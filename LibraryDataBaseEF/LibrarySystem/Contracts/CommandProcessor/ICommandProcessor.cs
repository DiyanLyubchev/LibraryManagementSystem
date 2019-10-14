using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Contracts.LibraryService;

namespace LibrarySystem
{
    public interface ICommandProcessor
    {
        Options ProcessMethod(Options currentOption, ILibraryService library, IAccountService users);
    }
}