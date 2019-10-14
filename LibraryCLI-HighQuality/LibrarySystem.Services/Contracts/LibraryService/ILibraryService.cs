using System.Collections.Generic;

namespace LibrarySystem
{
    public interface ILibraryService : IBooksHolder , IBooksLender , IRacksHolder
    {
        ISet<IBook> Books { get; }
        ICatalogService CatalogService { get; }
        ISystemService SystemService { get; }
    }
}