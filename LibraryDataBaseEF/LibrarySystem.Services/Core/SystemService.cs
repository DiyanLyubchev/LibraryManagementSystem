using LibrarySystem.Models.Books;
using LibrarySystem.Services.Contracts.System;
using System;
using System.Collections.Generic;

namespace LibrarySystem.Services.Core
{
    public class SystemService : ISystemService  // Single Responsibility
    {
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