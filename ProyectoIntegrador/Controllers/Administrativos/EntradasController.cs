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
    public class EntradasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Entradas
        public ActionResult Index()
        {
            var entrada = db.Entrada.Include(e => e.OrdenF);
            return View("/Views/Administrativas/Entradas/Index.cshtml", entrada.ToList());
        }

        // GET: Entradas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entrada.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Entradas/Details.cshtml", entrada);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo");
            return View("/Views/Administrativas/Entradas/Create.cshtml");
        }

        // POST: Entradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Fecha,Orden,factura")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entrada.Add(entrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo", entrada.Orden);
            return View("/Views/Administrativas/Entradas/Create.cshtml", entrada);
        }

        // GET: Entradas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entrada.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo", entrada.Orden);
            return View("/Views/Administrativas/Entradas/Edit.cshtml", entrada);
        }

        // POST: Entradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Fecha,Orden,factura")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo", entrada.Orden);
            return View("/Views/Administrativas/Entradas/Edit.cshtml", entrada);
        }

        // GET: Entradas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entrada.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Entradas/Delete.cshtml", entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Entrada entrada = db.Entrada.Find(id);
            db.Entrada.Remove(entrada);
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
