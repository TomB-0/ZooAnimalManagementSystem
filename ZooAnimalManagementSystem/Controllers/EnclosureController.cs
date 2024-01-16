using Microsoft.AspNetCore.Mvc;
using System;
using System.Xml.Linq;
using ZooAnimalManagementSystem.Data;
using ZooAnimalManagementSystem.Dtos;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;
using static ZooAnimalManagementSystem.Helpers.Enums;

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
        public async Task<ActionResult<Enclosure>> CreateEnclosure(EnclosureDto createEnclosureDto)
        {
            var enclosure = new Enclosure
            {
                Name = createEnclosureDto.Name,
                Size = createEnclosureDto.Size,
                Location = createEnclosureDto.Location,
                Objects = createEnclosureDto.Objects

            };

            var createdEnclosure = await _enclosureRepository.CreateEnclosureAsync(enclosure);
            return Ok(createdEnclosure);
        }

        [HttpPut("enclosures/{id}")]
        public async Task<ActionResult<Enclosure>> UpdateEnclosure(int id, [FromBody] EnclosureDto enclosureDto)
        {
            var enclosure = await _enclosureRepository.GetEnclosureAsync(id);

            if (enclosure == null)
            {
                return NotFound();
            }

            var newEnclosure = new Enclosure
            {
                Id = enclosure.Id,
                Name = enclosureDto.Name,
                Size = enclosureDto.Size,
                Location = enclosureDto.Location,
                Objects = enclosureDto.Objects,
                Animals = enclosure.Animals
            };

            try
            {
                var updatedEnclosure = await _enclosureRepository.UpdateEnclosureAsync(newEnclosure);
                return Ok(updatedEnclosure);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("enclosures/{id}")]
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

        [HttpDelete("enclosures/{id}")]
        public async Task<ActionResult> DeleteEnclosure(int id)
        {
            await _enclosureRepository.DeleteEnclosureAsync(id);
            return NoContent();
        }
    }
}
