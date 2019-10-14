using LibrarySystem.Models.Books;
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class SearchInCatalogCommand : Command  //polymorphism
    {                                              //Liskov Substitution Principle
        public override Options MenuOption => Options.SearchInCatalog;

        public override Options Execute(ICommandArgs commandArgs)
        {
            var options = this.MultipleChoice( title: "Search in catalog", options: new List<Options>
            {
               Options.SearchInCatalogByTitle,
               Options.SearchInCatalogByAuthor,
               Options.SearchInCatalogBySubject,
               Options.SearchInCatalogByPublishDate,
               Options.Back
            });

            IList<Book> books = null;

            switch (options)
            {
                case Options.SearchInCatalogByTitle:
                    Console.WriteLine("Please enter title:");
                    var title = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchByTitle(title);
                    break;

                case Options.SearchInCatalogByAuthor:
                    Console.WriteLine("Please enter author:");
                    var author = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchByAuthor(author);
                    break;

                case Options.SearchInCatalogBySubject:
                    Console.WriteLine("Please enter subject:");
                    var subject = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchBySubject(subject);
                    break;

                case Options.SearchInCatalogByPublishDate:
                    Console.WriteLine("Please enter publish date:");
                    var publishDate = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchByPublishDate(publishDate);
                    break;

                case Options.Back:
                    Console.WriteLine("Returning to home menu...");
                    Console.ReadKey();
                    return Options.HomeMenu;
                    
            }

            commandArgs.SelectedBook = this.MultipleChoice( title: "Book found", books);

            return Options.HomeMenu;
        }
    }
}