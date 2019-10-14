using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystem.Models.Books;
using LibrarySystem.Models.Contracts.Books;
using LibrarySystem.Services.Contracts.Catalog;
using LibrarySystem.Services.Contracts.System;

namespace LibrarySystem.Services.Core
{
    public interface IBookWebService
    {
        ISystemService SystemService { get; }

        Task<Book> CreateBook(string isbn, string title, int pages, string subject,
          string publishers, string publishDate, string author);
        IBook FindBook(int id);
        IEnumerable<IBook> GetAllBooks();
        Task RemovedBook(string isbn, string title);
        Task<IBook> SearchBookByTitle(string title);
        Task<IBook> SearchBookByAuthor(string author);
        Task<IBook> SearchBookBySubject(string subject);
        Task<IBook> SearchBookByPublishDate(string publishDate);
    }
}