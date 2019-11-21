using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{

    public class User
    {
        private int _id;
        private string _firstName;
        private string _username;
        private string _lastName;
        private string _password;

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string username, string password)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _username = username;
            _password = password;
        }


        public int UserID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }


        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }


        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }


        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }




        public override string ToString()
        {
            return $"{FirstName + LastName + UserName + Password}";
        }

    }
}

