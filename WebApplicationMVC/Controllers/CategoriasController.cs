using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "JefeVenta")]
        public IActionResult AddCategory()
        {
            return View();
        }

        
        public IActionResult EditCategory(int Id)
        {
            var Category = _context.Categorias.Find(Id);
            if(Category == null)
            {
                return NotFound();
            }
            else
            {
                return View(Category);
            }
        }

        [Authorize(Roles = "JefeVenta")]
        [HttpPost]
        public IActionResult AddCategory(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Add(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Ocurrio un Error!");
                return View(C);
            }
        }

        [HttpPost]
        public IActionResult EditCategory(Categoria C)
        {
            if (ModelState.IsValid)
            {
                _context.Categorias.Update(C);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Ocurrio un Error!");
                return View(C);
            }
        }

        public IActionResult DeleteCategory(int Id)
        {
            var Category = _context.Categorias.Find(Id);
            if (Category == null)
            {
                return NotFound();
            }
            else
            {
                _context.Categorias.Remove(Category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }



    }
}
