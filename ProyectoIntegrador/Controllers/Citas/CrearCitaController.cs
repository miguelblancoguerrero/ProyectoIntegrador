using ProyectoIntegrador.Controllers.Citas.DTOs;
using ProyectoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoIntegrador.Models.DBModels;

namespace ProyectoIntegrador.Controllers.Citas
{
    public class CrearCitaController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CrearCita
        public ActionResult Index()
        {
            CrearCitaDTO vDto = new CrearCitaDTO();
            vDto.TiposIdentificaciones = db.TipoIdentifiacion.Select(o => o).ToList();
            vDto.TiposCitas = db.TipoCitas.Select(o => o).ToList();
            return View("/Views/Citas/CrearCita/Index.cshtml", vDto);
        }

        [HttpGet]
        public ActionResult ValidarAfiliado(long pIdTipoIdentificacion, string pNumeroIdentificacion)
        {
            var vData = (
                from a in db.Afiliado
                join p in db.Persona on a.Persona equals p.Id
                join g in db.Genero on p.Genero equals g.Id
                join m in db.Municipio on a.RecidenciaMunicipio equals m.Id
                join d in db.Departamento on m.Departamento equals d.Id
                where p.IdentificacionTipo == pIdTipoIdentificacion
                where p.IdentificacionNumero == pNumeroIdentificacion
                select new {
                    a = a,
                    p = p,
                    g = g,
                    m = m,
                    d = d
                }
                ).FirstOrDefault();
            if (vData != null)
            {
                Afiliado vAfiliado = vData.a;
                vAfiliado.PersonaF = vData.p;
                vAfiliado.PersonaF.GeneroF = vData.g;
                vAfiliado.RecidenciaMunicipioF = vData.m;
                vAfiliado.RecidenciaMunicipioF.DepartamentoF = vData.d;
                var vJsonResult = new { objeto = vAfiliado, success = true, error = "" };
                return Json(vJsonResult, JsonRequestBehavior.AllowGet);

            } else
            {
                var vJsonResult = new { success = false, error = "No se encontro un afiliado con esa identificación" };
                return Json(vJsonResult, JsonRequestBehavior.AllowGet);
            }
        }
    }
}