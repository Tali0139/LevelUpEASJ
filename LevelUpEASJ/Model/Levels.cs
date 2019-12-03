using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;
using Remotion.Linq.Clauses;

namespace LevelUpEASJ.Model
{
    class Levels
    {
        private int _minXP;
        private int _maxXP;
        private int _Level;
        private int _totalXP;
        private ClientCatalogSingleton _clientCatalog;
        private LevelUpCRUD<Levels> _levelUpCrud;
        private List<Levels> _allLevels;
        private LevelUpCRUD<Client> _levelUpCrudClient;
        private List<Client> _allClients;

        public List<Client> AllClient
        {
            get { return _levelUpCrudClient.Load().Result; }
        }

        public List<Levels> AllLevels
        {
            get { return _levelUpCrud.Load().Result; }
        }

        public async void GetLevelForClient()
        {
            _totalXP = from c in AllClient 
            var query = from l in AllLevels select new {l._minXP, l._maxXP};
        }

    }
}
