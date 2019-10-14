using System;
using System.Collections.Generic;
using System.Text;

namespace VenneslaLibraryTeamWork
{
    public class Rack
    {
        public int RackNumber { get; set; }

        public RackLocation Location { get; set; }

        public List<BookItem> BookItems { get; set; } = new List<BookItem>();

        public List<char> Letters { get; set; }
    }
}
