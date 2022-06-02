using FashionFriendsApp.Commands;
using FashionFriendsApp.Core;
using FashionFriendsApp.Store;

using System.Windows.Input;

namespace FashionFriendsApp.MVVM.ViewModel
{
    public class LoginViewModel : ObservableObject
    {
        public ICommand NavigationRegisterCommand { get; }
        public ICommand NavigationBaseCommand { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            NavigationRegisterCommand = new NavigationRegisterCommand(navigationStore);
            NavigationBaseCommand = new NavigationBaseCommand(navigationStore);
        }
    }
}
