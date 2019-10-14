using LibrarySystem.Models;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Contracts.Accounts;
using LibrarySystem.Services.Contracts.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Services.Core
{
    public class AccountService : IAccountService // Single Responsibility
    {
        private LibrarySystemContext dbContext = new LibrarySystemContext();
        public Account CurrentAccount { get; private set; }

        private readonly IAccountFactory accountFactory;
        public AccountService(IAccountFactory accountFactory)
        {
            this.accountFactory = accountFactory;
        }

        public virtual Account CreateAccount(string userName, string passowrd, AccountType type)
        {
            var hashed_password = SecurePasswordHasherHelper.Hash(passowrd);
            Account account;
            switch (type)
            {
                case AccountType.Librarian:
                    account = accountFactory.CreateLibrarian(userName, hashed_password);

                    var accountLibrarianAvailable = dbContext.AccountsOldData
                        .Where(uName => uName.UserName == userName)
                        .Select(u => new
                        {
                            u.UserName
                        });
                    if (accountLibrarianAvailable.Count() == 0)
                    {
                        dbContext.AccountsOldData.Add(account);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine($"Account with the following username: {userName} exists");
                        Console.ReadKey();
                    }

                    return account;

                case AccountType.Member:
                    account = accountFactory.CreateMember(userName, hashed_password);

                    var accountMemberAvailable = dbContext.AccountsOldData
                        .Where(uName => uName.UserName == userName)
                        .Select(u => new
                        {
                            u.UserName
                        });
                    if (accountMemberAvailable.Count() == 0)
                    {
                        dbContext.AccountsOldData.Add(account);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine($"Account with the following username: {userName}exists");
                        Console.ReadKey();
                    }
                    dbContext.SaveChanges();
                    return account;

                default:
                    throw new InvalidOperationException("Does not support account type");
            }
        }
        public IEnumerable<IAccount> GetAllAccounts()
        {
            return dbContext.AccountsOldData;
        }
        public IAccount GetAccount(string accountName)
        {
            return dbContext.AccountsOldData.FirstOrDefault(ac => ac.UserName == accountName);
        }

        public virtual bool Login(string username, string password)
        {
            var account = dbContext.AccountsOldData.SingleOrDefault(a => a.UserName == username);
            if (account != null)
            {
                CurrentAccount = account;
                return true;
            }
            return false;
        }

    }
}