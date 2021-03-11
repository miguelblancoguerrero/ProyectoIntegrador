using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("ordenes_materiales")]
    public class OrdenMaterial
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("orden")]
        [Required]
        public long Orden { get; set; }

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


        [ForeignKey("Orden")]
        public Orden OrdenF { get; set; }
        [ForeignKey("Material")]
        public Material MaterialF { get; set; }
        [ForeignKey("Proveedor")]
        public Proveedor ProveedorF { get; set; }
        [ForeignKey("Bodega")]
        public Bodega BodegaF { get; set; }
    }
}