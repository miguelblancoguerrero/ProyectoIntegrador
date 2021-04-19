using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("tipos_afiliados")]
    public class TipoAfiliado
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(10)]
        [Required]
        [DisplayName("Código del afiliado")]
        public string Codigo { get; set; }

        [Column("nombre")]
        [MaxLength(20)]
        [Required]
        [DisplayName("Nombre del tipo")]
        public string Nombre { get; set; }
    }
}