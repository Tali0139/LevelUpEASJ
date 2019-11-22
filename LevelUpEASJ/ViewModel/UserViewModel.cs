using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Annotations;
using LevelUpEASJ.Commands;
using LevelUpEASJ.Model;

namespace LevelUpEASJ.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private UserCatalogSingleton _singleton;
        private ObservableCollection<User> _users;
        private ObservableCollection<Client> _clients;
        private ObservableCollection<Trainer> _trainers;
        private User _selectedUser;
        private int id;
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private int weight;
        private int height;
        private double fatPercent;
        private string gender;
        private int totalXp;
        private int level;
        private int yearsOfExperience;
        

        public UserViewModel()
        {
            
            _singleton = UserCatalogSingleton.Instance;
            _users = new ObservableCollection<User>();
            _trainers = new ObservableCollection<Trainer>();
            _clients = new ObservableCollection<Client>();
            _selectedUser = new User();
            

            AddCommand = new RelayCommand(toAddNewUser);
            DeleteCommand = new RelayCommand(toDeleteUser);
            UpdateCommand = new RelayCommand(toUpdateUser);
        }


        public ObservableCollection<User> all_Users
        {
            get
            {
                _users = new ObservableCollection<User>(singleton.Users);
                return _users;
            }
        }


        public ObservableCollection<Client> all_Clients
        {
            get
            {
                _clients = new ObservableCollection<Client>(singleton.users);
                return _clients;
            }

        }

        public ObservableCollection<Trainer> all_Trainers
        {
            get
            {
                _trainers = new ObservableCollection<Trainer>(singleton.trainers);
                return _trainers;
            }

        }



        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        public bool DoesUserExist(string username, string password)
        {
            User myUser = new User(id, firstName, lastName, username, password);
            Client myClient = new Client(id, firstName, lastName, username, password, weight, height, fatPercent, gender, totalXp, level);
            Trainer myTrainer = new Trainer(id, firstName, lastName, username, password, yearsOfExperience);


            bool check = singleton.CheckLogin(myUser);

            return check;

        }

        private int _id;
        public int UserID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }


        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public int UserCount
        {
            get { return singleton.Users.Count; }           
        }

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; OnPropertyChanged(); }
        }


        public void toAddNewUser()
        {
            User NewUser = new User(_id, _firstName, _lastName, _userName, _password);
            singleton.addUser(NewUser);
            OnPropertyChanged(nameof(all_Users));
            OnPropertyChanged(nameof(UserCount));
        }

        public void toDeleteUser()
        {
            singleton.deleteUser(SelectedUser);
            OnPropertyChanged(nameof(all_Users));
            OnPropertyChanged(nameof(UserCount));
        }


        public void toUpdateUser()
        {
            singleton.updateUser(SelectedUser);
            OnPropertyChanged(nameof(all_Users));
            OnPropertyChanged(nameof(UserCount));
        }

      




































        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
