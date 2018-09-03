USE [SGSST4]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[SP_ALERTA_AUSENTISMO_CONSULTAR_TODOS](
	@anioGestion int,
	@NitEmpresa varchar(50)
	)
AS
BEGIN
	-- Retorna la lista de ausencias para todas las empresas usuarias
	-- en un año de gestión.
	select 
		a.Documento_Persona DocumentoPersona, 
		a.FK_Id_Contingencia IdContingencia, 
		a.FechaInicio FechaInicio, 
		a.Fecha_Fin FechaFin,
		a.NitEmpresa NitEmpresa,
		a.NombrePersona NombrePersona,
		a.FK_Id_Diagnostico Id_Diagnostico,
		a.Pk_Id_Ausencias Id_Ausencia
	from 
		Tbl_Ausencias a
	where 
		a.NitEmpresa =@NitEmpresa
		and (
			year(a.FechaInicio) = @anioGestion
			or year(a.Fecha_Fin) = @anioGestion
			)
	order by 
		a.Documento_Persona, a.FechaInicio;

END;
GO
