namespace LibrarySystem.Models.Contracts.Accounts
{
    public interface IMember
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}