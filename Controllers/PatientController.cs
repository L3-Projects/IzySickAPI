using izySick.Models;
using IzySickAPI.Dto;
using IzySickAPI.Interfaces;
using IzySickAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IzySickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDocteurRepository _docteurRepository;

        public PatientController(IPatientRepository patientRepository, IDocteurRepository docteurRepository)
        {
            _patientRepository = patientRepository;
            _docteurRepository = docteurRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patient>))]
        public IActionResult GetPatients() 
        { 
            var patients = _patientRepository.GetPatients(); 
            if (!ModelState.IsValid) return BadRequest();
            return Ok(patients);
        
        }

        [HttpGet("{patientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patient>))]
        public IActionResult GetPatient(int patientId)
        {
            if (!_patientRepository.PatientExists(patientId)) return NotFound();
            var patient = _patientRepository.GetPatient(patientId);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(patient);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePatient([FromQuery] int docteurId ,[FromBody] Patient patientCreate)
        {
            if(patientCreate == null) return BadRequest();
            var patient = _patientRepository.GetPatients()
                            .Where(p => p.Nom.Trim().ToUpper() == patientCreate.Nom.TrimEnd().ToUpper()).FirstOrDefault();
           
           
            if (patient != null)
            {
                ModelState.AddModelError("","Patient already exists");
                return StatusCode(422, ModelState);
            }

            // var patientMap = _mapper.Map<Patient>(patientCreate);
            //if(!_patientRepository.CreatePatient(patientMap))
            //{
            //    ModelState.AddModelError("", "Something went wrong while saving");
            //    return StatusCode(500, ModelState);
            //}
            
            if (!ModelState.IsValid) return BadRequest(ModelState);
            patientCreate.DocteurTraitant = _docteurRepository.GetDocteur(docteurId);
            if (!_patientRepository.CreatePatient(docteurId, patientCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{patientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePatient(int patientId,[FromQuery] int docId, [FromBody] Patient updatedPatient)
        {
            if (updatedPatient == null) return BadRequest(ModelState);
            if (docId != updatedPatient.DocteurId) return BadRequest(ModelState);
            if (!_patientRepository.PatientExists(docId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            if(!_patientRepository.UpdatePatient(docId, updatedPatient))
            {
                ModelState.AddModelError("","Something went wrong updating patient");
                return StatusCode(500, ModelState); 
            }
            return NoContent();
            //return Ok(updatedPatient);

        }

        [HttpDelete("{patientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePatient(int patientId)
        {
            if (!_docteurRepository.DocteurExists(patientId)) return NotFound();
            var patientToDelete = _patientRepository.GetPatient(patientId);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_patientRepository.DeletePatient(patientToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting docteur");
            }
            return NoContent();
        }
    }
}
