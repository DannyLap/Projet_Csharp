// AddressViewModel.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using projetApi.Models;
using projetApi.Services;

namespace projetApi.ViewModels
{
    public class AddressViewModel : INotifyPropertyChanged
    {
        private readonly AddressService _addressService;

        public AddressViewModel(AddressService addressService)
        {
            _addressService = addressService;
            LoadAddresses();
        }

        private ObservableCollection<Address> _addresses;

        public ObservableCollection<Address> Addresses
        {
            get { return _addresses; }
            set
            {
                _addresses = value;
                OnPropertyChanged();
            }
        }

        private void LoadAddresses()
        {
            Addresses = new ObservableCollection<Address>(_addressService.GetAddress());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}