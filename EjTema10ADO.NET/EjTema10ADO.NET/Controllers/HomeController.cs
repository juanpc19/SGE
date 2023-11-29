using EjTema10ADO.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using CapaDAL.Listado;
using CapaDAL.Manejadoras;
using CapaDAL.Conexion;

namespace EjTema10ADO.NET.Controllers
{
    

        public class HomeController : Controller
        {
            public IActionResult Index()
            {
            //SERVER CASA DESKTOP-175H31S
            //server clase 107-29\SQLEXPRESS
            SqlConnection connection = new clsMyConnectionDAL().getConnection();

                try
                {
                     
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