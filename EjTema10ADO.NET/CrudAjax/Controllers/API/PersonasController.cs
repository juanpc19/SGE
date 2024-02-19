using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAjax.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsPersona> listadoPersonas = new List<clsPersona>();
            try
            {
                listadoPersonas = clsListaPersonasBL.listadoPersonasBL();

                if (listadoPersonas.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoPersonas);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<PersonasController>/5
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsPersona persona = new clsPersona();

            try
            {
                persona = clsManejadoraPersonaBL.getPersonaByIdBL(id);
                if (persona == null)
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
        public IActionResult Post([FromBody] clsPersona persona)
        { 
            IActionResult respuestaApi;
            int contadorPreInsert = 0; 
            int contadorPostInsert = 0;
            string newlyCreatedResourceURI = "/api/personas/" + persona.Id; //end point donde añado persona + id de la persona que he añadido


            try
            {
                clsManejadoraPersonaBL.createPersonaBL(persona);

                contadorPostInsert = clsListaPersonasBL.CuentaPersonasListadoBL();

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
            catch 
            {
                respuestaApi = BadRequest();
            }

            return respuestaApi;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] clsPersona persona)
        {
            IActionResult respuestaApi;
            int numeroFilasAfectadas;

            try
            {
                numeroFilasAfectadas = clsManejadoraPersonaBL.editPersonaBL(persona); 
                if (numeroFilasAfectadas == 0)
                {
                    respuestaApi = NotFound();
                }
                else
                {
                    respuestaApi = Ok();
                }

            }
            catch
            {
                respuestaApi = BadRequest();
            }

            return respuestaApi;
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
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
            catch
            {
                respuestaApi = BadRequest();
            }
            return respuestaApi;

        }
    }
}
