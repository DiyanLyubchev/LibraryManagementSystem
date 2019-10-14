using LibrarySystem.Models.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.UnitTest
{
    public static class BookGeneratorUtil
    {
        public static Book GenerateBook()
        {
            var isbn = "00-23-56-43";
            var title = "TestTitle";
            var pages = 300;
            var subject = "TestSubject";
            var publishers = "TestPublishers";
            var publishDate = "TestPublishDate";
            var author = "TestAuthor";
            var picture = "TestPicture";

            var book = new Book()
            {
                ISBN = isbn,
                Title = title,
                Pages = pages,
                Subject = subject,
                Publishers = publishers,
                PublishDate = publishDate,
                Author = author,
                Picture = picture,
            };

            return book;
        }
    }
}
