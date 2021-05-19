namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo_citas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.citas", "duracion", c => c.Int(nullable: false));
            AlterColumn("dbo.citas", "tipo", c => c.Short(nullable: false));
            AlterColumn("dbo.tipos_consultorios", "nombre", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tipos_consultorios", "nombre", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.citas", "tipo", c => c.String(nullable: false, maxLength: 15));
            DropColumn("dbo.citas", "duracion");
        }
    }
}
