using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BathroomKiosk.Services
{
    public class WundergroundApi
    {
        public dynamic Get(string uri)
        {
            string result = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.wunderground.com/api/APIKEY/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var success = false;
                Task<string> response = null;
                for (var tryCount = 0; !success && tryCount < 3; tryCount++)
                {
                    response = client.GetStringAsync(uri);
                    success = !response.IsFaulted;
                }
                result = response.Result;
            }
            return JsonConvert.DeserializeObject(result);
        }
    }
    
}