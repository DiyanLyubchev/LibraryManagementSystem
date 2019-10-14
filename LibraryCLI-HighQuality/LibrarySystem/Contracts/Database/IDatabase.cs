namespace LibrarySystem
{
    public interface IDatabase
    {
        ILibraryService LoadLibrary();

       IAccountService LoadUserAccounts();
    }
}