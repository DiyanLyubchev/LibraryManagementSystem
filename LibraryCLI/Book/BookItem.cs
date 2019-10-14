using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class BookItem
    {
        public Book Book { get; set; }
        public Rack Rack { get; set; }
        public override string ToString()
        {
            return Book.ToString();
        }
    }
}
