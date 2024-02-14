using CapaBL.Listados;
using CapaEntidades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ej6TemaAjax.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        // GET: api/<MarcasController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<clsMarca> listadoMarcas = new List<clsMarca>();
            try
            {
                listadoMarcas = clsListaMarcasBL.ListadoMarcasBl();

                if (listadoMarcas.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoMarcas);
                }
            }
            catch 
            {
                salida = BadRequest();
            }
            return salida;
        }

        // GET api/<MarcasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MarcasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MarcasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MarcasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
