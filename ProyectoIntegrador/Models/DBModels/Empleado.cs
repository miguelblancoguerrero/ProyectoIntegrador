using System;
using System.Collections.Generic;
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
        public long RecidenciaMunicipio { get; set; }

        [Column("cargo")]
        [Required]
        public long Cargo { get; set; }

        [Column("sucursal")]
        [Required]
        public long? Sucursal { get; set; }

        [Column("recidencia_barrio")]
        [MaxLength(30)]
        [Required]
        public string RecidenciaBarrio { get; set; }

        [Column("recidencia_direccion")]
        [MaxLength(30)]
        [Required]
        public string RecidenciaDireccion { get; set; }

        [Column("fecha_ingreso")]
        [Required]
        public DateTime FechaIngreso { get; set; }

        [Column("fecha_egreso")]
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