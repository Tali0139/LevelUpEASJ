using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace LevelUpEASJ.Model
{
    public class ExerciseCatalogSingleton
    {
        private const string apiId = "api/Exercises/";
        private Exercise _exercise;
        private List<Exercise> _exercises;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Exercise> _levelUpCrudExercise;
        private LevelUpCRUD<ClientExercise> _levelUpCRUDClientExercise;
        private Exercise e;
        private ClientExercise _clientExercise;
       

        public Exercise NyExercise
        {
            get { return e; }
            set { e = value; }
        }

        public ExerciseCatalogSingleton()
        {
            _exercises = new List<Exercise>();
            _levelUpCrudExercise = new LevelUpCRUD<Exercise>(serverUrl, apiId);
            e = new Exercise();
        }

        private static ExerciseCatalogSingleton _exerciseInstance;
        public static ExerciseCatalogSingleton ExerciseInstance
        {
            get
            {
                if (_exerciseInstance == null)
                {
                    _exerciseInstance = new ExerciseCatalogSingleton();
                }
                return _exerciseInstance;
            }
        }

      
        public async Task<List<Exercise>> ReadList()
        {
            return await _levelUpCrudExercise.Load();
        }

       

        public List<Exercise> Exercises
        {
            get { return _levelUpCrudExercise.Load().Result; }
        }

        public async Task<List<Exercise>> ReadListExercise()
        {
            return await _levelUpCrudExercise.Load();
        }

        private int _count;

        public int Count
        {
            get { return Exercises.Count; }
            set { _count = value; }
        }

        public List<ClientExercise> ClientExercises
        {
            get { return _levelUpCRUDClientExercise.Load().Result; }
        }

        public int XPForExercise(Client nc)
        {
            int cid = nc.UserID;
            var Query = from exer in Exercises
                        join clientExercise in ClientExercises on exer.ExerciseId equals clientExercise.ExerciseId
                        select new
                        {
                            XpFortraining = exer.XpForExercise,
                            clientIdentification = clientExercise.ClientId,
                            ExerciseIdentification = clientExercise.ExerciseId,
                        };

            foreach (var result in Query)
            {
                if (cid == result.clientIdentification)
                {
                    int _ex1 = result.XpFortraining;
                    int _ex2 = result.XpFortraining;
                    int _ex3 = result.XpFortraining;
                    int sumOfXP = _ex1 + _ex2 + _ex3;
                    return sumOfXP;
                }
            }
            return 0;
        }





    }
}
