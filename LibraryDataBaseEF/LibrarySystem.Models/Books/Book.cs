using LibrarySystem.Models.BaseEntity;
using LibrarySystem.Models.Contracts.Books;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.Books
{
    public class Book :  IBook      // Single Responsibility
    {
        [Key]
        public int Id { get; set; }
        public string ISBN { get; set; }

        public string Title { get; set; }
        [Required]
        [Range(20, 2000, ErrorMessage = "Pages must be between 20 and 2000.")]
        public int Pages { get; set; }

        public string Subject { get; set; }

        public string Publishers { get; set; }

        public string PublishDate { get; set; }

        public string Author { get; set; }


        public Book()
        {
        }

        public Book(string isbn, string title, int pages, string subject,
            string publishers, string publishDate, string author)
        {
            ISBN = isbn;
            Title = title;
            Pages = pages;
            Subject = subject;
            Publishers = publishers;
            PublishDate = publishDate;
            Author = author;
        }
        public override string ToString()
        {
            return $"Title: {Title}";
        }

    }
}