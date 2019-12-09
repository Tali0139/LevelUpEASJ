using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;
namespace LevelUpEASJ.Model
{
    public class ExerciseCatalogSingleton
    {
        private const string apiId = "api/Exercise/";

        private Exercise _exerciseModel;



        private List<Exercise> _exercises;
        
        
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<Exercise> _levelUpCrudExercise;

        private ExerciseCatalogSingleton()
        {
            _exercises = new List<Exercise>();
            _levelUpCrudExercise = new LevelUpCRUD<Exercise>(serverUrl, apiId);
            
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




        public List<Exercise> ExercisesList
        {
            get { return _levelUpCrudExercise.Load().Result; }
        }

        
            

          

  

        }






    }
}
