using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("tipos_identificacion")]
    public class TipoIdentifiacion
    {
        
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        [Required]
        [DisplayName("Nombre del tipo de identificación")]
        public string Nombre { get; set; }


    }
}