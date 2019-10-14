using System;

namespace LibrarySystem
{
    public interface IBookRegistry
    {
        IBookItem BookItem { get; set; }
        DateTime Date { get; set; }
        IAccount User { get; set; }
    }
}