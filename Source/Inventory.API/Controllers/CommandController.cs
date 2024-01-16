using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class CommandController
{
    private readonly CommandService _commandService;

    public CommandController(CommandService commandService)
    {
        _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
    }

    public IEnumerable<Command> GetCommands()
    {
        var commands = _commandService.GetAllCommands();
        return commands;
    }

    public Command GetCommandById(int id)
    {
        var command = _commandService.GetCommandById(id);

        if (command == null)
        {
            return null;
        }

        return command;
    }

    public Command CreateCommand(Command command)
    {
        _commandService.CreateCommand(command);
        return command;
    }

    public bool UpdateCommand(int id, Command command)
    {
        if (id != command.CommandId)
        {
            return false;
        }

        _commandService.UpdateCommand(command);
        return true;
    }

    public bool DeleteCommand(int id)
    {
        var existingCommand = _commandService.GetCommandById(id);

        if (existingCommand == null)
        {
            return false;
        }

        _commandService.DeleteCommand(id);
        return true;
    }
}
