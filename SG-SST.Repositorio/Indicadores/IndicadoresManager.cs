using SG_SST.Audotoria;
using SG_SST.Interfaces.Indicadores;
using SG_SST.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Repositorio.Indicadores
{
    public class IndicadoresManager : IIndicadores
    {
        public List<decimal> ObtenerResultadoEstandaresMinimos(string nitEmpresa)
        {
            List<decimal> resultados = new List<decimal>();
            using (SG_SSTContext contexto = new SG_SSTContext())
            {
                RegistraLog registra = new RegistraLog();

                try
                {

       

                    string sql = "SELECT SUM(valor_calificacion) as Valor_Calificacion "
                                + "FROM V_IndEvalEstandaresMinimos "
                                + "WHERE (Vigencia = @anio) AND (Nit_Empresa = @nit_empresa) AND (Estado=3) ";

                    resultados = contexto.Database.SqlQuery<decimal>(sql,
                                new SqlParameter("@anio", DateTime.Today.Year), 
                                new SqlParameter("@nit_empresa", nitEmpresa)).ToList();                     
                }
                catch (Exception ex)
                {
                    registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                    return null;
                }
            }

            return resultados;
        }

        public decimal? ObtenerResultadoFrecuenciaAusentismo(string nitEmpresa)
        {
            decimal? totalDTM = 0;
            int? totalDiasAus = 0;
            decimal? resultado = 0;
            using (SG_SSTContext contexto = new SG_SSTContext())
            {
                RegistraLog registra = new RegistraLog();

                try
                {
                    string sqlDTM = "SELECT SUM(Dias_Trabajados_DTM) AS Total_DTM "
                                + "FROM Tbl_ConfiguracionesHHT "
                                + "WHERE (Documento_empresa = @nit_empresa) AND (Ano = @anio) ";

                    totalDTM = contexto.Database.SqlQuery<decimal?>(sqlDTM,
                                new SqlParameter("@nit_empresa", nitEmpresa),
                                new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();
                    if(totalDTM != null && totalDTM.Value > 0)
                    {
                        string sqlDiasAus = "SELECT SUM(Total) AS TotalDiasAus "
                                        + "FROM (SELECT CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 1 THEN COUNT(*) ELSE '0' END AS Enero, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 2 THEN COUNT(*) ELSE '0' END AS Febrero, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 3 THEN COUNT(*) ELSE '0' END AS Marzo, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 4 THEN COUNT(*) ELSE '0' END AS Abril, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 5 THEN COUNT(*) ELSE '0' END AS Mayo, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 6 THEN COUNT(*) ELSE '0' END AS Junio, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 7 THEN COUNT(*) ELSE '0' END AS Julio, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 8 THEN COUNT(*) ELSE '0' END AS Agosto, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 9 THEN COUNT(*) ELSE '0' END AS Septiembre, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 10 THEN COUNT(*) ELSE '0' END AS Octubre, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 11 THEN COUNT(*) ELSE '0' END AS Noviembre, "
                                        + "CASE WHEN MONTH(DATEADD(DAY, number, CONVERT(DATE, a.FechaInicio, 103))) = 12 THEN COUNT(*) ELSE '0' END AS Diciembre, COUNT(*) AS Total "
                                        + "FROM master.dbo.spt_values INNER JOIN Tbl_Ausencias AS a INNER JOIN Tbl_Contingencias AS c "
                                        + "ON a.FK_Id_Contingencia = c.PK_Id_Contingencia ON DATEADD(DAY, master.dbo.spt_values.number, a.FechaInicio) <= a.Fecha_Fin "
                                        + "AND YEAR(DATEADD(DAY, master.dbo.spt_values.number, a.FechaInicio)) = YEAR(a.FechaInicio) "
                                        + "WHERE (master.dbo.spt_values.type = 'P') AND (c.PK_Id_Contingencia IN (1, 2, 3, 4,13,14)) AND (a.NitEmpresa = @nit_empresa) AND (DATEPART(YEAR, a.FechaInicio) = @anio) "
                                        + "GROUP BY DATEPART(MONTH, DATEADD(DAY, master.dbo.spt_values.number, CONVERT(DATE, a.FechaInicio, 103)))) AS vista ";

                        totalDiasAus = contexto.Database.SqlQuery<int?>(sqlDiasAus,
                                    new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                        if (totalDiasAus != null)
                        {
                            resultado = (totalDiasAus / totalDTM) * 100;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                    return null;
                }
            }

            return resultado;
        }

        public decimal? ObtenerResultadoCumplimientoRequisitosLegales(string nitEmpresa)
        {
            int? totalReq = 0;
            int? totalReqCumplidos = 0;
            decimal valorMaximo = 100;
            int? totalReqCumplidosPar = 0;
            decimal? resultado = 0;
            decimal? valorCal;
            using (SG_SSTContext contexto = new SG_SSTContext())
            {
                RegistraLog registra = new RegistraLog();

                try
                {                    
                    string sqlTotalReq = "SELECT     COUNT(*) AS total_requisitos "
                                + "FROM dbo.Tbl_Requisitos_legales_Otros INNER JOIN "
                                + "dbo.Tbl_Estado_RequisitoslegalesOtros ON dbo.Tbl_Requisitos_legales_Otros.FK_Estado_RequisitoslegalesOtros = dbo.Tbl_Estado_RequisitoslegalesOtros.PK_Estado_RequisitoslegalesOtros INNER JOIN "
                                + "dbo.Tbl_Actividad_Economica ON dbo.Tbl_Requisitos_legales_Otros.FK_Actividad_Economica = dbo.Tbl_Actividad_Economica.PK_Actividad_Economica INNER JOIN "
                                + "dbo.Tbl_Cumplimiento_Evaluacion ON dbo.Tbl_Requisitos_legales_Otros.FK_Cumplimiento_Evaluacion = dbo.Tbl_Cumplimiento_Evaluacion.PK_Cumplimiento_Evaluacion INNER JOIN "
                                + "dbo.Tbl_Requisitos_Matriz ON dbo.Tbl_Requisitos_legales_Otros.PK_RequisitosLegalesOtros = dbo.Tbl_Requisitos_Matriz.FK_RequisitosLegalesOtros INNER JOIN "
                                + "dbo.Tbl_Matriz_RequisitosLegales ON dbo.Tbl_Requisitos_Matriz.FK_MatrizRequisitosLegales = dbo.Tbl_Matriz_RequisitosLegales.PK_MatrizRequisitosLegales INNER JOIN "
                                + "dbo.Tbl_Empresa ON dbo.Tbl_Matriz_RequisitosLegales.FK_Empresa = dbo.Tbl_Empresa.Pk_Id_Empresa "
                                + "WHERE Nit_Empresa = @nit_empresa and year(Fecha_Seguimiento_Control) = @anio ";

                    totalReq = contexto.Database.SqlQuery<int?>(sqlTotalReq,
                                new SqlParameter("@nit_empresa", nitEmpresa),
                                new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault(); 
                    if (totalReq != null && totalReq.Value > 0)
                    {

                        valorCal = valorMaximo / totalReq;
                        string sqlTotalReqCumplidos = "SELECT COUNT(*) AS requisitos_cumplidos "
                                        + "FROM Tbl_Requisitos_legales_Otros INNER JOIN "
                                        + "Tbl_Estado_RequisitoslegalesOtros ON Tbl_Requisitos_legales_Otros.FK_Estado_RequisitoslegalesOtros = Tbl_Estado_RequisitoslegalesOtros.PK_Estado_RequisitoslegalesOtros INNER JOIN "
                                        + "Tbl_Actividad_Economica ON Tbl_Requisitos_legales_Otros.FK_Actividad_Economica = Tbl_Actividad_Economica.PK_Actividad_Economica INNER JOIN "
                                        + "Tbl_Cumplimiento_Evaluacion ON Tbl_Requisitos_legales_Otros.FK_Cumplimiento_Evaluacion = Tbl_Cumplimiento_Evaluacion.PK_Cumplimiento_Evaluacion INNER JOIN "
                                        + "Tbl_Requisitos_Matriz ON Tbl_Requisitos_legales_Otros.PK_RequisitosLegalesOtros = Tbl_Requisitos_Matriz.FK_RequisitosLegalesOtros INNER JOIN "
                                        + "Tbl_Matriz_RequisitosLegales ON Tbl_Requisitos_Matriz.FK_MatrizRequisitosLegales = Tbl_Matriz_RequisitosLegales.PK_MatrizRequisitosLegales INNER JOIN "
                                        + "Tbl_Empresa ON Tbl_Matriz_RequisitosLegales.FK_Empresa = Tbl_Empresa.Pk_Id_Empresa "
                                        + "WHERE (Tbl_Requisitos_legales_Otros.FK_Cumplimiento_Evaluacion = 1) AND (Tbl_Empresa.Nit_Empresa = @nit_empresa) AND (YEAR(Tbl_Requisitos_legales_Otros.Fecha_Seguimiento_Control) = @anio) ";
                        totalReqCumplidos = contexto.Database.SqlQuery<int?>(sqlTotalReqCumplidos,
                                    new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();


                        string sqlTotalReqCumplidosPar = "SELECT COUNT(*) AS requisitos_cumplidos "
                                    + "FROM Tbl_Requisitos_legales_Otros INNER JOIN "
                                    + "Tbl_Estado_RequisitoslegalesOtros ON Tbl_Requisitos_legales_Otros.FK_Estado_RequisitoslegalesOtros = Tbl_Estado_RequisitoslegalesOtros.PK_Estado_RequisitoslegalesOtros INNER JOIN "
                                    + "Tbl_Actividad_Economica ON Tbl_Requisitos_legales_Otros.FK_Actividad_Economica = Tbl_Actividad_Economica.PK_Actividad_Economica INNER JOIN "
                                    + "Tbl_Cumplimiento_Evaluacion ON Tbl_Requisitos_legales_Otros.FK_Cumplimiento_Evaluacion = Tbl_Cumplimiento_Evaluacion.PK_Cumplimiento_Evaluacion INNER JOIN "
                                    + "Tbl_Requisitos_Matriz ON Tbl_Requisitos_legales_Otros.PK_RequisitosLegalesOtros = Tbl_Requisitos_Matriz.FK_RequisitosLegalesOtros INNER JOIN "
                                    + "Tbl_Matriz_RequisitosLegales ON Tbl_Requisitos_Matriz.FK_MatrizRequisitosLegales = Tbl_Matriz_RequisitosLegales.PK_MatrizRequisitosLegales INNER JOIN "
                                    + "Tbl_Empresa ON Tbl_Matriz_RequisitosLegales.FK_Empresa = Tbl_Empresa.Pk_Id_Empresa "
                                    + "WHERE (Tbl_Requisitos_legales_Otros.FK_Cumplimiento_Evaluacion = 3) AND (Tbl_Empresa.Nit_Empresa = @nit_empresa) AND (YEAR(Tbl_Requisitos_legales_Otros.Fecha_Seguimiento_Control) = @anio) ";
                        totalReqCumplidosPar = contexto.Database.SqlQuery<int?>(sqlTotalReqCumplidosPar,
                                    new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                        resultado = totalReqCumplidos * valorCal + totalReqCumplidosPar * (valorCal / 2);

                        if (resultado== null)
                        {
                        
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                    return null;
                }
            }

            return resultado;
        }

        public decimal? ObtenerResultadoCapacitacionEntrenamiento(string nitEmpresa)
        {
            int? totalProg = 0;
            int? totalEjec = 0;
            decimal? resultado = 0;
            using (SG_SSTContext contexto = new SG_SSTContext())
            {
                RegistraLog registra = new RegistraLog();

                try
                {                   
                    string sqlTotalProg = "select sum(Programadas) Programadas "
                                + "from V_IndPlanCapacitacion "
                                + "where nitEmpresa = @nit_empresa and Anio = @anio ";

                    totalProg = contexto.Database.SqlQuery<int?>(sqlTotalProg,
                                new SqlParameter("@nit_empresa", nitEmpresa),
                                new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();
                    if (totalProg != null && totalProg.Value > 0)
                    {
                        string sqlTotalEjec = "select sum(Ejecutadas) Ejecutadas "
                                + "from V_IndPlanCapacitacion "
                                + "where nitEmpresa = @nit_empresa and Anio = @anio ";

                        totalEjec = contexto.Database.SqlQuery<int?>(sqlTotalEjec,
                                    new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                        if (totalEjec != null)
                        {
                            resultado = (Decimal.Parse(totalEjec.ToString()) / totalProg) * 100;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                    return null;
                }
            }

            return resultado;
        }



//...................//

        public decimal? ObtenerResultadoCondicionActoInseguro(string nitEmpresa)
        {
            int? totalReportesIISem = 0;
            int? totalReportesISem = 0;
            int? totalRepCerradosIISem = 0;
            int? totalRepCerradosISem = 0;
        
            decimal? resultado = 0;
          
            using (SG_SSTContext contexto = new SG_SSTContext())
            {
                RegistraLog registra = new RegistraLog();

                try
                {
                    int mes = DateTime.Today.Month;
                    if(mes > 6)
                    {
                        string sqlTotalRepIISem = "SELECT COUNT(Pk_Id_Reportes) AS Total "
                    + "FROM  V_IndConInsegurasTotalSemetre "
                    + "WHERE (Nit_Empresa = @nit_empresa) AND (ANIO = @anio) AND (MES BETWEEN 7 AND 12) "
                    + "GROUP BY Nit_Empresa, Razon_Social ";

                        totalReportesIISem = contexto.Database.SqlQuery<int?>(sqlTotalRepIISem,
                                   new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                        string sqlTotalRepCerradasIISem = "SELECT COUNT(*) AS Cerradas "
                                                          + "FROM (SELECT Pk_Id_Reportes,FK_NitEmpresa, COUNT(Pk_Id_Reportes) AS RecuentoFilas "
                                                          + "FROM            V_IndConInsegurasActividades "
                                                          + "WHERE        (Anio = @anio) AND (Mes BETWEEN 7 AND 12) "
                                                          + "GROUP BY Pk_Id_Reportes, FK_NitEmpresa  "
                                                          + "HAVING         (COUNT(*) >= 1)) AS TotalAct LEFT OUTER JOIN  "
                                                          + "(SELECT        Pk_Id_Reportes, ISNULL(COUNT(FechaCierre), 0) AS RecuentoCerradas "
                                                          + "FROM            V_IndConInsegurasActividades AS V_IndConInsegurasActividades_1 "
                                                          + "WHERE        (FechaCierre IS NOT NULL) AND (Anio = @anio) AND (Mes BETWEEN 7 AND 12) "
                                                          + "GROUP BY Pk_Id_Reportes "
                                                          + "HAVING (COUNT(*) >= 1)) AS Cerradas ON TotalAct.Pk_Id_Reportes = Cerradas.Pk_Id_Reportes "
                                                          + "WHERE        (TotalAct.RecuentoFilas = Cerradas.RecuentoCerradas) AND (TotalAct.FK_NitEmpresa = @nit_empresa) "
                                                          + "GROUP BY TotalAct.FK_NitEmpresa ";

                        totalRepCerradosIISem = contexto.Database.SqlQuery<int?>(sqlTotalRepCerradasIISem,
                                   new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                        if (totalReportesIISem != null)
                        {
 
                            resultado = (Decimal.Parse(totalRepCerradosIISem.ToString()) / totalReportesIISem) * 100;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        string sqlTotalRepISem = "SELECT COUNT(Pk_Id_Reportes) AS Total "
                                                   + "FROM  V_IndConInsegurasTotalSemetre "
                                                   + "WHERE (Nit_Empresa = @nit_empresa) AND (ANIO = @anio) AND (MES BETWEEN 1 AND 6) "
                                                   + "GROUP BY Nit_Empresa, Razon_Social ";

                        totalReportesISem = contexto.Database.SqlQuery<int?>(sqlTotalRepISem,
                                   new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                        string sqlTotalRepCerradasISem = "SELECT COUNT(*) AS Cerradas "
                                                          + "FROM (SELECT Pk_Id_Reportes,FK_NitEmpresa, COUNT(Pk_Id_Reportes) AS RecuentoFilas "
                                                          + "FROM            V_IndConInsegurasActividades "
                                                          + "WHERE        (Anio = @anio) AND (Mes BETWEEN 1 AND 6) "
                                                          + "GROUP BY Pk_Id_Reportes, FK_NitEmpresa  "
                                                          + "HAVING         (COUNT(*) >= 1)) AS TotalAct LEFT OUTER JOIN  "
                                                          + "(SELECT        Pk_Id_Reportes, ISNULL(COUNT(FechaCierre), 0) AS RecuentoCerradas "
                                                          + "FROM            V_IndConInsegurasActividades AS V_IndConInsegurasActividades_1 "
                                                          + "WHERE        (FechaCierre IS NOT NULL) AND (Anio = @anio) AND (Mes BETWEEN 1 AND 6) "
                                                          + "GROUP BY Pk_Id_Reportes "
                                                          + "HAVING (COUNT(*) >= 1)) AS Cerradas ON TotalAct.Pk_Id_Reportes = Cerradas.Pk_Id_Reportes "
                                                          + "WHERE        (TotalAct.RecuentoFilas = Cerradas.RecuentoCerradas) AND (TotalAct.FK_NitEmpresa = @nit_empresa) "
                                                          + "GROUP BY TotalAct.FK_NitEmpresa ";

                        totalRepCerradosISem = contexto.Database.SqlQuery<int?>(sqlTotalRepCerradasISem,
                                   new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();
                       
                        if (totalReportesISem != null)
                        {

                            resultado = (Decimal.Parse(totalRepCerradosISem.ToString()) / totalReportesISem) * 100;
                        }
                        else
                        {
                            return null;
                        }
                    }



                 
                }
                catch (Exception ex)
                {
                    registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                    return null;
                }
            }

            return resultado;
        }

   public int? ObtenerResultadoComiteCoppast(string nitEmpresa)
        {
            int? totalActasCoppast = 0;


            int? resultado = 0;
          
            using (SG_SSTContext contexto = new SG_SSTContext())
            {
                RegistraLog registra = new RegistraLog();

                try
                {
                          int nitxsede = (from e in contexto.Tbl_Empresa
                                     join sd in contexto.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                                        where sd.Empresa.Nit_Empresa == nitEmpresa
                                    select  sd.Pk_Id_Sede).FirstOrDefault();  
                    
                        string sqlTotalActas = "SELECT sum(Total) as totalActasCoppast "
                                                  + "FROM V_IndicadorCopastMensual  "
                                                  + " WHERE (Nit_Empresa = @nit_empresa) AND (anio = @anio) AND(Fk_Id_Sede=@idSede)  OR (Fk_Id_Sede=null) ";

                        totalActasCoppast = contexto.Database.SqlQuery<int?>(sqlTotalActas,
                                   new SqlParameter("@nit_empresa", nitEmpresa),
                                    new SqlParameter("@anio", DateTime.Today.Year),
                                    new SqlParameter("@idSede", nitxsede)).FirstOrDefault();



                        if (totalActasCoppast != null)
                        {

                            resultado = totalActasCoppast;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    
                catch (Exception ex)
                {
                    registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                    return null;
                }
            }

            return resultado;
        }


   public int? ObtenerResultadoComiteConvivenciaLaboral(string nitEmpresa)
   {
       int? totalActasConvivencia = 0;


       int? resultado = 0;

       using (SG_SSTContext contexto = new SG_SSTContext())
       {
           RegistraLog registra = new RegistraLog();

           try
           {
               int nitxsede = (from e in contexto.Tbl_Empresa
                               join sd in contexto.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                               where sd.Empresa.Nit_Empresa == nitEmpresa
                               select sd.Pk_Id_Sede).FirstOrDefault();

               string sqlTotalActas = "SELECT sum(Total) as totalActasConvivencia "
                                         + "FROM V_IndConvivenciaMensual  "
                                         + " WHERE (Nit_Empresa = @nit_empresa) AND (anio = @anio) AND(Fk_Id_Sede=@idSede)  OR (Fk_Id_Sede=null) ";

               totalActasConvivencia = contexto.Database.SqlQuery<int?>(sqlTotalActas,
                          new SqlParameter("@nit_empresa", nitEmpresa),
                           new SqlParameter("@anio", DateTime.Today.Year),
                           new SqlParameter("@idSede", nitxsede)).FirstOrDefault();



               if (totalActasConvivencia != null)
               {

                   resultado = totalActasConvivencia;
               }
               else
               {
                   return null;
               }
           }

           catch (Exception ex)
           {
               registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               return null;
           }
       }

       return resultado;
   }

   public decimal? ObtenerResultadoPlanTrabajoAnual(string nitEmpresa)
   {
       int? totalActividadesPlaneadas = 0;
       int? totalActividadesEjecutadas = 0;
       

       decimal? resultado = 0;

       using (SG_SSTContext contexto = new SG_SSTContext())
       {
           RegistraLog registra = new RegistraLog();

           try
           {

               int nitxsede = (from e in contexto.Tbl_Empresa
                               join sd in contexto.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                               where sd.Empresa.Nit_Empresa == nitEmpresa
                               select sd.Pk_Id_Sede).FirstOrDefault();


               string sqlTotalActividadesPlaneadas = "SELECT        COUNT(*) AS Total "
                                                  + "FROM            V_IndPlanTrabajoAnual "
                                                  + "WHERE       (Nit_Empresa = @nit_empresa) AND (IdSede = @idSede) AND (AnioProg = @anio) ";

               totalActividadesPlaneadas = contexto.Database.SqlQuery<int?>(sqlTotalActividadesPlaneadas,
                                           new SqlParameter("@nit_empresa", nitEmpresa),
                                              new SqlParameter("@anio", DateTime.Today.Year),
                                         new SqlParameter("@idSede", nitxsede)).FirstOrDefault();

               string sqlTotalActividadesEjecutadas = "SELECT COUNT(*) AS contador "
                                                      +" from V_IndPlanTrabajoAnual "
                                                      +"where AnioProg = @anio and AnioEje = @anio and Nit_Empresa = @nit_empresa and IdSede = @idSede";


               totalActividadesEjecutadas = contexto.Database.SqlQuery<int?>(sqlTotalActividadesEjecutadas,
                                           new SqlParameter("@nit_empresa", nitEmpresa),
                                              new SqlParameter("@anio", DateTime.Today.Year),
                                         new SqlParameter("@idSede", nitxsede)).FirstOrDefault();

               if (totalActividadesPlaneadas != null)
               {

                   resultado = (Decimal.Parse(totalActividadesEjecutadas.ToString()) / totalActividadesPlaneadas) * 100;
               }
               else
               {
                   return null;
               }
           }

           catch (Exception ex)
           {
               registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               return null;
           }
       }

       return resultado;
   }


   public decimal? ObtenerResultadoReporteSST(string nitEmpresa)
   {
       int? totalAccionesCorrectivasISem = 0;
       int? totalAccionesCorrectivasIISem = 0;

       int? totalAccionesCerradasISem = 0;
       int? totalAccionesCerradasIISem = 0;

       decimal? resultado = 0;

       using (SG_SSTContext contexto = new SG_SSTContext())
       {
           RegistraLog registra = new RegistraLog();

           try
           {
               int mes = DateTime.Today.Month;
               if (mes <= 6)
               {
                   string sqlTotaAccionesCorrectivasISem = "SELECT COUNT(*) AS Total "
                                                   +"FROM            V_IndAccionesCorrPrevMejTotal "
                             + "WHERE        (Nit_Empresa = @nit_empresa) AND (ANIO = @anio) AND (MES BETWEEN 1 AND 6) "
                             +"GROUP BY Nit_Empresa, Razon_Social ";

                   totalAccionesCorrectivasISem = contexto.Database.SqlQuery<int?>(sqlTotaAccionesCorrectivasISem,
                              new SqlParameter("@nit_empresa", nitEmpresa),
                               new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                   string sqltotalAccionesCerradasISem = "SELECT  COUNT(Pk_Id_Accion) AS Cerradas "
                   + " FROM            V_IndAccionesCorrPrevMejActividades "
                  + " WHERE        (Anio = @anio) AND (Mes BETWEEN 1 AND 6) AND  "
                  + " (Estado ='Cerrada') AND (Eficacia = 'Implementada y eficaz') AND (Nit_Empresa = @nit_empresa) "
                  + " GROUP BY Nit_Empresa HAVING (COUNT(*) >= 1) ";

                   totalAccionesCerradasISem = contexto.Database.SqlQuery<int?>(sqltotalAccionesCerradasISem,
                              new SqlParameter("@nit_empresa", nitEmpresa),
                               new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                   if (totalAccionesCorrectivasISem != null)
                   {

                       resultado = (Decimal.Parse(totalAccionesCerradasISem.ToString()) / totalAccionesCorrectivasISem) * 100;
                   }
                   else
                   {
                       return null;
                   }
               }
               else
               {
                   string sqlTotaAccionesCorrectivasIISem = "SELECT COUNT(*) AS Total "
                                                  + "FROM            V_IndAccionesCorrPrevMejTotal "
                            + "WHERE        (Nit_Empresa = @nit_empresa) AND (ANIO = @anio) AND (MES BETWEEN 7 AND 12) "
                            + "GROUP BY Nit_Empresa, Razon_Social ";

                   totalAccionesCorrectivasIISem = contexto.Database.SqlQuery<int?>(sqlTotaAccionesCorrectivasIISem,
                              new SqlParameter("@nit_empresa", nitEmpresa),
                               new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                   string sqltotalAccionesCerradasIISem = "SELECT  COUNT(Pk_Id_Accion) AS Cerradas "
                   + " FROM            V_IndAccionesCorrPrevMejActividades "
                  + " WHERE        (Anio = @anio) AND (Mes BETWEEN 7 AND 12) AND  "
                  + " (Estado ='Cerrada') AND (Eficacia = 'Implementada y eficaz') AND (Nit_Empresa = @nit_empresa) "
                  + " GROUP BY Nit_Empresa HAVING (COUNT(*) >= 1) ";

                   totalAccionesCerradasIISem = contexto.Database.SqlQuery<int?>(sqltotalAccionesCerradasIISem,
                              new SqlParameter("@nit_empresa", nitEmpresa),
                               new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                   if (totalAccionesCorrectivasIISem != null)
                   {

                       resultado = (Decimal.Parse(totalAccionesCerradasIISem.ToString()) / totalAccionesCorrectivasIISem) * 100;
                   }
                   else
                   {
                       return null;
                   }
               }

           }
           catch (Exception ex)
           {
               registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               return null;
           }
       }

       return resultado;
   }

   public decimal? ObtenerResultadoPerfilSocioDemografico(string nitEmpresa)
   {
       int? totalPerfiles= 0;


       int? resultado = 0;

       using (SG_SSTContext contexto = new SG_SSTContext())
       {
           RegistraLog registra = new RegistraLog();

           try
           {
               int nitxsede = (from e in contexto.Tbl_Empresa
                               join sd in contexto.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                               where sd.Empresa.Nit_Empresa == nitEmpresa
                               select sd.Pk_Id_Sede).FirstOrDefault();

               string sqltotalPerfiles = " select count(idEmpleado_PerfilSocioDemografico) as total "
                                        + " from Tbl_PerfilSocioDemograficoPlanificacion "
                                          + " WHERE   (Fk_Sede = @idSede)  ";

               totalPerfiles = contexto.Database.SqlQuery<int?>(sqltotalPerfiles,
                             new SqlParameter("@nit_empresa", nitEmpresa),
                             new SqlParameter("@idSede", nitxsede)).FirstOrDefault();



               if (totalPerfiles != null)
               {

                   resultado = totalPerfiles;
               }
               else
               {
                   return null;
               }
           }

           catch (Exception ex)
           {
               registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               return null;
           }
       }

       return resultado;
   }

   public decimal? ObtenerResultadoTasaAccidentalidad(string nitEmpresa)
   {
       int? totalAccidentes = 0;
       decimal? promedioTra = 0;


       decimal? resultado = 0;

       using (SG_SSTContext contexto = new SG_SSTContext())
       {
           RegistraLog registra = new RegistraLog();

           try
           {


               string sqltotalAccidentes = "SELECT COUNT(*) as Num_AT  "
                                          + "FROM V_IndTasaAccidentalidad "
                                          + "Where FK_Id_Contingencia = 3 and Anio = @anio and nitEmpresa = @nit_empresa "
                                          + "GROUP BY NitEmpresa ";

                              totalAccidentes = contexto.Database.SqlQuery<int?>(sqltotalAccidentes,
                              new SqlParameter("@nit_empresa", nitEmpresa),
                               new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

                              string sqlPromedioTrabajadores = "SELECT AVG(Num_Trabajadores_XT) as Num_Trabajadores "
                                                             + "FROM Tbl_ConfiguracionesHHT    "
                                                             + "WHERE Documento_empresa=@nit_empresa and Ano = @anio "
                                                             + " GROUP BY Ano, Documento_empresa ";

                              promedioTra = contexto.Database.SqlQuery<decimal?>(sqlPromedioTrabajadores,
                               new SqlParameter("@nit_empresa", nitEmpresa),
                                new SqlParameter("@anio", DateTime.Today.Year)).FirstOrDefault();

               if(promedioTra!=null)
               {

                   resultado = (Decimal.Parse(totalAccidentes.ToString()) / promedioTra) * 100;
      
               }
               else
               {
                   return null;
               }

           }

           catch (Exception ex)
           {
               registra.RegistrarError(typeof(IndicadoresManager), string.Format("Error al obtener la Información  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
               return null;
           }
       }

       return resultado;
   }

    }
}

