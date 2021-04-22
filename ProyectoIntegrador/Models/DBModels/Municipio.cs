using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace ProyectoIntegrador.Models.DBModels
{   
    [Table("municipios")]
    public class Municipio
    {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("codigo")]
        [MaxLength(10)]
        [Required]
        public string Codigo { get; set; }

        [Column("nombre")]
        [MaxLength(30)]
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [Column("departamento")]
        [Required]
        [DisplayName("Departamento del Municipio")]
        public long Departamento { get; set; }


        [ForeignKey("Departamento")]
        public Departamento DepartamentoF;
    }
}