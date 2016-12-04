using System.Web.Mvc;
using BathroomKiosk.Services;

namespace BathroomKiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly WundergroundApi _wundergroundApi = new WundergroundApi();

        public ActionResult Index()
        {
            var forecast = _wundergroundApi.Get("forecast/q/63101.json");
            ViewBag.High = forecast.forecast.simpleforecast.forecastday[0].high.fahrenheit;
            ViewBag.Low = forecast.forecast.simpleforecast.forecastday[0].low.fahrenheit;
            ViewBag.Conditions = forecast.forecast.simpleforecast.forecastday[0].conditions;
            
            return View();
        }
    }
}