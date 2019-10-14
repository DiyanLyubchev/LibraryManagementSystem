using LibrarySystem.Models.Books;
using LibrarySystem.Services.Contracts.Factory;

namespace LibrarySystem.Services.Factory
{
    public class BookFactory : IBookFactory // Single Responsibility
    {
        public Book CreateBook(string isbn, string title, int pages, string subject,
            string publishers, string publishDate, string author)
        {
            return new Book(isbn, title, pages, subject, publishers, publishDate, author);
        }
    }
}
