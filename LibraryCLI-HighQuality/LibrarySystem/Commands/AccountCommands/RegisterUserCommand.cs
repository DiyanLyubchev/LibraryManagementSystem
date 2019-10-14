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

            var option = this.MultipleChoice( title: $"Register Username {registerUserName}", new List<string>
            {
               "Register new Member",
               "Register new Librarian",
               "Back"
            });

            switch (option)
            {
                case "Register new Member":
                    var newUsernameMember = commandArgs.UsersService.CreateAccount(registerUserName, AccountType.Member);
                    commandArgs.UsersService.Accounts.Add(newUsernameMember);
                    break;

                case "Register new Librarian":
                    var newUsernameLibrarian = commandArgs.UsersService.CreateAccount(registerUserName, AccountType.Librarian);
                    commandArgs.UsersService.Accounts.Add(newUsernameLibrarian);
                    break;

                case "Back":
                    Console.WriteLine("Returning to home menu...");
                    Console.ReadKey();
                    return Options.HomeMenu;
            }

            Console.WriteLine($"Member with name {registerUserName} was create");

            return Options.HomeMenu;
        }
    }
}