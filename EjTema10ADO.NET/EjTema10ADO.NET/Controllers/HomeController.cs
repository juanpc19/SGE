using EjTema10ADO.NET.Models;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using DAL;

namespace EjTema10ADO.NET.Controllers
{
    

        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                SqlConnection connection = new SqlConnection();

                try
                {
                    connection.ConnectionString = "Server=DESKTOP-222O0N1\\SQLEXPRESS;database=Personas;uid=prueba;pwd=123;trustServerCertificate=true";
                    connection.Open();
                    ViewData["Connection"] = connection.State;
                }
                catch (SqlException ex)
                {
                    ViewBag.Connection = $"Error: {ex.Message}";
                }

                return View();
            }

            public IActionResult Listado()
            {
                try
                {
                    return View(clsListaPersonas.listadoPersonas());
                }
                catch (SqlException ex)
                {
                    ViewBag.Error = "Ha ocurrido un error en la base de datos";
                    return View("Error");
                }
            }

            public IActionResult Delete(int id)
            {
                try
                {
                    return View(clsListaPersonas.getPersona(id));
                }
                catch (SqlException ex)
                {
                    ViewBag.Error = "Ha ocurrido un error en la base de datos";
                    return View("Error");
                }
            }
        }
    }