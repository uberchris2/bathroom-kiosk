using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BathroomKiosk.Services
{
    public class WundergroundApi
    {
        public dynamic Get(string uri)
        {
            string result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.darksky.net/forecast/APIKEY/");
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