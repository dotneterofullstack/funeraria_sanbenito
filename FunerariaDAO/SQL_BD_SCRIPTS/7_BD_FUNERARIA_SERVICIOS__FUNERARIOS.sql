use funeraria
go 
create table EstatusCobranzaServicio (
	ID		int			not null	identity(1, 1)	primary key,
	Estatus varchar(50) not null
)
go

use funeraria 
go
insert into EstatusCobranzaServicio values
	('Cancelado'),
	('En proceso de Pago'),
	('Pago finiquitado')
go

use funeraria
go
create table TiposPagoServicio (
	ID			int			not null	identity(1, 1)	primary key,
	TipoPago	varchar(50)	not null
)
go

use funeraria
insert into TiposPagoServicio values
	('Inversión Inicial'),
	('Abono')
go

use funeraria
go
create table ServiciosFunerarios (
	ID							int				not null	identity(1, 1) primary key,
	IdPaquete					int				not null,
	IdAsesor					int				not null,
	IdCliente					int				not null,
	IdDomicilioCobranza			int				not null,
	FechaSolicitud				datetime		not null,
	FechaContrato				datetime		NOT null,
	NumeroSolicitud				VARCHAR(10)		NOT NULL	UNIQUE,
	NumeroContrato				VARCHAR(10)		NOT NULL	UNIQUE,
	Costo						DECIMAL(9,2)	NOT NULL,
	TitularSustituto			VARCHAR(500)	NULL,
	IdFrecuenciaAbonos			int				not null,
	ServicioYaProporcionado		BIT				NOT NULL	DEFAULT 0,
	IdEstatusCobranza			int				not null,

	FOREIGN KEY(IdPaquete)				REFERENCES Paquetes_servicio(ID),
	FOREIGN KEY(IdAsesor)				REFERENCES Asesores(ID),
	FOREIGN KEY(IdCliente)				REFERENCES Clientes(ID),
	FOREIGN KEY(IdDomicilioCobranza)	REFERENCES Domicilios(ID),
	FOREIGN KEY(IdFrecuenciaAbonos)		REFERENCES Frecuencia_abonos(ID),
	FOREIGN KEY(IdEstatusCobranza)		REFERENCES EstatusCobranzaServicio(ID),
)
go

use funeraria
go
create procedure sp_select_EstatusCobranzaServicio
as begin
	select ID, Estatus from funeraria..EstatusCobranzaServicio
end
go

use funeraria
go
create procedure sp_select_TiposPagoServicio
as begin
	select ID, TipoPago from funeraria..TiposPagoServicio
end
go

use funeraria
go