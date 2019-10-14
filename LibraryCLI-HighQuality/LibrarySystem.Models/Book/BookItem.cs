namespace LibrarySystem
{
    public class BookItem : IBookItem
    {
        public IBook Book { get; set; }
        public IRack Rack { get; set; }

        public override string ToString()
        {
            return Book.ToString();
        }
    }
}