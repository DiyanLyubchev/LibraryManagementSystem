using LibrarySystem.Models.Books;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibrarySystem.UnitTest
{
    [TestClass]
    public class Book_Should
    {
      
        [TestMethod]
        public void ValidPublishDate_Test()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var sut = new Book(isbn, title, pages, subject, publishers, publishDate, author);
            Assert.AreEqual("TestPublishDate", sut.PublishDate);
        }
    }
}