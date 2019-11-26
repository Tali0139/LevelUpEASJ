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
        private const string apiId = "api/Client/";
        private List<Client> _clients;
        private Client _client;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Client> _levelUpCrud;

        private ClientCatalogSingleton()
        {
            _clients = new List<Client>();
           _levelUpCrud = new LevelUpCRUD<Client>(serverUrl,apiId);



           Client c1 = new Client(1, "Omar", "Jaber", "Oj", "1234", 30, 68, 170, 16.8, "Mand", 38, 25);
           Client c2 = new Client(2, "Olivia", "Ownsabeach", "Olivia", "1234", 24, 86, 140, 28.3, "Hen", 110, 26.6);
           Client c3 = new Client(3, "Taliiia", "fukifuki", "Tali", "1234", 35, 68, 168, 18.8, "Kvinde", 48, 35);
           Client c4 = new Client(4, "Konraaad", "Blabli", "Kon", "1234", 27, 75, 175, 15.5, "Mand", 38, 30);
           Client c5 = new Client(5, "omar", "jaber", "oj", "1234", 30, 68, 170, 16.8, "mand", 38, 25);
            _clients.Add(c1);
           _clients.Add(c2);
           _clients.Add(c3);
           _clients.Add(c4);
            _clients.Add(c5);
        }


        public List<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
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
