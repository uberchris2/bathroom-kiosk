using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using BathroomKiosk.Services;

namespace BathroomKiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiCache _weatherApi = new ApiCache(new WeatherApi());

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Forecast()
        {
            var forecast = await _weatherApi.Get();
            // ViewBag.High = 
            // ViewBag.Low = Math.Round((float)forecast.daily.data[0].temperatureLow);
            ViewBag.Conditions = (string)forecast.properties.timeseries[0].data.next_12_hours.summary.symbol_code;
            
            return View();
        }
    }
}
