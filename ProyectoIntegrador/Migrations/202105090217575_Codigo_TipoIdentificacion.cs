namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Codigo_TipoIdentificacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tipos_identificacion", "codigo", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tipos_identificacion", "codigo");
        }
    }
}
