using System.Collections.Generic;

namespace VenneslaLibraryTeamWork
{
    public interface ICommandArgs
    {
        ILibrary Library { get; set; }
        Book SelectedBook { get; set; }
        Users Users { get; set; }
        T MultipleChoice<T>(string title, List<T> options);
    }
}