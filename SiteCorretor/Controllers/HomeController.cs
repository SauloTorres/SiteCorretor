using Microsoft.AspNetCore.Mvc;
using SiteCorretor.Data;
using SiteCorretor.Models;
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

        [HttpGet]
        public IActionResult Indexteste()
        {
            return View(_db.Residencias.ToList());
        }


        [HttpPost]
        public void VisitaResidencia(VisitResidencia visit)
        {
            if (ModelState.IsValid)
            {
                _db.VisitResidencia.Add(visit);
                _db.SaveChanges();
            }
        }

    }
}
