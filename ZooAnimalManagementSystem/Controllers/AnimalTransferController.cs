using Microsoft.AspNetCore.Mvc;
using ZooAnimalManagementSystem.Interfaces;

namespace ZooAnimalManagementSystem.Controllers
{
    public class AnimalTransferController : BaseApiController
    {
        private readonly IAnimalTransferService _animalTransferService;

        public AnimalTransferController(IAnimalTransferService animalTransferService)
        {
            _animalTransferService = animalTransferService;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferAnimals()
        {
            try
            {
                await _animalTransferService.ResetAnimalEnclosures();
                await _animalTransferService.TransferAnimalsAsync();
                return Ok("Animals transferred successfully.");
            }
            catch
            {
                return BadRequest("Unable to find suitable Enclosure");
            }
        }

    }
}
