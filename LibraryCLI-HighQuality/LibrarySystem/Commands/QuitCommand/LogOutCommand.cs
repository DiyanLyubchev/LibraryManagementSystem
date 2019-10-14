namespace LibrarySystem
{
    public class LogOutCommand : Command
    {
        public override Options MenuOption => Options.LogOut;

        public override Options Execute(ICommandArgs commandArgs)
        {
            return Options.LoginMenu;
        }
    }
}