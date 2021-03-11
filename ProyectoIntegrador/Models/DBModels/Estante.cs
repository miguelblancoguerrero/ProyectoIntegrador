using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("estantes")]
    public class Estante
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]  
        [MaxLength(15)]
        [Required]
        public string Codigo { get; set; }

        [Column("pasillo")]
        [Required]
        public long Pasillo { get; set; }


        [ForeignKey("Pasillo")]
        public Pasillo PasilloF { get; set; }
    }
}