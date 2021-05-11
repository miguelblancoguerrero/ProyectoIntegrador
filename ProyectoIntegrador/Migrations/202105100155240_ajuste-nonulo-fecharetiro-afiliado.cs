namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustenonulofecharetiroafiliado : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.afiliados", "fecha_retiro", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.afiliados", "fecha_retiro", c => c.DateTime(nullable: false));
        }
    }
}
