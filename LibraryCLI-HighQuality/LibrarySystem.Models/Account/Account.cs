using System;

namespace LibrarySystem
{
    public class Account : IAccount
    {
        private string userName;

        public Account(string userName, AccountType type)
        {
            this.UserName = userName;
            this.Type = type;
        }

        public virtual string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tha name cannot be null or empty!");
                }
                if (value.Length < 3 || value.Length > 12)
                {
                    throw new ArgumentException("The name lenght must between 3 and 12 symbols!");
                }
                this.userName = value;
            }
        }

        public AccountType Type { get; set; }

        public bool CanAddBook => this.Type == AccountType.Librarian;

        public bool CanEditBook => this.Type == AccountType.Librarian;

        public bool CanEditUsers => this.Type == AccountType.Librarian;
        public bool CanReserveBook => true;  

        public bool LoggOut => true; 
        public bool CanReturnBook => true; 

        public bool CanSearchTheCatalogue => true;

        public bool CanCheckOutBook { get; set; } = true;

        public bool CanRenewBook => true;

        public bool CanRegisterUsers => this.Type == AccountType.Librarian;

        public override string ToString()
        {
            return $"Username: {this.UserName}{Environment.NewLine}Type: {this.Type} ";
        }
    }
}