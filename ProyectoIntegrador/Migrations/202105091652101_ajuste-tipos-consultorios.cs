namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustetiposconsultorios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tipos_consultorios", "duracion_procedimiento", c => c.Int(nullable: false));
            DropColumn("dbo.citas", "duracion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.citas", "duracion", c => c.Int(nullable: false));
            DropColumn("dbo.tipos_consultorios", "duracion_procedimiento");
        }
    }
}
