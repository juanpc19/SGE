using CapaDAL.Listado;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EjTema10ADO.NET.Controllers
{
    public class PersonasController : Controller
    {
        public IActionResult Listado()
        {
            try
            {
                return View(clsListaPersonasDAL.listadoPersonas());
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
        }
    }
}
