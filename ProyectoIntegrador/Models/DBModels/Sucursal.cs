using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Nombe { get; set; }

        [Column("municipio")]
        [Required]
        public long Municipio { get; set; }

        [Column("direccion")]
        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; }

        [Column("telefonos")]
        [Required]
        [MaxLength(100)]
        public string Telefonos { get; set; }


        [ForeignKey("Municipio")]
        private Municipio MunicipioF;
    }
}