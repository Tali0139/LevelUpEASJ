using LevelUpEASJ.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LevelUpEASJ.Model
{

    //kommentar
        public class UserCatalogSingleton
        {
            
            private const string apiId = "api/User/";
            private int key = Instance._user.UserID;
            private List<User> _users;
            private User _user;
            private UserCatalogSingleton()
            

            {
                _users = new List<User>();

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

            public LevelUpCRUD LevelUpCrud { get; set; }



            private int _count;
            public int Count
            {
                get { return _count; }
                set
                {
                    _count = value;
                }
            }

            public async Task<List<Object>> Load()
            {
                return await LevelUpCrud.Load();
                
            }

      
            public  async Task<string> Create(int key, Object user)
            {
            return await LevelUpCrud.Create(key, user);
            }

            public void Delete(User u)
            {
                LevelUpCrud.Delete(u.UserID);
                
                
            }

            public void update(User u)
            {
                LevelUpCrud.Update(key, u);
            }
        }
    

}

