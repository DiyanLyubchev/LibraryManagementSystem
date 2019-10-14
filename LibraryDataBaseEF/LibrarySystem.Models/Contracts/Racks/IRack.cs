using LibrarySystem.Models.Books;
using LibrarySystem.Models.Racks;
using System.Collections.Generic;

namespace LibrarySystem.Models.Contracts.Racks
{
    public interface IRack
    {
        ICollection<BookItem> BookItems { get; }
        ICollection<RackLetter> Letters { get; }
        RackLocation Location { get; }
        int RackNumber { get; }
    }
}