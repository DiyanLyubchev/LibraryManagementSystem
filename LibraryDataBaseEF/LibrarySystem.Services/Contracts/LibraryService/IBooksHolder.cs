using LibrarySystem.Models.Books;
using LibrarySystem.Models.Contracts.Books;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Contracts.LibraryService
{
    public interface IBooksHolder
    {
        void AddBookInCatalog(Book book);
        void AddBook(Book book);

        void EditBook(Book oldBook, Book newBook);

        void RemoveBook(Book book);
    }
}
