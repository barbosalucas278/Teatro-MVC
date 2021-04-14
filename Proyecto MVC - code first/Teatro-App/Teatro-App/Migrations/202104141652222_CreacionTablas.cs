namespace Teatro_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrquestaId = c.Int(nullable: false),
                        Obra = c.String(nullable: false, maxLength: 200),
                        datetime2 = c.DateTime(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaBaja = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioModificacion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        MarcaUso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orquesta", t => t.OrquestaId)
                .Index(t => t.OrquestaId);
            
            CreateTable(
                "dbo.IntegranteInstrumentoPuestoEvento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventoId = c.Int(nullable: false),
                        PuestoId = c.Int(nullable: false),
                        IntegranteId = c.Int(nullable: false),
                        InstrumentoId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaBaja = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioModificacion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        MarcaUso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Evento", t => t.EventoId)
                .ForeignKey("dbo.Instrumento", t => t.InstrumentoId)
                .ForeignKey("dbo.Integrante", t => t.IntegranteId)
                .ForeignKey("dbo.Puesto", t => t.PuestoId)
                .Index(t => t.EventoId)
                .Index(t => t.PuestoId)
                .Index(t => t.IntegranteId)
                .Index(t => t.InstrumentoId);
            
            CreateTable(
                "dbo.Instrumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        FechaCreacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaBaja = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioModificacion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        MarcaUso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Integrante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150),
                        Apellido = c.String(nullable: false, maxLength: 150),
                        Edad = c.Int(nullable: false),
                        Telefono = c.String(nullable: false, maxLength: 20),
                        Dni = c.String(nullable: false, maxLength: 15),
                        FechaCreacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaBaja = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioModificacion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        MarcaUso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Puesto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        FechaCreacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaBaja = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioModificacion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        MarcaUso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orquesta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 150),
                        Localidad = c.String(nullable: false, maxLength: 150),
                        FechaCreacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaBaja = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaModificacion = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UsuarioModificacion = c.String(nullable: false, maxLength: 150),
                        Activo = c.Boolean(nullable: false),
                        MarcaUso = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evento", "OrquestaId", "dbo.Orquesta");
            DropForeignKey("dbo.IntegranteInstrumentoPuestoEvento", "PuestoId", "dbo.Puesto");
            DropForeignKey("dbo.IntegranteInstrumentoPuestoEvento", "IntegranteId", "dbo.Integrante");
            DropForeignKey("dbo.IntegranteInstrumentoPuestoEvento", "InstrumentoId", "dbo.Instrumento");
            DropForeignKey("dbo.IntegranteInstrumentoPuestoEvento", "EventoId", "dbo.Evento");
            DropIndex("dbo.IntegranteInstrumentoPuestoEvento", new[] { "InstrumentoId" });
            DropIndex("dbo.IntegranteInstrumentoPuestoEvento", new[] { "IntegranteId" });
            DropIndex("dbo.IntegranteInstrumentoPuestoEvento", new[] { "PuestoId" });
            DropIndex("dbo.IntegranteInstrumentoPuestoEvento", new[] { "EventoId" });
            DropIndex("dbo.Evento", new[] { "OrquestaId" });
            DropTable("dbo.Orquesta");
            DropTable("dbo.Puesto");
            DropTable("dbo.Integrante");
            DropTable("dbo.Instrumento");
            DropTable("dbo.IntegranteInstrumentoPuestoEvento");
            DropTable("dbo.Evento");
        }
    }
}
