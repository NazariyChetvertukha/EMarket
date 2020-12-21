using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class MapController : Controller
    {
        IGeolocationService geoService = new GeolocationService();
        public IActionResult PointsOfProduction()
        {
            ViewBag.Locations = geoService.GetGeolocations();
            
            return View();
        }
    }
}