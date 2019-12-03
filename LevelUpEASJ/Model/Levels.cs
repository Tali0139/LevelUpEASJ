﻿using System;
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
        private int _Level;
        private int _totalXP;
        private ClientCatalogSingleton _clientCatalog;
        private LevelUpCRUD<Levels> _levelUpCrud;
        private List<Levels> _allLevels;
        private LevelUpCRUD<Client> _levelUpCrudClient;
        private List<Client> _allClients;

        public Levels(int Level, int MinXP, int MaxXP)
        {
            _Level = Level;
            _maxXP = MaxXP;
            _minXP = MinXP;
        }

        public int Level
        {
            get { return _Level;}
            set { _Level=value;  }
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


        public List<Client> AllClient
        {
            get { return _levelUpCrudClient.Load().Result; }
        }

        public List<Levels> AllLevels
        {
            get { return _levelUpCrud.Load().Result; }
        }

        public int GetLevelForClient()
        {
            var getClientXp = from c in AllClient select new{ c.TotalXP};
            foreach (var cxp in getClientXp)
            {
                _totalXP = cxp.TotalXP;
                return _totalXP;
            }
           

            var setLevel = from l in AllLevels select new {l._minXP, l._maxXP, l._Level};
            foreach (var xp in setLevel)
            {
                if (_totalXP > xp._minXP && _totalXP < xp._maxXP)
                {
                    _Level = xp._Level;
                    return _Level;
                }
            }
            return 0;
        }
        
    }
}
