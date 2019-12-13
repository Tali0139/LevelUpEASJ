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
        private List<Levels> _levels;
        private Levels _level;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Levels> _levelUpCrudLevel;

        private LevelCatalogSingleton()
        {
            _levels = new List<Levels>();
            _levelUpCrudLevel = new LevelUpCRUD<Levels>(serverUrl, apiId);

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

        public List<Levels> Levels
        {
            get { return _levelUpCrudLevel.Load().Result; }
        }


        public string GetLevelForClient(Client nc)
        {
            int input = nc.TotalXP;
            var query = from level in Levels
                        where level.MaxXP >= input && level.MinXP <= input
                        select level;
            foreach (var result in query)
            {
                return result.LevelValue.ToString();
            }
            return "Level not detected";
         }

      
        public string XpToNextLevel(Client nc)
        {
            int input = nc.TotalXP;

            var query = from level in Levels
                where level.MaxXP >= input && level.MinXP <= input
                select level;

            foreach (var result in query)
            {
                if (result.LevelValue < 20)
                {
                    int max = result.MaxXP;
                    int diff = max - input;
                    return $"Tjen {1 + diff}xp for at nå level {1 + result.LevelValue}";
                }
            }
            return "Du har nået det højeste level";
        }

    }
}

