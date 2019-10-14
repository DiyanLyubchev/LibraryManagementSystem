namespace LibrarySystem
{
    public interface ICommandProcessor
    {
        Options ProcessMethod(Options currentOption, ILibraryService library, IAccountService users);
    }
}