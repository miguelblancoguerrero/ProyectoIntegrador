namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autekardex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.kardex", "descripcion", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.kardex", "descripcion");
        }
    }
}
