using Newtonsoft.Json;
using System;
using System.IO;

namespace LibrarySystem
{
    public class Database : IDatabase
    {
        private readonly ILibraryService library;
        private readonly IAccountService users;

        public Database(ILibraryService library, IAccountService users)
        {
            this.library = library;
            this.users = users;
        }

        public ILibraryService LoadLibrary()
        {
            //this.library.Name = "Vennesla Library and Cultural Cente";
            //this.library.Address = "Vennesla, Norway";
            this.library.FillRacks();

            var booksJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/books.json"));
            var books = JsonConvert.DeserializeObject<Book[]>(booksJson);

            foreach (IBook book in books)
            {
                this.library.AddBook(book);
                this.library.AddBook(book);
                this.library.AddBook(book);
            }

            return this.library;
        }

        public IAccountService LoadUserAccounts()
        {
            var usersJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/librarians.json"));
            var librarians = JsonConvert.DeserializeObject<Librarian[]>(usersJson);

            var usersMemberJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/member.json"));
            var members = JsonConvert.DeserializeObject<Member[]>(usersMemberJson);

            foreach (var member in members)
            {
                this.users.CreateAccount(member.UserName, member.Type);
            }

            foreach (var librarian in librarians)
            {
                this.users.CreateAccount(librarian.UserName, librarian.Type);
            }

            return this.users;
        }
    }
}