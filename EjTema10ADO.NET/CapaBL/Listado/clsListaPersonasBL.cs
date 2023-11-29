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
        /// Funcion que devuelve una persona segun su Id usando DAL aplicando las reglas de negocio oportunas
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersona(int id)
        {
            //EN UN MUNDO IDEAL SIN NORMAS
            clsPersona oPersona = clsManejadoraPersonaDAL.getPersonaById(id);
            
            return oPersona;
        }
    }
}
