use funeraria 
go
create procedure seleccionar_cargos
as begin
	SELECT [ID]
		  ,[Nombre]
	  FROM [dbo].[Cargos]
end
go

use funeraria
go
create procedure guardar_cargo (
	@nombre varchar(100)
) as begin
	INSERT INTO [Cargos]
			   ([Nombre])
		 VALUES
			   (@nombre)

	return SCOPE_IDENTITY()
end
go

use funeraria
go
create procedure seleccionar_telefonos_asesor (
	@idAsesor int
) as begin
	with idTelefonos as (
		select idTelefono
		from rel_telefonos_Asesores
		where IdAsesor = @idAsesor
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
create procedure seleccionar_domicilios_Asesor (
	@idAsesor int
) as begin
	with idDomicilios as (
		select idDomicilio
		from rel_Asesores_domicilios
		where IdAsesor = @idAsesor
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
create procedure seleccionar_Asesores (
	@id int = 0,
	@Cargo int = 0,
	@AsesorInvita int = 0,
	@codigo varchar(10) = '',
	@nombre varchar(100) = '',
	@apellidoPat varchar(100) = '',
	@apellidoMat varchar(100) = '',
	@rfc varchar(20) = ''
) as begin
	SELECT [ID]
	    ,[IdCargo]
		,isnull(IdAsesorInvita, 0) as IdAsesorInvita
		,[Codigo]
		,[Nombre]
		,[ApellidoPat]
		,[ApellidoMat]
		,[RFC]
	FROM [dbo].[Asesores]
	WHERE 
		(@id = 0 or ID = @id) AND
		(@Cargo = 0 or IdCargo = @Cargo) AND
		(@AsesorInvita = 0 or IdAsesorInvita = @AsesorInvita) AND
		(@codigo = '' or Codigo LIKE '%' + @codigo + '%') AND
		(@nombre = '' or Nombre like '%' + @nombre + '%') AND	
		(@apellidoPat = '' or ApellidoPat like '%' + @apellidoPat + '%') AND
		(@apellidoMat = '' or ApellidoMat like '%' + @apellidoMat + '%')
end
go

use funeraria
go
create procedure guardar_Asesor (
	@id int,
	@Cargo int,
	@AsesorInvita int = null,
	@codigo varchar(10),
	@nombre varchar(100),
	@apellidoPat varchar(100),
	@apellidoMat varchar(100),
	@rfc varchar(20) = ''
) as begin
	
	if @id = 0
	begin
		INSERT INTO [dbo].[Asesores]
			   ([IdCargo]
			   ,[IdAsesorInvita]
			   ,[Codigo]
			   ,[Nombre]
			   ,[ApellidoPat]
			   ,[ApellidoMat]
			   ,[RFC])
		 VALUES
			   (@Cargo
			   ,@AsesorInvita
			   ,@codigo
			   ,@nombre
			   ,@apellidoPat
			   ,@apellidoMat
			   ,@rfc)

		return scope_identity()
	end
	if @id > 0
	begin
		if EXISTS(SELECT * FROM Asesores WHERE ID = @id)
		BEGIN
			UPDATE [dbo].[Asesores]
			   SET [IdCargo] = @Cargo
				  ,[IdAsesorInvita] = @AsesorInvita
				  ,[Codigo] = @codigo
				  ,[Nombre] = @nombre
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
create procedure guardar_telefono_Asesor (
	@idAsesor int,
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

	INSERT INTO [dbo].[rel_telefonos_Asesores]
		([IdAsesor]
		,[IdTelefono])
	VALUES
		(@idAsesor
		,@idTelefono)

	return SCOPE_IDENTITY()
end
go

use funeraria 
go
create procedure guardar_domicilio_Asesor (
	@idAsesor int,
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

		INSERT INTO [dbo].[rel_Asesores_domicilios]
			([IdAsesor]
			,[IdDomicilio])
		VALUES
			(@idAsesor
			,@idDomicilio)

		return scope_identity()
	end
end
go

use funeraria
go
create procedure guardar_documento_Asesor (
	@idAsesor int,
	@idDocumento int
) as begin
	INSERT INTO [dbo].[rel_asesores_documentos]
		([IdAsesor]
		,[IdDocumento])
	VALUES
		(@idAsesor
		,@idDocumento)

	return SCOPE_IDENTITY()
end
go

use funeraria
go
create procedure [dbo].[seleccionar_documentos_asesor] (
	@idAsesor int
) as begin
	select
		rel.ID
		,rel.IdAsesor
		,rel.IdDocumento
	from rel_asesores_documentos rel 
	where rel.IdAsesor = @idAsesor
end
go

use funeraria
go
create procedure seleccionar_documentos
as begin
	select
		ID,
		Documento
	from Documentos
end
go