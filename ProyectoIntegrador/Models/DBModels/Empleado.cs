using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("empleados")]
    public class Empleado
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("persona")]
        [Required]
        public long Persona { get; set; }

        [Column("recidencia_municipio")]
        [Required]
        [DisplayName("Municipio de residencia")]
        public long RecidenciaMunicipio { get; set; }

        [Column("cargo")]
        [Required]
        [DisplayName("Cargo del empleado")]
        public long Cargo { get; set; }

        [Column("sucursal")]
        [Required]
        [DisplayName("Sucursal del empleado")]
        public long? Sucursal { get; set; }

        [Column("recidencia_barrio")]
        [MaxLength(30)]
        [Required]
        [DisplayName("Barrio de residencia")]
        public string RecidenciaBarrio { get; set; }

        [Column("recidencia_direccion")]
        [MaxLength(30)]
        [Required]
        [DisplayName("Dirección de residencia")]
        public string RecidenciaDireccion { get; set; }

        [Column("fecha_ingreso")]
        [Required]
        [DisplayName("Fecha de ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Column("fecha_egreso")]
        [DisplayName("Fecha de egreso")]
        public DateTime FechaEgreso { get; set; }


        [ForeignKey("Persona")]
        public Persona PersonaF { get; set; }
        [ForeignKey("RecidenciaMunicipio")]
        public Municipio RecidenciaMunicipioF { get; set; }
        [ForeignKey("Cargo")]
        public Cargo CargoF { get; set; }
        [ForeignKey("Sucursal")]
        public Sucursal SucursalF { get; set; }
    }
}