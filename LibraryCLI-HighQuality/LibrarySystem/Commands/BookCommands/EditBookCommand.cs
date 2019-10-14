using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class EditBookCommand : Command  //polymorphism
    {
        public override Options MenuOption => Options.EditBook;

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Enter ISBN of book");
            var isbnInput = Console.ReadLine();

            IBook oldBook = commandArgs.LibraryService.Books.FirstOrDefault(b => b.ISBN == isbnInput);

            if (oldBook == null)
            {
                Console.WriteLine($"Book with ISBN - {isbnInput} does not exist");
                Console.ReadKey();
                return Options.BookMenu;
            }

            var options = this.MultipleChoice( title: $"Found book {oldBook}", new List<string>
            {
                "Edit Title",
                "Edit Publisher",
                "Edit Subject"
            });

            IBook newBook = new Book();
            switch (options)
            {
                case "Edit Title":
                    var title = Console.ReadLine();
                    newBook.Title = title;
                    commandArgs.LibraryService.EditBook(oldBook, newBook);
                    break;

                case "Edit Publishers":
                    var publisher = Console.ReadLine();
                    newBook.Publishers = publisher;
                    commandArgs.LibraryService.EditBook(oldBook, newBook);
                    break;

                case "Edit Subject":
                    var subject = Console.ReadLine();
                    newBook.Subject = subject;
                    commandArgs.LibraryService.EditBook(oldBook, newBook);
                    break;
            }
            Console.Clear();
            Console.WriteLine($"Edited book {oldBook}");
            Console.ReadKey();

            return Options.HomeMenu;
        }
    }
}