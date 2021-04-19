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
    public class RecetaMedicaMaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecetaMedicaMaterials
        public async Task<ActionResult> Index()
        {
            var recetaMedicaMaterial = db.RecetaMedicaMaterial.Include(r => r.MaterialF).Include(r => r.RecetaMedicaF);
            return View("/Views/Administrativas/RecetaMedicaMaterials/Index.cshtml",await recetaMedicaMaterial.ToListAsync());
        }

        // GET: RecetaMedicaMaterials/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetaMedicaMaterial recetaMedicaMaterial = await db.RecetaMedicaMaterial.FindAsync(id);
            if (recetaMedicaMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/RecetaMedicaMaterials/Details.cshtml",recetaMedicaMaterial);
        }

        // GET: RecetaMedicaMaterials/Create
        public ActionResult Create()
        {
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo");
            ViewBag.RecetaMedica = new SelectList(db.RecetaMedica, "Id", "Descripcion");
            return View("/Views/Administrativas/RecetaMedicaMaterials/Create.cshtml");
        }

        // POST: RecetaMedicaMaterials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RecetaMedica,Material,Cantidad")] RecetaMedicaMaterial recetaMedicaMaterial)
        {
            if (ModelState.IsValid)
            {
                db.RecetaMedicaMaterial.Add(recetaMedicaMaterial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", recetaMedicaMaterial.Material);
            ViewBag.RecetaMedica = new SelectList(db.RecetaMedica, "Id", "Descripcion", recetaMedicaMaterial.RecetaMedica);
            return View("/Views/Administrativas/HistoriaMedicas/Create.cshtml", recetaMedicaMaterial);
        }

        // GET: RecetaMedicaMaterials/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetaMedicaMaterial recetaMedicaMaterial = await db.RecetaMedicaMaterial.FindAsync(id);
            if (recetaMedicaMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", recetaMedicaMaterial.Material);
            ViewBag.RecetaMedica = new SelectList(db.RecetaMedica, "Id", "Descripcion", recetaMedicaMaterial.RecetaMedica);
            return View("/Views/Administrativas/RecetaMedicaMaterials/Edit.cshtml", recetaMedicaMaterial);
        }

        // POST: RecetaMedicaMaterials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RecetaMedica,Material,Cantidad")] RecetaMedicaMaterial recetaMedicaMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recetaMedicaMaterial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", recetaMedicaMaterial.Material);
            ViewBag.RecetaMedica = new SelectList(db.RecetaMedica, "Id", "Descripcion", recetaMedicaMaterial.RecetaMedica);
            return View("/Views/Administrativas/RecetaMedicaMaterials/Edit.cshtml", recetaMedicaMaterial);
        }

        // GET: RecetaMedicaMaterials/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecetaMedicaMaterial recetaMedicaMaterial = await db.RecetaMedicaMaterial.FindAsync(id);
            if (recetaMedicaMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/RecetaMedicaMaterials/Delete.cshtml", recetaMedicaMaterial);
        }

        // POST: RecetaMedicaMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            RecetaMedicaMaterial recetaMedicaMaterial = await db.RecetaMedicaMaterial.FindAsync(id);
            db.RecetaMedicaMaterial.Remove(recetaMedicaMaterial);
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
