using FashionFriendsApp.MVVM.ViewModel;
using FashionFriendsApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFriendsApp.Commands
{
    public class NavigationRegisterCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigationRegisterCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new RegisterViewModel(_navigationStore);
        }
    }
}
