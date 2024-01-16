// AddressService.cs
using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Repositories;

namespace projetApi.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
        }

        public IEnumerable<Address> GetAllAddresses()
        {
            return _addressRepository.GetAllAddresses();
        }

        public Address GetAddressById(int id)
        {
            return _addressRepository.GetAddressById(id);
        }

        public void CreateAddress(Address address)
        {
            _addressRepository.CreateAddress(address);
        }

        public void UpdateAddress(Address address)
        {
            _addressRepository.UpdateAddress(address);
        }

        public void DeleteAddress(int id)
        {
            _addressRepository.DeleteAddress(id);
        }
    }
}
