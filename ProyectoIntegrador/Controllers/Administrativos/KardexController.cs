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
    public class KardexController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kardex
        public ActionResult Index()
        {
            var kardex = db.Kardex.Include(k => k.BodegaF).Include(k => k.MaterialF);
            return View("/Views/Administrativas/Kardex/Index.cshtml", kardex.ToList());
        }

        // GET: Kardex/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kardex kardex = db.Kardex.Find(id);
            if (kardex == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Kardex/Details.cshtml", kardex);
        }

        // GET: Kardex/Create
        public ActionResult Create()
        {
            ViewBag.Bodega = new SelectList(db.Material, "Id", "Codigo");
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo");
            return View("/Views/Administrativas/Kardex/Create.cshtml");
        }

        // POST: Kardex/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,Bodega,Fecha,Concepto,Descripcion,ValorUnitario,MovimientoTipo,MovimientoCantidad,MovimientoValorTotal")] Kardex kardex)
        {
            if (ModelState.IsValid)
            {
                db.Kardex.Add(kardex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bodega = new SelectList(db.Material, "Id", "Codigo", kardex.Bodega);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", kardex.Material);
            return View("/Views/Administrativas/Kardex/Create.cshtml", kardex);
        }

        // GET: Kardex/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kardex kardex = db.Kardex.Find(id);
            if (kardex == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bodega = new SelectList(db.Material, "Id", "Codigo", kardex.Bodega);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", kardex.Material);
            return View("/Views/Administrativas/Kardex/Edit.cshtml", kardex);
        }

        // POST: Kardex/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,Bodega,Fecha,Concepto,Descripcion,ValorUnitario,MovimientoTipo,MovimientoCantidad,MovimientoValorTotal")] Kardex kardex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kardex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bodega = new SelectList(db.Material, "Id", "Codigo", kardex.Bodega);
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", kardex.Material);
            return View("/Views/Administrativas/Kardex/Edit.cshtml", kardex);
        }

        // GET: Kardex/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kardex kardex = db.Kardex.Find(id);
            if (kardex == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Kardex/Delete.cshtml", kardex);
        }

        // POST: Kardex/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Kardex kardex = db.Kardex.Find(id);
            db.Kardex.Remove(kardex);
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
