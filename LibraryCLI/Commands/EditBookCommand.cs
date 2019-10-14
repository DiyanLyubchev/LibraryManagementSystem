using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VenneslaLibraryTeamWork
{
    public class EditBookCommand : ICommand
    {
       public Options Execute(ICommandArgs commandArgs)
       {

            Console.WriteLine("Enter ISBN of book");
            var isbnInput = Console.ReadLine();

            var oldBook = commandArgs.Library.Books.FirstOrDefault(b => b.ISBN == isbnInput);

            if(oldBook == null)
            {
                Console.WriteLine($"Book with ISBN - {isbnInput} does not exist");
                Console.ReadKey();
                return Options.BookMenu;
            }


            var options = commandArgs.MultipleChoice(title: $"Found book {oldBook}", new List<string>
            {
                "Edit Title",
                "Edit Publisher",
                "Edit Subject"
            });


            var newBook = new Book();
            switch (options)
            {
                case "Edit Title":
                    var title = Console.ReadLine();
                    newBook.Title = title;
                    commandArgs.Library.EditBook(oldBook, newBook);
                    break;
                case "Edit Publishers":
                    var publisher = Console.ReadLine();
                    newBook.Publishers = publisher;
                    commandArgs.Library.EditBook(oldBook, newBook);
                    break;
                case "Edit Subject":
                    var subject = Console.ReadLine();
                    newBook.Subject = subject;
                    commandArgs.Library.EditBook(oldBook, newBook);
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Edited book {oldBook}");
            Console.ReadKey();

            return Options.HomeMenu;
       }
    }
}
