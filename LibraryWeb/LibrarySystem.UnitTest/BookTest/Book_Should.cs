using LibrarySystem.DbContext;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using LibrarySystem.Services.Core;
using LibrarySystem.Services.Dto;
using LibrarySystem.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services.CustomException.BookTest
{
    [TestClass]
    public class Book_Should
    {

        [TestMethod]
        public async Task RenewBook_Test()
        {
            var isbn = "TestIsbn";
            var username = "TestUsername";
            var days = 5;

            var renewBookDto = new RenewBookDto();
            var lendDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(RenewBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { ISBN = isbn });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();

                renewBookDto.BookId = days;
                renewBookDto.BookId = book.Entity.Id;
                renewBookDto.UserId = user.Entity.Id;

                lendDto.Title = book.Entity.Title;
                lendDto.UserId = user.Entity.Id;

                var bookLending = new BookWebService(actContext);
                await bookLending.LendBookAsync(lendDto);
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.RenewBookAsync(renewBookDto);
                var actuaDays = assertContext.BookLendings.Select(book => book.Date);

                Assert.IsNotNull(actuaDays);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowExeptionWhenBookLendingIsNullRenewBook_Test()
        {
            var isbn = "TestIsbn";
            var username = "TestUsername";
            var days = 5;

            var renewBookDto = new RenewBookDto();
            var lendDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenBookLendingIsNullRenewBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { ISBN = isbn });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();

                renewBookDto.BookId = days;
                renewBookDto.BookId = book.Entity.Id;
                renewBookDto.UserId = user.Entity.Id;
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.RenewBookAsync(renewBookDto);
                var actuaDays = assertContext.BookLendings.Select(book => book.Date);
            }
        }

        [TestMethod]
        public async Task ReturnBook_Test()
        {
            var isbn = "TestIsbn";
            var username = "TestUsername";
            var reviewDto = new ReviewDto();
            var lendDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(ReturnBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { ISBN = isbn });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();

                reviewDto.ISBN = book.Entity.ISBN;
                reviewDto.BookId = book.Entity.Id;
                reviewDto.UserId = user.Entity.Id;

                lendDto.Title = book.Entity.Title;
                lendDto.UserId = user.Entity.Id;

                var bookLending = new BookWebService(actContext);
                await bookLending.LendBookAsync(lendDto);
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.ReturnBookAsync(reviewDto);

                Assert.AreEqual(0, assertContext.BookLendings.Count());
            }
        }


        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowExeptionWhenBookIdIsNullReturnBook_Test()
        {
            var title = "TestTitle";
            var username = "TestUsername";
            var reviewDto = new ReviewDto();
            var lendDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenBookIdIsNullReturnBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { Title = title });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();

                reviewDto.UserId = user.Entity.Id;

                lendDto.UserId = user.Entity.Id;

                var bookLending = new BookWebService(actContext);
                await bookLending.LendBookAsync(lendDto);
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.ReturnBookAsync(reviewDto);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowExeptionWhenUserNoHAveBookForReturnReturnBook_Test()
        {
            var isbn = "TestIsbn";
            var username = "TestUsername";
            var reviewDto = new ReviewDto();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenUserNoHAveBookForReturnReturnBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { ISBN = isbn });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();

                reviewDto.ISBN = book.Entity.ISBN;
                reviewDto.BookId = book.Entity.Id;
                reviewDto.UserId = user.Entity.Id;
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.ReturnBookAsync(reviewDto);
            }
        }

        [TestMethod]
        public async Task ReserveBook_Test()
        {
            var title = "TestTitle";
            var username = "TestUser";
            var reserveBookDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(ReserveBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { Title = title });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();
                reserveBookDto.Title = title;
                reserveBookDto.UserId = user.Entity.Id;
            }


            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookReserve = await sut.ReserveBookAsync(reserveBookDto);

                Assert.IsTrue(bookReserve);
            }
        }
        [TestMethod]
        public async Task ReturnFalseWhenBookIsNullReserveBook_Test()
        {
            string title = null;
            var username = "TestUser";
            var reserveBookDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(ReturnFalseWhenBookIsNullReserveBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();
                reserveBookDto.Title = title;
                reserveBookDto.UserId = user.Entity.Id;
            }


            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookReserve = await sut.ReserveBookAsync(reserveBookDto);

                Assert.IsFalse(bookReserve);
            }
        }

        [TestMethod]
        public void Create_Book_Test()
        {
            var book = BookGeneratorUtil.GenerateBook();

            var options = TestUtilities.GetOptions(nameof(Create_Book_Test));

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
        public async Task AddBook_Test()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";
            var picture = "TestPicture";

            var options = TestUtilities.GetOptions(nameof(AddBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(actContext);
                var book = await sut.CreateBookAsync(isbn, title, pages, subject, publishers, publishDate, author, picture);

                Assert.IsNotNull(book);
                Assert.AreEqual(1, actContext.Books.Count());
            }
        }

        [TestMethod]
        [DataRow("00-23-56-43", null)]
        [DataRow(null, "BIBLIQTA 2")]
        [DataRow(null, null)]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowBookExeptionInvalidInputAddBook_Test(string isbn, string title)
        {
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";
            var picture = "TestPicture";

            var options = TestUtilities.GetOptions(nameof(ThrowBookExeptionInvalidInputAddBook_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(actContext);
                var book = await sut.CreateBookAsync(isbn, title, pages, subject, publishers, publishDate, author, picture);
            }
        }

        [TestMethod]
        public async Task SearchBookByTitle_Test()
        {
            var title = "TestTitle";

            var options = TestUtilities.GetOptions(nameof(SearchBookByTitle_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Title = title });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(title, null, null, null);

                Assert.IsNotNull(bookSearch);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowBookException_WhenTitleIsIncorrect_Test()
        {
            var title = "TestTitle";

            var options = TestUtilities.GetOptions(nameof(ThrowBookException_WhenTitleIsIncorrect_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Title = "hello" });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(title, null, null, null);
            }
        }
        [TestMethod]
        public async Task SearchBookBySubject_Test()
        {
            var subject = "TestSubject";

            var options = TestUtilities.GetOptions(nameof(SearchBookBySubject_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Subject = subject });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(null, subject, null, null);

                Assert.IsNotNull(bookSearch);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowBookException_WhenSubjectIsIncorrect_Test()
        {
            var subject = "TestSubject";

            var options = TestUtilities.GetOptions(nameof(ThrowBookException_WhenSubjectIsIncorrect_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Subject = "Other Subject" });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(null, subject, null, null);
            }
        }

        [TestMethod]
        public async Task SearchBookByAuthor_Test()
        {
            var author = "TestAuthor";

            var options = TestUtilities.GetOptions(nameof(SearchBookByAuthor_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Author = author });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(null, null, author, null);

                Assert.IsNotNull(bookSearch);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowBookException_WhenAuthorIsIncorrect_Test()
        {
            var author = "TestAuthor";

            var options = TestUtilities.GetOptions(nameof(ThrowBookException_WhenAuthorIsIncorrect_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Author = "Other Author" });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(null, null, author, null);
            }
        }

        [TestMethod]
        public async Task SearchBookByPublishDate_Test()
        {
            var publishDate = "TestDate";

            var options = TestUtilities.GetOptions(nameof(SearchBookByPublishDate_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { PublishDate = publishDate });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(null, null, null, publishDate);

                Assert.IsNotNull(bookSearch);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowBookException_WhenPublishDateIsIncorrect_Test()
        {
            var publishDate = "TestDate";

            var options = TestUtilities.GetOptions(nameof(ThrowBookException_WhenPublishDateIsIncorrect_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { PublishDate = "Other Date" });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var bookSearch = await sut.SearchBookAsync(null, null, null, publishDate);
            }
        }
        [TestMethod]
        public async Task FindBookBookById_Test()
        {
            var id = 2;

            var options = TestUtilities.GetOptions(nameof(FindBookBookById_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Id = id });
                await actContext.SaveChangesAsync();

            }


            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                var findBook = await sut.FindBookAsync(id);

                Assert.IsNotNull(findBook);
            }

        }
        [TestMethod]
        public async Task RemoveBook_Test()
        {
            var isbn = "1234567890";

            var options = TestUtilities.GetOptions(nameof(ThrowBookException_WhenPublishDateIsIncorrect_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                var book = await actContext.Books.AddAsync(new Book { ISBN = isbn });
                await actContext.SaveChangesAsync();
            }

            var removeBookDto = new RemoveBookDto
            {
                ISBN = isbn
            };

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.RemoveBookAsync(removeBookDto);
                Assert.AreEqual(0, assertContext.Books.Count());
            }
        }
        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task ThrowBookExceptionNotExistBook_RemoveBook_Test()
        {
            var isbn = "1234567890";

            var options = TestUtilities.GetOptions(nameof(ThrowBookException_WhenPublishDateIsIncorrect_Test));

            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { ISBN = "1111111111" });
                await actContext.SaveChangesAsync();
            }

            var removeBookDto = new RemoveBookDto
            {
                ISBN = isbn
            };

            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.RemoveBookAsync(removeBookDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(BookException))]
        public async Task THrowExeptionWhenBookIsNull_LendBook_test()
        {
            string title = null;
            var username = "TestUser";
            var lendBookDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(THrowExeptionWhenBookIsNull_LendBook_test));


            using (var actContext = new LibrarySystemContext(options))
            {
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();
                lendBookDto.Title = title;
                lendBookDto.UserId = user.Entity.Id;
            }


            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.LendBookAsync(lendBookDto);

                Assert.AreEqual(1, assertContext.BookLendings.Count());
            }
        }

        [TestMethod]
        public async Task LendBook_Test()
        {
            var title = "TestTitle";
            var username = "TestUser";
            var lendBookDto = new BaseTitleDto();

            var options = TestUtilities.GetOptions(nameof(LendBook_Test));


            using (var actContext = new LibrarySystemContext(options))
            {
                await actContext.Books.AddAsync(new Book { Title = title });
                var user = await actContext.Users.AddAsync(new User { UserName = username });
                await actContext.SaveChangesAsync();
                lendBookDto.Title = title;
                lendBookDto.UserId = user.Entity.Id;
            }


            using (var assertContext = new LibrarySystemContext(options))
            {
                var sut = new BookWebService(assertContext);
                await sut.LendBookAsync(lendBookDto);

                Assert.AreEqual(1, assertContext.BookLendings.Count());
            }

        }
    }
}
