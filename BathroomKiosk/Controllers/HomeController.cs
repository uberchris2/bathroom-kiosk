using System;
using System.Web.Mvc;
using BathroomKiosk.Services;

namespace BathroomKiosk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiCache _wundergroundApi = new ApiCache(new WundergroundApi());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Forecast()
        {
            var forecast = _wundergroundApi.Get("38.628144,-90.192860?exclude=minutely,hourly,alerts,flags");
            ViewBag.High = Math.Round((float)forecast.daily.data[0].temperatureHigh);
            ViewBag.Low = Math.Round((float)forecast.daily.data[0].temperatureLow);
            ViewBag.Conditions = ((string)forecast.daily.data[0].summary).Replace(".", "");
            
            return View();
        }
    }
}