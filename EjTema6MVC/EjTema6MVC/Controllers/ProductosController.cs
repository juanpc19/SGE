using Microsoft.AspNetCore.Mvc;

namespace EjTema6MVC.Controllers
{
    public class ProductosController : Controller
    {
      
        public IActionResult ListadoProductos()
        {
            return View();
        }

    }
}
