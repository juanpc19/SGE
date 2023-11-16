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

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Editar(clsPersona persona)
		{
			//crear persona aqui
			if (persona == null) { 
			}
			return View("PersonaModificada");
		}

		public IActionResult PersonaModificada()
		{
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