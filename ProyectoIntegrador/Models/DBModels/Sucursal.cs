using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("sucursales")]
    public class Sucursal
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Column("nombe")]
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre de la sucursal")]
        public string Nombe { get; set; }

        [Column("municipio")]
        [Required]
        [DisplayName("Municipio de la sucursal")]
        public long Municipio { get; set; }

        [Column("direccion")]
        [Required]
        [MaxLength(100)]
        [DisplayName("Dirección de la sucursal")]
        public string Direccion { get; set; }

        [Column("telefonos")]
        [Required]
        [MaxLength(100)]
        [DisplayName("Telefonos")]
        public string Telefonos { get; set; }


        [ForeignKey("Municipio")]
        public Municipio MunicipioF { get; set; }
    }
}