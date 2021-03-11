using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("personas")]
    public class Persona
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("identificacion_tipo")]
        [Required]
        [Index("PersonaIdentificacionUK", 1)]
        public long IdentificacionTipo { get; set; }

        [Column("identificacion_numero")]
        [MaxLength(20)]
        [Required]
        [Index("PersonaIdentificacionUK", 2)]
        public string IdentificacionNumero { get; set; }

        [Column("nombres")]
        [MaxLength(60)]
        [Required]
        public string Nombres { get; set; }

        [Column("primer_apellido")]
        [MaxLength(30)]
        [Required]
        public string PrimerApellido { get; set; }

        [Column("segundo_apellido")]
        [MaxLength(30)]
        public string SegundoApellido { get; set; }

        [Column("genero")]
        [Required]
        public long Genero { get; set; }

        [Column("fecha_nacimiento")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Column("correo_electronico")]
        [MaxLength(30)]
        public string CorreoElectronico { get; set; }

        [Column("telefonos")]
        [MaxLength(100)]
        [Required]
        public string Telefonos { get; set; }


        [ForeignKey("IdentificacionTipo")]
        public TipoIdentifiacion IdentificacionTipoF { get; set; }
        [ForeignKey("Genero")]
        public Genero GeneroF { get; set; }
    }
}