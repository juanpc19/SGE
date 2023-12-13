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
        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            return clsListaPersonasBL.listadoPersonasBL();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)

        {

            IActionResult salida;
            int numFilasAfectadas = 0;
           

            try
            {
                
                numFilasAfectadas = clsManejadoraPersonaBL.deletePersonaBL(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;

        }
    }
}
