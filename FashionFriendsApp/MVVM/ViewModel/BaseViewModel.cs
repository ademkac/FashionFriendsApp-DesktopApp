using FashionFriendsApp.Core;
using FashionFriendsApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFriendsApp.MVVM.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        public BaseViewModel( NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
