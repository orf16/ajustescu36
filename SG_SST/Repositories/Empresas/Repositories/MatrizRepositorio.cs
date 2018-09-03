﻿// <copyright file="MatrizRepositorio.cs" company="Ada SA">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Cristian Mauricio Arenas Gomez.</author>
// <date>26/01/2017</date>
// <summary>Clase que contiene toda la implementacion de la Interfaz MatrizRepositorio y repositorio para las
// la gestion del analisis de la matriz DOFA y PEST</summary>

namespace SG_SST.Repositories.Empresas.Repositories
{
    using SG_SST.Models;
    using SG_SST.Models.Empresas;
    using SG_SST.Repositories.Empresas.IRepositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.Entity;
    using SG_SST.EntidadesDominio.Auditoria;
    using SG_SST.Repositorio.AuditoriaSistema;

    public class MatrizRepositorio : IMatrizRepositorio
    {
        SG_SSTContext db;
        AuditoriaSistemaManager auditoriaSistema = new AuditoriaSistemaManager();
        public MatrizRepositorio()
        {
            db = new SG_SSTContext();
        }



        public List<TipoAnalisis> ObtenerTiposDeAnalisis()
        {
            return db.Tbl_Tipo_Analisis.ToList();
        }

        public List<TipoElementoAnalisis> ObtenerTipoElementosPorAnalissis(int Pk_TipoAnalisis)
        {
            return db.Tbl_Tipo_Elemento_Analisis.Where(tpe => tpe.FK_Tipo_Analisis == Pk_TipoAnalisis).ToList();

        }


        public ElementoMatriz AgregarElementoMatriz(ElementoMatriz elementoMatriz, int Pk_Id_Empresa, EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    int pk_IdEmpresa = Pk_Id_Empresa;
                    Matriz matriz = db.Tbl_Matriz.Where(m => m.FK_Empresa == pk_IdEmpresa).FirstOrDefault();
                    //Preguntamos si el elemento de la matriz tiene id de la matriz si lo tiene lo agregamos o sino 
                    // creamos la matriz                 
                    if (matriz == null)
                    {
                        matriz = new Matriz();
                        matriz.Empresa = db.Tbl_Empresa.Find(pk_IdEmpresa);
                        matriz.ElementosMatriz = new List<ElementoMatriz>();
                        matriz.ElementosMatriz.Add(elementoMatriz);
                        /*inicio auditoria*/
                        int tipoMatriz = db.Tbl_Tipo_Elemento_Analisis.Find(elementoMatriz.FK_TipoElementoAnalisis).FK_Tipo_Analisis;
                        if (tipoMatriz == 1)
                        {
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {

                                db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_DOFA,
                                     matriz.ToString()));
                            }
                        }
                        else
                        {
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {

                                db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_PEST,
                                     matriz.ToString()));
                            }
                        }
                        /*fin auditoria*/
                        db.Tbl_Matriz.Add(matriz);
                    }
                    else
                    {
                        elementoMatriz.FK_Matriz = matriz.PK_Matriz;
                        /*inicio auditoria*/
                        int tipoMatriz = db.Tbl_Tipo_Elemento_Analisis.Find(elementoMatriz.FK_TipoElementoAnalisis).FK_Tipo_Analisis;
                        if (tipoMatriz == 1)
                        {
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {

                                db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_DOFA,
                                     elementoMatriz.ToString()));
                            }
                        }
                        else
                        {
                            if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                            {

                                db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                     Enumeraciones.EnumAuditoriaSistema.Acciones.CREACION,
                                     Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                     Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                     Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_PEST,
                                     elementoMatriz.ToString()));
                            }
                        }
                        /*fin auditoria*/
                        db.Tbl_Elemento_Matriz.Add(elementoMatriz);
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    return elementoMatriz;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return elementoMatriz;
                }
            }
        }


        public bool EliminarElementoMatriz(int Pk_ElementoMatriz, EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    ElementoMatriz elementoAEliminar = db.Tbl_Elemento_Matriz.Find(Pk_ElementoMatriz);
                    /*inicio auditoria*/
                    int tipoMatriz = db.Tbl_Tipo_Elemento_Analisis.Find(elementoAEliminar.FK_TipoElementoAnalisis).FK_Tipo_Analisis;
                    if (tipoMatriz == 1)
                    {
                        if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                        {

                            db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                 Enumeraciones.EnumAuditoriaSistema.Acciones.ELIMINACION,
                                 Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                 Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                 Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_DOFA,
                                 elementoAEliminar.ToString()));
                        }
                    }
                    else
                    {
                        if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                        {

                            db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                 Enumeraciones.EnumAuditoriaSistema.Acciones.ELIMINACION,
                                 Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                 Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                 Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_PEST,
                                 elementoAEliminar.ToString()));
                        }
                    }
                    /*fin auditoria*/
                    db.Tbl_Elemento_Matriz.Remove(elementoAEliminar);
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

        public List<ElementoMatriz> ObtenerElementosMatriz(int PkTipoAnalisis, string Nit_Empresa)
        {
            string nit = Nit_Empresa;
            List<Matriz> matrizList = db.Tbl_Matriz.Include(m => m.ElementosMatriz)
                                                   .Where(m => m.Empresa.Nit_Empresa == nit).ToList();
            if (matrizList.Count() > 0 && matrizList.FirstOrDefault().ElementosMatriz != null)
            {
                return matrizList.FirstOrDefault().ElementosMatriz.Where(e => e.TipoElementoAnalisis.FK_Tipo_Analisis == PkTipoAnalisis).ToList();
            }
            return new List<ElementoMatriz>();
        }



        public ElementoMatriz GrabarElementoMatrizEdicion(ElementoMatriz elementoMatriz,EDInformacionAuditoria edInfoauditoria)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    ElementoMatriz ElementoAModificar = db.Tbl_Elemento_Matriz.Find(elementoMatriz.PK_Elemento_Matriz);
                    /*inicio auditoria*/
                    int tipoMatriz = db.Tbl_Tipo_Elemento_Analisis.Find(ElementoAModificar.FK_TipoElementoAnalisis).FK_Tipo_Analisis;
                    if (tipoMatriz == 1)
                    {
                        if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                        {

                            db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                 Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                                 Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                 Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                 Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_DOFA,
                                 ElementoAModificar.ToString()));
                        }
                    }
                    else
                    {
                        if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaLiderazgoGerencial)
                        {

                            db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                                 Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                                 Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                                 Enumeraciones.EnumAuditoriaSistema.SubModulos.Consideraciones_internas_y_externas,
                                 Enumeraciones.EnumAuditoriaSistema.Opciones.Crear_PEST,
                                 ElementoAModificar.ToString()));
                        }
                    }
                    /*fin auditoria*/
                    ElementoAModificar.Descripcion_Elemento = elementoMatriz.Descripcion_Elemento;
                    db.Entry(ElementoAModificar).State = EntityState.Modified;
                    db.SaveChanges();
                    transaction.Commit();
                    return elementoMatriz;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return elementoMatriz;
                }
            }
        }









        /// <summary>
        /// consulta para retonar elemeto de la matriz DOFA - PARA EDITAR
        /// </summary>
        /// <param name="Pk_elementoMatriz"></param>
        /// <returns></returns>
        public string ObtenerElementoDofa(int Pk_elementoMatriz)
        {
            string Elemento_Dofa = "";
            var ElementoDofa = db.Tbl_Elemento_Matriz.Where(g => g.PK_Elemento_Matriz == Pk_elementoMatriz);
            if (ElementoDofa != null)
            {
                try
                {
                    return Elemento_Dofa = ElementoDofa.FirstOrDefault().Descripcion_Elemento;
                }
                catch (Exception)
                {
                    return "";
                }
            }
            return Elemento_Dofa;
        }















    }
}



