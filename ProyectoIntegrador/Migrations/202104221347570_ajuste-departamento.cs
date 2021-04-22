namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustedepartamento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.departamentos", "nombre", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.departamentos", "nombre", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
