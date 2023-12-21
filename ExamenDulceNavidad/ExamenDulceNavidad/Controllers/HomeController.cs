using ExamenDulceNavidad.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamenDulceNavidad.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

       public IActionResult Index()
        {
            return View();
        }
    }
}