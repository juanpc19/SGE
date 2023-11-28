using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaBL.Manejadoras
{
    public static class clsGetPersonaBL
    {
        /// <summary>
        /// Funcion que devuelve una persona segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersona(int id)
        {
            //SERVER CASA DESKTOP-175H31S
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona = new clsPersona();
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            if (id > 0)
            {
                try
                {
                    connection.ConnectionString = "Server=DESKTOP-175H31S;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true";
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM personas WHERE ID = @id";
                    connection.Open();
                    reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        oPersona.Id = id;
                        oPersona.Nombre = (string)reader["nombre"];
                        oPersona.Apellidos = (string)reader["apellidos"];
                        oPersona.Direccion = (string)reader["direccion"];
                        oPersona.Telefono = (string)reader["telefono"];
                        oPersona.FechaNac = (DateTime)reader["fechaNacimiento"];
                        oPersona.Foto = (string)reader["foto"];
                        oPersona.IdDepartamento = (int)reader["idDepartamento"];
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return oPersona;
        }
    }
}
