<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDeReportesIndDatos.aspx.cs" Inherits="SG_SST.Views.ReportesAplicacion.VisorDeReportesIndDatos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

 <head runat="server">
  <script runat="server">

        void Page_Load(object sender, EventArgs e)
        {
           MostrarReporteIndDatos();
        }
        protected void MostrarReporteIndDatos()
        {
            if (!IsPostBack)
            {

                switch (SG_SST.Reportes.RecursoParametros.Reporte)
                {
                    case "EstandaresMinimosDatos":

                        ReportViewer1.Reset();

                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndEvalEstandaresMinimosDataTable dtv1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndEvalEstandaresMinimosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndEvalEstandaresMinimosTableAdapter dav1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndEvalEstandaresMinimosTableAdapter();

                     
                        dav1.FillByFiltro(dtv1, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD1 = new ReportDataSource();
                        RD1.Value = dtv1;
                        RD1.Name = "DataSetEvaluaciones";


                        ReportViewer1.LocalReport.DataSources.Clear();

                        ReportViewer1.LocalReport.DataSources.Add(RD1);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportViewer1.ShowParameterPrompts = false;
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        
                        break;


                    case "AccionCorrectivaPreventivaDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndAccionesCorrPrevMejActividadesDataTable dtv2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndAccionesCorrPrevMejActividadesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndAccionesCorrPrevMejActividadesTableAdapter dav2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndAccionesCorrPrevMejActividadesTableAdapter();


                        dav2.FillByFiltro(dtv2,  SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD = new ReportDataSource();
                        RD.Value = dtv2;
                        RD.Name = "DataSetTotal";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD);
          
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "CondicionInseguraDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndActosCondicionesInsegurasDataTable dtv3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndActosCondicionesInsegurasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndActosCondicionesInsegurasTableAdapter dav3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndActosCondicionesInsegurasTableAdapter();


                        dav3.FillByFiltro(dtv3, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.Sede,SG_SST.Reportes.RecursoParametros.TipoReporte);
               
                        ReportDataSource RD3 = new ReportDataSource();
                        RD3.Value = dtv3;
                        RD3.Name = "DataSetTotal";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD3);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;


                    case "AccidentesDeTrabajoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndAccidenteDeTrabajoDataTable dtv4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndAccidenteDeTrabajoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndAccidenteDeTrabajoTableAdapter dav4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndAccidenteDeTrabajoTableAdapter();


                        dav4.FillByFiltro(dtv4,  SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede);
                       
                        ReportDataSource RD4 = new ReportDataSource();
                        RD4.Value = dtv4;
                        RD4.Name = "DataSetTotalAT";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD4);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "FrecuenciaAusentismoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndFrecuenciaAusentismoDataTable dtv5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndFrecuenciaAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndFrecuenciaAusentismoTableAdapter dav5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndFrecuenciaAusentismoTableAdapter();


                        dav5.FillByFiltro(dtv5,SG_SST.Reportes.RecursoParametros.Contigencia, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede);
                     
                        ReportDataSource RD5 = new ReportDataSource();
                        RD5.Value = dtv5;
                        RD5.Name = "DataSetTotalAus";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD5);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "CapacitacionEntrenamientoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.Tbl_PlanCapacitacionDataTable dtv6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.Tbl_PlanCapacitacionDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.Tbl_PlanCapacitacionTableAdapter dav6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.Tbl_PlanCapacitacionTableAdapter();


                        dav6.FillByFiltro(dtv6,  SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD6 = new ReportDataSource();
                        RD6.Value = dtv6;
                        RD6.Name = "DataSetTotal";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD6);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "PlanTrabajoAnualDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndPlanTrabajoAnualDataTable dtv7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndPlanTrabajoAnualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndPlanTrabajoAnualTableAdapter dav7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndPlanTrabajoAnualTableAdapter();


                        dav7.FillByFiltro(dtv7, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Anio);
                        
                        ReportDataSource RD7 = new ReportDataSource();
                        RD7.Value = dtv7;
                        RD7.Name = "DataSetTotal";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD7);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;


                    case "SeveridadAusentismoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndSeveridadAusentismoDataTable dtv8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndSeveridadAusentismoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndSeveridadAusentismoTableAdapter dav8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndSeveridadAusentismoTableAdapter();


                        dav8.FillByFiltro(dtv8, SG_SST.Reportes.RecursoParametros.Contigencia, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede);
                        
                        ReportDataSource RD8 = new ReportDataSource();
                        RD8.Value = dtv8;
                        RD8.Name = "DataSetTotalAus";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD8);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "TasaAccidentalidadDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndTasaAccidentalidadDataTable dtv9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndTasaAccidentalidadDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndTasaAccidentalidadTableAdapter dav9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndTasaAccidentalidadTableAdapter();


                        dav9.FillByFiltro(dtv9,  SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede);
                       
                        
                        ReportDataSource RD9 = new ReportDataSource();
                        RD9.Value = dtv9;
                        RD9.Name = "DataSetTotalAT";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD9);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "CumplimientoRequisitosLegalesDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndRequisitosLegalesDataTable dtv10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndRequisitosLegalesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndRequisitosLegalesTableAdapter dav10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndRequisitosLegalesTableAdapter();


                        dav10.FillByFiltro(dtv10, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);


                        ReportDataSource RD10 = new ReportDataSource();
                        RD10.Value = dtv10;
                        RD10.Name = "DataSetTotal";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD10);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "AccidenteDeTrabajoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndSeveridadAusentismoDatosDataTable dtv11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndSeveridadAusentismoDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndSeveridadAusentismoDatosTableAdapter dav11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndSeveridadAusentismoDatosTableAdapter();


                        dav11.FillByFiltro(dtv11,  SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Sede);
                       
                        ReportDataSource RD11 = new ReportDataSource();
                        RD11.Value = dtv11;
                        RD11.Name = "DataSetTotalAus";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD11);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "LesionesIncapacitantesDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndFrecuenciaAccidentesTrabajoDatosDataTable dtv12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.V_IndFrecuenciaAccidentesTrabajoDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndFrecuenciaAccidentesTrabajoDatosTableAdapter dav12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.V_IndFrecuenciaAccidentesTrabajoDatosTableAdapter();


                        dav12.FillByFiltro(dtv12, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede);
                    
                        ReportDataSource RD12 = new ReportDataSource();
                        RD12.Value = dtv12;
                        RD12.Name = "DataSetTotal";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD12);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;


                    case "DxCondicionesSaludDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.IndDxSaludDatosDataTable dtv13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.IndDxSaludDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.IndDxSaludDatosTableAdapter dav13 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.IndDxSaludDatosTableAdapter();


                        dav13.FillByFiltro(dtv13, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede,SG_SST.Reportes.RecursoParametros.Proceso);
                        
                        ReportDataSource RD13 = new ReportDataSource();
                        RD13.Value = dtv13;
                        RD13.Name = "DataSetTotalDx";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD13);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "AnalisisVulnerabilidadDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadDataSet1DataTable dtv14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadDataSet1TableAdapter dav14 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadDataSet1TableAdapter();


                        dav14.FillByDataSet1(dtv14, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);
                        
                        ReportDataSource RD14 = new ReportDataSource();
                        RD14.Value = dtv14;
                        RD14.Name = "DataSet1";
                        
                         SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadIdentificaAmenazaDataTable dtv15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadIdentificaAmenazaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadIdentificaAmenazaTableAdapter dav15 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadIdentificaAmenazaTableAdapter();


                        dav15.FillByIdentificaAmenaza(dtv15, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);
                        
                        ReportDataSource RD15 = new ReportDataSource();
                        RD15.Value = dtv15;
                        RD15.Name = "identificaAmenaza";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadPersonasDataTable dtv16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadPersonasTableAdapter dav16 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadPersonasTableAdapter();


                        dav16.FillByVulnerabilidadPersonas(dtv16, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);
                        
                        ReportDataSource RD16 = new ReportDataSource();
                        RD16.Value = dtv16;
                        RD16.Name = "personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadRecursosDataTable dtv17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.VulnerabilidadRecursosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadRecursosTableAdapter dav17 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.VulnerabilidadRecursosTableAdapter();


                        dav17.FillByRecursos(dtv17, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeTexto);
                        
                        ReportDataSource RD17 = new ReportDataSource();
                        RD17.Value = dtv17;
                        RD17.Name = "RECURSOS";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD14);
                        ReportViewer1.LocalReport.DataSources.Add(RD15);
                        ReportViewer1.LocalReport.DataSources.Add(RD16);
                        ReportViewer1.LocalReport.DataSources.Add(RD17);
                        
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "PerfilSocioDemograficoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PerfilSocioDataSet1DataTable dtv20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PerfilSocioDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PerfilSocioDataSet1TableAdapter dav20 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PerfilSocioDataSet1TableAdapter();


                        dav20.FillByDataSet1(dtv20, SG_SST.Reportes.RecursoParametros.NitEmpresa,  SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
                  
                        ReportDataSource RD20 = new ReportDataSource();
                        RD20.Value = dtv20;
                        RD20.Name = "DataSet1";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PerfilSocioDataSet2DataTable dtv21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PerfilSocioDataSet2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PerfilSocioDataSet2TableAdapter dav21 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PerfilSocioDataSet2TableAdapter();


                        dav21.FillByDataSet2(dtv21, SG_SST.Reportes.RecursoParametros.NitEmpresa,  SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
                  
                        ReportDataSource RD21 = new ReportDataSource();
                        RD21.Value = dtv21;
                        RD21.Name = "DataSet2";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PerfilSocioDataSet3DataTable dtv22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PerfilSocioDataSet3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PerfilSocioDataSet3TableAdapter dav22 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PerfilSocioDataSet3TableAdapter();


                        dav22.FillByDataSet3(dtv22, SG_SST.Reportes.RecursoParametros.NitEmpresa,  SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
                  
                        ReportDataSource RD22 = new ReportDataSource();
                        RD22.Value = dtv22;
                        RD22.Name = "DataSet3";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD20);
                        ReportViewer1.LocalReport.DataSources.Add(RD21);
                        ReportViewer1.LocalReport.DataSources.Add(RD22);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;


                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "ComunicacionesIndPersonasDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesIntPersonasDatosDataTable dtv73 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesIntPersonasDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesIntPersonasDatosTableAdapter dav73 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesIntPersonasDatosTableAdapter();

                        dav73.FillByPersonas(dtv73, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Documento);

                        ReportDataSource RD73 = new ReportDataSource();
                        RD73.Value = dtv73;
                        RD73.Name = "Internos_personas";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD73);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportViewer1.LocalReport.Refresh();
                        ReportViewer1.Visible = true;


                        break;

                    case "ComunicacionesIndCargoDatos":

       
                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesIntCargosDatosDataTable dtv74 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesIntCargosDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesIntCargosDatosTableAdapter dav74 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesIntCargosDatosTableAdapter();

                        dav74.FillByInternosCargos(dtv74, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);

                        ReportDataSource RD74 = new ReportDataSource();
                        RD74.Value = dtv74;
                        RD74.Name = "Internos_cargos";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD74);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ComunicacionesIndGrupoDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicadoIndInternosGruposDatosDataTable dtv75 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicadoIndInternosGruposDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicadoIndInternosGruposDatosTableAdapter dav75 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicadoIndInternosGruposDatosTableAdapter();

                 
                        dav75.FillByInternosGrupos(dtv75, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.GrupoTexto);

                        ReportDataSource RD75 = new ReportDataSource();
                        RD75.Value = dtv75;
                        RD75.Name = "Internos_grupos";
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD75);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ComunicacionesIndPersonasAPPDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesAPPPersonasDatosDataTable dtv73APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesAPPPersonasDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesAPPPersonasDatosTableAdapter dav73APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesAPPPersonasDatosTableAdapter();

                       
                        dav73APP.FillByAppPersonas(dtv73APP, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Documento);

                        ReportDataSource RD73APP = new ReportDataSource();
                        RD73APP.Value = dtv73APP;
                        RD73APP.Name = "app_personas";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD73APP);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ComunicacionesIndCargoAPPDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesAPPCargosDatosDataTable dtv74APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.ComunicacionesAPPCargosDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesAPPCargosDatosTableAdapter dav74APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.ComunicacionesAPPCargosDatosTableAdapter();

                        dav74APP.FillByAppCargos(dtv74APP, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);

                        ReportDataSource RD74APP = new ReportDataSource();
                        RD74APP.Value = dtv74APP;
                        RD74APP.Name = "Internos_cargos";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD74APP);



                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "EvaluacionSGSSTDatos":

                       ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionEvaluacionDataSet1DataTable dtvpla1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionEvaluacionDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionEvaluacionDataSet1TableAdapter davpla1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionEvaluacionDataSet1TableAdapter();

                        davpla1.FillByDataSet1(dtvpla1, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                       
                        ReportDataSource RDpla1 = new ReportDataSource();
                        RDpla1.Value = dtvpla1;
                        RDpla1.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla1);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "AccionesPrevCorrectivasDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionAccionesPreventivasCorrectivasDatosDataTable dtvpla2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionAccionesPreventivasCorrectivasDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionAccionesPreventivasCorrectivasDatosTableAdapter davpla2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionAccionesPreventivasCorrectivasDatosTableAdapter();

                        davpla2.FillByDataSet1(dtvpla2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla2 = new ReportDataSource();
                        RDpla2.Value = dtvpla2;
                        RDpla2.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla2);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "AuditoriasDatos":

                       
                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionAuditoriaDatosDataTable dtvpla3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionAuditoriaDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionAuditoriaDatosTableAdapter davpla3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionAuditoriaDatosTableAdapter();

                        davpla3.FillByDataSet1(dtvpla3, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla3 = new ReportDataSource();
                        RDpla3.Value = dtvpla3;
                        RDpla3.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla3);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "InspeccionDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionInspeccionDatosDataTable dtvpla4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionInspeccionDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionInspeccionDatosTableAdapter davpla4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionInspeccionDatosTableAdapter();

                        davpla4.FillByDataSet1(dtvpla4, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla4 = new ReportDataSource();
                        RDpla4.Value = dtvpla4;
                        RDpla4.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla4);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ActosInsegurosDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionCondicionesInsegurasDatosDataTable dtvpla5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionCondicionesInsegurasDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionCondicionesInsegurasDatosTableAdapter davpla5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionCondicionesInsegurasDatosTableAdapter();

                        davpla5.FillByDataSet1(dtvpla5, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla5 = new ReportDataSource();
                        RDpla5.Value = dtvpla5;
                        RDpla5.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla5);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "CoppastDatos":

                       ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanesDeAccionCopasstDatosDataTable dtvpla6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanesDeAccionCopasstDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanesDeAccionCopasstDatosTableAdapter davpla6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanesDeAccionCopasstDatosTableAdapter();

                        davpla6.FillByDataSet1(dtvpla6, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla6 = new ReportDataSource();
                        RDpla6.Value = dtvpla6;
                        RDpla6.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla6);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ComiteConvivenciaDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionComiteConvivenciaLaboralDataTable dtvpla7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanDeAccionComiteConvivenciaLaboralDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionComiteConvivenciaLaboralTableAdapter davpla7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanDeAccionComiteConvivenciaLaboralTableAdapter();

                        davpla7.FillByDataSet1(dtvpla7, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla7 = new ReportDataSource();
                        RDpla7.Value = dtvpla7;
                        RDpla7.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla7);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "RevisionSGSSTDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanesDeAccionSGSSTDatosDataTable dtvpla8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.PlanesDeAccionSGSSTDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanesDeAccionSGSSTDatosTableAdapter davpla8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.PlanesDeAccionSGSSTDatosTableAdapter();

                        davpla8.FillByDataSet1(dtvpla8, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RDpla8 = new ReportDataSource();
                        RDpla8.Value = dtvpla8;
                        RDpla8.Name = "DataSet1";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpla8);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ProcesoLugarActividadValoracionDatos":

                         ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable dtvpel1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter davpel1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter();

                        davpel1.FillByValoracion(dtvpel1, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);

                        ReportDataSource RDpel1 = new ReportDataSource();
                        RDpel1.Value = dtvpel1;
                        RDpel1.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.MetodologiaProcesoLugarActividadTablaDatosDataTable dtvpel2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.MetodologiaProcesoLugarActividadTablaDatosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.MetodologiaProcesoLugarActividadTablaDatosTableAdapter davpel2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.MetodologiaProcesoLugarActividadTablaDatosTableAdapter();

                        davpel2.FillByFiltro(dtvpel2, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.ProcesoInt, SG_SST.Reportes.RecursoParametros.ZonaLugarTexto, SG_SST.Reportes.RecursoParametros.ActividadTexto);
                        
                        
                        ReportDataSource RDpel2 = new ReportDataSource();
                        RDpel2.Value = dtvpel2;
                        RDpel2.Name = "TiposPeligrosSedeMetodologia";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel1);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel2);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                    case "ProcesoLugarValoracionDatos":
                        
                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable dtvpel3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter davpel3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter();

                        davpel3.FillByValoracion(dtvpel3, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);

                        ReportDataSource RDpel3 = new ReportDataSource();
                        RDpel3.Value = dtvpel3;
                        RDpel3.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.MetodologiaProcesoLugarTablaDataTable dtvpel4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.MetodologiaProcesoLugarTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.MetodologiaProcesoLugarTablaTableAdapter davpel4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.MetodologiaProcesoLugarTablaTableAdapter();

                        davpel4.FillByFiltro(dtvpel4, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.ProcesoInt, SG_SST.Reportes.RecursoParametros.ZonaLugarTexto);
                       
                        ReportDataSource RDpel4 = new ReportDataSource();
                        RDpel4.Value = dtvpel4;
                        RDpel4.Name = "TiposPeligrosSedeMetodologia";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel3);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel4);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        
                         break;
                    case "MetodologiaProcesoValoracionDatos":

                         ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable dtvpel5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter davpel5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter();

                        davpel5.FillByValoracion(dtvpel5, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);

                        ReportDataSource RDpel5 = new ReportDataSource();
                        RDpel5.Value = dtvpel5;
                        RDpel5.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.MetodologiaProcesoTablaDataTable dtvpel6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.MetodologiaProcesoTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.MetodologiaProcesoTablaTableAdapter davpel6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.MetodologiaProcesoTablaTableAdapter();

                        davpel6.FillByFiltro(dtvpel6, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.ProcesoInt);
                       
                        ReportDataSource RDpel6 = new ReportDataSource();
                        RDpel6.Value = dtvpel6;
                        RDpel6.Name = "TiposPeligrosSedeMetodologia";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel5);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel6);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        
                        break;

                    case "MetodologiaValoracionDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable dtvpel7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.SP_ValoracionDeRiesgosPeligrosTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter davpel7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.SP_ValoracionDeRiesgosPeligrosTablaTableAdapter();

                        davpel7.FillByValoracion(dtvpel7, SG_SST.Reportes.RecursoParametros.Metodologia, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.TipoPeligro);

                        ReportDataSource RDpel7 = new ReportDataSource();
                        RDpel7.Value = dtvpel7;
                        RDpel7.Name = "ValoracionRiesgos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.SedeMetodologiaTablaDataTable dtvpel8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndData.SedeMetodologiaTablaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.SedeMetodologiaTablaTableAdapter davpel8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndDataTableAdapters.SedeMetodologiaTablaTableAdapter();

                        davpel8.FillByFiltro(dtvpel8, SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Metodologia);
                       
                        ReportDataSource RDpel8 = new ReportDataSource();
                        RDpel8.Value = dtvpel8;
                        RDpel8.Name = "TiposPeligrosSedeMetodologia";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RDpel7);
                        ReportViewer1.LocalReport.DataSources.Add(RDpel8);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/IndicadoresDatos/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        
                        break;
                }
            }
        }

      </script>
</head>

<body>
    <form id="form1" runat="server">
     <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Height="1200px" Width="100%" Enabled="true"
                BackColor="White" BorderColor="black" Font-Bold="true" InternalBorderStyle="None" ShowParameterPrompts="true"   
                AsyncRendering="false" ShowExportControls="true" ShowBackButton="False" ShowFindControls="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False"  PageCountMode="Actual" ShowPageNavigationControls="False">

     </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
