using FashionFriendsApp.Commands;
using FashionFriendsApp.Core;
using FashionFriendsApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FashionFriendsApp.MVVM.ViewModel
{
    public class RegisterViewModel : ObservableObject
    {
        public ICommand NavigationLoginCommand { get; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            NavigationLoginCommand = new NavigationLoginCommand(navigationStore);
        }
    }
}
