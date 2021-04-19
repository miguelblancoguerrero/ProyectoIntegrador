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

namespace ProyectoIntegrador.Controllers.Administrativos
{
    public class HistoriaMedicasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HistoriaMedicas
        public async Task<ActionResult> Index()
        {
            return View("/Views/Administrativas/HistoriaMedicas/Index.cshtml",await db.HistoriaMedica.ToListAsync());
        }

        // GET: HistoriaMedicas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaMedica historiaMedica = await db.HistoriaMedica.FindAsync(id);
            if (historiaMedica == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/HistoriaMedicas/Details.cshtml",historiaMedica);
        }

        // GET: HistoriaMedicas/Create
        public ActionResult Create()
        {
            return View("/Views/Administrativas/HistoriaMedicas/Create.cshtml");
        }

        // POST: HistoriaMedicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Procedimiento,Persona,Medico,Finalidad,CausaExterna,Codigo,FechaRealiza,CodigoDiagnostico,CodigoDiagnosticoN1,CodigoDiagnosticoN2,CodigoDiagnosticoN3")] HistoriaMedica historiaMedica)
        {
            if (ModelState.IsValid)
            {
                db.HistoriaMedica.Add(historiaMedica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("/Views/Administrativas/HistoriaMedicas/Create.cshtml",historiaMedica);
        }

        // GET: HistoriaMedicas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaMedica historiaMedica = await db.HistoriaMedica.FindAsync(id);
            if (historiaMedica == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/HistoriaMedicas/Edit.cshtml", historiaMedica);
        }

        // POST: HistoriaMedicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Procedimiento,Persona,Medico,Finalidad,CausaExterna,Codigo,FechaRealiza,CodigoDiagnostico,CodigoDiagnosticoN1,CodigoDiagnosticoN2,CodigoDiagnosticoN3")] HistoriaMedica historiaMedica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaMedica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("/Views/Administrativas/HistoriaMedicas/Edit.cshtml",historiaMedica);
        }

        // GET: HistoriaMedicas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistoriaMedica historiaMedica = await db.HistoriaMedica.FindAsync(id);
            if (historiaMedica == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/HistoriaMedicas/Delete.cshtml",historiaMedica);
        }

        // POST: HistoriaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            HistoriaMedica historiaMedica = await db.HistoriaMedica.FindAsync(id);
            db.HistoriaMedica.Remove(historiaMedica);
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
