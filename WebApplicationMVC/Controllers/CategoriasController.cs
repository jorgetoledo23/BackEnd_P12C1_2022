using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Mostrar Todas las Categorias
            return View(_context.Categorias.ToList());
        }
    }
}
