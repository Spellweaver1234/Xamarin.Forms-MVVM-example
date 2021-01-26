using MvvmApp.Models;
using System.ComponentModel;

namespace MvvmApp.ViewModels
{
    public class FriendViewModel : INotifyPropertyChanged
    {
        public Friend Friend;
        public FriendsListViewModel friendsListViewModel;

        public FriendViewModel()
        {
            Friend = new Friend();
        }

        public FriendsListViewModel ListViewModel
        {
            //свойство получения/изменения и оповещения 
            get => friendsListViewModel;
            set
            {
                if (friendsListViewModel != value)
                {
                    friendsListViewModel = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            //свойство получения/изменения и оповещения 
            get => Friend.Name;
            set
            {
                if (Friend.Name != value)
                {
                    Friend.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Email
        {
            //свойство получения/изменения и оповещения 
            get => Friend.Email;
            set
            {
                if (Friend.Email != value)
                {
                    Friend.Email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Phone
        {
            get => Friend.Phone;
            set
            {
                if (Friend.Phone != value)
                {
                    Friend.Phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }

        //проверка на валидность
        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(Name.Trim())) ||
                (!string.IsNullOrEmpty(Phone.Trim())) ||
                (!string.IsNullOrEmpty(Email.Trim()));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}