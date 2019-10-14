using System;
using System.Linq;

namespace LibrarySystem
{
    public class RenewBookCommand : Command   //polymorphism
                                              // Liskov Substitution Principle
    {
        public override Options MenuOption => Options.RenewBook;

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Enter ISBN of the book you want to renew");
            var isbnBook = Console.ReadLine();

            var bookLending = commandArgs.LibrarySystemContext.BookLendings.FirstOrDefault(b => b.BookItem.Book.ISBN == isbnBook && b.User == commandArgs.UsersService.CurrentAccount);

            if (bookLending == null)
            {
                Console.WriteLine($"Book with the following ISBN: {isbnBook} does not exist");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            if (commandArgs.LibraryService.SystemService.ValidateLendPeriod(bookLending))
            {
                Console.WriteLine("Enter how many days you want to renew the book");
                var days = int.Parse(Console.ReadLine());
                if (days > 10)
                {
                    Console.WriteLine("You can renew the book up to 10 days");
                    Console.ReadKey();
                    return Options.HomeMenu;
                }

                bookLending.Date = bookLending.Date.AddDays(days);

                Console.WriteLine($"You renewed the book from {DateTime.Now} to {bookLending.Date}");
                Console.ReadKey();
            }

            return Options.HomeMenu;
        }
    }
}