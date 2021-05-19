namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteempleados : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.empleados", "fecha_egreso", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.empleados", "fecha_egreso", c => c.DateTime(nullable: false));
        }
    }
}
