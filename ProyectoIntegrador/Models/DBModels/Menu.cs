using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("menus")]
    public class Menu
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("etiqueta")]
        [MaxLength(50)]
        [Required]
        public string Etiqueta { get; set; }

        [Column("url")]
        [MaxLength(500)]
        public string Url { get; set; }

        [Column("padre")]
        public long? Padre { get; set; }

        [Column("orden")]
        [Required]
        public int Orden { get; set; }


        [ForeignKey("Padre")]
        public Menu FPadre { get; set; }
    }
}