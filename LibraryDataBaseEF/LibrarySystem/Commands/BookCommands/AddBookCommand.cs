using LibrarySystem.Services.Contracts.Factory;
using System;

namespace LibrarySystem
{
    public class AddBookCommand : Command // polymorphism
                                         // Liskov Substitution Principle
    {
        private readonly IBookFactory bookFactory;
        public override Options MenuOption => Options.AddBook;

        public AddBookCommand(IBookFactory bookFactory)
        {
            this.bookFactory = bookFactory;
        }

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Please enter the ISBN of the book:");
            var isbn = Console.ReadLine();
            Console.WriteLine("Please enter the Title of the book:");
            var title = Console.ReadLine();
            Console.WriteLine("Please enter the Pages of the book:");
            var pages = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the Subject of the book:");
            var subject = Console.ReadLine();
            Console.WriteLine("Pleae enter the publisher of the book:");
            var publishers = Console.ReadLine();
            Console.WriteLine("Pleae enter the Publish Date of the book:");
            var publishDate = Console.ReadLine();
            Console.WriteLine("Please enter the Author of the book:");
            var author = Console.ReadLine();

            var book = this.bookFactory.CreateBook(isbn, title, pages, subject, publishers, publishDate, author);
            commandArgs.LibraryService.AddBook(book);
            commandArgs.LibraryService.AddBookInCatalog(book);

            return Options.HomeMenu;
        }
    }
}