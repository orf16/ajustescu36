

namespace SG_SST.Repositories.LiderazgoGerencial.Repositories
{
    using SG_SST.Models;
    using SG_SST.Models.Empresas;
    using SG_SST.Models.LiderazgoGerencial;
    using SG_SST.Repositories.LiderazgoGerencial.IRepositories;
    //using SG_SST.Utilidades.Traza;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.Entity;
    using SG_SST.EntidadesDominio.Auditoria;
    using SG_SST.Repositorio.AuditoriaSistema;
    public class RolPorResponsabilidadRepositorio : IRolPorResponsabilidadRepositorio
    {
        SG_SSTContext db;
        AuditoriaSistemaManager auditoriaSistema = new AuditoriaSistemaManager();

        public RolPorResponsabilidadRepositorio()
        {
            db = new SG_SSTContext();
        }

        public RolPorResponsabilidadRepositorio(SG_SSTContext db)
        {
            this.db = db;
        }

        public bool GuardarRolYResponsabilidades(Rol DescripRol, List<Responsabilidades> responsabilidad, List<RendicionDeCuentas> rendicion,
            int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Rol rol = new Rol();
                    List<Responsabilidades> respons = new List<Responsabilidades>();
                    List<RendicionDeCuentas> rendic = new List<RendicionDeCuentas>();
                    ResponsabilidadesPorRol responsabilidadesPorRol = new ResponsabilidadesPorRol();
                    RendicionDeCuentasPorRol rendicionDeCuentasPorRol = new RendicionDeCuentasPorRol();
                    rol.ResponsabilidadesPorRoles = new List<ResponsabilidadesPorRol>();
                    rol.RendicionDeCuentasPorRoles = new List<RendicionDeCuentasPorRol>();
                    rol.Descripcion = DescripRol.Descripcion.ToUpper();
                    rol.Fk_Id_Empresa = Pk_Id_Empresa;

                    foreach (var rpr in responsabilidad)
                    {
                        Responsabilidades resp = new Responsabilidades();
                        resp.ResponsabilidadesPorRoles = new List<ResponsabilidadesPorRol>();
                        ResponsabilidadesPorRol rxrol = new ResponsabilidadesPorRol();
                        rxrol.Rol = rol;
                        resp.ResponsabilidadesPorRoles.Add(rxrol);
                        resp.Descripcion = rpr.Descripcion;
                       
                        respons.Add(resp);

                    }

                    foreach (var rendpr in rendicion)
                    {
                        RendicionDeCuentas rend = new RendicionDeCuentas();
                        rend.RendicionDeCuentasPorRoles = new List<RendicionDeCuentasPorRol>();
                        RendicionDeCuentasPorRol rendxrol = new RendicionDeCuentasPorRol();
                        rendxrol.Rol = rol;
                        rend.RendicionDeCuentasPorRoles.Add(rendxrol);
                        rend.Descripcion = rendpr.Descripcion;
                        rendic.Add(rend);

                    }

                    db.Tbl_Responsabilidades.AddRange(respons);
                    db.Tbl_RendicionDeCuentas.AddRange(rendic);
                    /*inicio auditoria*/
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {
                        db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.CrearRol,
                             rol.ToString()));
                    }
                    /*fin auditoria*/
                    //db.Tbl_Rol.Add(rol);
                    db.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    //RegistroInformacion.EnviarError<Rol>(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool EditarRolYResponsabilidades(Rol rol, List<Responsabilidades> responsabilidad, List<RendicionDeCuentas> rendicionDeCuenta, int[] responsaEliminadas,
            int[] rendiciEliminadas, int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            SG_SSTContext dbaud = new SG_SSTContext();
             using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    rol.Fk_Id_Empresa = Pk_Id_Empresa;
                    db.Entry(rol).State = EntityState.Modified;
                    foreach (var item in responsabilidad)
                    {
                        if (item.Pk_Id_Responsabilidades != 0)
                        {
                            /*inicio auditoria*/
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {
                                Responsabilidades resaudi = dbaud.Tbl_Responsabilidades.Find(item.Pk_Id_Responsabilidades);
                                db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.ModificarResponsabilidad,
                                     resaudi.ToString()));
                            }
                            /*fin auditoria*/
                            db.Entry(item).State = EntityState.Modified;
                        }
                        else
                        {
                            ResponsabilidadesPorRol responsabilidadesPorRoles = new ResponsabilidadesPorRol();
                            db.Tbl_Responsabilidades.Add(item);
                            /*inicio auditoria*/
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {                                
                                db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.CrearResponsabilidad,
                                     item.ToString()));
                            }
                            /*fin auditoria*/
                            responsabilidadesPorRoles.Fk_Id_Rol = rol.Pk_Id_Rol;
                            responsabilidadesPorRoles.Fk_Id_Responsabilidades = item.Pk_Id_Responsabilidades;
                            db.Tbl_Responsabilidades_Por_Rol.Add(responsabilidadesPorRoles);
                            db.SaveChanges();
                        }
                    }
                    foreach (var item in rendicionDeCuenta)
                    {
                        if (item.Pk_Id_RendicionDeCuentas != 0)
                        {
                            /*inicio auditoria*/
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {
                                RendicionDeCuentas rescuentaaudi = dbaud.Tbl_RendicionDeCuentas.Find(item.Pk_Id_RendicionDeCuentas);
                                db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.ModificarRendicionDeCuenta,
                                     rescuentaaudi.ToString()));
                            }
                            /*fin auditoria*/
                            db.Entry(item).State = EntityState.Modified;
                        }
                        else
                        {
                            db.Tbl_RendicionDeCuentas.Add(item);
                            /*inicio auditoria*/
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {                                
                                db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.CrearRendicionDeCuenta,
                                     item.ToString()));
                            }
                            /*fin auditoria*/
                            RendicionDeCuentasPorRol rendicionDeCuentasPorRol = new RendicionDeCuentasPorRol();
                            rendicionDeCuentasPorRol.Fk_Id_Rol = rol.Pk_Id_Rol;
                            rendicionDeCuentasPorRol.Fk_Id_RendicionDeCuentas = item.Pk_Id_RendicionDeCuentas;
                            db.Tbl_Rendicion_Cuenta_Por_Rol.Add(rendicionDeCuentasPorRol);
                            db.SaveChanges();
                        }
                    }
                    if (responsaEliminadas != null)
                    {
                        foreach (var item in responsaEliminadas)
                        {
                            Responsabilidades respon = db.Tbl_Responsabilidades.Find(item);
                            /*inicio auditoria*/
                                if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                                {                                
                                    db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                         Enumeraciones.EnumAuditoriaSistema.Acciones.ELIMINACION,
                                         Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                         Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                         Enumeraciones.EnumAuditoriaSistema.Opciones.EliminarResponsabilidad,
                                         respon.ToString()));
                                }
                            /*fin auditoria*/
                            db.Tbl_Responsabilidades.Remove(respon);
                        }
                    }
                    if (rendiciEliminadas != null)
                    {
                        foreach (var item in rendiciEliminadas)
                        {
                            RendicionDeCuentas rendi = db.Tbl_RendicionDeCuentas.Find(item);
                            /*inicio auditoria*/
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {
                                db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.EliminarRendicionDeCuenta,
                                     item.ToString()));
                            }
                            /*fin auditoria*/
                            db.Tbl_RendicionDeCuentas.Remove(rendi);
                        }
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    //RegistroInformacion.EnviarError<Rol>(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool EliminarRolYResponsabilidades(int id, EDInformacionAuditoria edInfoauditoria)
        {

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    List<RendicionDeCuentas> rendicionDeCuentas = new List<RendicionDeCuentas>();
                    List<RendicionDeCuentasPorRol> rendPorRol = db.Tbl_Rendicion_Cuenta_Por_Rol
                        .Where(r => r.Fk_Id_Rol == id).ToList();
                    foreach (var rddc in rendPorRol)
                    {
                        /*inicio auditoria*/
                        if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                        {
                            db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                 Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                                 Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                 Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                 Enumeraciones.EnumAuditoriaSistema.Opciones.EliminarRendicionDeCuenta,
                                 rddc.RendicionDeCuentas.ToString()));
                        }
                        /*fin auditoria*/
                        rendicionDeCuentas.Add(rddc.RendicionDeCuentas);
                    }
                    List<Responsabilidades> responsabilidadades = new List<Responsabilidades>();
                    List<ResponsabilidadesPorRol> respPorRol = db.Tbl_Responsabilidades_Por_Rol
                        .Where(r => r.Fk_Id_Rol == id).ToList();
                    foreach (var rpcr in respPorRol)
                    {
                        /*inicio auditoria*/
                        if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                        {
                            db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                                 Enumeraciones.EnumAuditoriaSistema.Acciones.ELIMINACION,
                                 Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                                 Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                                 Enumeraciones.EnumAuditoriaSistema.Opciones.EliminarResponsabilidad,
                                 rpcr.Responsabilidades.ToString()));
                        }
                        /*fin auditoria*/
                        responsabilidadades.Add(rpcr.Responsabilidades);
                    }                    
                    Rol rol = db.Tbl_Rol.Find(id);
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {
                        db.Tbl_AuditoriaLiderazgoGerencialSistema.Add(auditoriaSistema.ObtenerAuditoriaLiderazgoGerencial(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.ELIMINACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Liderazgo_Gerencial,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Roles_y_Responsabilidades_SST,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.EliminarRol,
                             rol.ToString()));
                    }
                    List<UsuarioRol> usuarioRol = new List<UsuarioRol>();
                    usuarioRol = db.Tbl_UsuarioRol.Where(er => er.Fk_Id_Rol == rol.Pk_Id_Rol).ToList();
                    db.Tbl_Rol.Remove(rol);
                    db.Tbl_UsuarioRol.RemoveRange(usuarioRol);
                    db.Tbl_Responsabilidades.RemoveRange(responsabilidadades);
                    db.Tbl_RendicionDeCuentas.RemoveRange(rendicionDeCuentas);
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    //RegistroInformacion.EnviarError<Rol>(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool CrearRolYResponsabilidadesPreestablecidos(int id)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    List<Rol> roles = new List<Rol>();
                    roles = db.Tbl_Rol
                        .Include(r => r.ResponsabilidadesPorRoles)
                        .Include(z => z.RendicionDeCuentasPorRoles)
                        .Where(x => x.Fk_Id_Empresa.Equals(null)).ToList();
                    foreach (var adr in roles)
                    {
                        Rol rol = new Rol();
                        List<Responsabilidades> respons = new List<Responsabilidades>();
                        List<RendicionDeCuentas> rendic = new List<RendicionDeCuentas>();
                        ResponsabilidadesPorRol responsabilidadesPorRol = new ResponsabilidadesPorRol();
                        RendicionDeCuentasPorRol rendicionDeCuentasPorRol = new RendicionDeCuentasPorRol();
                        rol.ResponsabilidadesPorRoles = new List<ResponsabilidadesPorRol>();
                        rol.RendicionDeCuentasPorRoles = new List<RendicionDeCuentasPorRol>();
                        rol.Descripcion = adr.Descripcion;
                        rol.Fk_Id_Empresa = id;
                        List<ResponsabilidadesPorRol> ResponsabilidPorRol = new List<ResponsabilidadesPorRol>();
                        List<RendicionDeCuentasPorRol> RendicionPorRol = new List<RendicionDeCuentasPorRol>();
                        ResponsabilidPorRol = adr.ResponsabilidadesPorRoles.ToList();
                        RendicionPorRol = adr.RendicionDeCuentasPorRoles.ToList();

                        foreach (var rpr in ResponsabilidPorRol)
                        {
                            Responsabilidades resp = new Responsabilidades();
                            resp.ResponsabilidadesPorRoles = new List<ResponsabilidadesPorRol>();
                            ResponsabilidadesPorRol rxrol = new ResponsabilidadesPorRol();
                            resp.Descripcion = rpr.Responsabilidades.Descripcion;                    
                            rxrol.Rol = rol;
                            resp.ResponsabilidadesPorRoles.Add(rxrol);
                            respons.Add(resp);

                        }                
                        db.Tbl_Responsabilidades.AddRange(respons);
                        foreach(var rcpr in RendicionPorRol)
                        {
                            RendicionDeCuentas rend = new RendicionDeCuentas();
                            rend.RendicionDeCuentasPorRoles = new List<RendicionDeCuentasPorRol>();
                            RendicionDeCuentasPorRol rdxrol = new RendicionDeCuentasPorRol();
                            rend.Descripcion = rcpr.RendicionDeCuentas.Descripcion;
                            rdxrol.Rol = rol;
                            rend.RendicionDeCuentasPorRoles.Add(rdxrol);
                            rendic.Add(rend);
                        }
                        db.Tbl_RendicionDeCuentas.AddRange(rendic);
                    }                       
                    db.SaveChanges();
                     transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    //RegistroInformacion.EnviarError<Rol>(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public List<Rol> RolesPorEmpresa(int Pk_Id_Empresa)
        {
            return db.Tbl_Rol
                .Include(r => r.ResponsabilidadesPorRoles)
                .Include(r => r.RendicionDeCuentasPorRoles)
                .Where(s => s.Fk_Id_Empresa == Pk_Id_Empresa).ToList();

        }

        public List<ObligacionesArl> GetObligacionesArl()
        {
            return db.Tbl_Obligaciones_Arl.ToList();
        }

        public List<ObligacionesEmpleadores> GetObligacionesEmpleadores()
        {
            return db.Tbl_Obligaciones_Empleadores.ToList();
        }
    }
}