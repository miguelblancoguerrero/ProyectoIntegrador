using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoIntegrador.Models;
using ProyectoIntegrador.Models.DBModels;

namespace ProyectoIntegrador.Controllers
{
    public class ProcedimientosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Procedimientos
        public async Task<ActionResult> Index()
        {
            var procedimiento = db.Procedimiento.Include(p => p.CitaF);
            return View("/Views/Administrativas/Procedimientos/Index.cshtml", await procedimiento.ToListAsync());
        }

        // GET: Procedimientos/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimiento procedimiento = await db.Procedimiento.FindAsync(id);
            if (procedimiento == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Procedimientos/Details.cshtml", procedimiento);
        }

        // GET: Procedimientos/Create
        public ActionResult Create()
        {
            ViewBag.Cita = new SelectList(db.Cita, "Id", "Tipo");
            return View("/Views/Administrativas/Procedimientos/Create.cshtml");
        }

        // POST: Procedimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Cita,Ambito,Codigo,Finalidad,FechaRealiza")] Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                db.Procedimiento.Add(procedimiento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Cita = new SelectList(db.Cita, "Id", "Tipo", procedimiento.Cita);
            return View("/Views/Administrativas/Procedimientos/Create.cshtml", procedimiento);
        }

        // GET: Procedimientos/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimiento procedimiento = await db.Procedimiento.FindAsync(id);
            if (procedimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cita = new SelectList(db.Cita, "Id", "Tipo", procedimiento.Cita);
            return View("/Views/Administrativas/Procedimientos/Edit.cshtml", procedimiento);
        }

        // POST: Procedimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Cita,Ambito,Codigo,Finalidad,FechaRealiza")] Procedimiento procedimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimiento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Cita = new SelectList(db.Cita, "Id", "Tipo", procedimiento.Cita);
            return View("/Views/Administrativas/Procedimientos/Edit.cshtml", procedimiento);
        }

        // GET: Procedimientos/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedimiento procedimiento = await db.Procedimiento.FindAsync(id);
            if (procedimiento == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/Procedimientos/Delete.cshtml", procedimiento);
        }

        // POST: Procedimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Procedimiento procedimiento = await db.Procedimiento.FindAsync(id);
            db.Procedimiento.Remove(procedimiento);
            await db.SaveChangesAsync();
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
