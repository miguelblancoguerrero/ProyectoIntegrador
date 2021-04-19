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
    public class SucursalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sucursales
        public ActionResult Index()
        {
            var sucursal = db.Sucursal.Include(s => s.MunicipioF);
            return View("/Views/Administrativas/Sucursales/Index.cshtml", sucursal.ToList());
        }

        // GET: Sucursales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Sucursales/Details.cshtml", sucursal);
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo");
            return View("/Views/Administrativas/Sucursales/Create.cshtml");
        }

        // POST: Sucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombe,Municipio,Direccion,Telefonos")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Sucursal.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo", sucursal.Municipio);
            return View("/Views/Administrativas/Sucursales/Index.cshtml", sucursal);
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo", sucursal.Municipio);
            return View("/Views/Administrativas/Sucursales/Edit.cshtml", sucursal);
        }

        // POST: Sucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombe,Municipio,Direccion,Telefonos")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Municipio = new SelectList(db.Municipio, "Id", "Codigo", sucursal.Municipio);
            return View("/Views/Administrativas/Sucursales/Edit.cshtml", sucursal);
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.Sucursal.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Sucursales/Delete.cshtml", sucursal);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Sucursal sucursal = db.Sucursal.Find(id);
            db.Sucursal.Remove(sucursal);
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
