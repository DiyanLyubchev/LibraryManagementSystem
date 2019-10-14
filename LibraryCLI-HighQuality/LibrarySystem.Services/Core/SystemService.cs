using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class SystemService : ISystemService
    {
        public IList<IBookLending> BookLendings { get; } = new List<IBookLending>();

        public IList<IBookReservation> BookReservations { get; } = new List<IBookReservation>();

        public bool ValidateLendPeriod(IBookLending bookLending)
        {
            return bookLending.Date.AddDays(10) >= DateTime.Now;
        }

        public decimal CalculateFine(IBookLending bookLending)
        {
            var result = DateTime.Now - bookLending.Date.AddDays(10);

            return result.Days * 1.30m;
        }
    }
}