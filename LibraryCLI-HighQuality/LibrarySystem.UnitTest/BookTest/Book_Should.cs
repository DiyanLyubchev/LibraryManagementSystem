using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LibrarySystem.UnitTest.BookTest
{
    [TestClass]
    public class Book_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowArgumentNullExseptionWhenPublishDateIsNull_Test()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            string publishDate = null;
            var author = "TestAuthor";

            var sut = new Book(isbn, title, pages, subject, publishers, publishDate, author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentNullExseptionWhenPublishDateIsMinValue_Test()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "Test";
            var author = "TestAuthor";

            var sut = new Book(isbn, title, pages, subject, publishers, publishDate, author);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowArgumentNullExseptionWhenPublishDateIsMaxValue_Test()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = new String('V', 31);
            var author = "TestAuthor";

            var sut = new Book(isbn, title, pages, subject, publishers, publishDate, author);
        }

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