using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    class RegisterUserCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Write Username which you want to Register:");
            var registerUserName = Console.ReadLine();
            var user = new Users();

            var option = commandArgs.MultipleChoice(title: $"Register Username {registerUserName}", new List<string>
            {
               "Register new Member",
               "Register new Librarian"
            });

            switch (option)
            {
                case "Register new Member":
                    var newUsernameMember = commandArgs.Users.CreateAccount(registerUserName, AccountType.Member);
                    user.Accounts.Add(newUsernameMember);
                    break;

                case "Register new Librarian":
                    var newUsernameLibrarian = commandArgs.Users.CreateAccount(registerUserName, AccountType.Librarian);
                    user.Accounts.Add(newUsernameLibrarian);
                    break;

            }

            Console.WriteLine($"Member with name {registerUserName} was create");

            return Options.HomeMenu;
        }
    }
}
