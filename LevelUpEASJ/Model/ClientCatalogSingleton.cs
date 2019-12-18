using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using LevelUpEASJ.ViewModel;

namespace LevelUpEASJ.Model
{
    public class ClientCatalogSingleton
    {
        private const string apiId = "api/Clients/";
        private List<Client> _clients;
        private Client _client;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Client> _levelUpCrud;
        private Client c;
        

        public Client NyClient
        {
            get { return c; } set { c = value; }
        }



        private ClientCatalogSingleton()
        {
            _clients = new List<Client>();
            _levelUpCrud = new LevelUpCRUD<Client>(serverUrl, apiId);
            c = new Client();
        }

        private static ClientCatalogSingleton _clientInstance;

        public static ClientCatalogSingleton ClientInstance
        {
            get
            {
                if (_clientInstance == null)
                {
                    _clientInstance = new ClientCatalogSingleton();
                }
                return _clientInstance;
            }
        }


        public List<Client> Clients
        {
            get { return _levelUpCrud.Load().Result; }
        }


        private int _count;
        public int Count
        {
            get { return Clients.Count; }
            set { _count = value; }
        }

        public async Task<List<Client>> ReadList()
        {
            return await _levelUpCrud.Load();
        }

        public void Read()
        {
            _levelUpCrud.Read(_client.UserID);
        }


        public async void AddClient(Client nc)
        {
            bool exist = false;
            {
                foreach (var c in _levelUpCrud.Load().Result)
                {
                    if (c.UserName == nc.UserName)
                        exist = true;
                }

                if (exist == false)
                {
                    nc.UserID = Count++;
                    await _levelUpCrud.Create(nc.UserID, nc);
                }

            }
        }

        public string ImageViewTraining
        {
            get
            {
                if (NyClient.Image != null)
                {
                    return NyClient.Image;
                }
                else return "../Assets/BrugerIconGennemsigitg.png";
            }
        }

        public async Task<string> GetGiftForClient(Client nc)
        {
            int input = nc.TotalXP;
            var query = from level in LevelCatalogSingleton.LevelInstance.Levels
                where level.MaxXP >= input && level.MinXP <= input
                select level;

            foreach (var result in query)
            {
                return result.Gave.ToString();
            }
            return null;
        }

        public string ClientGift
        {
            get
            {
                return ClientCatalogSingleton.ClientInstance.GetGiftForClient(ClientCatalogSingleton.ClientInstance.NyClient).Result.ToString();
            }
        }



        public void DeleteClient(Client delClient)
        {
            _levelUpCrud.Delete(delClient.Id, delClient);
        }

        public async void UpdateClient(Client upClient)
        {
            bool exist = false;
            {
                foreach (var c in _levelUpCrud.Load().Result)
                {
                    if (c.UserName == upClient.UserName)
                        exist = true;
                }

                if (exist == true)
                {
                    
                    await _levelUpCrud.Update(upClient.Id, upClient);
                }

            }
        }


    }
}
