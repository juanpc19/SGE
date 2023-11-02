using Ej1Tema7.Models;
using Ej1Tema7.Models.DAL;
using Ej1Tema7.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ej1Tema7.Controllers

{
    public class HomeController : Controller

        //NOTAS EJ 3
        //añadir idDepartamento a clsPersona en atributo, constructor , propiedades set get 
        //crear clase con persona y listado departamento ira a viewModel/dal porque se usa solo en vista
        //desde el action se enviara el modelo dentro de viewModel/dal
        //
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

        }

        public IActionResult ListadoPersonas()
        {
            //al ser static la clase ListaPersonas es asi sin static necesito instanciar objeto
            try
            {
                return View(ListaPersonas.listadoCompletoPersonas());

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