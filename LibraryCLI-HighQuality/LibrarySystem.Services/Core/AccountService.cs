using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class AccountService : IAccountService
    {
        public IList<IAccount> Accounts { get; }
        public IAccount CurrentAccount { get; private set; }

        public AccountService(IList<IAccount> accounts = null)
        {
            this.Accounts = accounts ?? new List<IAccount>();
        }

        public virtual IAccount CreateAccount(string userName, AccountType type)
        {
            IAccount account;
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

        public virtual bool Login(string username)
        {
            var account = this.Accounts.SingleOrDefault(a => a.UserName == username);
            if (account != null)
            {
                this.CurrentAccount = account;
                return true;
            }
            return false;
        }

    }
}