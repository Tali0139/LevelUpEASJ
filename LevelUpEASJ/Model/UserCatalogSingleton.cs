using LevelUpEASJ.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LevelUpEASJ.Model
{

    public class UserCatalogSingleton
    {

        private const string apiId = "api/User/";
        //private int key = Instance._user.UserID;
        private List<User> _users;
        private User _user;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<User> _levelUpCrud;
        private UserCatalogSingleton()
        {
            _users = new List<User>();
            _levelUpCrud = new LevelUpCRUD<User>(serverUrl, apiId);
        }

        private static UserCatalogSingleton _instance;
        public static UserCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserCatalogSingleton();
                }
                return _instance;
            }
        }

        
        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
            }
        }

        public async Task<List<User>> Load()
        {
            return await _levelUpCrud.Load();
        }


        public void Read()
        {
            _levelUpCrud.Read(_user.UserID);
        }

        public async Task<string> Create()
        {
            return await _levelUpCrud.Create(_user.UserID, _user);
        }

        public void Delete()
        {
            _levelUpCrud.Delete(_user.UserID);
        }


        public async Task<string> Update()
        {
            return await _levelUpCrud.Update(_user.UserID, _user);
        }


    }

}

