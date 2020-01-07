using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{
    public class Exercise : User
    {
        private string _exerciseName;
        private int _xpForExercise;
        private int _exerciseId;
        private string _exerciseImage;


        public Exercise()
        {

        }


        public Exercise(string exerciseName, int xpForExercise, int exerciseId, string exerciseImage)
        {
            _exerciseName = ExerciseName;
            _xpForExercise = XpForExercise;
            _exerciseId = ExerciseId;
            _exerciseImage = ExerciseImage;

        }

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

        public int ExerciseId
        {
            get { return _exerciseId; }
            set { _exerciseId = value; }
        }

        public string ExerciseImage
        {
            get { return _exerciseImage; }
            set { _exerciseImage = value; }
        }
    }
}
