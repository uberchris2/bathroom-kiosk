using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace BathroomKiosk.Services
{
    public class ApiCache
    {
        private readonly WeatherApi _weatherApi;

        public ApiCache(WeatherApi weatherApi)
        {
            _weatherApi = weatherApi;
        }

        public async Task<dynamic> Get()
        {
            var cachedResult = HttpContext.Current.Cache["weather"];
            if (cachedResult != null)
            {
                return cachedResult;
            }
            var response = await _weatherApi.Get();
            HttpContext.Current.Cache.Add("weather", response, null, DateTime.Now.AddMinutes(15), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            return response;
        }
    }
}