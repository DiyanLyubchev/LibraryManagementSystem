using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class LibraryService : ILibraryService
    {
        public ISystemService SystemService { get; private set; }
        public ICatalogService CatalogService { get; private set; }
        public IList<IRack> Racks { get; }
        public ISet<IBook> Books { get; }
        public LibraryService(ISystemService systemService, ICatalogService catalogService, IList<IRack> racks = null, ISet<IBook> books = null)
        {
            this.SystemService = systemService;
            this.CatalogService = catalogService;
            this.Racks = racks ?? new List<IRack>();
            this.Books = books ?? new HashSet<IBook>();
        }

        public void AddBook(IBook book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    var bookItem = new BookItem();
                    bookItem.Book = book;
                    bookItem.Rack = rack;

                    rack.BookItems.Add(bookItem);

                    if (this.Books.Add(book))
                    {
                        this.CatalogService.AddBook(book);
                    }
                    break;
                }
            }
        }

        public void RemoveBook(IBook book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    var bookItem = rack.BookItems.FirstOrDefault(bI => bI.Book == book);

                    rack.BookItems.Remove(bookItem);
                    bookItem = rack.BookItems.FirstOrDefault(bI => bI.Book == book);

                    if (bookItem == null)
                    {
                        this.Books.Remove(book);
                    }
                    break;
                }
            }
        }

        public void EditBook(IBook oldBook, IBook newBook)
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
                var oldBookItems = new List<IBookItem>();
                foreach (var rack in this.Racks)
                {
                    if (rack.Letters.Contains(oldBookLetter))
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

                foreach (var rack in this.Racks)
                {
                    if (rack.Letters.Contains(newBookLetter))
                    {
                        foreach (var bookItem in oldBookItems)
                        {
                            rack.BookItems.Add(bookItem);
                            bookItem.Rack = rack;
                        }
                        break;
                    }
                }
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
                var letters = new List<char>();
                letters.Add((char)ch++);

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

                this.Racks.Add(rack);
            }
        }

        public bool LendBook(IAccount user, IBook book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    var bookItem = rack.BookItems.FirstOrDefault(bI => bI.Book == book);

                    if (bookItem == null)
                    {
                        return false;
                    }

                    var bookLending = new BookLending()
                    {
                        BookItem = bookItem,
                        User = user,
                        Date = DateTime.Now
                    };

                    this.SystemService.BookLendings.Add(bookLending);
                    rack.BookItems.Remove(bookItem);
                    break;
                }
            }
            return true;
        }

        public void ReserveBook(IAccount user, IBook book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    var bookItem = rack.BookItems.FirstOrDefault(bR => bR.Book == book);

                    var bookReserv = new BookReservation
                    {
                        BookItem = bookItem,
                        User = user,
                        Date = DateTime.Now
                    };

                    this.SystemService.BookReservations.Add(bookReserv);
                    break;
                }
            }
        }

        public void ReturnBook(IBookLending bookLanding)
        {
            this.SystemService.BookLendings.Remove(bookLanding);
            bookLanding.BookItem.Rack.BookItems.Add(bookLanding.BookItem);
        }
    }
}