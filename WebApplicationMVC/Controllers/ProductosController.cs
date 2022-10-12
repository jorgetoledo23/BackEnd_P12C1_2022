using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
