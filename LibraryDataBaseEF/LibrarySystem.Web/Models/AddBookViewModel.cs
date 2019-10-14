using LibrarySystem.Models.Contracts.Books;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Web.Models
{
    public class AddBookViewModel
    {
        public AddBookViewModel(IBook book)
        {
            this.ISBN = book.ISBN;
            this.Title = book.Title;
            this.Pages = book.Pages;
            this.Subject = book.Subject;
            this.Publishers = book.Publishers;
            this.PublishDate = book.PublishDate;
            this.Author = book.Author;
        }
        public AddBookViewModel()
        {

        }
        [Required(ErrorMessage = "Cannot be Required")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Cannot be Required")]
        public string Title { get; set; }
        [Required]
        [Range(2, 2000, ErrorMessage = "Pages must be between 20 and 2000.")]
        public int Pages { get; set; }
        [Required(ErrorMessage = "Cannot be Required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Cannot be Required")]
        public string Publishers { get; set; }
        [Required(ErrorMessage = "Cannot be Required")]
        public string PublishDate { get; set; }
        [Required(ErrorMessage = "Cannot be Required")]
        public string Author { get; set; }
    }
}
