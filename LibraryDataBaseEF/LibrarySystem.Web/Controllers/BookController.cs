using System;
using System.Threading.Tasks;
using LibrarySystem.Services.Contracts.LibraryService;
using LibrarySystem.Services.Core;
using LibrarySystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Web.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookWebService service;

        public BookController(IBookWebService service)
        {
            this.service = service;
        }

        public IActionResult Details(int id)
        {
            var book = this.service.FindBook(id);
            if (book == null)
            {
                return NotFound();
            }


            return View(book);
        }

        [HttpGet]
        public IActionResult SearchBookByAuthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchBookByAuthor(string author)
        {
            var book =await this.service.SearchBookByAuthor(author);
            if (book == null)
            {
                return NotFound();
            }
            var bookModel = new AddBookViewModel(book);
            return View("Search", bookModel);
        }
        [HttpGet]
        public IActionResult SearchBookByTitle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchBookByTitle(string title)
        {
            var book =await this.service.SearchBookByTitle(title);
            if (book == null)
            {
                return NotFound();
            }
            var bookModel = new AddBookViewModel(book);
            return View("Search", bookModel);
        }
        [HttpGet]
        public IActionResult SearchBookBySubject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchBookBySubject(string subject)
        {
            var book = await this.service.SearchBookBySubject(subject);
            if (book == null)
            {
                return NotFound();
            }
            var bookModel = new AddBookViewModel(book);
            return View("Search", bookModel);
        }
        [HttpGet]
        public IActionResult SearchBookByPublishDate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SearchBookByPublishDate(string publishDate)
        {
            var book = await this.service.SearchBookByPublishDate(publishDate);
            if (book == null)
            {
                return NotFound();
            }
            var bookModel = new AddBookViewModel(book);
            return View("Search", bookModel);
        }
        public IActionResult BookInfo()
        {
            var books = this.service.GetAllBooks();

            var libraryViewModel = new LibraryViewModel(books);

            return View(libraryViewModel);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await this.service.CreateBook(book.ISBN, book.Title, book.Pages, book.Subject, book.Publishers, book.PublishDate, book.Author);

            return RedirectToAction("BookInfo", "Book");
        }
        [HttpGet]
        public IActionResult RemoveBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RemoveBook(BookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            await this.service.RemovedBook(vm.ISBN, vm.Title);
            return RedirectToAction("BookInfo", "Book");
        }
    }
}