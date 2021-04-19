using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("generos")]
    public class Genero
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("nombre")]
        [MaxLength(20)]
        [Required]
        [DisplayName("Nombre del sexo")]
        public string Nombre { get; set; }

        [Column("sexo_equivalente")]
        [MaxLength(1)]
        [Required]
        [DisplayName("Sexo al que pertenece")]
        public string SexoEquivalente { get; set; }
    }
}