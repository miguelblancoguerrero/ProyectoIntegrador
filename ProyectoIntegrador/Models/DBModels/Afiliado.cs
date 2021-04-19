using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("afiliados")]
    public class Afiliado
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("persona")]
        [Required]
        public long Persona { get; set; }

        [Column("recidencia_municipio")]
        [Required]
        [DisplayName("Municipio de residencia")]
        public long RecidenciaMunicipio { get; set; }

        [Column("tipo_usuario")]
        [Required]
        [DisplayName("Tipo de usuario")]
        public long TipoUsuario { get; set; }

        [Column("tipo_afiliado")]
        [Required]
        [DisplayName("Tipo de afiliado")]
        public long TipoAfiliado { get; set; }

        [Column("recidencia_barrio")]
        [MaxLength(30)]
        [Required]
        [DisplayName("Barrio de residencia")]
        public string RecidenciaBarrio { get; set; }

        [Column("recidencia_direccion")]
        [MaxLength(30)]
        [Required]
        [DisplayName("Dirección de residencia")]
        public string RecidenciaDireccion { get; set; }

        [Column("recidencia_zona")]
        [MaxLength(1)]
        [Required]
        [DisplayName("Zona de residencia")]
        public string RecidenciaZona { get; set; }

        [Column("fecha_afiliacion")]
        [Required]
        [DisplayName("Fecha de afiliación")]
        public DateTime FechaAfiliacion { get; set; }

        [Column("fecha_retiro")]
        [DisplayName("Fecha de retiro")]
        public DateTime FechaRetiro { get; set; }


        [ForeignKey("Persona")]
        public Persona PersonaF { get; set; }
        [ForeignKey("RecidenciaMunicipio")]
        public Municipio RecidenciaMunicipioF { get; set; }
        [ForeignKey("TipoUsuario")]
        public TipoUsuarioAfiliado TipoUsuarioF { get; set; }
        [ForeignKey("TipoAfiliado")]
        public TipoAfiliado TipoAfiliadoF { get; set; }
    }
}