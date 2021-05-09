namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo_consultorio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tipos_consultorios",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.consultorios", "tipo");
            AddForeignKey("dbo.consultorios", "tipo", "dbo.tipos_consultorios", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.consultorios", "tipo", "dbo.tipos_consultorios");
            DropIndex("dbo.consultorios", new[] { "tipo" });
            DropTable("dbo.tipos_consultorios");
        }
    }
}
