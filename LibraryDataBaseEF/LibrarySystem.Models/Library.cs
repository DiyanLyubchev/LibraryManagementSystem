using LibrarySystem.Models.Contracts.Library;
using System;

namespace LibrarySystem.Models
{
    public class Library : ILibrary  // Single Responsibility
    {
        private string name;
        private string address;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tha name cannot be null or empty!");
                }
                if (value.Length < 3 || value.Length > 50)
                {
                    throw new ArgumentException("The library name lenght must between 3 and 50 symbols ");
                }
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Tha name cannot be null or empty!");
                }
                if (value.Length < 3 || value.Length > 50)
                {
                    throw new ArgumentException("The library address lenght must between 10 and 50 symbols ");
                }
                address = value;
            }
        }


    }
}
