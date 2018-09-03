<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDeReportesIndRes.aspx.cs" Inherits="SG_SST.Views.ReportesAplicacion.VisorDeReportesInd" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
           MostrarReporteIndPro();
        }
        protected void MostrarReporteIndPro()
        {
            if (!IsPostBack)
            {

                switch (SG_SST.Reportes.RecursoParametros.Reporte)
                {
                       //si
                    case "AccionCorrectivaPreventiva":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                         ReportViewer1.LocalReport.DataSources.Clear();    
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejActividadesDataTable dtv1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejActividadesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejActividadesTableAdapter dav1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejActividadesTableAdapter();

                       
                        dav1.FillByCerradas1(dtv1, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);

                        ReportDataSource RD = new ReportDataSource();
                        RD.Value = dtv1;
                        RD.Name = "DataSetCerradas1";
                        
                     
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejActividadesDataTable dtv2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejActividadesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejActividadesTableAdapter dav2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejActividadesTableAdapter();

                        dav2.FillByCerradas2(dtv2, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                
                        ReportDataSource RD2 = new ReportDataSource();
                        RD2.Value = dtv2;
                        RD2.Name = "DataSetCerradas2";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejTotalDataTable dtv3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejTotalTableAdapter dav3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejTotalTableAdapter();

                        dav3.FillByTotal1(dtv3, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                
                        
                        ReportDataSource RD3= new ReportDataSource();
                        RD3.Value = dtv3;
                        RD3.Name = "DataSetTotal1";

                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejTotalDataTable dtv4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndAccionesCorrPrevMejTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejTotalTableAdapter dav4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndAccionesCorrPrevMejTotalTableAdapter();



                        dav4.FillByTotal2(dtv4, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
             
                        ReportDataSource RD4 = new ReportDataSource();
                        RD4.Value = dtv4;
                        RD4.Name = "DataSetTotal2";
                        
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv4M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav4M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav4M.FillByMetaIndicador(dtv4M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de gestión de la mejora continua en el SG de SST");
                                  
                        ReportDataSource RD4M = new ReportDataSource();
                        RD4M.Value = dtv4M;
                        RD4M.Name = "DataSetMetaIndicador";                    

                       

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD);
                        ReportViewer1.LocalReport.DataSources.Add(RD2);
                        ReportViewer1.LocalReport.DataSources.Add(RD3);
                        ReportViewer1.LocalReport.DataSources.Add(RD4);
                        ReportViewer1.LocalReport.DataSources.Add(RD4M);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        
                        
                             ReportParameter[] parameters4 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                      
                        parameters4[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());



                        ReportViewer1.LocalReport.SetParameters(parameters4);
                        
                        
                        ReportViewer1.LocalReport.Refresh();

                        break;

                        //si
                    case "CondicionInsegura":
                        
                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTable1DataTable dtv5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTable1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTable1TableAdapter dav5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTable1TableAdapter();

                       
                        dav5.FillByCerradas1(dtv5,SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD5 = new ReportDataSource();
                        RD5.Value = dtv5;
                        RD5.Name = "DataSetCerradas1";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTable1DataTable dtv6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTable1DataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTable1TableAdapter dav6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTable1TableAdapter();

                        dav6.FillByCerradas2(dtv6, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);
                
                        ReportDataSource RD6 = new ReportDataSource();
                        RD6.Value = dtv6;
                        RD6.Name = "DataSetCerradas2";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndConInsegurasTotalSemetreDataTable dtv7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();

                        dav7.FillByTotal1(dtv7, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
                
                        
                        ReportDataSource RD7= new ReportDataSource();
                        RD7.Value = dtv7;
                        RD7.Name = "DataSetTotal1";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndConInsegurasTotalSemetreDataTable dtv8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndConInsegurasTotalSemetreDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter dav8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndConInsegurasTotalSemetreTableAdapter();



                        dav8.FillByTotal2(dtv8, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);
             
                        ReportDataSource RD8 = new ReportDataSource();
                        RD8.Value = dtv8;
                        RD8.Name = "DataSetTotal2";
                      
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv8M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav8M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav8M.FillByMetaIndicador(dtv8M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de gestión sobre las condiciones y actos inseguros");
                                  
                        ReportDataSource RD8M = new ReportDataSource();
                        RD8M.Value = dtv8M;
                        RD8M.Name = "DataSetMetaIndicador"; 
                        
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD5);
                        ReportViewer1.LocalReport.DataSources.Add(RD6);
                        ReportViewer1.LocalReport.DataSources.Add(RD7);
                        ReportViewer1.LocalReport.DataSources.Add(RD8);
                        ReportViewer1.LocalReport.DataSources.Add(RD8M);
                        
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                       
                        ReportParameter[] parameters5 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                      
                        parameters5[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());



                        ReportViewer1.LocalReport.SetParameters(parameters5);
                        
                        
                     
                        
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();


                        break;

                        //si
                    case "PlanTrabajoAnual":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTableTotalPlanAnualDataTable dtv9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTableTotalPlanAnualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTableTotalPlanAnualTableAdapter dav9 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTableTotalPlanAnualTableAdapter();

                        //Sede
                        dav9.FillByTotal(dtv9, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.SedeInd, SG_SST.Reportes.RecursoParametros.Anio);
                      
                        
                        ReportDataSource RD9 = new ReportDataSource();
                        RD9.Value = dtv9;
                        RD9.Name = "DataSetTotal";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTableMensualPlanAnualDataTable dtv10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTableMensualPlanAnualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTableMensualPlanAnualTableAdapter dav10 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTableMensualPlanAnualTableAdapter();

                        dav10.FillByMensual(dtv10, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeInd);
                        
                        ReportDataSource RD10 = new ReportDataSource();
                        RD10.Value = dtv10;
                        RD10.Name = "DataSetMensual";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTableEjecutadasPlanAnualDataTable dtv11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.DataTableEjecutadasPlanAnualDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTableEjecutadasPlanAnualTableAdapter dav11 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.DataTableEjecutadasPlanAnualTableAdapter();

                        dav11.FillByEjecutadas(dtv11, SG_SST.Reportes.RecursoParametros.Anio, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.SedeInd);
                        

                        ReportDataSource RD11 = new ReportDataSource();
                        RD11.Value = dtv11;
                        RD11.Name = "DataSetEjecutadas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable dtv11M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.MetaIndicadorDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter dav11M = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.MetaIndicadorTableAdapter();

                        dav11M.FillByMetaIndicador(dtv11M, SG_SST.Reportes.RecursoParametros.NitEmpresa, "Indicador de ejecución del plan de trabajo anual en SST");
                                  
                        ReportDataSource RD11M = new ReportDataSource();
                        RD11M.Value = dtv11M;
                        RD11M.Name = "DataSetMetaIndicador";

                 

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD9);
                        ReportViewer1.LocalReport.DataSources.Add(RD10);
                        ReportViewer1.LocalReport.DataSources.Add(RD11);
                        ReportViewer1.LocalReport.DataSources.Add(RD11M);
                   
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportParameter[] parameters8 = new ReportParameter[2];
                        //Establecemos el valor de los parámetros

                      
                        parameters8[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                        parameters8[1] = new ReportParameter("sedeTexto", SG_SST.Reportes.RecursoParametros.SedeTexto);



                        ReportViewer1.LocalReport.SetParameters(parameters8);
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();


                        break;
                        //si
                        
                    case "EstandaresMinimos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndEvalEstandaresMinimosDataTable dtv12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndEvalEstandaresMinimosDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndEvalEstandaresMinimosTableAdapter dav12 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndEvalEstandaresMinimosTableAdapter();

                       
                        dav12.FillByEvaluaciones(dtv12, SG_SST.Reportes.RecursoParametros.Anio,SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        
                         ReportDataSource RD12 = new ReportDataSource();
                        RD12.Value = dtv12;
                        RD12.Name = "DataSetEvaluaciones";
                        
                        
                        //SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndEvalEstandaresMinimosDataTable dtv12b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.V_IndEvalEstandaresMinimosDataTable();
                        //SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndEvalEstandaresMinimosTableAdapter dav12b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.V_IndEvalEstandaresMinimosTableAdapter();
                        //dav12b.FillByCiclos(dtv12b, SG_SST.Reportes.RecursoParametros.NitEmpresa,SG_SST.Reportes.RecursoParametros.Anio);
        
                        // ReportDataSource RD12b = new ReportDataSource();
                        //RD12b.Value = dtv12b;
                        //RD12b.Name = "DataSetCiclos";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialCumpleDataTable dtv35= new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialCumpleDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialCumpleTableAdapter dav35 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialCumpleTableAdapter();

                        dav35.FillByCumple(dtv35, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        
                        ReportDataSource RD35 = new ReportDataSource();
                        
                        RD35.Value = dtv35;
                        RD35.Name = "DataSetCumple";


                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialNoCumpleDataTable dtv36 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialNoCumpleDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialNoCumpleTableAdapter dav36 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialNoCumpleTableAdapter();

                        dav36.FillByNoCumple(dtv36, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        
                        ReportDataSource RD36 = new ReportDataSource();
                        
                        RD36.Value = dtv36;
                        RD36.Name = "DataSetNoCumple";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialParcialDataTable dtv37 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialParcialDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialParcialTableAdapter dav37 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialParcialTableAdapter();

                        dav37.FillByParcial(dtv37, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        
                        ReportDataSource RD37 = new ReportDataSource();
                        
                        RD37.Value = dtv37;
                        RD37.Name = "DataSetParcialmente";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialTotalDataTable dtv38 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialTotalDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialTotalTableAdapter dav38 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialTotalTableAdapter();

                        dav38.FillByTotal(dtv38, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        
                        ReportDataSource RD38 = new ReportDataSource();
                        
                        RD38.Value = dtv38;
                        RD38.Name = "DataSetTotal";
                       
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialPreguntasDataTable dtv39 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetInd.IndEvaluacionInicialPreguntasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialPreguntasTableAdapter dav39 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetIndTableAdapters.IndEvaluacionInicialPreguntasTableAdapter();

                        dav39.FillByPreguntas(dtv39, SG_SST.Reportes.RecursoParametros.NitEmpresa);
                        
                        ReportDataSource RD39 = new ReportDataSource();
                        
                        RD39.Value = dtv39;
                        RD39.Name = "DataSetPreguntas";
                  
                        
                        ReportViewer1.LocalReport.DataSources.Clear();
                     
                        //ReportViewer1.LocalReport.DataSources.Add(RD12b);
                        ReportViewer1.LocalReport.DataSources.Add(RD12);
                        ReportViewer1.LocalReport.DataSources.Add(RD35);
                        ReportViewer1.LocalReport.DataSources.Add(RD36);
                        ReportViewer1.LocalReport.DataSources.Add(RD37);
                        ReportViewer1.LocalReport.DataSources.Add(RD38);
                        ReportViewer1.LocalReport.DataSources.Add(RD39);
              
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Indicadores/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        
                        ReportParameter[] parameters6 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                      
                        parameters6[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());



                        ReportViewer1.LocalReport.SetParameters(parameters6);
                        
                        
                        
                        
                        ReportViewer1.Visible = true;
                        ReportViewer1.LocalReport.Refresh();
                        break;

                       default:

                        SG_SST.Reportes.RecursoParametros.Anio = 0;
                        SG_SST.Reportes.RecursoParametros.NitEmpresa = "";
                        SG_SST.Reportes.RecursoParametros.Reporte = "";
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