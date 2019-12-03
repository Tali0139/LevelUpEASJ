using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;

namespace LevelUpEASJ.Model
{
    public class ClientCatalogSingleton
    {
        private const string apiId = "api/Clients/";
        private List<Client> _clients;
        private Client _client;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Client> _levelUpCrud;

        private ClientCatalogSingleton()
        {
            _clients = new List<Client>();
            _levelUpCrud = new LevelUpCRUD<Client>(serverUrl, apiId);

        }


        public List<Client> Clients
        {
            get { return _levelUpCrud.Load().Result; }
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

        public void DeleteClient(Client newClient)
        {
            _levelUpCrud.Delete(_client.UserID);
        }

        public async Task<string> UpdateClient(Client selectedClient)
        {
            return await _levelUpCrud.Update(_client.UserID, _client);
        }

    }
}
