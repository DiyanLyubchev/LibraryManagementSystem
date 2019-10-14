using LibrarySystem.Models.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystem.Services.Extentions;

namespace LibrarySystem.Web.Models
{
    public class SearchViewModel : BaseViewModel
    {
        public SearchViewModel(Book book)
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
            this.Rating = book.Reviews.GetAllRatings(book);
            this.Comment = book.Reviews.GetAllComment(book);
        }

        public SearchViewModel()
        {
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Title { get; set; }

        [Range(2, 2000, ErrorMessage = "Pages must be between 20 and 2000.")]
        public int Pages { get; set; }

        public string Subject { get; set; }

        public string Publishers { get; set; }

        public string PublishDate { get; set; }

        public string Author { get; set; }

        public string Picture { get; set; }

        public double? Rating { get; set; }

        public ICollection<string> Comment { get; set; }

    }
}
