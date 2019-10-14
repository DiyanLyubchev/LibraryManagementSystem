using LibrarySystem.Models.Books;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibrarySystem.UnitTest
{
    [TestClass]
    public class Book_DB
    {
        [TestMethod]
        public void Create_Book()
        {

            var book = new BookTesting().GetBookForTesting();


            var options = TestUtilities.GetOptions(nameof(Create_Book));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                Assert.AreEqual(1, assertContext.Books.Count());
            }
        }
        [TestMethod]
        public void Create_BookWithCorrectNumberOfPages()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectNumberOfPages));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.Pages == pages);
                Assert.IsNotNull(createBook);
            }
        }

        [TestMethod]
        public void Create_BookWithCorrectAuthor()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectAuthor));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.Author == author);
                Assert.IsNotNull(createBook);
            }
        }
        [TestMethod]
        public void Create_BookWithCorrectIsbn()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectIsbn));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.ISBN == isbn);
                Assert.IsNotNull(createBook);
            }
        }
        [TestMethod]
        public void Create_BookWithCorrectTitle()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectTitle));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.Title == title);
                Assert.IsNotNull(createBook);
            }
        }
        [TestMethod]
        public void Create_BookWithCorrectSubject()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectSubject));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.Subject == subject);
                Assert.IsNotNull(createBook);
            }
        }
        [TestMethod]
        public void Create_BookWithCorrectPublishersName()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectPublishersName));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.Publishers == publishers);
                Assert.IsNotNull(createBook);
            }
        }
        [TestMethod]
        public void Create_BookWithCorrectPublisherDate()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);

            var options = TestUtilities.GetOptions(nameof(Create_BookWithCorrectPublisherDate));

            using (var actContext = new LibrarySystemContext(options))
            {
                actContext.Books.Add(book);
                actContext.SaveChanges();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var createBook = assertContext.Books.FirstOrDefault(b => b.PublishDate == publishDate);
                Assert.IsNotNull(createBook);
            }
        }
    }
}
