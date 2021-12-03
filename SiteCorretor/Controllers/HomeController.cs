using Microsoft.AspNetCore.Mvc;
using SiteCorretor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCorretor.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteCorretorDbContext _db;
        public HomeController(SiteCorretorDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Residencias.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
