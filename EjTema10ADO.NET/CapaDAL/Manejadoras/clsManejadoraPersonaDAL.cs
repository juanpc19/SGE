using CapaDAL.Listado;
using CapaDAL.Conexion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
    public static class clsManejadoraPersonaDAL
    {


        /// <summary>
        /// Funcion que devuelve una persona segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersonaById(int id)
        {
            List<clsPersona> listaPersonas = clsListaPersonasDAL.listadoPersonasDAL();
            return listaPersonas.Find(x => x.Id == id);
        }

        public static int deletePersonaDAL(int id)

        {
            int numeroFilasAfectadas = 0;

            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();
             
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.CommandText = "DELETE FROM Personas WHERE ID=@id";
            command.Connection = connection;

            connection.Close();
            connection.Open();
            numeroFilasAfectadas = command.ExecuteNonQuery();
            connection.Close();

            return numeroFilasAfectadas;

        }

    }
}
