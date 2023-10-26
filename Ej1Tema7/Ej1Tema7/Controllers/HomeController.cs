using Ej1Tema7.Models;
using Ej1Tema7.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ej1Tema7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DateTime momentoActual = DateTime.Now;

            momentoActual.ToLongDateString();

            string momentoActualLong = momentoActual.ToLongDateString();

            int hour = momentoActual.Hour;

            string mensaje = "";

            clsPersona persona = new clsPersona();
            persona.Nombre = "Juan";
            persona.Apellidos = "Perez Caballero";

            if (hour >= 7 && hour <=13) 
            {
                mensaje = "Buenos dias.";
            }

            if (hour >=14 && hour <= 20)
            {
                mensaje = "Buenas tardes.";
            }

            if (hour >= 21 && hour <= 6)
            {
                mensaje = "Buenas noches.";
            }

            ViewData["Mensaje"] = mensaje;

            ViewBag.MomentoActualLong=momentoActualLong;



            return View(persona);

            //crear vista nueva(hecho) esta vista recibe cosa de controlador Home otra vez(este)
            //en html de index hacer lo de link del otro ej ,
            //hacer otro action,
            //dal de acceso a datos falsos,
            //clase que devuelve array personas

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}