using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class Librarian : Account
    {
        public Librarian(string userName) : base(userName, AccountType.Librarian)
        {

        }
    }
}
