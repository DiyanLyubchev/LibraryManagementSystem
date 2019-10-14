using System;
using System.Collections.Generic;
using System.Text;

namespace LibrarySystem.Services.CustomException
{
    public class UserExeption : Exception
    {
        public UserExeption(string masege)
        : base(String.Format(masege))
        {
        }
    }
}
