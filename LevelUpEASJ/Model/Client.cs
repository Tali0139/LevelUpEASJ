using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{
    public class Client : User
    {
        private double _weight;
        private int _height;
        private double _fatPercent;
        private string _gender;
        private int _totalXp;
        private int _level;
        private int _waistSize;
        private double _armSize;
        private int _age;
        private int _id;
        private string _goal;


        public Client() { }

        public Client(int id, string firstName, string lastName, int phoneNumber,string username, string password, string image, 
                      int Age, double Weight, int Height, double FatPercent, string Gender, int WaistSize, double ArmSize, int TotalXP, string goal) 
            : base(id, firstName, lastName, phoneNumber, username, password, image)
        {
            _weight = Weight;
            _height = Height;
            _fatPercent = FatPercent;
            _gender = Gender;
            _armSize = ArmSize;
            _waistSize = WaistSize;
            _age = Age;
            _totalXp = TotalXP;
            _id = id;
            _goal = goal;

        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public double Weight
        {
            get { return _weight; }
            set {_weight = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double FatPercent
        {
            get { return _fatPercent; }
            set { _fatPercent = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int WaistSize
        {
            get { return _waistSize; }
            set { _waistSize = value; }
        }

        public double ArmSize
        {
            get { return _armSize; }
            set { _armSize = value; }
        }

        public int TotalXP
        {
            get { return _totalXp; }
            set { _totalXp = value; }
        }

        public string Goal
        {
            get { return _goal; }
            set { _goal = value; }
        }

        
    }

}
