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
    public class clsListaModelosDAL
    {
        public static List<clsModelo> ListadoModelosDAL()
        {

            List<clsModelo> listado = new List<clsModelo>();
            List<clsModelo> listadoFiltrado = new List<clsModelo>();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsModelo oModelo;
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

            command.Connection = connection;
            command.CommandText = "SELECT * FROM modelos";

            connection.Close();
            connection.Open();
            reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    oModelo = new clsModelo();
                    oModelo.Id = (int)reader["Id"];
                    oModelo.Id = (int)reader["IdMarca"]; 
                    oModelo.Nombre = (string)reader["Nombre"];
                    oModelo.Precio = (int)reader["Precio"];
                    listado.Add(oModelo);
                }
            }

            reader.Close();
            connection.Close();


            return listado;
        }
    }
}
