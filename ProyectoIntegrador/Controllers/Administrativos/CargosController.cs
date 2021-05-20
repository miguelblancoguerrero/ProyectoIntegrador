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
    public class CargosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cargos
        public ActionResult Index()
        {
            return View("/Views/Administrativas/Cargos/Index.cshtml", db.Cargo.ToList());
        }

        // GET: Cargos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Cargos/Details.cshtml", cargo);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/Cargos/Create.cshtml");
        }

        // POST: Cargos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,Tipo,Descripcion,NivelPrioridad")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargo.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/Cargos/Create.cshtml", cargo);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Cargos/Edit.cshtml", cargo);
        }

        // POST: Cargos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Tipo,Descripcion,NivelPrioridad")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/Cargos/Edit.cshtml", cargo);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargo cargo = db.Cargo.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Cargos/Delete.cshtml", cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Cargo cargo = db.Cargo.Find(id);
            db.Cargo.Remove(cargo);
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
