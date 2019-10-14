using LibrarySystem.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Models.Racks
{
    public class RackLetter : BaseIdEntity  // Single Responsibility
    {
        public char Letter { get; set; }
        public int RackId { get; set; }
        public Rack Rack { get; set; }
    }
}
