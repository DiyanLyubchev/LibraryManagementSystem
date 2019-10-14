using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class System
    {
        public List<BookLending> BookLendings { get; } = new List<BookLending>();

        public List<BookReservation> BookReservations { get; } = new List<BookReservation>();
        public bool ValidateLendPeriod(BookLending bookLending)
        {
            return bookLending.Date.AddDays(10) >= DateTime.Now;

        }
        public decimal CalculateFine(BookLending bookLending)
        {
            var result = DateTime.Now - bookLending.Date.AddDays(10);

            return result.Days * 1.30m;
        }
    }
}
