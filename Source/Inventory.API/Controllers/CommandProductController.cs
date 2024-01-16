using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class CommandProductController
{
    private readonly CommandProductService _commandProductService;

    public CommandProductController(CommandProductService commandProductService)
    {
        _commandProductService = commandProductService ?? throw new ArgumentNullException(nameof(commandProductService));
    }

    public IEnumerable<CommandProduct> GetCommandProducts()
    {
        var commandProducts = _commandProductService.GetAllCommandProducts();
        return commandProducts;
    }

    public CommandProduct GetCommandProductById(int id)
    {
        var commandProduct = _commandProductService.GetCommandProductById(id);

        if (commandProduct == null)
        {
            return null;
        }

        return commandProduct;
    }

    public CommandProduct CreateCommandProduct(CommandProduct commandProduct)
    {
        _commandProductService.CreateCommandProduct(commandProduct);
        return commandProduct;
    }

    public bool UpdateCommandProduct(int id, CommandProduct commandProduct)
    {
        if (id != commandProduct.CommandId)
        {
            return false;
        }

        _commandProductService.UpdateCommandProduct(commandProduct);
        return true;
    }

    public bool DeleteCommandProduct(int id)
    {
        var existingCommandProduct = _commandProductService.GetCommandProductById(id);

        if (existingCommandProduct == null)
        {
            return false;
        }

        _commandProductService.DeleteCommandProduct(id);
        return true;
    }
}

