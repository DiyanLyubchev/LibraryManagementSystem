using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using LibrarySystem.Models.Contracts.Books;
using LibrarySystem.Models.Racks;
using LibrarySystem.Services.Contracts.Catalog;
using LibrarySystem.Services.Contracts.LibraryService;
using LibrarySystem.Services.Contracts.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Core
{
    public class LibraryService : ILibraryService  // Single Responsibility
    {
        private LibrarySystemContext dbContext = new LibrarySystemContext();

        public ISystemService SystemService { get; private set; }
        public ICatalogService CatalogService { get; private set; }

        public LibraryService(ISystemService systemService, ICatalogService catalogService)
        {
            SystemService = systemService;
            CatalogService = catalogService;
        }

        public void AddBook(Book book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in dbContext.Racks.Include(r => r.Letters))
            {
                if (rack.Letters.Any(rackLetter => rackLetter.Letter == bookLetter))
                {
                    var bookFromDb = dbContext.Books.FirstOrDefault(b => b.ISBN == book.ISBN);

                    var bookItem = new BookItem();
                    bookItem.Book = bookFromDb ?? book;
                    bookItem.Rack = rack;

                    rack.BookItems.Add(bookItem);



                    if (bookFromDb == null)
                    {
                        dbContext.Books.Add(book);
                    }
                    else
                    {
                        Console.WriteLine($"Book with the following ISBN: {book.ISBN} exists");
                        Console.ReadKey();
                    }
                    break;
                }
            }
            dbContext.SaveChanges();
        }
      
        public void AddBookInCatalog(Book book)
        {
            CatalogService.AddBook(book);
        }

        public void RemoveBook(Book book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in dbContext.Racks)
            {
                if (rack.Letters.Any(rackLetter => rackLetter.Letter == bookLetter))
                {
                    var bookItem = rack.BookItems.FirstOrDefault(bI => bI.Book.Id == book.Id);

                    rack.BookItems.Remove(bookItem);
                    bookItem = rack.BookItems.FirstOrDefault(bI => bI.Book == book);

                    if (bookItem == null)
                    {
                        dbContext.Books.Remove(book);
                    }
                    break;
                }
            }
            dbContext.SaveChanges();
        }

        public void EditBook(Book oldBook, Book newBook)
        {
            if (newBook.Subject != null)
            {
                oldBook.Subject = newBook.Subject;
            }
            if (newBook.Publishers != null)
            {
                oldBook.Publishers = newBook.Publishers;
            }
            if (newBook.Title != null)
            {
                char oldBookLetter = oldBook.Title.ToUpper()[0];
                var oldBookItems = new List<BookItem>();
                foreach (var rack in dbContext.Racks)
                {
                    if (rack.Letters.Any(rackLetter => rackLetter.Letter == oldBookLetter))
                    {
                        foreach (var bookItem in rack.BookItems)
                        {
                            if (bookItem.Book == oldBook)
                            {
                                oldBookItems.Add(bookItem);
                            }
                        }
                        foreach (var bookItem in oldBookItems)
                        {
                            rack.BookItems.Remove(bookItem);
                        }

                        break;
                    }
                }

                oldBook.Title = newBook.Title;
                char newBookLetter = oldBook.Title.ToUpper()[0];

                foreach (var rack in dbContext.Racks)
                {
                    if (rack.Letters.Any(rackLetter => rackLetter.Letter == newBookLetter))
                    {
                        foreach (var bookItem in oldBookItems)
                        {
                            rack.BookItems.Add(bookItem);
                            bookItem.Rack = rack;
                        }
                        break;
                    }
                }
                dbContext.SaveChanges();
            }
        }

        public void FillRacks()
        {
            int ch = 65;
            int row = 0;
            int col = 0;
            int maxCols = 2;

            for (int i = 0; i < 26; i++)
            {
                var letters = new List<RackLetter>();
                letters.Add(new RackLetter { Letter = (char)ch++ });

                var rack = new Rack
                {
                    RackNumber = i,
                    Letters = letters,
                    Location = new RackLocation()
                    {
                        Row = row,
                        Col = col++
                    }
                };

                if (col == maxCols)
                {
                    row++;
                    col = 0;
                }

                if (!dbContext.Racks.Any())
                {
                    dbContext.Racks.Add(rack);
                }
            }
            dbContext.SaveChanges();
        }

        public bool LendBook(Account user, Book book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in dbContext.Racks)
            {
                if (rack.Letters.Any(rackLetter => rackLetter.Letter == bookLetter))
                {
                    var bookItem = rack.BookItems
                        .FirstOrDefault(bItem => bItem.Book.Id == book.Id
                            && !dbContext.BookLendings.Any(bLending => bLending.BookItemId == bItem.Id));

                    if (bookItem == null)
                    {
                        return false;
                    }

                    var bookLending = new BookLending()
                    {
                        BookItemId = bookItem.Id,
                        AccountId = user.Id,
                        Date = DateTime.Now
                    };

                    dbContext.BookLendings.Add(bookLending);
                    break;
                }
            }
            dbContext.SaveChanges();
            return true;
        }

        public void ReserveBook(Account user, Book book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in dbContext.Racks)
            {
                if (rack.Letters.Any(rackLetter => rackLetter.Letter == bookLetter))
                {
                    var bookItem = rack.BookItems.FirstOrDefault(bItem => bItem.Book.Id == book.Id
                            && !dbContext.BookReservations.Any(bReserve => bReserve.BookItemId == bItem.Id));

                    var bookReserv = new BookReservation
                    {
                        BookItemId = bookItem.Id,
                        AccountId = user.Id,
                        Date = DateTime.Now
                    };

                    dbContext.BookReservations.Add(bookReserv);
                    break;
                }
            }

            dbContext.SaveChanges();
        }

        public void ReturnBook(BookLending bookLanding)
        {
            dbContext.BookLendings.Remove(bookLanding);
            dbContext.SaveChanges();
        }
    }
}