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
    public class PisosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pisos
        public ActionResult Index()
        {
            var piso = db.Piso.Include(p => p.EstanteF);
            return View("/Views/Administrativas/Pisos/Index.cshtml", piso.ToList());
        }

        // GET: Pisos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piso piso = db.Piso.Find(id);
            if (piso == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Pisos/Details.cshtml", piso);
        }

        // GET: Pisos/Create
        public ActionResult Create()
        {
            ViewBag.Estante = new SelectList(db.Estante, "Id", "Codigo");
            return View("/Views/Administrativas/Pisos/Create.cshtml");
        }

        // POST: Pisos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Estante")] Piso piso)
        {
            if (ModelState.IsValid)
            {
                db.Piso.Add(piso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estante = new SelectList(db.Estante, "Id", "Codigo", piso.Estante);
            return View("/Views/Administrativas/Pisos/Create.cshtml", piso);
        }

        // GET: Pisos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piso piso = db.Piso.Find(id);
            if (piso == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estante = new SelectList(db.Estante, "Id", "Codigo", piso.Estante);
            return View("/Views/Administrativas/Pisos/Edit.cshtml", piso);
        }

        // POST: Pisos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Estante")] Piso piso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(piso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estante = new SelectList(db.Estante, "Id", "Codigo", piso.Estante);
            return View("/Views/Administrativas/Pisos/Edit.cshtml", piso);
        }

        // GET: Pisos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Piso piso = db.Piso.Find(id);
            if (piso == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Pisos/Delete.cshtml", piso);
        }

        // POST: Pisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Piso piso = db.Piso.Find(id);
            db.Piso.Remove(piso);
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
