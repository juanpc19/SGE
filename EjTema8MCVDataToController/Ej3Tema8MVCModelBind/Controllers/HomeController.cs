using Ej3Tema8MVCModelBind.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ej3Tema8MVCModelBind.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
        }

    //quito index y toco programs.cs para cambiar esto
    // app.MapControllerRoute(
    // name: "default",
	//pattern: "{controller=Home}/{action=Index}/{id?}");
    // por esto

    // app.MapControllerRoute(
    //  name: "default",
	// pattern: "{controller=Home}/{action=Editar}/{id?}");
       
        //Cargo Editar desde el principio con persona dando valores por defecto
        public IActionResult Editar()
        {
            //Instancio una persona y le doy valores
            clsPersona persona = new clsPersona()
            {
                Id = 1,
                Nombre = "Juan",
                Apellidos = "Pérez Caballero",
                FechaNac = "03/05/1994",
                Direccion = "Calle Florencia",
                Telefono = "656656656"
            };
            //le paso el MODELO a usar la vista para que carge correctamente con valores por defecto dados en la persona recien creada
            return View(persona);
        }

        [HttpPost]
        //recibira el modelo desde si misma (Editar) despues de instanciar la persona y hacer return View(persona);
        public IActionResult Editar(clsPersona persona)
		{
            //creo variable que guarda el resultado del action enviar form mediante post
            IActionResult action;

            //si comprobacion de model state no es correcta
            if (!ModelState.IsValid)
            {
                //hago que la action sea recargar la vista actual para corregir datos
                action=View(persona);
            } else {
                // de lo contrario la comprobacion ha ido bien por lo que hago que el action lleve a la vista deseada
                //VISTA PersonaModificada y paso a esta el MODELO persona
                action = View("PersonaModificada", persona);
            }

            //devuelvo action que contendra 1 de 2 posibles valores
            return action;
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