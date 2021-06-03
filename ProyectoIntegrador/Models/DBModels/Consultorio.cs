using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("consultorios")]
    public class Consultorio
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("sucursal")]
        [Required]
        [DisplayName("Sucursal del consultorio")]
        public long Sucursal { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        public string Codigo { get; set; }

        [Column("tipo")]
        [Required]
        [DisplayName("Tipo del consultorio")]
        public short Tipo { get; set; }

        [Column("capacidad")]
        [DisplayName("Capacidad pacientes del consultorio")]
        public int Capacidad { get; set; }


        [ForeignKey("Sucursal")]
        public Sucursal SucursalF { get; set; }
        [ForeignKey("Tipo")]
        public TipoConsultorio TipoF { get; set; }
    }
}