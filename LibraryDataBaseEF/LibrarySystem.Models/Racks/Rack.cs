using LibrarySystem.Models.BaseEntity;
using LibrarySystem.Models.Books;
using LibrarySystem.Models.Contracts.Racks;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Racks
{
    public class Rack : BaseIdEntity, IRack // One Rack vs many RackLetter
                                            // One Rack vs many BookItem
    {
        public int RackNumber { get; set; }

        public RackLocation Location { get; set; }

        public ICollection<BookItem> BookItems { get; set; } = new List<BookItem>();

        public ICollection<RackLetter> Letters { get; set; } = new List<RackLetter>();

    }
}