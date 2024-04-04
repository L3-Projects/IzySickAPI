using izySick.Models;
using IzySickAPI.Dto;
using IzySickAPI.Interfaces;
using IzySickAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IzySickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentController : Controller
    {
        private readonly IMedicamentRepository _medicamentRepository;

        public MedicamentController(IMedicamentRepository medicamentRepository)
        {
            _medicamentRepository = medicamentRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type= typeof(IEnumerable<Medicaments>))]
        public IActionResult GetMedicaments()
        {
            var medicaments = _medicamentRepository.GetMedicaments();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(medicaments);

        }
        [HttpGet("{medId}")]
        [ProducesResponseType(200, Type = typeof(Medicaments))]
        public IActionResult GetMedicament (int medId)
        {
            if (!_medicamentRepository.MedicamentExists(medId)) return NotFound();
            var medicament = _medicamentRepository.GetMedicament(medId);

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(medicament);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatMedicament([FromBody] Medicaments medicamentcreate)
        {
            if (medicamentcreate == null) return BadRequest();
            var medicament = _medicamentRepository.GetMedicaments()
                            .Where(p => p.NomMedicament.Trim().ToUpper() == medicamentcreate.NomMedicament.TrimEnd().ToUpper()).FirstOrDefault();
            if (medicament != null)
            {
                ModelState.AddModelError("", "Docteur already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_medicamentRepository.CreateMedicament(medicamentcreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{medicamentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateMedicament(int medicamentId,[FromBody] Medicaments updatedMedicament) 
        {
            if(updatedMedicament == null) return BadRequest(ModelState);
            if(medicamentId != updatedMedicament.MedicamentsId) return BadRequest(ModelState);
            if (!_medicamentRepository.MedicamentExists(medicamentId)) return NotFound();
            if (!ModelState.IsValid) return BadRequest();
            if (!_medicamentRepository.UpdateMedicament( updatedMedicament))
            {
                ModelState.AddModelError("", "Something went wrong updating medicament");
                return StatusCode(500, ModelState);
            }
            return NoContent();
            //return Ok(updatedMedicament);
        
        }

        [HttpDelete("{medicamentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteMedicament(int medicamentId)
        {
            if (!_medicamentRepository.MedicamentExists(medicamentId)) return NotFound();
            var medicamentToDelete = _medicamentRepository.GetMedicament(medicamentId);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_medicamentRepository.DeleteMedicament(medicamentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting medicament");
            }
            return NoContent();
        }
    }
}
