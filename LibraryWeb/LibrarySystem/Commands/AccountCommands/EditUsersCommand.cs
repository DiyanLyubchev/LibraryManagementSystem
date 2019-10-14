using LibrarySystem.Models;
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

            var user = commandArgs.LibrarySystemContext.AccountsOldData.SingleOrDefault(u => u.UserName == userName);

            var option = this.MultipleChoice( title: $"Edit user {user}", new List<Options>
            {
                Options.EditUsername,
                Options.EditUserType,
                Options.Quit
            });

            switch (option)
            {
                case Options.EditUsername:
                    Console.WriteLine("Enter new Username");
                    var newUserName = Console.ReadLine();
                    user.UserName = newUserName;
                    break;

                case Options.EditUserType:
                    Console.WriteLine("Enter new userType");
                    var newUserType = Console.ReadLine();
                    user.Type = (AccountType)Enum.Parse(typeof(AccountType), newUserType);
                    break;
            }

            return Options.HomeMenu;
        }
    }
}