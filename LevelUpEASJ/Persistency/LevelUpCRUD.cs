using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LevelUpEASJ.Persistency
{
    public class LevelUpCRUD<T>:ILevelUpCRUD<T> where T : class
    {
        private string _serverURL;
        private string _apiPrefix;
        private string _apiId;
        private HttpClientHandler _handler;
        private HttpClient _HttpClient;
        private string url;
        

       
        public LevelUpCRUD(string serverURL, string apiPrefix, string apiId)
        {
            _serverURL = serverURL;
            _apiId = apiId;
            _apiPrefix = apiPrefix;
            _handler = new HttpClientHandler();
            _handler.UseDefaultCredentials = true;
            _HttpClient = new HttpClient(_handler);
            _HttpClient.BaseAddress = new Uri(_serverURL);
            url = serverURL + "/" + apiPrefix + "/" + apiId;
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

        public Task<List<T>> Load()
        {
            throw new NotImplementedException();
        }

    
        public Task<T> Read(int key)
        {
            throw new NotImplementedException();
        }

        public Task Update(int key, T obj)
        {
            throw new NotImplementedException();
        }
    }
}
