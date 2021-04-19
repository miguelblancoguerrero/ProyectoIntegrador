using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("procedimientos")]
    public class Procedimiento
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("cita")]
        [DisplayName("Clase de cita")]
        public long Cita { get; set; }

        [Column("ambito")]
        [Required]
        [DisplayName("Ambito de la cita")]
        public short Ambito { get; set; }

        [Column("codigo")]
        [MaxLength(8)]
        [Required]
        [DisplayName("Código de la cita")]
        public string Codigo { get; set; }

        [Column("finalidad")]
        [Required]
        [DisplayName("Finalidad de la cita")]
        public short Finalidad { get; set; }

        [Column("fecha_realiza")]
        [Required]
        [DisplayName("Fecha en que reserva la cita")]
        public DateTime FechaRealiza { get; set; }


        [ForeignKey("Cita")]
        public Cita CitaF { get; set; }
    }
}