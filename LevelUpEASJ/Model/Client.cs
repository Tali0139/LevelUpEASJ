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
        private int _weight;
        private int _height;
        private double _fatPercent;
        private string _gender;
        private int _totalXp;
        private int _level;
        private int _waistSize;
        private double _armSize;

        public Client(int id, string firstName, string lastName, string username, string password, int weight, int height, double fatPercent, string gender, int waistSize, double armSize) : base(id, firstName, lastName, username, password)

        {
            _weight = Weight;
            _height = Height;
            _fatPercent = FatPercent;
            _gender = Gender;
            _armSize = ArmSize;
            _waistSize = WaistSize;

        }

        public int Weight
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
