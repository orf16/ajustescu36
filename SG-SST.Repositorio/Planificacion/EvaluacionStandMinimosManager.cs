using SG_SST.Interfaces.Planificacion;
using System.Collections.Generic;
using System.Linq;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Models.Planificacion;
using System;
using SG_SST.Enumeraciones;
using SG_SST.Models;
using System.Data.Entity;
using SG_SST.EntidadesDominio.Ausentismo;
using SG_SST.Models.Empresas;

namespace SG_SST.Repositorio.Planificacion
{
    public class EvaluacionStandMinimosManager : IEvaluacionEstandMinimos
    {
        /// <summary>
        /// Guarda los datos de la evaluación estándares mínimos.
        /// Se debe tener en cuenta que debe existir. Tambien tener en cuenta
        /// que la empresa debe existir previamente para poder ser evaluada
        /// </summary>
        /// <param name="EvaluacionEstandar"></param>
        /// <returns></returns>
        public EDEvaluacionEstandarMinimo GuardarEvaluacionEstandar(EDEvaluacionEstandarMinimo EvaluacionEstandar)
        {

            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(EvaluacionEstandar.Nit.Trim())
                            select eval).FirstOrDefault();
                if (empr == null)
                {
                    var empresa = context.Tbl_Empresa.Where(e => e.Nit_Empresa.Trim().Equals(EvaluacionEstandar.Nit.Trim())).Select(e => e).FirstOrDefault();
                    if (empresa != null)
                    {
                        var empEval = new Empresa_Evaluar();
                        empEval.Fk_Id_Empresa = empresa.Pk_Id_Empresa;
                        empEval.Fecha_Diligencia_Eval_EstMin = DateTime.Now;
                        context.Tbl_Empresas_Evaluar.Add(empEval);
                        empr = empEval;
                        context.SaveChanges();
                    }
                }

                var empr1 = (from emp in context.Tbl_Empresa
                            where emp.Nit_Empresa.Trim().Equals(EvaluacionEstandar.Nit.Trim())
                            select emp).FirstOrDefault();


                var Evalempr = (from s in context.Tbl_EvaluacionEmpresa
                                where s.Pk_Id_EvaluacionEmpresa == EvaluacionEstandar.IdEvaluacion
                                select s).FirstOrDefault<EvaluacionEmpresa>();


                if (empr1.Pk_Id_Empresa==0 || Evalempr.Pk_Id_EvaluacionEmpresa == 0)
                {
                    return EvaluacionEstandar;
                }

                //if (!verificarevaluacion(empr1.Pk_Id_Empresa, EvaluacionEstandar.IdEvaluacion))
                //{
                //    return EvaluacionEstandar;
                //}

                int idcriterio = EvaluacionEstandar.IdCriterio;

                if (idcriterio == 0 )
                {
                    return EvaluacionEstandar;
                }


                if (verificarcriterio(idcriterio, Evalempr.Pk_Id_EvaluacionEmpresa))
                {
                    return EvaluacionEstandar;
                }

                EvaluacionEstandar.IdEmpresaEvaluar = empr.Pk_Id_Empresa_Evaluar;
                using (var Transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int codjustifica = 0;
                        Config_Valoracion_SubEstand Configuracion = null;
                        //Obtenemos el id del subestandar que se esta evaluando de acuerdo al criterio
                        var idSubEStandar = context.Tbl_Criterios.Where(c => c.Pk_Id_Criterio == EvaluacionEstandar.IdCriterio).Select(c => c.Fk_Id_SubEstandar).FirstOrDefault();

                        //Se verifica si la valoracion es no aplica, si as asi se debe verificar si el no aplica viene con justificacion
                        if (EvaluacionEstandar.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.NoAplica)
                        {
                            if (string.IsNullOrEmpty(EvaluacionEstandar.Justificacion))
                                codjustifica = (int)EnumPlanificacion.ValoracionStandares.NoJustifica;
                            else
                                codjustifica = (int)EnumPlanificacion.ValoracionStandares.Justifica;
                        }

                        //Obtenemos el id de la configuracion que tiene el valor de calificacion
                        if (codjustifica > 0)
                            Configuracion = context.Tbl_Config_Valoracion_SubEstandares.Where(cf => cf.Fk_Id_SubEstandar == idSubEStandar
                                                                                               && cf.Fk_Id_Valoracion_Criterio == EvaluacionEstandar.IdValoracionCriterio
                                                                                               && cf.Id_Dpendiente == codjustifica)
                                                                                          .Select(cf => cf).FirstOrDefault();
                        else
                            Configuracion = context.Tbl_Config_Valoracion_SubEstandares.Where(cf => cf.Fk_Id_SubEstandar == idSubEStandar
                                                                                               && cf.Fk_Id_Valoracion_Criterio == EvaluacionEstandar.IdValoracionCriterio)
                                                                                          .Select(cf => cf).FirstOrDefault();
                        if (Configuracion.Pk_Id_Config_Valoracion_SubEstand > 0)
                        {
                            decimal valorCriterio = context.Tbl_Criterios.Where(cr => cr.Pk_Id_Criterio == EvaluacionEstandar.IdCriterio).Select(cr => cr.Valor).FirstOrDefault();
                            if (Configuracion.Valor < 1)
                                valorCriterio = 0;

                            Evaluacion_Estandar_Minimo evaluacion = new Evaluacion_Estandar_Minimo
                            {
                                Fk_Id_Config_Valoracion_SubEstand = Configuracion.Pk_Id_Config_Valoracion_SubEstand,
                                Fk_Id_Criterio = EvaluacionEstandar.IdCriterio,
                                Fk_Id_Empresa_Evaluar = empr.Pk_Id_Empresa_Evaluar,
                                Valor_Calificacion = valorCriterio,
                                Fk_Id_EvaluacionEmpresa = Evalempr.Pk_Id_EvaluacionEmpresa,
                                NombreArchivo1 = EvaluacionEstandar.NombreArchivo1,
                                NombreArchivo2 = EvaluacionEstandar.NombreArchivo2,
                                NombreArchivo3 = EvaluacionEstandar.NombreArchivo3,
                                NombreArchivo1_download = EvaluacionEstandar.Filedownload1,
                                NombreArchivo2_download = EvaluacionEstandar.Filedownload2,
                                NombreArchivo3_download = EvaluacionEstandar.Filedownload3,
                                Ruta1 = EvaluacionEstandar.Ruta1,
                                Ruta2 = EvaluacionEstandar.Ruta2,
                                Ruta3 = EvaluacionEstandar.Ruta3
                            };

                            if (codjustifica == (int)EnumPlanificacion.ValoracionStandares.Justifica)
                            {
                                evaluacion.Justificacion = EvaluacionEstandar.Justificacion;
                            }
                            context.Tbl_Evaluacion_Estandares_Minimos.Add(evaluacion);
                            context.SaveChanges();
                            if (codjustifica == (int)EnumPlanificacion.ValoracionStandares.Justifica)
                            {
                                EvaluacionEstandar.GuardadoArchivos = true;
                            }

                            EvaluacionEstandar.IdEvalEstandarMinimo = evaluacion.Pk_Id_Eval_Estandar_Minimo;

                            if (EvaluacionEstandar.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.NoCumple)
                            {
                                foreach (var actividad in EvaluacionEstandar.Actividades)
                                {
                                    ActividadEvaluacion act = new ActividadEvaluacion
                                    {
                                        Descripcion = actividad.Descripcion,
                                        Responsable = actividad.Responsable,
                                        FechaFin = actividad.FechaFin,
                                        EvaluacionCerrado = false
                                    };

                                    context.Tbl_Actividades_Evaluacion.Add(act);
                                    context.SaveChanges();

                                    Actividad_Criterio accr = new Actividad_Criterio
                                    {
                                        Fk_Id_Actividad = act.Pk_Id_Actividad,
                                        Fk_Id_Eval_Estandar_Minimo = EvaluacionEstandar.IdEvalEstandarMinimo
                                    };

                                    context.Tbl_Actividades_Criterio.Add(accr);
                                    context.SaveChanges();
                                }
                            }
                        }
                        else
                            return EvaluacionEstandar;
                        Transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Transaction.Rollback();
                    }
                }
            }
            return EvaluacionEstandar;
        }
        public EDCiclo ObtenerStandares(int idCiclo)
        {
            EDCiclo ciclo = new EDCiclo();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                ciclo = (from c in context.Tbl_Ciclos
                         where c.Pk_Id_Ciclo == idCiclo
                         select new EDCiclo
                         {
                             Id_Ciclo = c.Pk_Id_Ciclo,
                             Nombre = c.Nombre,
                             Porcentaje_Max = c.Porcentaje_Max,
                             Estandares = (from ts in context.Tbl_Estandares
                                           where ts.Fk_Id_Ciclo == c.Pk_Id_Ciclo
                                           select new EDEstandar
                                           {
                                               Id_Estandar = ts.Pk_Id_Estandar,
                                               Descripcion = ts.Descripcion,
                                               Porcentaje_Max = ts.Porcentaje_Max
                                           }).ToList()

                         }).FirstOrDefault();
            }

            return ciclo;
        }
        public List<EDCiclo> ObtenerCiclos()
        {
            List<EDCiclo> ciclos = new List<EDCiclo>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                ciclos = (from c in context.Tbl_Ciclos
                          select new EDCiclo
                          {
                              Id_Ciclo = c.Pk_Id_Ciclo,
                              Nombre = c.Nombre,
                              Porcentaje_Max = c.Porcentaje_Max
                          }).ToList();
            }

            return ciclos;
        }
        public EDCiclo ObtenerEstandarPorCicloG(int idCiclo, int idCriterioActual, int idEmpresa)
        {
            EDCiclo ciclo = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                bool encuentraID = true;
                int idSiguienteCriterio = 0;
                int intentos = 0;
                do
                {
                    idCriterioActual++;
                    idSiguienteCriterio = context.Tbl_Criterios.Where(cr => cr.Pk_Id_Criterio == idCriterioActual).Select(cr => cr.Pk_Id_Criterio).FirstOrDefault();
                    if (idSiguienteCriterio > 0)
                        encuentraID = false;
                    if (intentos >= 10)
                        encuentraID = false;
                    intentos++;
                } while (encuentraID);

                var idSubestandar = context.Tbl_Criterios.Where(cr => cr.Pk_Id_Criterio == idSiguienteCriterio).Select(cr => cr.Fk_Id_SubEstandar).FirstOrDefault();
                var idEstandar = context.Tbl_SubEstandares.Where(sb => sb.Pk_Id_SubEstandar == idSubestandar).Select(sb => sb.Fk_Id_Estandar).FirstOrDefault();

                ciclo = (from c in context.Tbl_Ciclos
                         where c.Pk_Id_Ciclo == idCiclo
                         select new EDCiclo
                         {
                             Id_Ciclo = c.Pk_Id_Ciclo,
                             Nombre = c.Nombre,
                             Estandar = (from e in context.Tbl_Estandares
                                         where e.Pk_Id_Estandar == idEstandar
                                         select new EDEstandar
                                         {
                                             Id_Estandar = e.Pk_Id_Estandar,
                                             Descripcion = e.Descripcion,
                                             SubEstandar = (from sb in context.Tbl_SubEstandares
                                                            where sb.Pk_Id_SubEstandar == idSubestandar
                                                            select new EDSubEstandar
                                                            {
                                                                Id_SubEstandar = sb.Pk_Id_SubEstandar,
                                                                Descripcion = sb.Descripcion,
                                                                Criterio = (from cr in context.Tbl_Criterios
                                                                            where cr.Pk_Id_Criterio == idSiguienteCriterio
                                                                            select new EDCriterio
                                                                            {
                                                                                Id_Criterio = cr.Pk_Id_Criterio,
                                                                                Descripcion = cr.Descripcion,
                                                                                Marco_Legal = cr.Marco_Legal,
                                                                                Modo_Verificacion = cr.Modo_Verificacion,
                                                                                Numeral = cr.Numeral
                                                                            }).FirstOrDefault()
                                                            }).FirstOrDefault()
                                         }).FirstOrDefault()
                         }).FirstOrDefault();
            }
            return ciclo;
        }
        public EDCiclo ObtenerEstandarPorCicloSiguiente(int ideval, string NIT)
        {
            EDCiclo ciclo = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var evals = (from eval in context.Tbl_Evaluacion_Estandares_Minimos
                            join empev in context.Tbl_EvaluacionEmpresa on eval.Fk_Id_EvaluacionEmpresa equals empev.Pk_Id_EvaluacionEmpresa
                            join emp in context.Tbl_Empresa on empev.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(NIT) && empev.Pk_Id_EvaluacionEmpresa== ideval
                            select eval).ToList();

                var criterioactual = evals.Max(x => x.Fk_Id_Criterio);
                var idSubestandaractual = context.Tbl_Criterios.Where(cr => cr.Pk_Id_Criterio == criterioactual).Select(cr => cr.Fk_Id_SubEstandar).FirstOrDefault();
                var idEstandaractual = context.Tbl_SubEstandares.Where(sb => sb.Pk_Id_SubEstandar == idSubestandaractual).Select(sb => sb.Fk_Id_Estandar).FirstOrDefault();
                var idCicloactual = context.Tbl_Estandares.Where(sb => sb.Pk_Id_Estandar == idEstandaractual).Select(sb => sb.Fk_Id_Ciclo).FirstOrDefault();
                int idSiguienteCriterio = criterioactual + 1;


                var idSubestandar = context.Tbl_Criterios.Where(cr => cr.Pk_Id_Criterio == idSiguienteCriterio).Select(cr => cr.Fk_Id_SubEstandar).FirstOrDefault();
                var idEstandar = context.Tbl_SubEstandares.Where(sb => sb.Pk_Id_SubEstandar == idSubestandar).Select(sb => sb.Fk_Id_Estandar).FirstOrDefault();
                var idCiclo = context.Tbl_Estandares.Where(sb => sb.Pk_Id_Estandar == idEstandar).Select(sb => sb.Fk_Id_Ciclo).FirstOrDefault();

                if (idCiclo!= idCicloactual)
                {
                    return null;
                }
                ciclo = (from c in context.Tbl_Ciclos
                         where c.Pk_Id_Ciclo == idCiclo
                         select new EDCiclo
                         {
                             Id_Ciclo = c.Pk_Id_Ciclo,
                             Nombre = c.Nombre,
                             Estandar = (from e in context.Tbl_Estandares
                                         where e.Pk_Id_Estandar == idEstandar
                                         select new EDEstandar
                                         {
                                             Id_Estandar = e.Pk_Id_Estandar,
                                             Descripcion = e.Descripcion,
                                             SubEstandar = (from sb in context.Tbl_SubEstandares
                                                            where sb.Pk_Id_SubEstandar == idSubestandar
                                                            select new EDSubEstandar
                                                            {
                                                                Id_SubEstandar = sb.Pk_Id_SubEstandar,
                                                                Descripcion = sb.Descripcion,
                                                                Criterio = (from cr in context.Tbl_Criterios
                                                                            where cr.Pk_Id_Criterio == idSiguienteCriterio
                                                                            select new EDCriterio
                                                                            {
                                                                                Id_Criterio = cr.Pk_Id_Criterio,
                                                                                Descripcion = cr.Descripcion,
                                                                                Marco_Legal = cr.Marco_Legal,
                                                                                Modo_Verificacion = cr.Modo_Verificacion,
                                                                                Numeral = cr.Numeral
                                                                            }).FirstOrDefault()
                                                            }).FirstOrDefault()
                                         }).FirstOrDefault()
                         }).FirstOrDefault();
            }
            return ciclo;
        }
        /// <summary>
        /// Obtiene el criterio a editar con estandares y el ciclo al cual pertenece
        /// </summary>
        /// <param name="idCiclo"></param>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public EDCiclo ObtenerEstandarPorCiclo(int idCiclo, string Nit, int IdEval)
        {
            EDCiclo ciclo = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(Nit.Trim())
                            select eval).FirstOrDefault();
                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();
                var criteriosEvaluados = new List<int>();
                if (empr != null)
                {
                    criteriosEvaluados = (from tcr in context.Tbl_Criterios
                                          join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                          from ljoin in lefjoin.DefaultIfEmpty()
                                          where ljoin.Fk_Id_EvaluacionEmpresa == IdEval
                                          select ljoin.Fk_Id_Criterio).ToList();
                }
                ciclo = (from c in context.Tbl_Ciclos
                         join e in context.Tbl_Estandares on c.Pk_Id_Ciclo equals e.Fk_Id_Ciclo
                         join sb in context.Tbl_SubEstandares on e.Pk_Id_Estandar equals sb.Fk_Id_Estandar
                         join cr in context.Tbl_Criterios on sb.Pk_Id_SubEstandar equals cr.Fk_Id_SubEstandar
                         join teval in context.Tbl_Evaluacion_Estandares_Minimos on cr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                         from ljoin in lefjoin.DefaultIfEmpty()
                         where c.Pk_Id_Ciclo == idCiclo && !criteriosEvaluados.Contains(cr.Pk_Id_Criterio)
                         select new EDCiclo
                         {
                             Id_Ciclo = c.Pk_Id_Ciclo,
                             Nombre = c.Nombre,
                             Estandar = new EDEstandar
                             {
                                 Id_Estandar = e.Pk_Id_Estandar,
                                 Descripcion = e.Descripcion,
                                 SubEstandar = new EDSubEstandar
                                 {
                                     Id_SubEstandar = sb.Pk_Id_SubEstandar,
                                     Descripcion = sb.Descripcion,
                                     Criterio = new EDCriterio
                                     {
                                         Id_Criterio = cr.Pk_Id_Criterio,
                                         Descripcion = cr.Descripcion,
                                         Marco_Legal = cr.Marco_Legal,
                                         Modo_Verificacion = cr.Modo_Verificacion,
                                         Numeral = cr.Numeral
                                     }
                                 }
                             }
                         }).FirstOrDefault();
            }
            return ciclo;
        }
        public EDCiclo ObtenerEstandarPorCiclo1(int idCiclo, string Nit, int IdEval)
        {
            EDCiclo ciclo = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(Nit.Trim())
                            select eval).FirstOrDefault();
                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();
                var criteriosEvaluados = new List<int>();
                if (empr != null)
                {
                    criteriosEvaluados = (from tcr in context.Tbl_Criterios
                                          join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                          from ljoin in lefjoin.DefaultIfEmpty()
                                          where ljoin.Fk_Id_EvaluacionEmpresa == IdEval
                                          select ljoin.Fk_Id_Criterio).ToList();
                }
                ciclo = (from c in context.Tbl_Ciclos
                         join e in context.Tbl_Estandares on c.Pk_Id_Ciclo equals e.Fk_Id_Ciclo
                         join sb in context.Tbl_SubEstandares on e.Pk_Id_Estandar equals sb.Fk_Id_Estandar
                         join cr in context.Tbl_Criterios on sb.Pk_Id_SubEstandar equals cr.Fk_Id_SubEstandar
                         join teval in context.Tbl_Evaluacion_Estandares_Minimos on cr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                         from ljoin in lefjoin.DefaultIfEmpty()
                         where c.Pk_Id_Ciclo == idCiclo
                         select new EDCiclo
                         {
                             Id_Ciclo = c.Pk_Id_Ciclo,
                             Nombre = c.Nombre,
                             Estandar = new EDEstandar
                             {
                                 Id_Estandar = e.Pk_Id_Estandar,
                                 Descripcion = e.Descripcion,
                                 SubEstandar = new EDSubEstandar
                                 {
                                     Id_SubEstandar = sb.Pk_Id_SubEstandar,
                                     Descripcion = sb.Descripcion,
                                     Criterio = new EDCriterio
                                     {
                                         Id_Criterio = cr.Pk_Id_Criterio,
                                         Descripcion = cr.Descripcion,
                                         Marco_Legal = cr.Marco_Legal,
                                         Modo_Verificacion = cr.Modo_Verificacion,
                                         Numeral = cr.Numeral
                                     }
                                 }
                             }
                         }).FirstOrDefault();
            }
            return ciclo;
        }
        public int ObtenerCantidaEstdPorEvaluas(int idCiclo, string Nit, int IdEval)
        {
            int cantidadSinEval = 0;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(Nit.Trim())
                            select eval).FirstOrDefault();
                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();
                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();
                List<int> criteriosEvaluados = null;
                if (empr != null)
                {
                    criteriosEvaluados = (from tcr in context.Tbl_Criterios
                                          join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                          from ljoin in lefjoin.DefaultIfEmpty()
                                          where ljoin.Fk_Id_EvaluacionEmpresa == IdEval
                                          select ljoin.Fk_Id_Criterio).ToList();
                    cantidadSinEval = (from tc in context.Tbl_Ciclos
                                       join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                                       join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                                       join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                                       join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                       from ljoin in lefjoin.DefaultIfEmpty()
                                       where tc.Pk_Id_Ciclo == idCiclo
                                       && !criteriosEvaluados.Contains(tcr.Pk_Id_Criterio)
                                       select tcr.Pk_Id_Criterio).Distinct().ToList().Count();
                }
                else
                {
                    cantidadSinEval = (from tc in context.Tbl_Ciclos
                                       join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                                       join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                                       join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                                       join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                       from ljoin in lefjoin.DefaultIfEmpty()
                                       where tc.Pk_Id_Ciclo == idCiclo
                                       select tcr.Pk_Id_Criterio).Distinct().ToList().Count();
                }
            }
            return cantidadSinEval;
        }
        public int ObtenerCantidadCriteriosPorEstandar(int idCiclo)
        {
            int cantidad = 0;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                cantidad = (from tc in context.Tbl_Ciclos
                            join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                            join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                            join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                            where tc.Pk_Id_Ciclo == idCiclo
                            select tcr.Pk_Id_Criterio).Distinct().ToList().Count();
            }
            return cantidad;
        }
        public EDValoracionFinal ObtenerCalificacion(string Nit, int IdEval)
        {
            EDValoracionFinal calificacionFinal = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(Nit.Trim())
                            select eval).FirstOrDefault();
                if (empr == null)
                    return null;
                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();

                decimal calificacion = 0;
                try
                {
                    var cal = (from teval in context.Tbl_Evaluacion_Estandares_Minimos
                               where teval.Fk_Id_EvaluacionEmpresa == IdEval
                               select teval).FirstOrDefault();
                    if (cal != null)
                    {
                        calificacion = (from teval in context.Tbl_Evaluacion_Estandares_Minimos
                                        where teval.Fk_Id_EvaluacionEmpresa == IdEval
                                        select teval.Valor_Calificacion).Sum();
                    }
                }
                catch (Exception)
                {
                }

                decimal redondear = Decimal.Round(calificacion, 0, MidpointRounding.AwayFromZero);
                calificacionFinal = (from vf in context.Tbl_Valoracion_Final
                                     where vf.Rango_Inicial <= redondear && vf.Rango_Final >= redondear
                                     select new EDValoracionFinal
                                     {
                                         IdValoracionFinal = vf.Pk_Id_Valoracion_Final,
                                         Accion = vf.Accion,
                                         Valoracion = vf.Valoracion,
                                         CriterioValoracion = vf.CriterioEvaluacion,
                                         puntoObtenidos = calificacion
                                     }).FirstOrDefault();

            }

            return calificacionFinal;
        }
        public List<EDCiclo> ObtenerDatosInformeExcel(string Nit, int IdEval)
        {
            List<EDCiclo> Ciclos = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(Nit.Trim())
                            select eval).FirstOrDefault();
                if (empr == null)
                    return null;

                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();

                Ciclos = context.Tbl_Ciclos.Select(c => new EDCiclo
                {
                    Id_Ciclo = c.Pk_Id_Ciclo,
                    Estandares = c.Estandares.Select(es => new EDEstandar
                    {
                        Id_Estandar = es.Pk_Id_Estandar,
                        SubEstandares = es.SubEstandares.Select(sb => new EDSubEstandar
                        {
                            Id_SubEstandar = sb.Pk_Id_SubEstandar,
                            Criterios = (from cr in sb.Criterios
                                         join tesm in context.Tbl_Evaluacion_Estandares_Minimos on cr.Pk_Id_Criterio equals tesm.Fk_Id_Criterio
                                         join tcvs in context.Tbl_Config_Valoracion_SubEstandares on tesm.Fk_Id_Config_Valoracion_SubEstand equals tcvs.Pk_Id_Config_Valoracion_SubEstand
                                         where tesm.Fk_Id_EvaluacionEmpresa == IdEval
                                         select new EDCriterio
                                         {
                                             Id_Criterio = cr.Pk_Id_Criterio,
                                             Descripcion_Corta = cr.Descripcion_Corta,
                                             Evaluacion = new EDEvaluacionEstandarMinimo
                                             {
                                                 IdValoracionCriterio = tcvs.Fk_Id_Valoracion_Criterio,
                                                 Justificacion = (string.IsNullOrEmpty(tesm.Justificacion) ? "0" : "1")
                                             }

                                         }).ToList(),
                            CalTotal = (from cr in sb.Criterios
                                        join tesm in context.Tbl_Evaluacion_Estandares_Minimos on cr.Pk_Id_Criterio equals tesm.Fk_Id_Criterio
                                        //join tcvs in context.Tbl_Config_Valoracion_SubEstandares on tesm.Fk_Id_Config_Valoracion_SubEstand equals tcvs.Pk_Id_Config_Valoracion_SubEstand
                                        where tesm.Fk_Id_EvaluacionEmpresa == IdEval
                                        select tesm.Valor_Calificacion).Sum()
                        }).ToList()

                    }).ToList()
                }).ToList();
            }

            return Ciclos;

        }
        public List<EDCiclo> ObtenerDatosInicialesInformeExcel()
        {
            List<EDCiclo> Ciclos = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {
                Ciclos = (from c in context.Tbl_Ciclos
                          select new EDCiclo
                          {
                              Id_Ciclo = c.Pk_Id_Ciclo,
                              Nombre = c.Nombre,
                              Estandares = c.Estandares.Select(es => new EDEstandar
                              {
                                  Id_Estandar = es.Pk_Id_Estandar,
                                  Descripcion = es.Descripcion,
                                  SubEstandares = (from sb in es.SubEstandares
                                                       //join tcvs in context.Tbl_Config_Valoracion_SubEstandares on sb.Pk_Id_SubEstandar equals tcvs.Fk_Id_SubEstandar
                                                       ///where tcvs.Fk_Id_Valoracion_Criterio == (int)EnumPlanificacion.ValoracionStandares.CumpleTotalMente
                                                   select new EDSubEstandar
                                                   {
                                                       Id_SubEstandar = sb.Pk_Id_SubEstandar,
                                                       Descripcion_Corta = sb.Descripcion_Corta,
                                                       Procentaje_Max = sb.Procentaje_Max,
                                                       Criterios = sb.Criterios.Select(cr => new EDCriterio
                                                       {
                                                           Id_Criterio = cr.Pk_Id_Criterio,
                                                           Descripcion_Corta = cr.Descripcion_Corta,
                                                           ValPorPregunta = cr.Valor.ToString(),
                                                           ValPorPreguntadec = cr.Valor
                                                       }).ToList()
                                                   }).ToList()

                              }).ToList()
                          }).ToList();
            }
            return Ciclos;
        }
        public List<EDActividad> ObtenerActividades(string Nit, int IdEval)
        {
            List<EDActividad> Actividades = new List<EDActividad>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(Nit.Trim())
                            select eval).FirstOrDefault();
                if (empr == null)
                    return null;

                string vigencia = "";
                var evalemp = (from evemp in context.Tbl_EvaluacionEmpresa
                            where evemp.Pk_Id_EvaluacionEmpresa== IdEval
                               select evemp).FirstOrDefault();
                if (evalemp!=null)
                {
                    vigencia = evalemp.Vigencia.ToString();
                }
                //var emp = context.Tbl_Empresas_Evaluar.Where(e => e.Nit.Trim().Equals(Nit.Trim())).Select(e => e).FirstOrDefault();
                Actividades = (from eval in context.Tbl_Evaluacion_Estandares_Minimos
                               join ac in context.Tbl_Actividades_Criterio on eval.Pk_Id_Eval_Estandar_Minimo equals ac.Fk_Id_Eval_Estandar_Minimo
                               join ae in context.Tbl_Actividades_Evaluacion on ac.Fk_Id_Actividad equals ae.Pk_Id_Actividad
                               where eval.Fk_Id_EvaluacionEmpresa == IdEval
                               select new EDActividad
                               {
                                   Id_Actividad = eval.Criterio.Pk_Id_Criterio,
                                   Descripcion = ae.Descripcion,
                                   Responsable = ae.Responsable,
                                   FechaFin = ae.FechaFin,
                                   Accion = eval.Criterio.Descripcion_Corta,
                                   Vigencia= vigencia
                               }).ToList();
            }
            return Actividades;
        }
        public int ObtenerCantidaEstdPorEvaluas(int idCiclo, int idEmpresa, int idEval)
        {
            int cantidadSinEval = 0;
            using (SG_SSTContext context = new SG_SSTContext())
            {

                var criteriosEvaluados = (from tcr in context.Tbl_Criterios
                                          join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                          from ljoin in lefjoin.DefaultIfEmpty()
                                          where ljoin.Fk_Id_EvaluacionEmpresa == idEval
                                          select ljoin.Fk_Id_Criterio).Distinct().ToList();

                cantidadSinEval = (from tc in context.Tbl_Ciclos
                                   join ts in context.Tbl_Estandares on tc.Pk_Id_Ciclo equals ts.Fk_Id_Ciclo
                                   join tsb in context.Tbl_SubEstandares on ts.Pk_Id_Estandar equals tsb.Fk_Id_Estandar
                                   join tcr in context.Tbl_Criterios on tsb.Pk_Id_SubEstandar equals tcr.Fk_Id_SubEstandar
                                   join teval in context.Tbl_Evaluacion_Estandares_Minimos on tcr.Pk_Id_Criterio equals teval.Fk_Id_Criterio into lefjoin
                                   from ljoin in lefjoin.DefaultIfEmpty()
                                   where tc.Pk_Id_Ciclo == idCiclo
                                   && !criteriosEvaluados.Contains(tcr.Pk_Id_Criterio)
                                   select tcr.Pk_Id_Criterio).Distinct().ToList().Count();

            }
            return cantidadSinEval;
        }
        public List<EDEvaluacionEmpresa> ListaEvaluaciones(int idEmpresa)
        {
            List<EDEvaluacionEmpresa> ListaEvaluaciones = new List<EDEvaluacionEmpresa>();

            using (SG_SSTContext db = new SG_SSTContext())
            {
                var Listavar = (from s in db.Tbl_EvaluacionEmpresa
                                where s.Fk_Id_Empresa == idEmpresa
                                select s).ToList<EvaluacionEmpresa>();
                if (Listavar != null)
                {
                    foreach (var item in Listavar)
                    {
                        EDEvaluacionEmpresa EDEvaluacionEmpresa = new EDEvaluacionEmpresa();
                        EDEvaluacionEmpresa.Fk_Id_Empresa = item.Fk_Id_Empresa;
                        EDEvaluacionEmpresa.Pk_Id_EvaluacionEmpresa = item.Pk_Id_EvaluacionEmpresa;
                        EDEvaluacionEmpresa.Vigencia = item.Vigencia;
                        EDEvaluacionEmpresa.Fecha_Elab = item.Fecha_Elab;
                        EDEvaluacionEmpresa.Estado = item.Estado;
                        EDEvaluacionEmpresa.Consecutivo = item.Consecutivo;

                        bool cambioestado = false;
                        if (item.Estado == 1 & !cambioestado)
                        {
                            List<EDCiclo> Ciclos = ObtenerCiclos();
                            int EstandEv = 0;
                            foreach (var item1 in Ciclos)
                            {
                                EstandEv = EstandEv + ObtenerCantidaEstdPorEvaluas(item1.Id_Ciclo, idEmpresa, item.Pk_Id_EvaluacionEmpresa);
                            }
                            if (EstandEv == 0)
                            {
                                cambioestado = true;
                                EDEvaluacionEmpresa.Estado = 2;
                                CambiarEstado(item.Pk_Id_EvaluacionEmpresa, 2);
                            }
                        }
                        if (item.Estado == 2 & !cambioestado)
                        {
                            List<EDCiclo> Ciclos = ObtenerCiclos();
                            int EstandEv = 0;
                            foreach (var item1 in Ciclos)
                            {
                                EstandEv = EstandEv + ObtenerCantidaEstdPorEvaluas(item1.Id_Ciclo, idEmpresa, item.Pk_Id_EvaluacionEmpresa);
                            }
                            if (EstandEv != 0)
                            {
                                cambioestado = true;
                                EDEvaluacionEmpresa.Estado = 1;
                                CambiarEstado(item.Pk_Id_EvaluacionEmpresa, 1);
                            }
                        }
                        if (item.Estado == 3 & !cambioestado)
                        {
                        }
                        List<EDCiclo> ListaCiclos = ObtenerCiclos();
                        foreach (var item1 in ListaCiclos)
                        {
                            EDEvaluacionEmpresa.NumeroTotal = EDEvaluacionEmpresa.NumeroTotal + ObtenerCantidadCriteriosPorEstandar(item1.Id_Ciclo);
                            EDEvaluacionEmpresa.Numeroevaluar = EDEvaluacionEmpresa.Numeroevaluar + ObtenerCantidaEstdPorEvaluas(item1.Id_Ciclo, idEmpresa, item.Pk_Id_EvaluacionEmpresa);
                        }
                        ListaEvaluaciones.Add(EDEvaluacionEmpresa);
                    }
                }
            }

            return ListaEvaluaciones;
        }
        public bool CrearEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            EvaluacionEmpresa EvaluacionEmpresa = new EvaluacionEmpresa();
            bool ProbarGuardado = false;
            EvaluacionEmpresa.Fk_Id_Empresa = EDEvaluacionEmpresa.Fk_Id_Empresa;
            EvaluacionEmpresa.Vigencia = EDEvaluacionEmpresa.Vigencia;
            EvaluacionEmpresa.Fecha_Elab = EDEvaluacionEmpresa.Fecha_Elab;
            EvaluacionEmpresa.Consecutivo = AsignarConsecutivo1(EDEvaluacionEmpresa.Fk_Id_Empresa).ToString();
            EvaluacionEmpresa.Estado = 1;


            using (SG_SSTContext db = new SG_SSTContext())
            {
                db.Tbl_EvaluacionEmpresa.Add(EvaluacionEmpresa);
                try
                {
                    db.SaveChanges();
                    ProbarGuardado = true;
                }
                catch (Exception ex)
                {
                }
            }
            //AsignarConsecutivo(EDEvaluacionEmpresa.Fk_Id_Empresa);
            return ProbarGuardado;
        }
        public bool ValidarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            EvaluacionEmpresa EvaluacionEmpresa = new EvaluacionEmpresa();
            EvaluacionEmpresa.Pk_Id_EvaluacionEmpresa = EDEvaluacionEmpresa.Pk_Id_EvaluacionEmpresa;
            EvaluacionEmpresa.Estado = EDEvaluacionEmpresa.Estado;
            EvaluacionEmpresa.Fk_Id_Empresa = EDEvaluacionEmpresa.Fk_Id_Empresa;

            using (SG_SSTContext db = new SG_SSTContext())
            {
                var est = (from estd in db.Tbl_Evaluacion_Estandares_Minimos
                             where estd.Fk_Id_EvaluacionEmpresa== EvaluacionEmpresa.Pk_Id_EvaluacionEmpresa && estd.Fk_Id_Criterio== EvaluacionEmpresa.Estado
                           select estd).FirstOrDefault();

                if (est!=null)
                {
                    if (est.Pk_Id_Eval_Estandar_Minimo!=0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
        }
        public bool EliminarEvaluacion(int IdEval, int IdEmpresa)
        {
            bool ProbarGuardado = false;
            EvaluacionEmpresa EvaluacionEmpresa = new EvaluacionEmpresa();


            using (SG_SSTContext db = new SG_SSTContext())
            {
                var EvalMin = (from s in db.Tbl_EvaluacionEmpresa
                               where s.Pk_Id_EvaluacionEmpresa == IdEval
                               select s).FirstOrDefault<EvaluacionEmpresa>();
                if (EvalMin != null)
                {
                    EvaluacionEmpresa = EvalMin;
                }
            }
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var EvalMin = (from s in db.Tbl_Evaluacion_Estandares_Minimos
                               where s.Fk_Id_EvaluacionEmpresa == IdEval
                               select s).ToList<Evaluacion_Estandar_Minimo>();
                if (EvalMin != null)
                {
                    foreach (var item in EvalMin)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                db.Entry(EvaluacionEmpresa).State = System.Data.Entity.EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                    //AsignarConsecutivo(IdEmpresa);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }
        public EDEstandar ObtenerCantidaEstdPorEvaluasCons(int IdCriterio, int IdEval)
        {
            EDEstandar Estandar = null;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                var Ev = (from s in context.Tbl_Evaluacion_Estandares_Minimos
                          where s.Fk_Id_EvaluacionEmpresa == IdEval && s.Fk_Id_Criterio == IdCriterio
                          select s).FirstOrDefault<Evaluacion_Estandar_Minimo>();
                if (Ev != null)
                {
                    Estandar = new EDEstandar();
                    Estandar.Descripcion = Ev.Criterio.SubEstandar.Estandar.Descripcion;
                    Estandar.Porcentaje_Max = Ev.Criterio.SubEstandar.Estandar.Porcentaje_Max;
                    Estandar.SubEstandar = new EDSubEstandar();
                    Estandar.SubEstandar.Descripcion = Ev.Criterio.SubEstandar.Descripcion;
                    Estandar.SubEstandar.Procentaje_Max = Ev.Criterio.SubEstandar.Procentaje_Max;
                    Estandar.SubEstandar.Descripcion_Corta = Ev.Criterio.SubEstandar.Descripcion_Corta;
                    Estandar.SubEstandar.Criterio = new EDCriterio();
                    Estandar.SubEstandar.Criterio.Descripcion = Ev.Criterio.Descripcion;
                    Estandar.SubEstandar.Criterio.Descripcion_Corta = Ev.Criterio.Descripcion_Corta;
                    Estandar.SubEstandar.Criterio.Numeral = Ev.Criterio.Numeral;
                    Estandar.SubEstandar.Criterio.Marco_Legal = Ev.Criterio.Marco_Legal;
                    Estandar.SubEstandar.Criterio.Modo_Verificacion = Ev.Criterio.Modo_Verificacion;
                    Estandar.SubEstandar.Criterio.Id_Criterio = Ev.Criterio.Pk_Id_Criterio;
                    Estandar.SubEstandar.Criterio.Evaluacion = new EDEvaluacionEstandarMinimo();

                    int valoracion = Ev.Fk_Id_Config_Valoracion_SubEstand;
                    int valoracionEv = Ev.Fk_Id_Config_Valoracion_SubEstand;
                    bool planmejora = false;
                    var Ev1 = (from s in context.Tbl_Valoracion_Criterios
                               join d in context.Tbl_Config_Valoracion_SubEstandares on s.Pk_Id_Valoracion_Criterio equals d.Fk_Id_Valoracion_Criterio
                               where d.Pk_Id_Config_Valoracion_SubEstand == valoracion
                               select s).FirstOrDefault<Valoracion_Criterio>();
                    if (Ev1 != null)
                    {
                        valoracionEv = Ev1.Pk_Id_Valoracion_Criterio;
                        if (valoracionEv == 1)
                        {
                            //Cumple
                            Estandar.SubEstandar.Criterio.Evaluacion.IdValoracionCriterio = valoracionEv;
                        }
                        if (valoracionEv == 2)
                        {
                            //No cumple y tiene planes de mejora
                            planmejora = true;
                            Estandar.SubEstandar.Criterio.Evaluacion.IdValoracionCriterio = valoracionEv;
                        }
                        if (valoracionEv == 3)
                        {
                            //No aplica
                            var Ev2 = (from s in context.Tbl_Config_Valoracion_SubEstandares
                                       where s.Pk_Id_Config_Valoracion_SubEstand == valoracion
                                       select s).FirstOrDefault<Config_Valoracion_SubEstand>();
                            if (Ev2 != null)
                            {
                                Estandar.SubEstandar.Criterio.Evaluacion.IdValoracionCriterio = Ev2.Id_Dpendiente ?? int.MinValue;
                            }
                        }
                    }
                    Estandar.SubEstandar.Criterio.Evaluacion.Justificacion = Ev.Justificacion;
                    Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1 = Ev.NombreArchivo1;
                    Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2 = Ev.NombreArchivo2;
                    Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3 = Ev.NombreArchivo3;
                    Estandar.SubEstandar.Criterio.Evaluacion.Filedownload1 = Ev.NombreArchivo1_download;
                    Estandar.SubEstandar.Criterio.Evaluacion.Filedownload2 = Ev.NombreArchivo2_download;
                    Estandar.SubEstandar.Criterio.Evaluacion.Filedownload3 = Ev.NombreArchivo3_download;
                    Estandar.SubEstandar.Criterio.Evaluacion.Ruta1 = Ev.Ruta1;
                    Estandar.SubEstandar.Criterio.Evaluacion.Ruta2 = Ev.Ruta2;
                    Estandar.SubEstandar.Criterio.Evaluacion.Ruta3 = Ev.Ruta3;

                    Estandar.SubEstandar.Criterio.Evaluacion.Actividades = new List<EDActividad>();
                    if (planmejora)
                    {
                        //Plan de Mejora
                        List<Actividad_Criterio> ListaActs = new List<Actividad_Criterio>();
                        ListaActs = Ev.ActividadesCriterio.ToList();
                        if (ListaActs != null)
                        {
                            if (ListaActs.Count > 0)
                            {
                                foreach (var item in ListaActs)
                                {
                                    EDActividad EDActividad = new EDActividad();
                                    EDActividad.Descripcion = item.Actividad.Descripcion;
                                    EDActividad.Id_Actividad = item.Actividad.Pk_Id_Actividad;
                                    EDActividad.Responsable = item.Actividad.Responsable;
                                    EDActividad.FechaFin = item.Actividad.FechaFin;
                                    Estandar.SubEstandar.Criterio.Evaluacion.Actividades.Add(EDActividad);
                                }
                            }
                        }
                    }

                }
            }
            return Estandar;
        }
        public EDEvaluacionEstandarMinimo EditarEvaluacionEstandar(EDEvaluacionEstandarMinimo EvaluacionEdicion)
        {
            Evaluacion_Estandar_Minimo EvaluacionEditar = new Evaluacion_Estandar_Minimo();
            EvaluacionEdicion.GuardadoArchivos = false;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                var empr = (from eval in context.Tbl_Empresas_Evaluar
                            join emp in context.Tbl_Empresa on eval.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                            where emp.Nit_Empresa.Trim().Equals(EvaluacionEdicion.Nit.Trim())
                            select eval).FirstOrDefault();
                if (empr == null)
                {
                    var empresa = context.Tbl_Empresa.Where(e => e.Nit_Empresa.Trim().Equals(EvaluacionEdicion.Nit.Trim())).Select(e => e).FirstOrDefault();
                    if (empresa != null)
                    {
                        var empEval = new Empresa_Evaluar();
                        empEval.Fk_Id_Empresa = empresa.Pk_Id_Empresa;
                        empEval.Fecha_Diligencia_Eval_EstMin = DateTime.Now;
                        context.Tbl_Empresas_Evaluar.Add(empEval);
                        empr = empEval;
                        context.SaveChanges();
                    }
                }

                var evalu = (from eval in context.Tbl_Evaluacion_Estandares_Minimos
                             where eval.Fk_Id_Criterio == EvaluacionEdicion.IdCriterio && eval.Fk_Id_EvaluacionEmpresa == EvaluacionEdicion.IdEvaluacion
                             select eval).FirstOrDefault();



                var Evalempr = (from s in context.Tbl_EvaluacionEmpresa
                                where s.Pk_Id_EvaluacionEmpresa == EvaluacionEdicion.IdEvaluacion
                                select s).FirstOrDefault<EvaluacionEmpresa>();


                // EvaluacionEstandar.IdEmpresaEvaluar = empr.Pk_Id_Empresa_Evaluar;
                using (var Transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int codjustifica = 0;
                        Config_Valoracion_SubEstand Configuracion = null;
                        //Obtenemos el id del subestandar que se esta evaluando de acuerdo al criterio
                        var idSubEStandar = context.Tbl_Criterios.Where(c => c.Pk_Id_Criterio == EvaluacionEdicion.IdCriterio).Select(c => c.Fk_Id_SubEstandar).FirstOrDefault();

                        //Se verifica si la valoracion es no aplica, si as asi se debe verificar si el no aplica viene con justificacion
                        if (EvaluacionEdicion.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.NoAplica)
                        {
                            if (string.IsNullOrEmpty(EvaluacionEdicion.Justificacion))
                                codjustifica = (int)EnumPlanificacion.ValoracionStandares.NoJustifica;
                            else
                                codjustifica = (int)EnumPlanificacion.ValoracionStandares.Justifica;
                        }
                        else
                        {
                            evalu.NombreArchivo1 = null;
                            evalu.NombreArchivo2 = null;
                            evalu.NombreArchivo3 = null;

                            evalu.Ruta1 = null;
                            evalu.Ruta2 = null;
                            evalu.Ruta3 = null;

                            evalu.NombreArchivo1_download = null;
                            evalu.NombreArchivo2_download = null;
                            evalu.NombreArchivo3_download = null;
                        }

                        //Obtenemos el id de la configuracion que tiene el valor de calificacion
                        if (codjustifica > 0)
                            Configuracion = context.Tbl_Config_Valoracion_SubEstandares.Where(cf => cf.Fk_Id_SubEstandar == idSubEStandar
                                                                                               && cf.Fk_Id_Valoracion_Criterio == EvaluacionEdicion.IdValoracionCriterio
                                                                                               && cf.Id_Dpendiente == codjustifica)
                                                                                          .Select(cf => cf).FirstOrDefault();
                        else
                            Configuracion = context.Tbl_Config_Valoracion_SubEstandares.Where(cf => cf.Fk_Id_SubEstandar == idSubEStandar
                                                                                               && cf.Fk_Id_Valoracion_Criterio == EvaluacionEdicion.IdValoracionCriterio)
                                                                                          .Select(cf => cf).FirstOrDefault();
                        if (Configuracion.Pk_Id_Config_Valoracion_SubEstand > 0)
                        {
                            decimal valorCriterio = context.Tbl_Criterios.Where(cr => cr.Pk_Id_Criterio == EvaluacionEdicion.IdCriterio).Select(cr => cr.Valor).FirstOrDefault();
                            if (Configuracion.Valor < 1)
                                valorCriterio = 0;

                            evalu.Fk_Id_Config_Valoracion_SubEstand = Configuracion.Pk_Id_Config_Valoracion_SubEstand;
                            evalu.Valor_Calificacion = Configuracion.Valor;
                            evalu.Fk_Id_Config_Valoracion_SubEstand = Configuracion.Pk_Id_Config_Valoracion_SubEstand;


                            Evaluacion_Estandar_Minimo evaluacion = new Evaluacion_Estandar_Minimo
                            {
                                Fk_Id_Config_Valoracion_SubEstand = Configuracion.Pk_Id_Config_Valoracion_SubEstand,
                                Fk_Id_Criterio = EvaluacionEdicion.IdCriterio,
                                Fk_Id_Empresa_Evaluar = 0,
                                Valor_Calificacion = valorCriterio,
                                Fk_Id_EvaluacionEmpresa = Evalempr.Pk_Id_EvaluacionEmpresa
                            };

                            if (codjustifica == (int)EnumPlanificacion.ValoracionStandares.Justifica)
                            {
                                evalu.Justificacion = EvaluacionEdicion.Justificacion;
                                evaluacion.Justificacion = EvaluacionEdicion.Justificacion;

                                evalu.NombreArchivo1 = EvaluacionEdicion.NombreArchivo1;
                                evalu.NombreArchivo2 = EvaluacionEdicion.NombreArchivo2;
                                evalu.NombreArchivo3 = EvaluacionEdicion.NombreArchivo3;

                                evalu.Ruta1 = EvaluacionEdicion.Ruta1;
                                evalu.Ruta2 = EvaluacionEdicion.Ruta2;
                                evalu.Ruta3 = EvaluacionEdicion.Ruta3;

                                evalu.NombreArchivo1_download = EvaluacionEdicion.Filedownload1;
                                evalu.NombreArchivo2_download = EvaluacionEdicion.Filedownload2;
                                evalu.NombreArchivo3_download = EvaluacionEdicion.Filedownload3;
                                EvaluacionEdicion.GuardadoArchivos = true;
                            }
                            else
                            {
                                evalu.NombreArchivo1 = null;
                                evalu.NombreArchivo2 = null;
                                evalu.NombreArchivo3 = null;

                                evalu.Ruta1 = null;
                                evalu.Ruta2 = null;
                                evalu.Ruta3 = null;

                                evalu.NombreArchivo1_download = null;
                                evalu.NombreArchivo2_download = null;
                                evalu.NombreArchivo3_download = null;


                                evalu.Justificacion = null;
                                evaluacion.Justificacion = null;
                            }

                            EvaluacionEdicion.IdEvalEstandarMinimo = evalu.Pk_Id_Eval_Estandar_Minimo;
                            EvaluacionEdicion.IdCiclo = evalu.Criterio.SubEstandar.Estandar.Ciclo.Pk_Id_Ciclo;
                            EvaluacionEdicion.IdEmpresaEvaluar = evalu.EvaluacionEmpresa.Empresa.Pk_Id_Empresa;






                            //context.Tbl_Evaluacion_Estandares_Minimos.Add(evaluacion);
                            // context.SaveChanges();
                            context.Entry(evalu).State = EntityState.Modified;
                            context.SaveChanges();


                            List<ActividadEvaluacion> ListaActividadesEd = new List<ActividadEvaluacion>();
                            var acts = (from actis in context.Tbl_Actividades_Criterio
                                        where actis.Fk_Id_Eval_Estandar_Minimo == evalu.Pk_Id_Eval_Estandar_Minimo
                                        select actis).ToList();
                            if (acts != null)
                            {
                                foreach (var item in acts)
                                {
                                    if (item.Actividad != null)
                                    {
                                        ListaActividadesEd.Add(item.Actividad);
                                    }
                                }
                            }



                            if (EvaluacionEdicion.IdValoracionCriterio == (int)EnumPlanificacion.ValoracionStandares.NoCumple)
                            {



                                foreach (var actividad in EvaluacionEdicion.Actividades)
                                {
                                    //Identificar operación
                                    string tipoop = actividad.Accion;
                                    string opid = actividad.Id_Actividad_String;
                                    //Nueva Actividad
                                    if (tipoop == "nuevo")
                                    {
                                        ActividadEvaluacion act = new ActividadEvaluacion
                                        {
                                            Descripcion = actividad.Descripcion,
                                            Responsable = actividad.Responsable,
                                            FechaFin = actividad.FechaFin,
                                            EvaluacionCerrado = false
                                        };
                                        context.Tbl_Actividades_Evaluacion.Add(act);
                                        context.SaveChanges();
                                        Actividad_Criterio accr = new Actividad_Criterio
                                        {
                                            Fk_Id_Actividad = act.Pk_Id_Actividad,
                                            Fk_Id_Eval_Estandar_Minimo = evalu.Pk_Id_Eval_Estandar_Minimo
                                        };
                                        context.Tbl_Actividades_Criterio.Add(accr);
                                        context.SaveChanges();
                                    }
                                    //Editar Actividad
                                    if (tipoop == "editado")
                                    {
                                        int idActint = 0;
                                        if (int.TryParse(opid, out idActint))
                                        {
                                            ActividadEvaluacion ActEd = ListaActividadesEd.Where(s => s.Pk_Id_Actividad == idActint).FirstOrDefault();
                                            if (ActEd != null)
                                            {
                                                bool cambio = false;
                                                if (ActEd.Descripcion != actividad.Descripcion)
                                                {
                                                    ActEd.Descripcion = actividad.Descripcion;
                                                    cambio = true;
                                                }
                                                if (ActEd.Responsable != actividad.Responsable)
                                                {
                                                    ActEd.Responsable = actividad.Responsable;
                                                    cambio = true;
                                                }
                                                if (ActEd.FechaFin != actividad.FechaFin)
                                                {
                                                    ActEd.FechaFin = actividad.FechaFin;
                                                    cambio = true;
                                                }
                                                if (cambio)
                                                {
                                                    context.Entry(ActEd).State = EntityState.Modified;
                                                    context.SaveChanges();
                                                }
                                            }
                                        }
                                    }
                                    //Eliminar Actividad
                                    if (tipoop == "eliminado")
                                    {
                                        int idActint = 0;
                                        if (int.TryParse(opid, out idActint))
                                        {
                                            ActividadEvaluacion ActEd = ListaActividadesEd.Where(s => s.Pk_Id_Actividad == idActint).FirstOrDefault();
                                            if (ActEd != null)
                                            {
                                                var actsElim = (from actis in context.Tbl_Actividades_Criterio
                                                                where actis.Fk_Id_Actividad == ActEd.Pk_Id_Actividad
                                                                select actis).ToList();
                                                if (actsElim != null)
                                                {
                                                    foreach (var item in actsElim)
                                                    {
                                                        context.Entry(item).State = EntityState.Deleted;
                                                        context.SaveChanges();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item in ListaActividadesEd)
                                {
                                    var actsElim = (from actis in context.Tbl_Actividades_Criterio
                                                    where actis.Fk_Id_Actividad == item.Pk_Id_Actividad
                                                    select actis).ToList();
                                    foreach (var item1 in actsElim)
                                    {
                                        context.Entry(item1).State = EntityState.Deleted;
                                    }
                                }
                                context.SaveChanges();
                            }
                        }
                        else
                            return EvaluacionEdicion;
                        Transaction.Commit();


                    }
                    catch (Exception ex)
                    {
                        EvaluacionEdicion.GuardadoArchivos = false;
                        Transaction.Rollback();
                    }
                }
            }
            return EvaluacionEdicion;
        }
        /// <summary>
        /// Obtiene una lista de estandares según el ciclo en evaluación
        /// </summary>
        /// <param name="idCiclo"></param>
        /// <param name="Nit"></param>
        /// /// <param name="IdEval"></param>
        /// <returns></returns>
        public List<EDEstandar> ListaEstandarEditar(int idCiclo, string Nit, int IdEval)
        {
            List<EDEstandar> ListaEstandares = new List<EDEstandar>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var estandar = (from est in context.Tbl_Estandares
                                join sub in context.Tbl_SubEstandares on est.Pk_Id_Estandar equals sub.Fk_Id_Estandar
                                join crit in context.Tbl_Criterios on sub.Pk_Id_SubEstandar equals crit.Fk_Id_SubEstandar
                                join eva in context.Tbl_Evaluacion_Estandares_Minimos on crit.Pk_Id_Criterio equals eva.Fk_Id_Criterio
                                where eva.Fk_Id_EvaluacionEmpresa == IdEval && est.Fk_Id_Ciclo == idCiclo
                                select est).ToList().Distinct().ToList();
                foreach (var item in estandar)
                {
                    EDEstandar EDEstandar = new EDEstandar();
                    EDEstandar.Descripcion = item.Descripcion;
                    EDEstandar.Id_Estandar = item.Pk_Id_Estandar;
                    EDEstandar.Porcentaje_Max = item.Porcentaje_Max;
                    EDEstandar.SubEstandares = new List<EDSubEstandar>();
                    foreach (var item1 in item.SubEstandares)
                    {
                        EDSubEstandar EDSubEstandar = new EDSubEstandar();
                        EDSubEstandar.Descripcion = item1.Descripcion;
                        EDSubEstandar.Descripcion_Corta = item1.Descripcion_Corta;
                        EDSubEstandar.Procentaje_Max = item1.Procentaje_Max;
                        EDSubEstandar.Descripcion = item1.Descripcion;
                        EDSubEstandar.Id_SubEstandar = item1.Pk_Id_SubEstandar;
                        EDSubEstandar.Criterios = new List<EDCriterio>();
                        foreach (var item2 in item1.Criterios)
                        {
                            EDCriterio EDCriterio = new EDCriterio();
                            EDCriterio.Descripcion = item2.Descripcion;
                            EDCriterio.Descripcion_Corta = item2.Descripcion_Corta;
                            EDCriterio.Numeral = item2.Numeral;
                            EDCriterio.Marco_Legal = item2.Marco_Legal;
                            EDCriterio.Modo_Verificacion = item2.Modo_Verificacion;
                            EDCriterio.ValPorPregunta = item2.Valor.ToString();
                            EDCriterio.Numeral = item2.Numeral;
                            EDCriterio.Id_Criterio = item2.Pk_Id_Criterio;
                            EDCriterio.Evaluaciones = new List<EDEvaluacionEstandarMinimo>();
                            foreach (var item3 in item2.EvaluacionEstandaresMinimos)
                            {
                                if (item3.Fk_Id_EvaluacionEmpresa == IdEval)
                                {
                                    EDEvaluacionEstandarMinimo EDEvaluacionEstandarMinimo = new EDEvaluacionEstandarMinimo();
                                    EDEvaluacionEstandarMinimo.IdCriterio = item3.Fk_Id_Criterio;
                                    EDEvaluacionEstandarMinimo.Justificacion = item3.Justificacion;
                                    EDEvaluacionEstandarMinimo.IdEvalEstandarMinimo = item3.Pk_Id_Eval_Estandar_Minimo;
                                    EDEvaluacionEstandarMinimo.Respuesta = item3.Config_Valoracion_SubEstand.Valoracion_Criterio.Descripcion;
                                    EDEvaluacionEstandarMinimo.NombreArchivo1 = item3.NombreArchivo1;
                                    EDEvaluacionEstandarMinimo.NombreArchivo2 = item3.NombreArchivo2;
                                    EDEvaluacionEstandarMinimo.NombreArchivo3 = item3.NombreArchivo3;

                                    EDEvaluacionEstandarMinimo.Ruta1 = item3.Ruta1;
                                    EDEvaluacionEstandarMinimo.Ruta2 = item3.Ruta2;
                                    EDEvaluacionEstandarMinimo.Ruta3 = item3.Ruta3;

                                    int calificacion = item3.Config_Valoracion_SubEstand.Fk_Id_Valoracion_Criterio;




                                    if (calificacion == (int)EnumPlanificacion.ValoracionStandares.CumpleTotalMente)
                                    {
                                        EDEvaluacionEstandarMinimo.Respuesta = "Cumple totalmente";

                                    }
                                    if (calificacion == (int)EnumPlanificacion.ValoracionStandares.NoAplica)
                                    {
                                        EDEvaluacionEstandarMinimo.Respuesta = "No aplica";
                                        if (item3.Config_Valoracion_SubEstand.Id_Dpendiente != null)
                                        {
                                            int padre = item3.Config_Valoracion_SubEstand.Id_Dpendiente ?? int.MinValue;
                                            if (padre == (int)EnumPlanificacion.ValoracionStandares.Justifica)
                                            {
                                                EDEvaluacionEstandarMinimo.Respuesta = "No aplica - Justifica";
                                            }
                                            if (padre == (int)EnumPlanificacion.ValoracionStandares.NoJustifica)
                                            {
                                                EDEvaluacionEstandarMinimo.Respuesta = "No aplica - No justifica";
                                            }
                                        }
                                    }
                                    if (calificacion == (int)EnumPlanificacion.ValoracionStandares.NoCumple)
                                    {
                                        EDEvaluacionEstandarMinimo.Respuesta = "No cumple";
                                    }

                                    EDCriterio.Evaluaciones.Add(EDEvaluacionEstandarMinimo);
                                }
                            }
                            EDSubEstandar.Criterios.Add(EDCriterio);
                        }
                        EDEstandar.SubEstandares.Add(EDSubEstandar);
                    }
                    ListaEstandares.Add(EDEstandar);
                }
            }
            return ListaEstandares;
        }
        public List<int> ListaCriteriosAnteriores(int IdEval, int Ciclo)
        {
            List<int> ListaCriterios = new List<int>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var criterios = (from eval in context.Tbl_Evaluacion_Estandares_Minimos
                                 join crit in context.Tbl_Criterios on eval.Fk_Id_Criterio equals crit.Pk_Id_Criterio
                                 join sub in context.Tbl_SubEstandares on crit.Fk_Id_SubEstandar equals sub.Pk_Id_SubEstandar
                                 join est in context.Tbl_Estandares on sub.Fk_Id_Estandar equals est.Pk_Id_Estandar
                                 where eval.Fk_Id_EvaluacionEmpresa == IdEval && est.Fk_Id_Ciclo == Ciclo
                                 select eval).ToList().Distinct();
                if (criterios != null)
                {
                    foreach (var item in criterios)
                    {
                        ListaCriterios.Add(item.Fk_Id_Criterio);
                    }
                    return ListaCriterios;
                }
            }
            return null;
        }
        public void AsignarConsecutivo(int Pk_Id_Empresa)
        {
            List<int> Vigencias = new List<int>();
            List<int> VigenciasNoduplicado = new List<int>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var evals = (from s in context.Tbl_EvaluacionEmpresa
                             where s.Fk_Id_Empresa == Pk_Id_Empresa
                             select s).ToList<EvaluacionEmpresa>();

                if (evals != null)
                {
                    evals = evals.OrderBy(s => s.Pk_Id_EvaluacionEmpresa).ToList();
                    foreach (var item in evals)
                    {
                        Vigencias.Add(item.Vigencia);
                    }
                    VigenciasNoduplicado = Vigencias.Distinct().ToList();
                    foreach (var item in VigenciasNoduplicado)
                    {
                        var evalsvig = evals.Where(s => s.Vigencia == item).ToList();
                        if (evalsvig != null)
                        {
                            int n = 1;
                            foreach (var item1 in evalsvig)
                            {
                                item1.Consecutivo = n.ToString();
                                context.Entry(item1).State = EntityState.Modified;
                                try
                                {
                                    context.SaveChanges();
                                }
                                catch (Exception)
                                {
                                }
                                n++;
                            }
                        }
                    }
                }
            }
        }
        public int AsignarConsecutivo1(int Pk_Id_Empresa)
        {
            List<string> ListaConsecutivos = new List<string>();
            List<int> ListaTransformado = new List<int>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var evals = (from s in context.Tbl_EvaluacionEmpresa
                             where s.Fk_Id_Empresa == Pk_Id_Empresa
                             select s).ToList<EvaluacionEmpresa>();

                if (evals != null)
                {
                    evals = evals.OrderBy(s => s.Pk_Id_EvaluacionEmpresa).ToList();

                    foreach (var item in evals)
                    {
                        ListaConsecutivos.Add(item.Consecutivo);
                    }
                    foreach (var item in ListaConsecutivos)
                    {
                        int cons = 0;
                        if (int.TryParse(item, out cons))
                        {
                            ListaTransformado.Add(cons);
                        }
                        else
                        {
                            ListaTransformado.Add(1);
                        }
                    }
                    int numeromayor = 1;
                    foreach (var item in ListaTransformado)
                    {
                        if (item > numeromayor)
                        {
                            numeromayor = item;
                        }
                    }
                    if (ListaTransformado.Count != 0)
                    {
                        numeromayor++;
                        return numeromayor;
                    }
                    else
                    {
                        return numeromayor;
                    }

                }
                else
                {
                    return 1;
                }
            }
            return 1;
        }
        public bool ComprobarConsecutivo(int Pk_Id_Empresa)
        {
            List<int> Vigencias = new List<int>();
            List<int> VigenciasNoduplicado = new List<int>();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                var evals = (from s in context.Tbl_EvaluacionEmpresa
                             where s.Fk_Id_Empresa == Pk_Id_Empresa
                             select s).ToList<EvaluacionEmpresa>();

                if (evals != null)
                {
                    evals = evals.OrderBy(s => s.Fecha_Elab).ToList();
                    foreach (var item in evals)
                    {
                        Vigencias.Add(item.Vigencia);
                    }
                    VigenciasNoduplicado = Vigencias.Distinct().ToList();
                    foreach (var item in VigenciasNoduplicado)
                    {
                        var evalsvig = evals.Where(s => s.Vigencia == item).ToList();
                        List<int> consecutivos = new List<int>();
                        if (evalsvig != null)
                        {

                            foreach (var item1 in evalsvig)
                            {
                                int consint = 0;
                                if (!int.TryParse(item1.Consecutivo, out consint))
                                {
                                    return true;
                                }
                                consecutivos.Add(consint);
                            }
                        }
                        consecutivos.Sort();
                        int n = 1;
                        for (int i = 0; i < consecutivos.Count; i++)
                        {
                            if (consecutivos[i] != n)
                            {
                                return true;
                            }
                            n++;
                        }
                    }
                }
            }
            return false;

        }
        public List<EDEvaluacionEmpresa> EvaluacionCompleta(string Nit, int IdEval)
        {
            List<EDCiclo> Ciclos = ObtenerCiclos();


            List<EDEvaluacionEmpresa> ListaEvaluacion = new List<EDEvaluacionEmpresa>();
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evalempresa = (from s in db.Tbl_EvaluacionEmpresa
                                   join e in db.Tbl_Empresa on s.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                   where e.Nit_Empresa == Nit & s.Pk_Id_EvaluacionEmpresa == IdEval
                                   select s).ToList<EvaluacionEmpresa>();


                if (evalempresa != null)
                {
                    if (evalempresa.Count != 0)
                    {

                        EDEvaluacionEmpresa Evaluacion = new EDEvaluacionEmpresa();
                        Evaluacion.Consecutivo = evalempresa[0].Consecutivo;
                        Evaluacion.Estado = evalempresa[0].Estado;
                        Evaluacion.Fecha_Elab = evalempresa[0].Fecha_Elab;
                        Evaluacion.Pk_Id_EvaluacionEmpresa = evalempresa[0].Pk_Id_EvaluacionEmpresa;
                        Evaluacion.Vigencia = evalempresa[0].Vigencia;
                        Evaluacion.ListaCiclos = new List<EDCiclo>();

                        foreach (var item in Ciclos)
                        {
                            EDCiclo CicloEv = new EDCiclo();

                            CicloEv.Id_Ciclo = item.Id_Ciclo;
                            CicloEv.Nombre = item.Nombre;
                            CicloEv.Porcentaje_Max = item.Porcentaje_Max;
                            CicloEv.StandPorEvaluar = ObtenerCantidaEstdPorEvaluas(item.Id_Ciclo, evalempresa[0].Pk_Id_EvaluacionEmpresa, IdEval);
                            CicloEv.CantidadCriterios = ObtenerCantidadCriteriosPorEstandar(item.Id_Ciclo);
                            CicloEv.Estandares = ListaEstandarEditar(item.Id_Ciclo, Nit, IdEval);
                            Evaluacion.ListaCiclos.Add(CicloEv);
                        }
                        ListaEvaluacion.Add(Evaluacion);

                    }
                }
            }
            return ListaEvaluacion;

        }
        public List<EDEvaluacionEmpresa> Evaluacion(int Idempresa, int IdEval)
        {
            List<EDCiclo> Ciclos = ObtenerCiclos();


            List<EDEvaluacionEmpresa> ListaEvaluacion = new List<EDEvaluacionEmpresa>();
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evalempresa = (from s in db.Tbl_EvaluacionEmpresa
                                   where s.Fk_Id_Empresa == Idempresa & s.Pk_Id_EvaluacionEmpresa == IdEval
                                   select s).ToList<EvaluacionEmpresa>();
                if (evalempresa != null)
                {
                    if (evalempresa.Count != 0)
                    {

                        EDEvaluacionEmpresa Evaluacion = new EDEvaluacionEmpresa();
                        Evaluacion.Consecutivo = evalempresa[0].Consecutivo;
                        Evaluacion.Estado = evalempresa[0].Estado;
                        Evaluacion.Fecha_Elab = evalempresa[0].Fecha_Elab;
                        Evaluacion.Pk_Id_EvaluacionEmpresa = evalempresa[0].Pk_Id_EvaluacionEmpresa;
                        Evaluacion.Fk_Id_Empresa = evalempresa[0].Fk_Id_Empresa;
                        Evaluacion.Vigencia = evalempresa[0].Vigencia;
                        Evaluacion.ListaCiclos = new List<EDCiclo>();

                        foreach (var item in Ciclos)
                        {
                            EDCiclo CicloEv = new EDCiclo();
                            CicloEv.Id_Ciclo = item.Id_Ciclo;
                            CicloEv.Nombre = item.Nombre;
                            CicloEv.Porcentaje_Max = item.Porcentaje_Max;
                            CicloEv.StandPorEvaluar = ObtenerCantidaEstdPorEvaluas(item.Id_Ciclo, evalempresa[0].Pk_Id_EvaluacionEmpresa, IdEval);
                            CicloEv.CantidadCriterios = ObtenerCantidadCriteriosPorEstandar(item.Id_Ciclo);
                            CicloEv.Estandares = ListaEstandarEditar(item.Id_Ciclo, "", IdEval);
                            Evaluacion.ListaCiclos.Add(CicloEv);
                        }
                        ListaEvaluacion.Add(Evaluacion);

                    }
                }
            }
            return ListaEvaluacion;

        }
        public bool EliminarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            List<Actividad_Criterio> ListaActividades = new List<Actividad_Criterio>();
            List<ActividadEvaluacion> ListaActividadesEval = new List<ActividadEvaluacion>();
            List<Evaluacion_Estandar_Minimo> ListaEvEstmin = new List<Evaluacion_Estandar_Minimo>();



            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evalempresa = (from s in db.Tbl_EvaluacionEmpresa
                                   where s.Fk_Id_Empresa == EDEvaluacionEmpresa.Fk_Id_Empresa & s.Pk_Id_EvaluacionEmpresa == EDEvaluacionEmpresa.Pk_Id_EvaluacionEmpresa
                                   select s).FirstOrDefault<EvaluacionEmpresa>();
                if (evalempresa != null)
                {
                    var evalmin = (from s in db.Tbl_Evaluacion_Estandares_Minimos
                                   where s.Fk_Id_EvaluacionEmpresa == evalempresa.Pk_Id_EvaluacionEmpresa
                                   select s).ToList<Evaluacion_Estandar_Minimo>();

                    if (evalmin != null)
                    {
                        ListaEvEstmin = evalmin.ToList();
                        foreach (var item in ListaEvEstmin)
                        {
                            var Actividades = item.ActividadesCriterio.ToList();
                            foreach (var item1 in Actividades)
                            {
                                ListaActividades.Add(item1);
                            }
                        }
                        foreach (var item in ListaActividades)
                        {
                            var acts = (from s in db.Tbl_Actividades_Evaluacion
                                        where s.Pk_Id_Actividad == item.Fk_Id_Actividad
                                        select s).FirstOrDefault<ActividadEvaluacion>();
                            if (acts != null)
                            {
                                ListaActividadesEval.Add(acts);
                            }
                        }
                    }


                }

                using (var Transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in ListaActividades)
                        {
                            db.Entry(item).State = EntityState.Deleted;
                        }
                        foreach (var item in ListaEvEstmin)
                        {
                            db.Entry(item).State = EntityState.Deleted;
                        }
                        foreach (var item in ListaActividadesEval)
                        {
                            db.Entry(item).State = EntityState.Deleted;
                        }
                        db.Entry(evalempresa).State = EntityState.Deleted;
                        db.SaveChanges();
                        Transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        Transaction.Rollback();
                        return false;
                    }

                }
            }
        }
        public void CambiarEstado(int idEval, int estado)
        {
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var eval = (from s in db.Tbl_EvaluacionEmpresa
                            where s.Pk_Id_EvaluacionEmpresa == idEval
                            select s).FirstOrDefault<EvaluacionEmpresa>();
                if (eval != null)
                {
                    eval.Estado = estado;
                    db.Entry(eval).State = System.Data.Entity.EntityState.Modified;
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        public int VerificarCambiarEstado(int ideval)
        {
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var eval = (from s in db.Tbl_EvaluacionEmpresa
                            where s.Pk_Id_EvaluacionEmpresa == ideval
                            select s).FirstOrDefault<EvaluacionEmpresa>();
                if (eval != null)
                {
                    bool cambioestado = false;
                    if (eval.Estado == 1 & !cambioestado)
                    {
                        List<EDCiclo> Ciclos = ObtenerCiclos();
                        int EstandEv = 0;
                        foreach (var item1 in Ciclos)
                        {
                            EstandEv = EstandEv + ObtenerCantidaEstdPorEvaluas(item1.Id_Ciclo, eval.Fk_Id_Empresa, eval.Pk_Id_EvaluacionEmpresa);
                        }
                        if (EstandEv == 0)
                        {
                            cambioestado = true;
                            eval.Estado = 2;
                            CambiarEstado(eval.Pk_Id_EvaluacionEmpresa, 2);
                        }
                    }
                    if (eval.Estado == 2 & !cambioestado)
                    {
                        List<EDCiclo> Ciclos = ObtenerCiclos();
                        int EstandEv = 0;
                        foreach (var item1 in Ciclos)
                        {
                            EstandEv = EstandEv + ObtenerCantidaEstdPorEvaluas(item1.Id_Ciclo, eval.Fk_Id_Empresa, eval.Pk_Id_EvaluacionEmpresa);
                        }
                        if (EstandEv != 0)
                        {
                            cambioestado = true;
                            eval.Estado = 1;
                            CambiarEstado(eval.Pk_Id_EvaluacionEmpresa, 1);
                        }
                    }
                    if (eval.Estado == 3 & !cambioestado)
                    {

                    }


                    return eval.Estado;
                }
            }
            return -1;
        }
        public string CerrarEvaluacion(int IdEval, int idempresa)
        {
            int vigencia = 0;
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var eval = (from s in db.Tbl_EvaluacionEmpresa
                            where s.Pk_Id_EvaluacionEmpresa == IdEval && s.Fk_Id_Empresa == idempresa
                            select s).FirstOrDefault<EvaluacionEmpresa>();
                if (eval != null)
                {
                    vigencia = eval.Vigencia;
                    var evals = (from s in db.Tbl_EvaluacionEmpresa
                                 where s.Vigencia == vigencia && s.Fk_Id_Empresa == idempresa && s.Estado == 3
                                 select s).ToList<EvaluacionEmpresa>();
                    if (evals != null)
                    {
                        if (evals.Count > 0)
                        {
                            return "Existe";
                        }
                        else
                        {
                            eval.Estado = 3;


                            var evals_mins = (from s in db.Tbl_Evaluacion_Estandares_Minimos
                                              where s.Fk_Id_EvaluacionEmpresa == IdEval
                                              select s).ToList<Evaluacion_Estandar_Minimo>();
                            if (evals_mins != null)
                            {
                                foreach (var item in evals_mins)
                                {
                                    var evals_mins1 = (from s in db.Tbl_Actividades_Evaluacion
                                                       join d in db.Tbl_Actividades_Criterio on s.Pk_Id_Actividad equals d.Fk_Id_Actividad
                                                       where d.Fk_Id_Eval_Estandar_Minimo == item.Pk_Id_Eval_Estandar_Minimo
                                                       select s).ToList<ActividadEvaluacion>().Distinct().ToList();
                                    if (evals_mins1 != null)
                                    {
                                        foreach (var item1 in evals_mins1)
                                        {
                                            item1.EvaluacionCerrado = true;
                                            db.Entry(item1).State = System.Data.Entity.EntityState.Modified;
                                        }
                                    }
                                }
                            }

                            db.Entry(eval).State = System.Data.Entity.EntityState.Modified;
                            try
                            {
                                db.SaveChanges();
                                return "Cerrada";
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        eval.Estado = 3;
                        db.Entry(eval).State = System.Data.Entity.EntityState.Modified;
                        try
                        {
                            db.SaveChanges();
                            return "Cerrada";
                        }
                        catch (Exception)
                        {
                        }
                    }

                }
            }

            return "";
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

            }
            return cantidad;
        }
        public List<EDEvaluacionEmpresa> ObtenerCalificacionEstandresPorClicloComparar(string Nit, int fi, int ff)
        {
            List<EDCiclo> Ciclos = ObtenerCiclos();
            List<EDEvaluacionEmpresa> ListaEvaluacion = new List<EDEvaluacionEmpresa>();
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evalempresa = (from s in db.Tbl_EvaluacionEmpresa
                                   join e in db.Tbl_Empresa on s.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                   where e.Nit_Empresa == Nit && s.Vigencia >= fi && s.Vigencia <= ff && s.Estado == 3
                                   select s).ToList<EvaluacionEmpresa>();


                if (evalempresa != null)
                {
                    if (evalempresa.Count != 0)
                    {
                        foreach (var eval in evalempresa)
                        {
                            EDEvaluacionEmpresa Evaluacion = new EDEvaluacionEmpresa();
                            Evaluacion.Consecutivo = eval.Consecutivo;
                            Evaluacion.Estado = eval.Estado;
                            Evaluacion.Fecha_Elab = eval.Fecha_Elab;
                            Evaluacion.Pk_Id_EvaluacionEmpresa = eval.Pk_Id_EvaluacionEmpresa;
                            Evaluacion.Vigencia = eval.Vigencia;
                            Evaluacion.ListaCiclos = new List<EDCiclo>();
                            Evaluacion.ValoracionFinal = new EDValoracionFinal();
                            decimal valortotal = 0;
                            foreach (var item in Ciclos)
                            {
                                EDCiclo CicloEv = new EDCiclo();
                                decimal puntoObtenidos = ObtenerPorcentajeObtenidoAlmomento(item.Id_Ciclo, Nit, eval.Pk_Id_EvaluacionEmpresa);
                                CicloEv.Id_Ciclo = item.Id_Ciclo;
                                CicloEv.Nombre = item.Nombre;
                                CicloEv.Porcentaje_Max = item.Porcentaje_Max;
                                CicloEv.StandPorEvaluar = ObtenerCantidaEstdPorEvaluas(item.Id_Ciclo, eval.Pk_Id_EvaluacionEmpresa, eval.Pk_Id_EvaluacionEmpresa);
                                CicloEv.CantidadCriterios = ObtenerCantidadCriteriosPorEstandar(item.Id_Ciclo);
                                CicloEv.Estandares = ListaEstandarEditar(item.Id_Ciclo, Nit, eval.Pk_Id_EvaluacionEmpresa);
                                CicloEv.PorcenObtenido = (puntoObtenidos * 100) / CicloEv.Porcentaje_Max;
                                CicloEv.puntoObtenidos = puntoObtenidos;
                                valortotal = valortotal + CicloEv.puntoObtenidos;


                                Evaluacion.ListaCiclos.Add(CicloEv);
                            }
                            decimal redondear = Decimal.Round(valortotal, 0, MidpointRounding.AwayFromZero);

                            var calif = (from vf in db.Tbl_Valoracion_Final
                                         where vf.Rango_Inicial <= redondear && vf.Rango_Final >= redondear
                                         select vf).FirstOrDefault<Valoracion_Final>();
                            if (calif != null)
                            {
                                Evaluacion.ValoracionFinal.Valoracion = calif.Valoracion;
                            }
                            ListaEvaluacion.Add(Evaluacion);
                        }
                    }
                }
            }
            return ListaEvaluacion;
        }
        public EDEmpresa Identidadempresa(string Nit)
        {
            EDEmpresa EDEmpresa = new EDEmpresa();

            using (SG_SSTContext db = new SG_SSTContext())
            {
                var empresa = (from s in db.Tbl_Empresa
                               where s.Nit_Empresa == Nit
                               select s).FirstOrDefault<Empresa>();
                if (empresa != null)
                {
                    EDEmpresa.RazonSocial = empresa.Razon_Social;
                }
            }
            return EDEmpresa;
        }
        public EDEvaluacionEmpresa ObtenerVigenciayFechaElab(string Nit, int IdEval)
        {
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evaluacion = (from s in db.Tbl_EvaluacionEmpresa
                                  join d in db.Tbl_Empresa on s.Fk_Id_Empresa equals d.Pk_Id_Empresa
                                  where d.Nit_Empresa == Nit && s.Pk_Id_EvaluacionEmpresa == IdEval
                                  select s).FirstOrDefault<EvaluacionEmpresa>();
                if (evaluacion != null)
                {
                    EDEvaluacionEmpresa EDEvaluacionEmpresa = new EDEvaluacionEmpresa();
                    EDEvaluacionEmpresa.Vigencia= evaluacion.Vigencia;
                    EDEvaluacionEmpresa.Fecha_Elab = evaluacion.Fecha_Elab;
                    return EDEvaluacionEmpresa;
                }
            }
            return null;
        }


        public bool verificarcriterio(int IdCriterio, int IdEval)
        {
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evaluacion = (from s in db.Tbl_Evaluacion_Estandares_Minimos
                                  where s.Fk_Id_Criterio==IdCriterio && s.Fk_Id_EvaluacionEmpresa == IdEval
                                  select s).FirstOrDefault<Evaluacion_Estandar_Minimo>();
                if (evaluacion != null)
                {
                    return true;
                }
            }
            return false;
        }
        public bool verificarevaluacion(int IdEmpresa, int IdEval)
        {
            using (SG_SSTContext db = new SG_SSTContext())
            {
                var evaluacion = (from s in db.Tbl_EvaluacionEmpresa
                                  where s.Fk_Id_Empresa == IdEmpresa
                                  select s).FirstOrDefault<EvaluacionEmpresa>();
                if (evaluacion != null)
                {
                    if (evaluacion.Pk_Id_EvaluacionEmpresa== IdEval)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
