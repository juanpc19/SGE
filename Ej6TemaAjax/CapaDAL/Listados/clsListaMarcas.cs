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
    public class clsListaMarcas
    {

        public static List<clsMarca> listadoMarcasDAL()
        {

            List<clsMarca> listado = new List<clsMarca>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsMarca oDepartamento;
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM departamentos";

            connection.Close();
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    oDepartamento = new clsMarca();
                    oDepartamento.Id = (int)reader["ID"];
                    oDepartamento.Nombre = (string)reader["Nombre"];
                    listado.Add(oDepartamento);
                }
            }

            reader.Close();
            connection.Close();


            return listado;
        }
    }
}
