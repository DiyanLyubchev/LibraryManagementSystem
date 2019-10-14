using LibrarySystem.Models.Contracts.Books;

namespace LibrarySystem.Web.Models
{
    public class BookViewModel
    {
        public BookViewModel(IBook book)
        {
            this.ISBN = book.ISBN;
            this.Title = book.Title;
            this.Id = book.Id;
        }
        public BookViewModel()
        {

        }

        public string Title
        {
            get;
            set;
        }
        public string ISBN
        {
            get;
            set;
        }
        public int Id
        {
            get;
            set;
        }
    }
}
