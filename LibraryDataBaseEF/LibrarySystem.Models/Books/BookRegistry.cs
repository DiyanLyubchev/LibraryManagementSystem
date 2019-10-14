using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.BaseEntity;
using LibrarySystem.Models.Contracts.Books;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Books
{
    public class BookRegistry : BaseIdEntity, IBookRegistry
    {
        [ForeignKey("BookItem")]
        public int BookItemId { get; set; }
        public BookItem BookItem { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account User { get; set; }
        public DateTime Date { get; set; }
    }
}