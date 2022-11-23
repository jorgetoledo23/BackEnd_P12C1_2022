using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult LoginIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginIn(LoginViewModel Lvm)
        {
            var usuarios = _context.Usuarios.ToList();
            if(usuarios.Count == 0)
            {
                Usuario U = new Usuario();
                U.Name = "Administrador";
                U.Email = "admin@inacap.cl";
                U.Username = "admin";
                U.Rol = "SuperAdministrador";

                CreatePasswordHash("123456", out byte[] passwordHash, out byte[] passwordSalt);

                U.PasswordHash = passwordHash;
                U.PasswordSalt = passwordSalt;
                _context.Usuarios.Add(U);
                _context.SaveChanges();
            }

            //admin
            var us = _context.Usuarios.Where(u => u.Username.Equals(Lvm.Username)).FirstOrDefault();
            if(us != null)
            {
                //Usuario Encontrado
                if(VerificarPass(Lvm.Password, us.PasswordHash, us.PasswordSalt))
                {
                    //Usuario y Contraseña Correctos!
                    var Claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, us.Name),
                        new Claim(ClaimTypes.NameIdentifier, Lvm.Username),
                        new Claim(ClaimTypes.Role, us.Rol)
                    };

                    //Carnet, Licencia
                    var identity = new ClaimsIdentity(Claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal =new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                        new AuthenticationProperties { IsPersistent = true }
                        );

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Usuario correcto pero contraseña mala
                    ModelState.AddModelError("", "Contraseña Incorrecta");
                    return View(Lvm);
                }


            }
            else
            {
                //Usuario No Existe
                ModelState.AddModelError("", "Usuario no Encontrado!");
                return View(Lvm);
            }



            return View();
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //administrador 123456
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerificarPass(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var pass = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return pass.SequenceEqual(passwordHash);
            }
        }


    }
}
