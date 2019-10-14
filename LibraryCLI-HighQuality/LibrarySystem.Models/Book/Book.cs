using System;

namespace LibrarySystem
{
    public class Book : IBook // Single Responsibility
    {
        private string publishDate;
        public string ISBN { get; set; }
        public string Title { get; set; }

        public int Pages { get; set; }
        public string Subject { get; set; }
        public string Publishers { get; set; }

        public string PublishDate
        {
            get
            {
                return this.publishDate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Publish date cannot be null");
                }
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("PublishDate date must be between 5 and 30 symbols");
                }
                this.publishDate = value;
            }
        }

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