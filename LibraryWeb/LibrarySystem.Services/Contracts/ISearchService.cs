using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystem.Models.Books;

namespace LibrarySystem.Services.Core
{
    public interface ISearchService
    {
        Task<IEnumerable<Book>> SearchBookAsync(string title, string subject, string author, string publishDate);
        Task<Book> FindBookAsync(int id);
    }
}