using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("recetas_medicas")]
    public class RecetaMedica
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("descripcion")]
        [MaxLength(1024)]
        [Required]
        public string Descripcion { get; set; }

        [Column("observaciones")]
        [MaxLength(1024)]
        [Required]
        public string Observaciones { get; set; }

        [Column("historia_medica")]
        public long HistoriaMedica { get; set; }


        [ForeignKey("HistoriaMedica")]
        public HistoriaMedica HistoriaMedicaF { get; set; }
    }
}