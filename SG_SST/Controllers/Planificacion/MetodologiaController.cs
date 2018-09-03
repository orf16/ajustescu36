﻿// <copyright file="MetodologiaController.cs" company="Ada SA">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Cristian Mauricio Arenas Gomez</author>
// <date>04/01/2017</date>
// <summary>Controlador que me gestiona las acciones de las metologias a realizar</summary>

namespace SG_SST.Controllers.Planificacion
{
    using SG_SST.Dtos.Planificacion;
    using SG_SST.EntidadesDominio.Empresas;
    using SG_SST.Models;
    using SG_SST.Models.Empresas;
    using SG_SST.Models.Metodologia;
    using SG_SST.Models.Planificacion;
    using SG_SST.Repositories.Empresas.IRepositories;
    using SG_SST.Repositories.Empresas.Repositories;
    using SG_SST.ServiceRequest;
    using SG_SST.Services.Empresas.IServices;
    using SG_SST.Services.Empresas.Services;
    using SG_SST.Services.General.IServices;
    using SG_SST.Services.General.Services;
    using SG_SST.Services.Planificacion.IServices;
    using SG_SST.Services.Planificacion.Services;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;
    using SG_SST.EntidadesDominio.Planificacion;
    using SG_SST.Controllers.Base;
    using SG_SST.Helpers;
    using SG_SST.EntidadesDominio.Auditoria;

    [GestionAutorizacion]
    public class MetodologiaController : BaseController
    {

        private SG_SSTContext db = new SG_SSTContext();
        private IConsecuenciasServicios consecuenciasServicios = new ConsecuenciasServicios();
        private IProbabilidadesServicios probabilidadesServicios = new ProbabilidadesServicios();
        private IMetodologiaServicios metodologiaServicios = new MetodologiaServicios();
        private IRecursosServicios recursosServicios = new RecursosServicios();
        private IClasificacionDePeligrosServicios clasificacionDePeligrosServicios = new ClasificacionDePeligrosServicios();
        private INivelDeDeficienciaServicios nivelDeDeficienciaServicios = new NivelDeDeficienciaServicios();
        private IGTC45Servicio gtc45Servicio = new GTC45Servicio();
        private ISedeRepositorio sedeRepositorio = new SedeRepositorio();
        private IProcesoServicios procesoServicios = new ProcesoServicios();
        private int IDFORMULARIOGTC = Int32.Parse(ConfigurationManager.AppSettings["MetdologiaGTC45"]);
        private int IDFORMULARIORAM = Int32.Parse(ConfigurationManager.AppSettings["MetdologiaRAM"]);
        private int IDFORMULARIOINSHT = Int32.Parse(ConfigurationManager.AppSettings["MetdologiaINSHT"]);

        
        string CapacidadEmpresasSede = ConfigurationManager.AppSettings["CapacidadEmpresasSede"];

        #region Capacidades Planificaciones
        string urlPlanificacion = ConfigurationManager.AppSettings["UrlServicioPlanificacion"];
        string capacidadMetodologia = ConfigurationManager.AppSettings["CapacidadMetodologia"];
        string capacidadTiposDePeligros = ConfigurationManager.AppSettings["CapacidadTipoDePeligros"];
        string capacidadNivelesDeExposicion = ConfigurationManager.AppSettings["CapacidadNivelesDeExposicion"];
        string capacidadConsecuencias = ConfigurationManager.AppSettings["CapacidadConsecuencias"];
        string capacidadConsecuenciasPorGrupo = ConfigurationManager.AppSettings["CapacidadConsecuenciasPorGrupo"];
        string capacidadProbabilidades = ConfigurationManager.AppSettings["CapacidadProbabilidades"];
        string capacidadNivelesDeDeficiencia = ConfigurationManager.AppSettings["CapacidadNivelesDeDeficiencia"];
        string capacidadPeligro = ConfigurationManager.AppSettings["CapacidadPeligro"];

        string rutaRepositorioFile = ConfigurationManager.AppSettings["rutaRepositorioFile"];
        string rutaMPlanificacion = ConfigurationManager.AppSettings["rutaMPlanificacion"];
        string rutaOIdentificacionPeligros = ConfigurationManager.AppSettings["rutaOIdentificacionPeligros"];
        string rutaOMatrizINSHT = ConfigurationManager.AppSettings["rutaOMatrizINSHT"];
        #endregion

        // GET: Metodologia
        public ActionResult Index()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        /// <summary>
        /// controlador que retorna o obtiene una vista para seleccionar la sede y la metodologia a gestionar 
        /// </summary>
        /// <returns>vista para seleccionar la sede y la metologia</returns>
        public ActionResult GenerarMetodologia()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.PK_Metodologia = new SelectList(db.Tbl_Metodologia, "PK_Metodologia", "Descripcion_Metodologia");
            ViewBag.Pk_Id_Sede = new SelectList(sedeRepositorio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");
            return View("GenerarPeligro");           
        }

        /// <summary>
        /// controlador que retorna o obtiene una vista para agregar otro peligro 
        /// </summary>
        /// <returns>vista para seleccionar la sede y la metologia</returns>
        [AllowAnonymous]
        public ActionResult AgregarPeligro(int PK_TipoMedologia, int Pk_Sede)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.PK_Metodologia = new SelectList(db.Tbl_Metodologia, "PK_Metodologia", "Descripcion_Metodologia", PK_TipoMedologia);
            ViewBag.Pk_Id_Sede = new SelectList(sedeRepositorio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede", Pk_Sede);
            return View("GenerarPeligro");
        }


        /// <summary>
        /// Controlador que obtiene o retorna una vista parcial con el formulario de la metodologia 
        /// seleccionada
        /// </summary>
        /// <param name="PK_TipoMedologia">clave primaria de la metodologia</param>
        /// <param name="Pk_Sede">clave primaria de la sede</param>
        /// <returns>vista parcial</returns>
        public ActionResult ObtenerFormularioMetodologia(int PK_TipoMedologia, int Pk_Sede)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
           
            Sede sede = db.Tbl_Sede.Find(Pk_Sede);
            ViewBag.sede = sede;  
            ViewBag.FK_Tipo_De_Peligro = new SelectList(db.Tbl_Tipo_De_Peligro, "PK_Tipo_De_Peligro", "Descripcion_Del_Peligro");
            ViewBag.FK_Nivel_De_Exposicion = new SelectList(db.Tbl_Nivel_De_Exposicion, "PK_Nivel_De_Exposicion", "Descripcion_Exposicion");
            List<Consecuencia> consecuencias = consecuenciasServicios.ObtenerConsecuencias(PK_TipoMedologia);
            ViewBag.FK_Consecuencia = new SelectList(consecuencias, "PK_Consecuencia", "Descripcion_Consecuencia");
            List<Proceso> procesos = procesoServicios.ObtenerProcesosPrincipales(usuarioActual.IdEmpresa);
            ViewBag.Procesos = new SelectList(procesos, "Pk_Id_Proceso", "Descripcion_Proceso");
            if (IDFORMULARIORAM == PK_TipoMedologia)
            {
                List<Probabilidad> probabilidades = probabilidadesServicios.ObtenerProbabilidades(PK_TipoMedologia);
                ViewBag.FK_ProbabilidadPersona = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad");
                ViewBag.FK_ProbabilidadClientes = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad");
                ViewBag.FK_ProbabilidadEconomica = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad");
                ViewBag.FK_ProbabilidadImagenE = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad");
                ViewBag.FK_ProbabilidadAmbiental = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad");
                List<Consecuencia> consecuenciasPersona = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(3);
                ViewBag.consecuenciaPersona = new SelectList(consecuenciasPersona, "PK_Consecuencia", "Descripcion_Consecuencia");
                List<Consecuencia> consecuenciasClientes = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(6);
                ViewBag.consecuenciasClientes = new SelectList(consecuenciasClientes, "PK_Consecuencia", "Descripcion_Consecuencia");
                List<Consecuencia> consecuenciasEconomica = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(4);
                ViewBag.consecuenciasEconomica = new SelectList(consecuenciasEconomica, "PK_Consecuencia", "Descripcion_Consecuencia");
                List<Consecuencia> consecuenciasImagenE = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(7);
                ViewBag.consecuenciasImagenE = new SelectList(consecuenciasImagenE, "PK_Consecuencia", "Descripcion_Consecuencia");
                List<Consecuencia> consecuenciasAmbiental = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(5);
                ViewBag.consecuenciasAmbiental = new SelectList(consecuenciasAmbiental, "PK_Consecuencia", "Descripcion_Consecuencia");
                return PartialView("MetodologiaRAM");
            }
            else
            {
                if (IDFORMULARIOGTC == PK_TipoMedologia)
                {
                    List<NivelDeDeficiencia> nivelesDeDeficienciaList = nivelDeDeficienciaServicios.ConsultarNivelesDeDeficiencia(true);
                    ViewBag.FK_Nivel_De_Deficiencia = new SelectList(nivelesDeDeficienciaList, "PK_Nivel_De_Deficiencia", "Descripcion_Deficiciencia");
                    return PartialView("MetodologiaGTC45");
                }
                else
                {
                    List<Probabilidad> probabilidades = probabilidadesServicios.ObtenerProbabilidades(PK_TipoMedologia);
                    ViewBag.FK_Probabilidad = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad");
                    return PartialView("MetodologiaINSHT");
                }

            }
        }

       
        /// <summary>
        /// Metodo para grabar un peligro de tipo GTC45
        /// </summary>
        /// <param name="peligro">objeto de tipo  peligro</param>
        /// <param name="gtc45">objeto de tipo gtc45</param>
        /// <param name="consecuenciaPorPeligro">objeto de tipo consecuencia por peligro</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult GrabarMetodologiaGTC45(Peligro peligro, GTC45 gtc45, ConsecuenciaPorPeligro consecuenciaPorPeligro, string ipUsuario) 
       {
           var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
           if (usuarioActual == null)
           {
               ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
               return RedirectToAction("Login", "Home");
           }
          
            peligro.ConsecuenciasPorPeligros = new List<ConsecuenciaPorPeligro>();
            peligro.ConsecuenciasPorPeligros.Add(consecuenciaPorPeligro);
            peligro.GTC45 = new List<GTC45>();
            peligro.GTC45.Add(gtc45);
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            bool restpuestaGuardado = metodologiaServicios.GuardarPeligro(peligro, edInfoauditoria);
            if (restpuestaGuardado)
            {             
                return RedirectToAction("MostrarMatriz", new { IdSede = peligro.FK_Sede, IdMetodologia = IDFORMULARIOGTC });
            }
            else
            {
                return RedirectToAction("GenerarMetodologia");
            }

        }

        /// <summary>
        /// Metodo para grabar un peligro de tipo INSHT
        /// </summary>
        /// <param name="peligro">objeto de tipo  peligro</param>
        /// <param name="gtc45">objeto de tipo INSHT</param>
        /// <param name="PersonaExpuesta">objeto de tipo PersonaExpuesta</param>
        /// <param name="consecuenciaPorPeligro">objeto de tipo consecuencia por peligro</param>
        /// <param name="probabilidadPorPersonaExpuesta">objeto de tipo ProbabilidadPorPersonaExpuesta</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GrabarMetodologiaINSHT(Peligro peligro,
                                                    INSHT inst,
                                                    PersonaExpuesta personaExpuesta,
                                                    ConsecuenciaPorPeligro consecuenciaPorPeligro,
                                                    ProbabilidadPorPersonaExpuesta probabilidadPorPersonaExpuesta,
                                                    HttpPostedFileBase Firma, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            peligro.ConsecuenciasPorPeligros = new List<ConsecuenciaPorPeligro>();
            peligro.ConsecuenciasPorPeligros.Add(consecuenciaPorPeligro);
            personaExpuesta.ProbabilidadesPorPersonasExpuestas = new List<ProbabilidadPorPersonaExpuesta>();
            personaExpuesta.ProbabilidadesPorPersonasExpuestas.Add(probabilidadPorPersonaExpuesta);
            inst.Fecha_De_Comprobacion = (inst.Fecha_De_Comprobacion == new DateTime(0001, 1, 1)) ? new DateTime(1900, 1, 1) : inst.Fecha_De_Comprobacion;
            inst.Fecha_Finalizacion = (inst.Fecha_Finalizacion == new DateTime(0001, 1, 1)) ? new DateTime(1900, 1, 1) : inst.Fecha_Finalizacion;
            if (Firma != null && (Path.GetExtension(Firma.FileName).ToLower() == ".jpg" ||
                    Path.GetExtension(Firma.FileName).ToLower() == ".png"))
            {
                inst.FirmaResponsable = Firma.FileName;
            }
            personaExpuesta.INSHT = new List<INSHT>();
            personaExpuesta.INSHT.Add(inst);
            peligro.PersonaExpuestas = new List<PersonaExpuesta>();
            peligro.PersonaExpuestas.Add(personaExpuesta);
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            bool restpuestaGuardado = metodologiaServicios.GuardarPeligro(peligro, edInfoauditoria);
            if (restpuestaGuardado)
            {
                if (Firma != null && (Path.GetExtension(Firma.FileName).ToLower() == ".jpg" ||
                    Path.GetExtension(Firma.FileName).ToLower() == ".png"))
                {
                    var path = rutaRepositorioFile + rutaMPlanificacion + rutaOIdentificacionPeligros + rutaOMatrizINSHT + usuarioActual.NitEmpresa;
                    var img = Path.Combine(path, Firma.FileName);
                    if (!Directory.Exists(img))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    Firma.SaveAs(img);
                }             
                return RedirectToAction("MostrarMatriz", new { IdSede = peligro.FK_Sede, IdMetodologia = IDFORMULARIOINSHT });
            }
            else
            {
                return RedirectToAction("GenerarMetodologia");
            }
        }


        /// <summary>
        /// Metodo para grabar un peligro de tipo RAM
        /// </summary>
        /// <param name="peligro">objeto de tipo  peligro</param>
        /// <param name="ram">objeto de tipo RAM</param>
        /// <param name="PersonaExpuesta">objeto de tipo PersonaExpuesta</param>
        /// <param name="consecuenciaPorPeligro">Lista de objetos de tipo consecuencia por peligro</param>
        /// <param name="probabilidadPorPersonaExpuesta">Lista de objetos de tipo ProbabilidadPorPersonaExpuesta</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GrabarMetodologiaRAM(Peligro peligro,
                                                 RAM ram,
                                                 PersonaExpuesta personaExpuesta,
                                                 List<EstimacionDeRiesgoPorRAM> estimacionDeRiesgoPorRAM,
                                                 List<ProbabilidadPorPersonaExpuesta> probabilidadesPorPersonasExpuestas,
                                                 List<ConsecuenciaPorPeligro> consecuenciaPorPeligro,string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            peligro.ConsecuenciasPorPeligros = consecuenciaPorPeligro;
            personaExpuesta.ProbabilidadesPorPersonasExpuestas = probabilidadesPorPersonasExpuestas;
            ram.EstimacionDeRiesgosPorRAM = estimacionDeRiesgoPorRAM;
            personaExpuesta.RAM = new List<RAM>();
            personaExpuesta.RAM.Add(ram);
            peligro.PersonaExpuestas = new List<PersonaExpuesta>();
            peligro.PersonaExpuestas.Add(personaExpuesta);
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            bool restpuestaGuardado = metodologiaServicios.GuardarPeligro(peligro,edInfoauditoria);
            if (restpuestaGuardado)
            {           
                return RedirectToAction("MostrarMatriz", new { IdSede = peligro.FK_Sede, IdMetodologia = IDFORMULARIORAM });
            }
            else
            {
                return RedirectToAction("GenerarMetodologia");
            }
        }

        /// <summary>
        /// Metodo que me retorna los peligros por sedes
        /// </summary>
        /// <returns></returns>
        public ActionResult VisualizarPeligrosSede()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            List<PeligrosPorSede> peligrosSede = metodologiaServicios.ObtenerMatrizPorSedeEmpresa(usuarioActual.IdEmpresa);
            return View(peligrosSede);
        }

        /// <summary>
        /// Metodo que me retorna matriz por el tipo de metodologia
        /// </summary>
        /// <param name="IdSede">id o clave primaria de la sede</param>
        /// <param name="IdMetodologia">id o clave primaria de la sede</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult MostrarMatriz(int IdSede, int IdMetodologia)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            Sede sede = db.Tbl_Sede.Find(IdSede);
            ViewBag.sede = sede;
            ViewBag.IdMetodologia = IdMetodologia;
            if (IdMetodologia == IDFORMULARIOGTC)
            {
                List<MatrizGTC45> matrizGtc = metodologiaServicios.ObtenerMatrizGTC45(IdSede, IdMetodologia);
                return View("MatrizGTC45", matrizGtc);
            }
            if (IdMetodologia == IDFORMULARIOINSHT)
            {
                List<MatrizINSTH> matrizInsth = metodologiaServicios.ObtenerMatrizINSTH(IdSede, IdMetodologia);
                return View("MatrizINSTH", matrizInsth);
            }
            if (IdMetodologia == IDFORMULARIORAM)
            {
                List<MatrizRAM> matrizRAM = metodologiaServicios.ObtenerMatrizRAM(IdSede, IdMetodologia);
                return View("MatrizRAM", matrizRAM);
            }
            return null;
        }

        /// <summary>
        /// Metodo que me retorna la matriz de peligro como documento de excel
        /// </summary>
        /// <param name="IdSede">id o pk de la sede</param>
        /// <param name="IdMetodologia">id o pk del tipo de metodologias</param>
        /// <returns></returns>
        [AllowAnonymous]
        public FileStreamResult ExcelMatriz(int IdSede, int IdMetodologia)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
              //  return View();
            }

            MemoryStream stream = new MemoryStream();
            string nombreMetodologia = "";

            if (IdMetodologia == IDFORMULARIOGTC)
            {
                List<MatrizGTC45> matrizGtc = metodologiaServicios.ObtenerMatrizGTC45(IdSede, IdMetodologia);
                if (matrizGtc.Count == 1)
                {
                    matrizGtc.Add(new MatrizGTC45());
                }
                stream = recursosServicios.ExportarAExcel(matrizGtc);
                nombreMetodologia = "GTC45/2012";
            }
            if (IdMetodologia == IDFORMULARIOINSHT)
            {
                List<MatrizINSTH> matrizInsth = metodologiaServicios.ObtenerMatrizINSTH(IdSede, IdMetodologia);
                if (matrizInsth.Count == 1)
                {
                    matrizInsth.Add(new MatrizINSTH());
                }
                stream = recursosServicios.ExportarAExcel(matrizInsth);
                nombreMetodologia = "INSTH";
            }
            if (IdMetodologia == IDFORMULARIORAM)
            {
                List<MatrizRAM> matrizRAM = metodologiaServicios.ObtenerMatrizRAM(IdSede, IdMetodologia);
                if (matrizRAM.Count == 1)
                {
                    matrizRAM.Add(new MatrizRAM());
                }
                stream = recursosServicios.ExportarAExcel(matrizRAM);
                nombreMetodologia = "RAM";
            }
            //devuelvo el XML de la memoria como un fichero .xls
            return File(stream, "application/vnd.ms-excel", "Matriz de Riesgo" + nombreMetodologia + ".xls");
        }

        /// <summary>
        /// Metodo que me elimina una matriz de peligros
        /// </summary>
        /// <param name="IdSede">id o pk de la sede</param>
        /// <param name="IdMetodologia">id o pk del tipo de metodologias</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult EliminarMatriz(int IdSede, int IdMetodologia, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            bool restpuestaGuardado = metodologiaServicios.EliminarPeligros(IdSede, IdMetodologia, edInfoauditoria);
            string mensaje = "";
            if (restpuestaGuardado)
            {
                mensaje = "La matriz fue eliminada";
            }
            else
            {
                mensaje = "No fue posible eliminar la matriz";
            }
            ViewBag.mensaje = mensaje;
            ViewBag.respuesta = restpuestaGuardado;
            List<PeligrosPorSede> peligrosSede = metodologiaServicios.ObtenerMatrizPorSedeEmpresa(usuarioActual.IdEmpresa);
            return View("VisualizarPeligrosSede", peligrosSede);
        }

        /// <summary>
        /// Metodo que me elimina un peligro de la matriz
        /// </summary>
        /// <param name="Pk_Peligro">id o pk del peligro</param>
        /// <returns>me retorna si la operacion fue existosa o no, con su respectivo mensaje</returns>
        public ActionResult EliminarPeligro(int Pk_Peligro, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            bool restpuestaGuardado = metodologiaServicios.EliminarPeligro(Pk_Peligro, edInfoauditoria);
            string mensaje = "";
            if (restpuestaGuardado)
            {
                mensaje = "El peligro fue eliminado";
            }
            else
            {
                mensaje = "No fue posible eliminar el Peligro";
            }

            return Json(new
            {
                success = restpuestaGuardado,
                mesansaje = mensaje,
            }
               , JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Metodo que me retonar una vista con la informacion cargada para la edicion de un peligro
        /// </summary>
        /// <param name="idPeligro">id o pk del peligro</param>
        /// <param name="PK_TipoMedologia">id o pk del tipo de metodologia</param>
        /// <param name="Pk_Sede">id o pk de la sede</param>
        /// <returns>vista EditMetodologiaGTC45</returns>
        [AllowAnonymous]
        public ActionResult EditarPeligroGTC45(int idPeligro, int PK_TipoMedologia, int Pk_Sede)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            MatrizEditGTC45 matrizEditGTC45 = metodologiaServicios.ObtenerMatrizEditGTC45(idPeligro);
            Sede sede = db.Tbl_Sede.Find(Pk_Sede);
            ViewBag.sede = sede;

            List<Proceso> procesos = procesoServicios.ObtenerProcesosPrincipales(usuarioActual.IdEmpresa);
            Proceso proceso = procesoServicios.ObtenerProceso(matrizEditGTC45.idProceso);
            List<Proceso> subProcesos = procesoServicios.ObtenerSubProcesos(proceso.Procesos.Pk_Id_Proceso);
            ViewBag.Procesos = new SelectList(procesos, "Pk_Id_Proceso", "Descripcion_Proceso", proceso.Fk_Id_Proceso);
            ViewBag.FK_Proceso = new SelectList(subProcesos, "Pk_Id_Proceso", "Descripcion_Proceso", matrizEditGTC45.idProceso);

            ViewBag.FK_Tipo_De_Peligro = new SelectList(db.Tbl_Tipo_De_Peligro, "PK_Tipo_De_Peligro", "Descripcion_Del_Peligro", matrizEditGTC45.idClasificacion);
            List<ClasificacionDePeligro> clasesDePeligrosList = clasificacionDePeligrosServicios.ConsultarClasesDePeligros(matrizEditGTC45.idClasificacion);
            ViewBag.FK_Clasificacion_De_Peligro = new SelectList(clasesDePeligrosList, "PK_Clasificacion_De_Peligro", "Descripcion_Clase_De_Peligro", matrizEditGTC45.idDescripcion);
            List<NivelDeDeficiencia> nivelesDeDeficienciaList = nivelDeDeficienciaServicios.ConsultarNivelesDeDeficiencia(matrizEditGTC45.FLG_Tipo_De_Calificacion);

            ViewBag.FK_Nivel_De_Deficiencia = new SelectList(nivelesDeDeficienciaList, "PK_Nivel_De_Deficiencia", "Descripcion_Deficiciencia", matrizEditGTC45.idNivelDeficiencia);


            ViewBag.FK_Nivel_De_Exposicion = new SelectList(db.Tbl_Nivel_De_Exposicion, "PK_Nivel_De_Exposicion", "Descripcion_Exposicion", matrizEditGTC45.idNivelExposicion);
            List<Consecuencia> consecuencias = consecuenciasServicios.ObtenerConsecuencias(PK_TipoMedologia);
            ViewBag.FK_Consecuencia = new SelectList(consecuencias, "PK_Consecuencia", "Descripcion_Consecuencia", matrizEditGTC45.idNivelConsecuencia);
            return View("EditMetodologiaGTC45", matrizEditGTC45);
        }

        /// <summary>
        /// Metodo que me retonar una vista con la informacion cargada para la edicion de un peligro
        /// </summary>
        /// <param name="idPeligro">id o pk del peligro</param>
        /// <param name="PK_TipoMedologia">id o pk del tipo de metodologia</param>
        /// <param name="Pk_Sede">id o pk de la sede</param>
        /// <returns>vista EditMetodologiaINSHT</returns>
        [AllowAnonymous]
        public ActionResult EditarPeligroINSTH(int idPeligro, int PK_TipoMedologia, int Pk_Sede)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            MatrizEditINSTH matrizEditINSTH = metodologiaServicios.ObtenerMatrizEditINSTH(idPeligro);
            Sede sede = db.Tbl_Sede.Find(Pk_Sede);
            ViewBag.sede = sede;

            List<Proceso> procesos = procesoServicios.ObtenerProcesosPrincipales(usuarioActual.IdEmpresa);
            Proceso proceso = procesoServicios.ObtenerProceso(matrizEditINSTH.idProceso);
            List<Proceso> subProcesos = procesoServicios.ObtenerSubProcesos(proceso.Procesos.Pk_Id_Proceso);
            ViewBag.Procesos = new SelectList(procesos, "Pk_Id_Proceso", "Descripcion_Proceso", proceso.Fk_Id_Proceso);
            ViewBag.FK_Proceso = new SelectList(subProcesos, "Pk_Id_Proceso", "Descripcion_Proceso", matrizEditINSTH.idProceso);

            ViewBag.FK_Tipo_De_Peligro = new SelectList(db.Tbl_Tipo_De_Peligro, "PK_Tipo_De_Peligro", "Descripcion_Del_Peligro", matrizEditINSTH.idClasificacion);
            List<ClasificacionDePeligro> clasesDePeligrosList = clasificacionDePeligrosServicios.ConsultarClasesDePeligros(matrizEditINSTH.idClasificacion);
            ViewBag.FK_Clasificacion_De_Peligro = new SelectList(clasesDePeligrosList, "PK_Clasificacion_De_Peligro", "Descripcion_Clase_De_Peligro", matrizEditINSTH.idDescripcion);
            List<Consecuencia> consecuencias = consecuenciasServicios.ObtenerConsecuencias(PK_TipoMedologia);
            ViewBag.FK_Consecuencia = new SelectList(consecuencias, "PK_Consecuencia", "Descripcion_Consecuencia", matrizEditINSTH.idNivelConsecuencia);
            List<Probabilidad> probabilidades = probabilidadesServicios.ObtenerProbabilidades(PK_TipoMedologia);
            ViewBag.FK_Probabilidad = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad", matrizEditINSTH.idProbabilidad);
            return View("EditMetodologiaINSHT", matrizEditINSTH);
        }

        /// <summary>
        /// Metodo que me retonar una vista con la informacion cargada para la edicion de un peligro
        /// </summary>
        /// <param name="idPeligro">id o pk del peligro</param>
        /// <param name="PK_TipoMedologia">id o pk del tipo de metodologia</param>
        /// <param name="Pk_Sede">id o pk de la sede</param>
        /// <returns>vista EditMetodologiaRAM</returns>
        [AllowAnonymous]
        public ActionResult EditarPeligroRAM(int idPeligro, int PK_TipoMedologia, int Pk_Sede)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            MatrizEditRAM MatrizEditRAM = metodologiaServicios.ObtenerMatrizEditRAM(idPeligro);
            Sede sede = db.Tbl_Sede.Find(Pk_Sede);
            ViewBag.sede = sede;

            List<Proceso> procesos = procesoServicios.ObtenerProcesosPrincipales(usuarioActual.IdEmpresa);
            Proceso proceso = procesoServicios.ObtenerProceso(MatrizEditRAM.idProceso);
            List<Proceso> subProcesos = procesoServicios.ObtenerSubProcesos(proceso.Procesos.Pk_Id_Proceso);
            ViewBag.Procesos = new SelectList(procesos, "Pk_Id_Proceso", "Descripcion_Proceso", proceso.Fk_Id_Proceso);
            ViewBag.FK_Proceso = new SelectList(subProcesos, "Pk_Id_Proceso", "Descripcion_Proceso", MatrizEditRAM.idProceso);

            ViewBag.FK_Tipo_De_Peligro = new SelectList(db.Tbl_Tipo_De_Peligro, "PK_Tipo_De_Peligro", "Descripcion_Del_Peligro", MatrizEditRAM.idClasificacion);
            List<ClasificacionDePeligro> clasesDePeligrosList = clasificacionDePeligrosServicios.ConsultarClasesDePeligros(MatrizEditRAM.idClasificacion);
            ViewBag.FK_Clasificacion_De_Peligro = new SelectList(clasesDePeligrosList, "PK_Clasificacion_De_Peligro", "Descripcion_Clase_De_Peligro", MatrizEditRAM.idDescripcion);
            List<Probabilidad> probabilidades = probabilidadesServicios.ObtenerProbabilidades(PK_TipoMedologia);
            ViewBag.FK_ProbabilidadPersona = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad", MatrizEditRAM.idProbabilidadPersona);
            ViewBag.FK_ProbabilidadClientes = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad", MatrizEditRAM.idProbabilidadClientes);
            ViewBag.FK_ProbabilidadEconomica = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad", MatrizEditRAM.idProbabilidadEconomica);
            ViewBag.FK_ProbabilidadImagenE = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad", MatrizEditRAM.idProbabilidadEmpresa);
            ViewBag.FK_ProbabilidadAmbiental = new SelectList(probabilidades, "PK_Probabilidad", "Descripcion_Probabilidad", MatrizEditRAM.idProbabilidadAmbiental);
            List<Consecuencia> consecuenciasPersona = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(3);
            ViewBag.consecuenciaPersona = new SelectList(consecuenciasPersona, "PK_Consecuencia", "Descripcion_Consecuencia", MatrizEditRAM.idConsecuenciaPersona);
            List<Consecuencia> consecuenciasClientes = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(6);
            ViewBag.consecuenciasClientes = new SelectList(consecuenciasClientes, "PK_Consecuencia", "Descripcion_Consecuencia", MatrizEditRAM.idConsecuenciaClientes);
            List<Consecuencia> consecuenciasEconomica = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(4);
            ViewBag.consecuenciasEconomica = new SelectList(consecuenciasEconomica, "PK_Consecuencia", "Descripcion_Consecuencia", MatrizEditRAM.idConsecuenciaEconomica);
            List<Consecuencia> consecuenciasImagenE = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(7);
            ViewBag.consecuenciasImagenE = new SelectList(consecuenciasImagenE, "PK_Consecuencia", "Descripcion_Consecuencia", MatrizEditRAM.idConsecuenciaEmpresa);
            List<Consecuencia> consecuenciasAmbiental = consecuenciasServicios.ObtenerConsecuenciasPorGrupo(5);
            ViewBag.consecuenciasAmbiental = new SelectList(consecuenciasAmbiental, "PK_Consecuencia", "Descripcion_Consecuencia", MatrizEditRAM.idConsecuenciaAmbiental);
            return View("EditMetodologiaRAM", MatrizEditRAM);
        }

      
    }
}