using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using System;

namespace LibrarySystem.Models.Contracts.Books
{
    public interface IBookRegistry
    {
        int BookItemId { get; set; }
        BookItem BookItem { get; set; }
        DateTime Date { get; set; }
        int AccountId { get; set; }
        Account User { get; set; }
    }
}