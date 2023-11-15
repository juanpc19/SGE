using Ej2Tema8MVCPost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ej2Tema8MVCPost.Controllers
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
			return View();
		}

		//indico que el index hara un post en una accion dada(pulsar boton enviar)
		[HttpPost]
        //indico lo que recibira la accion Index tipo HttpPost para mandar a vistaSaludo (nombre)
		//debo quitar param entrada de aqui pero peta si lo hago y peta si quito el otro index
        public IActionResult Index(string nombre)
		{
            return View();
        }

		//indico lo que recibira vista Saludo (nombre)
		public IActionResult Saludo(string nombre)
		{
			// y se lo paso con ViewBag
            ViewBag.nombre = nombre;
            return View();
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