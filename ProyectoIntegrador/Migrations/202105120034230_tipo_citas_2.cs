namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipo_citas_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tipos_citas",
                c => new
                    {
                        id = c.Short(nullable: false, identity: true),
                        codigo = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false, maxLength: 30),
                        tipo_consultorio = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tipos_consultorios", t => t.tipo_consultorio)
                .Index(t => t.tipo_consultorio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tipos_citas", "tipo_consultorio", "dbo.tipos_consultorios");
            DropIndex("dbo.tipos_citas", new[] { "tipo_consultorio" });
            DropTable("dbo.tipos_citas");
        }
    }
}
