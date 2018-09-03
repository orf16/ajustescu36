<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDeReportesComunicaciones.aspx.cs" Inherits="SG_SST.Views.ReportesAplicacion.VisorDeReportesComunicaciones" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <script runat="server">
        void Page_Load(object sender, EventArgs e)
        {
           MostrarEstadisticasComunic();
        }
        protected void MostrarEstadisticasComunic()
        {
            if (!IsPostBack)
            {

                switch (SG_SST.Reportes.RecursoParametros.Reporte)
                {

                    case "TabulacionEncuestas":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstTabulacionEncuestaDataTable dtv1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstTabulacionEncuestaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstTabulacionEncuestaTableAdapter dav1 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstTabulacionEncuestaTableAdapter();

                       
                        dav1.FillByConsolidado(dtv1, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Encuesta);
                       
                        ReportDataSource RD = new ReportDataSource();
                        RD.Value = dtv1;
                        RD.Name = "DataSetConsolidado";
                        
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstTabulacionEncuestaDataTable dtv2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstTabulacionEncuestaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstTabulacionEncuestaTableAdapter dav2 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstTabulacionEncuestaTableAdapter();

                       
                        dav2.FillByRespuesta(dtv2, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Encuesta);
                       
                        ReportDataSource RD2 = new ReportDataSource();
                        RD2.Value = dtv2;
                        RD2.Name = "DataSetRespuestas";
                     
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstTabulacionEncuestaDataTable dtv3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstTabulacionEncuestaDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstTabulacionEncuestaTableAdapter dav3 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstTabulacionEncuestaTableAdapter();

                       
                        dav3.FillByTotal(dtv3, SG_SST.Reportes.RecursoParametros.Encuesta);
                      
                        ReportDataSource RD3 = new ReportDataSource();
                        RD3.Value = dtv3;
                        RD3.Name = "DataSetTotal";
                     
                       

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD);
                        ReportViewer1.LocalReport.DataSources.Add(RD2);
                        ReportViewer1.LocalReport.DataSources.Add(RD3);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Comunicaciones/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                        ReportViewer1.Visible = true;
                        
                        
                         
                        
                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "Comunicaciones":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable dtv4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter dav4 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter();


                        dav4.FillByConsolidado(dtv4, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD4 = new ReportDataSource();
                        RD4.Value = dtv4;
                        RD4.Name = "DataSetConsolidado";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable dtv4a = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter dav4a = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter();


                        dav4a.FillByComunicacionesInternas(dtv4a, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD4a = new ReportDataSource();
                        RD4a.Value = dtv4a;
                        RD4a.Name = "DataSetComunicacionesInternas";

                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable dtv4b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter dav4b = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter();


                        dav4b.FillByComunicacionesAPP(dtv4b, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD4b = new ReportDataSource();
                        RD4b.Value = dtv4b;
                        RD4b.Name = "DataSetComunicacionesAPP";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD4);
                        ReportViewer1.LocalReport.DataSources.Add(RD4a);
                        ReportViewer1.LocalReport.DataSources.Add(RD4b);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Comunicaciones/" + SG_SST.Reportes.RecursoParametros.NombreReporte);
                       
                          ReportParameter[] parameters1 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros

                      
                        parameters1[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());
                       

                        ReportViewer1.LocalReport.SetParameters(parameters1);
                        ReportViewer1.Visible = true;




                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "Encuestas":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;
                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EncuestasComunicacionesDataTable dtv5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EncuestasComunicacionesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EncuestasComunicacionesTableAdapter dav5 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EncuestasComunicacionesTableAdapter();


                        dav5.FillByConsolidado(dtv5, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD5 = new ReportDataSource();
                        RD5.Value = dtv5;
                        RD5.Name = "DataSetConsolidado";





                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD5);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Comunicaciones/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportParameter[] parameters2 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros


                        parameters2[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());


                        ReportViewer1.LocalReport.SetParameters(parameters2);
                        ReportViewer1.Visible = true;




                        ReportViewer1.LocalReport.Refresh();

                        break;


                    case "TabulacionEncuestasDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;

                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.Tbl_ComunicacionesEncuestasDataTable dtv6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.Tbl_ComunicacionesEncuestasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.Tbl_ComunicacionesEncuestasTableAdapter dav6 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.Tbl_ComunicacionesEncuestasTableAdapter();


                        dav6.FillByEncuestasDatos(dtv6, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Encuesta);
                  
                        ReportDataSource RD6 = new ReportDataSource();
                        RD6.Value = dtv6;
                        RD6.Name = "DataSetRespuestas";





                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD6);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Comunicaciones/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportParameter[] parameters3 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros


                       parameters3[0] = new ReportParameter("encuestaTexto", SG_SST.Reportes.RecursoParametros.EncuestaTexto);


                        ReportViewer1.LocalReport.SetParameters(parameters3);
                        ReportViewer1.Visible = true;




                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "ComunicacionesDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;

                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable dtv7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EstComunicacionesInternasDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter dav7 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EstComunicacionesInternasTableAdapter();


                        dav7.FillByConsolidado(dtv7, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD7 = new ReportDataSource();
                        RD7.Value = dtv7;
                        RD7.Name = "DataSetConsolidado";

                     

                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD7);
                     
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Comunicaciones/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportParameter[] parameters4 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros


                        parameters4[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());


                        ReportViewer1.LocalReport.SetParameters(parameters4);
                        ReportViewer1.Visible = true;




                        ReportViewer1.LocalReport.Refresh();

                        break;

                    case "EncuestasDatos":

                        ReportViewer1.Reset();
                        ReportViewer1.Visible = false;

                        ReportViewer1.LocalReport.DataSources.Clear();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EncuestasComunicacionesDataTable dtv8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSet.V_EncuestasComunicacionesDataTable();
                        SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EncuestasComunicacionesTableAdapter dav8 = new SG_SST.Views.ReportesAplicacion.SGSSTDataSetTableAdapters.V_EncuestasComunicacionesTableAdapter();


                        dav8.FillByConsolidado(dtv8, SG_SST.Reportes.RecursoParametros.NitEmpresa, SG_SST.Reportes.RecursoParametros.Anio);

                        ReportDataSource RD8 = new ReportDataSource();
                        RD8.Value = dtv8;
                        RD8.Name = "DataSetConsolidado";


                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(RD8);

                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Content/ReportesFisicos/Comunicaciones/" + SG_SST.Reportes.RecursoParametros.NombreReporte);

                        ReportParameter[] parameters5 = new ReportParameter[1];
                        //Establecemos el valor de los parámetros


                        parameters5[0] = new ReportParameter("anio", SG_SST.Reportes.RecursoParametros.Anio.ToString());


                        ReportViewer1.LocalReport.SetParameters(parameters5);
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
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="1200px" Width="100%" Enabled="true"
                BackColor="White" BorderColor="black" Font-Bold="true" InternalBorderStyle="None" ShowParameterPrompts="true"   
                AsyncRendering="false" ShowBackButton="False" ShowFindControls="False" ShowPrintButton="False" ShowRefreshButton="False" ShowZoomControl="False" ShowPageNavigationControls="False" >
            </rsweb:ReportViewer>    

        </div>
    </form>
</body>
</html>
