using LibrarySystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LibrarySystem.UnitTest.LibraryTest
{
    [TestClass]
    public class LibraryAddress_Should 
    {
        [TestMethod]
        public void SetValiLibraryAddress_Test()
        {
            var libraryAddress = "Vennesla, Norway";

            var library = new Library();
            library.Address = libraryAddress;

            Assert.AreEqual("Vennesla, Norway", library.Address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullExceptionWhenTheAddressIsNull_Test()
        {
            var library = new Library();
            library.Address = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExceptionWhenTheAddressIsMinLenght_Test()
        {

            var library = new Library();
            library.Address = "Li";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExceptionWhenTheNameIsMaxLenght_Test()
        {
            var library = new Library();
            library.Address = new String('L', 51);
        }
    }
}