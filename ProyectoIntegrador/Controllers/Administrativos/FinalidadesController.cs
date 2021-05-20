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
    public class FinalidadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Finalidades
        public ActionResult Index()
        {
            return View("/Views/Administrativas/Finalidades/Index.cshtml", db.Finalidad.ToList());
        }

        // GET: Finalidades/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finalidad finalidad = db.Finalidad.Find(id);
            if (finalidad == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Finalidades/Details.cshtml", finalidad);
        }

        // GET: Finalidades/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/Finalidades/Create.cshtml");
        }

        // POST: Finalidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion")] Finalidad finalidad)
        {
            if (ModelState.IsValid)
            {
                db.Finalidad.Add(finalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/Finalidades/Create.cshtml", finalidad);
        }

        // GET: Finalidades/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finalidad finalidad = db.Finalidad.Find(id);
            if (finalidad == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Finalidades/Edit.cshtml", finalidad);
        }

        // POST: Finalidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion")] Finalidad finalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/Finalidades/Edit.cshtml", finalidad);
        }

        // GET: Finalidades/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finalidad finalidad = db.Finalidad.Find(id);
            if (finalidad == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Finalidades/Delete.cshtml", finalidad);
        }

        // POST: Finalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Finalidad finalidad = db.Finalidad.Find(id);
            db.Finalidad.Remove(finalidad);
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
