namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustedepmun : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.municipios", "nombre", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.departamentos", "nombre", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.departamentos", "nombre", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.municipios", "nombre", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
