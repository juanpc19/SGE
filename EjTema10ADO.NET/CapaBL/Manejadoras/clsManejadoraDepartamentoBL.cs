using CapaDAL.Manejadoras;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Manejadoras
{
    public class clsManejadoraDepartamentoBL
    {

        /// <summary>
        /// Funcion que devuelve una persona segun su Id usando DAL aplicando las reglas de negocio oportunas
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsDepartamento getDepByIdBL(int id)
        {
            clsDepartamento oDepartamento = clsManejadoraDepartamentoDAL.getDepByIdDAL(id);

            return oDepartamento;
        }



        /// <summary>
        ///     /// Funcion que aplicara reglas de negocio pertinentes antes de darle a la capa DAL una persona que añadir a la BBDD
        /// </summary>
        /// <param name="oDepartamento"></param>
        public static void createDepBL(clsDepartamento oDepartamento)
        {
            clsManejadoraDepartamentoDAL.createDepDAL(oDepartamento);
        }

        /// <summary>
        /// Funcion que aplicara reglas de negocio pertinentes antes de darle a la capa DAL una persona que editar en la BBDD
        /// </summary>
        /// <param name="oDepartamento"></param>
        public static int editDepBL(clsDepartamento oDepartamento)
        {
            int numeroFilasAfectadas = 0;

            numeroFilasAfectadas = clsManejadoraDepartamentoDAL.editDepDAL(oDepartamento);

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// FUNCION QUE DEVUELVE EL NUMERO DE FILAS AFECTADAS  AL BORRAR LA PERSONA QUE RECIBE APLICANDO LAS REGLAS DE NEGOCIO
        /// Post: mi salida sera 0 cuando no haya errores, 1 si se ha borrado, -1 si hay error en borrado en bl
        /// </summary>
        /// <param name="id">id de la persona</param>
        /// <returns>devuelve el numero de personas afectadas</returns>
        public static int deleteDepBL(int id)
        {
            int numeroFilasAfectadas = 0;

            numeroFilasAfectadas = clsManejadoraDepartamentoDAL.deleteDepDAL(id);

            return numeroFilasAfectadas;

        }

    }
}
