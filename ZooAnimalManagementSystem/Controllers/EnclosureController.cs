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
            return Ok();
        }

        [HttpGet("enclosures")]
        public async Task<ActionResult<List<Enclosure>>> GetEnclosures()
        {
            return Ok();
        }

        [HttpGet("enclosures/{enclosureId}")]
        public async Task<ActionResult<Enclosure>> GetEnclosure(int enclosureId)
        {
            return Ok();
        }

        [HttpDelete("enclosures/{enclosureId}")]
        public async Task<ActionResult<Enclosure>> DeleteEnclosure(int enclosureId)
        {
            return Ok();
        }
    }
}
