using AutoMapper;
using izySick.Models;
using IzySickAPI.Dto;
using IzySickAPI.Interfaces;
using IzySickAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design.Serialization;

namespace IzySickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocteurController : Controller
    {
        private readonly IDocteurRepository _docteurRepository;
        private readonly IMapper _mapper;

        public DocteurController(IDocteurRepository docteurRepository, IMapper mapper)
        {
            _docteurRepository = docteurRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Docteur>))]
        public IActionResult GetDocteurs()
        {
            var docteurs = _mapper.Map<List<DocteurDto>>(_docteurRepository.GetDocteurs());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(docteurs);
        }
        
        [HttpGet("{DocId}")]
        [ProducesResponseType(200, Type= typeof(Docteur))]
        [ProducesResponseType(400)]
        public IActionResult GetDocteur(int DocId)
        {
            if (!_docteurRepository.DocteurExists(DocId)) return NotFound();
            var docteur = _mapper.Map<DocteurDto>(_docteurRepository.GetDocteur(DocId));

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(docteur);
        }

        [HttpGet("{DocId}/nbPatient")]
        [ProducesResponseType(200, Type = typeof(Docteur))]
        [ProducesResponseType(400)]
        public IActionResult GetNombrePatients(int DocId)
        {
            //if (docteurRepository.GetNombrePatients(DocId)) return NotFound();
            var nbPatient = _docteurRepository.GetNombrePatients(DocId);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(nbPatient);
        }

        [HttpGet("{DocId}/listPatients")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patient>))]
        [ProducesResponseType(400)]
        public IActionResult GetPatientOfDocteur(int DocId)
        {
            var patientofdoc = _docteurRepository.GetPatientOfDocteur(DocId);
            if (!ModelState.IsValid || patientofdoc == null) return BadRequest(ModelState);
            return Ok(patientofdoc);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDocteur( [FromBody] Docteur docteurCreate)
        {
            if (docteurCreate == null) return BadRequest();
            var docteur = _docteurRepository.GetDocteurs()
                            .Where(p => p.Nom.Trim().ToUpper() == docteurCreate.Nom.TrimEnd().ToUpper()).FirstOrDefault();
            if (docteur != null)
            {
                ModelState.AddModelError("", "Docteur already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_docteurRepository.CreateDocteur(docteurCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{docId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMedicament(int docId, [FromBody] Docteur updatedDocteur)
        {
            if (updatedDocteur == null) return BadRequest(ModelState);
            if (docId != updatedDocteur.DocteurId) return BadRequest(ModelState);
            if (!_docteurRepository.DocteurExists(docId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            if (!_docteurRepository.UpdateDocteur(updatedDocteur))
            {
                ModelState.AddModelError("", "Something went wrong updating docteur");
                return StatusCode(500, ModelState);
            }
            return NoContent();
            //return Ok(updatedDocteur);

        }

        [HttpDelete("{docId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDocteur(int docId)
        {
            if (!_docteurRepository.DocteurExists(docId)) return NotFound();
            var docteurToDelete = _docteurRepository.GetDocteur(docId);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_docteurRepository.DeleteDocteur(docteurToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting medicament");
            }
            return NoContent();
        }
    }

}
