<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDeReportesIndRes.aspx.cs" Inherits="SG_SST.Views.ReportesAplicacion.VisorDeReportesInd" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
           MostrarReporteIndRes();
        }
        protected void MostrarReporteIndRes()
        {
            if (!IsPostBack)
            {

                switch (SG_SST.Reportes.RecursoParametros.Reporte)
                {
                 
                    case "AccidentesDeTrabajo":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable dtv13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();

                        
                        dav13.FillByTotalAt(dtv13, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD13 = new ReportDataSource();
                        RD13.Value = dtv13;
                        RD13.Name = "DataSetTotalAT";
                                               
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable dtv14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();

                        
                        dav14.FillByTotalHHT(dtv14, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD14 = new ReportDataSource();
                        RD14.Value = dtv14;
                        RD14.Name = "DataSetTotalHHT";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable dtv15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();

                        
                        dav15.FillByTotalATSede(dtv15, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD15 = new ReportDataSource();
                        RD15.Value = dtv15;
                        RD15.Name = "DataSetTotalATSede";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable dtv15a = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav15a = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();

                        
                        dav15a.FillByTotalATMensual(dtv15a, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD15a = new ReportDataSource();
                        RD15a.Value = dtv15a;
                        RD15a.Name = "DataSetTotalATMensual";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv15M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav15M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav15M.FillByMetaIndicador(dtv15M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Frecuencia de los accidentes laborales");
                                  
                        ReportDataSource RD15M = new ReportDataSource();
                        RD15M.Value = dtv15M;
                        RD15M.Name = "DataSetMetaIndicador";
    
                        
                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD13);
                        ReportViewer1.LocalReport.DataSources.Add(RD14);
                        ReportViewer1.LocalReport.DataSources.Add(RD15);
                        ReportViewer1.LocalReport.DataSources.Add(RD15a);
                        ReportViewer1.LocalReport.DataSources.Add(RD15M);

                        //Array que contendrá los parámetros
                       ReportParameter[] parameters = new ReportParameter[1];
                        //Establecemos el valor de los parámetros
                      
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        parameters[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());

                   
                   
                        
                        ReportViewer1.LocalReport.SetParameters(parameters);
                        
                        
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "TasaAccidentalidad":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndTasaAccidentalidadDataTable dtv16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndTasaAccidentalidadDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndTasaAccidentalidadTableAdapter dav16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndTasaAccidentalidadTableAdapter();

                     
                        dav16.FillByTotalAT(dtv16, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD16 = new ReportDataSource();
                        RD16.Value = dtv16;
                        RD16.Name = "DataSetTotalAT";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndTasaAccidentalidadDataTable dtv17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndTasaAccidentalidadDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndTasaAccidentalidadTableAdapter dav17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndTasaAccidentalidadTableAdapter();

                     
                        dav17.FillByPromTrabajadores(dtv17, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);
                        

                        ReportDataSource RD17 = new ReportDataSource();
                        RD17.Value = dtv17;
                        RD17.Name = "DataSetPromTrab";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndTasaAccidentalidadDataTable dtv18 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndTasaAccidentalidadDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndTasaAccidentalidadTableAdapter dav18 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndTasaAccidentalidadTableAdapter();

                     
                        dav18.FillByTotalATMes(dtv18,SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        

                        ReportDataSource RD18 = new ReportDataSource();
                        RD18.Value = dtv18;
                        RD18.Name = "DataSetTotalATMes";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv18M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav18M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav18M.FillByMetaIndicador(dtv18M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Tasa accidentalidad");
                                  
                        ReportDataSource RD18M = new ReportDataSource();
                        RD18M.Value = dtv18M;
                        RD18M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD16);
                        ReportViewer1.LocalReport.DataSources.Add(RD17);
                        ReportViewer1.LocalReport.DataSources.Add(RD18);
                        ReportViewer1.LocalReport.DataSources.Add(RD18M);
                        

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportParameter[] parameters9 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                      
                        parameters9[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());



                        ReportViewer1.LocalReport.SetParameters(parameters9);
                        
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "CapacitacionEntrenamiento":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndPlanCapacitacionDataTable dtv19 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndPlanCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndPlanCapacitacionTableAdapter dav19 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndPlanCapacitacionTableAdapter();

                
                        dav19.FillByMeses(dtv19,SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD19 = new ReportDataSource();
                        RD19.Value = dtv19;
                        RD19.Name = "DataSetMeses";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndPlanCapacitacionDataTable dtv20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndPlanCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndPlanCapacitacionTableAdapter dav20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndPlanCapacitacionTableAdapter();

                
                        dav20.FillByTotal(dtv20,SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD20 = new ReportDataSource();
                        RD20.Value = dtv20;
                        RD20.Name = "DataSetTotal";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv20M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav20M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav20M.FillByMetaIndicador(dtv20M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Cumplimiento programa de capacitación y entrenamiento");
                                  
                        ReportDataSource RD20M = new ReportDataSource();
                        RD20M.Value = dtv20M;
                        RD20M.Name = "DataSetMetaIndicador";


                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD19);
                        ReportViewer1.LocalReport.DataSources.Add(RD20);
                        ReportViewer1.LocalReport.DataSources.Add(RD20M);

                   

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                       
                        ReportParameter[] parameters7 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                      
                        parameters7[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());



                        ReportViewer1.LocalReport.SetParameters(parameters7);
                        
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "FrecuenciaAusentismo":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAusentismoDataTable dtv21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAusentismoTableAdapter dav21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAusentismoTableAdapter();

                      
                        dav21.FillByTotalAus(dtv21, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);
                        
                     
                        ReportDataSource RD21 = new ReportDataSource();
                        RD21.Value = dtv21;
                        RD21.Name = "DataSetTotalAus";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.AusentismoDiasSedeDataTable dtv22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.AusentismoDiasSedeDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.AusentismoDiasSedeTableAdapter dav22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.AusentismoDiasSedeTableAdapter();

                        dav22.FillByTotalAusSede(dtv22, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                        
                     
                        ReportDataSource RD22 = new ReportDataSource();
                        RD22.Value = dtv22;
                        RD22.Name = "DataSetTotalAusSede";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Tbl_ConfiguracionesHHTDataTable dtv23 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Tbl_ConfiguracionesHHTDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Tbl_ConfiguracionesHHTTableAdapter dav23 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Tbl_ConfiguracionesHHTTableAdapter();

                     
                        dav23.FillByTotalDTM(dtv23, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);
                        
                     
                        ReportDataSource RD23 = new ReportDataSource();
                        RD23.Value = dtv23;
                        RD23.Name = "DataSetTotalDTM";
                       

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VW_REPORTE_AUSENTISMO_NUMERO_EVENTOS_CONTINGENCIADataTable dtv21c = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VW_REPORTE_AUSENTISMO_NUMERO_EVENTOS_CONTINGENCIADataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VW_REPORTE_AUSENTISMO_NUMERO_EVENTOS_CONTINGENCIATableAdapter dav21c = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VW_REPORTE_AUSENTISMO_NUMERO_EVENTOS_CONTINGENCIATableAdapter();

                        dav21c.FillByEventos(dtv21c, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD21c = new ReportDataSource();
                        RD21c.Value = dtv21c;
                        RD21c.Name = "DataSetEventos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.AusentismoDiasContingenciaDataTable dtv21d = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.AusentismoDiasContingenciaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.AusentismoDiasContingenciaTableAdapter dav21d = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.AusentismoDiasContingenciaTableAdapter();

                        dav21d.FillByDias(dtv21d, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD21d = new ReportDataSource();
                        RD21d.Value = dtv21d;
                        RD21d.Name = "DataSetDias";
                       
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv23M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav23M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav23M.FillByMetaIndicador(dtv23M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Ausentismo por incapacidad médica");
                                  
                        ReportDataSource RD23M = new ReportDataSource();
                        RD23M.Value = dtv23M;
                        RD23M.Name = "DataSetMetaIndicador";



                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD21);
                        ReportViewer1.LocalReport.DataSources.Add(RD22);
                        ReportViewer1.LocalReport.DataSources.Add(RD23);
                        ReportViewer1.LocalReport.DataSources.Add(RD21c);
                        ReportViewer1.LocalReport.DataSources.Add(RD21d);                        
                        ReportViewer1.LocalReport.DataSources.Add(RD23M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        //Establecemos el valor de los parámetros
                      
                        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                          ReportParameter[] parameters2 = new ReportParameter[1];
                      
                        parameters2[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                      
                        
                        ReportViewer1.LocalReport.SetParameters(parameters2);
                        
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "SeveridadAusentismo":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable dtv24 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter dav24 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter();


                        dav24.FillByTotalAus(dtv24, SG_SST.Reportes.RecursoParametros.Contigencia, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RD24 = new ReportDataSource();
                        RD24.Value = dtv24;
                        RD24.Name = "DataSetTotalAus";

                    
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable dtv25 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter dav25 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter();

                        dav25.FillByTotalAusSede(dtv25, SG_SST.Reportes.RecursoParametros.Contigencia, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RD25 = new ReportDataSource();
                        RD25.Value = dtv25;
                        RD25.Name = "DataSetTotalAusSede";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable dtv26 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter dav26 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter();


                        dav26.FillByTotalHHT(dtv26, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RD26 = new ReportDataSource();
                        RD26.Value = dtv26;
                        RD26.Name = "DataSetTotalHHT";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable dtv26b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter dav26b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadAusentismoTableAdapter();


                        dav26b.FillByTotalAusMensual(dtv26b,SG_SST.Reportes.RecursoParametros.Contigencia, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        

                        ReportDataSource RD26b = new ReportDataSource();
                        RD26b.Value = dtv26b;
                        RD26b.Name = "DataSetTotalAusMensual";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv26M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav26M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav26M.FillByMetaIndicador(dtv26M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Índice de severidad del ausentismo");
                                  
                        ReportDataSource RD26M = new ReportDataSource();
                        RD26M.Value = dtv26M;
                        RD26M.Name = "DataSetMetaIndicador";

                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD24);
                        ReportViewer1.LocalReport.DataSources.Add(RD25);
                        ReportViewer1.LocalReport.DataSources.Add(RD26);
                        ReportViewer1.LocalReport.DataSources.Add(RD26b);
                        ReportViewer1.LocalReport.DataSources.Add(RD26M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parameters3 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros

                      
                        parameters3[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        parameters3[1] = new ReportParameter("contingenciaTexto", SG_SST.Reportes.RecursoParametros.ContigenciaTexto);




                        ReportViewer1.LocalReport.SetParameters(parameters3);

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;



                    case "SeveridadAccidenteTrabajo":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadATDataTable dtv27 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadATDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadATTableAdapter dav27 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadATTableAdapter();


                        dav27.FillByTotalAus(dtv27,  SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);
             
                     
                        ReportDataSource RD27 = new ReportDataSource();
                        RD27.Value = dtv27;
                        RD27.Name = "DataSetTotalAus";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadATDataTable dtv28 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadATDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadATTableAdapter dav28 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadATTableAdapter();


                        dav28.FillByTotalAusSede(dtv28,SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);
             
                     
                        ReportDataSource RD28 = new ReportDataSource();
                        RD28.Value = dtv28;
                        RD28.Name = "DataSetTotalAusSede";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable dtv29 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav29 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();


                        dav29.FillByTotalHHT(dtv29, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
              
                     
                        ReportDataSource RD29 = new ReportDataSource();
                        RD29.Value = dtv29;
                        RD29.Name = "DataSetTotalHHT";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadATDataTable dtv28b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndSeveridadATDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadATTableAdapter dav28b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndSeveridadATTableAdapter();


                        dav28b.FillByTotalAusMensual(dtv28b,SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);
             
                     
                        ReportDataSource RD28b = new ReportDataSource();
                        RD28b.Value = dtv28b;
                        RD28b.Name = "DataSetTotalAusMensual";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv28M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav28M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();


                        dav28M.FillByMetaIndicador(dtv28M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Severidad de los accidentes laborales");
             
                     
                        ReportDataSource RD28M = new ReportDataSource();
                        RD28M.Value = dtv28M;
                        RD28M.Name = "DataSetMetaIndicador";
                       

                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD27);

                        ReportViewer1.LocalReport.DataSources.Add(RD28);
                        ReportViewer1.LocalReport.DataSources.Add(RD29);
                        ReportViewer1.LocalReport.DataSources.Add(RD28b);
                        ReportViewer1.LocalReport.DataSources.Add(RD28M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parameters10 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                        parameters10[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                       
                        
                        ReportViewer1.LocalReport.SetParameters(parameters10);

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;


                    case "LesionesIncapacitantes":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesTotalATDataTable dtv31 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesTotalATDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTotalATTableAdapter dav31 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTotalATTableAdapter();


                        dav31.FillByTotalAT(dtv31,  SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        

                        ReportDataSource RD31 = new ReportDataSource();
                        RD31.Value = dtv31;
                        RD31.Name = "DataSetTotalAT";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable dtv32 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndFrecuenciaAccidentesTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter dav32 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndFrecuenciaAccidentesTrabajoTableAdapter();


                        dav32.FillByTotalHHT(dtv32,  SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RD32 = new ReportDataSource();
                        RD32.Value = dtv32;
                        RD32.Name = "DataSetTotalHHT";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesTotalATSedeDataTable dtv33 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesTotalATSedeDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTotalATSedeTableAdapter dav33 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTotalATSedeTableAdapter();


                        dav33.FillByTotalATSede(dtv33,  SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RD33 = new ReportDataSource();
                        RD33.Value = dtv33;
                        RD33.Name = "DataSetTotalATSede";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesTotalDiasATDataTable dtv34 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesTotalDiasATDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTotalDiasATTableAdapter dav34 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTotalDiasATTableAdapter();


                        dav34.FillByTotalDiasAT(dtv34, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RD34 = new ReportDataSource();
                        RD34.Value = dtv34;
                        RD34.Name = "DataSetTotalDiasAT";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesDataTable dtv34b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndLesionesIncapacitantesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTableAdapter dav34b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndLesionesIncapacitantesTableAdapter();


                        dav34b.FillByTotalATMensual(dtv34b, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RD34b = new ReportDataSource();
                        RD34b.Value = dtv34b;
                        RD34b.Name = "DataSetTotalATMensual";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv34M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav34M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav34M.FillByMetaIndicador(dtv34M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Índice de lesiones incapacitantes por A.T");
                                  
                        ReportDataSource RD34M = new ReportDataSource();
                        RD34M.Value = dtv34M;
                        RD34M.Name = "DataSetMetaIndicador";


                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD31);

                        ReportViewer1.LocalReport.DataSources.Add(RD32);
                        ReportViewer1.LocalReport.DataSources.Add(RD33);
                        ReportViewer1.LocalReport.DataSources.Add(RD34);
                        ReportViewer1.LocalReport.DataSources.Add(RD34b);
                        ReportViewer1.LocalReport.DataSources.Add(RD34M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parameters11 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                        parameters11[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());




                        ReportViewer1.LocalReport.SetParameters(parameters11);

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "CumplimientoRequisitosLegales":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.indCumGeneralesDataSet1DataTable dtv35 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.indCumGeneralesDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.indCumGeneralesDataSet1TableAdapter dav35 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.indCumGeneralesDataSet1TableAdapter();


                        dav35.FillDataSet1(dtv35, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RD35 = new ReportDataSource();
                        RD35.Value = dtv35;
                        RD35.Name = "DataSet1";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.indCumGeneralesDataSet2DataTable dtv36 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.indCumGeneralesDataSet2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.indCumGeneralesDataSet2TableAdapter dav36 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.indCumGeneralesDataSet2TableAdapter();


                        dav36.FillByDataSet2(dtv36, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RD36 = new ReportDataSource();
                        RD36.Value = dtv36;
                        RD36.Name = "DataSet2";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.indCumpParcialmenteDataSet2DataTable dtv36CP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.indCumpParcialmenteDataSet2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.indCumpleParcialmenteDataSet2ableAdapter dav36CP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.indCumpleParcialmenteDataSet2ableAdapter();


                        dav36CP.FillByCumpleParcial(dtv36CP, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RD36CP = new ReportDataSource();
                        RD36CP.Value = dtv36CP;
                        RD36CP.Name = "DataSetCumpleParcialmente";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv36M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav36M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav36M.FillByMetaIndicador(dtv36M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador del cumplimiento de los requisitos legales");
                                  
                        ReportDataSource RD36M = new ReportDataSource();
                        RD36M.Value = dtv36M;
                        RD36M.Name = "DataSetMetaIndicador";

                        
                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD35);
                        ReportViewer1.LocalReport.DataSources.Add(RD36);
                        ReportViewer1.LocalReport.DataSources.Add(RD36M);
                        ReportViewer1.LocalReport.DataSources.Add(RD36CP);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parametersReqLeg = new ReportParameter[1];
                        //Establecemos el valor de los parámetros


                        parametersReqLeg[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());

                        ReportViewer1.LocalReport.SetParameters(parametersReqLeg);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "AnalisisVulnerabilidad":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadDataSet1DataTable dtv66 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadDataSet1TableAdapter dav66 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadDataSet1TableAdapter();

                        dav66.FillByDataSet1(dtv66, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RD66 = new ReportDataSource();
                        RD66.Value = dtv66;
                        RD66.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Vulnerabilidad_Em_Vul_Ame_tipoDataTable dtv67 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Vulnerabilidad_Em_Vul_Ame_tipoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Vulnerabilidad_EM_Vul_Ame_tipoTableAdapter dav67 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Vulnerabilidad_EM_Vul_Ame_tipoTableAdapter();

                        dav67.FillByEm_vul_ame_tipo(dtv67, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RD67 = new ReportDataSource();
                        RD67.Value = dtv67;
                        RD67.Name = "em_vul_ame_tipo";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadAmenazaDataTable dtv68 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadAmenazaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadAmenazaTableAdapter dav68 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadAmenazaTableAdapter();

                        dav68.FillByAmenazas(dtv68, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RD68 = new ReportDataSource();
                        RD68.Value = dtv68;
                        RD68.Name = "amenazas";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Vulnerabilidad_TECNOLÓGICODataTable dtv69 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Vulnerabilidad_TECNOLÓGICODataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Vulnerabilidad_tecnologicoTableAdapter dav69 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Vulnerabilidad_tecnologicoTableAdapter();

                        dav69.FillByTecnologico(dtv69, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RD69 = new ReportDataSource();
                        RD69.Value = dtv69;
                        RD69.Name = "TECNOLÓGICO";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadSocialesDataTable dtv70 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadSocialesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadSocialesTableAdapter dav70 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadSocialesTableAdapter();

                        dav70.FillBySociales(dtv70, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RD70 = new ReportDataSource();
                        RD70.Value = dtv70;
                        RD70.Name = "SOCIALES";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadNaturalDataTable dtv71 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadNaturalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadNaturalTableAdapter dav71 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadNaturalTableAdapter();

                        dav71.FillByNaturales(dtv71, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RD71 = new ReportDataSource();
                        RD71.Value = dtv71;
                        RD71.Name = "NATURALES";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Vulnerabilidad_Em_vul_grantotalDataTable dtvgt = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.Vulnerabilidad_Em_vul_grantotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Vulnerabilidad_Em_vul_grantotalTableAdapter davgt = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.Vulnerabilidad_Em_vul_grantotalTableAdapter();

                        davgt.FillByem_vul_grantotal(dtvgt, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RDgt = new ReportDataSource();
                        RDgt.Value = dtvgt;
                        RDgt.Name = "em_vul_grantotal";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadIdAmenazasDataTable dtvia = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.VulnerabilidadIdAmenazasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadIdAmenazasTableAdapter davia = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.VulnerabilidadIdAmenazasTableAdapter();

                        davia.FillByIdAmenazas(dtvia, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);

                        ReportDataSource RDia = new ReportDataSource();
                        RDia.Value = dtvia;
                        RDia.Name = "DataSetIdAmenazas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv71M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav71M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav71M.FillByMetaIndicador(dtv71M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador ánalisis vulnerabilidad");
                                  
                        ReportDataSource RD71M = new ReportDataSource();
                        RD71M.Value = dtv71M;
                        RD71M.Name = "DataSetMetaIndicador";
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD66);
                        ReportViewer1.LocalReport.DataSources.Add(RD67);
                        ReportViewer1.LocalReport.DataSources.Add(RD68);
                        ReportViewer1.LocalReport.DataSources.Add(RD69);
                        ReportViewer1.LocalReport.DataSources.Add(RD70);
                        ReportViewer1.LocalReport.DataSources.Add(RD71);
                        ReportViewer1.LocalReport.DataSources.Add(RDgt);
                        ReportViewer1.LocalReport.DataSources.Add(RDia);
                        ReportViewer1.LocalReport.DataSources.Add(RD71M);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parametersVulnerabilidad = new ReportParameter[1];
                        //Establecemos el valor de los parámetros
                        parametersVulnerabilidad[0] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        ReportViewer1.LocalReport.SetParameters(parametersVulnerabilidad);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                  
                    case "ProcesoLugarActividadValoracion":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos1DataTable dtvpel1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos1TableAdapter davpel1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos1TableAdapter();

                        davpel1.FillByLugarActividadValoracion(dtvpel1, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia,SG_SST.Reportes.RecursoParametros.ProcesoInt,SG_SST.Reportes.RecursoParametros.ZonaLugarTexto,SG_SST.Reportes.RecursoParametros.ActividadTexto);
                        
                        
                 
                        ReportDataSource RDpel1 = new ReportDataSource();
                        RDpel1.Value = dtvpel1;
                        RDpel1.Name = "TiposPeligrosSedeMetodologia";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable dtvpel2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter davpel2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter();

                     //   davpel2.FillByValoracion(dtvpel2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);
                        davpel2.FillByValoracion(dtvpel2,SG_SST.Reportes.RecursoParametros.Metodologia,SG_SST.Reportes.RecursoParametros.SedeInd,SG_SST.Reportes.RecursoParametros.TipoPeligro);
                        ReportDataSource RDpel2 = new ReportDataSource();
                        RDpel2.Value = dtvpel2;
                        RDpel2.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpel2M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpel2M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpel2M.FillByMetaIndicador(dtvpel2M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de identificación y valoración de peligros y riesgos");
                                  
                        ReportDataSource RDpel2M = new ReportDataSource();
                        RDpel2M.Value = dtvpel2M;
                        RDpel2M.Name = "DataSetMetaIndicador";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel1);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel2);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel2M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] peligrosYRiesgos = new ReportParameter[6];
                        //Establecemos el valor de los parámetros
                        peligrosYRiesgos[0] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        peligrosYRiesgos[1] = new ReportParameter("metedologiaTexto", SG_SST.Reportes.RecursoParametros.MetodologiaTexto);
                        peligrosYRiesgos[2] = new ReportParameter("procesoTexto", SG_SST.Reportes.RecursoParametros.ProcesoTexto);
                        peligrosYRiesgos[3] = new ReportParameter("ZonaLugarTexto", SG_SST.Reportes.RecursoParametros.ZonaLugarTexto);
                        peligrosYRiesgos[4] = new ReportParameter("ActividadTexto", SG_SST.Reportes.RecursoParametros.ActividadTexto);
                        peligrosYRiesgos[5] = new ReportParameter("TipoPeligroTexto", SG_SST.Reportes.RecursoParametros.TipoPeligroTexto);


                        ReportViewer1.LocalReport.SetParameters(peligrosYRiesgos);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ProcesoLugarValoracion":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos2DataTable dtvpel3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos2TableAdapter davpel3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos2TableAdapter();

                        davpel3.FillByLugarValoracion(dtvpel3, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.ProcesoInt, SG_SST.Reportes.RecursoParametros.ZonaLugarTexto);

                   
                        ReportDataSource RDpel3 = new ReportDataSource();
                        RDpel3.Value = dtvpel3;
                        RDpel3.Name = "TiposPeligrosSedeMetodologia";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable dtvpel4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter davpel4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter();

                        //   davpel2.FillByValoracion(dtvpel2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);
                        davpel4.FillByValoracion(dtvpel4, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);
                        ReportDataSource RDpel4 = new ReportDataSource();
                        RDpel4.Value = dtvpel4;
                        RDpel4.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpel4M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpel4M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpel4M.FillByMetaIndicador(dtvpel4M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de identificación y valoración de peligros y riesgos");
                                  
                        ReportDataSource RDpel4M = new ReportDataSource();
                        RDpel4M.Value = dtvpel4M;
                        RDpel4M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel3);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel4);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel4M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] peligrosYRiesgos2 = new ReportParameter[5];
                        //Establecemos el valor de los parámetros
                        peligrosYRiesgos2[0] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        peligrosYRiesgos2[1] = new ReportParameter("metedologiaTexto", SG_SST.Reportes.RecursoParametros.MetodologiaTexto);
                        peligrosYRiesgos2[2] = new ReportParameter("procesoTexto", SG_SST.Reportes.RecursoParametros.ProcesoTexto);
                        peligrosYRiesgos2[3] = new ReportParameter("ZonaLugarTexto", SG_SST.Reportes.RecursoParametros.ZonaLugarTexto);
                        peligrosYRiesgos2[4] = new ReportParameter("TipoPeligroTexto", SG_SST.Reportes.RecursoParametros.TipoPeligroTexto);


                        ReportViewer1.LocalReport.SetParameters(peligrosYRiesgos2);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;
                    case "MetodologiaProcesoValoracion":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos3DataTable dtvpel5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos3TableAdapter davpel5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos3TableAdapter();

                        davpel5.FillByProcesoValoracion(dtvpel5, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.ProcesoInt);


                        ReportDataSource RDpel5 = new ReportDataSource();
                        RDpel5.Value = dtvpel5;
                        RDpel5.Name = "TiposPeligrosSedeMetodologia";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable dtvpel6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter davpel6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter();

                        //   davpel2.FillByValoracion(dtvpel2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);
                        davpel6.FillByValoracion(dtvpel6, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);
                        ReportDataSource RDpel6 = new ReportDataSource();
                        RDpel6.Value = dtvpel6;
                        RDpel6.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpel6M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpel6M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpel6M.FillByMetaIndicador(dtvpel6M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de identificación y valoración de peligros y riesgos");
                                  
                        ReportDataSource RDpel6M = new ReportDataSource();
                        RDpel6M.Value = dtvpel6M;
                        RDpel6M.Name = "DataSetMetaIndicador";

                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel5);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel6);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel6M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] peligrosYRiesgos3 = new ReportParameter[4];
                        //Establecemos el valor de los parámetros
                        peligrosYRiesgos3[0] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        peligrosYRiesgos3[1] = new ReportParameter("metedologiaTexto", SG_SST.Reportes.RecursoParametros.MetodologiaTexto);
                        peligrosYRiesgos3[2] = new ReportParameter("procesoTexto", SG_SST.Reportes.RecursoParametros.ProcesoTexto);
                        peligrosYRiesgos3[3] = new ReportParameter("TipoPeligroTexto", SG_SST.Reportes.RecursoParametros.TipoPeligroTexto);


                        ReportViewer1.LocalReport.SetParameters(peligrosYRiesgos3);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "MetodologiaValoracion":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos4DataTable dtvpel7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ValoresPeligrosRiesgos4DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos4TableAdapter davpel7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ValoresPeligrosRiesgos4TableAdapter();

                        davpel7.FillByMetodologiaValoracion(dtvpel7, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia);


                        ReportDataSource RDpel7 = new ReportDataSource();
                        RDpel7.Value = dtvpel7;
                        RDpel7.Name = "TiposPeligrosSedeMetodologia";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable dtvpel8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter davpel8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTableAdapter();

                        //   davpel2.FillByValoracion(dtvpel2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);
                        davpel8.FillByValoracion(dtvpel8, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);
                        ReportDataSource RDpel8 = new ReportDataSource();
                        RDpel8.Value = dtvpel8;
                        RDpel8.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpel8M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpel8M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpel8M.FillByMetaIndicador(dtvpel8M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de identificación y valoración de peligros y riesgos");
                                  
                        ReportDataSource RDpel8M = new ReportDataSource();
                        RDpel8M.Value = dtvpel8M;
                        RDpel8M.Name = "DataSetMetaIndicador";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel7);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel8);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel8M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] peligrosYRiesgos4 = new ReportParameter[3];
                        //Establecemos el valor de los parámetros
                        peligrosYRiesgos4[0] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        peligrosYRiesgos4[1] = new ReportParameter("metedologiaTexto", SG_SST.Reportes.RecursoParametros.MetodologiaTexto);
                        peligrosYRiesgos4[2] = new ReportParameter("TipoPeligroTexto", SG_SST.Reportes.RecursoParametros.TipoPeligroTexto);


                        ReportViewer1.LocalReport.SetParameters(peligrosYRiesgos4);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "EvaluacionSGSST":
                        
                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionEvaluacionDataTable dtvpla1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionEvaluacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionEvaluacionTableAdapter  davpla1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionEvaluacionTableAdapter();

                        davpla1.FillByDataSet1(dtvpla1, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                       

                        ReportDataSource RDpla1 = new ReportDataSource();
                        RDpla1.Value = dtvpla1;
                        RDpla1.Name = "DataSet1";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionEvaluacionDataTable dtvpla2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionEvaluacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionEvaluacionTableAdapter  davpla2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionEvaluacionTableAdapter();

                        davpla1.FillByDataSet2(dtvpla2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                       

                        ReportDataSource RDpla2 = new ReportDataSource();
                        RDpla2.Value = dtvpla2;
                        RDpla2.Name = "DataSet2";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionEvaluacionDataTable dtvpla3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionEvaluacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionEvaluacionTableAdapter  davpla3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionEvaluacionTableAdapter();

                        davpla3.FillByDataSet3(dtvpla3, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                       

                        ReportDataSource RDpla3 = new ReportDataSource();
                        RDpla3.Value = dtvpla3;
                        RDpla3.Name = "DataSet3";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla3M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla3M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla3M.FillByMetaIndicador(dtvpla3M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla3M = new ReportDataSource();
                        RDpla3M.Value = dtvpla3M;
                        RDpla3M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla1);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla2);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla3);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla3M);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion1 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion1[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion1[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion1);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        
                        break;

                    case "Auditorias":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAuditoriaDataTable dtvpla4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAuditoriaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAuditoriaTableAdapter davpla4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAuditoriaTableAdapter();

                        davpla4.FillByDataSet1(dtvpla4, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla4 = new ReportDataSource();
                        RDpla4.Value = dtvpla4;
                        RDpla4.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAuditoriaDataTable dtvpla5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAuditoriaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAuditoriaTableAdapter davpla5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAuditoriaTableAdapter();

                        davpla5.FillByDataSet2(dtvpla5, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla5 = new ReportDataSource();
                        RDpla5.Value = dtvpla5;
                        RDpla5.Name = "DataSet2";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAuditoriaDataTable dtvpla6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAuditoriaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAuditoriaTableAdapter davpla6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAuditoriaTableAdapter();

                        davpla6.FillByDataSet3(dtvpla6, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla6 = new ReportDataSource();
                        RDpla6.Value = dtvpla6;
                        RDpla6.Name = "DataSet3";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla6M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla6M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla6M.FillByMetaIndicador(dtvpla6M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla6M = new ReportDataSource();
                        RDpla6M.Value = dtvpla6M;
                        RDpla6M.Name = "DataSetMetaIndicador";
                                                

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla4);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla5);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla6);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla6M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion2 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion2[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion2[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion2);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;
                    case "AccionesPrevCorrectivas":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas1DataTable dtvpla7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas1TableAdapter davpla7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas1TableAdapter();

                        davpla7.FillByDataSet1(dtvpla7, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla7 = new ReportDataSource();
                        RDpla7.Value = dtvpla7;
                        RDpla7.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas2DataTable dtvpla8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas2TableAdapter davpla8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas2TableAdapter();

                        davpla8.FillByDataSet2(dtvpla8, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla8 = new ReportDataSource();
                        RDpla8.Value = dtvpla8;
                        RDpla8.Name = "DataSet2";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas3DataTable dtvpla9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas3TableAdapter davpla9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas3TableAdapter();

                        davpla9.FillByDataSet3(dtvpla9, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);

                    

                        ReportDataSource RDpla9 = new ReportDataSource();
                        RDpla9.Value = dtvpla9;
                        RDpla9.Name = "DataSet3";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas4DataTable dtvpla10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionAccionesPreventivas4DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas4TableAdapter davpla10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionAccionesPreventivas4TableAdapter();

                        davpla10.FillByDataSet4(dtvpla10, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);                 

                        ReportDataSource RDpla10 = new ReportDataSource();
                        RDpla10.Value = dtvpla10;
                        RDpla10.Name = "DataSet4";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla10M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla10M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla10M.FillByMetaIndicador(dtvpla10M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla10M = new ReportDataSource();
                        RDpla10M.Value = dtvpla10M;
                        RDpla10M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla7);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla8);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla9);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla10);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla10M);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion3 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion3[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion3[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion3);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "Inspeccion":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanDeAccionInspeccionDataTable dtvpla11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanDeAccionInspeccionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionInspeccionTableAdapter davpla11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionInspeccionTableAdapter();

                        davpla11.FillByDataSet4(dtvpla11, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla11 = new ReportDataSource();
                        RDpla11.Value = dtvpla11;
                        RDpla11.Name = "DataSet4";
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanDeAccionInspeccionDataTable dtvpla12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanDeAccionInspeccionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionInspeccionTableAdapter davpla12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionInspeccionTableAdapter();

                        davpla12.FillByDataSet5(dtvpla12, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RDpla12 = new ReportDataSource();
                        RDpla12.Value = dtvpla12;
                        RDpla12.Name = "DataSet5";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanDeAccionInspeccionDataTable dtvpla13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanDeAccionInspeccionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionInspeccionTableAdapter davpla13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanDeAccionInspeccionTableAdapter();

                        davpla13.FillByDataSet7(dtvpla13, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla13 = new ReportDataSource();
                        RDpla13.Value = dtvpla13;
                        RDpla13.Name = "DataSet7";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla13M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla13M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla13M.FillByMetaIndicador(dtvpla13M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla13M = new ReportDataSource();
                        RDpla13M.Value = dtvpla13M;
                        RDpla13M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla11);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla12);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla13);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla13M);
                       
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion4 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion4[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion4[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion4);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "RevisionSGSST":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable dtvpla14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter davpla14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter();

                        davpla14.FillByDataSet1(dtvpla14, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla14 = new ReportDataSource();
                        RDpla14.Value = dtvpla14;
                        RDpla14.Name = "DataSet1";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable dtvpla15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter davpla15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter();

                        davpla15.FillByDataSet2(dtvpla15, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla15 = new ReportDataSource();
                        RDpla15.Value = dtvpla15;
                        RDpla15.Name = "DataSet2";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable dtvpla16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter davpla16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter();

                        davpla16.FillByDataSet3(dtvpla16, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                     

                        ReportDataSource RDpla16 = new ReportDataSource();
                        RDpla16.Value = dtvpla16;
                        RDpla16.Name = "DataSet3";
                        
                                  
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable dtvpla17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionRevisionSGSSTDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter davpla17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionRevisionSGSSTTableAdapter();

                        davpla17.FillByDataSet4(dtvpla17, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                   

                        ReportDataSource RDpla17 = new ReportDataSource();
                        RDpla17.Value = dtvpla17;
                        RDpla17.Name = "DataSet4";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla17M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla17M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla17M.FillByMetaIndicador(dtvpla17M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla17M = new ReportDataSource();
                        RDpla17M.Value = dtvpla17M;
                        RDpla17M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla14);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla15);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla16);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla17);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla17M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion5 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion5[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion5[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion5);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "ActosInseguros":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable dtvpla18 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter davpla18 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter();

                        davpla18.FillByDataSet1(dtvpla18, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla18 = new ReportDataSource();
                        RDpla18.Value = dtvpla18;
                        RDpla18.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable dtvpla19 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter davpla19 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter();

                        davpla19.FillByDataSet2(dtvpla19, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla19 = new ReportDataSource();
                        RDpla19.Value = dtvpla19;
                        RDpla19.Name = "DataSet2";
                       
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable dtvpla20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter davpla20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter();

                        davpla20.FillByDataSet3(dtvpla20, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                        
                       

                        ReportDataSource RDpla20 = new ReportDataSource();
                        RDpla20.Value = dtvpla20;
                        RDpla20.Name = "DataSet3";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable dtvpla21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCondicionesInsegurasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter davpla21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCondicionesInsegurasTableAdapter();

                        davpla21.FillByDataSet4(dtvpla21, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla21 = new ReportDataSource();
                        RDpla21.Value = dtvpla21;
                        RDpla21.Name = "DataSet4";
                       
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla21M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla21M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla21M.FillByMetaIndicador(dtvpla21M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla21M = new ReportDataSource();
                        RDpla21M.Value = dtvpla21M;
                        RDpla21M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla18);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla19);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla20);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla21);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla21M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion6 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion6[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion6[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion6);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "ComiteConvivencia":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral1DataTable dtvpla22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral1TableAdapter davpla22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral1TableAdapter();

                        davpla22.FillByDataSet1(dtvpla22, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla22 = new ReportDataSource();
                        RDpla22.Value = dtvpla22;
                        RDpla22.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral2DataTable dtvpla23 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral2TableAdapter davpla23 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral2TableAdapter();

                        davpla23.FillByDataSet2(dtvpla23, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla23 = new ReportDataSource();
                        RDpla23.Value = dtvpla23;
                        RDpla23.Name = "DataSet2";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral3DataTable dtvpla24 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral3TableAdapter davpla24 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral3TableAdapter();

                        davpla24.FillByDataSet3(dtvpla24, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RDpla24 = new ReportDataSource();
                        RDpla24.Value = dtvpla24;
                        RDpla24.Name = "DataSet3";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral4DataTable dtvpla25 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionConvivenciaLaboral4DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral4TableAdapter davpla25 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionConvivenciaLaboral4TableAdapter();

                        davpla25.FillByDataSet4(dtvpla25, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla25 = new ReportDataSource();
                        RDpla25.Value = dtvpla25;
                        RDpla25.Name = "DataSet4";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla25M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla25M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla25M.FillByMetaIndicador(dtvpla25M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla25M = new ReportDataSource();
                        RDpla25M.Value = dtvpla25M;
                        RDpla25M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla22);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla23);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla24);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla25);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla25M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion7 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion7[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion7[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion7);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;


                    case "Coppast":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCoppast1DataTable dtvpla26 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCoppast1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCoppast1TableAdapter davpla26 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCoppast1TableAdapter();

                        davpla26.FillByDataSet1(dtvpla26, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla26 = new ReportDataSource();
                        RDpla26.Value = dtvpla26;
                        RDpla26.Name = "DataSet1";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCoppastt2DataTable dtvpla27 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCoppastt2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCoppastt2TableAdapter davpla27 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCoppastt2TableAdapter();

                        davpla27.FillByDataSet2(dtvpla27, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla27 = new ReportDataSource();
                        RDpla27.Value = dtvpla27;
                        RDpla27.Name = "DataSet2";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCoppast3DataTable dtvpla28 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCoppast3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCoppast3TableAdapter davpla28 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCoppast3TableAdapter();

                        davpla28.FillByDataSet3(dtvpla28, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);


                        ReportDataSource RDpla28 = new ReportDataSource();
                        RDpla28.Value = dtvpla28;
                        RDpla28.Name = "DataSet3";



                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCopast4DataTable dtvpla29 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.PlanesDeAccionCopast4DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCopast4TableAdapter davpla29 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.PlanesDeAccionCopast4TableAdapter();

                        davpla29.FillByDataSet4(dtvpla29, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RDpla29 = new ReportDataSource();
                        RDpla29.Value = dtvpla29;
                        RDpla29.Name = "DataSet4";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtvpla29M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter davpla29M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        davpla29M.FillByMetaIndicador(dtvpla29M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de eficacia de cierre de planes de acción");
                                  
                        ReportDataSource RDpla29M = new ReportDataSource();
                        RDpla29M.Value = dtvpla29M;
                        RDpla29M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla26);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla27);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla28);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla29);
                        ReportViewer1.LocalReport.DataSources.Add(RDpla29M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] planesDeAccion8 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        planesDeAccion8[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        planesDeAccion8[1] = new ReportParameter("moduloTexto", SG_SST.Reportes.RecursoParametros.ModuloTexto);

                        ReportViewer1.LocalReport.SetParameters(planesDeAccion8);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;
                }
            }
        }
                        
                        
                        
                        
  </script>
        <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Height="1200px" Width="100%" Enabled="true"
                BackColor="White" BorderColor="black" Font-Bold="true" InternalBorderStyle="None" ShowParameterPrompts="true"   
                AsyncRendering="false" ShowExportControls="true" ShowBackButton="False" ShowFindControls="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False" InteractivityPostBackMode="SynchronousOnDrillthrough" PageCountMode="Actual" ShowPageNavigationControls="False" >

     </rsweb:ReportViewer>
    </div>
       
    </form>
</body>
</html>
