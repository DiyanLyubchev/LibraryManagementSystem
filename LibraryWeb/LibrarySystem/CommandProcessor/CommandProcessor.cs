using LibrarySystem.Services.Contracts.Accounts;
using LibrarySystem.Services.Contracts.LibraryService;
using System.Collections.Generic;

namespace LibrarySystem
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IDictionary<Options, ICommand> commands = new Dictionary<Options, ICommand>();
        private readonly ICommandArgs commandArgs;

        public CommandProcessor(IEnumerable<ICommand> commands, ICommandArgs commandArgs)
        {
            foreach (var command in commands)
            {
                this.commands.Add(command.MenuOption, command);
            }

            this.commandArgs = commandArgs;
        }

        public Options ProcessMethod(Options currentOption, ILibraryService library, IAccountService users)
        {
            this.commandArgs.LibraryService = library;
            this.commandArgs.UsersService = users;
            return this.commands[currentOption].Execute(this.commandArgs);
        }
    }
}