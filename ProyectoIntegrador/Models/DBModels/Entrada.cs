using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("entradas")]
    public class Entrada
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Column("fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Column("orden")]
        [Required]
        public long Orden { get; set; }

        [Column("factura")]
        [MaxLength(50)]
        public string factura { get; set; }


        [ForeignKey("Orden")]
        public Orden OrdenF { get; set; }
    }
}