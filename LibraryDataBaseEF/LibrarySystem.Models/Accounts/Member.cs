using LibrarySystem.Models;
using LibrarySystem.Models.Contracts.Accounts;

namespace LibrarySystem.Models.Accounts
{
    public class Member : Account, IMember
    {
        public Member(string userName, string password) : base(userName, password, AccountType.Member)
        {
            UserName = userName;
            Password = password;
        }
    }
}