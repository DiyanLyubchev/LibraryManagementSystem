using System;

namespace LibrarySystem.Services.CustomException
{
    public class BookException : Exception
    {

        public BookException(string masege)
        : base(String.Format(masege))
        {

        }
    }
}
