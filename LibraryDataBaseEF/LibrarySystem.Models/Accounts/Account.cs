using LibrarySystem.Models.BaseEntity;
using LibrarySystem.Models.Books;
using LibrarySystem.Models.Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Accounts
{
    public class Account : BaseIdEntity, IAccount // One account vs Many checked out books
                                                  // One account vs Many book reservations 
    {

        public Account(string userName, string password, AccountType type)
        {
            UserName = userName;
            Password = password;
            Type = type;
        }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public ICollection<BookLending> BookLendings { get; }
        public ICollection<BookReservation> BookReservations { get; }

        public AccountType Type { get; set; }
        [NotMapped]
        public bool CanAddBook => Type == AccountType.Librarian;
        [NotMapped]
        public bool CanEditBook => Type == AccountType.Librarian;
        [NotMapped]
        public bool CanEditUsers => Type == AccountType.Librarian;
        [NotMapped]
        public bool CanReserveBook => true;
        [NotMapped]
        public bool LoggOut => true;
        [NotMapped]
        public bool CanReturnBook => true;
        [NotMapped]
        public bool CanSearchTheCatalogue => true;
        [NotMapped]
        public bool CanCheckOutBook { get; set; } = true;
        [NotMapped]
        public bool CanRenewBook => true;
        [NotMapped]
        public bool CanRegisterUsers => Type == AccountType.Librarian;

        public override string ToString()
        {
            return $"Username: {UserName}{Environment.NewLine}Type: {Type} ";
        }
    }
}