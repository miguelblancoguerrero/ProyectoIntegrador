using System;
using System.Collections.Generic;
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
        public long RecidenciaMunicipio { get; set; }

        [Column("tipo_usuario")]
        [Required]
        public long TipoUsuario { get; set; }

        [Column("tipo_afiliado")]
        [Required]
        public long TipoAfiliado { get; set; }

        [Column("recidencia_barrio")]
        [MaxLength(30)]
        [Required]
        public string RecidenciaBarrio { get; set; }

        [Column("recidencia_direccion")]
        [MaxLength(30)]
        [Required]
        public string RecidenciaDireccion { get; set; }

        [Column("recidencia_zona")]
        [MaxLength(1)]
        [Required]
        public string RecidenciaZona { get; set; }

        [Column("fecha_afiliacion")]
        [Required]
        public DateTime FechaAfiliacion { get; set; }

        [Column("fecha_retiro")]
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