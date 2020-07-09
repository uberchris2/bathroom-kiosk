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
            var forecast = await _weatherApi.Get("47.7650,-122.3457?exclude=minutely,hourly,alerts,flags");
            ViewBag.High = Math.Round((float)forecast.daily.data[0].temperatureHigh);
            ViewBag.Low = Math.Round((float)forecast.daily.data[0].temperatureLow);
            ViewBag.Conditions = ((string)forecast.daily.data[0].summary).Replace(".", "");
            
            return View();
        }
    }
}
