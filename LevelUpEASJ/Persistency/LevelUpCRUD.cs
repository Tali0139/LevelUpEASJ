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
    //public class LevelUpCRUD<T>
    //{
    //    private enum APIMethodSwitch { Load, Create, Read, Update, Delete }

    //    #region Instance fields
    //    private string _serverURL;
    //    private string _apiPrefix;
    //    private string _apiID;
    //    private HttpClientHandler _handler;
    //    private HttpClient _client;
    //    #endregion

    //    #region Constructor
    //    public LevelUpCRUD(string serverURL, string apiPrefix, string apiID)
    //    {
    //        _serverURL = serverURL;
    //        _apiID = apiID;
    //        _apiPrefix = apiPrefix;
    //        _handler = new HttpClientHandler();
    //        _handler.UseDefaultCredentials = true;
    //        _client = new HttpClient(_handler);
    //        _client.BaseAddress = new Uri(_serverURL);
    //    }
    //    #endregion

    //    #region Implementation
    //    public async Task<List<T>> Load()
    //    {
    //        return await InvokeAPIWithReturnValueAsync<List<T>>(() => _client.GetAsync(CreateURL(APIMethodSwitch.Load)));
    //    }

    //    public async Task<T> Read(int key)
    //    {
    //        return await InvokeAPIWithReturnValueAsync<T>(() => _client.GetAsync(CreateURL(APIMethodSwitch.Read, key)));
    //    }

    //    public async Task Create(T obj)
    //    {
    //        await UseAPICRUDAsync(() => _client.PostAsJsonAsync(CreateURL(APIMethodSwitch.Create), obj));
    //    }

    //    public async Task Update(int key, T obj)
    //    {
    //        await UseAPICRUDAsync(() => _client.PutAsJsonAsync(CreateURL(APIMethodSwitch.Update, key), obj));
    //    }

    //    public async Task Delete(int key)
    //    {
    //        await UseAPICRUDAsync(() => _client.DeleteAsync(CreateURL(APIMethodSwitch.Update, key)));
    //    }
    //    #endregion

    //    #region Private methodSwitch for API methodSwitch invocation
    //    private async Task<T> InvokeAPIWithReturnValueAsync<T>(Func<Task<HttpResponseMessage>> apiMethod)
    //    {
    //        return await InvokeAPIAsync(apiMethod).Result.Content.ReadAsAsync<T>();
          
    //    }

    //    private async Task UseAPICRUDAsync(Func<Task<HttpResponseMessage>> apiMethod)
    //    {
    //        await InvokeAPIAsync(apiMethod);
    //    }

    //    private async Task<HttpResponseMessage> InvokeAPIAsync(Func<Task<HttpResponseMessage>> apiMethod)
    //    {
    //        // Prepare HTTP client for methodSwitch invocation
    //        _client.DefaultRequestHeaders.Clear();
    //        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //        // Invoke the methodSwitch - the methodSwitch will at some point 
    //        // return an HttpResponseMessage 
    //        HttpResponseMessage response = await apiMethod();

    //        // Throw exception if the invocation was unsuccessful
    //        if (!response.IsSuccessStatusCode)
    //        {
    //            throw new Exception($"{(int)response.StatusCode} - {response.ReasonPhrase}");
    //        }

    //        // Return the HttpResponseMessage, which we now know 
    //        // is a response to a successful methodSwitch invocation
    //        return response;
    //    }

    //    private string CreateURL(APIMethodSwitch methodSwitch, int key = 0)
    //    {
    //        switch (methodSwitch)
    //        {
    //            case APIMethodSwitch.Load:
    //                return $"{_apiPrefix}/{_apiID}";
    //            case APIMethodSwitch.Create:
    //                return $"{_apiPrefix}/{_apiID}";
    //            case APIMethodSwitch.Read:
    //                return $"{_apiPrefix}/{_apiID}/{key}";
    //            case APIMethodSwitch.Update:
    //                return $"{_apiPrefix}/{_apiID}/{key}";
    //            case APIMethodSwitch.Delete:
    //                return $"{_apiPrefix}/{_apiID}/{key}";
    //            default:
    //                throw new ArgumentException("CreateURL");
    //        }
    //    }
    //    #endregion
    //}
    public class LevelUpCRUD
     {
         private string _serverURL;
         private string _apiId;
         private HttpClientHandler _handler;
         private HttpClient _HttpClient;
         private string url;
         private UserCatalogSingleton _userCatalogSingleton;
         public const string serverURL = "http://localhost:52352";


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


         public async Task<string> Create(int key, Object obj)
         {
             string urlNew = url + "/" + key ;
             try
             {
                 var serialized = JsonConvert.SerializeObject(obj);
                 StringContent sc = new StringContent(serialized, Encoding.UTF8, "json/application");
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

         public async Task<List<Object>> Load()
         {
             string urlNew = url;
             HttpResponseMessage response = _HttpClient.GetAsync(urlNew).Result;
             if (response.IsSuccessStatusCode)
             {
                 string s = await response.Content.ReadAsStringAsync();
                 return JsonConvert.DeserializeObject<List<Object>>(s);
             }
             return null;
         }


         public void Read(int key)
         {
             string urlNew = url + "/" + key;
             HttpResponseMessage response = _HttpClient.GetAsync(urlNew).Result;
             response.EnsureSuccessStatusCode();
         }



         public async Task<string> Update(int key, Object obj)
         {
             CancellationToken cancellationToken = new CancellationToken();
             string urlNew = url + "/" + key;
             string serialized = JsonConvert.SerializeObject(obj);
             StringContent sc = new StringContent(serialized, Encoding.UTF8, "json/application");
             HttpResponseMessage response = _HttpClient.PutAsync(urlNew, sc, cancellationToken).Result;
             if (response.IsSuccessStatusCode)
             {
                 return await response.Content.ReadAsStringAsync();
             }
             return null;
         }
     }
}
