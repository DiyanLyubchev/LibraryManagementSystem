using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class CheckOutOrReserveBookCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            if (commandArgs.Library.System.BookLendings.Count(u => u.User == commandArgs.Users.CurrentAccount) == 5)
            {
                Console.WriteLine("You cannot take more than 5 books");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            Console.WriteLine("Enter ISBN of the book you want:");
            var bookIsbn = Console.ReadLine();

            var book = commandArgs.Library.Books.FirstOrDefault(b => b.ISBN == bookIsbn);

            if(book == null)
            {
                Console.WriteLine($"Book with the following ISBN: {bookIsbn} was not found");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            var bookReservation = new BookReservation();
            var user = commandArgs.Users.CurrentAccount;

            if (!commandArgs.Library.LendBook(user, book))
            {
                var option = commandArgs.MultipleChoice(title: "The book has no other copies left!" +
                    " Do you want to reserve?", new List<String>
                    {
                        "Reserve", 
                        "Cancel"
                    });
                if(option == "Reserve")
                {
                    if (commandArgs.Library.System.BookLendings.Count(b => b.User == commandArgs.Users.CurrentAccount) == 5)
                    {
                        Console.WriteLine("You cannot reserve more than 5 books");
                        Console.ReadKey();
                        return Options.HomeMenu;
                    }
                    commandArgs.Library.ReserveBook(user, book);
                    Console.WriteLine($"You reserved book: {book} {DateTime.Now}");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine($"You checked out book: {book} {DateTime.Now}");
                Console.ReadKey();
            }
           return Options.HomeMenu;
        }
    }
}
