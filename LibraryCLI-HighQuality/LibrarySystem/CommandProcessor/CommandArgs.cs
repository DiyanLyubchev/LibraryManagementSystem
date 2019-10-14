namespace LibrarySystem
{
    public class CommandArgs : ICommandArgs
    {
        public IAccountService UsersService { get; set; }
        public ILibraryService LibraryService { get; set; }
        public IBook SelectedBook { get; set; }
    }
}