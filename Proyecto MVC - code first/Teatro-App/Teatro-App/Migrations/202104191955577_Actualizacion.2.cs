namespace Teatro_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualizacion2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Evento", name: "datetime2", newName: "Dia");
            AlterColumn("dbo.Evento", "Dia", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Evento", "Dia", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Evento", name: "Dia", newName: "datetime2");
        }
    }
}
