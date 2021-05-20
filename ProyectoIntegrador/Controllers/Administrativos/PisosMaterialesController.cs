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
    public class PisosMaterialesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PisosMateriales
        public ActionResult Index()
        {
            var pisoMaterial = db.PisoMaterial.Include(p => p.MaterialF).Include(p => p.PisoF);
            return View("/Views/Administrativas/PisosMateriales/Index.cshtml", pisoMaterial.ToList());
        }

        // GET: PisosMateriales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PisoMaterial pisoMaterial = db.PisoMaterial.Find(id);
            if (pisoMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/PisosMateriales/Details.cshtml", pisoMaterial);
        }

        // GET: PisosMateriales/Create
        public ActionResult Create()
        {
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo");
            ViewBag.Piso = new SelectList(db.Piso, "Id", "Codigo");
            return View("/Views/Administrativas/PisosMateriales/Create.cshtml");
        }

        // POST: PisosMateriales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Material,Piso,Posicion,FechaEntrada,FechaCaducidad,Cantidad")] PisoMaterial pisoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.PisoMaterial.Add(pisoMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", pisoMaterial.Material);
            ViewBag.Piso = new SelectList(db.Piso, "Id", "Codigo", pisoMaterial.Piso);
            return View("/Views/Administrativas/PisosMateriales/Create.cshtml", pisoMaterial);
        }

        // GET: PisosMateriales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PisoMaterial pisoMaterial = db.PisoMaterial.Find(id);
            if (pisoMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", pisoMaterial.Material);
            ViewBag.Piso = new SelectList(db.Piso, "Id", "Codigo", pisoMaterial.Piso);
            return View("/Views/Administrativas/PisosMateriales/Edit.cshtml", pisoMaterial);
        }

        // POST: PisosMateriales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Material,Piso,Posicion,FechaEntrada,FechaCaducidad,Cantidad")] PisoMaterial pisoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pisoMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", pisoMaterial.Material);
            ViewBag.Piso = new SelectList(db.Piso, "Id", "Codigo", pisoMaterial.Piso);
            return View("/Views/Administrativas/PisosMateriales/Edit.cshtml", pisoMaterial);
        }

        // GET: PisosMateriales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PisoMaterial pisoMaterial = db.PisoMaterial.Find(id);
            if (pisoMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/PisosMateriales/Delete.cshtml", pisoMaterial);
        }

        // POST: PisosMateriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PisoMaterial pisoMaterial = db.PisoMaterial.Find(id);
            db.PisoMaterial.Remove(pisoMaterial);
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
