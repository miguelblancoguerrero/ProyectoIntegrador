using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("cargos")]
    public class Cargo
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [Required]
        [MaxLength(10)]
        public string Codigo { get; set; }

        [Column("nombre")]
        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }

        [Column("tipo")]
        [Required]
        public short Tipo { get; set; }

        [Column("descripcion")]
        [MaxLength(1024)]
        public string Descripcion { get; set; }

        [Column("nivel_prioridad")]
        [Required]
        public short NivelPrioridad { get; set; }
    }
}