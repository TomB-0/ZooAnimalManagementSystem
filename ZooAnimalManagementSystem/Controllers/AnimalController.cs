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
            return Ok();
        }

        [HttpPut("animals/{animalId}")]
        public async Task<ActionResult<Animal>> UpdateAnimal(Animal animal)
        {
            return Ok();
        }

        [HttpGet("animals/{animalId}")]
        public async Task<ActionResult<Animal>> GetAnimal(int animalId)
        {
            return Ok();
        }

        [HttpGet("animals")]
        public async Task<ActionResult<List<Animal>>> GetAnimals()
        {
            return Ok();
        }

        [HttpDelete("animals/{animalId}")]
        public async Task<ActionResult> DeleteAnimal(int animalId)
        {
            return Ok();
        }
    }
}
