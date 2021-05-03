using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("materiales")]
    public class Material
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Column("nombre")]
        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        [Column("tipo")]
        [Required]
        public short Tipo { get; set; }

        [Column("padre")]
        public long? Padre { get; set; }

        [Column("temperatura_almacenamiento")]
        [Required]
        [DisplayName("Temperatura de Almacenamiento")]
        public short TemperaturaAlmacenamiento { get; set; }

        [Column("marca")]
        public long? Marca { get; set; }


        [ForeignKey("Padre")]
        public Material PadreF { get; set; }
        [ForeignKey("Marca")]
        public Marca MarcaF { get; set; }
    }
}