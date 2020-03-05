using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BathroomKiosk.Services
{
    public class WeatherApi
    {
        public async Task<dynamic> Get(string uri)
        {
            string result;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.darksky.net/forecast/APIKEY/");
                var success = false;
                HttpResponseMessage response = null;
                for (var tryCount = 0; !success && tryCount < 3; tryCount++)
                {
                    response = await client.GetAsync(uri);
                    success = response.IsSuccessStatusCode;
                }
                result = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject(result);
        }
    }
    
}