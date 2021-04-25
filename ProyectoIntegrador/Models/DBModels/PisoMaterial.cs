using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("pisos_materiales")]
    public class PisoMaterial
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("material")]
        [Required]
        public long Material { get; set; }

        [Column("piso")]
        [Required]
        public long Piso { get; set; }

        [Column("posicion")]
        [MaxLength(25)]
        public string Posicion { get; set; }

        [Column("fecha_entrada")]
        [Required]
        public DateTime FechaEntrada { get; set; }

        [Column("fecha_caducidad")]
        public DateTime FechaCaducidad { get; set; }

        [Column("cantidad")]
        [Required]
        public long Cantidad { get; set; }


        [ForeignKey("Material")]
        public Material MaterialF { get; set; }
        [ForeignKey("Piso")]
        public Piso PisoF { get; set; }

    }
}