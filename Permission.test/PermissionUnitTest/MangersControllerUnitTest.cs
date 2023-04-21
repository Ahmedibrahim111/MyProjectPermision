using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Permission.Controllers;
using Permission.Model;
using Microsoft.EntityFrameworkCore;

namespace Permission.test.PermissionUnitTest
{
    public class MangersControllerUnitTest
    {
      
            private readonly NewMangerController _controller;

    


       
        public MangersControllerUnitTest()
        {
            _controller = new NewMangerController();

        }
        [Fact]
            public void Get_WhenCalled_ReturnsOkResult()
            {
            var _controller = new NewMangerController();

            // Act
            var okResult = _controller.Getmangers().Result;

                // Assert
                Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
            }

        [Fact]
        public void GetCount_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Getmangers().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Manger>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetManger(10);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var testGuid = 2;

            // Act
            var okResult = _controller.GetManger(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = 2;

            // Act
            var okResult = _controller.GetManger(testGuid) as OkObjectResult;

            // Assert
            Assert.IsType<Manger>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Manger).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Manger()
            {
                Id = 3,
                Name = ""
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.PostManger(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Manger manger = new Manger()
            {
                Id = 3,
                Name = "mohamed"
            };

            // Act
            var createdResponse = _controller.PostManger(manger);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Manger()
            {
                Id = 5,
                Name = "hassan"
            };

            // Act
            var createdResponse = _controller.PostManger(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Manger;

            // Assert
            Assert.IsType<Manger>(item);
            Assert.Equal("hassan", item.Name);
        }

        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = 10;

            // Act
            var badResponse = _controller.DeleteManger(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid =1;

            // Act
            var noContentResponse = _controller.DeleteManger(existingGuid);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }


    }
}
