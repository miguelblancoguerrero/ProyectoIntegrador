using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("departamentos")]
    public class Departamento
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(10)]
        [Required]
        public string Codigo { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        [Required]
        public string Nombre { get; set; }

    }
}