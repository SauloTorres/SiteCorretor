using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteCorretor.Data;
using SiteCorretor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SiteCorretor.Areas.Admin.Controllers
{
    public class ResidenciaController : AdminController
    {
        private readonly SiteCorretorDbContext _db;
        IWebHostEnvironment _appEnvironment;
        public ResidenciaController(SiteCorretorDbContext db, IWebHostEnvironment env) 
        {
            _db = db;
            _appEnvironment = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Residencias.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Residencia residencia, IList<IFormFile> file)
        {
            
            if (ModelState.IsValid)
            {

                

                string root = _appEnvironment.WebRootPath;
                string pathString = @"" + root + "\\itens\\Resid_" + residencia.Slug;
                Directory.CreateDirectory(pathString);

                

                foreach (var item in file)
                {
                    var filePath = Path.Combine(pathString, item.FileName);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        item.CopyToAsync(stream);
                    }
                    residencia.Image = $"Resid_{residencia.Slug}//{item.FileName}";
                }

                
                _db.Add(residencia);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(residencia);
        }
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


        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var residencia = _db.Residencias.Find(Id);
            _db.Remove(residencia);
            _db.SaveChanges();

            return View(residencia);
        }
    }
}
