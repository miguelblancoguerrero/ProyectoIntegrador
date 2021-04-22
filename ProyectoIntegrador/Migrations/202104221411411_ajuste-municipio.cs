namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustemunicipio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.municipios", "nombre", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.municipios", "nombre", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
