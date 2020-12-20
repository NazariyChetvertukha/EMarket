using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;
using WebApp.Models;
using WebApp.Services;
using AppContext = WebApp.Models.AppContext;

namespace WebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ISearchService searchService = new SearchService();
        public IActionResult Index(string query)
        {
            if (query != null)
            {
                return View(searchService.GetAllProductsByName(query));
            }
            return View(searchService.GetAll());
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
