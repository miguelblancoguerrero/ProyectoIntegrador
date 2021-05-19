using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("tipos_citas")]
    public class TipoCitas
    {

        [Key]
        [Column("id")]
        public short Id { get; set; }

        [Column("codigo")]
        [MaxLength(15)]
        [Required]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Column("nombre")]
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }

        [Column("tipo_consultorio")]
        [Required]
        [DisplayName("Tipo Consultorio")]
        public short TipoConsultorio { get; set; }

        [ForeignKey("TipoConsultorio")]
        public TipoConsultorio TipoConsultorioF { get; set; }

    }
}