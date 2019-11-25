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
        private int key = Instance._user.UserID;
        private List<User> _users;
        private User _user;
        private string serverUrl = "http://localhost:52352";
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

        //public LevelUpCRUD LevelUpCrud { get; set; }



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



        //public async Task <List<User>> Users
        //{
        //    get { return await Load(); }
        //    set { _users = value; }
        //}


        //public  async Task<string> Create(int key, Object user)
        //{
        //return await LevelUpCrud.Create(key, user);
        //}

        //public void Delete(User u)
        //{
        //    LevelUpCrud.Delete(u.UserID);


        //}

        //public void update(User u)
        //{
        //    LevelUpCrud.Update(key, u);
        //}
    }

}

