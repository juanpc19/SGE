
using CapaDAL.Conexion;
using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaEntidades;
using EjTema10ADO.NET.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EjTema10ADO.NET.Controllers
{
    public class CrudController : Controller
    {

        /// <summary>
        /// conecta a la base de datos
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// muestra listado de persona extraido de base de datos
        /// </summary>
        /// <returns></returns>
        public ActionResult Listado()
        {
            try
            {
                clsPersonaListaDepVM personaPlantilla = new clsPersonaListaDepVM();
                return View(personaPlantilla);
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
                clsPersona oPersona = clsManejadoraPersonaBL.getPersonaByIdBL(id);
                return View(oPersona);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }

        }

        /// <summary>
        /// carga pagina crear a partir de VM instanciado
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            try
            {
                //vm para formato pagina
                clsPersonaListaDepVM personaPlantilla = new clsPersonaListaDepVM();
                //devuelve vista con plantilla de persona
                return View(personaPlantilla);
            }

            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }

        }

        /// <summary>
        /// recibe objetoVM al enviar post y lo usa para añadir persona a base de datos
        /// </summary>
        /// <param name="personaDatos"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateBackToList(clsPersonaListaDepVM personaDatos) //recibo objeto VM
        {
           try
            {
                //creo objeto tipo persona a partir de objeto VM propiedad Persona,
                //tendra idDepartamento proveniente de VM ya que este tiene un nombre relacionado al id en el select dropdown de la view
                //no hay que darle id la BBDD se lo dara auto
                clsPersona personaNueva = personaDatos.Persona;
                //paso la persona a create de la capa BL
                clsManejadoraPersonaBL.createPersonaBL(personaNueva);

                //devuelvo a vista listado recargando la lista de la bbdd con VM nuevo
                clsPersonaListaDepVM recargaVM = new clsPersonaListaDepVM();
                return View("Listado", recargaVM);
            } 
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }

        }

        /// <summary>
        /// recibe id persona la busca en BBDD y la muestra para editar añadiendola al VM 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            try
            {
                clsPersona persona = clsManejadoraPersonaBL.getPersonaByIdBL(id);
                clsPersonaListaDepVM personaPlantilla = new clsPersonaListaDepVM();
                personaPlantilla.Persona = persona;
                return View(personaPlantilla);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
            
        }

        /// <summary>
        /// recibe VM del cual extrae persona usa sus datos para hacer edit de la misma llamando a metodo edit de BL
        /// </summary>
        /// <param name="personaPlantilla"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditSave(clsPersonaListaDepVM personaPlantilla)
        {
            try
            {
                clsPersona personaDatos = personaPlantilla.Persona;
                clsManejadoraPersonaBL.editPersonaBL(personaDatos);

                clsPersonaListaDepVM refrescaListado = new clsPersonaListaDepVM();
                return View("Listado", refrescaListado);
                //FALLA ALGO DE LA LOGICA DEL EDIT DE DAL NO HACE UPDATE DE BBDD, o puede ser QUE SE DEBA A FALLO AL PASAR ID O ID DEPARTAMENTO en objetos
                
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
        }

       /// <summary>
       /// recibe persona de listado y la muestra en pagina de borrado
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public IActionResult Delete(int id)
        {
            try
            {
                clsPersona oPersona = clsManejadoraPersonaBL.getPersonaByIdBL(id);
                return View(oPersona);
            }
            catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
           
        }

        /// <summary>
        /// borra persona de base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            try
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

                clsPersonaListaDepVM recargaVM = new clsPersonaListaDepVM();
                return View("Listado", recargaVM);
            }
            
             catch (SqlException ex)
            {
                ViewBag.Error = $"Ha ocurrido un error en la base de datos {ex} ";
                return View("Error");
            }
        }
    }
}
