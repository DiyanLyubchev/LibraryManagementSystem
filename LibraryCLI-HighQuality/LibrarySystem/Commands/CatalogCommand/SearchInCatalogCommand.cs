using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class SearchInCatalogCommand : Command  //polymorphism
    {
        public override Options MenuOption => Options.SearchInCatalog;

        public override Options Execute(ICommandArgs commandArgs)
        {
            var options = this.MultipleChoice( title: "Search in catalog", options: new List<Options>
            {
               Options.SearchInCatalog_ByTitle,
               Options.SearchInCatalog_ByAuthor,
               Options.SearchInCatalog_BySubject,
               Options.SearchInCatalog_SearchByPublishDate,
               Options.Back
            });

            IList<IBook> books = null;

            switch (options)
            {
                case Options.SearchInCatalog_ByTitle:
                    Console.WriteLine("Please enter title:");
                    var title = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchByTitle(title);
                    break;

                case Options.SearchInCatalog_ByAuthor:
                    Console.WriteLine("Please enter author:");
                    var author = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchByAuthor(author);
                    break;

                case Options.SearchInCatalog_BySubject:
                    Console.WriteLine("Please enter subject:");
                    var subject = Console.ReadLine();
                    books = commandArgs.LibraryService.CatalogService.SearchBySubject(subject);
                    break;

                case Options.SearchInCatalog_SearchByPublishDate:
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

            return Options.HomeMenu;// BookMenu
        }
    }
}