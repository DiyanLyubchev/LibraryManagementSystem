using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class HomeMenuCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            var user = commandArgs.Users.CurrentAccount;
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

            options.Add(Options.Quit);

            var option = commandArgs.MultipleChoice(title: "Home: ", options);
            return option;

        }
    }
}
