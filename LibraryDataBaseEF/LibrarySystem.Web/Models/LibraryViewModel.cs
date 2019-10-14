using LibrarySystem.Models.Contracts.Books;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models
{
    public class LibraryViewModel
    {
        public List<BookViewModel> Books { get; set; }
        public LibraryViewModel(IEnumerable<IBook> books)
        {
            this.Books = new List<BookViewModel>();
            foreach (var book in books)
            {
                this.Books.Add(new BookViewModel(book));
            }
        }
    }
}
