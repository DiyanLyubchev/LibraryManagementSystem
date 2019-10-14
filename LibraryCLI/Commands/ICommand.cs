using System;
using System.Collections.Generic;
using System.Text;


namespace VenneslaLibraryTeamWork
{
    public interface  ICommand 
    {
        Options Execute(ICommandArgs commandArgs);
    }
}
