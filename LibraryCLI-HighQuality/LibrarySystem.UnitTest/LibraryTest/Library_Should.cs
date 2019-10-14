using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace LibrarySystem
{
    [TestClass]
    public class Library_Should
    {
        [TestMethod]
        public void LendBook_Test()  
        {
            var bookTitle = "testTitle";

            var accountMock = new Mock<IAccount>();
            var bookLandingMock = new Mock<IList<IBookLending>>();
            var systemMock = new Mock<ISystemService>();
            var catalogMock = new Mock<ICatalogService>();
            var rackMock = new Mock<IRack>();
            var bookItemMock = new Mock<IBookItem>();
            var bookMock = new Mock<IBook>();

            systemMock.Setup(system => system.BookLendings)
                .Returns(bookLandingMock.Object);

            bookMock.Setup(book => book.Title)
                .Returns(bookTitle);

            bookItemMock.Setup(bookItem => bookItem.Book)
                .Returns(bookMock.Object);

            rackMock.Setup(rack => rack.Letters)
                .Returns(new List<char> { bookTitle.ToUpper()[0] });

            rackMock.Setup(rack => rack.BookItems)
                .Returns(new List<IBookItem> { bookItemMock.Object });

            var sut = new LibraryService(systemMock.Object, catalogMock.Object);
            sut.Racks.Add(rackMock.Object);

            sut.LendBook(accountMock.Object, bookMock.Object);

            bookLandingMock.Verify(bookLanding => bookLanding.Add(It.IsAny<IBookLending>()), Times.Once);
        }

        [TestMethod]
        public void ReserveBook_Test()   
        {
            var bookTitle = "testTitle";

            var accountMock = new Mock<IAccount>();
            var bookReservationsMock = new Mock<IList<IBookReservation>>();
            var systemMock = new Mock<ISystemService>();
            var catalogMock = new Mock<ICatalogService>();
            var rackMock = new Mock<IRack>();
            var bookItemMock = new Mock<IBookItem>();
            var bookMock = new Mock<IBook>();

            systemMock.Setup(system => system.BookReservations)
                .Returns(bookReservationsMock.Object);

            bookMock.Setup(book => book.Title)
                .Returns(bookTitle);

            bookItemMock.Setup(bookItem => bookItem.Book)
                .Returns(bookMock.Object);

            rackMock.Setup(rack => rack.Letters)
                .Returns(new List<char> { bookTitle.ToUpper()[0] });
            rackMock.Setup(rack => rack.BookItems)
                .Returns(new List<IBookItem> { bookItemMock.Object });

            var sut = new LibraryService(systemMock.Object, catalogMock.Object);

            sut.Racks.Add(rackMock.Object);

            sut.ReserveBook(accountMock.Object, bookMock.Object);

            bookReservationsMock.Verify(bookReservations => bookReservations.Add(It.IsAny<IBookReservation>()), Times.Once);
        }

        [TestMethod]
        public void AddBookInCatalog_Test() 
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "26.06.2014";
            var author = "TestAuthor";

            var rackMock = new Mock<IRack>();
            var bookMock = new Mock<IBook>();

            var systemMock = new Mock<ISystemService>();
            var catalogMock = new Mock<ICatalogService>();
            var booksMock = new Mock<ISet<IBook>>();
            var bookItemsMock = new Mock<IList<IBookItem>>();
            var racks = new List<IRack>();

            rackMock.Setup(rack => rack.Letters)
                .Returns(new List<char> { title.ToUpper()[0] });

            rackMock.Setup(rack => rack.BookItems)
                .Returns(bookItemsMock.Object);

            racks.Add(rackMock.Object);

            bookMock.Setup(book => book.Title)
                 .Returns(title);
            bookMock.Setup(book => book.Subject)
                .Returns(subject);
            bookMock.Setup(book => book.Publishers)
                .Returns(publishers);
            bookMock.Setup(book => book.PublishDate)
                .Returns(publishDate);
            bookMock.Setup(book => book.Pages)
                .Returns(pages);
            bookMock.Setup(book => book.ISBN)
                .Returns(isbn);
            bookMock.Setup(book => book.Author)
                .Returns(author);

            booksMock.Setup(books => books.Add(It.IsAny<IBook>()))
                .Returns(true);

            var sut = new LibraryService(systemMock.Object, catalogMock.Object, racks, booksMock.Object);

            sut.AddBook(bookMock.Object);

            catalogMock.Verify(catalog => catalog.AddBook(bookMock.Object), Times.Once);
        }

        [TestMethod]
        public void AddBookInBook() 
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "26.06.2014";
            var author = "TestAuthor";

            var rackMock = new Mock<IRack>();
            var bookMock = new Mock<IBook>();

            var systemMock = new Mock<ISystemService>();
            var catalogMock = new Mock<ICatalogService>();
            var booksMock = new Mock<ISet<IBook>>();
            var bookItemsMock = new Mock<IList<IBookItem>>();
            var racks = new List<IRack>();

            rackMock.Setup(rack => rack.Letters)
                .Returns(new List<char> { title.ToUpper()[0] });

            rackMock.Setup(rack => rack.BookItems)
                .Returns(bookItemsMock.Object);

            racks.Add(rackMock.Object);

            bookMock.Setup(book => book.Title)
                 .Returns(title);
            bookMock.Setup(book => book.Subject)
                .Returns(subject);
            bookMock.Setup(book => book.Publishers)
                .Returns(publishers);
            bookMock.Setup(book => book.PublishDate)
                .Returns(publishDate);
            bookMock.Setup(book => book.Pages)
                .Returns(pages);
            bookMock.Setup(book => book.ISBN)
                .Returns(isbn);
            bookMock.Setup(book => book.Author)
                .Returns(author);

            booksMock.Setup(books => books.Add(It.IsAny<IBook>()))
                .Returns(true);

            var sut = new LibraryService(systemMock.Object, catalogMock.Object, racks, booksMock.Object);

            sut.AddBook(bookMock.Object);

            booksMock.Verify(books => books.Add(bookMock.Object), Times.Once);
        }
       
    }


}