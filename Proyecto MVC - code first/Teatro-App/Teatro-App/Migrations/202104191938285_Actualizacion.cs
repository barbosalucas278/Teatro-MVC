namespace Teatro_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Actualizacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evento", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.IntegranteInstrumentoPuestoEvento", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Instrumento", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Integrante", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Puesto", "Nombre", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Orquesta", "Nombre", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Evento", "Obra");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Evento", "Obra", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Orquesta", "Nombre", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Puesto", "Nombre", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Integrante", "Nombre", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Instrumento", "Nombre", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.IntegranteInstrumentoPuestoEvento", "Nombre");
            DropColumn("dbo.Evento", "Nombre");
        }
    }
}
