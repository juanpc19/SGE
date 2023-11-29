
using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EjTema10ADO.NET.Controllers
{
    public class CrudController : Controller
    {
        // GET: CRUD
        //SOBRA
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
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

        // GET: CRUD/Details/5
        /// <summary>
        /// recibe id de persona clickeada desde view Listado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {

            try
            {
                clsPersona oPersona = clsManejadoraPersonaDAL.getPersonaById(id);
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

       
        public ActionResult Delete(int id)
        {
            try
            {
                clsPersona oPersona = clsManejadoraPersonaDAL.getPersonaById(id);
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
        //cambiar pesona por id
        public ActionResult DeletePost(clsPersona oPersona)
        {
            try
            {
                //cambiar por BL     y los view bags van a pagina ka la k redirija
               int numeroFilas clsManejadoraPersonaDAL.deletePersonaDAL(oPersona.Id);
                if (numeroFilas == 0)
                {
                    ViewBag.Info = "no existe esa persona";
                } else if (numeroFilas == -1)
                {
                    ViewBag.Info = "los viernes no se borra";
                } else
                {
                    ViewBag.Info = "persona borrada";
                }
            } 
            catch 
            {
                ViewBag.Error = "error";
                return RedirectToAction("Error");
            }
            

            return RedirectToAction("Listado");
        }
    }
}
