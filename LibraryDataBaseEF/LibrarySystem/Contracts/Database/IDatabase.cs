using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Contracts.LibraryService;

namespace LibrarySystem
{
    public interface IDatabase
    {
        ILibraryService LoadLibrary();

       IAccountService LoadUserAccounts();
    }
}