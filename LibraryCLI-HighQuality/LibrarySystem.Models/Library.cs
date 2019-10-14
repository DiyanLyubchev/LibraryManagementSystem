using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class Library : ILibrary
    {
        private string name;
        private string address;

        public string Name
        {
            get
            {
                return this.name;
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
                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
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
                this.address = value;
            }
        }

       
    }
}
