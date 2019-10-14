using Autofac;

namespace LibrarySystem
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Engine>().As<IEngine>();
            builder.RegisterType<CommandArgs>().As<ICommandArgs>();
            builder.RegisterType<Database>().As<IDatabase>().SingleInstance();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();

            ServicesContainer.Register(builder);

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