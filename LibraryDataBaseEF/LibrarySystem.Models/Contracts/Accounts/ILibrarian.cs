namespace LibrarySystem.Models.Contracts.Accounts
{
    public interface ILibrarian
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}