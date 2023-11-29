using CapaDAL.Listado;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
    public static class clsManejadoraPersonaBL
    {


        /// <summary>
        /// Funcion que devuelve una persona segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersonaById(int Id)
        {
            List<clsPersona> listaPersonas = clsListaPersonasDAL.listadoPersonasDAL();
            return listaPersonas.Find(x => x.Id == Id);
        }

        /// <summary>
        /// FUNCION QUE DEVUELVE EL NUMERO DE FILAS AFECTADAS  AL BORRAR LA PERSONA QUE RECIBE APLICANDO LAS REGLAS DE NEGOCIO
        /// Post: mi salida sera 0 cuando no haya errores, 1 si se ha borrado, -1 si hay error en borrado en bl
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <returns>devuelve el numero de personas afectadas</returns>
        public static int deletePersonaBL(int id)
        {
            int numeroFilasAfectadas = 0;
            
            DateTime fechaActual = DateTime.Now;    

            if(fechaActual.DayOfWeek==DayOfWeek.Friday)
            {
                numeroFilasAfectadas = -1;
            } else {
                numeroFilasAfectadas = clsManejadoraPersonaDAL.deletePersonaDAL(id);
            }
            return numeroFilasAfectadas;

        }

        

    }
}
