using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class AddBookCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
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


            var book = new Book(isbn, title, pages, subject, publishers, publishDate, author);
            commandArgs.Library.AddBook(book);

            return Options.HomeMenu;

        }
    }
}
        