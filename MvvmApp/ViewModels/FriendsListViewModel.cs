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
        public ICommand CreateFriendCommand { get; set; }
        public ICommand DeleteFriendCommand { get; set; }
        public ICommand SaveFriendCommand { get; set; }
        public ICommand BackCommand { get; set; }

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

        //обработка метода создания элемента
        private void CreateFriend()
        {
            Navigation.PushAsync(new FriendPage(new FriendViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            //навигаци кнопки Назад
            Navigation.PopAsync();
        }

        private void SaveFriend(object friendObject)
        {
            var item = ((FriendViewModel)friendObject);
            //проверка на наличие объекта
            if (item.IsValid())
            {
                if (Friends.Contains(item))
                    Friends.Remove(item);

                //добавление в коллекцию объекта
                Friends.Add(item);
            }

            //вызов Назад
            Back();
        }

        private void DeleteFriend(object friendObject)
        {
                //удаление объекта
                Friends.Remove((FriendViewModel)friendObject);

            //вызов Назад
            Back();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        //свойство выбора элемента из списка
        public FriendViewModel SelectedFriend
        {
            get => selectedFriend;
            set
            {
                if (selectedFriend != value)
                {
                    //зануляем выбранный элемент, оповещаем об этом и вызываем новую страницу с данными о выбранном элементе
                    var tempFriend = value;
                    selectedFriend = null;
                    OnPropertyChanged("SelectedFriend");
                    Navigation.PushAsync(new FriendPage(tempFriend));
                }
            }
        }
    }
}
