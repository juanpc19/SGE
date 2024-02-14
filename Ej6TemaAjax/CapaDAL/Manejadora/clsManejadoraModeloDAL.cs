using CapaDAL.Conexion;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL.Manejadora
{
    public class clsManejadoraModeloDAL
    {
        public static int editModeloDAL(clsModelo modelo)
        {
            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();
            int numeroFilasAfectadas;

            command.Parameters.AddWithValue("@Id", modelo.Id);
            command.Parameters.AddWithValue("@IdMarca", modelo.IdMarca);
            command.Parameters.AddWithValue("@Nombre", modelo.Nombre);
            command.Parameters.AddWithValue("@Precio", modelo.Precio);
 

            command.CommandText = "UPDATE Modelos SET Precio = @Precio, " +
                                 "IdMarca = @IdMarca, " +
                                 "Nombre = @Nombre " +
                                 "WHERE ID = @Id";

            command.Connection = connection;

            numeroFilasAfectadas = command.ExecuteNonQuery();

            return numeroFilasAfectadas;

        }
    }
}
