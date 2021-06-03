using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using ProyectoIntegrador.Models.DBModels;

namespace ProyectoIntegrador.Controllers.Citas.DTOs
{
    public class CrearCitaDTO
    {

        public List<TipoIdentifiacion> TiposIdentificaciones { get; set; }
        public List<TipoCita> TiposCitas { get; set; }
        public List<Sucursal> Sucursulas { get; set; }

        public Afiliado Afiliado { get; set; }
        public TipoIdentifiacion TipoIdentificacionAfiliado { get; set; }
        public TipoCita TipoCita { get; set; }
        public Sucursal SucursalEmpleado { get; set; }

        // Datos de recoleccion consulta espacio
        public long IdTipoCita { get; set; }
        public long IdSucursal { get; set; }
        public DateTime FechaCita { get; set; }

        //Datos Vacunacion
        public string IdHora { get; set; }
        public Consultorio Consultorio { get; set; }


        
        public CrearCitaDTO()
        {
            this.Afiliado = new Afiliado();
            this.Afiliado.PersonaF = new Persona();
            this.Afiliado.PersonaF.GeneroF = new Genero();
            this.Afiliado.RecidenciaMunicipioF = new Municipio();
            this.Afiliado.RecidenciaMunicipioF.DepartamentoF = new Departamento();
        }

    }
}