// ProductViewModel.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using projetApi.Models;
using projetApi.Services;

namespace projetApi.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _productService;

        public ProductViewModel(ProductService productService)
        {
            _productService = productService;
            LoadProducts();
        }

        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private void LoadProducts()
        {
            Products = new ObservableCollection<Product>(_productService.GetProducts());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}