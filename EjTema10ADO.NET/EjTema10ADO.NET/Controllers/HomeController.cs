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
          

                return View();
            }


        }
    }