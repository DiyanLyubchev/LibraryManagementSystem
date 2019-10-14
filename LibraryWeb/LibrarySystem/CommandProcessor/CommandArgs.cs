using LibrarySystem.Contracts.Books;
using LibrarySystem.DbContext;
using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Contracts.LibraryService;

namespace LibrarySystem
{
    public class CommandArgs : ICommandArgs
    {
        public IAccountService UsersService { get; set; }
        public ILibraryService LibraryService { get; set; }
        public IBook SelectedBook { get; set; }

        public LibrarySystemContext LibrarySystemContext { get; } = new LibrarySystemContext();
    }
}