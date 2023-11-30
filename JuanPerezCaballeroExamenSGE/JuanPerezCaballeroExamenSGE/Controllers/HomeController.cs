using Capa_Entidades;
using JuanPerezCaballeroExamenSGE.Models;
using JuanPerezCaballeroExamenSGE.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JuanPerezCaballeroExamenSGE.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            ListadosMarcasListadoModelosVM oVM = new ListadosMarcasListadoModelosVM();
            return View(oVM);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
      
            return View("CambiarPrecio");
        }

        public IActionResult CambiarPrecio()
        {
            CocheInfoCompletaVM cocheInfoCompletaVM = new CocheInfoCompletaVM();
            return View(cocheInfoCompletaVM);
        }

        [HttpPost]
        public IActionResult CambiarPrecio(double precio)
        {
            CocheInfoCompletaVM cocheInfoCompletaVM = new CocheInfoCompletaVM();
            return View(cocheInfoCompletaVM);
        }




    }
}