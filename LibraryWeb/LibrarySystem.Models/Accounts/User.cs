using LibrarySystem.Accounts;
using LibrarySystem.Books;
using LibrarySystem.Models.Books;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Accounts
{
    public class User : IdentityUser
    {
        public virtual ICollection<BookLending> BookLendings { get; } = new List<BookLending>();

        public virtual ICollection<BookReservation> BookReservations { get; } = new List<BookReservation>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public bool IsBanned { get; set; }

        public int CountLendBooks { get; set; } = 5;

        [NotMapped]
        public string LastNotification { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? Expired { get; set; }
    }
}
