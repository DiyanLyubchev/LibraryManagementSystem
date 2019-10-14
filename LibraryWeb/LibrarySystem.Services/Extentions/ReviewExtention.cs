using LibrarySystem.Models.Books;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Services.Extentions
{
    public static class ReviewExtention
    {
        public static double? GetAllRatings(this ICollection<Review> reviews, Book book)
        {
            return reviews
                  .Where(rating => rating.BookId == book.Id)
                  .Select(rating => rating.Rating).Average();
        }

        public static List<string> GetAllComment(this ICollection<Review> reviews, Book book)
        {
            return reviews.Where(rating => rating.BookId == book.Id)
                .Select(c => c.Comment).ToList();
        }

    }
}
