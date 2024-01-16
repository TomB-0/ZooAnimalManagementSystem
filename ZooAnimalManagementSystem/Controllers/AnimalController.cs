using Microsoft.AspNetCore.Mvc;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;

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
        public async Task<ActionResult<Animal>> CreateAnimal(Animal animal)
        {
            var createdAnimal = await _animalRepository.CreateAnimalAsync(animal);
            return Ok(createdAnimal);
        }

        [HttpPut("animals/{animalId}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(Animal animal)
        {
            try
            {
                var updatedAnimal = await _animalRepository.UpdateAnimalAsync(animal);
                return Ok(updatedAnimal);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("animals/{animalId}")]
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

        [HttpDelete("animals/{animalId}")]
        public async Task<ActionResult> DeleteAnimal(int animalId)
        {
            return Ok();
        }
    }
}
