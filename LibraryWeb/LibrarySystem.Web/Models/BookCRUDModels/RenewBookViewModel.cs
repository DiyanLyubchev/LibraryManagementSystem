using LibrarySystem.Models.Books;

namespace LibrarySystem.Web.Models
{
    public class RenewBookViewModel : BaseViewModel
    {
        public int BookId { get; set; }
        public int Days { get; set; }

    }
}
