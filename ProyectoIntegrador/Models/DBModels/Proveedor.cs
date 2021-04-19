using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("proveedores")]
    public class Proveedor
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("identificacion_tipo")]
        [Required]
        [DisplayName("Tipo de identificación")]
        public long IdentificacionTipo { get; set; }

        [Column("identificacion_numero")]
        [MaxLength(20)]
        [Required]
        [DisplayName("Numero de identificación")]
        public string IdentificacionNumero { get; set; }

        [Column("nombres")]
        [MaxLength(60)]
        [Required]
        [DisplayName("Nombres del Proveedor")]
        public string Nombres { get; set; }

        [Column("primer_apellido")]
        [MaxLength(30)]
        [DisplayName("Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Column("segundo_apellido")]
        [MaxLength(30)]
        [DisplayName("Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Column("municipio_recide")]
        [Required]
        [DisplayName("Municipio donde recide")]
        public long MunicipioRecide { get; set; }


        [ForeignKey("MunicipioRecide")]
        public Municipio MunicipioRecideF { get; set; }
    }
}