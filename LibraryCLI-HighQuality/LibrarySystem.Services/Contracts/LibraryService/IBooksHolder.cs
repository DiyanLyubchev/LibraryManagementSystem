namespace LibrarySystem
{
    public interface IBooksHolder
    {
        void AddBook(IBook book);

        void EditBook(IBook oldBook, IBook newBook);

        void RemoveBook(IBook book);
    }
}
