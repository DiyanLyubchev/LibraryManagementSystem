using System;
using System.Linq;

namespace LibrarySystem
{
    public class ReturnBookCommand : Command  //polymorphism
    {
        public override Options MenuOption => Options.ReturnBook;

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Enter the ISBN of the book you want to return");
            var bookIsbn = Console.ReadLine();

            var bookLending = commandArgs.LibraryService.SystemService.BookLendings
                .FirstOrDefault(b => b.BookItem.Book.ISBN == bookIsbn
                    && b.User == commandArgs.UsersService.CurrentAccount);

            if (bookLending == null)
            {
                Console.WriteLine($"Book with the following ISBN {bookIsbn} was not found!");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            if (!commandArgs.LibraryService.SystemService.ValidateLendPeriod(bookLending))
            {
                var fine = commandArgs.LibraryService.SystemService.CalculateFine(bookLending);
                Console.WriteLine($"You must pay {fine} for the overdue period");
                commandArgs.UsersService.CurrentAccount.CanCheckOutBook = false;
                Console.ReadKey();
                return Options.HomeMenu;
            }

            commandArgs.LibraryService.ReturnBook(bookLending);
            Console.WriteLine("The book was returned successfully");
            Console.ReadKey();

            var reservations = commandArgs.LibraryService.SystemService.BookReservations.Where(b => b.BookItem.Book.ISBN == bookIsbn);

            IBookReservation firstReservation = new BookReservation() { Date = DateTime.Now };
            if (reservations.Count() > 0)
            {
                foreach (var reservation in reservations)
                {
                    if (firstReservation.Date > reservation.Date)
                    {
                        firstReservation = reservation;
                    }
                }

                commandArgs.LibraryService.SystemService.BookReservations.Remove(firstReservation);
            }
            commandArgs.LibraryService.SystemService.BookReservations.Remove(firstReservation);

            return Options.HomeMenu;
        }
    }
}