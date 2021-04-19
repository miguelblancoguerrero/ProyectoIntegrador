using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("procedimientos_materiales")]
    public class ProcedimientoMaterial
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("procedimiento")]
        [Required]
        [DisplayName("Procedimiento a realizar")]
        public long Procedimiento { get; set; }

        [Column("material")]
        [Required]
        [DisplayName("Mmaterial a retirar")]
        public long Material { get; set; }

        [Column("cantidad")]
        [Required]
        [DisplayName("Cantidad material a retirar")]
        public long Cantidad { get; set; }


        [ForeignKey("Procedimiento")]
        public Procedimiento ProcedimientoF { get; set; }
        [ForeignKey("Material")]
        public Material MaterialF { get; set; }
    }
}