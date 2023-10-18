using Microsoft.AspNetCore.Mvc;

namespace EjTema6MVC.Controllers
{
    public class HomeController : Controller
    {
        

        //hola mundo
        public IActionResult Index()
        {
            return View();
        }
    }
}
