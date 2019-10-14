using LibrarySystem.Models.Books;
using LibrarySystem.Models.Racks;

namespace LibrarySystem.Models.Contracts.Books
{
    public interface IBookItem
    {
        Book Book { get; set; }
        Rack Rack { get; set; }

        string ToString();
    }
}