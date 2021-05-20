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
    public class ProveedorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Proveedor
        public ActionResult Index()
        {
            var proveedor = db.Proveedor.Include(p => p.MunicipioRecideF);
            return View("/Views/Administrativas/Proveedor/Index.cshtml", proveedor.ToList());
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Proveedor/Details.cshtml", proveedor);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            ViewBag.MunicipioRecide = new SelectList(db.Municipio, "Id", "Codigo");
            return View("/Views/Administrativas/Proveedor/Create.cshtml");
        }

        // POST: Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdentificacionTipo,IdentificacionNumero,Nombres,PrimerApellido,SegundoApellido,MunicipioRecide")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MunicipioRecide = new SelectList(db.Municipio, "Id", "Codigo", proveedor.MunicipioRecide);
            return View("/Views/Administrativas/Proveedor/Create.cshtml", proveedor);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.MunicipioRecide = new SelectList(db.Municipio, "Id", "Codigo", proveedor.MunicipioRecide);
            return View("/Views/Administrativas/Proveedor/Edit.cshtml", proveedor);
        }

        // POST: Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdentificacionTipo,IdentificacionNumero,Nombres,PrimerApellido,SegundoApellido,MunicipioRecide")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MunicipioRecide = new SelectList(db.Municipio, "Id", "Codigo", proveedor.MunicipioRecide);
            return View("/Views/Administrativas/Proveedor/Edit.cshtml", proveedor);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Proveedor/Delete.cshtml", proveedor);
        }

        // POST: Proveedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedor);
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
