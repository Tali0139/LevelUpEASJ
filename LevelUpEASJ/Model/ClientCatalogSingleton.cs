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
        private string serverUrl = "http://localhost:49306";
        private LevelUpCRUD<Client> _levelUpCrud;

        private ClientCatalogSingleton()
        {
            _clients = new List<Client>();
           _levelUpCrud = new LevelUpCRUD<Client>(serverUrl,apiId);

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
            get { return _count;}
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

        public async Task<string> Create()
        {
            return await _levelUpCrud.Create(_client.UserID, _client);
        }

        public void Delete()
        {
            _levelUpCrud.Delete(_client.UserID);
        }

        public async Task<string> Update()
        {
            return await _levelUpCrud.Update(_client.UserID, _client);
        }

    }
}
