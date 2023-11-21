using ElMandaloriano.Models;
using ElMandaloriano.Models.DAL;
using ElMandaloriano.Models.Entities;
using ElMandaloriano.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Emit;

namespace ElMandaloriano.Controllers
{
    public class HomeController : Controller
    {
    
        //creo la vista instanciando lista que ya estara rellena porque constructor default le da datos de clsListado misiones
        public IActionResult Misiones()
        {
            clsListadoMisionesVM lista = new clsListadoMisionesVM();
            return View(lista);
        }

        //tras hacer post al enviar form recarco pagina con mision seleccionada
        [HttpPost]
        public IActionResult Misiones(string id)
        {
            //quizas meter codigo aqui para usar valores de clsMision?
            

            return View(mision);
        }


    }
}   