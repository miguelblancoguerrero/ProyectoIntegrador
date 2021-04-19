namespace ProyectoIntegrador.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProyectoIntegrador.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProyectoIntegrador.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProyectoIntegrador.Models.ApplicationDbContext";
        }

        protected override void Seed(ProyectoIntegrador.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin    "))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new Models.ApplicationUser
                {
                    Id = "c96e2504-f162-4766-b121-9f6bc18237a5",
                    Email = null,
                    EmailConfirmed = true,
                    PasswordHash = "AC/xA9utATa1Guou4bab7Fmmr0DoKfDDqNqjMC5l+Ysb4Pe/2R3+can/49fNna761g==",
                    SecurityStamp = "bbaef269-d392-451b-bf87-bcdccdd49960",
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEndDateUtc = null,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "admin"
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
