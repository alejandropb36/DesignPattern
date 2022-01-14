using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DesignPatternsASP.Models;
using Tools;
using Microsoft.Extensions.Options;
using DesignPatternsASP.Configuration;
using DesignPatterns.Repository;
using DesignPatterns.Models.Data;

namespace DesignPatternsASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Beer> _beerRepository;
        private readonly IOptions<MyConfig> _config;

        public HomeController(
            IOptions<MyConfig> config,
            IRepository<Beer> beerRepository
        )
        {
            _beerRepository = beerRepository;
            _config = config;
        }

        public IActionResult Index()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a index");

            IEnumerable<Beer> beers = _beerRepository.Get();
            return View("Index", beers);
        }

        public IActionResult Privacy()
        {
            Log.GetInstance(_config.Value.PathLog).Save("Entro a privacy");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
