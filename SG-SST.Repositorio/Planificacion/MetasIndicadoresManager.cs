using SG_SST.Audotoria;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Interfaces.Planificacion;
using SG_SST.Models;
using SG_SST.Models.Planificacion;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Repositorio.Planificacion
{
    public class MetasIndicadoresManager : IMetasIndicadores
    {
        public List<EDIndicador> ObtenerIndicadoresPorTipo(string tipo)
        {
            List<EDIndicador> Indicadores = null;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        Indicadores = (from ind in context.Tbl_Indicador
                                       where ind.Tipo == tipo
                                       select new EDIndicador
                                         {
                                             PK_Id_Indicador = ind.PK_Id_Indicador,
                                             Nombre = ind.Nombre,
                                             Tipo = ind.Tipo,
                                             Unidad = ind.Unidad,
                                             Frecuencia = ind.Frecuencia
                                         }).ToList();
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al obtener los indicadores  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
            return Indicadores;
        }

        public EDIndicador ObtenerIndicadorPorId(int IdIndicador)
        {
            EDIndicador indicador = null;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        indicador = (from ind in context.Tbl_Indicador
                                     where ind.PK_Id_Indicador == IdIndicador
                                       select new EDIndicador
                                       {
                                           PK_Id_Indicador = ind.PK_Id_Indicador,
                                           Nombre = ind.Nombre,
                                           Tipo = ind.Tipo,
                                           Unidad = ind.Unidad,
                                           Frecuencia = ind.Frecuencia
                                       }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al obtener el indicador  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
            return indicador;
        }

        public List<EDMetaIndicador> ObtenerMetasIndicadoresPorEmpresa(int id)
        {
            List<EDMetaIndicador> MetasIndicadores = null;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        MetasIndicadores = (from metI in context.Tbl_MetaIndicador
                                             where metI.FK_Empresa == id
                                             select new EDMetaIndicador
                                             {
                                                 PK_Id_MetaIndicador = metI.PK_Id_MetaIndicador,
                                                 FK_Empresa = metI.FK_Empresa,
                                                 FK_Indicador = metI.FK_Indicador,
                                                 ValorRojo = metI.ValorRojo,
                                                 ValorAmarillo = metI.ValorAmarillo,
                                                 ValorVerde = metI.ValorVerde,
                                                 ValorMeta = metI.ValorMeta,
                                                 Indicador = (from ind in context.Tbl_Indicador
                                                              where ind.PK_Id_Indicador == metI.FK_Indicador
                                                              select new EDIndicador
                                                              {
                                                                  PK_Id_Indicador = ind.PK_Id_Indicador,
                                                                  Nombre = ind.Nombre,
                                                                  Tipo = ind.Tipo,
                                                                  Unidad = ind.Unidad,
                                                                  Frecuencia = ind.Frecuencia
                                             }).FirstOrDefault()
                                             }).ToList();
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al Obtener las metas de los indicadores  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
            return MetasIndicadores;
        }

        public EDMetaIndicador ObtenerMetaIndicadorPorId(int id)
        {
            EDMetaIndicador MetaIndicador = null;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        MetaIndicador = (from metI in context.Tbl_MetaIndicador
                                            where metI.PK_Id_MetaIndicador == id
                                            select new EDMetaIndicador
                                            {
                                                PK_Id_MetaIndicador = metI.PK_Id_MetaIndicador,
                                                FK_Empresa = metI.FK_Empresa,
                                                FK_Indicador = metI.FK_Indicador,
                                                ValorRojo = metI.ValorRojo,
                                                ValorAmarillo = metI.ValorAmarillo,
                                                ValorVerde = metI.ValorVerde,
                                                ValorMeta = metI.ValorMeta,
                                                Indicador = (from ind in context.Tbl_Indicador
                                                             where ind.PK_Id_Indicador == metI.FK_Indicador
                                                             select new EDIndicador
                                                             {
                                                                 PK_Id_Indicador = ind.PK_Id_Indicador,
                                                                 Nombre = ind.Nombre,
                                                                 Tipo = ind.Tipo,
                                                                 Unidad = ind.Unidad,
                                                                 Frecuencia = ind.Frecuencia
                                                             }).FirstOrDefault()
                                            }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al Obtener la meta del indicador  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
            return MetaIndicador;
        }

        public EDMetaIndicador GuardarMetaIndicador(EDMetaIndicador metaInd)
        {
            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        var yaExiste = (from m in context.Tbl_MetaIndicador
                                        where m.FK_Indicador == metaInd.FK_Indicador
                                        && m.FK_Empresa == metaInd.FK_Empresa
                                        select m);

                        if (yaExiste.Count() == 0)
                        {
                            MetaIndicador part = new MetaIndicador()
                            {
                                FK_Indicador = metaInd.FK_Indicador,
                                FK_Empresa = metaInd.FK_Empresa,
                                ValorMeta = metaInd.ValorMeta,
                                ValorRojo = metaInd.ValorRojo,
                                ValorAmarillo = metaInd.ValorAmarillo,
                                ValorVerde = metaInd.ValorVerde
                            };
                            context.Tbl_MetaIndicador.Add(part);
                        }

                        context.SaveChanges();
                        Transaction.Commit();

                        var metaRegistrada = (from m in context.Tbl_MetaIndicador
                                                 where m.FK_Indicador == metaInd.FK_Indicador
                                                 && m.FK_Empresa == metaInd.FK_Empresa
                                                 select new EDMetaIndicador
                                                 {
                                                     PK_Id_MetaIndicador = m.PK_Id_MetaIndicador,
                                                     FK_Indicador = m.FK_Indicador,
                                                     FK_Empresa = m.FK_Empresa,
                                                     ValorMeta = m.ValorMeta,
                                                     ValorRojo = m.ValorRojo,
                                                     ValorAmarillo = m.ValorAmarillo,
                                                     ValorVerde = m.ValorVerde
                                                 }
                                            ).FirstOrDefault();
                        return metaRegistrada;
                    }
                    catch (Exception ex)
                    {

                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al registrar meta de indicador  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
        }

        public EDMetaIndicador ModificarMetaIndicador(EDMetaIndicador metaInd)
        {
            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        var yaExiste = (from m in context.Tbl_MetaIndicador
                                        where m.PK_Id_MetaIndicador == metaInd.PK_Id_MetaIndicador
                                        select m).First();

                        if (yaExiste != null)
                        {
                            yaExiste.ValorMeta = metaInd.ValorMeta;
                            yaExiste.ValorRojo = metaInd.ValorRojo;
                            yaExiste.ValorAmarillo = metaInd.ValorAmarillo;
                            yaExiste.ValorVerde = metaInd.ValorVerde;
                            context.Entry(yaExiste).State = EntityState.Modified;
                        }

                        context.SaveChanges();
                        Transaction.Commit();

                        var metaModificada = (from m in context.Tbl_MetaIndicador
                                              where m.PK_Id_MetaIndicador == metaInd.PK_Id_MetaIndicador
                                              select new EDMetaIndicador
                                              {
                                                  PK_Id_MetaIndicador = m.PK_Id_MetaIndicador,
                                                  FK_Indicador = m.FK_Indicador,
                                                  FK_Empresa = m.FK_Empresa,
                                                  ValorMeta = m.ValorMeta,
                                                  ValorRojo = m.ValorRojo,
                                                  ValorAmarillo = m.ValorAmarillo,
                                                  ValorVerde = m.ValorVerde
                                              }
                                            ).FirstOrDefault();
                        return metaModificada;
                    }
                    catch (Exception ex)
                    {

                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al modificar meta de indicador  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
        }

        public List<EDMetaIndicador> EliminarMetaIndicador(int IdMetaInd, int IdEmpresa)
        {
            List<EDMetaIndicador> MetasIndicadores = new List<EDMetaIndicador>();
            MetaIndicador metaBorrar = new MetaIndicador();
            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        metaBorrar = (from part in context.Tbl_MetaIndicador
                                      where part.PK_Id_MetaIndicador == IdMetaInd
                                      select part).First();

                        if (metaBorrar != null)
                        {
                            context.Tbl_MetaIndicador.Remove(metaBorrar);
                        }

                        context.SaveChanges();
                        Transaction.Commit();

                        MetasIndicadores = (from m in context.Tbl_MetaIndicador
                                              where m.FK_Empresa == IdEmpresa
                                              select new EDMetaIndicador
                                              {
                                                  PK_Id_MetaIndicador = m.PK_Id_MetaIndicador,
                                                  FK_Indicador = m.FK_Indicador,
                                                  FK_Empresa = m.FK_Empresa,
                                                  ValorMeta = m.ValorMeta,
                                                  ValorRojo = m.ValorRojo,
                                                  ValorAmarillo = m.ValorAmarillo,
                                                  ValorVerde = m.ValorVerde,
                                                  Indicador = (from ind in context.Tbl_Indicador
                                                               where ind.PK_Id_Indicador == m.FK_Indicador
                                                               select new EDIndicador
                                                               {
                                                                   PK_Id_Indicador = ind.PK_Id_Indicador,
                                                                   Nombre = ind.Nombre,
                                                                   Tipo = ind.Tipo,
                                                                   Unidad = ind.Unidad,
                                                                   Frecuencia = ind.Frecuencia
                                                               }).FirstOrDefault()
                                              }
                                            ).ToList();
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al eliminar meta de indicador  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
            return MetasIndicadores;
        }

        public EDMetaIndicador ObtenerMetaIndicadorPorNombreIndicadorYEmpresa(string indicador, int id)
        {
            EDMetaIndicador MetaIndicador = null;

            using (SG_SSTContext context = new SG_SSTContext())
            {
                using (var Transaction = context.Database.BeginTransaction())
                {
                    RegistraLog registraLog = new RegistraLog();
                    try
                    {
                        MetaIndicador = (from metI in context.Tbl_MetaIndicador
                                            join ind in context.Tbl_Indicador on metI.FK_Indicador equals ind.PK_Id_Indicador
                                            where metI.FK_Empresa == id && ind.Nombre == indicador 
                                            select new EDMetaIndicador
                                            {
                                                PK_Id_MetaIndicador = metI.PK_Id_MetaIndicador,
                                                FK_Empresa = metI.FK_Empresa,
                                                FK_Indicador = metI.FK_Indicador,
                                                ValorRojo = metI.ValorRojo,
                                                ValorAmarillo = metI.ValorAmarillo,
                                                ValorVerde = metI.ValorVerde,
                                                ValorMeta = metI.ValorMeta,
                                                Indicador =  new EDIndicador
                                                             {
                                                                 PK_Id_Indicador = ind.PK_Id_Indicador,
                                                                 Nombre = ind.Nombre,
                                                                 Tipo = ind.Tipo,
                                                                 Unidad = ind.Unidad,
                                                                 Frecuencia = ind.Frecuencia
                                                             }
                                            }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        registraLog.RegistrarError(typeof(MetasIndicadoresManager), string.Format("Error al Obtener la meta del indicador  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                        Transaction.Rollback();
                        return null;
                    }
                }
            }
            return MetaIndicador;
        }

    }
}
