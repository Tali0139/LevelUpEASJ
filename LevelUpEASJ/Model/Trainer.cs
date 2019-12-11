using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{
   public class Trainer : User
    {

        private int _yearsOfExperience;

        public Trainer(int id, string firstName, string lastName, int phoneNumber, string username, string password, string image, int yearsOfExperience) 
            : base(id, firstName, lastName, phoneNumber, username, password, image)

        {
            _yearsOfExperience = yearsOfExperience;
         
        }

        public Trainer() { }

        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
            set { _yearsOfExperience = value; }
        }


    }
}
