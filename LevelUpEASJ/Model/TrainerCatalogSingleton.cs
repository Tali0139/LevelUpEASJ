﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;

namespace LevelUpEASJ.Model
{
    public class TrainerCatalogSingleton
    {
        private const string apiId = "api/Trainers/";
        private List<Trainer> _trainers;
        private Trainer _trainer;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Trainer> _levelUpCrudTrainer;
        private Trainer t;

        public Trainer NyTrainer
        {
            get { return t; } set { t = value; } }


        private TrainerCatalogSingleton()
        {
            _trainers = new List<Trainer>();
            _levelUpCrudTrainer = new LevelUpCRUD<Trainer>(serverUrl, apiId);
            t = new Trainer();
        }

        public List<Trainer> Trainers
        {
            get { return _levelUpCrudTrainer.Load().Result; }
        }

        private static TrainerCatalogSingleton _trainerInstance;

        public static TrainerCatalogSingleton TrainerInstance
        {
            get
            {
                if (_trainerInstance == null)
                {
                    _trainerInstance = new TrainerCatalogSingleton();
                }
                return _trainerInstance;
            }
        }

        private int _countTrainer;

        public int CountTrainer
        {
            get { return _countTrainer; }
            set { _countTrainer = value; }
        }

        public async Task<List<Trainer>> ReadListTrainer()
        {
            return await _levelUpCrudTrainer.Load();
        }

        public void ReadTrainer()
        {
            _levelUpCrudTrainer.Read(_trainer.UserID);
        }

        public void DeleteTrainer(Trainer delTrainer)
        {
            _levelUpCrudTrainer.Delete(delTrainer.UserID, delTrainer);
        }

        public async Task<string> UpdateTrainer(Trainer selectedLevels)
        {
            return await _levelUpCrudTrainer.Update(_trainer.UserID, _trainer);
        }

        public string TrainerImageViewTraining
        {
            get
            {
                if (NyTrainer.Image != null)
                {
                    return NyTrainer.Image;
                }
                else return "../Assets/BrugerIconGennemsigitg.png";
            }
        }

        public async void AddTrainer(Trainer nt)
        {
            bool exist = false;
            {
                foreach (var t in _levelUpCrudTrainer.Load().Result)
                {
                    if (t.UserName == nt.UserName)
                        exist = true;
                }

                if (exist == false)
                {
                    nt.UserID = CountTrainer++;
                    await _levelUpCrudTrainer.Create(nt.UserID, nt);
                }

            }
        }




    }
}
