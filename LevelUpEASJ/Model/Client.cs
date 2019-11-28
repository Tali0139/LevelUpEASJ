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

        public Client(int id, string firstName, string lastName, string username, string password, int Age, double Weight, int Height, double FatPercent, string Gender, int WaistSize, double ArmSize) : base(id, firstName, lastName, username, password)

        {
            _weight = Weight;
            _height = Height;
            _fatPercent = FatPercent;
            _gender = Gender;
            _armSize = ArmSize;
            _waistSize = WaistSize;
            _age = Age;

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

        


    }

}
