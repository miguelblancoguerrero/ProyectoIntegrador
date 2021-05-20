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
    public class MunicipiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Municipios
        public ActionResult Index()
        {
            return View("/Views/Administrativas/Municipios/Index.cshtml", db.Municipio.ToList());
        }

        // GET: Municipios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Municipios/Details.cshtml", municipio);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/Municipios/Create.cshtml");
        }

        // POST: Municipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,Departamento")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipio.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/Municipios/Create.cshtml", municipio);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Municipios/Edit.cshtml", municipio);
        }

        // POST: Municipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Departamento")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/Municipios/Edit.cshtml", municipio);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Municipios/Delete.cshtml", municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Municipio municipio = db.Municipio.Find(id);
            db.Municipio.Remove(municipio);
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
