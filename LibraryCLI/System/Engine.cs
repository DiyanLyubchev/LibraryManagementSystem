using LibraryCopyOfContent.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public sealed partial class Engine
    {
        private readonly Dictionary<Options, ICommand> commands = new Dictionary<Options, ICommand>();

        public static Engine Instance { get; } = new Engine(); // property koeto durji edinstvenata INSTACE na classa

        private Engine()   
        {
            this.commands.Add(Options.AddBook, new AddBookCommand());  // add command in dictionary
            this.commands.Add(Options.EditBook, new EditBookCommand());
            this.commands.Add(Options.EditUsers, new EditUsersCommand());
            this.commands.Add(Options.HomeMenu, new HomeMenuCommand());
            this.commands.Add(Options.LoginMenu, new LoginMenuCommand());
            this.commands.Add(Options.SearchInCatalog, new SearchInCatalogCommand());
            this.commands.Add(Options.RegisterUser, new RegisterUserCommand());
            this.commands.Add(Options.CheckOutBook, new CheckOutOrReserveBookCommand());
            this.commands.Add(Options.ReturnBook, new ReturnBookCommand());
            this.commands.Add(Options.RenewBook, new RenewBookCommand());
            this.commands.Add(Options.Quit, new QuitCommand());
        }

        public void Start()
        {
            var commandArgs = new CommandArgs();
            commandArgs.Library = this.CreateLibrary("Vennesla Library and Cultural Cente", "Vennesla, Norway");
            commandArgs.Users = this.CreateUserAccounts();

            var currentOption = Options.LoginMenu;
            while (currentOption != Options.Exited)
            {
                currentOption = this.commands[currentOption].Execute(commandArgs);
            }
        }

        private ILibrary CreateLibrary(string name, string address)
        {
            var library = new Library(name, address);

            library.FillRacks();  // fill rack

            var booksJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/books.json"));
            var books = JsonConvert.DeserializeObject<Book[]>(booksJson);

            foreach (var book in books)
            {
                library.AddBook(book); // fill book library
                library.AddBook(book);
                library.AddBook(book);
            }

            return library;
        }

        private Users CreateUserAccounts()
        {
            var usersJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/librarians.json"));
            var librarians = JsonConvert.DeserializeObject<Librarian[]>(usersJson);

            var users = new Users();
            foreach (var librarian in librarians)
            {
                users.CreateAccount(librarian.UserName, librarian.Type);
            }

            return users;
        }
    }
}
