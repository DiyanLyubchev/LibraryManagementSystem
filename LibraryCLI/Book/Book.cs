using System;
using System.Collections.Generic;

namespace VenneslaLibraryTeamWork
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }

        public int Pages { get; set; }
        public string Subject { get; set; }
        public string Publishers { get; set; }
        public string PublishDate { get; set; }
        public string Author { get; set; }

        public Book()
        {
        }

        public Book(string isbn, string title, int pages, string subject,
            string publishers, string publishDate, string author)
        {
            ISBN = isbn;
            Title = title;
            Pages = pages;
            Subject = subject;
            Publishers = publishers;
            PublishDate = publishDate;
            Author = author;
        }

        public override string ToString()
        {
            return $"Title: {this.Title}";
        }
    }
}
