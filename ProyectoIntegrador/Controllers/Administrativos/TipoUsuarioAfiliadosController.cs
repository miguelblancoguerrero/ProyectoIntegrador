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
    public class TipoUsuarioAfiliadoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoUsuarioAfiliadoes
        public ActionResult Index()
        {
            return View("/Views/Administrativas/TipoUsuarioAfiliados/Index.cshtml", db.TipoUsuarioAfiliado.ToList());
        }

        // GET: TipoUsuarioAfiliadoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarioAfiliado tipoUsuarioAfiliado = db.TipoUsuarioAfiliado.Find(id);
            if (tipoUsuarioAfiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoUsuarioAfiliados/Details.cshtml", tipoUsuarioAfiliado);
        }

        // GET: TipoUsuarioAfiliadoes/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/TipoUsuarioAfiliados/Create.cshtml");
        }

        // POST: TipoUsuarioAfiliadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre")] TipoUsuarioAfiliado tipoUsuarioAfiliado)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuarioAfiliado.Add(tipoUsuarioAfiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/TipoUsuarioAfiliados/Create.cshtm", tipoUsuarioAfiliado); ;
        }

        // GET: TipoUsuarioAfiliadoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarioAfiliado tipoUsuarioAfiliado = db.TipoUsuarioAfiliado.Find(id);
            if (tipoUsuarioAfiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoUsuarioAfiliados/Edit.cshtml", tipoUsuarioAfiliado);
        }

        // POST: TipoUsuarioAfiliadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre")] TipoUsuarioAfiliado tipoUsuarioAfiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUsuarioAfiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/TipoUsuarioAfiliados/Edit.cshtml", tipoUsuarioAfiliado);
        }

        // GET: TipoUsuarioAfiliadoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuarioAfiliado tipoUsuarioAfiliado = db.TipoUsuarioAfiliado.Find(id);
            if (tipoUsuarioAfiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/TipoUsuarioAfiliados/Delete.cshtml", tipoUsuarioAfiliado);
        }

        // POST: TipoUsuarioAfiliadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoUsuarioAfiliado tipoUsuarioAfiliado = db.TipoUsuarioAfiliado.Find(id);
            db.TipoUsuarioAfiliado.Remove(tipoUsuarioAfiliado);
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


