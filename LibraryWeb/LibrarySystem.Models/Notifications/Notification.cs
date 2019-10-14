using LibrarySystem.BaseEntitys;
using LibrarySystem.Books;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models.Notifications
{
    public class Notification : BaseIdEntity
    {
        public bool Seen { get; set; }
        public BookReservation BookReservation { get; set; }
 
    }
}
