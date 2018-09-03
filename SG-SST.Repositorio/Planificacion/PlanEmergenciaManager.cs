using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Models;
using SG_SST.Models.Emergencias;
using SG_SST.Audotoria;
using SG_SST.Interfaces.Planificacion;
namespace SG_SST.Repositorio.Planificacion
{
  public class PlanEmergenciaManager:IPlanEmergencia
    {

      public bool InsertarCargueMasivoBDInterna(List<EDDatosCarguePlanEmergencia> datosBDInterna, int sede)
      {
          using (SG_SSTContext context = new SG_SSTContext())
          {
              using (var transaction = context.Database.BeginTransaction())
              {
                  RegistraLog registraLog = new RegistraLog();
                  try
                  {

                      var del = context.Tbl_Eme_bd_Interna.Where(x => x.fk_id_sede == sede).ToList();
                      if (context != null)
                      {
                          context.Tbl_Eme_bd_Interna.RemoveRange(del);
                          context.SaveChanges();
                      }

                      foreach (EDDatosCarguePlanEmergencia datoBI in datosBDInterna)
                      {

                         Eme_bd_Interna datosBD = new Eme_bd_Interna

                         
                          { 
                              fk_id_sede=datoBI.idSede,
                              nombre= datoBI.nombreCompleto,
                              numdocumento=datoBI.numeroDocumeto,
                              genero=datoBI.genero,
                              eps=datoBI.eps,
                              rh=datoBI.rh,
                              contacto_nombre=datoBI.nombreContacto,
                              contacto_telefono=datoBI.telefonoContacto,
                              contacto_parentesco=datoBI.paremtescoContacto,
                              requiere_manejo=datoBI.requiereManejo,
                              cual_manejo=datoBI.cual
               
                              
                          };

                         ;
                         context.Tbl_Eme_bd_Interna.Add(datosBD);
                          context.SaveChanges();
                      }
                      transaction.Commit();
                      return true;

                  }

                  catch (Exception ex)
                  {
                      registraLog.RegistrarError(typeof(DxGralCondicionesDeSaludManager), string.Format("Error al guardar  la BDInterna Plan Emergencia  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                      transaction.Rollback();

                      return false;
                  }
              }
          }
      }


      public bool InsertarCargueMasivoBDExterna(List<EDDatosCarguePlanEmergencia> datosBDExterna, int sede)
      {
          using (SG_SSTContext context = new SG_SSTContext())
          {
              using (var transaction = context.Database.BeginTransaction())
              {
                  RegistraLog registraLog = new RegistraLog();
                  try
                  {

                      var del = context.Tbl_Eme_Bd_Externa.Where(x => x.fk_id_sede == sede).ToList();
                      if (context != null)
                      {
                          context.Tbl_Eme_Bd_Externa.RemoveRange(del);
                          context.SaveChanges();
                      }

                      foreach (EDDatosCarguePlanEmergencia datoBE in datosBDExterna)
                      {

                          Eme_Bd_Externa datosBD = new Eme_Bd_Externa


                          {
                              fk_id_sede = datoBE.idSede,
                              entidad = datoBE.entidad,
                              direccion = datoBE.direccion,
                              telefono = datoBE.telefonoContacto,
                              nombre_contacto = datoBE.nombreContacto,
                              NitEmpresa = datoBE.nitEmpresa
                              

                          };

                          
                          context.Tbl_Eme_Bd_Externa.Add(datosBD);
                          context.SaveChanges();
                      }
                      transaction.Commit();
                      return true;

                  }

                  catch (Exception ex)
                  {
                      registraLog.RegistrarError(typeof(DxGralCondicionesDeSaludManager), string.Format("Error al guardar  la BDExerna Plan Emergencia  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                      transaction.Rollback();

                      return false;
                  }
              }
          }
      }

      public bool InsertarCargueMasivoBDPlanAyuda(List<EDDatosCarguePlanEmergencia> datosBDPlanAyuda, int sede)
      {
          using (SG_SSTContext context = new SG_SSTContext())
          {
              using (var transaction = context.Database.BeginTransaction())
              {
                  RegistraLog registraLog = new RegistraLog();
                  try
                  {

                      var del = context.Tbl_Eme_PlanAyuda.Where(x => x.fk_id_sede == sede).ToList();
                      if (context != null)
                      {
                          context.Tbl_Eme_PlanAyuda.RemoveRange(del);
                          context.SaveChanges();
                      }

                      foreach (EDDatosCarguePlanEmergencia datoBPA in datosBDPlanAyuda)
                      {

                          Eme_PlanAyuda datosBD = new Eme_PlanAyuda


                          {
                              fk_id_sede = datoBPA.idSede,
                              empresa=datoBPA.empresaParticipante,
                              recurso=datoBPA.recursoDisposicion,
                              compensacion=datoBPA.compesacionEconomica,
                              reintegro=datoBPA.reintegroRecurso,
                              nombre_contacto=datoBPA.nombreContacto,
                              telefono_contacto=datoBPA.telefonoContacto,
                              NitEmpresa=datoBPA.nitEmpresa
                            

                          };


                          context.Tbl_Eme_PlanAyuda.Add(datosBD);
                          context.SaveChanges();
                      }
                      transaction.Commit();
                      return true;

                  }

                  catch (Exception ex)
                  {
                      registraLog.RegistrarError(typeof(DxGralCondicionesDeSaludManager), string.Format("Error al guardar  la BDPlanAYuda Plan Emergencia  {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                      transaction.Rollback();

                      return false;
                  }
              }
          }
      }


    }
}
