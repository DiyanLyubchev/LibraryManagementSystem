using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class SearchInCatalogCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            var options = commandArgs.MultipleChoice(title: "Search in catalog", options: new List<Options>
            {
               Options.SearchInCatalog_ByTitle,
               Options.SearchInCatalog_ByAuthor,
               Options.SearchInCatalog_BySubject,
               Options.SearchInCatalog_SearchByPublishDate,
               Options.Quit
            });
            List<Book> books = null;

            switch (options)
            {
                case Options.SearchInCatalog_ByTitle:
                    Console.WriteLine("Please enter title:");
                    var title = Console.ReadLine();
                    books = commandArgs.Library.Catalog.SearchByTitle(title);
                    break;
                case Options.SearchInCatalog_ByAuthor:
                    Console.WriteLine("Please enter author:");
                    var author = Console.ReadLine();
                    books = commandArgs.Library.Catalog.SearchByAuthor(author);
                    break;
                case Options.SearchInCatalog_BySubject:
                    Console.WriteLine("Please enter subject:");
                    var subject = Console.ReadLine();
                    books = commandArgs.Library.Catalog.SearchBySubject(subject);
                    break;
                case Options.SearchInCatalog_SearchByPublishDate:
                    Console.WriteLine("Please enter publish date:");
                    var publishDate = Console.ReadLine();
                    books = commandArgs.Library.Catalog.SearchByPublishDate(publishDate);
                    break;
            }

            commandArgs.SelectedBook = commandArgs.MultipleChoice(title: "Book found", books);

            return Options.HomeMenu;// BookMenu 
        }
    }
}

