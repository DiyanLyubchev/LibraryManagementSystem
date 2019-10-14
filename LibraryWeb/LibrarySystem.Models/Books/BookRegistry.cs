using LibrarySystem.BaseEntitys;
using LibrarySystem.Models.Accounts;
using LibrarySystem.Models.Books;
using System;

namespace LibrarySystem.Books
{
    public class BookRegistry : BaseIdEntity
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}