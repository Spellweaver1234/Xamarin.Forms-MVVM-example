using MvvmApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmApp.ViewModels
{
    public class FriendsListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FriendViewModel> Friends { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CreateFriendCommand { protected set; get; }
        public ICommand DeleteFriendCommand { protected set; get; }
        public ICommand SaveFriendCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        // для выбранного элемента из списка
        FriendViewModel selectedFriend;

        public INavigation Navigation { get; set; }

        public FriendsListViewModel()
        {
            //инициализация команд и коллекции 
            Friends = new ObservableCollection<FriendViewModel>();
            CreateFriendCommand = new Command(CreateFriend);
            DeleteFriendCommand = new Command(DeleteFriend);
            SaveFriendCommand = new Command(SaveFriend);
            BackCommand = new Command(Back);
        }

        //свойство выбора элемента из списка
        public FriendViewModel SelectedFriend
        {
            get { return selectedFriend; }
            set
            {
                if (selectedFriend != value)
                {
                    //зануляем выбранный элемент, оповещаем об этом и вызываем новую страницу с данными о выбранном элементе
                    FriendViewModel tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        //обработка метода создания элемента
        private void CreateFriend()
        {
            //переход на новую страницу
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }
        private void Back()
        {
            //навигаци кнопки Назад
            Navigation.PopAsync();
        }
        private void SaveFriend(object friendObject)
        {
            //проверка на наличие объекта
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null &&
                friend.IsValid)
            {
                //добавление в коллекцию объекта
                Friends.Add(friend);
            }
            //вызов Назад
            Back();
        }
        private void DeleteFriend(object friendObject)
        {
            //проверка на наличие объекта
            FriendViewModel friend = friendObject as FriendViewModel;
            if (friend != null)
            {//удаление объекта
                Friends.Remove(friend);
            }
            //вызов Назад
            Back();
        }
    }
}
