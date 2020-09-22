using MvvmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendsListPage : ContentPage
    {
        public FriendsListPage()
        {//инициализация и привязка контекста, передача навигации
            InitializeComponent();
            BindingContext = new FriendsListViewModel() { Navigation = this.Navigation };
        }
    }
}