using Microsoft.AspNetCore.Mvc;
using CapaBL.Listado;
using CapaDAL.Listado;
using CapaEntidades;
using CapaDAL.Manejadoras;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjTema10ADO.NET.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        //// GET: api/<PersonasController>
        //[HttpGet]
        ////ESTO ES GET LISTADO, END POINT Personas, devuelve listado 
        //public IEnumerable<clsPersona> Get()
        //{
        //    return clsListaPersonasBL.listadoPersonasBL();
        //}

        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listadoCompleto = new List<clsPersona>();
         
            try
            {             
                listadoCompleto = clsListaPersonasBL.listadoPersonasBL();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        //ESTO ES GET BY ID, END POINT Personas / id, devuelve persona
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona = new clsPersona();

            try
            {
                persona = clsManejadoraPersonaBL.getPersonaByIdBL(id);
                if (persona==null)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
             
        }

        // POST api/<PersonasController>
        [HttpPost]
        //ESTO ES CREAR, END POINT Personas / id, manda persona y devuelve codigo de action
        public IActionResult Post([FromBody] clsPersona persona)
        {
            //REQUIERE POSTMAN
            IActionResult respuestaApi;
            int contadorPreInsert=0;
            //= clsListaPersonasBL.cuentaPersonasListadoBL();
            int contadorPostInsert = 0;
            string newlyCreatedResourceURI = "/api/personas/" + persona.Id; //end point donde añado persona + id de la persona que he añadido


            try
            {
                clsManejadoraPersonaBL.createPersonaBL(persona);

                //contadorPostInsert = clsListaPersonasBL.cuentaPersonasListadoBL();

                if (contadorPreInsert < contadorPostInsert)
                {
                    //devuelve codigo 201 si el check de que el end point dado contiene los datos de la persona dada es correcto
                    respuestaApi = Created(newlyCreatedResourceURI, persona);
                }
                else
                {
                    // devuelve bool tras checkear formato de post CheckForUnsupportedMediaType();
                    respuestaApi = BadRequest();
                }
            } 
            catch (Exception ex)
            {
                respuestaApi = BadRequest();
            }

            return respuestaApi;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        //ESTO ES EDITAR, END POINT Personas / id, recibe id y manda persona pero no se modifica id persona y devuelve codigo de action
        public IActionResult Put(int id, [FromBody] clsPersona persona)
        {
            //REQUIERE POSTMAN
            IActionResult respuestaApi;
            try
            {
                respuestaApi = Ok();
            }
            catch (Exception ex)
            {
                respuestaApi = BadRequest();
            }

            return respuestaApi;
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        //ESTO ES DELETE, END POINT Personas / id, recibe id  y devuelve codigo de action
        public IActionResult Delete(int id)
        {
            //REQUIERE POSTMAN
            IActionResult respuestaApi;
            int numFilasAfectadas = 0;         
            try
            {               
                numFilasAfectadas = clsManejadoraPersonaBL.deletePersonaBL(id);
                if (numFilasAfectadas == 0)
                {
                    respuestaApi = NotFound();
                }
                else
                {
                    respuestaApi = Ok();
                }
            }
            catch (Exception e)
            {
                respuestaApi = BadRequest();
            }
            return respuestaApi;

        }
    }
}
