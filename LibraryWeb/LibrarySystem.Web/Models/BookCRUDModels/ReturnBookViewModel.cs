using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Web.Models
{
    public class ReturnBookViewModel : BaseViewModel
    {
        public int BookId { get; set; }
        public string Comment { get; set; }
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
        [Required]
        public int Rating { get; set; }
    }
}
