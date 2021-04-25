namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.menus",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        etiqueta = c.String(nullable: false, maxLength: 50),
                        url = c.String(maxLength: 500),
                        padre = c.Long(),
                        orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.menus", t => t.padre)
                .Index(t => t.padre);
            
            CreateTable(
                "dbo.roles_menus",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        rol = c.String(nullable: false, maxLength: 128),
                        menu = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.menus", t => t.menu)
                .ForeignKey("dbo.AspNetRoles", t => t.rol)
                .Index(t => t.rol)
                .Index(t => t.menu);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.roles_menus", "rol", "dbo.AspNetRoles");
            DropForeignKey("dbo.roles_menus", "menu", "dbo.menus");
            DropForeignKey("dbo.menus", "padre", "dbo.menus");
            DropIndex("dbo.roles_menus", new[] { "menu" });
            DropIndex("dbo.roles_menus", new[] { "rol" });
            DropIndex("dbo.menus", new[] { "padre" });
            DropTable("dbo.roles_menus");
            DropTable("dbo.menus");
        }
    }
}
