using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class Catalog
    {
        public Dictionary<string, List<Book>> SortedByTitle { get; private set; }
        public Dictionary<string, List<Book>> SortedByAuthor { get; private set; }
        public Dictionary<string, List<Book>> SortedBySubject { get; private set; }
        public Dictionary<string, List<Book>> SortedByPublishDate { get; private set; }

        public Catalog()
        {
            this.SortedByTitle = new Dictionary<string, List<Book>>();
            this.SortedByAuthor = new Dictionary<string, List<Book>>();
            this.SortedBySubject = new Dictionary<string, List<Book>>();
            this.SortedByPublishDate = new Dictionary<string, List<Book>>();
        }
       
        public void AddBook(Book book)
        {
            this.SortedByTitle.TryAdd(book.Title, new List<Book>());
            this.SortedByTitle[book.Title].Add(book);

            this.SortedByAuthor.TryAdd(book.Author, new List<Book>());
            this.SortedByAuthor[book.Author].Add(book);

            this.SortedBySubject.TryAdd(book.Subject, new List<Book>());
            this.SortedBySubject[book.Subject].Add(book);

            this.SortedByPublishDate.TryAdd(book.PublishDate, new List<Book>());
            this.SortedByPublishDate[book.PublishDate].Add(book);
        }

        public List<Book> SearchByTitle(string title)
        {
            if (this.SortedByTitle.ContainsKey(title))
            {
                return this.SortedByTitle[title];
            }
            throw new KeyNotFoundException($"Book with the following Title {title} was not found ");
        }
        public List<Book> SearchByAuthor(string author)
        {
            if (this.SortedByAuthor.ContainsKey(author))
            {
                return this.SortedByAuthor[author];
            }
            throw new KeyNotFoundException($"Book from the following Author {author} was not found ");
        }
        public List<Book> SearchBySubject(string subject)
        {
            if (this.SortedBySubject.ContainsKey(subject))
            {
                return this.SortedBySubject[subject];
            }
            throw new KeyNotFoundException($"Book with the following Subject {subject} was not found ");
        }
        public List<Book> SearchByPublishDate(string publishDateTime)
        {
            if (this.SortedByPublishDate.ContainsKey(publishDateTime))
            {
                return this.SortedByPublishDate[publishDateTime];
            }
            throw new KeyNotFoundException($"Book with the following PublishDate {publishDateTime} was not found ");
        }

    }
}
