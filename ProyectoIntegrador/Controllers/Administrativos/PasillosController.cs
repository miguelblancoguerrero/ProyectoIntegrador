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
    public class PasillosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pasillos
        public ActionResult Index()
        {
            var pasillo = db.Pasillo.Include(p => p.ZonaF);
            return View("/Views/Administrativas/Pasillos/Index.cshtml", pasillo.ToList());
        }

        // GET: Pasillos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasillo pasillo = db.Pasillo.Find(id);
            if (pasillo == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Pasillos/Details.cshtml", pasillo);
        }

        // GET: Pasillos/Create
        public ActionResult Create()
        {
            ViewBag.Zona = new SelectList(db.Zona, "Id", "Codigo");
            return View("/Views/Administrativas/Pasillos/Create.cshtml");
        }

        // POST: Pasillos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Zona")] Pasillo pasillo)
        {
            if (ModelState.IsValid)
            {
                db.Pasillo.Add(pasillo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Zona = new SelectList(db.Zona, "Id", "Codigo", pasillo.Zona);
            return View("/Views/Administrativas/Pasillos/Create.cshtml", pasillo);
        }

        // GET: Pasillos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasillo pasillo = db.Pasillo.Find(id);
            if (pasillo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Zona = new SelectList(db.Zona, "Id", "Codigo", pasillo.Zona);
            return View("/Views/Administrativas/Pasillos/Edit.cshtml", pasillo);
        }

        // POST: Pasillos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Zona")] Pasillo pasillo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pasillo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Zona = new SelectList(db.Zona, "Id", "Codigo", pasillo.Zona);
            return View("/Views/Administrativas/Pasillos/Edit.cshtml", pasillo);
        }

        // GET: Pasillos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pasillo pasillo = db.Pasillo.Find(id);
            if (pasillo == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Pasillos/Delete.cshtml", pasillo);
        }

        // POST: Pasillos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Pasillo pasillo = db.Pasillo.Find(id);
            db.Pasillo.Remove(pasillo);
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
