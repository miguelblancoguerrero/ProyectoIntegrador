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
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personas
        public ActionResult Index()
        {
            var persona = db.Persona.Include(p => p.GeneroF).Include(p => p.IdentificacionTipoF);
            return View("/Views/Administrativas/Personas/Index.cshtml", persona.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Personas/Details.cshtml", persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.Genero = new SelectList(db.Genero, "Id", "Nombre");
            ViewBag.IdentificacionTipo = new SelectList(db.TipoIdentifiacion, "Id", "Nombre");
            return View("/Views/Administrativas/Personas/Create.cshtml");
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdentificacionTipo,IdentificacionNumero,Nombres,PrimerApellido,SegundoApellido,Genero,FechaNacimiento,CorreoElectronico,Telefonos")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Genero = new SelectList(db.Genero, "Id", "Nombre", persona.Genero);
            ViewBag.IdentificacionTipo = new SelectList(db.TipoIdentifiacion, "Id", "Nombre", persona.IdentificacionTipo);
            return View("/Views/Administrativas/Personas/Index.cshtml", persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genero = new SelectList(db.Genero, "Id", "Nombre", persona.Genero);
            ViewBag.IdentificacionTipo = new SelectList(db.TipoIdentifiacion, "Id", "Nombre", persona.IdentificacionTipo);
            return View("/Views/Administrativas/Personas/Edit.cshtml", persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdentificacionTipo,IdentificacionNumero,Nombres,PrimerApellido,SegundoApellido,Genero,FechaNacimiento,CorreoElectronico,Telefonos")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Genero = new SelectList(db.Genero, "Id", "Nombre", persona.Genero);
            ViewBag.IdentificacionTipo = new SelectList(db.TipoIdentifiacion, "Id", "Nombre", persona.IdentificacionTipo);
            return View("/Views/Administrativas/Personas/Edit.cshtml", persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Personas/Delete.cshtml", persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
