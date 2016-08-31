use funeraria
go
create procedure sp_select_estatusCobranzaServicio
as begin
	select ID, Estatus from funeraria..EstatusCobranzaServicio
end
go

use funeraria
go
create procedure sp_select_tiposPagoServicio
as begin
	select ID, TipoPago from funeraria..TiposPagoServicio
end
go

use funeraria
go
create procedure sp_select_ServiciosFunerarios(
	@ID							int = 0,
	@IdPaquete					int = 0,
	@IdAsesor					int = 0,
	@IdCliente					int = 0,
	@NumeroSolicitud			VARCHAR(10)	= '',
	@NumeroContrato				VARCHAR(10)	= '',
	@ServicioYaProporcionado	BIT = null,
	@IdEstatusCobranza			int = -1			
) as begin
	select 
		ID							,
		IdPaquete					,
		IdAsesor					,
		IdCliente					,
		IdDomicilioCobranza			,
		FechaSolicitud				,
		FechaContrato				,
		NumeroSolicitud				,
		NumeroContrato				,
		Costo						,
		TitularSustituto			,
		IdFrecuenciaAbonos			,
		ServicioYaProporcionado		,
		IdEstatusCobranza			
	from funeraria..ServiciosFunerarios
	where
	(@ID = 0 or ID = @ID) and		
	(@IdPaquete = 0 or IdPaquete = @IdPaquete) and
	(@IdAsesor = 0 or IdAsesor = @IdAsesor) and
	(@IdCliente = 0 or IdCliente = @IdCliente) and
	(@NumeroSolicitud = '' or NumeroSolicitud = @NumeroSolicitud) and
	(@NumeroContrato = '' or NumeroContrato = @NumeroContrato) and	
	(@ServicioYaProporcionado is null or ServicioYaProporcionado = @ServicioYaProporcionado) and
	(@IdEstatusCobranza = -1 or IdEstatusCobranza = @IdEstatusCobranza)
end
go