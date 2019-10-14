using System.Collections.Generic;

namespace LibrarySystem
{
    public class HomeMenuCommand : Command // Liskov Substitution Principle
    {
        public override Options MenuOption => Options.HomeMenu;

        public override Options Execute(ICommandArgs commandArgs)
        {
            var user = commandArgs.UsersService.CurrentAccount;
            var options = new List<Options>();

            if (user.CanAddBook)
            {
                options.Add(Options.AddBook);
            }
            if (user.CanEditBook)
            {
                options.Add(Options.EditBook);
            }
            if (user.CanEditUsers)
            {
                options.Add(Options.EditUsers);
            }
            if (user.CanReserveBook)
            {
                options.Add(Options.ReserveBook);
            }
            if (user.CanCheckOutBook)
            {
                options.Add(Options.CheckOutBook);
            }
            if (user.CanRegisterUsers)
            {
                options.Add(Options.RegisterUser);
            }
            if (user.CanRenewBook)
            {
                options.Add(Options.RenewBook);
            }
            if (user.CanReturnBook)
            {
                options.Add(Options.ReturnBook);
            }
            if (user.CanSearchTheCatalogue)
            {
                options.Add(Options.SearchInCatalog);
            }
            if (user.LoggOut)
            {
                options.Add(Options.LogOut);
            }

            options.Add(Options.Quit);

            var option = this.MultipleChoice( title: "Home: ", options);
            return option;
        }
    }
}