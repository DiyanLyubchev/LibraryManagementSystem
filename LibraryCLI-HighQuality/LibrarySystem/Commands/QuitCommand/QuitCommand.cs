using System;

namespace LibrarySystem
{
    public class QuitCommand : Command
    {
        public override Options MenuOption => Options.Quit;

        public override Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
            return Options.Exited;
        }
    }
}