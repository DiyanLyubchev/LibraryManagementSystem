using System.Collections.Generic;

namespace LibrarySystem
{
    public interface ICatalogService
    {
        IDictionary<string, IList<IBook>> SortedByAuthor { get; }
        IDictionary<string, IList<IBook>> SortedByPublishDate { get; }
        IDictionary<string, IList<IBook>> SortedBySubject { get; }
        IDictionary<string, IList<IBook>> SortedByTitle { get; }

        void AddBook(IBook book);
        IList<IBook> SearchByAuthor(string author);
        IList<IBook> SearchByPublishDate(string publishDateTime);
        IList<IBook> SearchBySubject(string subject);
        IList<IBook> SearchByTitle(string title);
    }
}