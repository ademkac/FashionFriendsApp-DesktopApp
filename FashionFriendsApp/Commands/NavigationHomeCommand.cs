using FashionFriendsApp.MVVM.ViewModel;
using FashionFriendsApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFriendsApp.Commands
{
    public class NavigationHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigationHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
    }
}
