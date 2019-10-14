using LibrarySystem.Services.Core;
using LibrarySystem.Services.CustomException;
using LibrarySystem.Services.Dto;
using LibrarySystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibrarySystem.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ISearchService searchService;
        private readonly IBookWebService service;
        public BookController(IBookWebService service, ISearchService searchService)
        {
            this.service = service;
            this.searchService = searchService;
        }
        [HttpGet]
        [Authorize]
        public IActionResult SearchBook()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchBook(SearchViewModel vm)
        {
            try
            {
                var book = (await this.searchService.SearchBookAsync(vm.Title, vm.Subject, vm.Author, vm.PublishDate))
               .Select(b => new SearchViewModel(b));

                var results = new SearchResultsViewModel(book);
                return View("Search", results);

            }
            catch (BookException ex)
            {

                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }


        public async Task<IActionResult> Details(int id)
        {
            var book = await this.searchService.FindBookAsync(id);
            if (book == null)
            {
                return View("Message", new MessageViewModel { Message = "The book was not found!" });
            }

            var result = new SearchViewModel(book);

            return View(result);
        }

        public async Task<IActionResult> BookInfo()
        {
            var books = await this.service.GetAllBooksAsync();

            var libraryViewModel = new LibraryViewModel(books);

            return View(libraryViewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook(BookViewModel book)
        {
            try
            {
                await this.service.CreateBookAsync(book.ISBN, book.Title, book.Pages, book.Subject, book.Publishers, book.PublishDate, book.Author, book.Picture);
            }
            catch (BookException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
            //Redirect to book info
            return View("Message", new MessageViewModel { Message = $"The book {book.Title} was added successfully!", IsSuccess = true });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveBook()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveBook(BookIsbnViewModel vm)
        {
            try
            {
                var removeDto = new RemoveBookDto
                {
                    ISBN = vm.ISBN,
                };

                await this.service.RemoveBookAsync(removeDto);
            }
            catch (BookException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return View("Message", new MessageViewModel { Message = $"The book {vm.ISBN} was removed successfully!", IsSuccess = true });
        }
        [HttpGet]
        [Authorize]
        public IActionResult LendBook()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> LendBook(BookTitleViewModel vm)
        {
            try
            {
                var lendDto = new BaseTitleDto
                {
                    Title = vm.Title,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                await this.service.LendBookAsync(lendDto);
            }
            catch (BookException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return View("Message", new MessageViewModel { Message = $"The book {vm.Title} was lended successfully!", IsSuccess = true });
        }
        [HttpGet]
        [Authorize]
        public IActionResult ReserveBook()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ReserveBook(BookTitleViewModel vm)
        {
            var reserveDto = new BaseTitleDto
            {
                Title = vm.Title,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            var result = await this.service.ReserveBookAsync(reserveDto);
            if (!result)
            {
                return View("Message", new MessageViewModel { Message = "Book was not found!" });
            }

            return View("Message", new MessageViewModel { Message = $"The book {vm.Title} was reserved successfully!", IsSuccess = true });
        }

        [HttpGet]
        [Authorize]
        public IActionResult ReturnBook(int bookId)
        {
            var book = new ReturnBookViewModel { BookId = bookId };
            return View(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ReturnBook(ReturnBookViewModel vm)
        {
            try
            {
                var reviewDto = new ReviewDto
                {
                    BookId = vm.BookId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Comment = vm.Comment,
                    Rating = vm.Rating,
                };
                await this.service.ReturnBookAsync(reviewDto);
            }
            catch (BookException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return View("Message", new MessageViewModel { Message = "The book was returned successfully!", IsSuccess = true });
        }

        [Authorize]
        public async Task<IActionResult> CheckMyBooks()
        {
            var baseDto = new BaseTitleDto
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)                
            };

            var book = (await this.service.GetAllBookLendings(baseDto))
              .Select(b => new SearchViewModel(b));

            var results = new SearchResultsViewModel(book);

            return View("CheckMyBooks", results);
        }        

        [HttpGet]
        [Authorize]
        public IActionResult RenewBook(int bookId)
        {
            var book = new RenewBookViewModel { BookId = bookId };
            return View(book);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RenewBook(RenewBookViewModel vm)
        {
            try
            {
                var renewDto = new RenewBookDto
                {
                    BookId = vm.BookId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Days = vm.Days

                };
                await this.service.RenewBookAsync(renewDto);

            }
            catch (BookException ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return View("Message", new MessageViewModel { Message = $"The book was renewed successfully for {vm.Days} days!", IsSuccess = true });
        }
    }
}