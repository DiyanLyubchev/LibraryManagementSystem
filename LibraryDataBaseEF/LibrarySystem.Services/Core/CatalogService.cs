using LibrarySystem.Models.Books;
using LibrarySystem.Services.Contracts.Catalog;
using System.Collections.Generic;

namespace LibrarySystem.Services.Core
{
    public class CatalogService : ICatalogService  // Single Responsibility
    {
        public IDictionary<string, IList<Book>> SortedByTitle { get; }
        public IDictionary<string, IList<Book>> SortedByAuthor { get; }
        public IDictionary<string, IList<Book>> SortedBySubject { get; }
        public IDictionary<string, IList<Book>> SortedByPublishDate { get; }

        public CatalogService(IDictionary<string, IList<Book>> sortedByTitle = null,
                     IDictionary<string, IList<Book>> sortedByAuthor = null,
                     IDictionary<string, IList<Book>> sortedBySubject = null,
                     IDictionary<string, IList<Book>> sortedByPublishDate = null)
        {
            SortedByTitle = sortedByTitle ?? new Dictionary<string, IList<Book>>();
            SortedByAuthor = sortedByAuthor ?? new Dictionary<string, IList<Book>>();
            SortedBySubject = sortedBySubject ?? new Dictionary<string, IList<Book>>();
            SortedByPublishDate = sortedByPublishDate ?? new Dictionary<string, IList<Book>>();
        }

        public void AddBook(Book book)
        {
            SortedByTitle.TryAdd(book.Title, new List<Book>());
            SortedByTitle[book.Title].Add(book);

            SortedByAuthor.TryAdd(book.Author, new List<Book>());
            SortedByAuthor[book.Author].Add(book);

            SortedBySubject.TryAdd(book.Subject, new List<Book>());
            SortedBySubject[book.Subject].Add(book);

            SortedByPublishDate.TryAdd(book.PublishDate, new List<Book>());
            SortedByPublishDate[book.PublishDate].Add(book);
        }

        public IList<Book> SearchByTitle(string title)
        {
            if (SortedByTitle.ContainsKey(title))
            {
                return SortedByTitle[title];
            }
            throw new KeyNotFoundException($"Book with the following Title {title} was not found ");
        }

        public IList<Book> SearchByAuthor(string author)
        {
            if (SortedByAuthor.ContainsKey(author))
            {
                return SortedByAuthor[author];
            }
            throw new KeyNotFoundException($"Book from the following Author {author} was not found ");
        }

        public IList<Book> SearchBySubject(string subject)
        {
            if (SortedBySubject.ContainsKey(subject))
            {
                return SortedBySubject[subject];
            }
            throw new KeyNotFoundException($"Book with the following Subject {subject} was not found ");
        }

        public IList<Book> SearchByPublishDate(string publishDateTime)
        {
            if (SortedByPublishDate.ContainsKey(publishDateTime))
            {
                return SortedByPublishDate[publishDateTime];
            }
            throw new KeyNotFoundException($"Book with the following PublishDate {publishDateTime} was not found ");
        }
    }
}