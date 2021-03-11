using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("historias_medicas")]
    public class HistoriaMedica
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("procedimiento")]
        public long Procedimiento { get; set; }

        [Column("persona")]
        [Required]
        public long Persona { get; set; }

        [Column("medico")]
        [Required]
        public long Medico { get; set; }

        [Column("finalidad")]
        [Required]
        public long Finalidad { get; set; }

        [Column("causa_externa")]
        [Required]
        public long CausaExterna { get; set; }

        [Column("codigo")]
        [MaxLength(8)]
        [Required]
        public string Codigo { get; set; }

        [Column("fecha_realiza")]
        [Required]
        public DateTime FechaRealiza { get; set; }

        [Column("codigo_diagnostico")]
        [MaxLength(4)]
        [Required]
        public string CodigoDiagnostico { get; set; }

        [Column("codigo_diagnostico_n1")]
        [MaxLength(4)]
        public string CodigoDiagnosticoN1 { get; set; }

        [Column("codigo_diagnostico_n2")]
        [MaxLength(4)]
        public string CodigoDiagnosticoN2 { get; set; }

        [Column("codigo_diagnostico_n3")]
        [MaxLength(4)]
        public string CodigoDiagnosticoN3 { get; set; }

        public Procedimiento ProcedimientoF { get; set; }
        public Persona PersonaF { get; set; }
        public Empleado MedicoF { get; set; }
        public Finalidad FinalidadF { get; set; }
        public CausaExterna CausaExternaF { get; set; }
    }
}