using LibrarySystem.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.UnitTest
{
    public  class BookTesting
    {
        public  Book GetBookForTesting()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";

            return new Book(isbn, title, pages, subject, publishers, publishDate, author);
        }
    }
}
