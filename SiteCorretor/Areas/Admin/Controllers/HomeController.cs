using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteCorretor.Data;
using SiteCorretor.Models;
using SiteCorretor.Services.Security;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SiteCorretor.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {

        private readonly SiteCorretorDbContext _db;
        public HomeController(SiteCorretorDbContext db)
        {
            _db = db;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario user)
        {
            Md5Hash md5 = new Md5Hash();
            user.Senha = md5.CalculateMD5Hash(user.Senha);
            var usuario = _db.Usuarios.FirstOrDefault(x => x.Login == user.Login && x.Senha == user.Senha);
            if(usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim("IdUser",Convert.ToString(usuario.Nome))
                };

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Usuário ou senha incorretos";
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            ViewBag.TotalResidencias = _db.Residencias.Count();
            return View();
        }
    }
}
