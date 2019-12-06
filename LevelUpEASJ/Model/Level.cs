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
    public class Level
    {
        private int _minXP;
        private int _maxXP;
        private int _level;
        private int _totalXP;
        private ClientCatalogSingleton _clientCatalog;
        private LevelUpCRUD<Level> _levelUpCrud;
        private List<Level> _allLevels;
        private LevelUpCRUD<Client> _levelUpCrudClient;
        private List<Client> _allClients;

        public Level(int Level, int MinXP, int MaxXP)
        {
            _level = Level;
            _maxXP = MaxXP;
            _minXP = MinXP;
        }

        public int Levelvalue
        {
            get { return _level;}
            set { _level=value;  }
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


        
    }
}
