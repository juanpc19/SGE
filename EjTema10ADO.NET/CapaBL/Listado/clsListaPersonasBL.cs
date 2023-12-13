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
        /// Funcion que devuelve un listado de personas extraido de DAL aplicando las reglas de negocio oportunas
        /// </summary>
        /// <returns>lista con personas</returns>
        public async Task <List<clsPersona>> listadoPersonasBL()
        {
            //EN UN MUNDO IDEAL SIN NORMAS
            clsListaPersonasDAL oDal = new clsListaPersonasDAL();

            List<clsPersona> listado = await oDal.listadoPersonasDAL();

            return listado;
        }

       
    }
}
