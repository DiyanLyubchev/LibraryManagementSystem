using System;

namespace LibrarySystem
{
    public class BookRegistry : IBookRegistry 
    {
        public IBookItem BookItem { get; set; }
        public IAccount User { get; set; }

        public DateTime Date { get; set; }
    }
}