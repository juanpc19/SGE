using CapaBL.Listados;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej6TemaAjax.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        // GET: api/<ModelosController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsModelo> listadoModelos = new List<clsModelo>();
            try
            {
                listadoModelos = clsListaModelosBL.ListadoModelosBL();

                if (listadoModelos.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoModelos);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<ModelosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ModelosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModelosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] clsModelo modeloRecibido)
        {
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

        // DELETE api/<ModelosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
