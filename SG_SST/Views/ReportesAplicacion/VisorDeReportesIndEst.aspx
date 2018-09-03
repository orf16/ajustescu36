<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDeReportesIndRes.aspx.cs" Inherits="SG_SST.Views.ReportesAplicacion.VisorDeReportesInd" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            MostrarReporteIndEst();
        }
        protected void MostrarReporteIndEst()
        {
            if (!IsPostBack)
            {

                switch (SG_SST.Reportes.RecursoParametros.Reporte)
                {
                   
                        //si
                        
                    case "ComiteCoppast":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet1DataTable dtv37Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet1TableAdapter dav37Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet1TableAdapter();


                        dav37Cop.FillByFiltro(dtv37Cop, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD37Cop = new ReportDataSource();
                        RD37Cop.Value = dtv37Cop;
                        RD37Cop.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet2DataTable dtv38Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet2TableAdapter dav38Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet2TableAdapter();


                        dav38Cop.FillByFiltro(dtv38Cop, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD38Cop = new ReportDataSource();
                        RD38Cop.Value = dtv38Cop;
                        RD38Cop.Name = "DataSet2";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet3DataTable dtv39Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet3TableAdapter dav39Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet3TableAdapter();


                        dav39Cop.FillByFiltro(dtv39Cop, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD39Cop = new ReportDataSource();
                        RD39Cop.Value = dtv39Cop;
                        RD39Cop.Name = "DataSet3";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet4DataTable dtv40Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet4DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet4TableAdapter dav40Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet4TableAdapter();


                        dav40Cop.FillByFiltro(dtv40Cop, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD40Cop = new ReportDataSource();
                        RD40Cop.Value = dtv40Cop;
                        RD40Cop.Name = "DataSet4";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet5DataTable dtv41Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet5DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet5TableAdapter dav41Cop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet5TableAdapter();


                        dav41Cop.FillByFiltro(dtv41Cop, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD41Cop = new ReportDataSource();
                        RD41Cop.Value = dtv41Cop;
                        RD41Cop.Name = "DataSet5";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv41MCop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav41MCop = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav41MCop.FillByMetaIndicador(dtv41MCop, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de comité Copasst");
                                  
                        ReportDataSource RD41MCop = new ReportDataSource();
                        RD41MCop.Value = dtv41MCop;
                        RD41MCop.Name = "DataSetMetaIndicador";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndicadorCopastMensualDataTable dtvCopMen = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndicadorCopastMensualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndicadorCopastMensualTableAdapter davCopMen = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndicadorCopastMensualTableAdapter();

                        davCopMen.Fill(dtvCopMen, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.Sede);


                        ReportDataSource RDCopMen = new ReportDataSource();
                        RDCopMen.Value = dtvCopMen;
                        RDCopMen.Name = "DataSetCoppast";
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD37Cop);
                        ReportViewer1.LocalReport.DataSources.Add(RD38Cop);
                        ReportViewer1.LocalReport.DataSources.Add(RD39Cop);
                        ReportViewer1.LocalReport.DataSources.Add(RD40Cop);
                        ReportViewer1.LocalReport.DataSources.Add(RD41Cop);
                        ReportViewer1.LocalReport.DataSources.Add(RDCopMen);
                        ReportViewer1.LocalReport.DataSources.Add(RD41MCop);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parametersConvivencia = new ReportParameter[2];
                        //Establecemos el valor de los parámetros


                        parametersConvivencia[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        parametersConvivencia[1] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        ReportViewer1.LocalReport.SetParameters(parametersConvivencia);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "ConvivenciaLaboral":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet1DataTable dtv37 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet1TableAdapter dav37 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet1TableAdapter();


                        dav37.FillByFiltro(dtv37, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD37 = new ReportDataSource();
                        RD37.Value = dtv37;
                        RD37.Name = "DataSet1";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet2DataTable dtv38 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet2DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet2TableAdapter dav38 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet2TableAdapter();


                        dav38.FillByFiltro(dtv38, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD38 = new ReportDataSource();
                        RD38.Value = dtv38;
                        RD38.Name = "DataSet2";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet3DataTable dtv39 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet3DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet3TableAdapter dav39 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet3TableAdapter();


                        dav39.FillByFiltro(dtv39, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD39 = new ReportDataSource();
                        RD39.Value = dtv39;
                        RD39.Name = "DataSet3";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet4DataTable dtv40 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet4DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet4TableAdapter dav40 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet4TableAdapter();


                        dav40.FillByFiltro(dtv40, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD40 = new ReportDataSource();
                        RD40.Value = dtv40;
                        RD40.Name = "DataSet4";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet5DataTable dtv41 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndCoppastDataSet5DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet5TableAdapter dav41 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndCoppastDataSet5TableAdapter();


                        dav41.FillByFiltro(dtv41, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);

                        ReportDataSource RD41 = new ReportDataSource();
                        RD41.Value = dtv41;
                        RD41.Name = "DataSet5";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv41M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav41M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav41M.FillByMetaIndicador(dtv41M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de Comité Convivencia Laboral");

                        ReportDataSource RD41M = new ReportDataSource();
                        RD41M.Value = dtv41M;
                        RD41M.Name = "DataSetMetaIndicador";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndConvivenciaMensualDataTable dtvConMen = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndConvivenciaMensualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndConvivenciaMensualTableAdapter davConMen = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndConvivenciaMensualTableAdapter();

                        davConMen.Fill(dtvConMen, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede);


                        ReportDataSource RDConMen = new ReportDataSource();
                        RDConMen.Value = dtvConMen;
                        RDConMen.Name = "DataSetConvivenciaMensual";

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD37);
                        ReportViewer1.LocalReport.DataSources.Add(RD38);
                        ReportViewer1.LocalReport.DataSources.Add(RD39);
                        ReportViewer1.LocalReport.DataSources.Add(RD40);
                        ReportViewer1.LocalReport.DataSources.Add(RD41);
                        ReportViewer1.LocalReport.DataSources.Add(RDConMen);
                        ReportViewer1.LocalReport.DataSources.Add(RD41M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parametersCoppast = new ReportParameter[2];
                        //Establecemos el valor de los parámetros


                        parametersCoppast[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        parametersCoppast[1] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        ReportViewer1.LocalReport.SetParameters(parametersCoppast);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                        //si

                    case "DxCondicionesSalud":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable dtv42 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter dav42 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter();


                        dav42.FillByDxCIE10(dtv42, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
     

                        ReportDataSource RD42 = new ReportDataSource();
                        RD42.Value = dtv42;
                        RD42.Name = "DataSetDxCIE10";

                    
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable dtv43 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter dav43 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter();


                        dav43.FillByPruebasClinicas(dtv43, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
     

                        ReportDataSource RD43 = new ReportDataSource();
                        RD43.Value = dtv43;
                        RD43.Name = "DataSetPruebasClinicas";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable dtv44 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter dav44 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter();


                        dav44.FillByPruebasPClinicas(dtv44, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
     

                        ReportDataSource RD44 = new ReportDataSource();
                        RD44.Value = dtv44;
                        RD44.Name = "DataSetPruebasParaclinicas";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable dtv45 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndDxSaludDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter dav45 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndDxSaludTableAdapter();


                        dav45.FillBySintomatologia(dtv45, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);
     

                        ReportDataSource RD45 = new ReportDataSource();
                        RD45.Value = dtv45;
                        RD45.Name = "DataSetSintomatologia";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv45M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav45M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav45M.FillByMetaIndicador(dtv45M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador diagnóstico de condiciones de salud");
                                  
                        ReportDataSource RD45M = new ReportDataSource();
                        RD45M.Value = dtv45M;
                        RD45M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD42);
                        ReportViewer1.LocalReport.DataSources.Add(RD43);
                        ReportViewer1.LocalReport.DataSources.Add(RD44);
                        ReportViewer1.LocalReport.DataSources.Add(RD45);
                        ReportViewer1.LocalReport.DataSources.Add(RD45M);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parametersDxSalud = new ReportParameter[3];
                        //Establecemos el valor de los parámetros


                        parametersDxSalud[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        parametersDxSalud[1] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        parametersDxSalud[2] = new ReportParameter("procesoTexto", SG_SST.Reportes.RecursoParametros.ProcesoTexto);

                        ReportViewer1.LocalReport.SetParameters(parametersDxSalud);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "PerfilSocioDemografico":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_GradoEscolaridadPerfilSocioDataTable dtv46 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_GradoEscolaridadPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_GradoEscolaridadPerfilSocioTableAdapter dav46 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_GradoEscolaridadPerfilSocioTableAdapter();


                        dav46.FillByGradoEscolaridad(dtv46, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD46 = new ReportDataSource();
                        RD46.Value = dtv46;
                        RD46.Name = "DataSet1GradoEsc";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_CiudadResidenciaPerfilSocioDataTable dtv47 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_CiudadResidenciaPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_CiudadResidenciaPerfilSocioTableAdapter dav47 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_CiudadResidenciaPerfilSocioTableAdapter();


                        dav47.FillByCiudad(dtv47, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD47 = new ReportDataSource();
                        RD47.Value = dtv47;
                        RD47.Name = "DataSet2Ciudad";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_SexoPerfilSocioDataTable dtv48 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_SexoPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_SexoPerfilSocioTableAdapter dav48 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_SexoPerfilSocioTableAdapter();


                        dav48.FillBySexo(dtv48, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD48 = new ReportDataSource();
                        RD48.Value = dtv48;
                        RD48.Name = "DataSet3Sexo";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IngresosPerfilSocioDataTable dtv49 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IngresosPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IngresosPerfilSocioTableAdapter dav49 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IngresosPerfilSocioTableAdapter();


                        dav49.FillByIngresos(dtv49, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD49 = new ReportDataSource();
                        RD49.Value = dtv49;
                        RD49.Name = "DataSet4Ingresos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_VinculacionLaboralPerfilSocioDataTable dtv50 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_VinculacionLaboralPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_VinculacionLaboralPerfilSocioTableAdapter dav50 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_VinculacionLaboralPerfilSocioTableAdapter();


                        dav50.FillByVinculacionLaboral(dtv50, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD50 = new ReportDataSource();
                        RD50.Value = dtv50;
                        RD50.Name = "DataSet5VinculacionLab";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_EstratoSocioeconoPerfilSocioDataTable dtv51 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_EstratoSocioeconoPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_EstratoSocioeconoPerfilSocioTableAdapter dav51 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_EstratoSocioeconoPerfilSocioTableAdapter();


                        dav51.FillByEstrato(dtv51, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD51 = new ReportDataSource();
                        RD51.Value = dtv51;
                        RD51.Name = "DataSet6EstratoSoc";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_EstadoCivilPerfilSocioDataTable dtv52 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_EstadoCivilPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_EstadoCivilPerfilSocioTableAdapter dav52 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_EstadoCivilPerfilSocioTableAdapter();


                        dav52.FillByEstadoCivil(dtv52, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD52 = new ReportDataSource();
                        RD52.Value = dtv52;
                        RD52.Name = "DataSet7EstadoCivil";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_ConyuguePerfilSocioDataTable dtv53 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_ConyuguePerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_ConyuguePerfilSocioTableAdapter dav53 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_ConyuguePerfilSocioTableAdapter();


                        dav53.FillByConyuge(dtv53, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD53 = new ReportDataSource();
                        RD53.Value = dtv53;
                        RD53.Name = "DataSet8Conyuge";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_HijosPerfilSocioDataTable dtv54 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_HijosPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_HijosPerfilSocioTableAdapter dav54 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_HijosPerfilSocioTableAdapter();


                        dav54.FillByHijos(dtv54, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD54 = new ReportDataSource();
                        RD54.Value = dtv54;
                        RD54.Name = "DataSet9Hijos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_EtniaPerfilsocioDataTable dtv55 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_EtniaPerfilsocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_EtniaPerfilsocioTableAdapter dav55 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_EtniaPerfilsocioTableAdapter();
                        dav55.FillByEtnia(dtv55, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD55 = new ReportDataSource();
                        RD55.Value = dtv55;
                        RD55.Name = "DataSet10Etnia";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_GeneralPerfilSocioDataTable dtv56 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_GeneralPerfilSocioDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_GeneralPerfilSocioTableAdapter dav56 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_GeneralPerfilSocioTableAdapter();
                        dav56.FillByFiltro(dtv56, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Sede, SG_SST.Reportes.RecursoParametros.Proceso);

                        ReportDataSource RD56 = new ReportDataSource();
                        RD56.Value = dtv56;
                        RD56.Name = "DataSet11Generalperfil";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv56M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav56M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav56M.FillByMetaIndicador(dtv56M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de perfil sociodemográfico");
                                  
                        ReportDataSource RD56M = new ReportDataSource();
                        RD56M.Value = dtv56M;
                        RD56M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD46);
                        ReportViewer1.LocalReport.DataSources.Add(RD47);
                        ReportViewer1.LocalReport.DataSources.Add(RD48);
                        ReportViewer1.LocalReport.DataSources.Add(RD49);
                        ReportViewer1.LocalReport.DataSources.Add(RD50);
                        ReportViewer1.LocalReport.DataSources.Add(RD51);
                        ReportViewer1.LocalReport.DataSources.Add(RD52);
                        ReportViewer1.LocalReport.DataSources.Add(RD53);
                        ReportViewer1.LocalReport.DataSources.Add(RD54);
                        ReportViewer1.LocalReport.DataSources.Add(RD55);
                        ReportViewer1.LocalReport.DataSources.Add(RD56);
                        ReportViewer1.LocalReport.DataSources.Add(RD56M);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] parametersPerfilSocio = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        parametersPerfilSocio[0] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);
                        parametersPerfilSocio[1] = new ReportParameter("procesoTexto", SG_SST.Reportes.RecursoParametros.ProcesoTexto);

                        ReportViewer1.LocalReport.SetParameters(parametersPerfilSocio);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();

                        break;
                   
                  
                        //si
                    case "ComunicacionesIndPersonas":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable dtv73 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter dav73 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter();

                        dav73.FillByPK_Id_Comunicado_personas(dtv73, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        ReportDataSource RD73 = new ReportDataSource();
                        RD73.Value = dtv73;
                        RD73.Name = "PK_Id_Comunicado_personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntInternosPersonasDataTable dtv74 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntInternosPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntInternosPersonasTableAdapter  dav74 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntInternosPersonasTableAdapter();

                        dav74.FillByInternosPersonas(dtv74, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Documento);
                        
                        ReportDataSource RD74 = new ReportDataSource();
                        RD74.Value = dtv74;
                        RD74.Name = "Internos_personas";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv74M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav74M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav74M.FillByMetaIndicador(dtv74M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de comunicaciones internas");
                                  
                        ReportDataSource RD74M = new ReportDataSource();
                        RD74M.Value = dtv74M;
                        RD74M.Name = "DataSetMetaIndicador";
                        
                     
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD73);
                        ReportViewer1.LocalReport.DataSources.Add(RD74);
                        ReportViewer1.LocalReport.DataSources.Add(RD74M);
                    

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] comunicacionesIndPersonas = new ReportParameter[3];
                        //Establecemos el valor de los parámetros
                        comunicacionesIndPersonas[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        comunicacionesIndPersonas[1] = new ReportParameter("tipo", SG_SST.Reportes.RecursoParametros.TipoComTexto.ToString());
                        comunicacionesIndPersonas[2] = new ReportParameter("Documento", SG_SST.Reportes.RecursoParametros.Documento.ToString());


                        ReportViewer1.LocalReport.SetParameters(comunicacionesIndPersonas);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                        //si
                    case "ComunicacionesIndCargo":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable dtv75 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter dav75 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter();

                        dav75.FillByPK_Id_Comunicado_personas(dtv75, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        ReportDataSource RD75 = new ReportDataSource();
                        RD75.Value = dtv75;
                        RD75.Name = "PK_Id_Comunicado_personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIndInternosCargosDataTable dtv76 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIndInternosCargosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIndInternosCargosTableAdapter dav76 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIndInternosCargosTableAdapter();

                        dav76.FillByIntCargos(dtv76, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);

                        ReportDataSource RD76 = new ReportDataSource();
                        RD76.Value = dtv76;
                        RD76.Name = "Internos_cargos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv76M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav76M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav76M.FillByMetaIndicador(dtv76M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de comunicaciones internas");
                                  
                        ReportDataSource RD76M = new ReportDataSource();
                        RD76M.Value = dtv76M;
                        RD76M.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD75);
                        ReportViewer1.LocalReport.DataSources.Add(RD76);
                        ReportViewer1.LocalReport.DataSources.Add(RD76M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] comunicacionesIndCargos = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        comunicacionesIndCargos[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        comunicacionesIndCargos[1] = new ReportParameter("tipo", SG_SST.Reportes.RecursoParametros.TipoComTexto.ToString());


                        ReportViewer1.LocalReport.SetParameters(comunicacionesIndCargos);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                        //si
                    case "ComunicacionesIndGrupo":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable dtv77 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter dav77 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter();

                        dav77.FillByPK_Id_Comunicado_personas(dtv77, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        ReportDataSource RD77 = new ReportDataSource();
                        RD77.Value = dtv77;
                        RD77.Name = "PK_Id_Comunicado_personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIndInternosGruposDataTable dtv78 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIndInternosGruposDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIndInternosGruposTableAdapter dav78 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIndInternosGruposTableAdapter();

                        dav78.FillByInternos_grupos(dtv78, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.GrupoTexto);

                        ReportDataSource RD78 = new ReportDataSource();
                        RD78.Value = dtv78;
                        RD78.Name = "Internos_grupos";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv78M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav78M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav78M.FillByMetaIndicador(dtv78M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de comunicaciones internas");
                                  
                        ReportDataSource RD78M = new ReportDataSource();
                        RD78M.Value = dtv78M;
                        RD78M.Name = "DataSetMetaIndicador";                        
                        

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD77);
                        ReportViewer1.LocalReport.DataSources.Add(RD78);
                        ReportViewer1.LocalReport.DataSources.Add(RD78M);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] comunicacionesIndGrupos= new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        comunicacionesIndGrupos[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        comunicacionesIndGrupos[1] = new ReportParameter("tipo", SG_SST.Reportes.RecursoParametros.TipoComTexto.ToString());


                        ReportViewer1.LocalReport.SetParameters(comunicacionesIndGrupos);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                        //si
                    case "ComunicacionesIndPersonasAPP":

                            ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable dtv73APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter dav73APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter();

                        dav73APP.FillByPK_Id_Comunicado_personas(dtv73APP, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        ReportDataSource RD73APP = new ReportDataSource();
                        RD73APP.Value = dtv73APP;
                        RD73APP.Name = "PK_Id_Comunicado_personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesAPPPersonasDataTable dtv74APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesAPPPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesPersonasAPPTableAdapter dav74APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesPersonasAPPTableAdapter();

                        dav74APP.FillByPersonas(dtv74APP, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.Documento);

                        ReportDataSource RD74APP = new ReportDataSource();
                        RD74APP.Value = dtv74APP;
                        RD74APP.Name = "app_personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv74APPM = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav74APPM = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav74APPM.FillByMetaIndicador(dtv74APPM, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de comunicaciones APP");
                                  
                        ReportDataSource RD74APPM = new ReportDataSource();
                        RD74APPM.Value = dtv74APPM;
                        RD74APPM.Name = "DataSetMetaIndicador";
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD73APP);
                        ReportViewer1.LocalReport.DataSources.Add(RD74APP);
                        ReportViewer1.LocalReport.DataSources.Add(RD74APPM);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] comunicacionesIndPersonasAPP = new ReportParameter[3];
                        //Establecemos el valor de los parámetros
                        comunicacionesIndPersonasAPP[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        comunicacionesIndPersonasAPP[1] = new ReportParameter("tipo", SG_SST.Reportes.RecursoParametros.TipoComTexto.ToString());
                        comunicacionesIndPersonasAPP[2] = new ReportParameter("Documento", SG_SST.Reportes.RecursoParametros.Documento.ToString());


                        ReportViewer1.LocalReport.SetParameters(comunicacionesIndPersonasAPP);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                        //si
                    case "ComunicacionesIndCargoAPP":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable dtv75APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesIntPKComunicadoPersonasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter dav75APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesIntPKComunicadoPersonasTableAdapter();

                        dav75APP.FillByPK_Id_Comunicado_personas(dtv75APP, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        ReportDataSource RD75APP = new ReportDataSource();
                        RD75APP.Value = dtv75APP;
                        RD75APP.Name = "PK_Id_Comunicado_personas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesAPPCargoDataTable dtv76APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.ComunicacionesAPPCargoDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesAPPCargoTableAdapter dav76APP = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.ComunicacionesAPPCargoTableAdapter();

                        dav76APP.FillByInternosCargos(dtv76APP, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.CargoTexto);

                        ReportDataSource RD76APP = new ReportDataSource();
                        RD76APP.Value = dtv76APP;
                        RD76APP.Name = "Internos_cargos";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv76APPM = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav76APPM = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav76APPM.FillByMetaIndicador(dtv76APPM, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de comunicaciones APP");
                                  
                        ReportDataSource RD76APPM = new ReportDataSource();
                        RD76APPM.Value = dtv76APPM;
                        RD76APPM.Name = "DataSetMetaIndicador";
                        

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD75APP);
                        ReportViewer1.LocalReport.DataSources.Add(RD76APP);
                        ReportViewer1.LocalReport.DataSources.Add(RD76APPM);


                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportParameter[] comunicacionesIndCargosAPP = new ReportParameter[2];
                        //Establecemos el valor de los parámetros
                        comunicacionesIndCargosAPP[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        comunicacionesIndCargosAPP[1] = new ReportParameter("tipo", SG_SST.Reportes.RecursoParametros.TipoComTexto.ToString());


                        ReportViewer1.LocalReport.SetParameters(comunicacionesIndCargosAPP);
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