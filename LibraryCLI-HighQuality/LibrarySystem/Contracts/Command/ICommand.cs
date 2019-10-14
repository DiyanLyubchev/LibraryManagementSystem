namespace LibrarySystem
{
    public interface ICommand
    {
        Options MenuOption { get; }

        Options Execute(ICommandArgs commandArgs);
    }
}