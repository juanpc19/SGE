using CapaBL.Listado;
using CapaBL.Manejadoras;
using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAjax.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        // GET: api/<DepartamentosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsDepartamento> listadoDepartamentos = new List<clsDepartamento>();
            try
            {
                listadoDepartamentos = clsListaDepBL.listadoDepartamentosBL();

                if (listadoDepartamentos.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoDepartamentos);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<DepartamentosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            clsDepartamento departamento = new clsDepartamento();

            try
            {
                departamento = clsManejadoraDepartamentoBL.getDepByIdBL(id);
                if (departamento == null)
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

        // POST api/<DepartamentosController>
        [HttpPost]
        public IActionResult Post([FromBody] clsDepartamento departamento)
        {
            IActionResult respuestaApi;
            int contadorPreInsert = 0;
            int contadorPostInsert = 0;
            string newlyCreatedResourceURI = "/api/departamentos/" + departamento.Id; //end point donde añado persona + id de la persona que he añadido


            try
            {
                clsManejadoraDepartamentoBL.createDepBL(departamento);

                contadorPostInsert = clsListaDepBL.CuentaDepsListadoBL();

                if (contadorPreInsert < contadorPostInsert)
                {
                    //devuelve codigo 201 si el check de que el end point dado contiene los datos de la persona dada es correcto
                    respuestaApi = Created(newlyCreatedResourceURI, departamento);
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

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] clsDepartamento departamento)
        {
            IActionResult respuestaApi;
            int numeroFilasAfectadas;

            try
            {
                numeroFilasAfectadas = clsManejadoraDepartamentoBL.editDepBL(departamento);
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

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult respuestaApi;
            int numFilasAfectadas = 0;
            try
            {
                numFilasAfectadas = clsManejadoraDepartamentoBL.deleteDepBL(id);
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
