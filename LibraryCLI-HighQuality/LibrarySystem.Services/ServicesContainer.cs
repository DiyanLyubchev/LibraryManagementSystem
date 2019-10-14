using Autofac;

namespace LibrarySystem
{
    public static class ServicesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<CatalogService>().As<ICatalogService>();
            builder.RegisterType<SystemService>().As<ISystemService>();
            builder.RegisterType<LibraryService>().As<ILibraryService>();
        }
    }
}
