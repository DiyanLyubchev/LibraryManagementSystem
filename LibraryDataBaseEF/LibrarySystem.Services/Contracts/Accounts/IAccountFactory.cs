using LibrarySystem.Models.Accounts;

namespace LibrarySystem.Services.Contracts.Accounts
{
    public interface IAccountFactory
    {
        Librarian CreateLibrarian(string userName, string password);
        Member CreateMember(string userName, string password);
    }
}