using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using CSC237_UnitTest_start.Controllers;
using CSC237_UnitTest_start.Models;

namespace ContactManager.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // arrange
            var rep = new Mock<IRepository<Contact>>();
            var controller = new HomeController(rep.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);

        }
    }
}
