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
    public class EmpleadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.CargoF).Include(e => e.PersonaF).Include(e => e.RecidenciaMunicipioF).Include(e => e.SucursalF);
            return View("/Views/Administrativas/Empleados/Index.cshtml", empleado.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Empleados/Details.cshtml", empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.Cargo = new SelectList(db.Cargo, "Id", "Codigo");
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero");
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Nombre");
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo");
            return View("/Views/Administrativas/Empleados/Create.cshtml");
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Persona,RecidenciaMunicipio,Cargo,Sucursal,RecidenciaBarrio,RecidenciaDireccion,FechaIngreso,FechaEgreso")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo = new SelectList(db.Cargo, "Id", "Codigo", empleado.Cargo);
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero", empleado.Persona);
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Codigo", empleado.RecidenciaMunicipio);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", empleado.Sucursal);
            return View("/Views/Administrativas/Empleados/Create.cshtml", empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.Cargo, "Id", "Codigo", empleado.Cargo);
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero", empleado.Persona);
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Codigo", empleado.RecidenciaMunicipio);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", empleado.Sucursal);
            return View("/Views/Administrativas/Empleados/Edit.cshtml", empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Persona,RecidenciaMunicipio,Cargo,Sucursal,RecidenciaBarrio,RecidenciaDireccion,FechaIngreso,FechaEgreso")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.Cargo, "Id", "Codigo", empleado.Cargo);
            ViewBag.Persona = new SelectList(db.Persona, "Id", "IdentificacionNumero", empleado.Persona);
            ViewBag.RecidenciaMunicipio = new SelectList(db.Municipio, "Id", "Codigo", empleado.RecidenciaMunicipio);
            ViewBag.Sucursal = new SelectList(db.Sucursal, "Id", "Codigo", empleado.Sucursal);
            return View("/Views/Administrativas/Empleados/Edit.cshtml", empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Empleados/Delete.cshtml", empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
