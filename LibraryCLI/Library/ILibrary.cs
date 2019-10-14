using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public interface ILibrary
    {
        string Name { get; }
        string Address { get; }
        HashSet<Book> Books { get; }
        Catalog Catalog { get; }

        List<Rack> Racks { get; }
        System System { get; }
        void AddBook(Book book);
        void EditBook(Book oldBook, Book newBook);
        void FillRacks();
        void RemoveBook(Book book);
        bool LendBook(Account user, Book book);
        void ReserveBook(Account user, Book book);
        void ReturnBook(BookLending bookLanding);


    }
}
