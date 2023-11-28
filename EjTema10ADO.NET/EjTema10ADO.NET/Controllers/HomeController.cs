using EjTema10ADO.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL;
using CapaDAL.Listado;
using CapaDAL.Manejadoras;

namespace EjTema10ADO.NET.Controllers
{
    

        public class HomeController : Controller
        {
            public IActionResult Index()
            {
            //SERVER CASA DESKTOP-175H31S
            SqlConnection connection = new SqlConnection();

                try
                {
                    connection.ConnectionString = "Server=DESKTOP-175H31S;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true";
                    connection.Open();
                    ViewData["Connection"] = connection.State;
                }
                catch (SqlException ex)
                {
                    ViewBag.Connection = $"Ha ocurrido un error en la base de datos {ex} ";
                    return View("Error");
                }

                return View();
            }


        }
    }