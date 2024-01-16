// UserViewModel.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using projetApi.Models;
using projetApi.Services;

namespace projetApi.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;

        public UserViewModel(UserService userService)
        {
            _userService = userService;
            LoadUsers();
        }

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<User>(_userService.GetUsers());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}