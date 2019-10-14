namespace LibrarySystem
{
    public class Engine : IEngine
    {
        private ICommandProcessor commandProcessor;
        private IDatabase database;

        public Engine(ICommandProcessor commandProcessor, IDatabase database)
        {
            this.commandProcessor = commandProcessor;
            this.database = database;
        }

        public void Start()
        {
            var library = this.database.LoadLibrary();
            var users = this.database.LoadUserAccounts();

            var currentOption = Options.LoginMenu;
            while (true)
            {
                currentOption = this.commandProcessor.ProcessMethod(currentOption, library, users);
            }
        }
    }
}