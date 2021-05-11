using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProyectoIntegrador.Models.DBModels;

namespace ProyectoIntegrador.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Column("persona")]
        public long? Persona { get; set; }

        [ForeignKey("Persona")]
        public Persona FPersona { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<IdentityUserRole> UserRoles { get; set; }

        public DbSet<Afiliado> Afiliado { get; set; }
        public DbSet<Bodega> Bodega { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<CausaExterna> CausaExterna { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Consultorio> Consultorio { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<EntradaMaterial> EntradaMaterial { get; set; }
        public DbSet<Estante> Estante { get; set; }
        public DbSet<Finalidad> Finalidad { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<HistoriaMedica> HistoriaMedica { get; set; }
        public DbSet<Kardex> Kardex { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Orden> Orden { get; set; }
        public DbSet<OrdenMaterial> OrdenMaterial { get; set; }
        public DbSet<Pasillo> Pasillo { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Piso> Piso { get; set; }
        public DbSet<PisoMaterial> PisoMaterial { get; set; }
        public DbSet<Procedimiento> Procedimiento { get; set; }
        public DbSet<ProcedimientoMaterial> ProcedimientoMaterial { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<RecetaMedica> RecetaMedica { get; set; }
        public DbSet<RecetaMedicaMaterial> RecetaMedicaMaterial { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<TipoAfiliado> TipoAfiliado { get; set; }
        public DbSet<TipoConsultorio> TipoConsultorio { get; set; }
        public DbSet<TipoIdentifiacion> TipoIdentifiacion { get; set; }
        public DbSet<TipoUsuarioAfiliado> TipoUsuarioAfiliado { get; set; }
        public DbSet<Zona> Zona { get; set; }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
    }
}