using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("recetas_medicas_materiales")]
    public class RecetaMedicaMaterial
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("receta_medica")]
        [Required]
        [DisplayName("Receta médica")]
        public long RecetaMedica { get; set; }

        [Column("material")]
        [Required]
        [DisplayName("Material receta médica")]
        public long Material { get; set; }

        [Column("cantidad")]
        [Required]
        [DisplayName("Cantidad material receta")]
        public long Cantidad { get; set; }


        [ForeignKey("RecetaMedica")]
        public RecetaMedica RecetaMedicaF { get; set; }
        [ForeignKey("Material")]
        public Material MaterialF { get; set; }
    }
}