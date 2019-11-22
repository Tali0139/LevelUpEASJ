using LevelUpEASJ.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{
    
    
       

   namespace LevelUpEASJ.Model
    {
        public class UserCatalogSingleton
        {
            private const string apiId = "api/User/";
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



            private int _count;
            public int Count
            {
                get { return _count; }
                set
                {
                    _count = value;
                }
            }
            public List<User> Users
            {
                //get { return  _users; }
                get
                {
                    //return  users();
                    return LevelUpCRUD.Load(key);
                }
                set
                {
                    _users = value;

                }
            }


            public void Create(User user)
            {
                
                //_students.Add(student);
                LevelUpCRUD.Create(key, user);
            }

            public void Delete(User u)
            {
                //_students.Remove(s);
                //myClient.DeleteStudent(s.StudentID);

                LevelUpCRUD.Delete(key + u.User);
                LevelUpCRUD.Load(key);
            }

            public void update(User u)
            {
                //myClient.UpdateStudent(s);
                LevelUpCRUD.Update(url + u.Id, u);
            }
        }
    }

}
}
