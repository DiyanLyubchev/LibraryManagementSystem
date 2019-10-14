using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem
{
    public class EditUsersCommand : Command   //polymorphism
    {
        public override Options MenuOption => Options.EditUsers;

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Enter Username");
            var userName = Console.ReadLine();

            var user = commandArgs.UsersService.Accounts.SingleOrDefault(u => u.UserName == userName);

            var option = this.MultipleChoice( title: $"Edit user {user}", new List<Options>
            {
                Options.EditUser_ChangeUsername,
                Options.EditUser_ChangeUserType,
                Options.Back
            });

            switch (option)
            {
                case Options.EditUser_ChangeUsername:
                    Console.WriteLine("Enter new Username");
                    var newUserName = Console.ReadLine();
                    user.UserName = newUserName;
                    break;

                case Options.EditUser_ChangeUserType:
                    Console.WriteLine("Enter new userType");
                    var newUserType = Console.ReadLine();
                    user.Type = (AccountType)Enum.Parse(typeof(AccountType), newUserType);
                    break;

                case Options.Back:
                    Console.WriteLine("Returning to home menu...");
                    Console.ReadKey();
                    return Options.HomeMenu;
            }

            return Options.HomeMenu;
        }
    }
}