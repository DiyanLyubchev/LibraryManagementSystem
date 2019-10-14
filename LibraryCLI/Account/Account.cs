using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public abstract class Account
    {
        public Account(string userName, AccountType type)
        {
            this.UserName = userName;
            this.Type = type;
        }
        public string UserName { get; set; }

        public AccountType Type { get; set; }

        public bool CanAddBook => this.Type == AccountType.Librarian;

        public bool CanEditBook => this.Type == AccountType.Librarian;


        public bool CanEditUsers => this.Type == AccountType.Librarian;


        public bool CanReturnBook => true;

        public bool CanSearchTheCatalogue => true;

        public bool CanCheckOutBook { get; set; } = true;

        public bool CanRenewBook => true;

        public bool CanRegisterUsers => this.Type == AccountType.Librarian;

        public override string ToString()
        {
            return $"Username: {this.UserName}\nType: {this.Type} ";
        }





    }
}
