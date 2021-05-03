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
    public class MaterialesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Materiales
        public ActionResult Index()
        {
            var material = db.Material.Include(m => m.MarcaF).Include(m => m.PadreF);
            return View("/Views/Administrativas/Materiales/Index.cshtml", material.ToList());
        }

        // GET: Materiales/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Materiales/Details.cshtml", material);
        }

        // GET: Materiales/Create
        public ActionResult Create()
        {
            ViewBag.Marca = new SelectList(db.Marca, "Id", "Codigo");
            ViewBag.Padre = new SelectList(db.Material, "Id", "Codigo");
            return View("/Views/Administrativas/Materiales/Create.cshtml");
        }

        // POST: Materiales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,Tipo,Padre,TemperaturaAlmacenamiento,Marca")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Marca = new SelectList(db.Marca, "Id", "Codigo", material.Marca);
            ViewBag.Padre = new SelectList(db.Material, "Id", "Codigo", material.Padre);
            return View("/Views/Administrativas/Materiales/Index.cshtml", material);
        }

        // GET: Materiales/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.Marca = new SelectList(db.Marca, "Id", "Codigo", material.Marca);
            ViewBag.Padre = new SelectList(db.Material, "Id", "Codigo", material.Padre);
            return View("/Views/Administrativas/Materiales/Edit.cshtml", material);
        }

        // POST: Materiales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Tipo,Padre,TemperaturaAlmacenamiento,Marca")] Material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Marca = new SelectList(db.Marca, "Id", "Codigo", material.Marca);
            ViewBag.Padre = new SelectList(db.Material, "Id", "Codigo", material.Padre);
            return View("/Views/Administrativas/Materiales/Edit.cshtml", material);
        }

        // GET: Materiales/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Material material = db.Material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Materiales/Delete.cshtml", material);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Material material = db.Material.Find(id);
            db.Material.Remove(material);
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
