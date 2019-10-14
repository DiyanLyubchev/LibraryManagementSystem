using LibrarySystem.Models.Contracts.Books;
using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Contracts.LibraryService;

namespace LibrarySystem
{
    public interface ICommandArgs
    {
        IAccountService UsersService { get; set; }
        ILibraryService LibraryService { get; set; }
        IBook SelectedBook { get; set; }
        LibrarySystemContext LibrarySystemContext { get;  }
    }
}