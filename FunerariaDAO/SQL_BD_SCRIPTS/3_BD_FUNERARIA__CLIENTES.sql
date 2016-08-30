use funeraria
go
create table Clientes (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	Nombre			VARCHAR(100)	NOT NULL,
	ApellidoPat		VARCHAR(100)	NOT NULL,
	ApellidoMat		VARCHAR(100)	NOT NULL,
	RFC				VARCHAR(20)		NULL
)
go

use funeraria
go
create table TipoTelefono (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	Nombre			VARCHAR(15)		NOT NULL
)
go

use funeraria
go
create table Telefonos (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdTipoTelefono	INT				NOT NULL,
	Telefono		VARCHAR(10)		NOT NULL,
	Extension		VARCHAR(5)		NULL,
	FOREIGN KEY(IdTipoTelefono)		REFERENCES TipoTelefono(ID)
)
go

use funeraria
go
create table rel_telefonos_clientes (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdCliente		INT				NOT NULL,
	IdTelefono		INT				NOT NULL,
	FOREIGN KEY(IdCliente)			REFERENCES Clientes(ID),
	FOREIGN KEY(IdTelefono)			REFERENCES Telefonos(ID)
)
go

use funeraria
go
create table Domicilios (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdMunicipio		INT				NOT NULL,
	Calle			VARCHAR(200)	NOT NULL,
	NumeroExterior	VARCHAR(10)		NOT NULL,
	NumeroInterior	VARCHAR(10)		NULL,
	Colonia			VARCHAR(200)	NOT NULL,
	CodigoPostal	VARCHAR(10)		NOT NULL,
	EntreCalles		VARCHAR(400)	NULL,
	Latitud			VARCHAR(10)		NULL,
	Longitud		VARCHAR(10)		NULL,
	FOREIGN KEY(IdMunicipio)		REFERENCES Municipios(ID)
)
go

use funeraria
go
create table rel_clientes_domicilios (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	IdCliente		INT				NOT NULL,
	IdDomicilio		INT				NOT NULL,
	FOREIGN KEY(IdCliente)			REFERENCES Clientes(ID),
	FOREIGN KEY(IdDomicilio)		REFERENCES Domicilios(ID)
)
go

use funeraria
go
create table Paquetes_servicio (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	Descripcion		VARCHAR(250)	NOT NULL,
	Precio			DECIMAL(9,2)	NOT NULL,
	Comision		DECIMAL(9,2)	NOT NULL,
	SoloCremacion	bit				NOT NULL
)
go

use funeraria
go
create table Frecuencia_abonos (
	ID				INT				NOT NULL	PRIMARY KEY	IDENTITY(1, 1),
	Descripcion		VARCHAR(10)		NOT NULL,
	Dias			INT				NOT NULL,
	SoloDiasHabiles	BIT				NOT NULL
)
go

-- use funeraria
-- go
-- insert into Paquetes_servicio values
-- ('Ata�d Met�lico Modelo Imperial', 12500, 1000, 0),
-- ('Ata�d madera Italia Tapa plana', 16500, 1500, 0),
-- ('Ata�d madera Americano', 23000, 2000, 0)
-- go
