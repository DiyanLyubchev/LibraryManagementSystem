using LibrarySystem.Models;
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class RegisterUserCommand : Command   //polymorphism
    {
        public override Options MenuOption => Options.RegisterUser;

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Write Username which you want to Register:");
            var registerUserName = Console.ReadLine();
            Console.WriteLine("Enter a password:");
            var password = Console.ReadLine();

            var option = this.MultipleChoice( title: $"Register Username {registerUserName}", new List<string>
            {
               "Register new Member",
               "Register new Librarian"
            });

            switch (option)
            {
                case "Register new Member":
                    commandArgs.UsersService.CreateAccount(registerUserName, password, AccountType.Member);
                    break;

                case "Register new Librarian":
                    commandArgs.UsersService.CreateAccount(registerUserName, password, AccountType.Librarian);
                    break;
            }

            Console.WriteLine($"User with name {registerUserName} was create");
            Console.ReadKey();
            return Options.HomeMenu;
        }
    }
}