using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
        public TrainerCatalogSingleton trainerSingleton { get; set; }
        private ObservableCollection<Exercise> _exercises;
        public ExerciseCatalogSingleton exerciseSingleton { get; set; }
        private ObservableCollection<Client> _clients;
        private TrainerCatalogSingleton _trainerSingleton;
        private ObservableCollection<Trainer> _trainers;
        private ObservableCollection<Levels> _levels;
        private Client _selectedClient;
        private Trainer _selectedTrainer;
        private Levels _selectedLevels;
        private Exercise _selectedExercise1;
        private Exercise _selectedExercise2;
        private Exercise _selectedExercise3;
        private int id;
        private string image;
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
        private bool _trainerexist = false;
        private Exercise _exercise;




        public LevelUpViewModel()
        {

            clientSingleton = ClientCatalogSingleton.ClientInstance;
            trainerSingleton = TrainerCatalogSingleton.TrainerInstance;
            exerciseSingleton = ExerciseCatalogSingleton.ExerciseInstance;

            _exercises = new ObservableCollection<Exercise>();
            _trainers = new ObservableCollection<Trainer>();
            _clients = new ObservableCollection<Client>();
            _levels = new ObservableCollection<Levels>();
            //_selectedExercise = new Exercise(ExerciseName, XpForExercise, ExerciseId);
            _selectedClient = new Client(UserID, FirstName, LastName, PhoneNumber, UserName, Password, image, Age, Weight, Height, Fatpercent, Gender, WaistSize, ArmSize, TotalXP);
            _selectedTrainer = new Trainer(UserID, FirstName, LastName, PhoneNumber, UserName, Password, image, YearsOfExperience);
            _selectedLevels = new Levels(levelValue, minXp, maxXp);

            _selectedExercise1= new Exercise();
            _selectedExercise2= new Exercise();
            _selectedExercise3= new Exercise();

            //CheckCommand = new RelayCommand(DoesUserExist);
            AddCommand = new RelayCommand(ToAddNewClient);
            CreateGoal = new RelayCommand(ToAddNewGoal);
            _køn = new List<string>();
            _køn.Add("Mand");
            _køn.Add("Kvinde");

        }

        public ExerciseCatalogSingleton ExerciseCatalogSingleton { get; set; }
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

        public ObservableCollection<Exercise> all_Exercises
        {
            get
            {
                _exercises = new ObservableCollection<Exercise>(exerciseSingleton.Exercises);
                return _exercises;
            }
        }





        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CreateGoal { get; set; }
        //public RelayCommand CheckCommand { get; set; }



        public bool ClientExist
        {
            get { return _exist; }
            set { _exist = value; }
        }

        public bool TrainerExist
        {
            get { return _trainerexist; }
            set { _trainerexist = value; }
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
                    _trainerexist = true;
                }
            }

            return _trainerexist;
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

        //public int XPForTraining
        //{
        //    get
        //    {
        //        return ExerciseCatalogSingleton.ExerciseInstance.XPForExercise(ClientCatalogSingleton.ClientInstance.NyClient);
        //    }
        //}

        private int _cid;


        public int UserID
        {
            get
            {
                List<Client> myListOfClients = clientSingleton.ReadList().Result;
                foreach (var person in myListOfClients)
                {
                    _cid = person.UserID;
                }

                return _cid;
            }
            set
            {
                _cid = value;
                OnPropertyChanged();
            }
        }

        //private int _tid;
        //public int TrainerID
        //{
        //    get
        //    {
        //      List<Trainer> myListOfTrainers = trainerSingleton.ReadListTrainer().Result;
        //        foreach (var person in myListOfTrainers)
        //        {
        //            _tid = person.UserID;
        //        }

        //        return _tid;
        //    }
        //    set
        //    {
        //        _tid = value;
        //        OnPropertyChanged();
        //    }
        //}

        private string _exerciseName;
        public string ExerciseName
        {
            get { return _exerciseName; }
            set { _exerciseName = value; OnPropertyChanged(); }
        }

        private int _xpForExercise;
        public int XpForExercise
        {
            get { return _xpForExercise; }
            set { _xpForExercise = value; OnPropertyChanged(); }
        }

        private int _exerciseId;
        public int ExerciseId
        {
            get { return _exerciseId; }
            set { _exerciseId = value; OnPropertyChanged(); }
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

        public string Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged(); }
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

        //public double FatPercent
        //{
        //    get { return fatPercent; }
        //    set { fatPercent = value; OnPropertyChanged(); }
        //}

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
                double bmi = w / Math.Pow(h / 100, 2);
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
            set { _selectedLevels = value; OnPropertyChanged(); }
        }

        
        public Exercise SelectedExercise1
        {
            get { return _selectedExercise1; }
            set { _selectedExercise1 = value; OnPropertyChanged(); }
        }
        public Exercise SelectedExercise2
        {
            get { return _selectedExercise2; }
            set { _selectedExercise2 = value; OnPropertyChanged(); }
        }

        public Exercise SelectedExercise3
        {
            get { return _selectedExercise3; }
            set { _selectedExercise3 = value; OnPropertyChanged(); }
        }

       
        //public int TotalXpOfExercise
        //{

        //    get
        //    {
        //        int result = xp1 + xp2 + xp3;
        //        return result;
        //    }
        //}
        private int _tot;
        public int Tot
        {
            get { return _tot; }
            set
            {
                _tot = value;
                OnPropertyChanged(nameof(Tot));
            }
        }
        //public int xp1
        //{
        //    get
        //    {
        //       // var list = exerciseSingleton.ReadList();
                
        //        return xp1;
        //    }
        //    set
        //    {
        //         xp1 = exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise.ExerciseName).XpForExercise;
        //    }
        //}
        //public int xp2
        //{
        //    get
        //    {
        //        int xp2 = exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise.ExerciseName).XpForExercise;
        //        return xp2;
        //    }

        //}
        //public int xp3
        //{
        //    get
        //    {
        //        int xp3 = exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise.ExerciseName).XpForExercise;
        //        return xp3;
        //    }

        //}



        public void ToAddNewGoal()
        {
                Tot = exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise1.ExerciseName)
                          .XpForExercise +
                      exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise2.ExerciseName)
                          .XpForExercise + exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise3.ExerciseName)
                          .XpForExercise;
                //Client cn = clientSingleton.ReadList().Result.Find(c => c.UserName == SelectedClient.UserName);
                //cn.TotalXP = cn.TotalXP + Tot;
                //clientSingleton.UpdateClient(cn);


        }

        public async Task<int> ToAddNewXPToTotalXP(Client nc)
        {
            if (SelectedClient.UserID == nc.UserID)
            {
                int initialXP = nc.TotalXP;
                int XPafterTraining = initialXP + Tot;
                await ClientCatalogSingleton.UpdateClient(nc);
                return XPafterTraining;
            }
            else return nc.TotalXP;
        }

        public void ToAddNewClient()
        {
            Client NewClient = new Client(id, FirstName, LastName, PhoneNumber, UserName, Password, image, age, weight, height, fatPercent,
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
            Trainer newLevels = new Trainer(id, firstName, lastName, PhoneNumber, username, Password, image, yearsOfExperience);
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

