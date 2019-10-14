using LibrarySystem.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace LibrarySystem.UnitTest.LibraryTest
{
    [TestClass]
    public class LibraryName_Shold 
    {
        [TestMethod]
        public void SetValiLibraryAddress_Test()
        {
            var libraryName = "Vennesla Library and Cultural Cente";

            var library = new Library();
            library.Name = libraryName;

            Assert.AreEqual("Vennesla Library and Cultural Cente", library.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullExceptionWhenTheNameIsNull_Test()
        {
            var library = new Library();
            library.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExceptionWhenTheNameIsMinLenght_Test()
        {
            var library = new Library();
            library.Name = "Li";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentExceptionWhenTheNameIsMaxLenght_Test()
        {
            var library = new Library();
            library.Name = new String('L', 51);
        }
    }
}