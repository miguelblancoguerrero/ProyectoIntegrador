using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Afiliado de la cita")]
        public long Afiliado { get; set; }

        [Column("medico")]
        [Required]
        [DisplayName("Médico de la cita")]
        public long Medico { get; set; }

        [Column("consultorio")]
        [Required]
        [DisplayName("Consultorio de la cita")]
        public long Consultorio { get; set; }

        [Column("tipo")]
        [MaxLength(15)]
        [Required]
        [DisplayName("Tipo de cita")]
        public string Tipo { get; set; }

        [Column("fecha")]
        [Required]
        [DisplayName("Fecha de la cita")]
        public DateTime Fecha { get; set; }

        [Column("duracion")]
        [Required]
        [DisplayName("Duración de la cita")]
        public int Duracion { get; set; }

        [Column("fecha_crea")]
        [Required]
        [DisplayName("Fecha de creación de la cita")]
        public DateTime FechaCrea { get; set; }

        [Column("estado")]
        [Required]
        [DisplayName("Estado de la cita")]
        public short Estado { get; set; }


        [ForeignKey("Afiliado")]
        public Afiliado AfiliadoF { get; set; }
        [ForeignKey("Medico")]
        public Empleado MedicoF { get; set; }
        [ForeignKey("Consultorio")]
        public Consultorio ConsultorioF { get; set; }
    }
}