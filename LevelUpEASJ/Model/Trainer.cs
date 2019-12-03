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

        public Trainer(int id, string firstName, string lastName, int phoneNumber, string username, string password, int yearsOfExperience) : base(id, firstName, lastName, phoneNumber, username, password)

        {
            _yearsOfExperience = yearsOfExperience;
         
        }

        public int YearsOfExperience
        {
            get { return _yearsOfExperience; }
            set { _yearsOfExperience = value; }
        }


    }
}
