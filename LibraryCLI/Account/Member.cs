using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class Member : Account
    {
        public Member(string userName) : base(userName, AccountType.Member)
        {

        }
    }
}
