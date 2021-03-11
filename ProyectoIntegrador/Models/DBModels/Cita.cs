using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("citas")]
    public class Cita
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("afiliado")]
        [Required]
        public long Afiliado { get; set; }

        [Column("medico")]
        [Required]
        public long Medico { get; set; }

        [Column("consultorio")]
        [Required]
        public long Consultorio { get; set; }

        [Column("tipo")]
        [MaxLength(15)]
        [Required]
        public string Tipo { get; set; }

        [Column("fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Column("duracion")]
        [Required]
        public int Duracion { get; set; }

        [Column("fecha_crea")]
        [Required]
        public DateTime FechaCrea { get; set; }

        [Column("estado")]
        [Required]
        public short Estado { get; set; }


        [ForeignKey("Afiliado")]
        private Afiliado AfiliadoF { get; set; }
        [ForeignKey("Medico")]
        private Empleado MedicoF { get; set; }
        [ForeignKey("Consultorio")]
        private Consultorio ConsultorioF { get; set; }
    }
}