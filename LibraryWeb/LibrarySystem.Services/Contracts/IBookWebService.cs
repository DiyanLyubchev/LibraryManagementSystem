using System.Collections.Generic;
using System.Threading.Tasks;
using LibrarySystem.Models.Books;
using LibrarySystem.Services.Dto;

namespace LibrarySystem.Services.Core
{
    public interface IBookWebService
    {
        Task ReturnBookAsync(ReviewDto reviewDto);
        Task<Book> CreateBookAsync(string isbn, string title, int pages, string subject,
           string publishers, string publishDate, string author, string picture);

        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task RemoveBookAsync(RemoveBookDto removeBookDto);
        Task LendBookAsync(BaseTitleDto baseTitleDto);
        Task<bool> ReserveBookAsync(BaseTitleDto baseTitleDto);
        Task RenewBookAsync(RenewBookDto renewBookDto);
        Task<IEnumerable<Book>> GetAllBookLendings(BaseTitleDto baseTitleDto);
    }
}