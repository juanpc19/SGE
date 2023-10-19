using Ej4Tema6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ej4Tema6.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

      
    }
}