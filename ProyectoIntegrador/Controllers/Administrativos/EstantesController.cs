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

namespace ProyectoIntegrador.Controllers
{
    public class EstantesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estantes
        public ActionResult Index()
        {
            var estante = db.Estante.Include(e => e.PasilloF);
            return View("/Views/Administrativas/Estantes/Index.cshtml", estante.ToList());
        }

        // GET: Estantes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Estantes/Details.cshtml", estante);
        }

        // GET: Estantes/Create
        public ActionResult Create()
        {
            ViewBag.Pasillo = new SelectList(db.Pasillo, "Id", "Codigo");
            return View("/Views/Administrativas/Estantes/Create.cshtml");
        }

        // POST: Estantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Pasillo")] Estante estante)
        {
            if (ModelState.IsValid)
            {
                db.Estante.Add(estante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pasillo = new SelectList(db.Pasillo, "Id", "Codigo", estante.Pasillo);
            return View("/Views/Administrativas/Estantes/Index.cshtml", estante);
        }

        // GET: Estantes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pasillo = new SelectList(db.Pasillo, "Id", "Codigo", estante.Pasillo);
            return View("/Views/Administrativas/Estantes/Edit.cshtml", estante);
        }

        // POST: Estantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Pasillo")] Estante estante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pasillo = new SelectList(db.Pasillo, "Id", "Codigo", estante.Pasillo);
            return View("/Views/Administrativas/Estantes/Edit.cshtml", estante);
        }

        // GET: Estantes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Estantes/Delete.cshtml", estante);
        }

        // POST: Estantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Estante estante = db.Estante.Find(id);
            db.Estante.Remove(estante);
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
