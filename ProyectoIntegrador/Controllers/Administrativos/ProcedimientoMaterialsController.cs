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
    public class ProcedimientoMaterialsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProcedimientoMaterials
        public async Task<ActionResult> Index()
        {
            var procedimientoMaterial = db.ProcedimientoMaterial.Include(p => p.MaterialF).Include(p => p.ProcedimientoF);
            return View("/Views/Administrativas/ProcedimientoMaterials/Index.cshtml", await procedimientoMaterial.ToListAsync());
        }

        // GET: ProcedimientoMaterials/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedimientoMaterial procedimientoMaterial = await db.ProcedimientoMaterial.FindAsync(id);
            if (procedimientoMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/ProcedimientoMaterials/Detalles.cshtml",procedimientoMaterial);
        }

        // GET: ProcedimientoMaterials/Create
        public ActionResult Create()
        {
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo");
            ViewBag.Procedimiento = new SelectList(db.Procedimiento, "Id", "Codigo");
            return View("/Views/Administrativas/ProcedimientoMaterials/Create.cshtml");
        }

        // POST: ProcedimientoMaterials/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Procedimiento,Material,Cantidad")] ProcedimientoMaterial procedimientoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.ProcedimientoMaterial.Add(procedimientoMaterial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", procedimientoMaterial.Material);
            ViewBag.Procedimiento = new SelectList(db.Procedimiento, "Id", "Codigo", procedimientoMaterial.Procedimiento);
            return View("/Views/Administrativas/ProcedimientoMaterials/Create.cshtml",procedimientoMaterial);
        }

        // GET: ProcedimientoMaterials/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedimientoMaterial procedimientoMaterial = await db.ProcedimientoMaterial.FindAsync(id);
            if (procedimientoMaterial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", procedimientoMaterial.Material);
            ViewBag.Procedimiento = new SelectList(db.Procedimiento, "Id", "Codigo", procedimientoMaterial.Procedimiento);
            return View("/Views/Administrativas/ProcedimientoMaterials/Edit.cshtml",procedimientoMaterial);
        }

        // POST: ProcedimientoMaterials/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Procedimiento,Material,Cantidad")] ProcedimientoMaterial procedimientoMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedimientoMaterial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Material = new SelectList(db.Material, "Id", "Codigo", procedimientoMaterial.Material);
            ViewBag.Procedimiento = new SelectList(db.Procedimiento, "Id", "Codigo", procedimientoMaterial.Procedimiento);
            return View("/Views/Administrativas/ProcedimientoMaterials/Edit.cshtml",procedimientoMaterial);
        }

        // GET: ProcedimientoMaterials/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProcedimientoMaterial procedimientoMaterial = await db.ProcedimientoMaterial.FindAsync(id);
            if (procedimientoMaterial == null)
            {
                return HttpNotFound();
            }
            return View("/Views/Administrativas/ProcedimientoMaterials/Delete.cshtml",procedimientoMaterial);
        }

        // POST: ProcedimientoMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProcedimientoMaterial procedimientoMaterial = await db.ProcedimientoMaterial.FindAsync(id);
            db.ProcedimientoMaterial.Remove(procedimientoMaterial);
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
