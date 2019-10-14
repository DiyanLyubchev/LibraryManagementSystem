using LibrarySystem.Models;
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
                Options.Login,
                Options.Register,
                Options.Quit
            });
            string username;
            string password;
            switch (option)
            {
                case Options.Login:
                    Console.WriteLine("Enter your username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter your passowrd:");
                    password = Console.ReadLine();
                    if (!commandArgs.UsersService.Login(username, password))
                    {
                        Console.WriteLine("Wrong username!");
                        Console.ReadKey();
                        return Options.LoginMenu;
                    }

                    return Options.HomeMenu;

                case Options.Register:
                    Console.WriteLine("Enter your username:");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    password = Console.ReadLine();
                    commandArgs.UsersService.CreateAccount(username, password, AccountType.Member);
                    commandArgs.UsersService.Login(username, password);
                    return Options.HomeMenu;
            }

            return option;
        }
    }
}