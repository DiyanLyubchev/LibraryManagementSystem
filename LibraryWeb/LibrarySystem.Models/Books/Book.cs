using LibrarySystem.BaseEntitys;
using LibrarySystem.Books;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Books
{
    public class Book : BaseIdEntity      // Single Responsibility
    {
        public virtual ICollection<BookReservation> BookReservations { get; set; } = new List<BookReservation>();

        public virtual ICollection<BookLending> BookLendings { get; set; } = new List<BookLending>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public string ISBN { get; set; }

        public string Title { get; set; }
        [Required]
        [Range(20, 2000, ErrorMessage = "Pages must be between 20 and 2000.")]
        public int Pages { get; set; }

        public string Subject { get; set; }

        public string Publishers { get; set; }

        public string PublishDate { get; set; }

        public string Author { get; set; }

        public string Picture { get; set; }

        [NotMapped]
        public string LastNotification { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}";
        }

    }
}