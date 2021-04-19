using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("tipos_usuarios_afiliados")]
    public class TipoUsuarioAfiliado
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