
create PROCEDURE [dbo].[SP_AcumuladoTotalContingenciasReporteAusentismo]
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


