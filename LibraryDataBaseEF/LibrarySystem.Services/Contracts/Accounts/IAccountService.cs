using LibrarySystem.Models;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Contracts.Accounts;
using System.Collections.Generic;

namespace LibrarySystem.Services.Contracts.Accounts
{
    public interface IAccountService
    {
        IEnumerable<IAccount> GetAllAccounts();
        Account CurrentAccount { get; }

        Account CreateAccount(string userName, string password, AccountType type);
        bool Login(string username, string password);
    }
}