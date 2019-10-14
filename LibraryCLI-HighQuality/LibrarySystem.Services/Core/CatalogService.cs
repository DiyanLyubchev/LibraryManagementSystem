using System.Collections.Generic;

namespace LibrarySystem
{
    public class CatalogService : ICatalogService
    {
        public IDictionary<string, IList<IBook>> SortedByTitle { get; }
        public IDictionary<string, IList<IBook>> SortedByAuthor { get; }
        public IDictionary<string, IList<IBook>> SortedBySubject { get; }
        public IDictionary<string, IList<IBook>> SortedByPublishDate { get; }

        public CatalogService(IDictionary<string, IList<IBook>> sortedByTitle = null,
                     IDictionary<string, IList<IBook>> sortedByAuthor = null,
                     IDictionary<string, IList<IBook>> sortedBySubject = null,
                     IDictionary<string, IList<IBook>> sortedByPublishDate = null)
        {
            this.SortedByTitle = sortedByTitle ?? new Dictionary<string, IList<IBook>>();
            this.SortedByAuthor = sortedByAuthor ?? new Dictionary<string, IList<IBook>>();
            this.SortedBySubject = sortedBySubject ?? new Dictionary<string, IList<IBook>>();
            this.SortedByPublishDate = sortedByPublishDate ?? new Dictionary<string, IList<IBook>>();
        }

        public void AddBook(IBook book)
        {
            this.SortedByTitle.TryAdd(book.Title, new List<IBook>());
            this.SortedByTitle[book.Title].Add(book);

            this.SortedByAuthor.TryAdd(book.Author, new List<IBook>());
            this.SortedByAuthor[book.Author].Add(book);

            this.SortedBySubject.TryAdd(book.Subject, new List<IBook>());
            this.SortedBySubject[book.Subject].Add(book);

            this.SortedByPublishDate.TryAdd(book.PublishDate, new List<IBook>());
            this.SortedByPublishDate[book.PublishDate].Add(book);
        }

        public IList<IBook> SearchByTitle(string title)
        {
            if (this.SortedByTitle.ContainsKey(title))
            {
                return this.SortedByTitle[title];
            }
            throw new KeyNotFoundException($"Book with the following Title {title} was not found ");
        }

        public IList<IBook> SearchByAuthor(string author)
        {
            if (this.SortedByAuthor.ContainsKey(author))
            {
                return this.SortedByAuthor[author];
            }
            throw new KeyNotFoundException($"Book from the following Author {author} was not found ");
        }

        public IList<IBook> SearchBySubject(string subject)
        {
            if (this.SortedBySubject.ContainsKey(subject))
            {
                return this.SortedBySubject[subject];
            }
            throw new KeyNotFoundException($"Book with the following Subject {subject} was not found ");
        }

        public IList<IBook> SearchByPublishDate(string publishDateTime)
        {
            if (this.SortedByPublishDate.ContainsKey(publishDateTime))
            {
                return this.SortedByPublishDate[publishDateTime];
            }
            throw new KeyNotFoundException($"Book with the following PublishDate {publishDateTime} was not found ");
        }
    }
}