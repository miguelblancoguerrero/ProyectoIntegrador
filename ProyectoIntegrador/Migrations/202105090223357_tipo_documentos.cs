namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo_documentos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tipos_identificacion", "nombre", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tipos_identificacion", "nombre", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
