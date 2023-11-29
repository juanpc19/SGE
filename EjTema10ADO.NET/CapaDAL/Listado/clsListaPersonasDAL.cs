using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDAL.Listado
{
    public static class clsListaPersonasDAL
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas extraido de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoPersonas()
        {
            //SERVER CASA DESKTOP-175H31S
            //server clase 107-29\SQLEXPRESS
            List<clsPersona> listado = new List<clsPersona>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona;

            connection.ConnectionString = "Server=jpc19.database.windows.net;database=JPCBBDD;uid=prueba;pwd=fernandoG321;trustServerCertificate=true";
            command.Connection = connection;
            command.CommandText = "SELECT * FROM personas";

            try
            {
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)reader["id"];
                        oPersona.Nombre = (string)reader["nombre"];
                        oPersona.Apellidos = (string)reader["apellidos"];
                        oPersona.Direccion = (string)reader["direccion"];
                        oPersona.Telefono = (string)reader["telefono"];
                        oPersona.FechaNac = (DateTime)reader["fechaNacimiento"];
                        oPersona.Foto = (string)reader["foto"];
                        oPersona.IdDepartamento = (int)reader["idDepartamento"];
                        listado.Add(oPersona);
                    }
                }
                reader.Close();
                connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;

            }

            return listado;
        }

      
    }
}
