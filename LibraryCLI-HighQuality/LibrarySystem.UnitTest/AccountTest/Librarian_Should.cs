using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibrarySystem
{
    [TestClass]
    public class Custom_Unit_Test_Class1
    {
        [TestMethod]
        public void ValidateCorrectUsernameLibrarian_Test()
        {
            var userName = "TestName";

            var sut = new Librarian(userName);

            Assert.AreEqual("TestName", sut.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExceptionWhenUserNameIsMinLenght_Test()
        {
            var userName = "Vn";

            var sut = new Librarian(userName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExceptionWhenUserNameIsMaxLenght_Test()
        {
            var userName = new String('V', 13);

            var sut = new Librarian(userName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullExceptionWhenUserNameIsMaxLenght_Test()
        {
            string userName = null;

            var sut = new Librarian(userName);
        }
    }
}