using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("bodegas")]
    public class Bodega
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Column("interna")]
        [Required]
        public bool Interna { get; set; }

        [Column("sucursal")]
        [Required]
        public long Sucursal { get; set; }

        [Column("municipio")]
        [Required]
        public long Municipio { get; set; }

        [Column("direccion")]
        [MaxLength(100)]
        [Required]
        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [Column("telefonos")]
        [MaxLength(100)]
        [Required]
        [DisplayName("Teléfonos")]
        public string Telefonos { get; set; }


        [ForeignKey("Municipio")]
        public Municipio MunicipioF { get; set; }
        [ForeignKey("Sucursal")]
        public Sucursal SucursalF { get; set; }
    }
}