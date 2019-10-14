using System;

namespace LibrarySystem.Books
{
    public class BookLending : BookRegistry
    {
        public DateTime? ReturnDate { get; set; }
    }
}