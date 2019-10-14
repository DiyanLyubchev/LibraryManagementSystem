using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class EditUsersCommand : ICommand
    {
        public Options Execute(ICommandArgs commandArgs)
        {

            Console.WriteLine("Enter Username");
            var userName = Console.ReadLine();

            var user = commandArgs.Users.Accounts.Find(u => u.UserName == userName);

            var option = commandArgs.MultipleChoice(title: $"Edit user {user}", new List<Options>
            {
                Options.EditUser_ChangeUsername,
                Options.EditUser_ChangeUserType,
                Options.Quit
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
            }

            return Options.HomeMenu;

        }
    }
}
