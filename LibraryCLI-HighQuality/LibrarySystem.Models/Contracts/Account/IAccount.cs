namespace LibrarySystem
{
    public interface IAccount
    {
        bool CanAddBook { get; }
        bool CanCheckOutBook { get; set; }
        bool CanEditBook { get; }
        bool CanEditUsers { get; }
        bool CanRegisterUsers { get; }
        bool CanRenewBook { get; }
        bool CanReturnBook { get; }
        bool CanSearchTheCatalogue { get; }
        AccountType Type { get; set; }
        string UserName { get; set; }
        bool CanReserveBook { get; }
        bool LoggOut { get; }

        string ToString();
    }
}