using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;

namespace LevelUpEASJ.Model
{
    public class IUser
    {
        private int _id;
        private string _firstName;
        private string _username;
        private string _lastName;
        private string _password;

        public IUser()
        {

        }

        public IUser(int Id, string FirstName, string LastName, string Username, string Password)
        {
            _id = Id;
            _firstName = FirstName;
            _lastName = LastName;
            _username = Username;
            _password = Password;
        }

        public int UserID
        {
            get { return _id; }


        }

    }
}
