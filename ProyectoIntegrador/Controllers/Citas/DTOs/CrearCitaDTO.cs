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
        public List<TipoConsultorio> TiposConsultorios { get; set; }

        public Afiliado Afiliado { get; set; }
        public TipoIdentifiacion TipoIdentificacionAfiliado { get; set; }
        public TipoConsultorio TipoCita { get; set; }

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