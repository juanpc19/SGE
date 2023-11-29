
using CapaDAL.Conexion;
using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EjTema10ADO.NET.Controllers
{
    public class CrudController : Controller
    {

        public IActionResult Index()
        {
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

            try
            {
                ViewData["Connection"] = connection.State;
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }

            return View();
        }

        public ActionResult Listado()
        {
            try
            {
                return View(clsListaPersonasBL.listadoPersonasBL());
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
        }

        /// <summary>
        /// recibe id de persona clickeada desde view Listado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {

            try
            {
                clsPersona oPersona = clsManejadoraPersonaBL.getPersonaById(id);
                return View(oPersona);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Listado");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        public IActionResult Delete(int id)
        {
            try
            {
                clsPersona oPersona = clsManejadoraPersonaBL.getPersonaById(id);
                return View(oPersona);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
           
        }

        
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            
               int numeroFilas = clsManejadoraPersonaBL.deletePersonaBL(id);

                if (numeroFilas == 0)
                {
                    ViewBag.Info = "No existe esa persona.";
                } else if (numeroFilas == -1)
                {
                    ViewBag.Info = "Los viernes no se puede borrar personas.";
                } else
                {
                    ViewBag.Info = "Persona borrada.";
                }
            
           
            //funciona sin crash pero no borra
            return View("Listado", clsListaPersonasBL.listadoPersonasBL());
        }
    }
}
