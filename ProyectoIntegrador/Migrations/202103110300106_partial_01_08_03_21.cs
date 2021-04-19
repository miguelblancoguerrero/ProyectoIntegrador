namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partial_01_08_03_21 : DbMigration
    {
        public override void Up()
        {
            
            CreateIndex("dbo.sucursales", "municipio");
            AddForeignKey("dbo.sucursales", "municipio", "dbo.municipios", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sucursales", "municipio", "dbo.municipios");
            DropIndex("dbo.sucursales", new[] { "municipio" });
        }
    }
}
