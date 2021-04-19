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
    public class ConsultoriosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultorios
        public ActionResult Index()
        {
            var consultorio = db.Consultorio.Include(c => c.SucursalF);
            return View("/Views/Administrativas/Consultorios/Index.cshtml", consultorio.ToList());
        }

        // GET: Consultorios/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Consultorios/Details.cshtml", consultorio);
        }

        // GET: Consultorios/Create
        public ActionResult Create()
        {
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo");
            return View("/Views/Administrativas/Consultorios/Create.cshtml");
        }

        // POST: Consultorios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sucursal,Codigo,Tipo,Capacidad")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Consultorio.Add(consultorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", consultorio.Sucursal);
            return View("/Views/Administrativas/Consultorios/Index.cshtml", consultorio);
        }

        // GET: Consultorios/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", consultorio.Sucursal);
            return View("/Views/Administrativas/Consultorios/Edit.cshtml", consultorio);
        }

        // POST: Consultorios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sucursal,Codigo,Tipo,Capacidad")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", consultorio.Sucursal);
            return View("/Views/Administrativas/Consultorios/Edit.cshtml", consultorio);
        }

        // GET: Consultorios/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Consultorios/Delete.cshtml", consultorio);
        }

        // POST: Consultorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Consultorio consultorio = db.Consultorio.Find(id);
            db.Consultorio.Remove(consultorio);
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
