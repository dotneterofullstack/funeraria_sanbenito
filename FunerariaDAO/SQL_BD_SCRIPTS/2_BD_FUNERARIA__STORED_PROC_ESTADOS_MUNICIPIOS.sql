use funeraria
go

create procedure sp_select_estados 
as begin
	select ID, Nombre, Abreviatura from funeraria..Estados
end
go

USE [funeraria]
GO
CREATE procedure [dbo].[sp_select_municipios]
 as begin
	select ID, IDEstado, Nombre 
	from Municipios
end
GO

use funeraria
go
create procedure sp_select_municipios_por_estado
(
	@id int
) as begin
	select ID, IDEstado, Nombre 
	from Municipios
	where IdEstado = @id
end
go

