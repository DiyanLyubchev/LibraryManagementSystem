using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }

        public string ISBN { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }

        public string UserId { get; set; }

        public int BookId { get; set; }

        public BaseTitleDto BaseDto { get; set; }
    }
}
