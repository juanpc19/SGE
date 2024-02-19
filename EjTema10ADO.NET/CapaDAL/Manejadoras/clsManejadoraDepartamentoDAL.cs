using CapaDAL.Conexion;
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
    public class clsManejadoraDepartamentoDAL
    {
        /// <summary>
        /// Funcion que devuelve un departamento segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsDepartamento getDepByIdDAL(int id)
        {
            List<clsDepartamento> listaDeps = clsListaDepDAL.listadoDepartamentosDAL();
            return listaDeps.Find(x => x.Id == id);
        }

        /// <summary>
        /// funcion que crea un departamento a partir del recibido de capa BL<UI, y la inserta en la BBDD
        /// </summary>
        /// <param name="oDepartamento"></param>
        public static void createDepDAL(clsDepartamento oDepartamento)
        {
            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@Nombre", oDepartamento.NombreDep);
            command.CommandText = "INSERT INTO Departamentos (Nombre) " +
                "VALUES(@Nombre) ";

            command.Connection = connection;

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// edita un departamento de la base de datos recibida por parametros
        /// </summary>
        /// <param name="oDepartamento"></param>
        public static int editDepDAL(clsDepartamento oDepartamento)
        {
            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();
            int numeroFilasAfectadas = 0;

            command.Parameters.AddWithValue("@ID", oDepartamento.Id);
            command.Parameters.AddWithValue("@Nombre", oDepartamento.NombreDep);
            command.CommandText = "UPDATE Departamentos SET Nombre = @Nombre WHERE ID = @ID";

            command.Connection = connection;

            numeroFilasAfectadas = command.ExecuteNonQuery();

            return numeroFilasAfectadas;
        }


        /// <summary>
        /// funcion que borra un departamento de la base de datos a partir de param entrada id y devuelve filas afectadas por borrado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int deleteDepDAL(int id)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection connection = new clsMyConnectionDAL().getConnection();
            SqlCommand command = new SqlCommand();

            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.CommandText = "DELETE FROM Departamentos WHERE ID=@id";
            command.Connection = connection;

            numeroFilasAfectadas = command.ExecuteNonQuery();

            return numeroFilasAfectadas;
        }
    }
}
