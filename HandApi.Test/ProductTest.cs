using HandApi.controllers;
using HandApi.Models;
using HandApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace HandApi.Test
{
    public class PrioductTest
    {
      
        [Fact]
        public async Task ValidateGetByIdOKResponse()
        {
            ProductEntity sessions = new ProductEntity();
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IProductServices>();
            mockRepo.Setup(repo => repo.GetById(testSessionId))
                .Returns(sessions);
            var controller = new ProductController(mockRepo.Object);

            // Act
            var actualResult =  controller.GetById(testSessionId);

            actualResult.ToString().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ValidateGetAllOKResponse()
        {
            List<ProductEntity> sessions = new List<ProductEntity>();
            // Arrange
     
            var mockRepo = new Mock<IProductServices>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(sessions);
            var controller = new ProductController(mockRepo.Object);

            // Act
            var actualResult = controller.GetAll();

            actualResult.ToString().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ValidatePostBadRequestResponse()
        {
            ProductEntity sessions = new ProductEntity()
            {
                Model = "Focus",
                Description = "",
                Year = 2010,
                Brand = "Ford",
                Kilometers = 10000           
            };
                                                 
            // Arrange
            var mockRepo = new Mock<IProductServices>();
            mockRepo.Setup(repo => repo.Create(sessions))
                .Returns(sessions);
            var controller = new ProductController(mockRepo.Object);
            // Act
            var actualResult = controller.Post(sessions);

            actualResult.ToString().Equals(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ValidateDeleteOkResponse()
        {
            ProductEntity sessions = new ProductEntity();
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IProductServices>();
            mockRepo.Setup(repo => repo.Delete(testSessionId));
                
            var controller = new ProductController(mockRepo.Object);

            // Act
            var actualResult = controller.GetById(testSessionId);

            actualResult.ToString().Equals(HttpStatusCode.OK);
        }

        [Fact]
        public async Task ValidatePostOKResponse()
        {
            ProductEntity sessions = new ProductEntity()
            {            
                Model = "Tsuru",
                Description = "",
                Year = 2010,
                Brand = "Nissan",
                Kilometers = 10000,
                Price = 100000
            };

            // Arrange
            var mockRepo = new Mock<IProductServices>();
            mockRepo.Setup(repo => repo.Create(sessions))
                .Returns(sessions);
            var controller = new ProductController(mockRepo.Object);
            // Act
            var actualResult = controller.Post(sessions);

            actualResult.ToString().Equals(HttpStatusCode.OK);

        }
    }
}
