using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Display.Core;
using Windows.UI.Xaml;
using LevelUpEASJ.Persistency;
using Remotion.Linq.Clauses;

namespace LevelUpEASJ.Model
{
    public class Levels
    {
        private int _minXP;
        private int _maxXP;
        private int _levelValue;
        private int _totalXP;
        private string _gave;
        private ClientCatalogSingleton _clientCatalog;
        private LevelUpCRUD<Levels> _levelUpCrud;
        private List<Levels> _allLevels;
        private LevelUpCRUD<Client> _levelUpCrudClient;
        private List<Client> _allClients;

        public Levels(int LevelValue, int MinXP, int MaxXP,string Gave)
        {
            _levelValue = LevelValue;
            _maxXP = MaxXP;
            _minXP = MinXP;
            _gave = Gave;
        }
        
        public int LevelValue
        {
            get { return _levelValue; }
            set { _levelValue = value;  }
        }

        public int MaxXP
        {
            get { return _maxXP; }
            set { _maxXP = value; }
        }

        public int MinXP
        {
            get { return _minXP; }
            set { _minXP = value; }
        }

        public string Gave
        {
            get { return _gave; }
            set { _gave = value; }
        }

        
    }
}