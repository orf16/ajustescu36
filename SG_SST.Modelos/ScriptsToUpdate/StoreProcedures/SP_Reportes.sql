USE [SGSST]
GO
/****** Object:  StoredProcedure [dbo].[SP_AcumuladoTotalContingenciasReporteAusentismo]    Script Date: 22/02/2018 11:30:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_AcumuladoTotalContingenciasReporteAusentismo]
	@anio int, @tipoContingenciaComparar int, @Nit varchar(20), @idEmpresaUsuaria int
AS
BEGIN
	SET NOCOUNT ON;
    declare @anioString varchar(10) = convert(varchar(10), @anio)
	declare @MesesAusencias table(mes int)
	if (@idEmpresaUsuaria > 0)
	begin
		if(@tipoContingenciaComparar > 0)
		begin
			insert into @MesesAusencias
			select distinct DATEPART(MONTH, fechaInicio) as MesesAusencias
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.fechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia = @tipoContingenciaComparar
			and a.FK_Id_Ausencias_Padre = 0
			and a.FK_Id_EmpresaUsuaria = @idEmpresaUsuaria
			group by DATEPART(MONTH, fechaInicio)
			select	DATEPART(MONTH, a.fechaInicio) as Mes,
				count(a.Pk_Id_Ausencias) as EventosPorMes,
				sum(a.DiasAusencia) as DiasAusenciaPorMes, 
				chht.Horas_Hombre_HTD as HorasTrabajadas,
				chht.Num_Trabajadores_XT as NumeroTrabajadores,
				chht.[Total_HHT] as TotalMes --------------- se agrego
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.FechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia = @tipoContingenciaComparar
			and a.FK_Id_Ausencias_Padre = 0
			and a.FK_Id_EmpresaUsuaria = @idEmpresaUsuaria
			group by DATEPART(MONTH, a.fechaInicio), chht.Horas_Hombre_HTD, chht.Num_Trabajadores_XT,chht.[Total_HHT] -------se agrego
			union
			select *,0 from MesesSinAusencias(@anioString) where Mes not in (select mes from @MesesAusencias)
		end
		else
		begin
			insert into @MesesAusencias
			select distinct DATEPART(MONTH, fechaInicio) as MesesAusencias
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.fechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia in (1, 2, 3)
			and a.FK_Id_Ausencias_Padre = 0
			group by DATEPART(MONTH, fechaInicio)
			select	DATEPART(MONTH, a.fechaInicio) as Mes,
					count(a.Pk_Id_Ausencias) as EventosPorMes,
					sum(a.DiasAusencia) as DiasAusenciaPorMes, 
					chht.Horas_Hombre_HTD as HorasTrabajadas,
					chht.Num_Trabajadores_XT as NumeroTrabajadores,
					chht.[Total_HHT] as TotalMes --------------- se agrego
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.fechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia in (1, 2, 3)
			and a.FK_Id_Ausencias_Padre = 0
			group by DATEPART(MONTH, a.fechaInicio), chht.Horas_Hombre_HTD, chht.Num_Trabajadores_XT,chht.[Total_HHT] -------se agrego
			union
			select *,0 from MesesSinAusencias(@anioString) where Mes not in  (select mes from @MesesAusencias)
		end
	end
	else
	begin
		if(@tipoContingenciaComparar > 0)
		begin
			insert into @MesesAusencias
			select distinct DATEPART(MONTH, fechaInicio) as MesesAusencias
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.fechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia = @tipoContingenciaComparar
			and a.FK_Id_Ausencias_Padre = 0
			group by DATEPART(MONTH, fechaInicio)
			select	DATEPART(MONTH, a.fechaInicio) as Mes,
				count(a.Pk_Id_Ausencias) as EventosPorMes,
				sum(a.DiasAusencia) as DiasAusenciaPorMes, 
				chht.Horas_Hombre_HTD as HorasTrabajadas,
				chht.Num_Trabajadores_XT as NumeroTrabajadores,
				chht.[Total_HHT] as TotalMes --------------- se agrego
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.FechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia = @tipoContingenciaComparar
			and a.FK_Id_Ausencias_Padre = 0
			group by DATEPART(MONTH, a.fechaInicio), chht.Horas_Hombre_HTD, chht.Num_Trabajadores_XT,chht.[Total_HHT] -------se agrego
			union
			select *,0 from MesesSinAusencias(@anioString) where Mes not in (select mes from @MesesAusencias)
		end
		else
		begin
			insert into @MesesAusencias
			select distinct DATEPART(MONTH, fechaInicio) as MesesAusencias
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.fechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia in (1, 2, 3)
			and a.FK_Id_Ausencias_Padre = 0
			group by DATEPART(MONTH, fechaInicio)
			select	DATEPART(MONTH, a.fechaInicio) as Mes,
					count(a.Pk_Id_Ausencias) as EventosPorMes,
					sum(a.DiasAusencia) as DiasAusenciaPorMes, 
					chht.Horas_Hombre_HTD as HorasTrabajadas,
					chht.Num_Trabajadores_XT as NumeroTrabajadores,
					chht.[Total_HHT] as TotalMes --------------- se agrego
			from Tbl_ConfiguracionesHHT chht
			inner join Tbl_Ausencias a on chht.Documento_empresa = a.NitEmpresa and chht.Ano = @anio
			inner join Tbl_Contingencias c on a.FK_Id_Contingencia = c.PK_Id_Contingencia 
			where DATEPART(YEAR, a.FechaInicio) = @anio and chht.Mes = DATEPART(MONTH, a.fechaInicio)
			and a.NitEmpresa = @Nit
			and c.PK_Id_Contingencia in (1, 2, 3)
			and a.FK_Id_Ausencias_Padre = 0
			group by DATEPART(MONTH, a.fechaInicio), chht.Horas_Hombre_HTD, chht.Num_Trabajadores_XT,chht.[Total_HHT] -------se agrego
			union
			select *,0 from MesesSinAusencias(@anioString) where Mes not in  (select mes from @MesesAusencias)
		end
	end
END



GO
/****** Object:  StoredProcedure [dbo].[SP_Cargos_Comunicaciones]    Script Date: 22/02/2018 11:30:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Cargos_Comunicaciones]

@nitEmpresa nvarchar(50)   
as
SELECT     DISTINCT  NitEmpresa, 
PK_Id_Comunicado,

	SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)) as cargo,
	CASE WHEN 	ltrim(rtrim(
	
	SUBSTRING(ltrim(rtrim(
	
	SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(SUBSTRING(SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)),0,patindex('%,%', Destinatarios))))))
	
	,1,charindex(',',DESTINATARIOS,1)-1)))<>'' THEN 
	
	ltrim(rtrim(
	
	SUBSTRING(ltrim(rtrim(
	
	SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(SUBSTRING(SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)),0,patindex('%,%', Destinatarios))))))
	
	,1,charindex(',',DESTINATARIOS,1)-1))) end as cargo2,

	ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS))))  as cargo3,
ltrim(rtrim(SUBSTRING(ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))),charindex('-',ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))),1)+1,len(ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))))))) as cargo4,
	
Destinatarios
                         
FROM            dbo.Tbl_ComunicacionesExternas 

WHERE 

DESTINATARIOS not like '%@%' AND

 SUBSTRING(DESTINATARIOS,0,patindex('%-%', Destinatarios))<>'C' and
SUBSTRING(DESTINATARIOS,0,patindex('%-%', Destinatarios))<>'N/A' and 
SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)) not in (


SELECT        dbo.Tbl_GruposComunicaciones.NombreGrupo
FROM            dbo.Tbl_GrupoUsuariosComunicaciones INNER JOIN
                         dbo.Tbl_GruposComunicaciones ON dbo.Tbl_GrupoUsuariosComunicaciones.fk_id_grupo_comunicaciones = dbo.Tbl_GruposComunicaciones.pk_id_grupo





where NitEmpresa=nitEmpresa

)
GO
/****** Object:  StoredProcedure [dbo].[SP_comunicaciones_appCargos]    Script Date: 22/02/2018 11:30:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





create Procedure [dbo].[SP_comunicaciones_appCargos] 

---- @cargo varchar(50)='AUXILIAR ADMINISTRATIVO I'

@nitEmpresa nvarchar(50)   
as
SELECT     DISTINCT  NitEmpresa, 
IDComunicadosAPP,

	SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)) as cargo,
	CASE WHEN 	ltrim(rtrim(
	
	SUBSTRING(ltrim(rtrim(
	
	SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(SUBSTRING(SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)),0,patindex('%,%', Destinatarios))))))
	
	,1,charindex(',',DESTINATARIOS,1)-1)))<>'' THEN 
	
	ltrim(rtrim(
	
	SUBSTRING(ltrim(rtrim(
	
	SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(SUBSTRING(SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)),0,patindex('%,%', Destinatarios))))))
	
	,1,charindex(',',DESTINATARIOS,1)-1))) end as cargo2,

	ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS))))  as cargo3,
ltrim(rtrim(SUBSTRING(ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))),charindex('-',ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))),1)+1,len(ltrim(rtrim(SUBSTRING(DESTINATARIOS,charindex(',',DESTINATARIOS,1)+1,len(DESTINATARIOS)))))))) as cargo4,
	
Destinatarios
                         
FROM      [dbo].[Tbl_ComunicadosAPP]    

WHERE 

DESTINATARIOS not like '%@%' AND patindex('%-%', Destinatarios) ='0' and

 SUBSTRING(DESTINATARIOS,0,patindex('%-%', Destinatarios))<>'C' and
SUBSTRING(DESTINATARIOS,0,patindex('%-%', Destinatarios))<>'N/A' and 
SUBSTRING(DESTINATARIOS,0,patindex('%,%', Destinatarios)) not in (


SELECT        dbo.Tbl_GruposComunicaciones.NombreGrupo
FROM            dbo.Tbl_GrupoUsuariosComunicaciones INNER JOIN
                         dbo.Tbl_GruposComunicaciones ON dbo.Tbl_GrupoUsuariosComunicaciones.fk_id_grupo_comunicaciones = dbo.Tbl_GruposComunicaciones.pk_id_grupo




where NitEmpresa=nitEmpresa

)









GO
/****** Object:  StoredProcedure [dbo].[SP_ValoracionDeRiesgosPeligros]    Script Date: 22/02/2018 11:30:30 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_ValoracionDeRiesgosPeligros]
@Tipos_Metologias int, @Sede int, @IdTipoPeligro int
as
Begin
	if(@Tipos_Metologias = 1)-->metodoloiga gtc45
	begin
		select Interpretacion,count(Nivel_De_Riesgo) as cantidad from Tbl_Interpretacion_Nivel_Riesgo as inr join
			(select	Nivel_De_Riesgo from  Tbl_Tipo_De_Peligro as tp join
			Tbl_Clasificacion_De_Peligro as cdp  on tp.PK_Tipo_De_Peligro = cdp.FK_Tipo_De_Peligro join
			Tbl_Peligro as p  on cdp.PK_Clasificacion_De_Peligro = p.FK_Clasificacion_De_Peligro join
			Tbl_Consecuencia_Por_Peligro as cscp on p.PK_Peligro = cscp.FK_Peligro join
			Tbl_Consecuencia as csc on cscp.FK_Consecuencia = csc.PK_Consecuencia join
			Tbl_Grupo as gp on csc.FK_Grupo = gp.PK_Grupo join
			Tbl_Tipo_Metodologia as m on gp.FK_Metodologia = m.PK_Metodologia join
			Tbl_GTC45 as gtc45  on gtc45.FK_Peligro = p.PK_Peligro 
			where FK_Sede=@Sede and PK_Metodologia=@Tipos_Metologias  and PK_Tipo_De_Peligro =@IdTipoPeligro) as valorRiesgo
			on inr.Nivel_Superior >= valorRiesgo.Nivel_De_Riesgo and inr.Nivel_Inferior <= valorRiesgo.Nivel_De_Riesgo
			group by Interpretacion,Nivel_De_Riesgo
	end
	else
	begin
		if(@Tipos_Metologias =2) --> metodologia ram
		begin
			select  gtp.Nivel_De_Riesgo as Interpretacion,count(gtp.Nivel_De_Riesgo) as cantidad from 
				(select	FK_Peligro,Descripcion_Metodologia from  Tbl_Consecuencia_Por_Peligro as cscp join
				Tbl_Consecuencia as csc on cscp.FK_Consecuencia = csc.PK_Consecuencia join
				Tbl_Grupo as gp on csc.FK_Grupo = gp.PK_Grupo join
				Tbl_Tipo_Metodologia as m on gp.FK_Metodologia = m.PK_Metodologia 
				where  PK_Metodologia=@Tipos_Metologias) as pm join
				(select PK_Peligro,Nivel_De_Riesgo from Tbl_RAM as ram join
				Tbl_Persona_Expuesta_INSHT_RAM as perexp on ram.FK_Persona_Expuesta = perexp.PK_Persona_Expuesta join
				Tbl_Peligro as p on perexp.FK_Peligro = p.PK_Peligro join
				Tbl_Clasificacion_De_Peligro as cp on p.FK_Clasificacion_De_Peligro = cp.PK_Clasificacion_De_Peligro
				where FK_Sede=@Sede  and FK_Tipo_De_Peligro=@IdTipoPeligro) as gtp 
				on pm.FK_Peligro = gtp.PK_Peligro
				group by gtp.Nivel_De_Riesgo
		end
		else
		begin -->metologia insht
			select Estimacion_Riesgo as Interpretacion,count(Estimacion_Riesgo) as cantidad from Tbl_INSHT as inst join
				Tbl_Persona_Expuesta_INSHT_RAM as perexp on inst.FK_Persona_Expuesta = perexp.PK_Persona_Expuesta join
				Tbl_Peligro as p on perexp.FK_Peligro = p.PK_Peligro  join
				Tbl_Consecuencia_Por_Peligro as cscp  on p.PK_Peligro = cscp.FK_Peligro join
				Tbl_Consecuencia as csc on cscp.FK_Consecuencia = csc.PK_Consecuencia join
				Tbl_Grupo as gp on csc.FK_Grupo = gp.PK_Grupo join 
				Tbl_Tipo_Metodologia as m on gp.FK_Metodologia = m.PK_Metodologia join
				Tbl_Clasificacion_De_Peligro as cp on p.FK_Clasificacion_De_Peligro = cp.PK_Clasificacion_De_Peligro join
				Tbl_Tipo_De_Peligro as tp on tp.PK_Tipo_De_Peligro = cp.FK_Tipo_De_Peligro
				where FK_Sede=@Sede and PK_Metodologia=@Tipos_Metologias  and PK_Tipo_De_Peligro =@IdTipoPeligro
				group by Estimacion_Riesgo 
		end

	end
end



GO
