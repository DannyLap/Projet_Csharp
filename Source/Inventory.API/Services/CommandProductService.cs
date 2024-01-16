// CommandProductService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class CommandProductService
    {
        private readonly CommandProductRepository _commandProductRepository;

        public CommandProductService(CommandProductRepository commandProductRepository)
        {
            _commandProductRepository = commandProductRepository ?? throw new ArgumentNullException(nameof(commandProductRepository));
        }

        public IEnumerable<CommandProduct> GetAllCommandProducts()
        {
            return _commandProductRepository.GetAllCommandProducts();
        }

        public CommandProduct GetCommandProductById(int id)
        {
            return _commandProductRepository.GetCommandProductById(id);
        }

        public void CreateCommandProduct(CommandProduct commandProduct)
        {
            _commandProductRepository.CreateCommandProduct(commandProduct);
        }

        public void UpdateCommandProduct(CommandProduct commandProduct)
        {
            _commandProductRepository.UpdateCommandProduct(commandProduct);
        }

        public void DeleteCommandProduct(int id)
        {
            _commandProductRepository.DeleteCommandProduct(id);
        }
    }
}