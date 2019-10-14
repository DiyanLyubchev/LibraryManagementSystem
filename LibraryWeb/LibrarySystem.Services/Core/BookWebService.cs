using LibrarySystem.Books;
using LibrarySystem.DbContext;
using LibrarySystem.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LibrarySystem.Services.CustomException;
using LibrarySystem.Models;
using LibrarySystem.Services.Dto;

namespace LibrarySystem.Services.Core
{
    public class BookWebService : IBookWebService
    {
        private readonly LibrarySystemContext dbContext;
        private const int maxLendedBooks = 4;
        private const int minLendedBooks = 1;

        public BookWebService(LibrarySystemContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await this.dbContext.Books
                .Include(review => review.Reviews)
                .OrderBy(book => book.Title)
                .ToListAsync();
        }
        public async Task<Book> CreateBookAsync(string isbn, string title, int pages, string subject,
           string publishers, string publishDate, string author , string picture)
        {
            if (isbn == null || title == null)
            {
                throw new BookException("The provided data is invalid!");
            }

            var book = new Book
            {
                ISBN = isbn,
                Title = title,
                Pages = pages,
                Subject = subject,
                Publishers = publishers,
                PublishDate = publishDate,
                Author = author,
                Picture = picture

            };

            this.dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            return book;

        }

        public async Task RemoveBookAsync(RemoveBookDto removeBookDto)
        {
            var book = await dbContext.Books
                .FirstOrDefaultAsync(bookIsbn => bookIsbn.ISBN == removeBookDto.ISBN);

            if (book == null)
            {
                throw new BookException("The book was not found!");
            }

            this.dbContext.Books.Remove(book);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task LendBookAsync(BaseTitleDto baseTitleDto)
        {
            var book = await this.dbContext.Books
                .FirstOrDefaultAsync(bTitle => bTitle.Title == baseTitleDto.Title);

            var user = await this.dbContext.Users
                .Include(uLend => uLend.BookLendings)
                .SingleOrDefaultAsync(uId => uId.Id == baseTitleDto.UserId);

            if (book == null)
            {
                throw new BookException("The book was not found!");
            }


            if (user.CountLendBooks < minLendedBooks)
            {
                throw new Exception("You cannot take more than 3 books!");
            }

            var bookLending = await this.dbContext.BookLendings
                .FirstOrDefaultAsync(bLending => bLending.BookId == book.Id
                    && !bLending.ReturnDate.HasValue
                    && bLending.Date.AddDays(10) > DateTime.Now);    // This is enshures automatic return after 10 days


            if (bookLending != null)
            {
                throw new BookException("The book has already been lended!");
            }

            bookLending = new BookLending()
            {

                Book = book,
                User = user,
                Date = DateTime.Now
            };
            user.CountLendBooks -= 1;


            var bookReservation = await this.dbContext.BookReservations
                .Include(item => item.Notification)
                .FirstOrDefaultAsync(item => item.BookId == book.Id && item.UserId == user.Id && item.Active);

            if (bookReservation != null)
            {
                bookReservation.Active = false;
                bookReservation.Notification.Seen = true;
            }

            await this.dbContext.BookLendings.AddAsync(bookLending);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ReserveBookAsync(BaseTitleDto baseTitleDto)
        {
            var book = await this.dbContext.Books
                .FirstOrDefaultAsync(bTitle => bTitle.Title == baseTitleDto.Title);

            var user = await this.dbContext.Users
                .Include(uLend => uLend.BookReservations)
                .SingleOrDefaultAsync(uId => uId.Id == baseTitleDto.UserId);

            if (book == null)
            {
                return false;
            }
            var bookReservation = new BookReservation()
            {

                Book = book,
                User = user,
                Date = DateTime.Now
            };


            await this.dbContext.BookReservations.AddAsync(bookReservation);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
        public async Task ReturnBookAsync(ReviewDto reviewDto)
        {
            if (reviewDto.BookId == 0)
            {
                throw new BookException("The book was not found!");
            }

            var bookId = (await this.dbContext.Books
                .SingleOrDefaultAsync(book => book.Id == reviewDto.BookId)).Id;

            var user = this.dbContext.Users
                .Where(userId => userId.Id == reviewDto.UserId)
                .Select(account => account.CountLendBooks)
                .FirstOrDefault();
        
            if (user > maxLendedBooks)
            {
                throw new BookException("You have no more books for return");
            }

            var bookLending = await this.dbContext.BookLendings
                .FirstOrDefaultAsync(bLending => bLending.BookId == bookId && bLending.UserId == reviewDto.UserId);

            if (bookLending == null)
            {
                throw new BookException("The book has not been lended to the current user.");
            }

            var review = new Review
            {
                BookId = bookId,
                Comment = reviewDto.Comment,
                Rating = reviewDto.Rating,
                UserId = reviewDto.UserId
            };



            bookLending.ReturnDate = DateTime.Now;     // manual return
            user += 1;

            this.dbContext.Reviews.Add(review);
            this.dbContext.BookLendings.Remove(bookLending);
            await this.dbContext.SaveChangesAsync();
        }


        public async Task RenewBookAsync(RenewBookDto renewBookDto)
        {
            var book = await this.dbContext.Books.
                FirstOrDefaultAsync(bRenew => bRenew.Id == renewBookDto.BookId);

            var user = await this.dbContext.Users
                .Include(uLend => uLend.BookLendings)
                .SingleOrDefaultAsync(uName => uName.Id == renewBookDto.UserId);

            var bookLending = await this.dbContext.BookLendings
                .FirstOrDefaultAsync(bLending => bLending.BookId == book.Id
                && bLending.UserId == user.Id);

            if (bookLending == null)
            {
                throw new BookException("The book has not beed lended by the current user!");
            }

            if (renewBookDto.Days > 10)
            {
                throw new BookException("You cannot renew book for more than 10 days.");
            }

            bookLending.Date.AddDays(renewBookDto.Days);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBookLendings(BaseTitleDto baseTitleDto)
        {
            var userId = await this.dbContext.Users
                .FirstOrDefaultAsync(uId => uId.Id == baseTitleDto.UserId);

            var bookLending = await this.dbContext.BookLendings
                .Include(u => u.User)
                .Where(bLending => bLending.UserId == baseTitleDto.UserId)
                .Select(book => book.Book)
                .ToListAsync();

            if (bookLending == null)
            {
                throw new BookException("You do not have any lended books.");
            }
            return bookLending;
        }
    }
}
