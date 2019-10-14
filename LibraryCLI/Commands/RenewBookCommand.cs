using System;
using System.Collections.Generic;
using System.Text;
using VenneslaLibraryTeamWork;


namespace LibraryCopyOfContent.Commands
{
    class RenewBookCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {

            Console.WriteLine("Enter ISBN of the book you want to renew");
            var isbnBook = Console.ReadLine();

            var bookLending = commandArgs.Library.System.BookLendings.Find(b => b.BookItem.Book.ISBN == isbnBook);

            if (bookLending == null)
            {
                Console.WriteLine($"Book with the following ISBN: {isbnBook} does not exist");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            if (commandArgs.Library.System.ValidateLendPeriod(bookLending))
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
