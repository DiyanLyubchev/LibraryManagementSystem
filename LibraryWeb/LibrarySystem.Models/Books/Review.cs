using LibrarySystem.BaseEntitys;
using LibrarySystem.Models.Accounts;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.Books
{
    public class Review : BaseIdEntity
    {
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        [Required]
        public int? Rating { get; set; }

        [StringLength(400)]
        public string Comment { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
