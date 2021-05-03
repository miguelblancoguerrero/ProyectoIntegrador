using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoIntegrador.Models;
using ProyectoIntegrador.Models.DBModels;

namespace ProyectoIntegrador.Controllers.Administrativos
{
    public class ZonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zonas
        public ActionResult Index()
        {
            var zona = db.Zona.Include(z => z.BodegaF);
            return View("/Views/Administrativas/Zonas/Index.cshtml", zona.ToList());
        }

        // GET: Zonas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Zonas/Details.cshtml", zona);
        }

        // GET: Zonas/Create
        public ActionResult Create()
        {
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo");
            return View("/Views/Administrativas/Zonas/Create.cshtml");
        }

        // POST: Zonas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Tipo,Bodega")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Zona.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", zona.Bodega);
            return View("/Views/Administrativas/Zonas/Index.cshtml", zona);
        }

        // GET: Zonas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", zona.Bodega);
            return View("/Views/Administrativas/Zonas/Edit.cshtml", zona);
        }

        // POST: Zonas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Tipo,Bodega")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", zona.Bodega);
            return View("/Views/Administrativas/Zonas/Edit.cshtml", zona);
        }

        // GET: Zonas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zona.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Zonas/Delete.cshtml", zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Zona zona = db.Zona.Find(id);
            db.Zona.Remove(zona);
            db.SaveChanges();
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
