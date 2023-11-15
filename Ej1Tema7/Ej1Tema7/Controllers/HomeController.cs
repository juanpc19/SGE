using Ej1Tema7.Models;
using Ej1Tema7.Models.DAL;
using Ej1Tema7.Models.Entidades;
using Ej1Tema7.Models.ViewModels;
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

        //3 formas de pasar datos a la vista
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

        }

        public IActionResult ListadoPersonas()
        {
            //al ser static la clase ListaPersonas es asi, sin static necesitaria instanciar objeto
            try
            {
                return View(clsListaPersonas.listadoCompletoPersonas());

            } catch (Exception ex) {
                return View("Error");
            }

        }

        public IActionResult GuardarPersona(clsPersona persona) {

            return View();
        }

        public IActionResult EditarPersona()
        {
            try
            {
				//retorno una nueva instancia de PersonaListaDep que usara clsPersona vacia y List<clsDepartamento> 
				return View(new PersonaListaDep());

            } catch (Exception ex) {
                return View("Error");   
            }
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