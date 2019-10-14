using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Web.Models
{
    public class MembershipViewModel : BaseViewModel
    {
        [Range(1, 3)]
        [Required]
        public int Months { get; set; }
    }
}
