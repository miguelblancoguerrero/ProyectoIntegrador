namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pisos_materiales", "cantidad", c => c.Long(nullable: false));
            AddColumn("dbo.AspNetUsers", "persona", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "persona");
            AddForeignKey("dbo.AspNetUsers", "persona", "dbo.personas", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "persona", "dbo.personas");
            DropIndex("dbo.AspNetUsers", new[] { "persona" });
            DropColumn("dbo.AspNetUsers", "persona");
            DropColumn("dbo.pisos_materiales", "cantidad");
        }
    }
}
