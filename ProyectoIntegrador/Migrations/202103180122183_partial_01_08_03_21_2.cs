namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partial_01_08_03_21_2 : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.pisos_materiales",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        material = c.Long(nullable: false),
                        piso = c.Long(nullable: false),
                        posicion = c.String(maxLength: 25),
                        fecha_entrada = c.DateTime(nullable: false),
                        fecha_caducidad = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.materiales", t => t.material)
                .ForeignKey("dbo.pisos", t => t.piso)
                .Index(t => t.material)
                .Index(t => t.piso);
            
            AddColumn("dbo.entradas", "factura", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pisos_materiales", "piso", "dbo.pisos");
            DropForeignKey("dbo.pisos_materiales", "material", "dbo.materiales");
            DropIndex("dbo.pisos_materiales", new[] { "piso" });
            DropIndex("dbo.pisos_materiales", new[] { "material" });
            DropColumn("dbo.entradas", "factura");
            DropTable("dbo.pisos_materiales");
        }
    }
}
