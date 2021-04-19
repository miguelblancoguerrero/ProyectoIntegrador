using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

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
        [DisplayName("Código del departamento")]
        public string Codigo { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        [Required]
        [DisplayName("Nombre del departamento")]
        public string Nombre { get; set; }

    }
}