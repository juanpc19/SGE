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
    public static class clsManejadoraPersonaDAL
    {


        /// <summary>
        /// Funcion que devuelve una persona segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersonaById(int Id)
        {
            List<clsPersona> listaPersonas = clsListaPersonasDAL.listadoPersonas();
            return listaPersonas.Find(x => x.Id == Id);
        }

        public static int deletePersonaDAL(int id)

        {
            //SERVER CASA DESKTOP-175H31S
            //server clase 107-29\SQLEXPRESS
            int numeroFilasAfectadas = 0;

            SqlConnection connection = new clsMySqlConnectionDAL();

            SqlCommand command = new SqlCommand();


            connection.ConnectionString = "Server=107-29\\SQLEXPRESS;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true;";
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try

            {

                connection.Open();

                command.CommandText = "DELETE FROM Personas WHERE ID=@id";

                command.Connection = connection;

                numeroFilasAfectadas = command.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            connection.Close();

            return numeroFilasAfectadas;

        }

    }
}
