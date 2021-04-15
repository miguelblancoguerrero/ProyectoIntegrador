namespace ProyectoIntegrador.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class partial_01_08_03_21_3 : DbMigration
    {
        public override void Up()
        {
            
            RenameTable(name: "dbo.prcedimientos", newName: "procedimientos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.procedimientos", newName: "prcedimientos");
        }
    }
}
