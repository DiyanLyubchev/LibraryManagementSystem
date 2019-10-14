using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class ReturnBookCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Enter the ISBN of the book you want to return");
            var bookIsbn = Console.ReadLine();

            var bookLending = commandArgs.Library.System.BookLendings.Find(b => b.BookItem.Book.ISBN == bookIsbn 
            && b.User == commandArgs.Users.CurrentAccount);

            if(bookLending == null)
            {
                Console.WriteLine($"Book with the following ISBN {bookIsbn} was not found!");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            if (!commandArgs.Library.System.ValidateLendPeriod(bookLending))
            {
                var fine = commandArgs.Library.System.CalculateFine(bookLending);
                Console.WriteLine($"You must pay {fine} for the overdue period");
                commandArgs.Users.CurrentAccount.CanCheckOutBook = false;
                Console.ReadKey();
                return Options.HomeMenu;
            }

            commandArgs.Library.ReturnBook(bookLending);
            Console.WriteLine("The book was returned successfully");
            Console.ReadKey();

            var reservations = commandArgs.Library.System.BookReservations.FindAll(b => b.BookItem.Book.ISBN == bookIsbn);  

            var firstReservation = new BookReservation() { Date = DateTime.Now };
            if (reservations.Count > 0)
            {

                foreach (var reservation in reservations)
                {
                    if (firstReservation.Date > reservation.Date)
                    {
                        firstReservation = reservation;
                    }
                }

                commandArgs.Library.System.BookReservations.Remove(firstReservation);
            }
            commandArgs.Library.System.BookReservations.Remove(firstReservation);


            return Options.HomeMenu;
        }
    }
}
