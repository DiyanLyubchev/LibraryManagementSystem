using LibrarySystem.Models.Books;
using System.Collections.Generic;

namespace LibrarySystem.Web.Models
{
    public class LibraryViewModel : BaseViewModel
    {
        public List<BookViewModel> Books { get; set; }
        public LibraryViewModel(IEnumerable<Book> books)
        {
            this.Books = new List<BookViewModel>();
            foreach (var book in books)
            {
                this.Books.Add(new BookViewModel(book));
            }
        }
    }
}
