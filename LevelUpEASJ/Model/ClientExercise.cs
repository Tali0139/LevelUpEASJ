using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LevelUpEASJ.Model
{
    public class ClientExercise
    {
        private int _clientExerciseId;
        private int _clientId;
        private int _exerciseId;

        public ClientExercise() { }

        public ClientExercise(int clientExercise, int clientId, int exerciseId)
        {
            _clientExerciseId = ClientExerciseId;
            _clientId = ClientId;
            _exerciseId = ExerciseId;
        }

        public int ClientExerciseId
        {
            get { return _clientExerciseId; }
            set { _clientExerciseId = value; }
        }
        
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        public int ExerciseId
        {
            get { return _exerciseId; }
            set { _exerciseId = value; }
        }


    }
}
