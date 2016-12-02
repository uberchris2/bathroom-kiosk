using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BathroomKiosk.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string response;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetStringAsync("http://api.wunderground.com/api/APIKEY/forecast/q/63101.json").Result;
            }
            dynamic forecast = JsonConvert.DeserializeObject(response);
            ViewBag.High = forecast.forecast.simpleforecast.forecastday[0].high.fahrenheit;
            ViewBag.Low = forecast.forecast.simpleforecast.forecastday[0].low.fahrenheit;
            ViewBag.Conditions = forecast.forecast.simpleforecast.forecastday[0].conditions;
            
            return View();
        }
    }
}