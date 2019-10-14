using System.Collections.Generic;

namespace LibrarySystem
{
    public class Rack : IRack
    {
        public int RackNumber { get; set; }

        public IRackLocation Location { get; set; }

        public IList<IBookItem> BookItems { get; set; } = new List<IBookItem>();

        public IList<char> Letters { get; set; }
    }
}