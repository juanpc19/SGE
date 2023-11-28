﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.SqlClient;

namespace DAL
{
    public static class clsListaPersonas
    {
        /// <summary>
        /// Funcion que devuelve un listado de personas extraido de la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<clsPersona> listadoPersonas()
        {
            List<clsPersona> listado = new List<clsPersona>();
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona;

            try
            {
                connection.ConnectionString = "Server=DESKTOP-222O0N1\\SQLEXPRESS;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true";
                command.Connection = connection;
                command.CommandText = "SELECT * FROM personas";
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

        /// <summary>
        /// Funcion que devuelve una persona segun su Id
        /// Pre: Int Id > 0
        /// Pos: Nada
        /// </summary>
        /// <returns></returns>
        public static clsPersona getPersona(int id)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            SqlDataReader reader;
            clsPersona oPersona = new clsPersona();
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            if (id > 0)
            {
                try
                {
                    connection.ConnectionString = "server=107-28\\SQLEXPRESS;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true";
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
