using LibrarySystem.Models;
using LibrarySystem.Models.Contracts.Accounts;

namespace LibrarySystem.Models.Accounts
{
    public class Librarian : Account, ILibrarian
    {
        public Librarian(string userName, string password) : base(userName, password, AccountType.Librarian)
        {
            UserName = userName;
            Password = password;
        }
    }
}