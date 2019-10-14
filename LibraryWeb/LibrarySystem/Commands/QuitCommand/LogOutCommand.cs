namespace LibrarySystem
{
    public class LogOutCommand : Command // Liskov Substitution Principle
    {
        public override Options MenuOption => Options.LogOut;

        public override Options Execute(ICommandArgs commandArgs)
        {
            return Options.LoginMenu;
        }
    }
}