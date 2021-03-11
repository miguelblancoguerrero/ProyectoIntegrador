using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace ProyectoIntegrador.Models.DBModels
{
    [Table("entradas_materiales")]
    public class EntradaMaterial
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("entrada")]
        [Required]
        public long Entrada { get; set; }

        [Column("material")]
        [Required]
        public long Material { get; set; }

        [Column("proveedor")]
        [Required]
        public long Proveedor { get; set; }

        [Column("bodega")]
        [Required]
        public long Bodega { get; set; }

        [Column("cantidad")]
        [Required]
        public long Cantidad { get; set; }


        [ForeignKey("Entrada")]
        public Entrada EntradaF { get; set; }
        [ForeignKey("Material")]
        public Material MaterialF { get; set; }
        [ForeignKey("Proveedor")]
        public Proveedor ProveedorF { get; set; }
        [ForeignKey("Bodega")]
        public Bodega BodegaF { get; set; }
    }
}