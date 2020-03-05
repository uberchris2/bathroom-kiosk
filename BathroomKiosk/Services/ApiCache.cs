using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace BathroomKiosk.Services
{
    public class ApiCache
    {
        private readonly WundergroundApi _wundergroundApi;

        public ApiCache(WundergroundApi wundergroundApi)
        {
            _wundergroundApi = wundergroundApi;
        }

        public async Task<dynamic> Get(string uri)
        {
            var cachedResult = HttpContext.Current.Cache[uri];
            if (cachedResult != null)
            {
                return cachedResult;
            }
            var response = await _wundergroundApi.Get(uri);
            HttpContext.Current.Cache.Add(uri, response, null, DateTime.Now.AddMinutes(15), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            return response;
        }
    }
}