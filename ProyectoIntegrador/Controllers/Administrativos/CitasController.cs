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
    public class CitasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Citas
        public ActionResult Index()
        {
            var cita = db.Cita.Include(c => c.AfiliadoF).Include(c => c.ConsultorioF).Include(c => c.MedicoF);
            return View("/Views/Administrativas/Citas/Index.cshtml", cita.ToList());
        }

        // GET: Citas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Citas/Details.cshtml", cita);
        }

        // GET: Citas/Create
        public ActionResult Create()
        {
            ViewBag.Afiliado = new SelectList(db.Afiliado, "Id", "RecidenciaBarrio");
            ViewBag.Consultorio = new SelectList(db.Consultorio, "Id", "Codigo");
            ViewBag.Medico = new SelectList(db.Empleado, "Id", "RecidenciaBarrio");
            return View("/Views/Administrativas/Citas/Create.cshtml");
        }

        // POST: Citas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Afiliado,Medico,Consultorio,Tipo,Fecha,Duracion,FechaCrea,Estado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Afiliado = new SelectList(db.Afiliado, "Id", "RecidenciaBarrio", cita.Afiliado);
            ViewBag.Consultorio = new SelectList(db.Consultorio, "Id", "Codigo", cita.Consultorio);
            ViewBag.Medico = new SelectList(db.Empleado, "Id", "RecidenciaBarrio", cita.Medico);
            return View("/Views/Administrativas/Citas/Create.cshtml", cita);
        }

        // GET: Citas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.Afiliado = new SelectList(db.Afiliado, "Id", "RecidenciaBarrio", cita.Afiliado);
            ViewBag.Consultorio = new SelectList(db.Consultorio, "Id", "Codigo", cita.Consultorio);
            ViewBag.Medico = new SelectList(db.Empleado, "Id", "RecidenciaBarrio", cita.Medico);
            return View("/Views/Administrativas/Citas/Edit.cshtml", cita);
        }

        // POST: Citas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Afiliado,Medico,Consultorio,Tipo,Fecha,Duracion,FechaCrea,Estado")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Afiliado = new SelectList(db.Afiliado, "Id", "RecidenciaBarrio", cita.Afiliado);
            ViewBag.Consultorio = new SelectList(db.Consultorio, "Id", "Codigo", cita.Consultorio);
            ViewBag.Medico = new SelectList(db.Empleado, "Id", "RecidenciaBarrio", cita.Medico);
            return View("/Views/Administrativas/Citas/Edit.cshtml", cita);
        }

        // GET: Citas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cita cita = db.Cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Citas/Delete.cshtml", cita);
        }

        // POST: Citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Cita cita = db.Cita.Find(id);
            db.Cita.Remove(cita);
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
