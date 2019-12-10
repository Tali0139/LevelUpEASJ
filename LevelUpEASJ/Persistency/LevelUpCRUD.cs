using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using LevelUpEASJ.Model;

namespace LevelUpEASJ.Persistency
{

    public class LevelUpCRUD<T>
    {
        private string _serverURL;
        private string _apiId;
        private HttpClientHandler _handler;
        private HttpClient _HttpClient;
        private string url;
        private ClientCatalogSingleton _clientCatalogSingleton;
        private TrainerCatalogSingleton _trainerCatalogSingleton;

        //public const string serverURL = "http://localhost:52352";


        public LevelUpCRUD(string serverURL, string apiId)
        {
            _serverURL = serverURL;
            _apiId = apiId;
            _handler = new HttpClientHandler();
            _handler.UseDefaultCredentials = true;
            _HttpClient = new HttpClient(_handler);
            _HttpClient.BaseAddress = new Uri(_serverURL);
            _HttpClient.DefaultRequestHeaders.Clear();
            _HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            url = serverURL + "/" + apiId;
        }


        public async Task<string> Create(int key, T obj)
        {
            string urlNew = url + "/" + key;
            try
            {
                var serialized = JsonConvert.SerializeObject(obj);
                StringContent sc = new StringContent(serialized, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _HttpClient.PostAsync(urlNew, sc);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public void Delete(int key)
        {
            string urlNew = url + "/" + key;
            HttpResponseMessage response = _HttpClient.DeleteAsync(urlNew).Result;
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<T>> Load()
        {
            string urlNew = url;
            HttpResponseMessage response = _HttpClient.GetAsync(urlNew).Result;
            if (response.IsSuccessStatusCode)
            {
                string s = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(s);
            }
            return null;
        }


        public void Read(int key)
        {
            string urlNew = url + "/" + key;
            HttpResponseMessage response = _HttpClient.GetAsync(urlNew).Result;
            response.EnsureSuccessStatusCode();
        }



        public async Task<string> Update(int key, T obj)
        {
            CancellationToken cancellationToken = new CancellationToken();
            string urlNew = url + "/" + key;
            string serialized = JsonConvert.SerializeObject(obj);
            StringContent sc = new StringContent(serialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _HttpClient.PutAsync(urlNew, sc, cancellationToken).Result;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
