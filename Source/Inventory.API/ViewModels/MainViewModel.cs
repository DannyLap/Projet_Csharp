// MainViewModel.cs
using System.Collections.ObjectModel;
using projetApi.Models;
using projetApi.Services;
using projetApi.Repositories;

namespace projetApi.ViewModels
{
    public class MainViewModel
    {
        public UserViewModel Users { get; }
        public AddressViewModel Addresses { get; }
        public ProductViewModel Products { get; }

        public MainViewModel()
        {
            var userService = new UserService(new UserRepository());
            var addressService = new AddressService(new AddressRepository());
            var productService = new ProductService(new ProductRepository());

            Users = new UserViewModel(userService);
            Addresses = new AddressViewModel(addressService);
            Products = new ProductViewModel(productService);
        }
    }
}