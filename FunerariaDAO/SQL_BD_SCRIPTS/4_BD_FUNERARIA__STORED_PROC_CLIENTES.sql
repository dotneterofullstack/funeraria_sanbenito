use funeraria
go
create procedure seleccionar_telefonos_cliente (
	@idCliente int
) as begin
	with idTelefonos as (
		select idTelefono
		from rel_telefonos_clientes
		where IdCliente = @idCliente
	)
	SELECT [ID]
		  ,[IdTipoTelefono]
		  ,[Telefono]
		  ,isnull(Extension, '') as Extension
	FROM [dbo].[Telefonos]
	INNER JOIN idTelefonos ON ID = idTelefonos.IdTelefono
end
go

use funeraria
go
create procedure seleccionar_domicilios_cliente (
	@idCliente int
) as begin
	with idDomicilios as (
		select idDomicilio
		from rel_clientes_domicilios
		where IdCliente = @idCliente
	)
	SELECT [ID]
		  ,[IdMunicipio]
		  ,[Calle]
		  ,[NumeroExterior]
		  ,isnull(NumeroInterior, '') as NumeroInterior
		  ,[Colonia]
		  ,[CodigoPostal]
		  ,isnull(EntreCalles, '') as EntreCalles
		  ,isnull(Latitud, '') as Latitud
		  ,isnull(Longitud, '') as Longitud
	FROM [dbo].[Domicilios]
	INNER JOIN idDomicilios ON ID = IdDomicilio
end
go

use funeraria 
go
create procedure seleccionar_clientes (
	@id int = 0,
	@nombre varchar(100) = '',
	@apellidoPat varchar(100) = '',
	@apellidoMat varchar(100) = '',
	@rfc varchar(20) = ''
) as begin
	SELECT [ID]
		,[Nombre]
		,[ApellidoPat]
		,[ApellidoMat]
		,[RFC]
	FROM [dbo].[Clientes]
	WHERE 
		(@id = 0 or ID = @id) AND
		(@nombre = '' or Nombre like '%' + @nombre + '%') AND	
		(@apellidoPat = '' or ApellidoPat like '%' + @apellidoPat + '%') AND
		(@apellidoMat = '' or ApellidoMat like '%' + @apellidoMat + '%')
end
go

use funeraria
go
create procedure guardar_cliente (
	@id int,
	@nombre varchar(100),
	@apellidoPat varchar(100),
	@apellidoMat varchar(100),
	@rfc varchar(20) = ''
) as begin
	
	if @id = 0
	begin
		INSERT INTO [dbo].[Clientes]
			   ([Nombre]
			   ,[ApellidoPat]
			   ,[ApellidoMat]
			   ,[RFC])
		 VALUES
			   (@nombre
			   ,@apellidoPat
			   ,@apellidoMat
			   ,@rfc)

		return scope_identity()
	end
	if @id > 0
	begin
		if EXISTS(SELECT * FROM Clientes WHERE ID = @id)
		BEGIN
			UPDATE [dbo].[Clientes]
			   SET [Nombre] = @nombre
				  ,[ApellidoPat] = @apellidoPat
				  ,[ApellidoMat] = @apellidoMat
				  ,[RFC] = @rfc
			 WHERE ID = @id

			 RETURN @@rowcount
		END
		ELSE
		BEGIN
			RETURN 0
		END
	end

	return 0
end
go

use funeraria
go
create procedure guardar_telefono_cliente (
	@idCliente int,
	@idTipoTelefono int,
	@telefono varchar(10),
	@extension varchar(5) = null
) as begin
	DECLARE @idTelefono as int

	INSERT INTO [dbo].[Telefonos]
		([IdTipoTelefono]
		,[Telefono]
		,[Extension])
	VALUES
		(@idTipoTelefono
		,@telefono
		,@extension)

	set @idTelefono = SCOPE_IDENTITY()

	INSERT INTO [dbo].[rel_telefonos_clientes]
		([IdCliente]
		,[IdTelefono])
	VALUES
		(@idCliente
		,@idTelefono)

	return SCOPE_IDENTITY()
end
go

use funeraria 
go
create procedure guardar_domicilio_cliente (
	@idCliente int,
	@idDomicilio int = 0,
	@idMunicipio int,
	@calle varchar(200),
	@numeroExterior varchar(10),
	@numeroInterior varchar(10) = null,
	@colonia varchar(200),
	@codigoPostal varchar(10),
	@entreCalles varchar(400) = null,
	@latitud varchar(10) = null,
	@longitud varchar(10) = null
) as begin
	if @idDomicilio > 0
	begin
		UPDATE [dbo].[Domicilios]
		SET IdMunicipio = @idMunicipio
			,[Calle] = @calle
			,[NumeroExterior] = @numeroExterior
			,[NumeroInterior] = @numeroInterior
			,[Colonia] = @colonia
			,[CodigoPostal] = @codigoPostal
			,[EntreCalles] = @entreCalles
			,[Latitud] = @latitud
			,[Longitud] = @longitud
		WHERE ID = @idDomicilio

		return @@rowcount
	end
	else
	begin
		INSERT INTO [dbo].[Domicilios]
			([IdMunicipio]
			,[Calle]
			,[NumeroExterior]
			,[NumeroInterior]
			,[Colonia]
			,[CodigoPostal]
			,[EntreCalles]
			,[Latitud]
			,[Longitud])
		VALUES
			(@idMunicipio
			,@calle
			,@numeroExterior
			,@numeroInterior
			,@colonia
			,@codigoPostal
			,@entreCalles
			,@latitud
			,@longitud)

		set @idDomicilio = SCOPE_IDENTITY()

		INSERT INTO [dbo].[rel_clientes_domicilios]
			([IdCliente]
			,[IdDomicilio])
		VALUES
			(@idCliente
			,@idDomicilio)

		return scope_identity()
	end
end
go

use funeraria
go
create procedure seleccionar_tipos_telefono 
as begin
	SELECT [ID]
		,[Nombre]
	FROM [dbo].[TipoTelefono]
end
go

use funeraria
go
create procedure seleccionar_estatus_servicio
as begin
	SELECT [ID]
		,[Nombre]
	FROM [dbo].[estatus_servicio]
end
go

use funeraria
go
create procedure seleccionar_paquetes_servicio (
	@id int = 0,
	@soloCremacion bit = null
) as begin
	SELECT [ID]
		,[Descripcion]
		,[Precio]
		,[Comision]
		,[SoloCremacion]
	FROM [dbo].[Paquetes_servicio]
	WHERE (@id = 0 or ID = @id)
	AND (@soloCremacion is null or [SoloCremacion] = @soloCremacion)
end
go

USE funeraria
GO
create procedure seleccionar_frecuencia_abonos
as begin
	SELECT [ID]
		  ,[Descripcion]
		  ,[Dias]
		  ,[SoloDiasHabiles]
	  FROM [dbo].[Frecuencia_abonos]		
end
GO

use funeraria 
go
create procedure guardar_paquete_servicio (
	@idPaquete int,
	@Descripcion varchar(250),
	@Precio decimal(9,2),
	@Comision decimal(9,2),
	@SoloCremacion bit
) as begin 
	
	if exists(select * from Paquetes_servicio where ID = @idPaquete)
	begin
		UPDATE [dbo].[Paquetes_servicio]
		   SET [Descripcion] = @Descripcion
			  ,[Precio] = @Precio
			  ,[Comision] = @Comision
			  ,[SoloCremacion] = @SoloCremacion
		 WHERE ID = @idPaquete

		 return @@rowcount
	end
	else
	begin
		INSERT INTO [dbo].[Paquetes_servicio]
				   ([Descripcion]
				   ,[Precio]
				   ,[Comision]
				   ,[SoloCremacion])
			 VALUES
				   (@Descripcion
				   ,@Precio
				   ,@Comision
				   ,@SoloCremacion)

		return scope_identity()
	end

	RETURN 0
end
go