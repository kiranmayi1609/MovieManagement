using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Dto;
using WebAPI.Models;
using WebAPI.Repo;
using Xunit;

public class ActorControllerTests
{
    

    [Fact]
    public void GetAllActors_ReturnsOkResult()
    {
        // Arrange
        //Create a mock for the concrete genric repo 
        var mockRepo = new Mock<GenericRepocs<Actor>>();
        //Set up behaviour for the MOCK (returning list of actors)
        mockRepo.Setup(repo => repo.GetAll())
                .Returns(new List<Actor> { new Actor { Id = 1, Name = "Actor1" }, new Actor { Id = 2, Name = "Actor2" } });

        var actualRepoInstance=mockRepo.Object;

         // mockrepo.object to get the actual instance the mocked repo 
        var controller = new ActorController(actualRepoInstance);

        // Act
        var result = controller.GetAllActors();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }


    [Fact]
    public void CreateActor_ReturnsOkResult()
    {
        // Arrange
        var mockRepo = new Mock<GenericRepocs<Actor>>();
        var controller = new ActorController(mockRepo.Object);
        var actorDto = new ActorDto { Name = "New Actor" };

        // Act
        var result = controller.CreateActor(actorDto);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void UpdateActor_ReturnsOkResult()
    {
        // Arrange
        var mockRepo = new Mock<GenericRepocs<Actor>>();
        mockRepo.Setup(repo => repo.GetbyId(It.IsAny<int>()))
                .Returns(new Actor { Id = 1, Name = "ExistingActor" });

        var controller = new ActorController(mockRepo.Object);
        var actorDto = new ActorDto { Name = "UpdatedActor" };

        // Act
        var result = controller.UpdateActor(1, actorDto);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void UpdateActor_ReturnsNoContent_ForNonExistingActor()
    {
        // Arrange
        var mockRepo = new Mock<GenericRepocs<Actor>>();
        mockRepo.Setup(repo => repo.GetbyId(It.IsAny<int>()))
                .Returns((Actor)null);

        var controller = new ActorController(mockRepo.Object);
        var actorDto = new ActorDto { Name = "UpdatedActor" };

        // Act
        var result = controller.UpdateActor(1, actorDto);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void DeleteActor_ReturnsNoContentResult()
    {
        // Arrange
        var mockRepo = new Mock<GenericRepocs<Actor>>();
        mockRepo.Setup(repo => repo.GetbyId(It.IsAny<int>()))
                .Returns(new Actor { Id = 1, Name = "ExistingActor" });

        var controller = new ActorController(mockRepo.Object);

        // Act
        var result = controller.DeleteActor(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void DeleteActor_ReturnsNotFoundResult_ForNonExistingActor()
    {
        // Arrange
        var mockRepo = new Mock<GenericRepocs<Actor>>();
        mockRepo.Setup(repo => repo.GetbyId(It.IsAny<int>()))
                .Returns((Actor)null);

        var controller = new ActorController(mockRepo.Object);

        // Act
        var result = controller.DeleteActor(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }


}
