using LibrarySystem.Services.Core;
using LibrarySystem.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;

namespace LibrarySystem.UnitTest.ControllerTests
{
    [TestClass]
    public class BookControllerTests
    {
        [TestMethod]
        public void SearchAction_Test()
        {
            var bookWebService = new Mock<IBookWebService>();

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new BookController(bookWebService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = controller.SearchBook();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
