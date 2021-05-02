using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChallenge.Models;

namespace WebChallenge.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.countryId = new SelectList(dbContext.Countries, "Id", "Name");
            return View();
        }

        public ActionResult GetForecastForCity(int countryId, int cityApiId )
        {
            Country country = dbContext.Countries.Find(countryId);
            City city = dbContext.Cities.Single(x => x.CityIdApi == cityApiId);

            ServiceWeather.ServiceWeatherClient serviceClient = new ServiceWeather.ServiceWeatherClient();
            ServiceWeather.DayForecastCompleteContract dayForecastCompleteContract = serviceClient.DayForecastForCity(cityApiId);
            ServiceWeather.WeekForecastContract weekForecastContract = serviceClient.WeekForecastForCity(cityApiId);

            ViewBag.countryName = country.Name;
            ViewBag.cityName = city.Name;
            ViewBag.cityIdSelected = city.CityIdApi;
            ViewBag.dayForecastCompleteContract = dayForecastCompleteContract;
            ViewBag.weekForecastContract = weekForecastContract;
            ViewBag.countryId = new SelectList(dbContext.Countries, "Id", "Name");

            return View("index");
        }

        public JsonResult GetCitiesForCountry(int countryId)
        {
            List<City> cities = dbContext.Cities.Where(x => x.CountryId == countryId).ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}