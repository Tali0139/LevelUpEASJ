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

namespace LevelUpEASJ.Persistency
{
    public class LevelUpCRUD<T> where T : class
    {
        private string _serverURL;
        private string _apiId;
        private HttpClientHandler _handler;
        private HttpClient _HttpClient;
        private string url;

        public const string serverURL = "http://localhost:52352";
        
       
        public LevelUpCRUD(string serverURL, string apiId)
        {
            _serverURL = serverURL;
            _apiId = apiId;
            _handler = new HttpClientHandler();
            _handler.UseDefaultCredentials = true;
            _HttpClient = new HttpClient(_handler);
            _HttpClient.BaseAddress = new Uri(_serverURL);
            url = serverURL + "/" + apiId;
        }


        public async Task Create(int key, T obj)
        {
            string urlNew = url + "/" + key;
            string serialized = JsonConvert.SerializeObject(obj);
            StringContent sc = new StringContent(serialized, Encoding.UTF8, "json/application");
            HttpResponseMessage response = _HttpClient.PostAsync(urlNew, sc).Result;
            response.EnsureSuccessStatusCode();
        }
        
        public async Task Delete(int key)
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

    
        public Task<T> Read(int key)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int key, T obj)
        {
            CancellationToken cancellationToken = new CancellationToken();
            string urlNew = url + "/" + key;
            string serialized = JsonConvert.SerializeObject(obj);
            StringContent sc = new StringContent(serialized, Encoding.UTF8, "json/application");
            HttpResponseMessage response = _HttpClient.PutAsync(urlNew, sc, cancellationToken).Result;
            response.EnsureSuccessStatusCode();

        }
    }
}
