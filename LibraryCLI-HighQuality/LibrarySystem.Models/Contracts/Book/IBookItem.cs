namespace LibrarySystem
{
    public interface IBookItem
    {
        IBook Book { get; set; }
        IRack Rack { get; set; }

        string ToString();
    }
}