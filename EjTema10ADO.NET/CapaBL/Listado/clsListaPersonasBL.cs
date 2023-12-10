using CapaDAL.Manejadoras;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace CapaDAL.Listado
{
    public class clsListaPersonasBL
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas extraido de DAL aplicando las reglas de negocio oportunas teniendo en cuenta la asincronia
        /// </summary>
        /// <returns>lista con personas</returns>
        public async Task<List<clsPersona>> listadoPersonasBL()
        {
            //creo instancia de la clase de listados de personas de DAL, necesario en lugar de estatico por asincronia
            clsListaPersonasDAL oDal = new clsListaPersonasDAL();

            //creo el listado y le indico que valor a recibir es asincrono con await
            List<clsPersona> listado = await oDal.listadoPersonasDAL();

            //EN UN MUNDO IDEAL SIN NORMAS devuelvo el listado sin hacer nada mas
            return listado;
        }

        
    }
}
