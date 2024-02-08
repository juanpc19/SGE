using CapaDAL.Conexion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Listados
{
    public class clsListaMarcasDAL
    {

        public static List<clsMarca> ListadoMarcasDAL()
        {

            List<clsMarca> listado = new List<clsMarca>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsMarca oMarca;
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM marcas";

            connection.Close();
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    oMarca = new clsMarca();
                    oMarca.Id = (int)reader["Id"];
                    oMarca.Nombre = (string)reader["Nombre"];
                    listado.Add(oMarca);
                }
            }

            reader.Close();
            connection.Close();


            return listado;
        }
    }
}
