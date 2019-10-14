using LibrarySystem.Models.Books;

namespace LibrarySystem.Services.Contracts.Factory
{
    public interface IBookFactory
    {
        Book CreateBook(string isbn, string title, int pages, string subject, string publishers, string publishDate, string author);
    }
}