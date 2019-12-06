using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Windows.Security.Cryptography.Core;
using LevelUpEASJ.Persistency;

namespace LevelUpEASJ.Model
{
    public class LevelCatalogSingleton
    {
        private const string apiId = "api/Levels/";
        private List<Level> _levels;
        private Level _level;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Level> _levelUpCrudLevel;

        private LevelCatalogSingleton()
        {
            _levels = new List<Level>();
            _levelUpCrudLevel = new LevelUpCRUD<Level>(serverUrl, apiId);
        }


        public List<Level> Levels
        {
            get { return _levelUpCrudLevel.Load().Result; }
        }

        private static LevelCatalogSingleton _levelInstance;

        public static LevelCatalogSingleton LevelInstance
        {
            get
            {
                if (_levelInstance == null)
                {
                    _levelInstance = new LevelCatalogSingleton();
                }
                return _levelInstance;
            }
        }


        private LevelUpCRUD<Level> _levelUpCrud;


        public string GetLevelForClient(Client nc)
        {
            int input = nc.TotalXP;
            string result;
            if (input >= 0 && input <= 99) { result = "1"; }
            else if (input >= 100 && input <= 199) { result = "2"; }
            else if (input >= 200 && input <= 349) { result = "3"; }
            else if (input >= 350 && input <= 549) { result = "4"; }
            else if (input >= 550 && input <= 799) { result = "5"; }
            else if (input >= 800 && input <= 1099) { result = "6"; }
            else if (input >= 1100 && input <= 1449) { result = "7"; }
            else if (input >= 1450 && input <= 1849) { result = "8"; }
            else if (input >= 1850 && input <= 2299) { result = "9"; }
            else if (input >= 2300 && input <= 2799) { result = "10"; }
            else if (input >= 2800 && input <= 3349) { result = "11"; }
            else if (input >= 3350 && input <= 3949) { result = "12"; }
            else if (input >= 3950 && input <= 4599) { result = "13"; }
            else if (input >= 4600 && input <= 5299) { result = "14"; }
            else if (input >= 5300 && input <= 6049) { result = "15"; }
            else if (input >= 6050 && input <= 6849) { result = "16"; }
            else if (input >= 6850 && input <= 7699) { result = "17"; }
            else if (input >= 7700 && input <= 8599) { result = "18"; }
            else if (input >= 8600 && input <= 9999) { result = "19"; }
            else if (input >= 10000) { result = "20"; }
            else result = "No level detected";

            return result;

        }
            
    }

}

