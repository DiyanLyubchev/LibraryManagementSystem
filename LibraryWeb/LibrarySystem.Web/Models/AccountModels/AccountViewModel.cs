using LibrarySystem.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Web.Models
{
    public class AccountViewModel : BaseViewModel
    {
        [Required]
        public string Username { get; set; }
    }
}
