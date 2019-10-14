namespace LibrarySystem
{
    public class Librarian : Account, ILibrarian 
    {
        public Librarian(string userName) : base(userName, AccountType.Librarian)
        {
            this.UserName = userName;
        }
    }
}