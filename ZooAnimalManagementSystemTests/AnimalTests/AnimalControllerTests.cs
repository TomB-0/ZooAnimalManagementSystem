using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ZooAnimalManagementSystem.Controllers;
using ZooAnimalManagementSystem.Dtos;
using ZooAnimalManagementSystem.Entities;
using ZooAnimalManagementSystem.Interfaces;
using static ZooAnimalManagementSystem.Helpers.Enums;

namespace ZooAnimalManagementSystemTests.AnimalTests
{
    public class AnimalControllerTests
    {
        private readonly Mock<IAnimalRepository> _mockAnimalRepo;
        private readonly AnimalController _animalController;

        public AnimalControllerTests()
        {
            _mockAnimalRepo = new Mock<IAnimalRepository>();

            _animalController = new AnimalController(_mockAnimalRepo.Object);
        }

        [Fact]
        public async Task CreateAnimal_ReturnsOk_WithAnimal()
        {
            // Arrange
            var mockAnimal = new Animal { Id = 1, Species = "wolf", Food = AnimalFood.Carnivore, Amount = 1};
            var mockAnimalDto = new AnimalDto { Species = "wolf", Food = AnimalFood.Carnivore, Amount = 1 };
            _mockAnimalRepo.Setup(repo => repo.CreateAnimalAsync(It.IsAny<Animal>()))
                           .ReturnsAsync(mockAnimal);

            // Act
            var result = await _animalController.CreateAnimal(mockAnimalDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockAnimal, actionResult.Value);
        }

        [Fact]
        public async Task UpdateAnimal_ReturnsOk_WithAnimal()
        {
            // Arrange
            var mockAnimal = new Animal { Id = 1, Species = "wolf", Food = AnimalFood.Carnivore, Amount = 1};
            var mockAnimalDto = new AnimalDto { Species = "wolf", Food = AnimalFood.Carnivore, Amount = 1 };
            _mockAnimalRepo.Setup(repo => repo.UpdateAnimalAsync(It.IsAny<Animal>()))
                           .ReturnsAsync(mockAnimal);
            _mockAnimalRepo.Setup(repo => repo.GetAnimalAsync(It.IsAny<int>()))
               .ReturnsAsync(mockAnimal);
            // Act
            var result = await _animalController.UpdateAnimal(1, mockAnimalDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockAnimal, actionResult.Value);
        }

        [Fact]
        public async Task GetAnimal_ReturnsOk_WithAnimal()
        {
            // Arrange
            var mockAnimal = new Animal { Id = 1, Species = "wolf", Food = AnimalFood.Carnivore, Amount = 1 }; 
            _mockAnimalRepo.Setup(repo => repo.GetAnimalAsync(It.IsAny<int>()))
                           .ReturnsAsync(mockAnimal);

            // Act
            var result = await _animalController.GetAnimal(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockAnimal, actionResult.Value);
        }

        [Fact]
        public async Task GetAnimal_ReturnsNotFound_WhenAnimalDoesNotExist()
        {
            // Act
            var result = await _animalController.GetAnimal(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetAnimals_Return_Ok_WithListOfAnimals()
        {
            // Arrange
            var mockAnimals = new List<Animal> { new Animal { Id = 1, Species = "wolf", Food = AnimalFood.Carnivore, Amount = 1 } };
            _mockAnimalRepo.Setup(repo => repo.GetAnimalsAsync())
            .ReturnsAsync(mockAnimals);

            // Act
            var result = await _animalController.GetAnimals();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockAnimals, actionResult.Value);
        }

        [Fact]
        public async Task DeleteAnimal_ReturnsNoContent()
        {
            // Arrange
            _mockAnimalRepo.Setup(repo => repo.DeleteAnimalAsync(It.IsAny<int>()))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _animalController.DeleteAnimal(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
