using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoIntegrador.Models;
using ProyectoIntegrador.Models.DBModels;

namespace ProyectoIntegrador.Controllers.Administrativos
{
    public class RecetaMedicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecetaMedicas
        public async Task<ActionResult> Index()
        {
            var recetaMedica = db.RecetaMedica.Include(r => r.HistoriaMedicaF);
            return View("/Views/Administrativas/RecetaMedicas/Index.cshtml",await recetaMedica.ToListAsync());
        }

        // GET: RecetaMedicas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetaMedica recetaMedica = await db.RecetaMedica.FindAsync(id);
            if (recetaMedica == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/RecetaMedicas/Details.cshtml", recetaMedica);
        }

        // GET: RecetaMedicas/Create
        public ActionResult Create()
        {
            ViewBag.HistoriaMedica = new SelectList(db.HistoriaMedica, "Id", "Codigo");
            return View("/Views/Administrativas/RecetaMedicas/Create.cshtml");
        }

        // POST: RecetaMedicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion,Observaciones,HistoriaMedica")] RecetaMedica recetaMedica)
        {
            if (ModelState.IsValid)
            {
                db.RecetaMedica.Add(recetaMedica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.HistoriaMedica = new SelectList(db.HistoriaMedica, "Id", "Codigo", recetaMedica.HistoriaMedica);
            return View("/Views/Administrativas/RecetaMedicas/Create.cshtml", recetaMedica);
        }

        // GET: RecetaMedicas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetaMedica recetaMedica = await db.RecetaMedica.FindAsync(id);
            if (recetaMedica == null)
            {
                return HttpNotFound();
            }
            ViewBag.HistoriaMedica = new SelectList(db.HistoriaMedica, "Id", "Codigo", recetaMedica.HistoriaMedica);
            return View("/Views/Administrativas/RecetaMedicas/Edit.cshtml", recetaMedica);
        }

        // POST: RecetaMedicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion,Observaciones,HistoriaMedica")] RecetaMedica recetaMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetaMedica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HistoriaMedica = new SelectList(db.HistoriaMedica, "Id", "Codigo", recetaMedica.HistoriaMedica);
            return View("/Views/Administrativas/RecetaMedicas/Edit.cshtml", recetaMedica);
        }

        // GET: RecetaMedicas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetaMedica recetaMedica = await db.RecetaMedica.FindAsync(id);
            if (recetaMedica == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/RecetaMedicas/Delete.cshtml", recetaMedica);
        }

        // POST: RecetaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            RecetaMedica recetaMedica = await db.RecetaMedica.FindAsync(id);
            db.RecetaMedica.Remove(recetaMedica);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
