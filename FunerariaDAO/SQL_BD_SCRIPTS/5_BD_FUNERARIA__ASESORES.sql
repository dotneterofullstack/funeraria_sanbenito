USE funeraria 
go
create table Cargos (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	Nombre			VARCHAR(100)	NOT NULL
)
go

USE funeraria
GO
INSERT INTO Cargos VALUES
('Asesor Ejecutivo')
,('Gestor')
,('Director')
,('Gerente de Cobranza')
,('Gerente de Ventas')
,('Gerente de Contabilidad')
,('Gerente de Recursos Humanos')
,('Gerente de Capillas')
GO

use funeraria
go
create table Asesores (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdCargo			INT				NOT NULL,
	IdAsesorInvita	INT				NULL,
	Codigo			VARCHAR(10)		NOT NULL	UNIQUE,
	Nombre			VARCHAR(100)	NOT NULL,
	ApellidoPat		VARCHAR(100)	NOT NULL,
	ApellidoMat		VARCHAR(100)	NOT NULL,
	RFC				VARCHAR(20)		NULL
	FOREIGN KEY(IdCargo)			REFERENCES Cargos(ID),
	FOREIGN KEY(IdAsesorInvita)		REFERENCES Asesores(ID)
)
go

use funeraria
go
create table rel_telefonos_asesores (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdAsesor		INT				NOT NULL,
	IdTelefono		INT				NOT NULL,
	FOREIGN KEY(IdAsesor)			REFERENCES Asesores(ID),
	FOREIGN KEY(IdTelefono)			REFERENCES Telefonos(ID)
)
go

use funeraria
go
create table rel_asesores_domicilios (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdAsesor		INT				NOT NULL,
	IdDomicilio		INT				NOT NULL,
	FOREIGN KEY(IdAsesor)			REFERENCES Asesores(ID),
	FOREIGN KEY(IdDomicilio)		REFERENCES Domicilios(ID)
)
go

use funeraria
go
create table Documentos (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	Documento		VARCHAR(100)	NOT NULL,
)
go

use funeraria
go
insert into documentos values
('Solicitud de Empleo'),
('Credencial para Votar'),
('Comprobante de Domicilio'),
('Carta de Policia')
go

use funeraria
go
create table rel_asesores_documentos (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdAsesor		INT				NOT NULL,
	IdDocumento		INT				NOT NULL,
	FOREIGN KEY(IdAsesor)			REFERENCES Asesores(ID),
	FOREIGN KEY(IdDocumento)		REFERENCES Documentos(ID)
)
go











