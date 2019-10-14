using Autofac;
using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Contracts.Catalog;
using LibrarySystem.Services.Contracts.Factory;
using LibrarySystem.Services.Contracts.LibraryService;
using LibrarySystem.Services.Contracts.System;
using LibrarySystem.Services.Core;
using LibrarySystem.Services.Factory;

namespace LibrarySystem
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            //System
            builder.RegisterType<Engine>().As<IEngine>();
            builder.RegisterType<CommandArgs>().As<ICommandArgs>();
            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();

            //Service
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<CatalogService>().As<ICatalogService>();
            builder.RegisterType<SystemService>().As<ISystemService>();
            builder.RegisterType<LibraryService>().As<ILibraryService>();

            //Factory
            builder.RegisterType<BookFactory>().As<IBookFactory>();
            builder.RegisterType<AccountFactory>().As<IAccountFactory>();

            //Commands
            builder.RegisterType<AddBookCommand>().As<ICommand>();
            builder.RegisterType<CheckOutBookCommand>().As<ICommand>();
            builder.RegisterType<ReserveBookCommand>().As<ICommand>();
            builder.RegisterType<EditBookCommand>().As<ICommand>();
            builder.RegisterType<EditUsersCommand>().As<ICommand>();
            builder.RegisterType<HomeMenuCommand>().As<ICommand>();
            builder.RegisterType<LoginMenuCommand>().As<ICommand>();
            builder.RegisterType<QuitCommand>().As<ICommand>();
            builder.RegisterType<RegisterUserCommand>().As<ICommand>();
            builder.RegisterType<RenewBookCommand>().As<ICommand>();
            builder.RegisterType<ReturnBookCommand>().As<ICommand>();
            builder.RegisterType<SearchInCatalogCommand>().As<ICommand>();
            builder.RegisterType<LogOutCommand>().As<ICommand>();

            return builder.Build();
        }
    }
}