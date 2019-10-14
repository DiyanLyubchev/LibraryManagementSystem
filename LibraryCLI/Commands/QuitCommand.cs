using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public class QuitCommand : ICommand 
    {
        public Options Execute(ICommandArgs commandArgs)
        {
            Console.WriteLine("Exiting...");

            return Options.Exited;
        }
    }
}
