using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace BathroomKiosk.Services
{
    public class WeatherApi
    {
        public async Task<dynamic> Get()
        {
            string result;
            using (var client = new HttpClient())
            {
                var success = false;
                HttpResponseMessage response = null;
                for (var tryCount = 0; !success && tryCount < 3; tryCount++)
                {
                    response = await client.GetAsync("https://api.met.no/weatherapi/locationforecast/2.0/complete?lat=47.7650&lon=-122.3457");
                    success = response.IsSuccessStatusCode;
                }
                result = await response.Content.ReadAsStringAsync();
            }
            return JsonConvert.DeserializeObject(result);
        }
    }
    
}
