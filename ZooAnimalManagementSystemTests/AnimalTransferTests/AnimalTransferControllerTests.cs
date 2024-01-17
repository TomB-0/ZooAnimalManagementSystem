using Microsoft.AspNetCore.Mvc;
using Moq;
using ZooAnimalManagementSystem.Controllers;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;
using ZooAnimalManagementSystem.Services;
using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystemTests.AnimalTransferTests
{
    public class AnimalTransferControllerTests
    {
        private readonly Mock<IAnimalRepository> _mockAnimalRepo;
        private readonly Mock<IEnclosureRepository> _mockEnclosureRepo;
        private readonly AnimalTransferService _animalTransferService;
        private readonly AnimalTransferController _animalTransferController;

        public AnimalTransferControllerTests()
        {
            _mockAnimalRepo = new Mock<IAnimalRepository>();
            _mockEnclosureRepo = new Mock<IEnclosureRepository>();
            _animalTransferService = new AnimalTransferService(_mockAnimalRepo.Object, _mockEnclosureRepo.Object);
            _animalTransferController = new AnimalTransferController(_animalTransferService);
        }

        [Fact]
        public async Task TransferAnimalsAsync_AssignsAnimalsToSuitableEnclosures()
        {
            // Arrange
            var animals = new List<Animal> { new Animal { Id = 1, Amount = 1, Food = AnimalFood.Herbivore, Species = "Lama"} };
            var enclosures = new List<Enclosure> { new Enclosure { Id = 1, Location = EnclosureLocation.Inside, Name = "Enclousure 1", Size = EnclosureSize.Large, Objects = new List<String> { "Wall" }, Animals = new List<Animal>() } };

            _mockAnimalRepo.Setup(repo => repo.GetAnimalsAsync()).ReturnsAsync(animals);
            _mockEnclosureRepo.Setup(repo => repo.GetEnclosuresAsync()).ReturnsAsync(enclosures);

            // Act
            var result = await _animalTransferController.TransferAnimals();

            // Assert

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task TransferAnimalsAsync_FailToAssignAnimalsToSuitableEnclosures_WhenThereIsNoSpaceInEnclosures()
        {
            // Arrange
            var animals = new List<Animal> { new Animal { Id = 1, Amount = 100, Food = AnimalFood.Herbivore, Species = "Lama" } };
            var enclosures = new List<Enclosure> { new Enclosure { Id = 1, Location = EnclosureLocation.Inside, Name = "Enclousure 1", Size = EnclosureSize.Large, Objects = new List<String> { "Wall" }, Animals = new List<Animal>() } };

            _mockAnimalRepo.Setup(repo => repo.GetAnimalsAsync()).ReturnsAsync(animals);
            _mockEnclosureRepo.Setup(repo => repo.GetEnclosuresAsync()).ReturnsAsync(enclosures);

            // Act
            var result = await _animalTransferController.TransferAnimals();

            // Assert

            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
