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
    class Rango
    {
        public string Id { get; set; }
        public string Etiqueta { get; set; }
    }

    class Celda
    {
        public Consultorio Consultorio { get; set; }
        public Rango Hora { get; set; }
        public Boolean Bloqueada { get; set; }
        public long PuestosDisponibles { get; set; }
    }

    public class CrearCitaController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CrearCita
        public ActionResult Index()
        {
            CrearCitaDTO vDto = new CrearCitaDTO();
            vDto.TiposIdentificaciones = db.TipoIdentifiacion.Select(o => o).ToList();
            vDto.TiposCitas = db.TipoCitas.Select(o => o).ToList();
            if (Session["empleado"] != null)
            {
                vDto.SucursalEmpleado = ((Empleado)Session["empleado"]).SucursalF;
                vDto.Sucursulas = db.Sucursal.Where(
                    o => o.Municipio.Equals(vDto.SucursalEmpleado.Municipio)
                ).ToList();
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarDisponibilidadVacunacion(CrearCitaDTO datos)
        {
            TipoConsultorio vTipoConsultorio = (from tc in db.TipoConsultorio
                                                join tct in db.TipoCitas on tc.Id equals tct.TipoConsultorio
                                                where tct.Id == datos.IdTipoCita
                                                select tc).FirstOrDefault();
            List<Consultorio> vConsultorios = (from c in db.Consultorio
                                               join tc in db.TipoConsultorio on c.Tipo equals tc.Id
                                               where c.Sucursal == datos.IdSucursal
                                               where tc.Id == vTipoConsultorio.Id
                                               select c).ToList();
            List<Cita> vCitas = (from c in db.Cita 
                                 where c.Tipo == datos.IdTipoCita 
                                 where c.Fecha.Year + " - " + c.Fecha.Month + " - " + c.Fecha.Day ==
                                    datos.FechaCita.Year + " - " + datos.FechaCita.Month + " - " + datos.FechaCita.Day
                                 select c).ToList();
            // genero los horarios de la fecha
            DateTime vHoraInicio = new DateTime(datos.FechaCita.Year, datos.FechaCita.Month, datos.FechaCita.Day, 7, 0, 0);
            DateTime vHoraFin = new DateTime(datos.FechaCita.Year, datos.FechaCita.Month, datos.FechaCita.Day, 18, 0, 0);
            List<Rango> vHoras = new List<Rango>();
            // mientras la hora de inicio sea menor a la de fin genero un rango de horas seleccionable
            while (vHoraInicio.CompareTo(vHoraFin) < 0)
            {
                Rango rango = new Rango();
                rango.Id = vHoraInicio.ToString("yyyy-MM-dd-HH-mm");
                rango.Etiqueta = vHoraInicio.ToString("t");
                vHoraInicio = vHoraInicio.AddMinutes(vTipoConsultorio.DuracionProcedimiento);
                rango.Etiqueta += " - " + vHoraInicio.ToString("t");
                vHoras.Add(rango);
            }
            List<List<Celda>> vCeldas = new List<List<Celda>>();
            // itero en rangos y consultorios, obtengo las citas relacionadas e indico si el rengo sobre el consultorio es seleccionable
            foreach(Rango iHora in vHoras)
            {
                List<Celda> vSubCeldas = new List<Celda>();
                foreach (Consultorio iConsultorio in vConsultorios)
                {
                    Celda vCelda = new Celda();
                    vCelda.Consultorio = iConsultorio;
                    vCelda.Hora = iHora;
                    // Obtengo las citas existentes sobre el consultorio y la hora
                    List<Cita> vCitasCoinciden = vCitas.FindAll(o => {
                        String vId = o.Fecha.ToString("yyyy-MM-dd-HH-mm");
                        return o.Consultorio == iConsultorio.Id && vId.Equals(iHora.Id);
                    });
                    // Cuento y segun la cantidad vs la capacidad del consultorio asigno si la celda es seleccionable
                    long vCantidad = vCitasCoinciden.Count();
                    vCelda.PuestosDisponibles = iConsultorio.Capacidad - vCantidad;
                    vCelda.Bloqueada = vCelda.PuestosDisponibles <= 0;
                    vSubCeldas.Add(vCelda);
                }
                vCeldas.Add(vSubCeldas);
            }
            return Json(new { success = true, consultorios = vConsultorios , horas = vHoras, celdas = vCeldas });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarCitaVacunacion(CrearCitaDTO datos)
        {
            bool valido = true;
            List<string> errores = new List<string>();
            if (datos.Afiliado == null || datos.Afiliado.Id == 0)
            {
                errores.Add("Debe indicar el afiliado al que se le registrará la cita");
                valido = false;
            }
            if (datos.Consultorio == null || datos.Consultorio.Id == 0)
            {
                errores.Add("Debe indicar el consultorio donde se registrará la cita");
                valido = false;
            }
            if (datos.IdHora == null)
            {
                errores.Add("Debe indicar la hora en la que se registrará la cita");
                valido = false;
            }
            if (valido)
            {
                TipoCita tipoCita = (from tc in db.TipoCitas
                                     where tc.TipoConsultorio == datos.Consultorio.Tipo
                                     select tc).FirstOrDefault();
                Cita cita = new Cita();
                cita.Consultorio = datos.Consultorio.Id;
                cita.Afiliado = datos.Afiliado.Id;
                cita.Tipo = tipoCita.Id;
                cita.Duracion = datos.Consultorio.TipoF.DuracionProcedimiento;
                cita.Estado = 1;
                string[] fp = datos.IdHora.Split('-');
                cita.FechaCrea = DateTime.Now;
                cita.Fecha = new DateTime(int.Parse(fp[0]), int.Parse(fp[1]), int.Parse(fp[2]), int.Parse(fp[3]), int.Parse(fp[4]), 0);
                try 
                {
                    db.Cita.Add(cita);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                    valido = false;
                    errores.Add("No se logró ejecutar el guardado de la cita");
                }
            }
            return Json(new { success = valido, errores = errores, });
        }
    }
}