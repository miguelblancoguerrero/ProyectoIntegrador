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

namespace ProyectoIntegrador.Controllers
{
    public class CausaExternasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CausaExternas
        public async Task<ActionResult> Index()
        {
            return View("/Views/Administrativas/CausaExternas/Index.cshtml",await db.CausaExterna.ToListAsync());
        }

        // GET: CausaExternas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CausaExterna causaExterna = await db.CausaExterna.FindAsync(id);
            if (causaExterna == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/CausaExterna/Details.cshtml",causaExterna);
        }

        // GET: CausaExternas/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/CausaExterna/Create.cshtml");
        }

        // POST: CausaExternas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Descripcion")] CausaExterna causaExterna)
        {
            if (ModelState.IsValid)
            {
                db.CausaExterna.Add(causaExterna);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/CausaExterna/Create.cshtml",causaExterna);
        }

        // GET: CausaExternas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CausaExterna causaExterna = await db.CausaExterna.FindAsync(id);
            if (causaExterna == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/CausaExterna/Edit.cshtml",causaExterna);
        }

        // POST: CausaExternas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Descripcion")] CausaExterna causaExterna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(causaExterna).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/CausaExterna/Edit.cshtml",causaExterna);
        }

        // GET: CausaExternas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CausaExterna causaExterna = await db.CausaExterna.FindAsync(id);
            if (causaExterna == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/CausaExterna/Delete.cshtml",causaExterna);
        }

        // POST: CausaExternas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CausaExterna causaExterna = await db.CausaExterna.FindAsync(id);
            db.CausaExterna.Remove(causaExterna);
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
