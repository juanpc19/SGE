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

		//action carga pagina primera vez o f5
		public IActionResult Index()
		{
			return View();
		}
		
		//action envia datos al pulsar el boton
		[HttpPost]
		//al enviar recargara el index para recibir el parametro y luego hacer el return de la vista Saludo que se cargara con el valor nombre
        public IActionResult Index(string nombre)
		{
			ViewBag.nombre = nombre;//mando a vista Saludo el nombre en viewbag
            return View("Saludo");//el return view sera el que me mande a view Saludo
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