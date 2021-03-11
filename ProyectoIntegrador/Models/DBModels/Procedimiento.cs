using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("prcedimientos")]
    public class Procedimiento
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("cita")]
        public long Cita { get; set; }

        [Column("ambito")]
        [Required]
        public short Ambito { get; set; }

        [Column("codigo")]
        [MaxLength(8)]
        [Required]
        public string Codigo { get; set; }

        [Column("finalidad")]
        [Required]
        public short Finalidad { get; set; }

        [Column("fecha_realiza")]
        [Required]
        public DateTime FechaRealiza { get; set; }


        [ForeignKey("Cita")]
        public Cita CitaF { get; set; }
    }
}