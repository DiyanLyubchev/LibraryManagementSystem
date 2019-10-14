using LibrarySystem.Models.Books;
using LibrarySystem.Models.Contracts.Books;
using LibrarySystem.Services.Contracts.Catalog;
using LibrarySystem.Services.Contracts.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public class BookWebService : IBookWebService
    {
        private LibrarySystemContext dbContext = new LibrarySystemContext();

        public ISystemService SystemService { get; private set; }

        public BookWebService(ISystemService systemService)
        {
            SystemService = systemService;
        }


        public IEnumerable<IBook> GetAllBooks()
        {
            return dbContext.Books.ToList();
        }
        public async Task<Book> CreateBook(string isbn, string title, int pages, string subject,
           string publishers, string publishDate, string author)
        {
            var book = new Book
            {
                ISBN = isbn,
                Title = title,
                Pages = pages,
                Subject = subject,
                Publishers = publishers,
                PublishDate = publishDate,
                Author = author
            };
            if (isbn != null || title != null)
            {
                await dbContext.Books.AddAsync(book);
                await dbContext.SaveChangesAsync();
            }

            return book;

        }
        public IBook FindBook(int id)
        {
            return this.dbContext.Books
                 .FirstOrDefault(book => book.Id == id);
        }
        public async Task RemovedBook(string isbn, string title)
        {
            var book = dbContext.Books
                .FirstOrDefault(bookIsbn => bookIsbn.ISBN == isbn && bookIsbn.Title == title);
            if (book != null)
            {
                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync();
            }

        }
        public async Task<IBook> SearchBookByTitle(string title)
        {
            var bookSearch = await this.dbContext.Books
                .FirstOrDefaultAsync(book => book.Title == title);

            return bookSearch;
        }

        public async Task<IBook> SearchBookByAuthor(string author)
        {
            var bookSearch = await this.dbContext.Books
                .FirstOrDefaultAsync(book => book.Author == author);

            return bookSearch;
        }
        public async Task<IBook> SearchBookBySubject(string subject)
        {
            var bookSearch =await this.dbContext.Books
                .FirstOrDefaultAsync(book => book.Subject == subject);

            return bookSearch;
        }
        public async Task<IBook> SearchBookByPublishDate(string publishDate)
        {
            var bookSearch = await this.dbContext.Books
                .FirstOrDefaultAsync(book => book.PublishDate == publishDate);

            return bookSearch;
        }
    }
}


