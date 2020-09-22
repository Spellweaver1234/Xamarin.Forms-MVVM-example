using MvvmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MvvmApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FriendPage : ContentPage
    {
        public FriendViewModel ViewModel { get; private set; }
        public FriendPage(FriendViewModel vm)
        {//инициализация, сохранение вьюмодели и привязка её
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}