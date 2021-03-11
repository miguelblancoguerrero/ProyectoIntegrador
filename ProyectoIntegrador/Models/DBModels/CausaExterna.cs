using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ProyectoIntegrador.Models.DBModels
{
    [Table("causas_externas")]
    public class CausaExterna
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("descripcion")]
        [MaxLength(100)]
        [Required]
        public string Descripcion { get; set; }
    }
}