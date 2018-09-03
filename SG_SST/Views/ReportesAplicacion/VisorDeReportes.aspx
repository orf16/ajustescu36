<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDeReportes.aspx.cs" Inherits="SG_SST.ReportesAplicacion.VisorDeReportes" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script runat="server">

    

        void Page_Load(object sender, EventArgs e)
        {
         
           MostrarReporteEstadistica();
        }

        protected void MostrarReporteEstadistica()
        {
            if (!IsPostBack)
            {

              
                
                switch (SG_SST.Reportes.RecursoParametros.Reporte)
                {

                    case "DesempeñoDelSistema":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DesempeñoSistemaInspeccionesTotalDataTable dtv = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DesempeñoSistemaInspeccionesTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DesempeñoSistemaInspeccionesTotalTableAdapter dav = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DesempeñoSistemaInspeccionesTotalTableAdapter();

                        dav.FillByDesempeño(dtv, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD = new ReportDataSource();
                        RD.Value = dtv;
                        RD.Name = "DataSetInspeccion";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_PlanaccionGralInspeccionDetalladoDataTable dtv2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_PlanaccionGralInspeccionDetalladoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_PlanaccionGralInspeccionDetalladoTableAdapter dav2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_PlanaccionGralInspeccionDetalladoTableAdapter();

                        dav2.FillByFiltro(dtv2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD2 = new ReportDataSource();
                        RD2.Value = dtv2;
                        RD2.Name = "DataSetInspeccionDatos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AccionesPreventivasCorrectivasSistemaDataTable  dtv3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AccionesPreventivasCorrectivasSistemaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AccionesPreventivasCorrectivasSistemaTableAdapter dav3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AccionesPreventivasCorrectivasSistemaTableAdapter();

                        dav3.FillByEspecifico(dtv3, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD3 = new ReportDataSource();
                        RD3.Value = dtv3;
                        RD3.Name = "DataSetGeneral";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AccionesPreventivasCorrectivasSistemaTotalDataTable dtv4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AccionesPreventivasCorrectivasSistemaTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AccionesPreventivasCorrectivasSistemaTotalTableAdapter dav4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AccionesPreventivasCorrectivasSistemaTotalTableAdapter();

                        dav4.FillByDataSetTotal(dtv4, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD4 = new ReportDataSource();
                        RD4.Value = dtv4;
                        RD4.Name = "DataSetTotal";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AuditoriaGeneralDataTable dtv5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AuditoriaGeneralDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AuditoriaGeneralTableAdapter dav5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AuditoriaGeneralTableAdapter();

                        dav5.FillByAuditoria(dtv5, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                       
                        ReportDataSource RD5 = new ReportDataSource();
                        RD5.Value = dtv5;
                        RD5.Name = "DataSetAuditoriaGeneral";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AuditoriaTotalDataTable dtv6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AuditoriaTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AuditoriaTotalTableAdapter dav6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AuditoriaTotalTableAdapter();

                        dav6.FillByTotal(dtv6, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                      
                       
                        ReportDataSource RD6 = new ReportDataSource();
                        RD6.Value = dtv6;
                        RD6.Name = "DataSetAuditoriaTotal";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AuditoriaRealizadasDataTable dtv7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_AuditoriaRealizadasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AuditoriaRealizadasTableAdapter dav7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_AuditoriaRealizadasTableAdapter();

                        dav7.FillByAuditoriasRealizadas(dtv7, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD7 = new ReportDataSource();
                        RD7.Value = dtv7;
                        RD7.Name = "DataSetAuditoriasRealizadas";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DesempeñoSistemaInspeccionesTotalDataTable dtv8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DesempeñoSistemaInspeccionesTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DesempeñoSistemaInspeccionesTotalTableAdapter dav8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DesempeñoSistemaInspeccionesTotalTableAdapter();

                        dav8.FillByDesempeño(dtv8, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD8 = new ReportDataSource();
                        RD8.Value = dtv8;
                        RD8.Name = "DataSetInspeccionTotalPlanes";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_PlanaccionGralInspeccionDataTable dtv9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_PlanaccionGralInspeccionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_PlanaccionGralInspeccionTableAdapter dav9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_PlanaccionGralInspeccionTableAdapter();

                        dav9.FillByTipoInspeccion(dtv9, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD9 = new ReportDataSource();
                        RD9.Value = dtv9;
                        RD9.Name = "DataSetTipoInspeccion";
                        
                       
                            
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD);
                        ReportViewer1.LocalReport.DataSources.Add(RD2);
                        ReportViewer1.LocalReport.DataSources.Add(RD3);
                        ReportViewer1.LocalReport.DataSources.Add(RD4);
                        ReportViewer1.LocalReport.DataSources.Add(RD5);
                        ReportViewer1.LocalReport.DataSources.Add(RD6);
                        ReportViewer1.LocalReport.DataSources.Add(RD7);
                        ReportViewer1.LocalReport.DataSources.Add(RD8);
                        ReportViewer1.LocalReport.DataSources.Add(RD9);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Estadistica/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportParameter[] parameters1 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros
                        parameters1[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());

                        ReportViewer1.LocalReport.SetParameters(parameters1);

                        ReportViewer1.Visible = true;
                    
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "GestionDelRiesgo":
                        
                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndFrecuenciaAccidentesTrabajoDataTable dtv10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();

                        dav10.FillByDataSetTotalATMensual(dtv10, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD10 = new ReportDataSource();
                        RD10.Value = dtv10;
                        RD10.Name = "DataSetTotalATMensual";
                        
                            
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndFrecuenciaAusentismoDataTable dtv11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndFrecuenciaAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndFrecuenciaAusentismoTableAdapter dav11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndFrecuenciaAusentismoTableAdapter();

                        dav11.FillByDataSetTotalAus(dtv11, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD11 = new ReportDataSource();
                        RD11.Value = dtv11;
                        RD11.Name = "DataSetTotalAus";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndFrecuenciaAccidentesTrabajoDataTable dtv12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();

                        dav12.FillByDataSetTotalELMensual(dtv12, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD12 = new ReportDataSource();
                        RD12.Value = dtv12;
                        RD12.Name = "DataSetTotalELMensual";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable dtv13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();

                        dav13.FillByDataSetActosInsegurosMensual(dtv13, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD13 = new ReportDataSource();
                        RD13.Value = dtv13;
                        RD13.Name = "DataSetActosInsegurosMensual";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable dtv14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();

                        dav14.FillByDataSetCondicionesInsegurasMensual(dtv14, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD14 = new ReportDataSource();
                        RD14.Value = dtv14;
                        RD14.Name = "DataSetCondicionesInsegurasMensual";
                        
                         SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable dtv15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();

                        dav15.FillByDataSetPlanActosInseguros(dtv15, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD15 = new ReportDataSource();
                        RD15.Value = dtv15;
                        RD15.Name = "DataSetPlanActosInseguros";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable dtv16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();

                        dav16.FillByDataSetPlanCondInseguras(dtv16, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD16 = new ReportDataSource();
                        RD16.Value = dtv16;
                        RD16.Name = "DataSetPlanCondInseguras";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable dtv17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();

                        dav17.FillByDataSetTotalCondActosInseguros(dtv17, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD17 = new ReportDataSource();
                        RD17.Value = dtv17;
                        RD17.Name = "DataSetTotalCondActosInseguros";  
                        
                        //Plan de trabajo
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndPlanTrabajoMensualDataTable dtv18 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndPlanTrabajoMensualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndPlanTrabajoMensualTableAdapter dav18 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndPlanTrabajoMensualTableAdapter();

                        dav18.FillByPlanTrabajoMensual(dtv18, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD18 = new ReportDataSource();
                        RD18.Value = dtv18;
                        RD18.Name = "DataSetPlanTrabajoMensual";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndPlanTrabajoAnualDataTable dtv19 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_IndPlanTrabajoAnualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndPlanTrabajoAnualTableAdapter dav19 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_IndPlanTrabajoAnualTableAdapter();

                        dav19.FillByDataSetTotalPlanTrabajo(dtv19, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD19 = new ReportDataSource();
                        RD19.Value = dtv19;
                        RD19.Name = "DataSetTotalPlanTrabajo";  
                         
                        //Peligros

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Nivel_RiesgoGTC45DataTable dtv20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Nivel_RiesgoGTC45DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Nivel_RiesgoGTC45TableAdapter dav20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Nivel_RiesgoGTC45TableAdapter();

                        dav20.FillByDataSetNivelRiesgoGTC45(dtv20, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD20 = new ReportDataSource();
                        RD20.Value = dtv20;
                        RD20.Name = "DataSetNivelRiesgoGTC45";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Nivel_RiesgoINSHTDataTable dtv21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Nivel_RiesgoINSHTDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Nivel_RiesgoINSHTTableAdapter dav21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Nivel_RiesgoINSHTTableAdapter();

                        dav21.FillByDataSetNivelRiesgoINSHT(dtv21, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD21 = new ReportDataSource();
                        RD21.Value = dtv21;
                        RD21.Name = "DataSetNivelRiesgoINSHT";  
                         
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Nivel_RiesgoRAMDataTable dtv22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Nivel_RiesgoRAMDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Nivel_RiesgoRAMTableAdapter dav22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Nivel_RiesgoRAMTableAdapter();

                        dav22.FillByDataSetNivelRiesgoRAM(dtv22, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD22 = new ReportDataSource();
                        RD22.Value = dtv22;
                        RD22.Name = "DataSetNivelRiesgoRAM";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_EstPeligrosIdentificadosDataTable dtv23 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_EstPeligrosIdentificadosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_EstPeligrosIdentificadosTableAdapter dav23 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_EstPeligrosIdentificadosTableAdapter();

                        dav23.FillByDataSetPeligrosIdGTC45(dtv23, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD23 = new ReportDataSource();
                        RD23.Value = dtv23;
                        RD23.Name = "DataSetPeligrosIdGTC45";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_EstPeligrosIdentificadosDataTable dtv24 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_EstPeligrosIdentificadosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_EstPeligrosIdentificadosTableAdapter dav24 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_EstPeligrosIdentificadosTableAdapter();

                        dav24.FillByDataSetPeligrosIdINSHT(dtv24, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD24 = new ReportDataSource();
                        RD24.Value = dtv24;
                        RD24.Name = "DataSetPeligrosIdINSHT";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_EstPeligrosIdentificadosDataTable dtv25 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_EstPeligrosIdentificadosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_EstPeligrosIdentificadosTableAdapter dav25 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_EstPeligrosIdentificadosTableAdapter();

                        dav25.FillByDataSetPeligrosIdRam(dtv25, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD25 = new ReportDataSource();
                        RD25.Value = dtv25;
                        RD25.Name = "DataSetPeligrosIdRAM";  
                        
                        // DX Condiciones de Salud

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DxCondicionesDeSaludCIE10DataTable dtv26 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DxCondicionesDeSaludCIE10DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DxCondicionesDeSaludCIE10TableAdapter dav26 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DxCondicionesDeSaludCIE10TableAdapter();

                        dav26.FillByDataSetDxCIE10(dtv26, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD26 = new ReportDataSource();
                        RD26.Value = dtv26;
                        RD26.Name = "DataSetDxCIE10";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DxCondicionesDeSaludDataTable dtv27 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.DxCondicionesDeSaludDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DxCondicionesDeSaludTableAdapter dav27 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.DxCondicionesDeSaludTableAdapter();

                        dav27.FillByDataSetTotalDx(dtv27, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD27 = new ReportDataSource();
                        RD27.Value = dtv27;
                        RD27.Name = "DataSetTotalDx";  
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD10);
                        ReportViewer1.LocalReport.DataSources.Add(RD11);
                        ReportViewer1.LocalReport.DataSources.Add(RD12);
                        ReportViewer1.LocalReport.DataSources.Add(RD13);
                        ReportViewer1.LocalReport.DataSources.Add(RD14);
                        ReportViewer1.LocalReport.DataSources.Add(RD15);
                        ReportViewer1.LocalReport.DataSources.Add(RD16);
                        ReportViewer1.LocalReport.DataSources.Add(RD17);
                        ReportViewer1.LocalReport.DataSources.Add(RD18);
                        ReportViewer1.LocalReport.DataSources.Add(RD19);
                        ReportViewer1.LocalReport.DataSources.Add(RD20);
                        ReportViewer1.LocalReport.DataSources.Add(RD21);
                        ReportViewer1.LocalReport.DataSources.Add(RD22);
                        ReportViewer1.LocalReport.DataSources.Add(RD23);
                        ReportViewer1.LocalReport.DataSources.Add(RD24);
                        ReportViewer1.LocalReport.DataSources.Add(RD25);
                        ReportViewer1.LocalReport.DataSources.Add(RD26);
                        ReportViewer1.LocalReport.DataSources.Add(RD27);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Estadistica/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportParameter[] parameters2 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros
                        parameters2[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());

                        ReportViewer1.LocalReport.SetParameters(parameters2);
                        

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
            
                        
                            break;


                    case "EntrenamientoSGSST":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_GeneralPerfilSocioEstDataTable dtv28 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_GeneralPerfilSocioEstDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_GeneralPerfilSocioEstTableAdapter dav28 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_GeneralPerfilSocioEstTableAdapter();

                        dav28.FillByDataSetPerfilSocioGeneral(dtv28, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD28 = new ReportDataSource();
                        RD28.Value = dtv28;
                        RD28.Name = "DataSetGeneralPerfil";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_GeneralPerfilSocioTotalDataTable dtv29 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_GeneralPerfilSocioTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_GeneralPerfilSocioTotalTableAdapter dav29 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_GeneralPerfilSocioTotalTableAdapter();

                        dav29.FillByTotalPerfil(dtv29, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD29 = new ReportDataSource();
                        RD29.Value = dtv29;
                        RD29.Name = "DataSetTotalPerfil";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_PerfilSocioUltimoCargoDataTable dtv30 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.V_PerfilSocioUltimoCargoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_PerfilSocioUltimoCargoTableAdapter dav30 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.V_PerfilSocioUltimoCargoTableAdapter();

                        dav30.FillByUltimoCargo(dtv30, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD30 = new ReportDataSource();
                        RD30.Value = dtv30;
                        RD30.Name = "DataSetPerfilUltimoCargo";  


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.CompetenciasPorRolDataTable dtv31 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.CompetenciasPorRolDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.CompetenciasPorRolTableAdapter dav31 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.CompetenciasPorRolTableAdapter();

                        dav31.FillByDataSetCompetenciasPorRol(dtv31, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD31 = new ReportDataSource();
                        RD31.Value = dtv31;
                        RD31.Name = "DataSetCompetenciasXRol";  
                        
                         SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.TotalCapacitacionDataTable dtv32 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.TotalCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.TotalCapacitacionTableAdapter dav32 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.TotalCapacitacionTableAdapter();

                        dav32.FillByTotalCapacitacion(dtv32, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD32 = new ReportDataSource();
                        RD32.Value = dtv32;
                        RD32.Name = "DataSetTotalCapacitacion";  
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_PlanCapacitacionDataTable dtv33 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_PlanCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_PlanCapacitacionTableAdapter dav33 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_PlanCapacitacionTableAdapter();

                        dav33.FillByCapacitacionesMensual(dtv33, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD33 = new ReportDataSource();
                        RD33.Value = dtv33;
                        RD33.Name = "DataSetCapacitacionesMensual";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_PlanCapacitacionDataTable dtv34 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_PlanCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_PlanCapacitacionTableAdapter dav34 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_PlanCapacitacionTableAdapter();

                        dav34.FillByEntrenamientosMensual(dtv34, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD34 = new ReportDataSource();
                        RD34.Value = dtv34;
                        RD34.Name = "DataSetEntrenamientosMensual";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_PlanCapacitacionDataTable dtv35 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_PlanCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_PlanCapacitacionTableAdapter dav35 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_PlanCapacitacionTableAdapter();

                        dav35.FillByInduccionesMensual(dtv35, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD35 = new ReportDataSource();
                        RD35.Value = dtv35;
                        RD35.Name = "DataSetInduccionesMensual";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_AsistenciaCapacitacionesDataTable dtv36 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_AsistenciaCapacitacionesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_AsistenciaCapacitacionesTableAdapter dav36 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_AsistenciaCapacitacionesTableAdapter();

                        dav36.FillByAsistenciaCapacitaciones(dtv36, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD36 = new ReportDataSource();
                        RD36.Value = dtv36;
                        RD36.Name = "DataSetAsistenciaCapacitaciones";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_AsistenciaCapacitacionesDataTable dtv37 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_AsistenciaCapacitacionesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_AsistenciaCapacitacionesTableAdapter dav37 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_AsistenciaCapacitacionesTableAdapter();

                        dav37.FillByAsistenciaEntrenamientos(dtv37, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD37 = new ReportDataSource();
                        RD37.Value = dtv37;
                        RD37.Name = "DataSetAsistenciaEntrenamientos";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_AsistenciaCapacitacionesDataTable dtv38 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticas.Tbl_AsistenciaCapacitacionesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_AsistenciaCapacitacionesTableAdapter dav38 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetEstadisticasTableAdapters.Tbl_AsistenciaCapacitacionesTableAdapter();

                        dav38.FillByAsistenciaInducciones(dtv38, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD38 = new ReportDataSource();
                        RD38.Value = dtv38;
                        RD38.Name = "DataSetAsistenciaInducciones";
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD28);
                        ReportViewer1.LocalReport.DataSources.Add(RD29);
                        ReportViewer1.LocalReport.DataSources.Add(RD30);
                        ReportViewer1.LocalReport.DataSources.Add(RD31);
                        ReportViewer1.LocalReport.DataSources.Add(RD32);
                        ReportViewer1.LocalReport.DataSources.Add(RD33);
                        ReportViewer1.LocalReport.DataSources.Add(RD34);
                        ReportViewer1.LocalReport.DataSources.Add(RD35);
                        ReportViewer1.LocalReport.DataSources.Add(RD36);
                        ReportViewer1.LocalReport.DataSources.Add(RD37);
                        ReportViewer1.LocalReport.DataSources.Add(RD38);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Estadistica/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportParameter[] parameters3 = new ReportParameter[1];
                       // Establecemos el valor de los parámetros
                        parameters3[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());

                        ReportViewer1.LocalReport.SetParameters(parameters3);
                        

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                   
                            break;
                   
                }             
            }

        }
           
    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="1200px" Width="100%" Enabled="true"
                BackColor="White" BorderColor="black" Font-Bold="true" InternalBorderStyle="None" ShowParameterPrompts="true"   
                AsyncRendering="false" ShowBackButton="False" ShowFindControls="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False" ShowPageNavigationControls="False" >
            </rsweb:ReportViewer>    

        </div>
    </form>
</body>
</html>
