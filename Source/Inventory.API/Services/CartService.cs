// CartService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;


namespace projetApi.Services
{
    public class CartService
    {
        private readonly CartRepository _cartRepository;

        public CartService(CartRepository cartRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _cartRepository.GetAllCarts();
        }

        public Cart GetCartById(int id)
        {
            return _cartRepository.GetCartById(id);
        }

        public void CreateCart(Cart cart)
        {
            _cartRepository.CreateCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _cartRepository.UpdateCart(cart);
        }

        public void DeleteCart(int id)
        {
            _cartRepository.DeleteCart(id);
        }
    }
}