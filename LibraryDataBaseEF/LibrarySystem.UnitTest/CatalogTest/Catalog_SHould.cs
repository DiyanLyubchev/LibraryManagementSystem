using LibrarySystem.Models.Books;
using LibrarySystem.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LibrarySystem
{
    [TestClass]
    public class Catalog_Should
    {
        [TestMethod]
        public void SearchInCatalogByTitle_Test()
        {
            var title = "TestTitle";

            var catalogAdd = new Dictionary<string, IList<Book>>();
            var expectedResult = new List<Book>();
            catalogAdd.Add(title, expectedResult);

            var sut = new CatalogService(catalogAdd);
            var actualResult = sut.SearchByTitle(title);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void InvalidSearchByTitle_Test()
        {
            var title = "TestTitle";

            var catalogAdd = new Dictionary<string, IList<Book>>();
            var expectedResult = new List<Book>();
            catalogAdd.Add(title, expectedResult);

            var sut = new CatalogService(catalogAdd);
            sut.SearchByTitle("Test");
        }

        [TestMethod]
        public void ValidSearchByAuthor_Test()
        {
            var author = "TestAuthor";

            var catalogAdd = new Dictionary<string, IList<Book>>();

            var expectedResult = new List<Book>();
            catalogAdd.Add(author, expectedResult);

            var sut = new CatalogService(null, catalogAdd);
            var actualResult = sut.SearchByAuthor(author);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void InValidSearchByAuthgor()
        {
            var author = "TestAuthor";

            var catalogAdd = new Dictionary<string, IList<Book>>();

            var expectedResult = new List<Book>();
            catalogAdd.Add(author, expectedResult);

            var sut = new CatalogService(null, catalogAdd);
            sut.SearchByAuthor("Test");
        }

        [TestMethod]
        public void ValidSearchByPublisher()
        {
            var subject = "TestPublisher";

            var catalogAdd = new Dictionary<string, IList<Book>>();
            var expectedResult = new List<Book>();
            catalogAdd.Add(subject, expectedResult);

            var sut = new CatalogService(null, null, catalogAdd);
            var actualResult = sut.SearchBySubject(subject);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void InValidSearchByPublisher()
        {
            var subject = "TestSubject";

            var catalogAdd = new Dictionary<string, IList<Book>>();
            var expectedResult = new List<Book>();
            catalogAdd.Add(subject, expectedResult);

            var sut = new CatalogService(null, null, catalogAdd);
            sut.SearchBySubject("Test");
        }

        [TestMethod]
        public void ValidSearchByPublishDate()
        {
            var publishDate = "publishDateTest";

            var catalogAdd = new Dictionary<string, IList<Book>>();
            var expectedResult = new List<Book>();
            catalogAdd.Add(publishDate, expectedResult);

            var sut = new CatalogService(null, null, null, catalogAdd);
            var actualResult = sut.SearchByPublishDate(publishDate);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void InValidSearchByPublishDate()
        {
            var publishDate = "TestPublishDate";

            var catalogAdd = new Dictionary<string, IList<Book>>();
            var expextedResult = new List<Book>();
            catalogAdd.Add(publishDate, expextedResult);

            var sut = new CatalogService(null, null, null, catalogAdd);
            sut.SearchByPublishDate("TestDate");
        }
    }
}