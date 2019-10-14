using LibrarySystem.Models.BaseEntity;
using LibrarySystem.Models.Contracts.Books;
using LibrarySystem.Models.Racks;

namespace LibrarySystem.Models.Books
{
    public class BookItem : BaseIdEntity, IBookItem
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int RackId { get; set; }
        public Rack Rack { get; set; }

    }
}