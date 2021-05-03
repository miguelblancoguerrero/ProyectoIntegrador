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
    public class BodegasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bodegas
        public ActionResult Index()
        {
            var bodega = db.Bodega.Include(b => b.MunicipioF).Include(b => b.SucursalF);
            return View("/Views/Administrativas/Bodegas/Index.cshtml", bodega.ToList());
        }

        // GET: Bodegas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodega.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Bodegas/Details.cshtml", bodega);
        }

        // GET: Bodegas/Create
        public ActionResult Create()
        {
            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo");
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo");
            return View("/Views/Administrativas/Bodegas/Create.cshtml");
        }

        // POST: Bodegas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Interna,Sucursal,Municipio,Direccion,Telefonos")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Bodega.Add(bodega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo", bodega.Municipio);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", bodega.Sucursal);
            return View("/Views/Administrativas/Bodegas/Index.cshtml", bodega);
        }

        // GET: Bodegas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodega.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo", bodega.Municipio);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", bodega.Sucursal);
            return View("/Views/Administrativas/Bodegas/Edit.cshtml", bodega);
        }

        // POST: Bodegas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Interna,Sucursal,Municipio,Direccion,Telefonos")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo", bodega.Municipio);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", bodega.Sucursal);
            return View("/Views/Administrativas/Bodegas/Edit.cshtml", bodega);
        }

        // GET: Bodegas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodega.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Bodegas/Delete.cshtml", bodega);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Bodega bodega = db.Bodega.Find(id);
            db.Bodega.Remove(bodega);
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
