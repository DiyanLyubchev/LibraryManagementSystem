using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    class LoginMenuCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            var option = commandArgs.MultipleChoice(title: "Login to System:", options: new List<Options>
            {
                Options.LoginMenu_Login,
                Options.LoginMenu_Register,
                Options.Quit
            });
            string username;
            switch (option)
            {
                case Options.LoginMenu_Login:
                    Console.WriteLine("Enter your username:");
                    username = Console.ReadLine();
                    if (!commandArgs.Users.Login(username))
                    {
                        Console.WriteLine("Wrong username!");
                        Console.ReadKey();
                        return Options.LoginMenu;
                    }

                    return Options.HomeMenu;
                case Options.LoginMenu_Register:
                    Console.WriteLine("Enter your username");
                    username = Console.ReadLine();
                    commandArgs.Users.CreateAccount(username, AccountType.Member);
                    commandArgs.Users.Login(username);
                    return Options.HomeMenu;
            }

            return option;
        }

    }
}
