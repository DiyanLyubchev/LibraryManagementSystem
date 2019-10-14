using System.Collections.Generic;

namespace LibrarySystem.Models.Contracts.Library
{
    public interface ILibrary
    {
        string Name { get; set; }
        string Address { get; set; }

    }
}