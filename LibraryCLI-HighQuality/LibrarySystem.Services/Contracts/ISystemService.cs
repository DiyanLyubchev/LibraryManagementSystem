using System.Collections.Generic;

namespace LibrarySystem
{
    public interface ISystemService
    {
        IList<IBookLending> BookLendings { get; }
        IList<IBookReservation> BookReservations { get; }

        decimal CalculateFine(IBookLending bookLending);
        bool ValidateLendPeriod(IBookLending bookLending);
    }
}