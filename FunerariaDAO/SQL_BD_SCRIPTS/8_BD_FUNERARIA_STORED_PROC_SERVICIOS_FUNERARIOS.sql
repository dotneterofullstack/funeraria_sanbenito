USE FUNERARIA
GO
create procedure sp_select_ServiciosFunerarios(
	@ID							int = 0,		
	@IdPaquete					int = 0,		
	@IdAsesor					int = 0,		
	@IdCliente					int = 0,		
	@IdDomicilioCobranza		int = 0,		
	@NumeroSolicitud			VARCHAR(10) = '',
	@NumeroContrato				VARCHAR(10) = '',
	@IdFrecuenciaAbonos			int = -1,		
	@ServicioYaProporcionado	BIT = null,
	@IdEstatusCobranza			int = -1		
)
as begin
	select
		 ServiciosFunerarios.ID							
		,IdPaquete					
		,IdAsesor					
		,IdCliente					
		,IdDomicilioCobranza		
		,FechaSolicitud				
		,FechaContrato				
		,NumeroSolicitud			
		,NumeroContrato				
		,Costo						
		,TitularSustituto			
		,IdFrecuenciaAbonos			
		,ServicioYaProporcionado	
		,IdEstatusCobranza			
		,Paquetes_servicio.Descripcion as Paquete
		,Asesores.Nombre + ' ' + Asesores.ApellidoPat + ' ' + Asesores.ApellidoMat as Asesor
		,Clientes.Nombre + ' ' + Clientes.ApellidoPat + ' ' + Clientes.ApellidoMat as Cliente
		,Domicilios.Calle + ' No. ' + Domicilios.NumeroExterior as Domicilio
		,Frecuencia_abonos.Descripcion as FrecuenciaAbonos
		,EstatusCobranzaServicio.Estatus as EstatusCobranza
	from ServiciosFunerarios
	inner join Paquetes_servicio on Paquetes_servicio.ID = IdPaquete
	inner join Asesores on Asesores.ID = IdAsesor
	inner join Clientes on Clientes.ID = IdCliente
	inner join Domicilios on Domicilios.ID = IdDomicilioCobranza
	inner join Frecuencia_abonos on Frecuencia_abonos.ID = IdFrecuenciaAbonos
	inner join EstatusCobranzaServicio on EstatusCobranzaServicio.ID = IdEstatusCobranza
	where
		(@ID							 = 0 or			ServiciosFunerarios.ID = @ID) and
		(@IdPaquete						 = 0 or			IdPaquete = @IdPaquete) and
		(@IdAsesor						 = 0 or			IdAsesor = @IdAsesor) and
		(@IdCliente						 = 0 or			IdCliente = @IdCliente) and
		(@IdDomicilioCobranza			 = 0 or			IdDomicilioCobranza = @IdDomicilioCobranza) and
		(@NumeroSolicitud				 = '' or		NumeroSolicitud = @NumeroSolicitud) and
		(@NumeroContrato				 = '' or		NumeroContrato = @NumeroContrato) and
		(@IdFrecuenciaAbonos			= - 1 or		IdFrecuenciaAbonos = @IdFrecuenciaAbonos) and
		(@ServicioYaProporcionado		is null or		ServicioYaProporcionado= @ServicioYaProporcionado) and
		(@IdEstatusCobranza = -1 or						IdEstatusCobranza = @IdEstatusCobranza)			
end
go

use funeraria
go
create procedure guardar_servicioFunerario (
	 @ID						int			
	,@IdPaquete					int			
	,@IdAsesor					int			
	,@IdCliente					int			
	,@IdDomicilioCobranza		int			
	,@FechaSolicitud			DATETIME
	,@FechaContrato				DATETIME
	,@NumeroSolicitud			VARCHAR(10) 
	,@NumeroContrato			VARCHAR(10) 
	,@Costo						DECIMAL(9,2)
	,@TitularSustituto			DECIMAL(9,2)
	,@IdFrecuenciaAbonos		int			
	,@ServicioYaProporcionado	BIT			
	,@IdEstatusCobranza			int			
) as begin
	if @ID = 0
	BEGIN
		INSERT INTO ServiciosFunerarios VALUES(					
			 @IdPaquete					
			,@IdAsesor					
			,@IdCliente					
			,@IdDomicilioCobranza		
			,@FechaSolicitud			
			,@FechaContrato				
			,@NumeroSolicitud			
			,@NumeroContrato			
			,@Costo						
			,@TitularSustituto			
			,@IdFrecuenciaAbonos		
			,@ServicioYaProporcionado	
			,@IdEstatusCobranza			
		)

		return SCOPE_IDENTITY()
	END
	ELSE if @ID > 0
	BEGIN
		UPDATE ServiciosFunerarios SET
			 IdPaquete					= @IdPaquete									
			,IdAsesor					= @IdAsesor					
			,IdCliente					= @IdCliente					
			,IdDomicilioCobranza		= @IdDomicilioCobranza		
			,FechaSolicitud				= @FechaSolicitud			
			,FechaContrato				= @FechaContrato				
			,NumeroSolicitud			= @NumeroSolicitud			
			,NumeroContrato				= @NumeroContrato			
			,Costo						= @Costo						
			,TitularSustituto			= @TitularSustituto			
			,IdFrecuenciaAbonos			= @IdFrecuenciaAbonos		
			,ServicioYaProporcionado	= @ServicioYaProporcionado	
			,IdEstatusCobranza			= @IdEstatusCobranza			
		WHERE ID = @ID
	END
	ELSE
	BEGIN
		RETURN 0
	END
end
go