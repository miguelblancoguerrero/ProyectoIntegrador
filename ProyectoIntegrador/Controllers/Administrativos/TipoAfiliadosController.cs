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
    public class TipoAfiliadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoAfiliados
        public ActionResult Index()
        {
            return View("/Views/Administrativas/TipoAfiliados/Index.cshtml", db.TipoAfiliado.ToList());
        }

        // GET: TipoAfiliados/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAfiliado tipoAfiliado = db.TipoAfiliado.Find(id);
            if (tipoAfiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoAfiliados/Details.cshtml",tipoAfiliado);
        }

        // GET: TipoAfiliados/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/TipoAfiliados/Create.cshtml");
        }

        // POST: TipoAfiliados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre")] TipoAfiliado tipoAfiliado)
        {
            if (ModelState.IsValid)
            {
                db.TipoAfiliado.Add(tipoAfiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/TipoAfiliados/Create.cshtml", tipoAfiliado);
        }

        // GET: TipoAfiliados/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAfiliado tipoAfiliado = db.TipoAfiliado.Find(id);
            if (tipoAfiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoAfiliados/Edit.cshtml",tipoAfiliado);
        }

        // POST: TipoAfiliados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre")] TipoAfiliado tipoAfiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAfiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/TipoAfiliados/Edit.cshtml", tipoAfiliado);
        }

        // GET: TipoAfiliados/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAfiliado tipoAfiliado = db.TipoAfiliado.Find(id);
            if (tipoAfiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoAfiliados/Delete.cshtml", tipoAfiliado);
        }

        // POST: TipoAfiliados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoAfiliado tipoAfiliado = db.TipoAfiliado.Find(id);
            db.TipoAfiliado.Remove(tipoAfiliado);
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
