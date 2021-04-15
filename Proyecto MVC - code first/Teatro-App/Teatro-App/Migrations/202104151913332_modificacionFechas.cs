namespace Teatro_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modificacionFechas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Evento", "FechaBaja", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Evento", "FechaModificacion", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.IntegranteInstrumentoPuestoEvento", "FechaBaja", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.IntegranteInstrumentoPuestoEvento", "FechaModificacion", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Instrumento", "FechaBaja", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Instrumento", "FechaModificacion", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Integrante", "FechaBaja", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Integrante", "FechaModificacion", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Puesto", "FechaBaja", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Puesto", "FechaModificacion", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orquesta", "FechaBaja", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orquesta", "FechaModificacion", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orquesta", "FechaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orquesta", "FechaBaja", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Puesto", "FechaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Puesto", "FechaBaja", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Integrante", "FechaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Integrante", "FechaBaja", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Instrumento", "FechaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Instrumento", "FechaBaja", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.IntegranteInstrumentoPuestoEvento", "FechaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.IntegranteInstrumentoPuestoEvento", "FechaBaja", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Evento", "FechaModificacion", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Evento", "FechaBaja", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
