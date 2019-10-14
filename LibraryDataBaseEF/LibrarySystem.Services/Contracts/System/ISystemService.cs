using LibrarySystem.Models.Books;

namespace LibrarySystem.Services.Contracts.System
{
    public interface ISystemService
    {
        decimal CalculateFine(BookLending bookLending);
        bool ValidateLendPeriod(BookLending bookLending);
    }
}