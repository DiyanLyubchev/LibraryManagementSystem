using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services.Dto
{
    public class RenewBookDto
    {
        public int BookId { get; set; }

        public string UserId { get; set; }

        public int Days { get; set; }
    }
}
