using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly AppDbContext _context;
        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Filtro)
        {
            
             var productos = await _context.Productos
                .Include(p => p.Categoria)
                .ToListAsync();
            
            return View(productos);
        }

        public IActionResult AddProducto()
        {
            var Categorias = _context.Categorias.ToList();
            ViewData["Perrito"] = new SelectList(Categorias, "CategoriaId", "Nombre");
            return View();
        }

        public IActionResult EditProducto(int Id)
        {
            var P = _context.Productos.Find(Id);
            if(P == null)
            {
                return NotFound();
            }
            else
            {
                var Categorias = _context.Categorias.ToList();
                ViewData["Perrito"] = new SelectList(Categorias, "CategoriaId", "Nombre");
                return View(P);
            }

            
        }

        [HttpPost]
        public async Task<IActionResult> AddProducto(Producto P)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(P);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Ha Ocurrido un Error!");
                return View(P);
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditProducto(Producto P)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Update(P);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("", "Ha Ocurrido un Error!");
                return View(P);
            }
        }

        public IActionResult DeleteProducto(int Id)
        {
            var P = _context.Productos.Find(Id);
            if (P == null)
            {
                return NotFound();
            }
            else
            {
                _context.Productos.Remove(P);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }


    }
}
