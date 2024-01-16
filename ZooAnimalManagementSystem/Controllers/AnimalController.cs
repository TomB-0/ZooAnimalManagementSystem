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

        [HttpPut("animals/{id}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(int id, [FromBody] AnimalDto animalDto)
        {
            var animal = await _animalRepository.GetAnimalAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            var newAnimal = new Animal
            {
                Id = animal.Id,
                Species = animalDto.Species,
                Food = animalDto.Food,
                Amount = animalDto.Amount,
                EnclosureId = animal.EnclosureId,
                Enclosure = animal.Enclosure
            };

            try
            {
                var updatedAnimal = await _animalRepository.UpdateAnimalAsync(newAnimal);
                return Ok(updatedAnimal);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("animals/{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _animalRepository.GetAnimalAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpGet("animals")]
        public async Task<ActionResult<List<Animal>>> GetAnimals()
        {
            var animals = await _animalRepository.GetAnimalsAsync();
            return Ok(animals);
        }

        [HttpDelete("animals/{id}")]
        public async Task<ActionResult> DeleteAnimal(int id)
        {
            await _animalRepository.DeleteAnimalAsync(id);
            return NoContent();
        }
    }
}
