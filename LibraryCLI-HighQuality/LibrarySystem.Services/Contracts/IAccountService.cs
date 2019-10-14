using System.Collections.Generic;

namespace LibrarySystem
{
    public interface IAccountService
    {
        IList<IAccount> Accounts { get; }
        IAccount CurrentAccount { get; }

        IAccount CreateAccount(string userName, AccountType type);
        bool Login(string username);
    }
}