using EjTema8MCVDataToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjTema8MCVDataToController.Controllers
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

		//le digo al controller Home en el action Saludo que parametro que va a recibir desde el action link de Vista Index es nombre
		public IActionResult Saludo(string nombre)
		{
			//y uso el ViewBag para pasar el nombre a la vista
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