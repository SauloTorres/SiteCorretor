using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiteCorretor.Data;
using SiteCorretor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace SiteCorretor.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ResidenciaController : AdminController
    {
        private readonly SiteCorretorDbContext _db;
        public ResidenciaController(SiteCorretorDbContext db) 
        {
            _db = db;
            
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Residencias.ToList());
        }

        [Route(template: "residencia/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route(template: "residencia/create")]
        [HttpPost]
        public IActionResult Create(Residencia residencia, IList<IFormFile> file)
        {
            
            if (ModelState.IsValid)
            {
                _db.Add(residencia);
                _db.SaveChanges();

                string root = Environment.CurrentDirectory;
                string pathString = @"" + root + "\\Areas\\Admin\\Imagens\\Resid_" + residencia.Id;
                Directory.CreateDirectory(pathString);

                foreach (var item in file)
                {
                    var filePath = Path.Combine(pathString, item.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyToAsync(stream);
                    }
                }                
                return RedirectToAction("Index");
            }
            return View(residencia);
        }
        [Route(template: "residencia/edit")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var residencia = _db.Residencias.Find(Id);
            if (residencia == null)
            {
                return NotFound();
            }
            return View(residencia);
        }

        [Route(template: "residencia/edit")]
        [HttpPost]
        public IActionResult Edit(Residencia residencia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Attach(residencia);
                    _db.Entry(residencia).State = EntityState.Modified;
                    _db.SaveChanges();
                    RedirectToAction("Index");
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(residencia);
        }
    }
}
