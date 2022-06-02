using FashionFriendsApp.MVVM.ViewModel;
using FashionFriendsApp.Store;
using System.Windows;

namespace FashionFriendsApp
{
   
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();

            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };

            MainWindow.Show();

            
        }
    }
}
