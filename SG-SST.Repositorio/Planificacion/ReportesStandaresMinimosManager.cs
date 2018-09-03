using SG_SST.Interfaces.Planificacion;
using SG_SST.Models;
using SG_SST.Models.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Repositorio.Planificacion
{
    public class ReportesStandaresMinimosManager : IReportesEstandaresMinimos
    {
        public int ObtenerCantidadPreguntasAlmomento(int idCclo, string Nit, int Ideval)
        {
            int cantidad = 0;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                cantidad = (from tc in context.Tbl_Ciclos
                            join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                            join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                            join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                            join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio
                            join emeval1 in context.Tbl_EvaluacionEmpresa on teval.Fk_Id_EvaluacionEmpresa equals emeval1.Pk_Id_EvaluacionEmpresa
                            join emp in context.Tbl_Empresa on emeval1.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where tc.Pk_Id_Ciclo == idCclo && emeval1.Pk_Id_EvaluacionEmpresa == Ideval
                            select teval.Fk_Id_Criterio).ToList().Count();
            }
            return cantidad;
        }

        public decimal ObtenerPorcentajeObtenidoAlmomento(int idCclo, string Nit, int Ideval)
        {
            decimal cantidad = 0;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                var evalmin = (from tc in context.Tbl_Ciclos
                               join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                               join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                               join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                               join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio
                               join emeval1 in context.Tbl_EvaluacionEmpresa on teval.Fk_Id_EvaluacionEmpresa equals emeval1.Pk_Id_EvaluacionEmpresa
                               join emp in context.Tbl_Empresa on emeval1.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                               where tc.Pk_Id_Ciclo == idCclo && emeval1.Pk_Id_EvaluacionEmpresa == Ideval
                               select teval).ToList<Evaluacion_Estandar_Minimo>().Distinct().ToList();

                if (evalmin != null)
                {
                    decimal cantidadCrit = 0;
                    decimal cantidadeval = 0;
                    foreach (var item in evalmin)
                    {
                        cantidadCrit = item.Criterio.Valor;
                        cantidadeval = item.Config_Valoracion_SubEstand.Valor;
                        cantidad = cantidad + (cantidadCrit * cantidadeval);
                    }
                }
                //teval.Valor_Calificacion).ToList().Sum();

                //cantidad = (from tc in context.Tbl_Ciclos
                //            join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                //            join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                //            join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                //            join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio
                //            join emeval1 in context.Tbl_EvaluacionEmpresa on teval.Fk_Id_EvaluacionEmpresa equals emeval1.Pk_Id_EvaluacionEmpresa
                //            join emp in context.Tbl_Empresa on emeval1.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                //            where tc.Pk_Id_Ciclo == idCclo && emeval1.Pk_Id_EvaluacionEmpresa == Ideval
                //            select teval.Valor_Calificacion).ToList().Sum();


            }
            return cantidad;
        }

        public decimal ObtenerPorcentajeObtenidoEstandar(int idCclo, int idEstandar, string Nit, int Idval)
        {
            decimal cantidad = 0;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                cantidad = (from tc in context.Tbl_Ciclos
                            join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                            join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                            join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                            join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio
                            join emeval in context.Tbl_EvaluacionEmpresa on teval.Fk_Id_EvaluacionEmpresa equals emeval.Pk_Id_EvaluacionEmpresa

                            join emp in context.Tbl_Empresa on emeval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where tc.Pk_Id_Ciclo == idCclo && ts.Pk_Id_Estandar == idEstandar && emeval.Pk_Id_EvaluacionEmpresa == Idval
                            select teval.Valor_Calificacion).ToList().Sum(v => v);
            }
            return cantidad;
        }
        public decimal ObtenerPorcentajeObtenidoSubEstandar(int idCclo, int idEstandar, string Nit, int Idval)
        {
            decimal cantidad = 0;
            decimal cantidad1 = 0;
            using (SG_SSTContext context = new SG_SSTContext())
            {


                cantidad = (from teval in context.Tbl_Evaluacion_Estandares_Minimos
                            join tcr in context.Tbl_Criterios on teval.Fk_Id_Criterio equals tcr.Pk_Id_Criterio
                            join ts in context.Tbl_SubEstandares on tcr.Fk_Id_SubEstandar equals ts.Pk_Id_SubEstandar
                            join emeval in context.Tbl_EvaluacionEmpresa on teval.Fk_Id_EvaluacionEmpresa equals emeval.Pk_Id_EvaluacionEmpresa
                            where ts.Pk_Id_SubEstandar == idEstandar && emeval.Pk_Id_EvaluacionEmpresa == Idval
                            select teval.Valor_Calificacion).Distinct().ToList().Sum(v => v);
                cantidad = (from tc in context.Tbl_Ciclos
                            join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                            join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                            join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                            join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio
                            join emeval in context.Tbl_EvaluacionEmpresa on teval.Fk_Id_EvaluacionEmpresa equals emeval.Pk_Id_EvaluacionEmpresa
                            where tc.Pk_Id_Ciclo == idCclo && tsb.Pk_Id_SubEstandar == idEstandar && emeval.Pk_Id_EvaluacionEmpresa == Idval
                            select teval.Valor_Calificacion).ToList().Sum(v => v);

            }
            return cantidad;
        }
    }
}
