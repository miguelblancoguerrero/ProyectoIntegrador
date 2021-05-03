using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{

    [Table("kardex")]
    public class Kardex
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("material")]
        [Required]
        public long Material { get; set; }

        [Column("bodega")]
        [Required]
        public long Bodega { get; set; }

        [Column("fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Column("concepto")]
        [MaxLength(3)]
        [Required]
        public string Concepto { get; set; }

        [Column("descripcion")]
        [MaxLength(200)]
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Column("valor_unitario")]
        [Required]
        [DisplayName("Valor Unitario")]
        public double ValorUnitario { get; set; }

        [Column("movimiento_tipo")]
        [MaxLength(3)]
        [Required]
        [DisplayName("Tipo de Movimiento")]
        public string MovimientoTipo { get; set; }

        [Column("movimiento_cantidad")]
        [Required]
        [DisplayName("Cantidad del movimiento")]
        public int MovimientoCantidad { get; set; }

        [Column("movimiento_valor_total")]
        [Required]
        [DisplayName("Valor total del movimiento")]
        public double MovimientoValorTotal { get; set; }


        [ForeignKey("Material")]
        public Material MaterialF { get; set; }
        [ForeignKey("Bodega")]
        public Material BodegaF { get; set; }
    }
}