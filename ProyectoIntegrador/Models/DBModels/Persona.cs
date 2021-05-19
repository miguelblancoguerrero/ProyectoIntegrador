using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Tipo identificación")]
        public long IdentificacionTipo { get; set; }

        [Column("identificacion_numero")]
        [MaxLength(20)]
        [Required]
        [Index("PersonaIdentificacionUK", 2)]
        [DisplayName("Numero identificación")]
        public string IdentificacionNumero { get; set; }

        [Column("nombres")]
        [MaxLength(60)]
        [Required]
        public string Nombres { get; set; }

        [Column("primer_apellido")]
        [MaxLength(30)]
        [Required]
        [DisplayName("Primer apellido")]
        public string PrimerApellido { get; set; }

        [Column("segundo_apellido")]
        [MaxLength(30)]
        [DisplayName("Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Column("genero")]
        [Required]
        public long Genero { get; set; }

        [Column("fecha_nacimiento")]
        [Required]
        [DisplayName("Fecha nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("correo_electronico")]
        [MaxLength(30)]
        [DisplayName("Correo electronico")]
        public string CorreoElectronico { get; set; }

        [Column("telefonos")]
        [MaxLength(100)]
        [Required]
        [DisplayName("Número telefónico")]
        public string Telefonos { get; set; }


        [ForeignKey("IdentificacionTipo")]
        [DisplayName("Tipo identificación")]
        public TipoIdentifiacion IdentificacionTipoF { get; set; }
        [ForeignKey("Genero")]
        public Genero GeneroF { get; set; }
    }
}