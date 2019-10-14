using LibrarySystem.Models.Books;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Web.Models
{
    public class BookViewModel : BaseViewModel
    {
        public BookViewModel(Book book)
        {
            this.Id = book.Id;
            this.ISBN = book.ISBN;
            this.Title = book.Title;
            this.Pages = book.Pages;
            this.Subject = book.Subject;
            this.Publishers = book.Publishers;
            this.PublishDate = book.PublishDate;
            this.Author = book.Author;
            this.Picture = book.Picture;
        }

        public BookViewModel()
        {
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(2, 2000, ErrorMessage = "Pages must be between 20 and 2000.")]
        public int Pages { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Publishers { get; set; }
        [Required]
        public string PublishDate { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Picture { get; set; }
    }
}
