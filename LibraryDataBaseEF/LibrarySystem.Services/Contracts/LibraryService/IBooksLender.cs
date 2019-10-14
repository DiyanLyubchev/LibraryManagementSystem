using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;

namespace LibrarySystem.Services.Contracts.LibraryService
{
    public interface IBooksLender
    {
        bool LendBook(Account user, Book book);

        void ReserveBook(Account user, Book book);

        void ReturnBook(BookLending bookLanding);
    }
}
