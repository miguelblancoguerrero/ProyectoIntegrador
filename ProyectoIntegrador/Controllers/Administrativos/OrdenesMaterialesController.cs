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
    public class OrdenesMaterialesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrdenesMateriales
        public ActionResult Index()
        {
            var ordenMaterial = db.OrdenMaterial.Include(o => o.BodegaF).Include(o => o.MaterialF).Include(o => o.OrdenF).Include(o => o.ProveedorF);
            return View("/Views/Administrativas/OrdenesMateriales/Index.cshtml", ordenMaterial.ToList());
        }

        // GET: OrdenesMateriales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenMaterial ordenMaterial = db.OrdenMaterial.Find(id);
            if (ordenMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/OrdenesMateriales/Details.cshtml", ordenMaterial);
        }

        // GET: OrdenesMateriales/Create
        public ActionResult Create()
        {
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo");
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo");
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo");
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero");
            return View("/Views/Administrativas/OrdenesMateriales/Create.cshtml");
        }

        // POST: OrdenesMateriales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Orden,Material,Proveedor,Bodega,Cantidad")] OrdenMaterial ordenMaterial)
        {
            if (ModelState.IsValid)
            {
                db.OrdenMaterial.Add(ordenMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", ordenMaterial.Bodega);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", ordenMaterial.Material);
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo", ordenMaterial.Orden);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero", ordenMaterial.Proveedor);
            return View("/Views/Administrativas/OrdenesMateriales/Index.cshtml", ordenMaterial);
        }

        // GET: OrdenesMateriales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenMaterial ordenMaterial = db.OrdenMaterial.Find(id);
            if (ordenMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", ordenMaterial.Bodega);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", ordenMaterial.Material);
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo", ordenMaterial.Orden);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero", ordenMaterial.Proveedor);
            return View("/Views/Administrativas/OrdenesMateriales/Edit.cshtml", ordenMaterial);
        }

        // POST: OrdenesMateriales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Orden,Material,Proveedor,Bodega,Cantidad")] OrdenMaterial ordenMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", ordenMaterial.Bodega);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", ordenMaterial.Material);
            ViewBag.Orden = new SelectList(db.Orden, "Id", "Codigo", ordenMaterial.Orden);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero", ordenMaterial.Proveedor);
            return View("/Views/Administrativas/OrdenesMateriales/Edit.cshtml", ordenMaterial);
        }

        // GET: OrdenesMateriales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenMaterial ordenMaterial = db.OrdenMaterial.Find(id);
            if (ordenMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/OrdenesMateriales/Delete.cshtml", ordenMaterial);
        }

        // POST: OrdenesMateriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            OrdenMaterial ordenMaterial = db.OrdenMaterial.Find(id);
            db.OrdenMaterial.Remove(ordenMaterial);
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
