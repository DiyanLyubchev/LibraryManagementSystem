using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibrarySystem.Services.Dto
{
    public class AccountDto
    {
        [Required]
        public string Username { get; set; }
    }
}
