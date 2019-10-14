using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services.Dto
{
    public class BaseTitleDto
    {
        public string UserId { get; set; }

        public int BookId { get; set; }

        public string Title { get; set; }
    }
}
