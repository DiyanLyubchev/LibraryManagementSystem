using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class Library : ILibrary
    {
        public string Name { get; }

        public string Address { get; }

        public Library(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public System System { get; } = new System();
        public List<Rack> Racks { get; } = new List<Rack>();

        public HashSet<Book> Books { get; } = new HashSet<Book>();
        public Catalog Catalog { get; } = new Catalog();

        public void AddBook(Book book)
        {
            char bookLetter = book.Title.ToUpper()[0];  

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    var bookItem = new BookItem(); // pravin si kopie na knigata koqto se  dobavq
                    bookItem.Book = book;
                    bookItem.Rack = rack;

                    rack.BookItems.Add(bookItem); // tuk sudurjame fizicheskite kopiq na edna kniga
                    break;
                }
            }
            if (this.Books.Add(book))
            {
                this.Catalog.AddBook(book);
            }

        }
        public void RemoveBook(Book book)
        {
            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter)) 
                {
                    var bookItem = rack.BookItems.Find(bI => bI.Book == book);

                    rack.BookItems.Remove(bookItem);
                    bookItem = rack.BookItems.Find(bI => bI.Book == book);

                    if (bookItem == null)
                    {
                        this.Books.Remove(book);
                    }
                    break;
                }
            }
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
                var letters = new List<char> ();
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
        public bool LendBook(Account user, Book book)
        {
            var bookItem = new BookItem();

            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    bookItem = rack.BookItems.Find(bI => bI.Book == book);

                    if (bookItem == null)
                    {
                        return false;
                    }
                    var bookLending = new BookLending
                    {
                        BookItem = bookItem,
                        User = user,
                        Date = DateTime.Now
                    };

                    this.System.BookLendings.Add(bookLending);
                    rack.BookItems.Remove(bookItem);
                    break;
                }

            }
            return true;
        }
        public void ReserveBook(Account user, Book book)
        {
            var bookItem = new BookItem();

            char bookLetter = book.Title.ToUpper()[0];

            foreach (var rack in this.Racks)
            {
                if (rack.Letters.Contains(bookLetter))
                {
                    bookItem = rack.BookItems.Find(bR => bR.Book == book);

                    var bookReserv = new BookReservation
                    {
                        BookItem = bookItem,
                        User = user,
                        Date = DateTime.Now
                    };
                    this.System.BookReservations.Add(bookReserv);
                    break;
                }
                   
            }
        }
        public void ReturnBook(BookLending bookLanding)
        {
            this.System.BookLendings.Remove(bookLanding);
            bookLanding.BookItem.Rack.BookItems.Add(bookLanding.BookItem);
        }


    }

}
