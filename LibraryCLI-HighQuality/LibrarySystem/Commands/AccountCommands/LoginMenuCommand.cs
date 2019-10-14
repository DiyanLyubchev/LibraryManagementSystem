using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class LoginMenuCommand : Command   //polymorphism
    {
        public override Options MenuOption => Options.LoginMenu;

        public override Options Execute(ICommandArgs commandArgs)
        {
            var option = this.MultipleChoice( title: "Login to System:", options: new List<Options>
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
                    if (!commandArgs.UsersService.Login(username))
                    {
                        Console.WriteLine("Wrong username!");
                        Console.ReadKey();
                        return Options.LoginMenu;
                    }

                    return Options.HomeMenu;

                case Options.LoginMenu_Register:
                    Console.WriteLine("Enter your username");
                    username = Console.ReadLine();
                    commandArgs.UsersService.CreateAccount(username, AccountType.Member);
                    commandArgs.UsersService.Login(username);
                    return Options.HomeMenu;
            }

            return option;
        }
    }
}