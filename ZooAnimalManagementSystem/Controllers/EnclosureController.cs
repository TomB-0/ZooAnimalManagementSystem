using Microsoft.AspNetCore.Mvc;
using ZooAnimalManagementSystem.Data;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;

namespace ZooAnimalManagementSystem.Controllers
{
    public class EnclosureController : BaseApiController
    {
        private readonly IEnclosureRepository _enclosureRepository;

        public EnclosureController(IEnclosureRepository enclosureRepository)
        {
            _enclosureRepository = enclosureRepository;
        }

        [HttpPost("enclosures")]
        public async Task<ActionResult<Enclosure>> CreateEnclosure(Enclosure enclosure)
        {
            var createdEnclosure = await _enclosureRepository.CreateEnclosureAsync(enclosure);
            return Ok(createdEnclosure);
        }

        [HttpPut("enclosures/{enclosureId}")]
        public async Task<ActionResult<Enclosure>> UpdateEnclosure(Enclosure enclosure)
        {
            try
            {
                var updatedEnclosure = await _enclosureRepository.UpdateEnclosureAsync(enclosure);
                return Ok(updatedEnclosure);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("enclosures/{enclosureId}")]
        public async Task<ActionResult<Enclosure>> GetEnclosure(int id)
        {
            var enclosure = await _enclosureRepository.GetEnclosureAsync(id);
            if (enclosure == null)
            {
                return NotFound();
            }
            return Ok(enclosure);
        }

        [HttpGet("enclosures")]
        public async Task<ActionResult<List<Enclosure>>> GetEnclosures()
        {
            var enclosures = await _enclosureRepository.GetEnclosuresAsync();
            return Ok(enclosures);
        }

        [HttpDelete("enclosures/{enclosureId}")]
        public async Task<ActionResult> DeleteEnclosure(int id)
        {
            await _enclosureRepository.DeleteEnclosureAsync(id);
            return NoContent();
        }
    }
}
