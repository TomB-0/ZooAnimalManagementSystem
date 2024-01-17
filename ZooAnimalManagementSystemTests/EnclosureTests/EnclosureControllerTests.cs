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

namespace ZooAnimalManagementSystemTests.EnclosureTests
{
    public class EnclosureControllerTests
    {
        private readonly Mock<IEnclosureRepository> _mockEnclosureRepo;
        private readonly EnclosureController _enclosureController;

        public EnclosureControllerTests()
        {
            _mockEnclosureRepo = new Mock<IEnclosureRepository>();

            _enclosureController = new EnclosureController(_mockEnclosureRepo.Object);
        }

        [Fact]
        public async Task CreateEnclosure_ReturnsOk_WithEnclosure()
        {
            // Arrange
            var mockEnclosure = new Enclosure { Id = 1, Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } };
            var mockEnclosureDto = new EnclosureDto { Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } };
            _mockEnclosureRepo.Setup(repo => repo.CreateEnclosureAsync(It.IsAny<Enclosure>()))
                           .ReturnsAsync(mockEnclosure);

            // Act
            var result = await _enclosureController.CreateEnclosure(mockEnclosureDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockEnclosure, actionResult.Value);
        }

        [Fact]
        public async Task BulkCreateEnclosure_ReturnsOk()
        {
            // Arrange
            var mockEnclosure = new List<Enclosure> { new Enclosure { Id = 1, Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } } };
            var mockEnclosureDto = new EnclosureListDto { Enclosures = new List<EnclosureDto> { new EnclosureDto { Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } } } };
            _mockEnclosureRepo.Setup(repo => repo.CreateEnclosureAsync(It.IsAny<Enclosure>()))
                           .ReturnsAsync(mockEnclosure[0]);

            // Act
            var result = await _enclosureController.BulkCreateEnclosures(mockEnclosureDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateEnclosure_ReturnsOk_WithAnimal()
        {
            // Arrange
            var mockEnclosure = new Enclosure { Id = 1, Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } };
            var mockEnclosureDto = new EnclosureDto { Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } };
            _mockEnclosureRepo.Setup(repo => repo.UpdateEnclosureAsync(It.IsAny<Enclosure>()))
                           .ReturnsAsync(mockEnclosure);
            _mockEnclosureRepo.Setup(repo => repo.GetEnclosureAsync(It.IsAny<int>()))
               .ReturnsAsync(mockEnclosure);

            // Act
            var result = await _enclosureController.UpdateEnclosure(1, mockEnclosureDto);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockEnclosure, actionResult.Value);
        }

        [Fact]
        public async Task GetEnclosure_ReturnsOk_WithAnimal()
        {
            // Arrange
            var mockEnclosure = new Enclosure { Id = 1, Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } };
            _mockEnclosureRepo.Setup(repo => repo.GetEnclosureAsync(It.IsAny<int>()))
                           .ReturnsAsync(mockEnclosure);

            // Act
            var result = await _enclosureController.GetEnclosure(1);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockEnclosure, actionResult.Value);
        }

        [Fact]
        public async Task GetEnclosure_ReturnsNotFound_WhenEnclosureDoesNotExist()
        {
            // Act
            var result = await _enclosureController.GetEnclosure(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetEnclosures_Return_Ok_WithListOfAnimals()
        {
            // Arrange
            var mockEnclosure = new List<Enclosure> { new Enclosure { Id = 1, Name = "Enclosure 1", Size = EnclosureSize.Large, Location = EnclosureLocation.Inside, Objects = new List<String> { "Wall" } } };
            _mockEnclosureRepo.Setup(repo => repo.GetEnclosuresAsync())
            .ReturnsAsync(mockEnclosure);

            // Act
            var result = await _enclosureController.GetEnclosures();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(mockEnclosure, actionResult.Value);
        }

        [Fact]
        public async Task DeleteAnimal_ReturnsNoContent()
        {
            // Arrange
            _mockEnclosureRepo.Setup(repo => repo.DeleteEnclosureAsync(It.IsAny<int>()))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _enclosureController.DeleteEnclosure(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


    }
}
