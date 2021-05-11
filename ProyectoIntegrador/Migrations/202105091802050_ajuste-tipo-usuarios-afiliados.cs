namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustetipousuariosafiliados : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tipos_usuarios_afiliados", "nombre", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tipos_usuarios_afiliados", "nombre", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
