using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.Models.DBModels
{
    [Table("roles_menus")]
    public class RolMenu
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("rol")]
        [MaxLength(128)]
        [Required]
        public string Rol { get; set; }

        [Column("menu")]
        [Required]
        public long Menu { get; set; }

        [ForeignKey("Rol")]
        public IdentityRole FRol { get; set; }

        [ForeignKey("Menu")]
        public Menu FMenu { get; set; }
    }
}