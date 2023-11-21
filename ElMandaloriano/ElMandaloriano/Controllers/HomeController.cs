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
    
        //cargo la vista Misiones instanciando lista que ya estara rellena porque constructor default le da datos de clsListado misiones
        public IActionResult Misiones()
        {
            clsListadoMisionesVM lista = new clsListadoMisionesVM();
            return View(lista);
        }

        //mediante post mando a controlador id de mision seleccionada
        [HttpPost]
        public IActionResult Misiones(int id)
        {

            //creo view model que pasare a la vista
			clsListadoMisionesVM lista = new clsListadoMisionesVM();
			//creo mision a la que dare valor de mision encontrada usando el id para buscarla usando metodo GetMisionSeleccionada
			clsMision mision = lista.GetMisionSeleccionada(id);

            //uso el setter de mision para dar valor a la mision del view model
            lista.Mision=mision;

			//recargo vista pasandole el view model con los datos de la mision que necesita para rellenar campos
			return View(lista);
        }


    }
}   