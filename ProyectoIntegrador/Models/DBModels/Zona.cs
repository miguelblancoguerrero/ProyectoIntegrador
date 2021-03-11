using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("zonas")]
    public class Zona
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        public string Codigo { get; set; }

        [Column("tipo")]
        [MaxLength(15)]
        [Required]
        public string Tipo { get; set; }

        [Column("bodega")]
        [Required]
        public long Bodega { get; set; }


        [ForeignKey("Bodega")]
        public Bodega BodegaF { get; set; }
    }
}