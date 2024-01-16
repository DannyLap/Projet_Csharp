using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class CartController
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService ?? throw new ArgumentNullException(nameof(cartService));
    }

    public IEnumerable<Cart> GetCarts()
    {
        var carts = _cartService.GetAllCarts();
        return carts;
    }

    public Cart GetCartById(int id)
    {
        var cart = _cartService.GetCartById(id);

        if (cart == null)
        {
            return null;
        }

        return cart;
    }

    public Cart CreateCart(Cart cart)
    {
        _cartService.CreateCart(cart);
        return cart;
    }

    public bool UpdateCart(int id, Cart cart)
    {
        if (id != cart.CartId)
        {
            return false;
        }

        _cartService.UpdateCart(cart);
        return true;
    }

    public bool DeleteCart(int id)
    {
        var existingCart = _cartService.GetCartById(id);

        if (existingCart == null)
        {
            return false;
        }

        _cartService.DeleteCart(id);
        return true;
    }
}

