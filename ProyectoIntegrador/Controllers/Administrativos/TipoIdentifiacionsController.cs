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
    public class TipoIdentifiacionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoIdentifiacions
        public ActionResult Index()
        {
            return View("/Views/Administrativas/TipoIdentifiacions/Index.cshtml", db.TipoIdentifiacion.ToList());
        }

        // GET: TipoIdentifiacions/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIdentifiacion tipoIdentifiacion = db.TipoIdentifiacion.Find(id);
            if (tipoIdentifiacion == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoIdentifiacions/Details.cshtml", tipoIdentifiacion);
        }

        // GET: TipoIdentifiacions/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/TipoIdentifiacions/Create.cshtml");
        }

        // POST: TipoIdentifiacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] TipoIdentifiacion tipoIdentifiacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoIdentifiacion.Add(tipoIdentifiacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/TipoIdentifiacions/Create.cshtml", tipoIdentifiacion);
        }

        // GET: TipoIdentifiacions/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIdentifiacion tipoIdentifiacion = db.TipoIdentifiacion.Find(id);
            if (tipoIdentifiacion == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoIdentifiacions/Edit.cshtml", tipoIdentifiacion);
        }

        // POST: TipoIdentifiacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] TipoIdentifiacion tipoIdentifiacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoIdentifiacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoIdentifiacion);
        }

        // GET: TipoIdentifiacions/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoIdentifiacion tipoIdentifiacion = db.TipoIdentifiacion.Find(id);
            if (tipoIdentifiacion == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoIdentifiacions/Delete.cshtml", tipoIdentifiacion);
        }

        // POST: TipoIdentifiacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoIdentifiacion tipoIdentifiacion = db.TipoIdentifiacion.Find(id);
            db.TipoIdentifiacion.Remove(tipoIdentifiacion);
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
