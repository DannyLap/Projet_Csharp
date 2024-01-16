// CommandService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class CommandService
    {
        private readonly CommandRepository _commandRepository;

        public CommandService(CommandRepository commandRepository)
        {
            _commandRepository = commandRepository ?? throw new ArgumentNullException(nameof(commandRepository));
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commandRepository.GetAllCommands();
        }

        public Command GetCommandById(int id)
        {
            return _commandRepository.GetCommandById(id);
        }

        public void CreateCommand(Command command)
        {
            _commandRepository.CreateCommand(command);
        }

        public void UpdateCommand(Command command)
        {
            _commandRepository.UpdateCommand(command);
        }

        public void DeleteCommand(int id)
        {
            _commandRepository.DeleteCommand(id);
        }
    }
}
