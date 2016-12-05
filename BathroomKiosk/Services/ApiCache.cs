using System;
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

        public dynamic Get(string uri)
        {
            var cachedResult = HttpContext.Current.Cache[uri];
            if (cachedResult != null)
            {
                return cachedResult;
            }
            var response = _wundergroundApi.Get(uri);
            HttpContext.Current.Cache.Add(uri, response, null, DateTime.Now.AddMinutes(15), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            return response;
        }
    }
}