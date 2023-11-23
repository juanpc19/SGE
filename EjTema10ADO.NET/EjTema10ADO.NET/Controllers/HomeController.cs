using EjTema10ADO.NET.Models;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
 

namespace EjTema10ADO.NET.Controllers
{
    public class HomeController : Controller
    {

        //miConexion.Close();  //cierra conexion
        //miConexion.Dispose();  //se deshace de la conexion?
        // ViewData["conexion"] = miConexion.State;
        // ViewData["conexion"] = "Error: Conexion fallida";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

                    SqlConnection miConexion = new SqlConnection();

                    List<clsPersona> listadoPersonas = new List<clsPersona>();

                    SqlCommand miComando = new SqlCommand();

                    SqlDataReader miLector;

                    clsPersona oPersona;

                    miConexion.ConnectionString = "server=107-29\\SQLEXPRESS;database=Personas;uid=prueba;pwd=123;";

                    try
                    {
                        miConexion.Open();
                        miComando.CommandText = "SELECT * FROM personas";
                        miComando.Connection = miConexion;
                        miLector = miComando.ExecuteReader();

                        if (miLector.HasRows)
                        {
                            while (miLector.Read())
                            {
                                oPersona = new clsPersona();

                                oPersona.Id = (int)miLector["IDPersona"];

                                oPersona.Nombre = (string)miLector["nombre"];

                                oPersona.Apellidos = (string)miLector["apellidos"];

                                //Si sospechamos que el campo puede ser Null en la BBDD
                                if (miLector["fechaNac"] != System.DBNull.Value)

                                { oPersona.FechaNac = (DateTime)miLector["fechaNac"]; }

                                oPersona.Direccion = (string)miLector["direccion"];

                                oPersona.Telefono = (string)miLector["telefono"];

                                listadoPersonas.Add(oPersona);

                            }

                        }

                        miLector.Close();
                        miConexion.Close();

                    return View();

                    }

                    catch (SqlException exSql)
                    {
                        throw exSql;
                    }

            catch (Exception ex)
            {
                ViewBag.Error = "Ha ocurrido un erorr con la base de datos";
                return View("Error");
            }
        }

        public IActionResult Delete()
        {
            return View();

        }
    }
}