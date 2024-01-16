using System;
using System.Collections.Generic;
using projetApi.Models;
using projetApi.Services;

public class AddressController
{
    private readonly AddressService _addressService;

    public AddressController(AddressService addressService)
    {
        _addressService = addressService ?? throw new ArgumentNullException(nameof(addressService));
    }

    public IEnumerable<Address> GetAddresses()
    {
        var addresses = _addressService.GetAllAddresses();
        return addresses;
    }

    public Address GetAddressById(int id)
    {
        var address = _addressService.GetAddressById(id);

        if (address == null)
        {
            return null;
        }

        return address;
    }

    public Address CreateAddress(Address address)
    {
        _addressService.CreateAddress(address);
        return address;
    }

    public bool UpdateAddress(int id, Address address)
    {
        if (id != address.AddressId)
        {
            return false;
        }

        _addressService.UpdateAddress(address);
        return true;
    }

    public bool DeleteAddress(int id)
    {
        var existingAddress = _addressService.GetAddressById(id);

        if (existingAddress == null)
        {
            return false;
        }

        _addressService.DeleteAddress(id);
        return true;
    }
}

