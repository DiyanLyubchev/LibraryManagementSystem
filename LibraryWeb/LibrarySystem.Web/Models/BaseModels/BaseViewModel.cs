using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Web.Models
{
    public class BaseViewModel
    {
        [ScaffoldColumn(false)]
        public string LastNotification { get; set; }
    }
}
