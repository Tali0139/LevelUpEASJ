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
        private int _phoneNumber;
        private string _image;

        public User()
        {

        }

        public User(int id, string firstName, string lastName, int phoneNumber, string username, string password, string image)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _username = username;
            _password = password;
            _image = image;
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

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
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

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }



        public override string ToString()
        {
            return $"{FirstName + LastName + UserName + Password}";
        }

    }
}

