using Microsoft.AspNetCore.Mvc;
using ZooAnimalManagementSystem.Dtos;
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
        public async Task<ActionResult<Enclosure>> CreateEnclosure(EnclosureDto createEnclosureDto)
        {
            var enclosure = new Enclosure
            {
                Name = createEnclosureDto.Name,
                Size = createEnclosureDto.Size,
                Location = createEnclosureDto.Location,
                Objects = createEnclosureDto.Objects,
                Animals = new List<Animal>()
            };

            var createdEnclosure = await _enclosureRepository.CreateEnclosureAsync(enclosure);
            return Ok(createdEnclosure);
        }

        [HttpPost("bulk/enclosures")]
        public async Task<IActionResult> BulkCreateEnclosures([FromBody] EnclosureListDto enclosures)
        {
            foreach (var createEnclosureDto in enclosures.Enclosures)
            {
                Enclosure enclosure = new Enclosure
                {
                    Name = createEnclosureDto.Name,
                    Size = createEnclosureDto.Size,
                    Location = createEnclosureDto.Location,
                    Objects = createEnclosureDto.Objects,
                    Animals = new List<Animal>()
                };
                await _enclosureRepository.CreateEnclosureAsync(enclosure);
            }

            return Ok("Enclosures uploaded successfully.");
        }

        [HttpPut("enclosures/{id}")]
        public async Task<ActionResult<EnclosureAnimalsDto>> UpdateEnclosure(int id, [FromBody] EnclosureDto enclosureDto)
        {
            var enclosure = await _enclosureRepository.GetEnclosureAsync(id);

            if (enclosure == null)
            {
                return NotFound();
            }

            enclosure.Name = enclosureDto.Name;
            enclosure.Location = enclosureDto.Location;
            enclosure.Objects = enclosureDto.Objects;
            enclosure.Size = enclosureDto.Size;

            try
            {
                var updatedEnclosure = await _enclosureRepository.UpdateEnclosureAsync(enclosure);

                var enclosureAnimalsDto = new EnclosureAnimalsDto
                {
                    Id = updatedEnclosure.Id,
                    Name = updatedEnclosure.Name,
                    Size = updatedEnclosure.Size,
                    Location = updatedEnclosure.Location,
                    Objects = updatedEnclosure.Objects,
                    AnimalDtos = updatedEnclosure.Animals?.Select(a => new AnimalDto
                    {
                        Species = a.Species,
                        Food = a.Food,
                        Amount = a.Amount,
                    }).ToList() ?? new List<AnimalDto>()
                };

                return Ok(enclosureAnimalsDto);
            }
            catch
            {
                return BadRequest("Update of enclosure failed");
            }
        }

        [HttpGet("enclosures/{id}")]
        public async Task<ActionResult<EnclosureAnimalsDto>> GetEnclosure(int id)
        {
            var enclosure = await _enclosureRepository.GetEnclosureAsync(id);
            if (enclosure == null)
            {
                return NotFound();
            }

            var enclosureAnimalsDto = new EnclosureAnimalsDto
            {
                Id = enclosure.Id,
                Name = enclosure.Name,
                Size = enclosure.Size,
                Location = enclosure.Location,
                Objects = enclosure.Objects,
                AnimalDtos = enclosure.Animals?.Select(a => new AnimalDto
                {
                    Species = a.Species,
                    Food = a.Food,
                    Amount = a.Amount,
                }).ToList() ?? new List<AnimalDto>()
            };

            return Ok(enclosureAnimalsDto);
        }

        [HttpGet("enclosures")]
        public async Task<ActionResult<List<EnclosureAnimalsDto>>> GetEnclosures()
        {
            var enclosures = await _enclosureRepository.GetEnclosuresAsync();

            List<EnclosureAnimalsDto> enclosureAnimalsDtos = enclosures
                .Select(e => new EnclosureAnimalsDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Size = e.Size,
                    Location = e.Location,
                    Objects = e.Objects,
                    AnimalDtos = e.Animals?.Select(a => new AnimalDto
                    {
                        Species = a.Species,
                        Food = a.Food,
                        Amount = a.Amount,
                    }).ToList() ?? new List<AnimalDto>()
                })
                .ToList();

            return Ok(enclosureAnimalsDtos);
        }

        [HttpDelete("enclosures/{id}")]
        public async Task<ActionResult> DeleteEnclosure(int id)
        {
            await _enclosureRepository.DeleteEnclosureAsync(id);
            return NoContent();
        }
    }
}
