// <copyright file="GobiernoController.cs" company="Ada SA">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Robinson Correa</author>
// <date>03/01/2017</date>
// <summary>Controlador que gestiona la mision de la empresa</summary>

namespace SG_SST.Repositories.Empresas.Repositories
{
    using SG_SST.Models;
    using SG_SST.Models.Empresas;
    using SG_SST.Repositories.Empresas.IRepositories;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using SG_SST.EntidadesDominio.Auditoria;
    using SG_SST.Repositorio.AuditoriaSistema;
    //pilas con los nombres en la interface y en el repositorio
    public class GobiernoRepositorio : IGobiernoRepositorio
    {
        SG_SSTContext db;
        AuditoriaSistemaManager auditoriaSistema = new AuditoriaSistemaManager();

        public GobiernoRepositorio()
        {
            db = new SG_SSTContext();
        }
        public GobiernoRepositorio(SG_SSTContext db)
        {
            this.db = db;
        }

        internal SG_SST.Repositories.Empresas.IRepositories.IGobiernoRepositorio IGobiernoRepositorio
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void GrabarGobierno(Gobierno gobierno,int Pk_Id_Empresa,EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    
                    gobierno.Fk_Id_Empresa =Pk_Id_Empresa;
                    /*inicio auditoria*/
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {
                        
                        db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.Mision,
                             gobierno.ToString()));
                    }
                    /*fin auditoria*/
                    db.Tbl_Gobierno.Add(gobierno);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    
                }
           
            }
        }
        public void GrabarGobiernoV(Gobierno gobiernov, int Pk_Id_Empresa, int Nit_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
           using (var transaction =db.Database.BeginTransaction())
            try
            {
                gobiernov.Fk_Id_Empresa = Pk_Id_Empresa;
                /*inicio auditoria*/
                if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                {

                    db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                         Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                         Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                         Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                         Enumeraciones.EnumAuditoriaSistema.Opciones.Vision,
                         gobiernov.ToString()));
                }
                /*fin auditoria*/
                gobiernov.Nit_Empresa = Nit_Empresa;
                db.Tbl_Gobierno.Add(gobiernov);
                db.SaveChanges();
                transaction.Commit();
            }
            catch(Exception)
            {
                transaction.Rollback();

            }
        }

        public Gobierno ObtenerGobierno(int Pk_Id_Empresa)
        {
            //Entity FrameWork           
            Gobierno gb = db.Tbl_Gobierno.Where(g => g.Fk_Id_Empresa == Pk_Id_Empresa).FirstOrDefault();           
            return gb; 
        }


        public bool ModficarGobierno(Gobierno gobierno, EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {
                        SG_SSTContext dbaud = new SG_SSTContext();
                        Gobierno gb = dbaud.Tbl_Gobierno.Find(gobierno.Pk_Id_Gobierno);
                        db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.Mision,
                             gb.ToString()));
                    }
                    /*fin auditoria*/
                    db.Entry(gobierno).State = EntityState.Modified;
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public bool ModficarGobiernov(Gobierno gobiernov, EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    /*inicio auditoria*/
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {
                        SG_SSTContext dbaud = new SG_SSTContext();
                        Gobierno gb = dbaud.Tbl_Gobierno.Find(gobiernov.Pk_Id_Gobierno);
                        db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.Vision,
                             gb.ToString()));
                    }
                    /*fin auditoria*/
                    db.Entry(gobiernov).State = EntityState.Modified;
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public string ObtenerMisionEmpresa(int Pk_Id_Empresa)
        {
            string mision = "";
            var gobiernos = db.Tbl_Gobierno.Where(p => p.Fk_Id_Empresa == Pk_Id_Empresa).ToList();            
            if (gobiernos.Count > 0)
            {
                mision = gobiernos.FirstOrDefault().Mision;
            }
          
            return mision;
        }
        public string ObtenerVisionEmpresa(int Pk_Id_Empresa)
        {
            string vision = "";
            var gobiernos = db.Tbl_Gobierno.Where(p => p.Fk_Id_Empresa == Pk_Id_Empresa).ToList();
            //var gobiernos = db.Tbl_Gobierno.Where(g => g.Nit_Empresa == nit).ToList();
            if (gobiernos.Count > 0)
            {
                vision = gobiernos.FirstOrDefault().Vision;
            }
            return vision;
        }
        public bool EliminarMision(int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Gobierno gbv = db.Tbl_Gobierno.First(g => g.Fk_Id_Empresa == (Pk_Id_Empresa));
                    //inicio auditoria
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {                       
                        db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.Mision,
                             gbv.ToString()));
                    }
                    //fin auditoria
                    gbv.Mision = "";
                    db.Entry(gbv).State = EntityState.Modified;
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public bool EliminarVision(int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Gobierno gbv = db.Tbl_Gobierno.First(g => g.Fk_Id_Empresa == (Pk_Id_Empresa));
                    //inicio auditoria
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                    {
                        db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.Vision,
                             gbv.ToString()));
                    }
                    //fin auditoria
                    gbv.Vision = "";
                    db.Entry(gbv).State = EntityState.Modified;
                    db.SaveChanges();
                    transaction.Commit();
                    
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
                
            }
        }

        public bool GrabarProceso(Proceso proceso)
        {
            using (var transaction = db.Database.BeginTransaction())
                try
                {

                    proceso.Descripcion_Proceso = "Mapa Proceso Empresa";
                    db.Tbl_Procesos.Add(proceso);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }

        }


    }
}