using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("pisos")]
    public class Piso
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Column("estante")]
        [Required]
        public long Estante { get; set; }


        [ForeignKey("Estante")]
        public Estante EstanteF { get; set; }
    }
}