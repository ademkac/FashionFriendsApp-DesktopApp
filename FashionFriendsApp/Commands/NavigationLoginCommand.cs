using FashionFriendsApp.MVVM.ViewModel;
using FashionFriendsApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFriendsApp.Commands
{
    public class NavigationLoginCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigationLoginCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);
        }
    }
}
