using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using CSC237_UnitTest_start.Models;
using CSC237_UnitTest_start.Controllers;

namespace ContactManager.Tests
{
    public class ContactControllerTests
    {
        /************************
         * Details action method
         ************************/
        [Fact]
        public void Details_ReturnsViewResult()
        {
            // arrange
            var unit = GetDetailsUnitOfWork();
            var controller = new ContactController(unit);

            // act
            var result = controller.Details(1);

            // assert
            Assert.IsType<ViewResult>(result);
        }
        /*************************************************
         * private methods to get UnitOfWork
         *************************************************/
        private IUnitOfWork GetDetailsUnitOfWork()
        {
            var rep = new Mock<IRepository<Contact>>();
            rep.Setup(m => m.Get(It.IsAny<QueryOptions<Contact>>())).Returns(new Contact());

            var unit = new Mock<IUnitOfWork>();
            unit.Setup(m => m.Contacts).Returns(rep.Object);

            return unit.Object;
        }
    }
}
