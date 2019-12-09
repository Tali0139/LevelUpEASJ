﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.PointOfService;
using LevelUpEASJ.Annotations;
using LevelUpEASJ.Commands;
using LevelUpEASJ.Model;
using LevelUpEASJ.View;

namespace LevelUpEASJ.ViewModel
{
    public class LevelUpViewModel : INotifyPropertyChanged
    {
        public ClientCatalogSingleton clientSingleton { get; set; }
        public TrainerCatalogSingleton trainerSigleton { get; set; }
        private ObservableCollection<Client> _clients;
        private TrainerCatalogSingleton trainerSingleton;
        private ObservableCollection<Trainer> _trainers;
        private ObservableCollection<Levels> _levels;
        private Client _selectedClient;
        private Trainer _selectedTrainer;
        private Levels _selectedLevels;
        private int id;
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private double weight;
        private int height;
        private double fatPercent;
        private string gender;
        private int totalXp;
        private int minXp;
        private int maxXp;
        private int levelValue;
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
            _levels = new ObservableCollection<Levels>();
            _selectedClient = new Client(UserID, FirstName, LastName, PhoneNumber, UserName, Password, Age, Weight, Height, Fatpercent, Gender, WaistSize, ArmSize, TotalXP);
            _selectedTrainer = new Trainer(UserID, FirstName, LastName, PhoneNumber, UserName, Password, YearsOfExperience);
            _selectedLevels = new Levels(levelValue, minXp, maxXp);
            //CheckCommand = new RelayCommand(DoesUserExist);
            AddCommand = new RelayCommand(ToAddNewClient);
            _køn = new List<string>();
            _køn.Add("Mand");
            _køn.Add("Kvinde");

        }

        public ClientCatalogSingleton ClientCatalogSingleton { get; set; }
        public TrainerCatalogSingleton TrainerCatalogSingleton { get; set; }


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
        //public RelayCommand CheckCommand { get; set; }



        public bool Exist
        {
            get { return _exist; }
            set { _exist = value; }
        }

        public bool DoesUserExist(string username, string password)
        {
            List<Client> myList = clientSingleton.ReadList().Result;
            foreach (var person in myList)
            {

                if (person.UserName == username && person.Password == password)
                ClientCatalogSingleton.ClientInstance.NyClient = person;
                _exist = true;
            }

            return _exist;
        }

        public bool DoesAdminExist(string username, string password)
        {
            List<Trainer> myListOfTrainers = trainerSingleton.ReadListTrainer().Result;

            foreach (var trainer in myListOfTrainers)
            {
                if (trainer.UserName == username && trainer.Password == password)
                {
                    TrainerCatalogSingleton.TrainerInstance.NyTrainer = trainer;
                    _exist = true;
                }
            }

            return _exist;
        }

        public string ClientLevel
        {
            get
            {
                return LevelCatalogSingleton.LevelInstance.GetLevelForClient(ClientCatalogSingleton.ClientInstance.NyClient).ToString();
            }
        }

        public string ClientXPtoNextLevel
        {
            get
            {
                return LevelCatalogSingleton.LevelInstance.XpToNextLevel(ClientCatalogSingleton.ClientInstance.NyClient).ToString();
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
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        private int _phoneNumber;
        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; OnPropertyChanged(); }
        }


        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }


        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(); }
        }


        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(); }
        }


        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        private List<string> _køn;
        public List<string> Køn
        {
            get { return _køn; }
            set { _køn = value; OnPropertyChanged(); }
        }

        public double Fatpercent
        {
            get { return fatPercent; }
            set { fatPercent = value; OnPropertyChanged(); }
        }

        public int WaistSize
        {
            get { return waistSize; }
            set { waistSize = value; OnPropertyChanged(); }
        }

        public int Height
        {
            get { return height; }
            set { height = value; OnPropertyChanged(); }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged(); }
        }

        public double BMI
        {
            get
            {
                double h = ClientCatalogSingleton.ClientInstance.NyClient.Height;
                double w = ClientCatalogSingleton.ClientInstance.NyClient.Weight;
                double bmi = w / Math.Pow(h/100,2);
                return bmi;
            }
        }

        public double ArmSize
        {
            get { return armSize; }
            set { armSize = value; OnPropertyChanged(); }
        }

        public int TotalXP
        {
            get { return totalXp; }
            set { totalXp = value; OnPropertyChanged(); }
        }

        public int YearsOfExperience
        {
            get { return yearsOfExperience; }
            set { yearsOfExperience = value; OnPropertyChanged(); }
        }

        public int ClientCount
        {
            get { return all_Clients.Count; }
        }

        public int TrainerCount
        {
            get { return all_Trainers.Count; }
        }

        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; OnPropertyChanged(); }
        }

        public Trainer SelectedTrainer
        {
            get { return _selectedTrainer; }
            set { _selectedTrainer = value; OnPropertyChanged(); }
        }

        public Levels SelectedLevel
        {
            get { return _selectedLevels; }
            set { _selectedLevels = value;OnPropertyChanged(); }
        }

        public void ToAddNewClient()
        {
            Client NewClient = new Client(id, FirstName, LastName, PhoneNumber, UserName, Password, age, weight, height, fatPercent,
                gender, WaistSize, ArmSize, TotalXP);
            clientSingleton.AddClient(NewClient);
            OnPropertyChanged(nameof(all_Clients));
            OnPropertyChanged(nameof(ClientCount));
        }


        public void ToDeleteClient()
        {
            clientSingleton.DeleteClient(SelectedClient);
            OnPropertyChanged(nameof(all_Clients));
            OnPropertyChanged(nameof(ClientCount));
        }


        public async void ToUpdateClient()
        {
            await clientSingleton.UpdateClient(SelectedClient);
            OnPropertyChanged(nameof(all_Clients));
            OnPropertyChanged(nameof(ClientCount));

        }


        public void ToAddNewTrainer()
        {
            Trainer newLevels = new Trainer(id, firstName, lastName, PhoneNumber, username, Password, yearsOfExperience);
            trainerSingleton.AddTrainer(newLevels);
            OnPropertyChanged(nameof(all_Trainers));
            OnPropertyChanged(nameof(TrainerCount));
        }


        public void ToDeleteTrainer()
        {
            trainerSingleton.DeleteTrainer(SelectedTrainer);
            OnPropertyChanged(nameof(all_Trainers));
            OnPropertyChanged(nameof(TrainerCount));
        }


        public async void ToUpdateTrainer()
        {
            await trainerSingleton.UpdateTrainer(SelectedTrainer);
            OnPropertyChanged(nameof(all_Trainers));
            OnPropertyChanged(nameof(TrainerCount));

        }












        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
