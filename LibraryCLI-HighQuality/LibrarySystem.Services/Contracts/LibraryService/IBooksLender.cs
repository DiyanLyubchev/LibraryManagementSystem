namespace LibrarySystem
{
    public interface IBooksLender
    {
        bool LendBook(IAccount user, IBook book);

        void ReserveBook(IAccount user, IBook book);

        void ReturnBook(IBookLending bookLanding);
    }
}
