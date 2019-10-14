using LibrarySystem.DbContext;
using LibrarySystem.Models.Books;
using LibrarySystem.Services.CustomException;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public class SearchService : ISearchService
    {
        private readonly LibrarySystemContext dbContext;

        public SearchService(LibrarySystemContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<IEnumerable<Book>> SearchBookAsync(string title, string subject, string author, string publishDate)
        {
            var bookSearch = await this.dbContext.Books
                .Include(review => review.Reviews)
                .Where(book => (title == null || book.Title == title)
                && (subject == null || book.Subject == subject)
                && (author == null || book.Author == author)
                && (publishDate == null || book.PublishDate == publishDate)).ToListAsync();

            if (!bookSearch.Any())
            {
                throw new BookException("Invalid parameter entered!");
            }
            return bookSearch;
        }
        public async Task<Book> FindBookAsync(int id)
        {
            return await this.dbContext.Books
                .Include(review => review.Reviews)
                 .FirstOrDefaultAsync(book => book.Id == id);
        }
    }
}
