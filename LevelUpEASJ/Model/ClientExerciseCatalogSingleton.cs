using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelUpEASJ.Persistency;

namespace LevelUpEASJ.Model
{
   public class ClientExerciseCatalogSingleton
    {
        private const string apiId = "api/ClientExercises/";
        private List<ClientExercise> _clientExercises;
        private ClientExercise _clientExercise;
        private string serverUrl = "http://localhost:53409";
        private LevelUpCRUD<ClientExercise> _levelUpCrud;
        private ClientExercise ce;

        public ClientExercise NyClientExercise
        {
            get { return ce; }
            set { ce = value; }
        }


        private ClientExerciseCatalogSingleton()
        {
            _clientExercises = new List<ClientExercise>();
            _levelUpCrud = new LevelUpCRUD<ClientExercise>(serverUrl, apiId);
            ce = new ClientExercise();
        }

        private static ClientExerciseCatalogSingleton _clientExerciseInstance;

        public static ClientExerciseCatalogSingleton ClientExerciseInstance
        {
            get
            {
                if (_clientExerciseInstance == null)
                {
                    _clientExerciseInstance = new ClientExerciseCatalogSingleton();
                }
                return _clientExerciseInstance;
            }
        }


        public List<ClientExercise> ClientExercises
        {
            get { return _levelUpCrud.Load().Result; }
        }


        private int _count;
        public int Count
        {
            get { return ClientExercises.Count; }
            set { _count = value; }
        }

        public async Task<List<ClientExercise>> ReadList()
        {
            return await _levelUpCrud.Load();
        }

        public void Read()
        {
            _levelUpCrud.Read(_clientExercise.ClientExerciseId);
        }


        public async void AddClientExercise(ClientExercise cex)
        {
            bool exist = false;
            {
                foreach (var c in _levelUpCrud.Load().Result)
                {
                    if (c.ClientExerciseId == cex.ClientExerciseId)
                        exist = true;
                }

                if (exist == false)
                {
                    cex.ClientExerciseId = Count++;
                    await _levelUpCrud.Create(cex.ClientExerciseId, cex);
                }

            }
        }

    }
}
