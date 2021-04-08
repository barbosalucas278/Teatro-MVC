IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Evento_Orquesta]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Evento] DROP CONSTRAINT [FK_Evento_Orquesta]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_IntegranteInstrumentoPuestoEvento_Evento]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [IntegranteInstrumentoPuestoEvento] DROP CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Evento]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_IntegranteInstrumentoPuestoEvento_Instrumento]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [IntegranteInstrumentoPuestoEvento] DROP CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Instrumento]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_IntegranteInstrumentoPuestoEvento_Integrante]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [IntegranteInstrumentoPuestoEvento] DROP CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Integrante]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_IntegranteInstrumentoPuestoEvento_Puesto]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [IntegranteInstrumentoPuestoEvento] DROP CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Puesto]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Evento]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Evento]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Instrumento]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Instrumento]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Integrante]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Integrante]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[IntegranteInstrumentoPuestoEvento]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [IntegranteInstrumentoPuestoEvento]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Orquesta]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Orquesta]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Puesto]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Puesto]
;

CREATE TABLE [Evento]
(
	[id] int NOT NULL IDENTITY (1, 1),
	[OrquestaId] int NOT NULL,
	[Obra] nvarchar(200) NOT NULL,
	[Dia] datetime2(7) NOT NULL,
	[Activo] bit NOT NULL DEFAULT 1
)
;

CREATE TABLE [Instrumento]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Nombre] nvarchar(100) NOT NULL,
	[Activo] bit NOT NULL DEFAULT 1
)
;

CREATE TABLE [Integrante]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Nombre] nvarchar(150) NOT NULL,
	[Apellido] nvarchar(150) NOT NULL,
	[Edad] int NOT NULL,
	[Telefono] int,
	[Activo] bit NOT NULL DEFAULT 1,
	[Dni] nvarchar(15) NOT NULL
)
;

CREATE TABLE [IntegranteInstrumentoPuestoEvento]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[EventoId] int NOT NULL,
	[PuestoId] int NOT NULL,
	[IntegranteId] int NOT NULL,
	[InstrumentoId] int NOT NULL,
	[FechaInscripcion] datetime2(7) NOT NULL,
	[FechaBaja] datetime2(7) NOT NULL,
	[Activo] bit NOT NULL DEFAULT 1
)
;

CREATE TABLE [Orquesta]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Nombre] nvarchar(150) NOT NULL,
	[Localidad] nvarchar(150) NOT NULL,
	[Activo] bit NOT NULL DEFAULT 1
)
;

CREATE TABLE [Puesto]
(
	[Id] int NOT NULL IDENTITY (1, 1),
	[Nombre] nvarchar(100) NOT NULL,
	[Activo] bit NOT NULL DEFAULT 1
)
;

CREATE INDEX [IXFK_Evento_Orquesta] 
 ON [Evento] ([OrquestaId] ASC)
;

ALTER TABLE [Evento] 
 ADD CONSTRAINT [PK_Evento]
	PRIMARY KEY CLUSTERED ([id])
;

ALTER TABLE [Instrumento] 
 ADD CONSTRAINT [PK_Instrumento]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Integrante] 
 ADD CONSTRAINT [PK_Integrante]
	PRIMARY KEY CLUSTERED ([Id])
;

CREATE INDEX [IXFK_IntegranteInstrumentoPuestoEvento_Evento] 
 ON [IntegranteInstrumentoPuestoEvento] ([EventoId] ASC)
;

CREATE INDEX [IXFK_IntegranteInstrumentoPuestoEvento_Instrumento] 
 ON [IntegranteInstrumentoPuestoEvento] ([InstrumentoId] ASC)
;

CREATE INDEX [IXFK_IntegranteInstrumentoPuestoEvento_Integrante] 
 ON [IntegranteInstrumentoPuestoEvento] ([IntegranteId] ASC)
;

CREATE INDEX [IXFK_IntegranteInstrumentoPuestoEvento_Puesto] 
 ON [IntegranteInstrumentoPuestoEvento] ([PuestoId] ASC)
;

ALTER TABLE [IntegranteInstrumentoPuestoEvento] 
 ADD CONSTRAINT [PK_IntegranteInstrumentoPuestoEvento]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Orquesta] 
 ADD CONSTRAINT [PK_Orquesta]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Puesto] 
 ADD CONSTRAINT [PK_Puesto]
	PRIMARY KEY CLUSTERED ([Id])
;

ALTER TABLE [Evento] ADD CONSTRAINT [FK_Evento_Orquesta]
	FOREIGN KEY ([OrquestaId]) REFERENCES [Orquesta] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [IntegranteInstrumentoPuestoEvento] ADD CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Evento]
	FOREIGN KEY ([EventoId]) REFERENCES [Evento] ([id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [IntegranteInstrumentoPuestoEvento] ADD CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Instrumento]
	FOREIGN KEY ([InstrumentoId]) REFERENCES [Instrumento] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [IntegranteInstrumentoPuestoEvento] ADD CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Integrante]
	FOREIGN KEY ([IntegranteId]) REFERENCES [Integrante] ([Id]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [IntegranteInstrumentoPuestoEvento] ADD CONSTRAINT [FK_IntegranteInstrumentoPuestoEvento_Puesto]
	FOREIGN KEY ([PuestoId]) REFERENCES [Puesto] ([Id]) ON DELETE No Action ON UPDATE No Action
;
