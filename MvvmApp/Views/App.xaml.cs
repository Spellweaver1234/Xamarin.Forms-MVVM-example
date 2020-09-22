using MvvmApp.Views;
using Xamarin.Forms;

namespace MvvmApp
{
    public partial class App : Application
    {
        public App()
        {
            //установка стартовой страницы 
            MainPage = new NavigationPage(new FriendsListPage());
        }

        protected override void OnStart()
        { }

        protected override void OnSleep()
        { }

        protected override void OnResume()
        { }
    }
}
