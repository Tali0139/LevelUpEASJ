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
using LevelUpEASJ.Persistency;
using LevelUpEASJ.View;

namespace LevelUpEASJ.ViewModel
{
    public class LevelUpViewModel : INotifyPropertyChanged
    {

        public ClientCatalogSingleton clientSingleton { get; set; }
        public TrainerCatalogSingleton trainerSingleton { get; set; }
        public ClientExerciseCatalogSingleton clientExercises { get; set; }
        public ExerciseCatalogSingleton exerciseSingleton { get; set; }

        private ObservableCollection<Exercise> _exercises;
        private ObservableCollection<Client> _clients;
        private ObservableCollection<ClientExercise> _clientExercises;
        private TrainerCatalogSingleton _trainerSingleton;
        private ObservableCollection<Trainer> _trainers;
        private ObservableCollection<Levels> _levels;
        private ObservableCollection<Exercise> _chosenE;


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
        private string gave;
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
            ClientExerciseCatalogSingleton = ClientExerciseCatalogSingleton.ClientExerciseInstance;

            _exercises = new ObservableCollection<Exercise>();
            _trainers = new ObservableCollection<Trainer>();
            _clients = new ObservableCollection<Client>();
            _levels = new ObservableCollection<Levels>();
            _clientExercises = new ObservableCollection<ClientExercise>();
            _chosenE = new ObservableCollection<Exercise>();
            //_selectedExercise = new Exercise(ExerciseName, XpForExercise, ExerciseId);
            _selectedClient = new Client(UserID, FirstName, LastName, PhoneNumber, UserName, Password, image, Age,
                Weight, Height, Fatpercent, Gender, WaistSize, ArmSize, TotalXP);
            _selectedTrainer = new Trainer(UserID, FirstName, LastName, PhoneNumber, UserName, Password, image,
                YearsOfExperience);
            _selectedLevels = new Levels(levelValue, minXp, maxXp, gave);

            _selectedExercise1 = new Exercise();
            _selectedExercise2 = new Exercise();
            _selectedExercise3 = new Exercise();

            //CheckCommand = new RelayCommand(DoesUserExist);
            AddCommand = new RelayCommand(ToAddNewClient);
            CalculateXP = new RelayCommand(ToCalculateXPForTraining);
            CreateGoalForClient = new RelayCommand(ToCreateClientExercise);
            _køn = new List<string>();
            _køn.Add("Mand");
            _køn.Add("Kvinde");

        }

        public ExerciseCatalogSingleton ExerciseCatalogSingleton { get; set; }
        public ClientCatalogSingleton ClientCatalogSingleton { get; set; }
        public TrainerCatalogSingleton TrainerCatalogSingleton { get; set; }
        public ClientExerciseCatalogSingleton ClientExerciseCatalogSingleton { get; set; }


        public ObservableCollection<Client> all_Clients
        {
            get
            {
                _clients = new ObservableCollection<Client>(clientSingleton.Clients);
                return _clients;
            }
        }

        public ObservableCollection<ClientExercise> all_ClientExercises
        {
            get
            {
                _clientExercises =
                    new ObservableCollection<ClientExercise>(ClientExerciseCatalogSingleton.ClientExercises);
                return _clientExercises;
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

        public ObservableCollection<Exercise> all_ChosenExercises
        {
            get
            {
                _chosenE = new ObservableCollection<Exercise>(ChosenExercises);
                return _chosenE;
            }
        }

        public ObservableCollection<Levels> all_Levels
        {
            get
            {
                _levels = new ObservableCollection<Levels>(LevelCatalogSingleton.LevelInstance.Levels);
                return _levels;
            }
        }

      
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand CalculateXP { get; set; }

        public RelayCommand CreateGoalForClient { get; set; }
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
                return LevelCatalogSingleton.LevelInstance
                    .GetLevelForClient(ClientCatalogSingleton.ClientInstance.NyClient).ToString();
            }
        }

        public string ClientXPtoNextLevel
        {
            get
            {
                return LevelCatalogSingleton.LevelInstance.XpToNextLevel(ClientCatalogSingleton.ClientInstance.NyClient)
                    .ToString();
            }
        }

        public List<Exercise> ChosenExercises
        {
            get { return TrainingForClient(ClientCatalogSingleton.ClientInstance.NyClient); }
        }

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


        private string _exerciseName;

        public string ExerciseName
        {
            get { return _exerciseName; }
            set
            {
                _exerciseName = value;
                OnPropertyChanged();
            }
        }

        private int _xpForExercise;

        public int XpForExercise
        {
            get { return _xpForExercise; }
            set
            {
                _xpForExercise = value;
                OnPropertyChanged();
            }
        }

        private int _exerciseId;

        public int ExerciseId
        {
            get { return _exerciseId; }
            set
            {
                _exerciseId = value;
                OnPropertyChanged();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private int _phoneNumber;

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }


        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }


        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }


        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private List<string> _køn;

        public List<string> Køn
        {
            get { return _køn; }
            set
            {
                _køn = value;
                OnPropertyChanged();
            }
        }

        public double Fatpercent
        {
            get { return fatPercent; }
            set
            {
                fatPercent = value;
                OnPropertyChanged();
            }
        }

        public int WaistSize
        {
            get { return waistSize; }
            set
            {
                waistSize = value;
                OnPropertyChanged();
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged();
            }
        }

        public double FatPercent
        {
            get { return fatPercent; }
            set
            {
                fatPercent = value;
                OnPropertyChanged();
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged();
            }
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
            set
            {
                armSize = value;
                OnPropertyChanged();
            }
        }

        public int TotalXP
        {
            get { return totalXp; }
            set
            {
                totalXp = value;
                OnPropertyChanged();
            }
        }

        public int YearsOfExperience
        {
            get { return yearsOfExperience; }
            set
            {
                yearsOfExperience = value;
                OnPropertyChanged();
            }
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
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        }

        public Trainer SelectedTrainer
        {
            get { return _selectedTrainer; }
            set
            {
                _selectedTrainer = value;
                OnPropertyChanged();
            }
        }

        public Levels SelectedLevel
        {
            get { return _selectedLevels; }
            set
            {
                _selectedLevels = value;
                OnPropertyChanged();
            }
        }


        public Exercise SelectedExercise1
        {
            get { return _selectedExercise1; }
            set
            {
                _selectedExercise1 = value;
                OnPropertyChanged();
            }
        }

        public Exercise SelectedExercise2
        {
            get { return _selectedExercise2; }
            set
            {
                _selectedExercise2 = value;
                OnPropertyChanged();
            }
        }

        public Exercise SelectedExercise3
        {
            get { return _selectedExercise3; }
            set
            {
                _selectedExercise3 = value;
                OnPropertyChanged();
            }
        }




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


        public void ToCalculateXPForTraining()
        {
            Tot = exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise1.ExerciseName)
                      .XpForExercise +
                  exerciseSingleton.ReadList().Result.Find(e => e.ExerciseName == SelectedExercise2.ExerciseName)
                      .XpForExercise + exerciseSingleton.ReadList().Result
                      .Find(e => e.ExerciseName == SelectedExercise3.ExerciseName)
                      .XpForExercise;

        }

        public void ToCreateClientExercise()
        {
            Client p = clientSingleton.Clients.Find(c => c.UserName == SelectedClient.UserName);

            int E1ID = exerciseSingleton.Exercises.Find(e => e.ExerciseName == SelectedExercise1.ExerciseName)
                .ExerciseId;
            ClientExercise ce1 = new ClientExercise(p.Id+E1ID+100, p.Id, E1ID);
            ClientExerciseCatalogSingleton.AddClientExercise(ce1);

            int E2ID = exerciseSingleton.Exercises.Find(e => e.ExerciseName == SelectedExercise1.ExerciseName)
                .ExerciseId;

            ClientExercise ce2 = new ClientExercise(p.Id+E2ID+200, p.Id, E2ID);
            ClientExerciseCatalogSingleton.AddClientExercise(ce2);

            int E3ID = exerciseSingleton.Exercises.Find(e => e.ExerciseName == SelectedExercise1.ExerciseName)
                .ExerciseId;
            ClientExercise ce3 = new ClientExercise(p.Id+E3ID+300, p.Id, E3ID);
            ClientExerciseCatalogSingleton.AddClientExercise(ce3);
            OnPropertyChanged(nameof(all_ClientExercises));
        }


        public List<Exercise> TrainingForClient(Client nc)
        {
            List<Exercise>myEList = new List<Exercise>();
            int input = nc.Id;
            var query =
                from item in all_ClientExercises
                where item.ClientId == input
                join exerciseItem in all_Exercises on item.ExerciseId equals exerciseItem.ExerciseId
                select exerciseItem;
            foreach (var result in query)
            {
                myEList.Add(result);
            }
            return myEList;
        }

    
    public async Task<int> ToAddNewXPToTotalXP(Client nc)
    {
        if (SelectedClient.UserID == nc.UserID)
        {
            int initialXP = nc.TotalXP;
            nc.TotalXP= initialXP + Tot;
            await ClientCatalogSingleton.UpdateClient(nc);
            return nc.TotalXP;
        }
        else return nc.TotalXP;
    }

    public Exercise ShowSelectedExercise1
    {
        get
        {
            if (clientSingleton.NyClient.UserID == SelectedClient.UserID) { return SelectedExercise1; }
            else return null;
        }
    }

    public Exercise ShowSelectedExercise2
    {
        get
        {
            if (clientSingleton.NyClient.UserID == SelectedClient.UserID) { return SelectedExercise2; }
            else return null;
        }
    }

    public Exercise ShowSelectedExercise3
    {
        get
        {
            if (clientSingleton.NyClient.UserID == SelectedClient.UserID) { return SelectedExercise3; }
            else return null;
        }
    }


    public int ToAddXPAfterTraining
    {
        get { return ToAddNewXPToTotalXP(SelectedClient).Result; }
    }

    public string NumberOfTraining
    {
        get
        {
            int result = 0;
            if (clientSingleton.NyClient.UserID == SelectedClient.UserID)
            {
                if (ShowSelectedExercise1.XpForExercise != 0)
                {
                    result = +1;
                }
                if (ShowSelectedExercise2.XpForExercise != 0)
                {
                    result = +1;
                }
                if (ShowSelectedExercise2.XpForExercise != 0)
                {
                    result = +1;
                }
                else result = +0;

                return result.ToString();
            }

            return "Øvelse(r) kunne ikke findes";
        }
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

