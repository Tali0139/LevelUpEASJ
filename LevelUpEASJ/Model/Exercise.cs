using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{
    public class Exercise
    {
        private string _exerciseName;
        private int _xpForExercise;
        
        

        public string ExerciseName
        {
            get { return _exerciseName;}
            set { _exerciseName = value; }
        }

        public int XpForExercise
        {
            get { return _xpForExercise; }
            set { _xpForExercise = value; }
        }

    }
}
