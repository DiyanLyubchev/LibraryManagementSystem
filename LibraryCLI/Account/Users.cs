using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class Users
    {
        public List<Account> Accounts { get; } = new List<Account>();
        public Account CurrentAccount { get; private set; }                      

        public Account CreateAccount(string userName, AccountType type)
        {
            Account account;
            switch (type)
            {
                case AccountType.Librarian:
                    account = new Librarian(userName);
                    Accounts.Add(account);
                    return account;


                case AccountType.Member:
                    account = new Member(userName);
                    Accounts.Add(account);
                    return account;


                default:
                    throw new InvalidOperationException("Does not support account type");
            }
        }
        public bool Login(string username) 
        {
            var account = this.Accounts.Find(a => a.UserName == username);
            if (account != null)
            {
                this.CurrentAccount = account;
                return true;
            }
            return false;
        }
    }
}
