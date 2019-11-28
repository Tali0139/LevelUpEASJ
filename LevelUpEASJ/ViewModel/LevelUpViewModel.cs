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
    class LevelUpViewModel : INotifyPropertyChanged
    {
        private ClientCatalogSingleton clientSingleton;
        private ObservableCollection<Client> _clients;
        private TrainerCatalogSingleton trainerSingleton;
        private ObservableCollection<Trainer> _trainers;
        private Client _selectedClient;
        private Trainer _selectedTrainer;
        private int id;
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private double weight;
        private int height;
        private double fatPercent;
        private string gender;
        private int totalXp;
        private int level;
        private int yearsOfExperience;
        private int age;
        private bool _exist = false;
        private int waistSize;
        private double armSize;




        public LevelUpViewModel()
        {

            clientSingleton = ClientCatalogSingleton.ClientInstance;
            trainerSingleton = TrainerCatalogSingleton.TrainerInstance;
            _trainers = new ObservableCollection<Trainer>();
            _clients = new ObservableCollection<Client>();
            _selectedClient = new Client(0, "", "", "", "", 0, 0, 0, 0.0, "", 0, 0.0);
            _selectedTrainer = new Trainer(0, "", "", "", "", 0);
            CheckCommand = new RelayCommand(DoesUserExist);

        }

        public ObservableCollection<Client> all_Clients
        {
            get
            {
                _clients = new ObservableCollection<Client>(clientSingleton.Clients);
               return _clients;
            }
        }

        public ObservableCollection<Trainer> all_Trainers
        {
            get
            {
                _trainers = new ObservableCollection<Trainer>(trainerSingleton.Trainers);
                return _trainers;
            }
        }


        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CheckCommand { get; set; }

        public bool Exist
        {
            get { return _exist; }
            set { _exist = value; }
        }

        public void DoesUserExist()
        {
            //User myUser = new User(id, firstName, lastName, userName, password);
            //  Client myClient = new Client(id, firstName, lastName, userName, password, weight, height, fatPercent, gender, waistSize, armSize);
            //Trainer myTrainer = new Trainer(id, firstName, lastName, userName, password, yearsOfExperience);
            List<Client> myList = clientSingleton.ReadList().Result;

            foreach (var person in myList)
            {

                if (person.UserName == userName && person.Password == password)
                    _exist = true;
            }
        }

        private int _id;
        public int UserID
        {
            
            get
            {
                List<Client> myList = clientSingleton.ReadList().Result;
                foreach (var person in myList)
                {
                    _id = person.UserID;
                }
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

        public int WaistSize
        {
            get { return waistSize; }
            set { waistSize = value; }
        }

        public double ArmSize
        {
            get { return armSize; }
            set { armSize = value; }
        }

        public int ClientCount
        {
            get { return clientSingleton.Count; }
        }

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; OnPropertyChanged(); }
        }
        

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
