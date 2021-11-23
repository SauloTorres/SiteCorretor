using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteCorretor.Data;
using SiteCorretor.Models;
using SiteCorretor.Services.Security;

namespace SiteCorretor.Areas.Admin.Controllers
{
    public class UsuarioController : AdminController
    {
        Md5Hash md5;
        //private SiteCorretorDbContext db = new SiteCorretorDbContext();
        private readonly SiteCorretorDbContext db;
        // GET: Usuario
        public IActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }


        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Login,Senha,Nome")] Usuario usuario)
        {
            md5 = new Md5Hash();
            if (ModelState.IsValid)
            {
                usuario.Senha = md5.CalculateMD5Hash(usuario.Senha);
                db.Usuarios.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public IActionResult Edit(int id)
        {
            var usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Login,Senha,Nome")] Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                md5 = new Md5Hash();
                try
                {
                    usuario.Senha = md5.CalculateMD5Hash(usuario.Senha);
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                }   
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public IActionResult Delete(int id)
        {
            var usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            return RedirectToAction(nameof(Index));
        }
    }
}
