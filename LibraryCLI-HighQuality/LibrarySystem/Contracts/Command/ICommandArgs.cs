namespace LibrarySystem
{
    public interface ICommandArgs
    {
        IAccountService UsersService { get; set; }
        ILibraryService LibraryService { get; set; }
        IBook SelectedBook { get; set; }
    }
}