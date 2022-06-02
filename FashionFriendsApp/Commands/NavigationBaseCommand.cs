using FashionFriendsApp.MVVM.ViewModel;
using FashionFriendsApp.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionFriendsApp.Commands
{
    public class NavigationBaseCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigationBaseCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new BaseViewModel(_navigationStore);
        }
    }
}
