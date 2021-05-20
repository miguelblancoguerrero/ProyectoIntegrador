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
    public class EntradasMaterialesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EntradasMateriales
        public ActionResult Index()
        {
            var entradaMaterial = db.EntradaMaterial.Include(e => e.BodegaF).Include(e => e.EntradaF).Include(e => e.MaterialF).Include(e => e.ProveedorF);
            return View("/Views/Administrativas/EntradasMateriales/Index.cshtml", entradaMaterial.ToList());
        }

        // GET: EntradasMateriales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMaterial entradaMaterial = db.EntradaMaterial.Find(id);
            if (entradaMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/EntradasMateriales/Details.cshtml", entradaMaterial);
        }

        // GET: EntradasMateriales/Create
        public ActionResult Create()
        {
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo");
            ViewBag.Entrada = new SelectList(db.Entrada, "Id", "Codigo");
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo");
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero");
            return View("/Views/Administrativas/EntradasMateriales/Create.cshtml");
        }

        // POST: EntradasMateriales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Entrada,Material,Proveedor,Bodega,Cantidad")] EntradaMaterial entradaMaterial)
        {
            if (ModelState.IsValid)
            {
                db.EntradaMaterial.Add(entradaMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", entradaMaterial.Bodega);
            ViewBag.Entrada = new SelectList(db.Entrada, "Id", "Codigo", entradaMaterial.Entrada);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", entradaMaterial.Material);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero", entradaMaterial.Proveedor);
            return View("/Views/Administrativas/EntradasMateriales/Create.cshtml", entradaMaterial);
        }

        // GET: EntradasMateriales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMaterial entradaMaterial = db.EntradaMaterial.Find(id);
            if (entradaMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", entradaMaterial.Bodega);
            ViewBag.Entrada = new SelectList(db.Entrada, "Id", "Codigo", entradaMaterial.Entrada);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", entradaMaterial.Material);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero", entradaMaterial.Proveedor);
            return View("/Views/Administrativas/EntradasMateriales/Edit.cshtml", entradaMaterial);
        }

        // POST: EntradasMateriales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Entrada,Material,Proveedor,Bodega,Cantidad")] EntradaMaterial entradaMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bodega = new SelectList(db.Bodega, "Id", "Codigo", entradaMaterial.Bodega);
            ViewBag.Entrada = new SelectList(db.Entrada, "Id", "Codigo", entradaMaterial.Entrada);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", entradaMaterial.Material);
            ViewBag.Proveedor = new SelectList(db.Proveedor, "Id", "IdentificacionNumero", entradaMaterial.Proveedor);
            return View("/Views/Administrativas/EntradasMateriales/Edit.cshtml", entradaMaterial);
        }

        // GET: EntradasMateriales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMaterial entradaMaterial = db.EntradaMaterial.Find(id);
            if (entradaMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/EntradasMateriales/Delete.cshtml", entradaMaterial);
        }

        // POST: EntradasMateriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EntradaMaterial entradaMaterial = db.EntradaMaterial.Find(id);
            db.EntradaMaterial.Remove(entradaMaterial);
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
