using System.Collections.Generic;

namespace LibrarySystem
{
    public interface IRack
    {
        IList<IBookItem> BookItems { get; set; }
        IList<char> Letters { get; set; }
        IRackLocation Location { get; set; }
        int RackNumber { get; set; }
    }
}