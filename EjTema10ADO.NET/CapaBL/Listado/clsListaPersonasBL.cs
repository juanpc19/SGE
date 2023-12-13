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
    public static class clsListaPersonasBL
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas extraido de DAL aplicando las reglas de negocio oportunas
        /// </summary>
        /// <returns>lista con personas</returns>
        public static List<clsPersona> listadoPersonasBL()
        {
            //EN UN MUNDO IDEAL SIN NORMAS
            List<clsPersona> listado = clsListaPersonasDAL.listadoPersonasDAL();

            return listado;
        }

        /// <summary>
        /// funcion que devolvera cantidad de personas en la base de datos aplicando las reglas de negocio oportunas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int cuentaPersonasListadoBL()
        {
            int contador = 0;

            contador = clsListaPersonasDAL.cuentaPersonasListadoDAL();

            return contador;
        }
    }
}
