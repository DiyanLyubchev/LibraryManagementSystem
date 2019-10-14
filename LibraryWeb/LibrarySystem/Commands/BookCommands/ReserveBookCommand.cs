using LibrarySystem.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class ReserveBookCommand : Command  //polymorphism
                                              // Liskov Substitution Principle   
    {
        public override Options MenuOption => Options.ReserveBook;

        public override Options Execute(ICommandArgs commandArgs)
        {
            if (commandArgs.LibrarySystemContext.BookLendings.Count(b => b.User == commandArgs.UsersService.CurrentAccount) == 5)
            {
                Console.WriteLine("You cannot reserve more than 5 books");
                Console.ReadKey();
                return Options.HomeMenu;
            }
            Console.WriteLine("Enter ISBN of the book you want:");
            var bookIsbn = Console.ReadLine();

            var book = commandArgs.LibrarySystemContext.Books.FirstOrDefault(b => b.ISBN == bookIsbn);

            if (book == null)
            {
                Console.WriteLine($"Book with the following ISBN: {bookIsbn} was not found");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            var bookReservation = new BookReservation();
            var user = commandArgs.UsersService.CurrentAccount;

            var option = this.MultipleChoice( title: " Do you want to reserve?", new List<string>
            {
               "Reserve",
               "Cancel"
            });
            if (option == "Reserve")
            {
                if (commandArgs.LibrarySystemContext.BookLendings.Count(b => b.User == commandArgs.UsersService.CurrentAccount) == 5)
                {
                    Console.WriteLine("You cannot reserve more than 5 books");
                    Console.ReadKey();
                    return Options.HomeMenu;
                }
                commandArgs.LibraryService.ReserveBook(user, book);
                Console.WriteLine($"You reserved book: {book} {DateTime.Now}");
                Console.ReadKey();
            }
            if (option == "Cancel")
            {
                Console.WriteLine("You canceled your reservation!");
                Console.ReadKey();
                return Options.HomeMenu;
            }

            return Options.HomeMenu;
        }
    }
}