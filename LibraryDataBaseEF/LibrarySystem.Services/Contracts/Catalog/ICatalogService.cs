using LibrarySystem.Models.Books;
using System.Collections.Generic;

namespace LibrarySystem.Services.Contracts.Catalog
{
    public interface ICatalogService
    {
        IDictionary<string, IList<Book>> SortedByAuthor { get; }
        IDictionary<string, IList<Book>> SortedByPublishDate { get; }
        IDictionary<string, IList<Book>> SortedBySubject { get; }
        IDictionary<string, IList<Book>> SortedByTitle { get; }

        void AddBook(Book book);
        IList<Book> SearchByAuthor(string author);
        IList<Book> SearchByPublishDate(string publishDateTime);
        IList<Book> SearchBySubject(string subject);
        IList<Book> SearchByTitle(string title);
    }
}