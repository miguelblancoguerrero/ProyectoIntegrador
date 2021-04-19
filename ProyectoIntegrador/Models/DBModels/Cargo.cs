using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
        [DisplayName("Nombre del cargo")]
        public string Nombre { get; set; }

        [Column("tipo")]
        [Required]
        [DisplayName("Tipo del cargo")]
        public short Tipo { get; set; }

        [Column("descripcion")]
        [MaxLength(1024)]
        [DisplayName("Descripción del cargo")]
        public string Descripcion { get; set; }

        [Column("nivel_prioridad")]
        [Required]
        [DisplayName("Nivel de prioridad")]
        public short NivelPrioridad { get; set; }
    }
}