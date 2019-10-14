using LibrarySystem.Services.Contracts.Catalog;
using LibrarySystem.Services.Contracts.System;

namespace LibrarySystem.Services.Contracts.LibraryService
{
    public interface ILibraryService : IBooksHolder, IBooksLender, IRacksHolder
    {
        ICatalogService CatalogService { get; }
        ISystemService SystemService { get; }
    }
}