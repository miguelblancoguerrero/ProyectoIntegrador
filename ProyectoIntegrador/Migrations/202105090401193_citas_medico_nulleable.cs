namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class citas_medico_nulleable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.citas", new[] { "medico" });
            AlterColumn("dbo.citas", "medico", c => c.Long());
            CreateIndex("dbo.citas", "medico");
        }
        
        public override void Down()
        {
            DropIndex("dbo.citas", new[] { "medico" });
            AlterColumn("dbo.citas", "medico", c => c.Long(nullable: false));
            CreateIndex("dbo.citas", "medico");
        }
    }
}
