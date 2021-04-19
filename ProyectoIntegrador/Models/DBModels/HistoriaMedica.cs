using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel;


namespace ProyectoIntegrador.Models.DBModels
{
    [Table("historias_medicas")]
    public class HistoriaMedica
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("procedimiento")]
        [DisplayName("Procedimiento a realizar")]
        public long Procedimiento { get; set; }

        [Column("persona")]
        [Required]
        [DisplayName("Persona a realizar procedimiento")]
        public long Persona { get; set; }

        [Column("medico")]
        [Required]
        [DisplayName("Medico tratante")]
        public long Medico { get; set; }

        [Column("finalidad")]
        [Required]
        [DisplayName("Finalidad del procedimiento")]
        public long Finalidad { get; set; }

        [Column("causa_externa")]
        [Required]
        [DisplayName("Causa externa de la enfermedad")]
        public long CausaExterna { get; set; }

        [Column("codigo")]
        [MaxLength(8)]
        [Required]
        [DisplayName("Código del procedimiento")]
        public string Codigo { get; set; }

        [Column("fecha_realiza")]
        [Required]
        [DisplayName("Fecha del procedimiento")]
        public DateTime FechaRealiza { get; set; }

        [Column("codigo_diagnostico")]
        [MaxLength(4)]
        [DisplayName("Código del procedimiento")]
        [Required]
        public string CodigoDiagnostico { get; set; }

        [Column("codigo_diagnostico_n1")]
        [MaxLength(4)]
        [DisplayName("Código del diagnostico")]
        public string CodigoDiagnosticoN1 { get; set; }

        [Column("codigo_diagnostico_n2")]
        [MaxLength(4)]
        [DisplayName("Codigo referencia 2 diagnostico")]
        public string CodigoDiagnosticoN2 { get; set; }

        [Column("codigo_diagnostico_n3")]
        [MaxLength(4)]
        [DisplayName("Codigo referencia 3 diagnostico")]
        public string CodigoDiagnosticoN3 { get; set; }

        public Procedimiento ProcedimientoF { get; set; }
        public Persona PersonaF { get; set; }
        public Empleado MedicoF { get; set; }
        public Finalidad FinalidadF { get; set; }
        public CausaExterna CausaExternaF { get; set; }
    }
}