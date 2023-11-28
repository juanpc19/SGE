using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadoras
{
    public static class clsDeletePersonaDAL
    {
        public static int deletePersonaDAL(int id)

        {

            int numeroFilasAfectadas = 0;

            SqlConnection connection = new SqlConnection();

            SqlCommand command = new SqlCommand();

            connection.ConnectionString = ("Server=DESKTOP-175H31S;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true;");
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try

            {

                connection.Open();

                command.CommandText = "DELETE FROM Personas WHERE IDPersona=@id";

                command.Connection = connection;

                numeroFilasAfectadas = command.ExecuteNonQuery();

                connection.Close();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return numeroFilasAfectadas;

        }
    }
}
