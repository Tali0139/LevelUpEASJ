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
        private UserCatalogSingleton singleton;
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
        private bool _exist = false;


        public UserViewModel()
        {

            singleton = UserCatalogSingleton.Instance;
            _users = new ObservableCollection<User>();
            _trainers = new ObservableCollection<Trainer>();
            _clients = new ObservableCollection<Client>();
            _selectedUser = new User();
            CheckCommand = new RelayCommand(DoesUserExist);



            //AddCommand = new RelayCommand(toAddNewUser);
            //DeleteCommand = new RelayCommand(toDeleteUser);
            //UpdateCommand = new RelayCommand(toUpdateUser);
        }


        //public ObservableCollection<User> all_Users
        //{
        //    get
        //    {
        //        _users = new ObservableCollection<User>(singleton.Users);
        //        return _users;
        //    }
        //}

        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CheckCommand { get; set; }

        public bool Exist
        {
            get { return _exist;}
            set { _exist = value; }
        }

        public void DoesUserExist()
        {
            //User myUser = new User(id, firstName, lastName, userName, password);
            //Client myClient = new Client(id, firstName, lastName, userName, password, weight, height, fatPercent, gender, totalXp, level);
            //Trainer myTrainer = new Trainer(id, firstName, lastName, userName, password, yearsOfExperience);
            List<User> myList = singleton.Load().Result;
           
            
            foreach (var User in myList)
            {

                if (User.UserName == userName && User.Password == password)
                    _exist = true;               
            }


            
            //bool check = singleton
            

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

        //public int UserCount
        //{
        //    get { return singleton.Users.Count; }
        //}

        //public User SelectedUser
        //{
        //    get { return _selectedUser; }
        //    set { _selectedUser = value; OnPropertyChanged(); }
        //}


        //public void toAddNewUser()
        //{
        //    User NewUser = new User(_id, _firstName, _lastName, _userName, _password);
        //    singleton.addUser(NewUser);
        //    OnPropertyChanged(nameof(all_Users));
        //    OnPropertyChanged(nameof(UserCount));
        //}

        //public void toDeleteUser()
        //{
        //    singleton.deleteUser(SelectedUser);
        //    OnPropertyChanged(nameof(all_Users));
        //    OnPropertyChanged(nameof(UserCount));
        //}


        //public void toUpdateUser()
        //{
        //    singleton.updateUser(SelectedUser);
        //    OnPropertyChanged(nameof(all_Users));
        //    OnPropertyChanged(nameof(UserCount));
        //}






































        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
