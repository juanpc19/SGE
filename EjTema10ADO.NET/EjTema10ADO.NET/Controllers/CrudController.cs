using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaEntidades;
using DAL;
using Microsoft.AspNetCore.Http;
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

        // GET: CRUD/Details/5
        /// <summary>
        /// recibe id de persona clickeada desde view Listado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {

            try
            {
                return View(clsGetPersonaDAL.getPersona(id));
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }

        }

        // GET: CRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRUD/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: CRUD/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRUD/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
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

        // GET: CRUD/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(clsDeletePersonaDAL.deletePersonaDAL(id));
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
           
        }

        // POST: CRUD/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
