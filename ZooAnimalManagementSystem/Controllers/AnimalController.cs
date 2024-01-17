using Microsoft.AspNetCore.Mvc;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;
using ZooAnimalManagementSystem.Dtos;

namespace ZooAnimalManagementSystem.Controllers
{
    public class AnimalController : BaseApiController
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpPost("animals")]
        public async Task<ActionResult<Animal>> CreateAnimal(AnimalDto createAnimalDto)
        {
            var animal = new Animal
            {
                Species = createAnimalDto.Species,
                Food = createAnimalDto.Food,
                Amount = createAnimalDto.Amount
            };

            var createdAnimal = await _animalRepository.CreateAnimalAsync(animal);
            return Ok(createdAnimal);
        }

        [HttpPost("bulk/animals")]
        public async Task<IActionResult> BulkCreateAnimals([FromBody] AnimalListDto animals)
        {
            foreach (var createAnimalDto in animals.Animals)
            {
                Animal animal = new Animal
                {
                    Species = createAnimalDto.Species,
                    Food = createAnimalDto.Food,
                    Amount = createAnimalDto.Amount
                };
                await _animalRepository.CreateAnimalAsync(animal);
            }

            return Ok("Animals created successfully.");
        }

        [HttpPut("animals/{id}")]
        public async Task<ActionResult<AnimalEnclosureDto>> UpdateAnimal(int id, [FromBody] AnimalDto animalDto)
        {
            var animal = await _animalRepository.GetAnimalAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            animal.Species = animalDto.Species;
            animal.Food = animalDto.Food;
            animal.Amount = animalDto.Amount;

            try
            {
                var updatedAnimal = await _animalRepository.UpdateAnimalAsync(animal);

                var updatedAnimalEnclosureDto = new AnimalEnclosureDto
                {
                    Id = updatedAnimal.Id,
                    Species = updatedAnimal.Species,
                    Food = updatedAnimal.Food,
                    Amount = updatedAnimal.Amount,
                    EnclosureId = updatedAnimal.EnclosureId,
                    EnclosureDto = updatedAnimal.Enclosure != null ? new EnclosureDto
                    {
                        Name = updatedAnimal.Enclosure.Name,
                        Size = updatedAnimal.Enclosure.Size,
                        Location = updatedAnimal.Enclosure.Location,
                        Objects = updatedAnimal.Enclosure.Objects
                    } : null
                };

                return Ok(updatedAnimalEnclosureDto);
            }
            catch
            {
                return BadRequest("Update of animal failed");
            }
        }

        [HttpGet("animals/{id}")]
        public async Task<ActionResult<AnimalEnclosureDto>> GetAnimal(int id)
        {
            var animal = await _animalRepository.GetAnimalAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            var animalEnclosureDto = new AnimalEnclosureDto
            {
                Id = animal.Id,
                Species = animal.Species,
                Food = animal.Food,
                Amount = animal.Amount,
                EnclosureId = animal.EnclosureId,
                EnclosureDto = animal.Enclosure != null ? new EnclosureDto
                {
                    Name = animal.Enclosure.Name,
                    Size = animal.Enclosure.Size,
                    Location = animal.Enclosure.Location,
                    Objects = animal.Enclosure.Objects
                }: null
            };

            return Ok(animalEnclosureDto);
        }

        [HttpGet("animals")]
        public async Task<ActionResult<List<AnimalEnclosureDto>>> GetAnimals()
        {
            var animals = await _animalRepository.GetAnimalsAsync();

            List<AnimalEnclosureDto> animalEnclosureDtos = animals.Select(a => new AnimalEnclosureDto
            {
                Id = a.Id,
                Species = a.Species,
                Food = a.Food,
                Amount = a.Amount,
                EnclosureId = a.EnclosureId,
                EnclosureDto = a.Enclosure != null ? new EnclosureDto
                {
                    Name = a.Enclosure.Name,
                    Size = a.Enclosure.Size,
                    Location = a.Enclosure.Location,
                    Objects = a.Enclosure.Objects
                } : null
            }).ToList();

            return Ok(animalEnclosureDtos);
        }

        [HttpDelete("animals/{id}")]
        public async Task<ActionResult> DeleteAnimal(int id)
        {
            await _animalRepository.DeleteAnimalAsync(id);
            return NoContent();
        }
    }
}
