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

namespace ProyectoIntegrador.Controllers
{
    public class AfiliadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Afiliados
        public ActionResult Index()
        {
            var afiliado = db.Afiliado.Include(a => a.PersonaF).Include(a => a.RecidenciaMunicipioF).Include(a => a.TipoAfiliadoF).Include(a => a.TipoUsuarioF);
            return View("/Views/Administrativas/Afiliados/Index.cshtml", afiliado.ToList());
        }

        // GET: Afiliados/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliado.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Afiliados/Details.cshtml", afiliado);
        }

        // GET: Afiliados/Create
        public ActionResult Create()
        {
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero");
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Nombre");
            ViewBag.TipoAfiliado = new SelectList(db.TipoAfiliado, "Id", "Nombre");
            ViewBag.TipoUsuario = new SelectList(db.TipoUsuarioAfiliado, "Id", "Nombre");
            return View("/Views/Administrativas/Afiliados/Create.cshtml");
        }

        // POST: Afiliados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Persona,RecidenciaMunicipio,TipoUsuario,TipoAfiliado,RecidenciaBarrio,RecidenciaDireccion,RecidenciaZona,FechaAfiliacion,FechaRetiro")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Afiliado.Add(afiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero", afiliado.Persona);
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Codigo", afiliado.RecidenciaMunicipio);
            ViewBag.TipoAfiliado = new SelectList(db.TipoAfiliado, "Id", "Codigo", afiliado.TipoAfiliado);
            ViewBag.TipoUsuario = new SelectList(db.TipoUsuarioAfiliado, "Id", "Codigo", afiliado.TipoUsuario);
            return View("/Views/Administrativas/Afiliados/Create.cshtml", afiliado);
        }

        // GET: Afiliados/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliado.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero", afiliado.Persona);
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Codigo", afiliado.RecidenciaMunicipio);
            ViewBag.TipoAfiliado = new SelectList(db.TipoAfiliado, "Id", "Codigo", afiliado.TipoAfiliado);
            ViewBag.TipoUsuario = new SelectList(db.TipoUsuarioAfiliado, "Id", "Codigo", afiliado.TipoUsuario);
            return View("/Views/Administrativas/Afiliados/Edit.cshtml", afiliado);
        }

        // POST: Afiliados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Persona,RecidenciaMunicipio,TipoUsuario,TipoAfiliado,RecidenciaBarrio,RecidenciaDireccion,RecidenciaZona,FechaAfiliacion,FechaRetiro")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero", afiliado.Persona);
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Codigo", afiliado.RecidenciaMunicipio);
            ViewBag.TipoAfiliado = new SelectList(db.TipoAfiliado, "Id", "Codigo", afiliado.TipoAfiliado);
            ViewBag.TipoUsuario = new SelectList(db.TipoUsuarioAfiliado, "Id", "Codigo", afiliado.TipoUsuario);
            return View("/Views/Administrativas/Afiliados/Edit.cshtml", afiliado);
        }

        // GET: Afiliados/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliado.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Afiliados/Delete.cshtml", afiliado);
        }

        // POST: Afiliados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Afiliado afiliado = db.Afiliado.Find(id);
            db.Afiliado.Remove(afiliado);
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
