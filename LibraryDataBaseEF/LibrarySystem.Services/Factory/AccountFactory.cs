using LibrarySystem.Models.Accounts;
using LibrarySystem.Services.Contracts.Accounts;

namespace LibrarySystem.Services.Factory
{
    public class AccountFactory : IAccountFactory // Single Responsibility
    {
        public Member CreateMember(string userName, string password)
        {
            return new Member(userName, password);
        }

        public Librarian CreateLibrarian(string userName, string password)
        {
            return new Librarian(userName, password);
        }
    }
}
