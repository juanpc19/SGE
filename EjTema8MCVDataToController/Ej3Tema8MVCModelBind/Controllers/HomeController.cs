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
                Telefono = 656656656
            };
            //le paso el MODELO a usar la vista para que carge correctamente con valores por defecto dados en la persona recien creada
            return View(persona);
        }

        [HttpPost]
        //recibira el modelo desde si misma (Editar) despues de instanciar la persona y hacer return View(persona);
        public IActionResult Editar(clsPersona persona)
		{
            //solicito ir a VISTA PersonaModificada y paso a esta el MODELO persona
            return View("PersonaModificada", persona);
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