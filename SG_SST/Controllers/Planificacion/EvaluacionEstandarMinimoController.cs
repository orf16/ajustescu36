using SG_SST.Models.Planificacion;
using SG_SST.ServiceRequest;
using SG_SST.EntidadesDominio.Planificacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json;
using SG_SST.Controllers.Base;
using Rotativa;
using System.Net;
using SG_SST.Logica.Usuarios;
using System.IO;
using System.Web.Configuration;
using SG_SST.Enumeraciones;
using SG_SST.Helpers;

namespace SG_SST.Controllers.Planificacion
{
    [GestionAutorizacion]
    public class EvaluacionEstandarMinimoController : BaseController
    {
        string urlServicioPlanificacion = ConfigurationManager.AppSettings["UrlServicioPlanificacion"];
        string capacidadEvaluacionEstandaresMinimos = ConfigurationManager.AppSettings["capacidadEvaluacionEstandaresMinimos"];
        string CapacidadEvaluacionEstandaresMinimosCons = ConfigurationManager.AppSettings["CapacidadEvaluacionEstandaresMinimosCons"];
        string capacidadCrearEvaluacion = ConfigurationManager.AppSettings["capacidadCrearEvaluacion"];
        string capacidadEliminarEvaluacion = ConfigurationManager.AppSettings["capacidadEliminarEvaluacion"];
        string capacidadEvaluaciones = ConfigurationManager.AppSettings["capacidadEvaluaciones"];
        string capacidadCerrarEvaluacion = ConfigurationManager.AppSettings["capacidadCerrarEvaluacion"];
        string capacidadValidarEvaluacion = ConfigurationManager.AppSettings["capacidadValidarEvaluacion"];
        string capacidadValidarCriterio = ConfigurationManager.AppSettings["capacidadValidarCriterio"];
        string capacidadCalificacionEstandaresMinimos = ConfigurationManager.AppSettings["CapacidadCalificacionEstandaresMinimos"];
        string capacidadReporteEstandaresMinimos = ConfigurationManager.AppSettings["CapacidadReporteEstandaresMinimos"];
        string capacidadReporteRespuestasEstandaresMinimos = ConfigurationManager.AppSettings["CapacidadReporteRespuestasEstandaresMinimos"];
        string capacidadReportePuntajeEstandaresMinimos = ConfigurationManager.AppSettings["CapacidadReportePuntajeEstandaresMinimos"];
        string capacidadReporteCalificacionEstandaresMinimosFinal = ConfigurationManager.AppSettings["CapacidadReporteCalificacionEstandaresMinimosFinal"];
        string capacidadPlanAccion = ConfigurationManager.AppSettings["CapacidadPlanAccion"];
        string capacidadPlanAccionExcel = ConfigurationManager.AppSettings["CapacidadPlanAccionExcel"];
        string CapacidadReporteExcelEstandaresMinimosCiclo = ConfigurationManager.AppSettings["CapacidadReporteExcelEstandaresMinimosCiclo"];
        string CapacidadReporteExcelRespuestasEstandaresMinimos = ConfigurationManager.AppSettings["CapacidadReporteExcelRespuestasEstandaresMinimos"];
        string CapacidadReporteExcelPuntajeEstandaresMinimos = ConfigurationManager.AppSettings["CapacidadReporteExcelPuntajeEstandaresMinimos"];
        string CapacidadObtenerAnoInicioEmpresa = ConfigurationManager.AppSettings["CapacidadObtenerAnoInicioEmpresa"];
        string CapacidadReporteCalificacionEstandaresMinimosComparar = ConfigurationManager.AppSettings["CapacidadReporteCalificacionEstandaresMinimosComparar"];

        //Rutas Imagenes
        private static string RutaArchivosBDTemp = "~/Content/ArchivosEvaluacion/ArchivosEvaluacionTemp/";
        private static string RutaArchivosBD = "~/Content/ArchivosEvaluacion/ArchivosEvaluacionBD/";

        public ActionResult Index()
        {
            //se consume el servicio rest para obtener los ciclos
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado para realizar la evalación.";
                return RedirectToAction("Login", "Home");
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", "1");

            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadEvaluacionEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0 && result.FirstOrDefault() != null)
            {
                var evaluacionEstMin = new EvaluacionEstandarMinimoModel();
                evaluacionEstMin.Ciclos = result.Select(c => new CicloModel()
                {
                    IdCiclo = c.Id_Ciclo,
                    Nombre = obtenernombreciclo(c.Id_Ciclo, c.Nombre),
                    Porcentaje = c.Porcentaje_Max,
                    CantidadCriterios = c.CantidadCriterios,
                    StandPorEvaluar = c.StandPorEvaluar
                }).ToList();

                var obtenerCalificacionFinal = evaluacionEstMin.Ciclos.Where(c => c.StandPorEvaluar > 0).Count();
                if (obtenerCalificacionFinal == 0)
                {

                    //Se consume el servicio rest para obtener la calificacion final
                    ServiceClient.EliminarParametros();
                    ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);

                    var calificacionFinal = ServiceClient.ObtenerObjetoJsonRestFul<EDValoracionFinal>(urlServicioPlanificacion, capacidadCalificacionEstandaresMinimos, RestSharp.Method.GET);
                    evaluacionEstMin.CalificacionFinal = calificacionFinal == null ? null : new ValoracionFinalModel()
                    {
                        IdValoracionFinal = calificacionFinal.IdValoracionFinal,
                        Accion = calificacionFinal.Accion,
                        CriterioValoracion = calificacionFinal.CriterioValoracion,
                        Valoracion = calificacionFinal.Valoracion
                    };
                }
                return View(evaluacionEstMin);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(int ideval)
        {
            long int_FileSizeLimit = 0;
            int int_MB = 0;
            HttpRuntimeSection section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
            if (section != null)
            {
                // Retreive the maximum request length from the web.config and convert to bytes.
                var limit = section.MaxRequestLength;
                int_FileSizeLimit = (limit * 1024);
                double megabytes1 = ConvertBytesToMegabytes((long)int_FileSizeLimit);
                int_MB = (int)Math.Floor(megabytes1);
            }
            else
            {
                int_FileSizeLimit = 31457280;
            }
            ViewBag.LimiteMB = int_MB;

            ViewBag.ideval = ideval.ToString();
            //se consume el servicio rest para obtener los ciclos
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado para realizar la evalación.";
                return RedirectToAction("Login", "Home");
            }

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("IdEval", ideval);
            var estadosver = ServiceClient.PeticionesPostJsonRestFulRespuetaint(urlServicioPlanificacion, capacidadEvaluaciones, RestSharp.Method.GET);
            if (estadosver == 3)
            {
                return RedirectToAction("Inicio", "EvaluacionEstandarMinimo");
            }

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", ideval.ToString());

            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadEvaluacionEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0 && result.FirstOrDefault() != null)
            {
                var evaluacionEstMin = new EvaluacionEstandarMinimoModel();
                evaluacionEstMin.Ciclos = result.Select(c => new CicloModel()
                {
                    IdCiclo = c.Id_Ciclo,
                    Nombre = obtenernombreciclo(c.Id_Ciclo, c.Nombre),
                    Porcentaje = c.Porcentaje_Max,
                    CantidadCriterios = c.CantidadCriterios,
                    StandPorEvaluar = c.StandPorEvaluar
                }).ToList();

                var obtenerCalificacionFinal = evaluacionEstMin.Ciclos.Where(c => c.StandPorEvaluar > 0).Count();
                if (obtenerCalificacionFinal == 0)
                {

                    //Se consume el servicio rest para obtener la calificacion final
                    ServiceClient.EliminarParametros();
                    ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
                    ServiceClient.AdicionarParametro("IdEval", ideval.ToString());

                    var calificacionFinal = ServiceClient.ObtenerObjetoJsonRestFul<EDValoracionFinal>(urlServicioPlanificacion, capacidadCalificacionEstandaresMinimos, RestSharp.Method.GET);
                    evaluacionEstMin.CalificacionFinal = calificacionFinal == null ? null : new ValoracionFinalModel()
                    {
                        IdValoracionFinal = calificacionFinal.IdValoracionFinal,
                        Accion = calificacionFinal.Accion,
                        CriterioValoracion = calificacionFinal.CriterioValoracion,
                        Valoracion = calificacionFinal.Valoracion,
                        puntoObtenidos = calificacionFinal.puntoObtenidos,
                        Idval = ideval.ToString()
                    };
                }
                return View(evaluacionEstMin);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index_ed(int ideval, int Idcrit, int idciclo)
        {
            int int_FileSizeLimit = 0;
            int int_MB = 0;

            HttpRuntimeSection section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
            if (section != null)
            {
                int_FileSizeLimit = (section.MaxRequestLength * 1024);
                double megabytes1 = ConvertBytesToMegabytes((long)int_FileSizeLimit);
                int_MB = (int)Math.Floor(megabytes1);
            }
            else
            {
                int_FileSizeLimit = 31457280;
            }
            ViewBag.LimiteMB = int_MB;

            ViewBag.Idcrit = Idcrit;
            ViewBag.ideval = ideval.ToString();

            EDCiclo EDCiclo = new EDCiclo();

            //se consume el servicio rest para obtener los ciclos
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado para realizar la evalación.";
                return RedirectToAction("Login", "Home");
            }

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("IdEval", ideval);
            var estadosver = ServiceClient.PeticionesPostJsonRestFulRespuetaint(urlServicioPlanificacion, capacidadEvaluaciones, RestSharp.Method.GET);
            if (estadosver == 3)
            {
                return RedirectToAction("Inicio", "EvaluacionEstandarMinimo");
            }

            var evaluacionEstMin1 = new EvaluacionEstandarMinimoModel();

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", ideval.ToString());

            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadEvaluacionEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0 && result.FirstOrDefault() != null)
            {
                var evaluacionEstMin = new EvaluacionEstandarMinimoModel();
                evaluacionEstMin.Ciclos = result.Select(c => new CicloModel()
                {
                    IdCiclo = c.Id_Ciclo,
                    Nombre = obtenernombreciclo(c.Id_Ciclo, c.Nombre),
                    Porcentaje = c.Porcentaje_Max,
                    CantidadCriterios = c.CantidadCriterios,
                    StandPorEvaluar = c.StandPorEvaluar
                }).ToList();
                int IdCiclo = 0;
                foreach (var item in evaluacionEstMin.Ciclos)
                {
                    if (item.StandPorEvaluar > 0)
                    {
                        IdCiclo = item.IdCiclo;
                        break;
                    }
                }


                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("idCiclo", idciclo);
                ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
                ServiceClient.AdicionarParametro("IdEval", ideval);
                ServiceClient.AdicionarParametro("idElemento", Idcrit);
                ServiceClient.AdicionarParametro("tipo", true);
                var result1 = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                if (result1 != null)
                {
                    string RutaArchivo1 = null;
                    string RutaArchivo2 = null;
                    string RutaArchivo3 = null;
                    try
                    {
                        RutaArchivo1 = Server.MapPath(Path.Combine(result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1, result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        RutaArchivo2 = Server.MapPath(Path.Combine(result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2, result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2));
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        RutaArchivo3 = Server.MapPath(Path.Combine(result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3, result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3));
                    }
                    catch (Exception)
                    {
                    }

                    if (RutaArchivo1 != null)
                    {
                        if (!System.IO.File.Exists(RutaArchivo1))
                        {
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1 = null;
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1 = null;
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload1 = null;
                        }
                    }
                    if (RutaArchivo2 != null)
                    {
                        if (!System.IO.File.Exists(RutaArchivo2))
                        {
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2 = null;
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2 = null;
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload2 = null;
                        }
                    }
                    if (RutaArchivo3 != null)
                    {
                        if (!System.IO.File.Exists(RutaArchivo3))
                        {
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3 = null;
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3 = null;
                            result1.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload3 = null;
                        }
                    }
                    evaluacionEstMin.EDCiclo = result1;
                    return View(evaluacionEstMin);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Inicio(string vigencia, string estado)
        {
            int vigenciaint = -1;
            int estadoint = -1;

            if (vigencia != null)
            {
                if (int.TryParse(vigencia, out vigenciaint))
                {
                }
            }
            if (estado != null)
            {
                if (int.TryParse(estado, out estadoint))
                {
                }
            }
            ViewBag.Estadopage = "";
            ViewBag.Vigenciapage = "";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.RazonSocial = usuarioActual.RazonSocialEmpresa;
            ViewBag.Nit = usuarioActual.NitEmpresa;
            List<EDEvaluacionEmpresa> Lista = new List<EDEvaluacionEmpresa>();
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("IdEmpresa", usuarioActual.IdEmpresa);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDEvaluacionEmpresa>(urlServicioPlanificacion, capacidadEvaluaciones, RestSharp.Method.GET);

            if (result != null && result.Count() > 0 && result.FirstOrDefault() != null)
            {
                foreach (var item in result)
                {
                    EDEvaluacionEmpresa EDEvaluacionEmpresa = new EDEvaluacionEmpresa();
                    EDEvaluacionEmpresa.Estado = item.Estado;
                    EDEvaluacionEmpresa.Fecha_Elab = item.Fecha_Elab;
                    EDEvaluacionEmpresa.Fk_Id_Empresa = item.Fk_Id_Empresa;
                    EDEvaluacionEmpresa.Vigencia = item.Vigencia;
                    EDEvaluacionEmpresa.Pk_Id_EvaluacionEmpresa = item.Pk_Id_EvaluacionEmpresa;
                    EDEvaluacionEmpresa.Consecutivo = item.Consecutivo;
                    EDEvaluacionEmpresa.NumeroTotal = item.NumeroTotal;
                    EDEvaluacionEmpresa.Numeroevaluar = item.Numeroevaluar;

                    if (vigenciaint >= 2017 && estadoint >= 1)
                    {
                        if (EDEvaluacionEmpresa.Estado == estadoint && EDEvaluacionEmpresa.Vigencia == vigenciaint)
                        {
                            ViewBag.Vigenciapage = vigenciaint.ToString();
                            ViewBag.Estadopage = estadoint.ToString();
                            Lista.Add(EDEvaluacionEmpresa);
                        }
                    }
                    else
                    {
                        bool filtro = false;
                        if (estadoint >= 1)
                        {
                            filtro = true;
                            ViewBag.Estadopage = estadoint.ToString();
                            if (EDEvaluacionEmpresa.Estado == estadoint)
                            {
                                Lista.Add(EDEvaluacionEmpresa);
                            }
                        }
                        if (vigenciaint >= 2017)
                        {
                            filtro = true;
                            ViewBag.Vigenciapage = vigenciaint.ToString();
                            if (EDEvaluacionEmpresa.Vigencia == vigenciaint)
                            {
                                Lista.Add(EDEvaluacionEmpresa);
                            }
                        }
                        if (!filtro)
                        {
                            Lista.Add(EDEvaluacionEmpresa);
                        }
                    }
                }
            }
            Lista = Lista.OrderByDescending(s => s.Vigencia).ThenByDescending(s => s.Fecha_Elab).ToList();


            List<SelectListItem> ListaAños = new List<SelectListItem>();
            ListaAños.Add(new SelectListItem { Text = null, Value = null });
            for (int i = 2017; i < 2051; i++)
            {
                ListaAños.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }
            ViewBag.SelectAnio = ListaAños;


            return View(Lista);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Editar(int ideval)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.finalizado = -1;
            ViewBag.Accion = null;
            ViewBag.CriterioValoracion = null;
            ViewBag.Valoracion = null;
            ViewBag.puntoObtenidos = null;


            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", ideval.ToString());
            var result0 = ServiceClient.ObtenerArrayJsonRestFul<EDEvaluacionEmpresa>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
            if (result0 != null && result0.Count() > 0 && result0.FirstOrDefault() != null)
            {
                EDEvaluacionEmpresa evaluacion = result0[0];
                
                ViewBag.RazonSocial = usuarioActual.RazonSocialEmpresa;
                ViewBag.Nit = usuarioActual.NitEmpresa;
                ViewBag.ideval = ideval.ToString();
                return View(evaluacion);

            }
            ViewBag.RazonSocial = usuarioActual.RazonSocialEmpresa;
            ViewBag.Nit = usuarioActual.NitEmpresa;
            ViewBag.ideval = ideval.ToString();

            return View();

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult cerraevaluacion(int ideval)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.finalizado = -1;
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("IdEval", ideval);
            var estadosver = ServiceClient.PeticionesPostJsonRestFulRespuetaint(urlServicioPlanificacion, capacidadEvaluaciones, RestSharp.Method.GET);
            if (estadosver != -1)
            {
                ViewBag.finalizado = estadosver;
            }
            if (estadosver == 3)
            {
                return RedirectToAction("Inicio", "EvaluacionEstandarMinimo");
            }


            ViewBag.RazonSocial = usuarioActual.RazonSocialEmpresa;
            ViewBag.Nit = usuarioActual.NitEmpresa;
            ViewBag.ideval = ideval.ToString();

            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Ver(int ideval)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Accion = null;
            ViewBag.CriterioValoracion = null;
            ViewBag.Valoracion = null;
            ViewBag.puntoObtenidos = null;

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("IdEval", ideval);
            var estadosver = ServiceClient.PeticionesPostJsonRestFulRespuetaint(urlServicioPlanificacion, capacidadEvaluaciones, RestSharp.Method.GET);

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", ideval.ToString());
            var result0 = ServiceClient.ObtenerArrayJsonRestFul<EDEvaluacionEmpresa>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
            if (result0 != null && result0.Count() > 0 && result0.FirstOrDefault() != null)
            {
                EDEvaluacionEmpresa evaluacion = result0[0];
                var obtenerCalificacionFinal = evaluacion.ListaCiclos.Where(c => c.StandPorEvaluar > 0).Count();
                if (obtenerCalificacionFinal == 0)
                {
                    //Se consume el servicio rest para obtener la calificacion final
                    ServiceClient.EliminarParametros();
                    ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                    ServiceClient.AdicionarParametro("IdEval", ideval.ToString());

                    var calificacionFinal = ServiceClient.ObtenerObjetoJsonRestFul<EDValoracionFinal>(urlServicioPlanificacion, capacidadCalificacionEstandaresMinimos, RestSharp.Method.GET);
                    if (calificacionFinal!=null)
                    {
                        ViewBag.Accion = calificacionFinal.Accion;
                        ViewBag.CriterioValoracion = calificacionFinal.CriterioValoracion;
                        ViewBag.Valoracion = calificacionFinal.Valoracion;
                        ViewBag.puntoObtenidos = calificacionFinal.puntoObtenidos;
                    }
                }
                return View(evaluacion);
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult comparativoaños()
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado para realizar la evalación.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult compararevaluaciones(int fi, int ff)
        {
            bool Probar = false;
            string Estado = "Sin respuesta";
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                Estado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { Estado, Probar });
            }

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            ServiceClient.AdicionarParametro("fi", fi);
            ServiceClient.AdicionarParametro("ff", ff);

            var result = ServiceClient.ObtenerArrayJsonRestFul<EDEvaluacionEmpresa>(urlServicioPlanificacion, CapacidadReporteCalificacionEstandaresMinimosComparar, RestSharp.Method.GET);
            if (result != null)
            {
                if (result.Count() > 0)
                {
                    if (result[0] != null)
                    {
                        if (result.Count() > 10)
                        {
                            Estado = "El limite de evaluaciones a comparar es de 10, por favor seleccione un rango de años inferior al seleccionado actualmente";
                            return Json(new { Estado, Probar });
                        }
                        var resultado = result.ToList().OrderBy(s=>s.Vigencia).ToList();
                        var datos = RenderRazorViewToString("_CompararVigencias", resultado);
                        return Json(new { Probar = true, Datos = datos, Estado = "OK" });
                    }
                    else
                    {
                        Estado = "No existen evaluaciones para ese rango de años";
                        return Json(new { Estado, Probar });
                    }
                }
                else
                {
                    Estado = "No existen evaluaciones para ese rango de años";
                    return Json(new { Estado, Probar });
                }
            }
            return Json(new { Estado, Probar });
        }
        [HttpPost]
        public ActionResult CrearPlan(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            bool Probar = false;
            string Estado = "Se ha presentado un error y la evaluación no ha sido creada. Por favor intente nuevamente";
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                Estado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { Estado, Probar });
            }
            int Vigencia = EDEvaluacionEmpresa.Vigencia;
            if (Vigencia != 0)
            {
                if (Vigencia.ToString().Length != 4 || Vigencia < 2017)
                {
                    Estado = "La vigencia debe ser un año superior al 2017 con 4 digitos";
                    return Json(new { Estado, Probar });
                }
                EDEvaluacionEmpresa.Fecha_Elab = DateTime.Today;
                EDEvaluacionEmpresa.Fk_Id_Empresa = usuarioActual.IdEmpresa;
                EDEvaluacionEmpresa.Estado = 1;

                ServiceClient.EliminarParametros();
                var result = ServiceClient.PeticionesPostJsonRestFulRespuetaBoolEval<bool>(urlServicioPlanificacion, capacidadCrearEvaluacion, EDEvaluacionEmpresa);

                bool ProbarGuardado = result;
                if (ProbarGuardado)
                {
                    Probar = true;
                    return Json(new { url = Url.Action("Inicio", "EvaluacionEstandarMinimo"), Estado, Probar });
                }
            }
            else
            {
                Estado = "No ha seleccionado la vigencia, por favor seleccionela para guardar la evaluación de estándares mínimos";
                return Json(new { Estado, Probar });
            }
            return Json(new { Estado, Probar });
        }
        [HttpPost]
        public ActionResult EliminarEvaluacion(string ideval)
        {
            bool probar = false;
            string resultado = "El proceso de eliminación no se completó";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                resultado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);
            }

            int IdElemento = 0;
            bool probarNumero = int.TryParse(ideval, out IdElemento);
            if (IdElemento != 0)
            {
                List<EDEvaluacionEmpresa> Lista = new List<EDEvaluacionEmpresa>();
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("Idempresa", usuarioActual.IdEmpresa);
                ServiceClient.AdicionarParametro("IdEval", IdElemento);
                var result = ServiceClient.ObtenerArrayJsonRestFul<EDEvaluacionEmpresa>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                if (result != null && result.Count() > 0 && result.FirstOrDefault() != null)
                {
                    List<string> ListaArchivos = new List<string>();
                    var EDEvaluacionEmpresa = result[0];
                    foreach (var item in EDEvaluacionEmpresa.ListaCiclos)
                    {
                        foreach (var item1 in item.Estandares)
                        {
                            foreach (var item2 in item1.SubEstandares)
                            {
                                foreach (var item3 in item2.Criterios)
                                {
                                    foreach (var item4 in item3.Evaluaciones)
                                    {
                                        try
                                        {
                                            ListaArchivos.Add(Server.MapPath(Path.Combine(item4.Ruta1, item4.NombreArchivo1)));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            ListaArchivos.Add(Server.MapPath(Path.Combine(item4.Ruta2, item4.NombreArchivo2)));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            ListaArchivos.Add(Server.MapPath(Path.Combine(item4.Ruta3, item4.NombreArchivo3)));
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }


                    ServiceClient.EliminarParametros();
                    var resultEl = ServiceClient.PeticionesPostJsonRestFulRespuetaBoolEval<bool>(urlServicioPlanificacion, capacidadEliminarEvaluacion, EDEvaluacionEmpresa);

                    if (resultEl)
                    {
                        foreach (var item in ListaArchivos)
                        {
                            try
                            {
                                if (System.IO.File.Exists(item))
                                {
                                    System.IO.File.Delete(item);
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                        probar = true;
                        resultado = "La evaluación se ha eliminado correctamente";
                        return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult CerrarEvaluacion(int ideval)
        {
            bool probar = false;
            string resultado = "No se ha cerrado la evaluación, por favor intente de nuevo";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                resultado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);
            }

            if (ideval != 0)
            {
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("idEval", ideval);
                ServiceClient.AdicionarParametro("idempresa", usuarioActual.IdEmpresa);
                var result = ServiceClient.PeticionesPostJsonRestFulRespuetastring(urlServicioPlanificacion, capacidadCerrarEvaluacion, RestSharp.Method.GET);

                if (result == "Cerrada" || result == "\"Cerrada\"")
                {
                    probar = true;
                    resultado = "La evaluación se ha cerrado exitosamente";
                    return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);
                }
                if (result == "Existe" || result == "\"Existe\"")
                {
                    resultado = "La evaluación no se ha cerrado, existe una evaluación cerrada para esta vigencia, si desea cerrar esta evaluación debe eliminar la evaluación que actualmente se encuetra cerrada para esta vigencia";
                    return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { probar, resultado }, JsonRequestBehavior.AllowGet);
        }
        //Se puede editar Javier Garcia
        /// <summary>
        /// Consulta y renderiza la información de los estándares,
        /// sub-estándares y criterios asociados al ciclo actual y un estandar guardado.
        /// </summary>
        /// <param name="idCiclo"></param>
        /// /// <param name="IdEstandar"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerCriteriosPorCicloEditar(int idCiclo, int idEval, int idElemento)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                string Mensajesalida = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { Mensaje = Mensajesalida });
            }

            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            //se consume el servicio rest para obtener los ciclos
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("idCiclo", idCiclo);
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", idEval.ToString());
            ServiceClient.AdicionarParametro("idElemento", idElemento);
            ServiceClient.AdicionarParametro("tipo", false);

            var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
            if (result != null)
            {
                string RutaArchivo1 = null;
                string RutaArchivo2 = null;
                string RutaArchivo3 = null;
                try
                {
                    RutaArchivo1 = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1));
                }
                catch (Exception)
                {
                }
                try
                {
                    RutaArchivo2 = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2));
                }
                catch (Exception)
                {
                }
                try
                {
                    RutaArchivo3 = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3));
                }
                catch (Exception)
                {
                }

                if (RutaArchivo1 != null)
                {
                    if (!System.IO.File.Exists(RutaArchivo1))
                    {
                        result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1 = null;
                        result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1 = null;
                        result.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload1 = null;
                    }
                }
                if (RutaArchivo2 != null)
                {
                    if (!System.IO.File.Exists(RutaArchivo2))
                    {
                        result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2 = null;
                        result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2 = null;
                        result.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload2 = null;
                    }
                }
                if (RutaArchivo3 != null)
                {
                    if (!System.IO.File.Exists(RutaArchivo3))
                    {
                        result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3 = null;
                        result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3 = null;
                        result.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload3 = null;
                    }
                }
                var datos = RenderRazorViewToString("_EditarEvaluacion", result);

                return Json(new { Datos = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        [HttpPost]
        public JsonResult EdicionCalificacion(CalificacionCriterioModel objCalificacion)
        {
            bool probar = false;
            string Mensaje = "La edición se realizó correctamente";
            if (ModelState.IsValid)
            {
                int calificacion = objCalificacion.IdValoracionCriterio;
                var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                if (objEvaluacion == null)
                    return Json(new { MensajeVal = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });
                #region validarArchivos
                bool eliminartodosArchivos = false;
                List<string> EliminarArchivos = new List<string>();
                List<string> MoverArchivosTemp = new List<string>();
                string[] Nombrearch = new string[3];
                Nombrearch[0] = objCalificacion.NombreArchivo1;
                Nombrearch[1] = objCalificacion.NombreArchivo2;
                Nombrearch[2] = objCalificacion.NombreArchivo3;
                string[] Rutaarch = new string[3];
                Rutaarch[0] = objCalificacion.Ruta1;
                Rutaarch[1] = objCalificacion.Ruta2;
                Rutaarch[2] = objCalificacion.Ruta3;
                string[] fdonw = new string[3];
                fdonw[0] = objCalificacion.Filedownload1;
                fdonw[1] = objCalificacion.Filedownload2;
                fdonw[2] = objCalificacion.Filedownload3;
                string[,] archivo = new string[2, 3];
                bool[] ExisteArchivo = new bool[3] { false, false, false };
                bool[] ArchivoTemp = new bool[3] { false, false, false };
                bool[] NombreArchivo = new bool[3] { false, false, false };

                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("idCiclo", objCalificacion.IdCiclo);
                ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
                ServiceClient.AdicionarParametro("IdEval", objCalificacion.IdEvaluacion.ToString());
                ServiceClient.AdicionarParametro("idElemento", objCalificacion.IdCriterio);
                ServiceClient.AdicionarParametro("tipo", false);

                var result1 = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                if (result1 != null)
                {
                    archivo[0, 0] = result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1;
                    archivo[1, 0] = result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1;
                    archivo[0, 1] = result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2;
                    archivo[1, 1] = result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2;
                    archivo[0, 2] = result1.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3;
                    archivo[1, 2] = result1.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3;
                }

                if (calificacion == (int)EnumPlanificacion.ValoracionStandares.NoAplica)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (archivo[0, i] != null && archivo[1, i] != null)
                        {
                            string path = Server.MapPath(Path.Combine(archivo[1, i], archivo[0, i]));
                            if (System.IO.File.Exists(path))
                            {
                                ExisteArchivo[i] = true;
                            }
                        }
                        if (Nombrearch[i] != null)
                        {
                            NombreArchivo[i] = true;
                            string path = Server.MapPath(Path.Combine(RutaArchivosBDTemp, Nombrearch[i]));
                            if (System.IO.File.Exists(path))
                            {
                                ArchivoTemp[i] = true;
                            }
                        }
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (NombreArchivo[i])
                        {
                            if (ExisteArchivo[i])
                            {
                                if (Nombrearch[i] == archivo[0, i])
                                {
                                    Rutaarch[i] = archivo[1, i];
                                    Nombrearch[i] = archivo[0, i];

                                }
                                else
                                {

                                    EliminarArchivos.Add(Server.MapPath(Path.Combine(archivo[1, i], archivo[0, i])));
                                    MoverArchivosTemp.Add(Nombrearch[i]);
                                }
                            }
                            else
                            {
                                if (ArchivoTemp[i])
                                {

                                    Rutaarch[i] = RutaArchivosBD;
                                    MoverArchivosTemp.Add(Nombrearch[i]);
                                }
                                else
                                {
                                    Nombrearch[i] = null;
                                    Rutaarch[i] = null;
                                    fdonw[i] = null;
                                }
                            }


                        }
                        else
                        {
                            if (ExisteArchivo[i])
                            {
                                EliminarArchivos.Add(Server.MapPath(Path.Combine(archivo[1, i], archivo[0, i])));
                                Nombrearch[i] = null;
                                Rutaarch[i] = null;
                                fdonw[i] = null;
                            }
                            else
                            {
                                Nombrearch[i] = null;
                                Rutaarch[i] = null;
                                fdonw[i] = null;
                            }
                        }
                    }



                }
                else
                {
                    eliminartodosArchivos = true;
                    for (int i = 0; i < 3; i++)
                    {
                        if (archivo[1, i] != null && archivo[0, i] != null)
                        {
                            EliminarArchivos.Add(Server.MapPath(Path.Combine(archivo[1, i], archivo[0, i])));
                        }
                        if (Nombrearch[i] != null)
                        {
                            string path = Server.MapPath(Path.Combine(RutaArchivosBDTemp, Nombrearch[i]));
                            if (System.IO.File.Exists(path))
                            {
                                EliminarArchivos.Add(path);
                            }
                        }
                        Nombrearch[i] = null;
                        Rutaarch[i] = null;
                        fdonw[i] = null;
                    }
                }



                #endregion
                var criterioCalificado = new EDEvaluacionEstandarMinimo()
                {
                    Ruta1 = Rutaarch[0],
                    Ruta2 = Rutaarch[1],
                    Ruta3 = Rutaarch[2],
                    Filedownload1 = fdonw[0],
                    Filedownload2 = fdonw[1],
                    Filedownload3 = fdonw[2],
                    NombreArchivo1 = Nombrearch[0],
                    NombreArchivo2 = Nombrearch[1],
                    NombreArchivo3 = Nombrearch[2],
                    IdEvaluacion = objCalificacion.IdEvaluacion,
                    Nit = objEvaluacion.NitEmpresa,
                    IdCiclo = objCalificacion.IdCiclo,
                    IdCriterio = objCalificacion.IdCriterio,
                    IdEmpresaEvaluar = objCalificacion.IdEmpresaEvaluar,
                    IdValoracionCriterio = objCalificacion.IdValoracionCriterio,
                    Justificacion = objCalificacion.Justificacion,
                    Actividades = objCalificacion.Actividades == null ? null : objCalificacion.Actividades.Select(a => new EDActividad()
                    {
                        Id_Actividad = a.Id_Actividad,
                        Descripcion = a.Descripcion,
                        Responsable = a.Responsable,
                        FechaFin = a.FechaFin,
                        Accion = a.Accion,
                        Id_Actividad_String = a.Id_Actividad_String
                    }).ToList()
                };
                //se consume el servicio post para guardar la información de los estandares minimos
                ServiceClient.EliminarParametros();
                var result = ServiceClient.SolicitarGuaardadoCriterioPorCiclo<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, criterioCalificado);

                if (result != null)
                {
                    #region ArchivosOperacion
                    if (result.Operacion)
                    {
                        foreach (var item in MoverArchivosTemp)
                        {
                            mover(item);
                        }
                        foreach (var item in EliminarArchivos)
                        {
                            eliminar(item);
                        }
                    }
                    else
                    {
                        if (eliminartodosArchivos)
                        {
                            foreach (var item in EliminarArchivos)
                            {
                                eliminar(item);
                            }
                        }
                    }
                    #endregion
                    var cicloObtenido = result;
                    var cicloActual = new CicloModel()
                    {
                        IdCiclo = cicloObtenido.Id_Ciclo,
                        Nombre = cicloObtenido.Nombre,
                        Porcentaje = cicloObtenido.Porcentaje_Max,
                        CantidadCriterios = cicloObtenido.CantidadCriterios,
                        StandPorEvaluar = cicloObtenido.StandPorEvaluar,
                        EstandarActual = cicloObtenido.Estandar == null ? null : new EstandarModel()
                        {
                            Id_Estandar = cicloObtenido.Estandar.Id_Estandar,
                            Descripcion = cicloObtenido.Estandar.Descripcion,
                            Porcentaje_Max = cicloObtenido.Estandar.Porcentaje_Max,
                            SubEstandarActual = cicloObtenido.Estandar.SubEstandar == null ? null : new SubEstandarModel()
                            {
                                Id_SubEstandar = cicloObtenido.Estandar.SubEstandar.Id_SubEstandar,
                                Descripcion_Corta = cicloObtenido.Estandar.SubEstandar.Descripcion_Corta,
                                Descripcion = cicloObtenido.Estandar.SubEstandar.Descripcion,
                                Procentaje_Max = cicloObtenido.Estandar.SubEstandar.Procentaje_Max,
                                CriterioActual = cicloObtenido.Estandar.SubEstandar.Criterio == null ? null : new CriterioModel()
                                {
                                    Id_Criterio = cicloObtenido.Estandar.SubEstandar.Criterio.Id_Criterio,
                                    Descripcion_Corta = cicloObtenido.Estandar.SubEstandar.Criterio.Descripcion_Corta,
                                    Descripcion = cicloObtenido.Estandar.SubEstandar.Criterio.Descripcion,
                                    Numeral = cicloObtenido.Estandar.SubEstandar.Criterio.Numeral,
                                    Marco_Legal = cicloObtenido.Estandar.SubEstandar.Criterio.Marco_Legal,
                                    Modo_Verificacion = cicloObtenido.Estandar.SubEstandar.Criterio.Modo_Verificacion
                                }
                            }
                        }
                    };
                    var datos = string.Empty;
                    var cicloCalificado = false;
                    var terminaCalfEstMin = false;
                    if (cicloActual.StandPorEvaluar == 0)
                    {
                        datos = cicloActual.IdCiclo.ToString();
                        cicloCalificado = true;
                    }
                    if (cicloActual.EstandarActual == null)
                        terminaCalfEstMin = true;
                    else
                        datos = RenderRazorViewToString("_ObtenerCriteriosPorCiclo", cicloActual);
                    return Json(new { MensajeVal = Mensaje, Validacion = probar, Datos = datos, Mensaje = "OK", CicloCalificado = cicloCalificado, TerminaCalfEstMin = terminaCalfEstMin });
                }
                else
                    return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        private string obtenernombreciclo(int id_Ciclo, string nombre)
        {

            switch (id_Ciclo)
            {
                case 1:
                    return string.Format("I. {0}", nombre);
                case 2:
                    return string.Format("II. {0}", nombre);
                case 3:
                    return string.Format("III. {0}", nombre);
                case 4:
                    return string.Format("IV. {0}", nombre);
                default:
                    return nombre;
            }
        }
        /// <summary>
        /// Consulta y renderiza la información de los estándares,
        /// sub-estándares y criterios asociados al ciclo actual.
        /// </summary>
        /// <param name="idCiclo"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerCriteriosPorCiclo(int idCiclo, int idEval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            //se consume el servicio rest para obtener los ciclos
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("idCiclo", idCiclo);
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdEval", idEval.ToString());
            //ServiceClient.AdicionarParametro("NIT", "234567654");
            var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadEvaluacionEstandaresMinimos, RestSharp.Method.GET);
            if (result != null)
            {
                var cicloObtenido = result;
                var cicloActual = new CicloModel()
                {
                    IdCiclo = cicloObtenido.Id_Ciclo,
                    Nombre = obtenernombreciclo(cicloObtenido.Id_Ciclo, cicloObtenido.Nombre),
                    Porcentaje = cicloObtenido.Porcentaje_Max,
                    CantidadCriterios = cicloObtenido.CantidadCriterios,
                    StandPorEvaluar = cicloObtenido.StandPorEvaluar,
                    EstandarActual = new EstandarModel()
                    {
                        Id_Estandar = cicloObtenido.Estandar.Id_Estandar,
                        Descripcion = cicloObtenido.Estandar.Descripcion,
                        Porcentaje_Max = cicloObtenido.Estandar.Porcentaje_Max,
                        SubEstandarActual = new SubEstandarModel()
                        {
                            Id_SubEstandar = cicloObtenido.Estandar.SubEstandar.Id_SubEstandar,
                            Descripcion_Corta = cicloObtenido.Estandar.SubEstandar.Descripcion_Corta,
                            Descripcion = cicloObtenido.Estandar.SubEstandar.Descripcion,
                            Procentaje_Max = cicloObtenido.Estandar.SubEstandar.Procentaje_Max,
                            CriterioActual = new CriterioModel()
                            {
                                Id_Criterio = cicloObtenido.Estandar.SubEstandar.Criterio.Id_Criterio,
                                Descripcion = cicloObtenido.Estandar.SubEstandar.Criterio.Descripcion,
                                Numeral = cicloObtenido.Estandar.SubEstandar.Criterio.Numeral,
                                Marco_Legal = cicloObtenido.Estandar.SubEstandar.Criterio.Marco_Legal,
                                Modo_Verificacion = cicloObtenido.Estandar.SubEstandar.Criterio.Modo_Verificacion
                            }
                        }
                    }
                };
                var datos = RenderRazorViewToString("_ObtenerCriteriosPorCiclo", cicloActual);
                return Json(new { Datos = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        [HttpPost]
        public JsonResult AgregarNuevaActividad(ActividadModel nuevaActividad)
        {
            if (ModelState.IsValid)
            {
                var datos = RenderRazorViewToString("_NuevaActividad", nuevaActividad);
                return Json(new { Data = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Data = string.Empty, Mensaje = "ERROR" });
        }
        #region Plan de accion
        /// <summary>
        /// Obtiene las Actividades generadas durante la evaluacion y se presentan como 
        /// plan de accion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PlanDeAccion(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("idEval", ideval);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDActividad>(urlServicioPlanificacion, capacidadPlanAccion, RestSharp.Method.GET);

            if (result != null && result.Count() > 0)
            {
                var Actividades = result.Select(c => new ActividadModel
                {
                    Accion = c.Accion,
                    Descripcion = c.Descripcion,
                    Responsable = c.Responsable,
                    strFechaFin = string.Format("{0}/{1}/{2}", c.FechaFin.Year, c.FechaFin.Month, c.FechaFin.Day)
                }).ToList();

                var datos = RenderRazorViewToString("_PlanAccionEstandaresMinimos", Actividades);
                return Json(new { Data = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Data = string.Empty, Mensaje = "ERROR" });
        }
        /// <summary>
        /// Descarga el plan de accion a archivo excel
        /// </summary>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        public FileResult DescargarPlanAccionExccel(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            ServiceClient.EliminarParametros();

            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            var result = ServiceClient.ObtenerObjetoJsonRestFul<byte[]>(urlServicioPlanificacion, capacidadPlanAccionExcel, RestSharp.Method.GET);
            return File(result, "application/vnd.ms-excel", "PlanDeAccion.xlsx");
        }
        [AllowAnonymous]
        public ActionResult DescargarPlanAccionPDF(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("idEval", ideval);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDActividad>(urlServicioPlanificacion, capacidadPlanAccion, RestSharp.Method.GET);

            if (result != null && result.Count() > 0)
            {
                var Actividades = result.Select(c => new ActividadModel
                {
                    Accion = c.Accion,
                    Descripcion = c.Descripcion,
                    Responsable = c.Responsable,
                    strFechaFin = string.Format("{0}/{1}/{2}", c.FechaFin.Year, c.FechaFin.Month, c.FechaFin.Day),
                    Vigencia=c.Vigencia
                }).ToList();

                string EncodedRazonSocial = System.Net.WebUtility.UrlEncode(objEvaluacion.RazonSocialEmpresa);
                string EncodedNit = System.Net.WebUtility.UrlEncode(objEvaluacion.NitEmpresa);
                string EncodedNombreInforme = System.Net.WebUtility.UrlEncode("PLAN DE MEJORA PARA LOS ESTÁNDARES MÍNIMOS SGSST");

                var footurl = "https://alissta.gov.co/Acciones/Footer";
                var headerurl = "https://alissta.gov.co/Acciones/Header?NombreEmpresa=" + EncodedRazonSocial + "&NitEmpresa=" + EncodedNit + "&NombreInforme=" + EncodedNombreInforme;
                string cusomtSwitches = string.Format("--footer-line --print-media-type --allow {0} --footer-html {0} --header-line --print-media-type --allow {1} --header-html {1} --header-spacing 5",
           footurl, headerurl);

                return new ViewAsPdf("DescargarPlanAccionPDF", Actividades)
                {
                    FileName = "PlanDeAccion.pdf"
                    ,
                    CustomSwitches = cusomtSwitches
                };

            }
            else
            {
                List<ActividadModel> Actividades = new List<ActividadModel>();
                return new ViewAsPdf("DescargarPlanAccionPDF", Actividades)
                {
                    FileName = "PlanDeAccion.pdf"
                };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actividades"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Renderizarctividades(ActividadModel[] actividades)
        {
            var datos = new StringBuilder();
            if (actividades != null && actividades.Count() > 0)
            {
                foreach (var actividad in actividades)
                    datos.Append(RenderRazorViewToString("_NuevaActividad", actividad));
                return Json(new { Data = datos.ToString(), Mensaje = "OK" });
            }
            else
                return Json(new { Data = string.Empty, Mensaje = "ERROR" });
        }
        [HttpPost]
        public JsonResult CalificarCriterioPorCiclo(CalificacionCriterioModel objCalificacion)
        {
            if (ModelState.IsValid)
            {
                var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                if (objEvaluacion == null)
                    return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });





                string PathOrigen1 = null;
                string Pathdestino1 = null;
                string PathOrigen2 = null;
                string Pathdestino2 = null;
                string PathOrigen3 = null;
                string Pathdestino3 = null;
                if (objCalificacion.NombreArchivo1 != null)
                {
                    PathOrigen1 = Server.MapPath(Path.Combine(RutaArchivosBDTemp, objCalificacion.NombreArchivo1));
                    Pathdestino1 = Server.MapPath(Path.Combine(RutaArchivosBD, objCalificacion.NombreArchivo1));
                }
                if (objCalificacion.NombreArchivo2 != null)
                {
                    PathOrigen2 = Server.MapPath(Path.Combine(RutaArchivosBDTemp, objCalificacion.NombreArchivo2));
                    Pathdestino2 = Server.MapPath(Path.Combine(RutaArchivosBD, objCalificacion.NombreArchivo2));
                }
                if (objCalificacion.NombreArchivo3 != null)
                {
                    PathOrigen3 = Server.MapPath(Path.Combine(RutaArchivosBDTemp, objCalificacion.NombreArchivo3));
                    Pathdestino3 = Server.MapPath(Path.Combine(RutaArchivosBD, objCalificacion.NombreArchivo3));
                }


                EDEvaluacionEmpresa validar = new EDEvaluacionEmpresa();

                validar.Pk_Id_EvaluacionEmpresa = objCalificacion.IdEvaluacion;
                validar.Estado = objCalificacion.IdCriterio;

                ServiceClient.EliminarParametros();
                var resultbool = ServiceClient.PeticionesPostJsonRestFulRespuetaBoolEval<bool>(urlServicioPlanificacion, capacidadValidarCriterio, validar);

                bool ProbarGuardado = resultbool;
                if (ProbarGuardado)
                {
                    return Json(new { Data = "Error de validación", Mensaje = "ERROR" });
                }
                else
                {
                    var criterioCalificado = new EDEvaluacionEstandarMinimo()
                    {
                        RutaTempServer1 = PathOrigen1,
                        RutaTempServer2 = PathOrigen2,
                        RutaTempServer3 = PathOrigen3,

                        RutaDBServer1 = Pathdestino1,
                        RutaDBServer2 = Pathdestino2,
                        RutaDBServer3 = Pathdestino3,

                        RutaTemp = RutaArchivosBDTemp,
                        RutaDB = RutaArchivosBD,
                        Filedownload1 = objCalificacion.Filedownload1,
                        Filedownload2 = objCalificacion.Filedownload2,
                        Filedownload3 = objCalificacion.Filedownload3,
                        NombreArchivo1 = objCalificacion.NombreArchivo1,
                        NombreArchivo2 = objCalificacion.NombreArchivo2,
                        NombreArchivo3 = objCalificacion.NombreArchivo3,
                        IdEvaluacion = objCalificacion.IdEvaluacion,
                        Nit = objEvaluacion.NitEmpresa,
                        IdCiclo = objCalificacion.IdCiclo,
                        IdCriterio = objCalificacion.IdCriterio,
                        IdEmpresaEvaluar = objCalificacion.IdEmpresaEvaluar,
                        IdValoracionCriterio = objCalificacion.IdValoracionCriterio,
                        Justificacion = objCalificacion.Justificacion,
                        Actividades = objCalificacion.Actividades == null ? null : objCalificacion.Actividades.Select(a => new EDActividad()
                        {
                            Id_Actividad = a.Id_Actividad,
                            Descripcion = a.Descripcion,
                            Responsable = a.Responsable,
                            FechaFin = a.FechaFin
                        }).ToList()
                    };



                    //se consume el servicio post para guardar la información de los estandares minimos
                    ServiceClient.EliminarParametros();
                    var result = ServiceClient.SolicitarGuaardadoCriterioPorCiclo<EDCiclo>(urlServicioPlanificacion, capacidadEvaluacionEstandaresMinimos, criterioCalificado);
                    if (result != null)
                    {
                        var cicloObtenido = result;
                        var cicloActual = new CicloModel()
                        {
                            IdCiclo = cicloObtenido.Id_Ciclo,
                            Nombre = cicloObtenido.Nombre,
                            Porcentaje = cicloObtenido.Porcentaje_Max,
                            CantidadCriterios = cicloObtenido.CantidadCriterios,
                            StandPorEvaluar = cicloObtenido.StandPorEvaluar,
                            EstandarActual = cicloObtenido.Estandar == null ? null : new EstandarModel()
                            {
                                Id_Estandar = cicloObtenido.Estandar.Id_Estandar,
                                Descripcion = cicloObtenido.Estandar.Descripcion,
                                Porcentaje_Max = cicloObtenido.Estandar.Porcentaje_Max,
                                SubEstandarActual = cicloObtenido.Estandar.SubEstandar == null ? null : new SubEstandarModel()
                                {
                                    Id_SubEstandar = cicloObtenido.Estandar.SubEstandar.Id_SubEstandar,
                                    Descripcion_Corta = cicloObtenido.Estandar.SubEstandar.Descripcion_Corta,
                                    Descripcion = cicloObtenido.Estandar.SubEstandar.Descripcion,
                                    Procentaje_Max = cicloObtenido.Estandar.SubEstandar.Procentaje_Max,
                                    CriterioActual = cicloObtenido.Estandar.SubEstandar.Criterio == null ? null : new CriterioModel()
                                    {
                                        Id_Criterio = cicloObtenido.Estandar.SubEstandar.Criterio.Id_Criterio,
                                        Descripcion_Corta = cicloObtenido.Estandar.SubEstandar.Criterio.Descripcion_Corta,
                                        Descripcion = cicloObtenido.Estandar.SubEstandar.Criterio.Descripcion,
                                        Numeral = cicloObtenido.Estandar.SubEstandar.Criterio.Numeral,
                                        Marco_Legal = cicloObtenido.Estandar.SubEstandar.Criterio.Marco_Legal,
                                        Modo_Verificacion = cicloObtenido.Estandar.SubEstandar.Criterio.Modo_Verificacion
                                    }
                                }
                            }
                        };
                        var datos = string.Empty;
                        var cicloCalificado = false;
                        var terminaCalfEstMin = false;
                        if (cicloActual.StandPorEvaluar == 0)
                        {
                            datos = "<h5>Redirigiendo...</h5>";
                            cicloCalificado = true;
                        }
                        if (cicloActual.EstandarActual == null)
                            terminaCalfEstMin = true;
                        else
                            datos = RenderRazorViewToString("_ObtenerCriteriosPorCiclo", cicloActual);
                        return Json(new { Datos = datos, Mensaje = "OK", CicloCalificado = cicloCalificado, TerminaCalfEstMin = terminaCalfEstMin });
                    }
                    else
                        return Json(new { Datos = string.Empty, Mensaje = "REDIRIGIR" });
                }



            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        [HttpPost]
        public JsonResult validarCriterio(int ideval, int idcriterio)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });

            EDEvaluacionEmpresa EDEvaluacionEmpresa = new EDEvaluacionEmpresa();
            EDEvaluacionEmpresa.Pk_Id_EvaluacionEmpresa = ideval;
            EDEvaluacionEmpresa.Fk_Id_Empresa = objEvaluacion.IdEmpresa;
            EDEvaluacionEmpresa.Estado = idcriterio;

            ServiceClient.EliminarParametros();
            var result = ServiceClient.PeticionesPostJsonRestFulRespuetaBoolEval<bool>(urlServicioPlanificacion, capacidadValidarEvaluacion, EDEvaluacionEmpresa);

            bool ProbarGuardado = result;
            if (ProbarGuardado)
            {
                return Json(new { Mensaje = "OK" });
            }
            else
            {
                return Json(new { Mensaje = "ERROR" });
            }
        }
        [HttpPost]
        public JsonResult ObtenerInformeExccel()
        {
            return Json(new { Datos = "", Mensaje = "OK" });
        }
        /// <summary>
        /// Descarga el excel de todos los estandares con su respectiva calificacion
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public FileResult DescargarInformeExccel(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            ServiceClient.EliminarParametros();
            //ServiceClient.AdicionarParametro("NIT", "860123006");
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerObjetoJsonRestFul<byte[]>(urlServicioPlanificacion, capacidadReporteEstandaresMinimos, RestSharp.Method.GET);
            return File(result, "application/vnd.ms-excel", "EstandaresMinimos.xlsx");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerInformeParcial(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //ServiceClient.AdicionarParametro("NIT", "234567654");
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadReporteRespuestasEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0)
            {
                var ciclos = result.Select(c => new CicloModel()
                {
                    IdCiclo = c.Id_Ciclo,
                    Nombre = c.Nombre,
                    PorcenObtenido = c.PorcenObtenido,
                    PorcenRespondido = c.PorcenRespondido,
                    Porcentaje = c.Porcentaje_Max
                }).ToList();
                var datos = RenderRazorViewToString("_InformeParcial", ciclos);
                return Json(new { Datos = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        [HttpPost]
        public JsonResult ObtenerInformeFinal(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadReporteRespuestasEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0)
            {
                List<CicloModel> CiclosM = new List<CicloModel>();
                foreach (var item in result)
                {
                    var ciclo = new CicloModel()
                    {
                        IdCiclo = item.Id_Ciclo,
                        Nombre = item.Nombre,
                        PorcenObtenido = item.PorcenObtenido,
                        PorcenRespondido = item.PorcenRespondido,
                        Porcentaje = item.Porcentaje_Max,
                        puntoObtenidos = item.puntoObtenidos,
                        Estandares = item.Estandares == null ? null :
                        item.Estandares.Select(e => new EstandarModel()
                        {
                            Porcentaje_Max = e.Porcentaje_Max,
                            Id_Estandar = e.Id_Estandar,
                            Descripcion = e.Descripcion,
                            CalificacionFinal = e.Calificacion,
                            Porcentaje = e.Porcentaje,
                        }).ToList()
                    };
                    if (ciclo != null)
                    {
                        CiclosM.Add(ciclo);
                    }
                }
                //EstandarModel EstandarModel = new EstandarModel();

                //EstandarModel = result.Estandares.Select(e => new EstandarModel()
                //{
                //    Id_Estandar = e.Id_Estandar,
                //    Descripcion = e.Descripcion,
                //    CalificacionFinal = e.Calificacion
                //}).ToList();

                //var ciclos = result.Select(c => new CicloModel()
                //{
                //    IdCiclo = c.Id_Ciclo,
                //    Nombre = c.Nombre,
                //    PorcenObtenido = c.PorcenObtenido,
                //    PorcenRespondido = c.PorcenRespondido,
                //    Porcentaje = c.Porcentaje_Max,
                //    puntoObtenidos = c.puntoObtenidos,

                //}).ToList();
                var datos = RenderRazorViewToString("_InformeFinal", CiclosM);
                return Json(new { Datos = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        [AllowAnonymous]
        public JsonResult ObtenerCalificacionEstandares(int idCiclo, int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "NOTFOUND" });
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdCiclo", idCiclo);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadReporteCalificacionEstandaresMinimosFinal, RestSharp.Method.GET);
            if (result != null)
            {
                var ciclo = new CicloModel()
                {
                    IdCiclo = result.Id_Ciclo,
                    Nombre = result.Nombre,
                    PorcenObtenido = result.PorcenObtenido,
                    PorcenRespondido = result.PorcenRespondido,
                    Porcentaje = result.Porcentaje_Max,
                    Estandares = result.Estandares == null ? null :
                    result.Estandares.Select(e => new EstandarModel()
                    {
                        Id_Estandar = e.Id_Estandar,
                        Descripcion = e.Descripcion,
                        CalificacionFinal = e.Calificacion
                    }).ToList()
                };
                return Json(new { Datos = ciclo, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "NOTFOUND" });
        }
        #region Informes excel calificacion final
        [AllowAnonymous]
        public JsonResult CalificacionFinal(int idCiclo)
        {
            TempData["idciclo"] = idCiclo;
            return Json(new { Datos = "", Mensaje = "OK" });
        }
        [AllowAnonymous]
        public FileResult ObtenerCalificacionFinalExcel(int ideval)
        {
            int idCiclo = 1;
            if (TempData["idciclo"] != null)
            {
                idCiclo = int.Parse(TempData["idciclo"].ToString());
            }
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            ServiceClient.EliminarParametros();

            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("IdCiclo", idCiclo);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerObjetoJsonRestFul<byte[]>(urlServicioPlanificacion, CapacidadReporteExcelEstandaresMinimosCiclo, RestSharp.Method.GET);

            return File(result, "application/vnd.ms-excel", "CalificacionCiclo.xlsx");

        }
        #endregion
        #region Informes calificacion parcial
        /// <summary>
        /// obtiene el porcentaje de avance del puntaje obtenido
        /// respecto al puntaje total
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerPorcentajePuntajeDePuntajeTotal(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //ServiceClient.AdicionarParametro("NIT", "234567654");
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadReportePuntajeEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0)
            {
                var ciclos = result.Select(c => new CicloModel()
                {
                    IdCiclo = c.Id_Ciclo,
                    Nombre = c.Nombre,
                    PorcenObtenido = Math.Round(c.PorcenObtenido, 2),
                    PorcenRespondido = Math.Round(c.PorcenRespondido, 2),
                    Porcentaje = c.Porcentaje_Max
                }).ToList();
                return Json(new { Datos = ciclos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        /// <summary>
        /// Obtiene el excel del informe parcial de porcentaje obtenido al momento por ciclo
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public FileResult ObtenerExcelPorcentajeObtenido(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            ServiceClient.EliminarParametros();
            //ServiceClient.AdicionarParametro("NIT", "860123006");
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerObjetoJsonRestFul<byte[]>(urlServicioPlanificacion, CapacidadReporteExcelPuntajeEstandaresMinimos, RestSharp.Method.GET);

            return File(result, "application/vnd.ms-excel", "PorcentajeObtenido.xlsx");

        }
        /// <summary>
        /// obtiene el porcentaje de avance sobre las respuestas dadas
        /// respecto al total de preguntas
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ObtenerPorcentajeRespuestasDeTotalPreguntas(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objEvaluacion == null)
                return Json(new { Data = "Debe estar autenticado para realizar la evalación.", Mensaje = "ERROR" });
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);

            //ServiceClient.AdicionarParametro("NIT", "234567654");
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDCiclo>(urlServicioPlanificacion, capacidadReporteRespuestasEstandaresMinimos, RestSharp.Method.GET);
            if (result != null && result.Count() > 0)
            {
                var ciclos = result.Select(c => new CicloModel()
                {
                    IdCiclo = c.Id_Ciclo,
                    Nombre = c.Nombre,
                    PorcenObtenido = Math.Round(c.PorcenObtenido, 2),
                    PorcenRespondido = Math.Round(c.PorcenRespondido, 2),
                    Porcentaje = c.Porcentaje_Max
                }).ToList();
                return Json(new { Datos = ciclos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "ERROR" });
        }
        /// <summary>
        /// Obtiene el excel del informe parcial de porcentaje obtenido al momento por ciclo
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public FileResult ObtenerExcelPorcentajeDeRespuestas(int ideval)
        {
            var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            ServiceClient.EliminarParametros();
            //ServiceClient.AdicionarParametro("NIT", "860123006");
            ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
            ServiceClient.AdicionarParametro("Idval", ideval);
            //se consume el servicio post para guardar la información de la evaluación inicial
            var result = ServiceClient.ObtenerObjetoJsonRestFul<byte[]>(urlServicioPlanificacion, CapacidadReporteExcelRespuestasEstandaresMinimos, RestSharp.Method.GET);
            return File(result, "application/vnd.ms-excel", "PorcentajeRespuestas.xlsx");
        }
        [AllowAnonymous]
        public ActionResult EvaluacionPositiva()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado para visualizar los Indicadores.";
                return View();
            }
            var lnUsuario = new LNUsuario();
            EvaluacionPositivaModel modelEvalPositiva = new EvaluacionPositivaModel();
            //ServiceClient.EliminarParametros();
            //ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            //var resultAno = ServiceClient.ObtenerObjetoJsonRestFul<int>(urlServicioPlanificacion, CapacidadObtenerAnoInicioEmpresa, RestSharp.Method.GET);
            //if (resultAno > 0)
            //{
            //    modelEvalPositiva.Anios = GetAnios(resultAno);
            //}
            //else
            modelEvalPositiva.Anios = GetAnios(2011);
            modelEvalPositiva.RazonSocial = usuarioActual.RazonSocialEmpresa;
            return View(modelEvalPositiva);
        }
        [HttpPost]
        public ActionResult EvaluacionPositiva(EvaluacionPositivaModel EvalPositiva)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado.";
                return View();
            }

            EvaluacionPositivaModel modelEvalPositiva = new EvaluacionPositivaModel();
            if (!ModelState.IsValid)
            {
                var lnUsuario = new LNUsuario();
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                var resultAno = ServiceClient.ObtenerObjetoJsonRestFul<int>(urlServicioPlanificacion, CapacidadObtenerAnoInicioEmpresa, RestSharp.Method.GET);
                if (resultAno > 0)
                {
                    modelEvalPositiva.Anios = GetAnios(resultAno);
                }
                else
                    modelEvalPositiva.Anios = GetAnios(2010);

                modelEvalPositiva.RazonSocial = usuarioActual.RazonSocialEmpresa;

                return View(modelEvalPositiva);
            }
            else
            {
                var lnUsuario = new LNUsuario();
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                var resultAno = ServiceClient.ObtenerObjetoJsonRestFul<int>(urlServicioPlanificacion, CapacidadObtenerAnoInicioEmpresa, RestSharp.Method.GET);
                if (resultAno > 0)
                {
                    modelEvalPositiva.Anios = GetAnios(resultAno);
                }
                else
                    modelEvalPositiva.Anios = GetAnios(2010);

                modelEvalPositiva.RazonSocial = usuarioActual.RazonSocialEmpresa;

                var login = new GestposService.ws_loginSoapClient();
                var parametro = new GestposService.paramObtenerLink();

                parametro.codi_usu = usuarioActual.Documento;
                parametro.xml_params = string.Format("<rt><anho_gest>{0}</anho_gest><tdoc_emp>{1}</tdoc_emp><ndoc_emp>{2}</ndoc_emp></rt>", EvalPositiva.anioseleccionado, "NI", usuarioActual.NitEmpresa);
                parametro.modulo = GestposService.modulo.eval_plan_gestpos;
                var ruta = new GestposService.rtaObtenerLink();
                try
                {
                    ruta = login.obtenerLink(parametro);
                }
                catch
                {
                    ruta = null;
                }
                if (ruta == null)
                    modelEvalPositiva.url = "../Content/ErrorPage.html";
                else if (ruta.valido < 0)
                    modelEvalPositiva.url = "../Content/ErrorPage.html";
                else
                    modelEvalPositiva.url = ruta.url_sitio;

                return View(modelEvalPositiva);
            }
        }
        #endregion
        [HttpPost]
        public JsonResult listaPlanMejora(List<String> values)
        {
            List<string> ListaArchivos = new List<string>();
            bool probar = false;
            string resultado = "El archivo se encuentra disponible";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                resultado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { probar, resultado });
            }

            int ideval = -1;
            int idelem = -1;
            int idciclo = -1;

            if (values[0] != null & values[1] != null & values[2] != null)
            {
                if (int.TryParse(values[0], out ideval))
                {
                    if (int.TryParse(values[1], out idelem))
                    {
                        if (int.TryParse(values[2], out idciclo))
                        {
                            ServiceClient.EliminarParametros();
                            ServiceClient.AdicionarParametro("idCiclo", idciclo);
                            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                            ServiceClient.AdicionarParametro("IdEval", ideval.ToString());
                            ServiceClient.AdicionarParametro("idElemento", idelem);
                            ServiceClient.AdicionarParametro("tipo", true);

                            var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                            if (result != null)
                            {
                                List<EDActividad> Listaplan = new List<EDActividad>();

                                if (result.Estandar.SubEstandar.Criterio.Evaluacion.Actividades != null)
                                {
                                    Listaplan = result.Estandar.SubEstandar.Criterio.Evaluacion.Actividades;
                                    foreach (var item in Listaplan)
                                    {
                                        item.FechaFinString = item.FechaFin.ToShortDateString();
                                    }

                                    probar = true;
                                    return Json(new { probar, resultado, Listaplan });
                                }


                            }
                        }
                        else
                        {
                            resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                            return Json(new { probar, resultado });
                        }
                    }
                    else
                    {
                        resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                        return Json(new { probar, resultado });
                    }
                }
                else
                {
                    resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                    return Json(new { probar, resultado });
                }
            }
            else
            {
                resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                return Json(new { probar, resultado });
            }




            return Json(new { probar, resultado });
        }
        #endregion
        #region Archivos
        [HttpPost]
        public JsonResult listaArchivos(List<String> values)
        {
            List<string> ListaArchivos = new List<string>();
            bool probar = false;
            string resultado = "El archivo se encuentra disponible";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                resultado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { probar, resultado });
            }

            int ideval = -1;
            int idelem = -1;
            int idciclo = -1;

            if (values[0] != null & values[1] != null & values[2] != null)
            {
                if (int.TryParse(values[0], out ideval))
                {
                    if (int.TryParse(values[1], out idelem))
                    {
                        if (int.TryParse(values[2], out idciclo))
                        {
                            ServiceClient.EliminarParametros();
                            ServiceClient.AdicionarParametro("idCiclo", idciclo);
                            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                            ServiceClient.AdicionarParametro("IdEval", ideval.ToString());
                            ServiceClient.AdicionarParametro("idElemento", idelem);
                            ServiceClient.AdicionarParametro("tipo", true);

                            var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                            if (result != null)
                            {
                                string[] NombreArchivoBd = new string[3] { result.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload1, result.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload2, result.Estandar.SubEstandar.Criterio.Evaluacion.Filedownload3 };
                                string[] NombreArchivoBd1 = new string[3] { result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3 };
                                string justificacion = result.Estandar.SubEstandar.Criterio.Evaluacion.Justificacion;
                                probar = true;
                                return Json(new { probar, resultado, NombreArchivoBd, NombreArchivoBd1, justificacion });
                            }
                        }
                        else
                        {
                            resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                            return Json(new { probar, resultado });
                        }
                    }
                    else
                    {
                        resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                        return Json(new { probar, resultado });
                    }
                }
                else
                {
                    resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                    return Json(new { probar, resultado });
                }
            }
            else
            {
                resultado = "No se completó el envió del formulario para obtener los archivos en este ciclo";
                return Json(new { probar, resultado });
            }




            return Json(new { probar, resultado });
        }
        [HttpPost]
        public JsonResult ValidarArchivos(List<String> values)
        {
            bool probar = false;
            string resultado = "El archivo se encuentra disponible";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                resultado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { probar, resultado });
            }

            string[] NombreArchivo = new string[3] { values[0], values[1], values[2] };


            string IdEval = values[3];
            string Idciclo = values[4];
            string Idelemento = values[5];

            if (Idelemento != null && Idelemento != null & IdEval != null & Idciclo != null)
            {
                int cicloint = 0;
                int Idelementoint = 0;
                if (int.TryParse(Idciclo, out cicloint))
                {
                }
                if (int.TryParse(Idelemento, out Idelementoint))
                {
                }
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("idCiclo", cicloint);
                ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                ServiceClient.AdicionarParametro("IdEval", IdEval.ToString());
                ServiceClient.AdicionarParametro("idElemento", Idelementoint);
                ServiceClient.AdicionarParametro("tipo", true);

                var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                if (result != null)
                {
                    string[] NombreArchivoBd = new string[3] { result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3 };
                    string[] RutaBd = new string[3] { result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1, result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2, result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3 };
                    for (int i = 0; i < 3; i++)
                    {
                        if (NombreArchivo[i] != null)
                        {
                            string pathtemp = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivo[i]));
                            string pathbd = "";
                            if (NombreArchivoBd[0] != null & RutaBd[0] != null)
                            {
                                if (NombreArchivoBd[0] == NombreArchivo[i])
                                {
                                    pathbd = Server.MapPath(Path.Combine(RutaBd[0], NombreArchivoBd[0]));
                                }
                            }
                            try
                            {
                                if (System.IO.File.Exists(pathtemp))
                                {
                                    probar = true;
                                }
                            }
                            catch (Exception)
                            {
                            }
                            try
                            {
                                if (System.IO.File.Exists(pathbd))
                                {
                                    probar = true;
                                }
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }

            return Json(new { probar, resultado });
        }
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        private void CrearCarpeta(string path)
        {
            bool existeCarpeta = Directory.Exists(Server.MapPath(path));
            if (!existeCarpeta)
            {
                Directory.CreateDirectory(Server.MapPath(path));
            }

        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            bool probar = false;
            string resultado = "";
            string[] NombreArchivos = new string[3];
            string[] NombreArchivos_short = new string[3];
            string[] NuevoNombreArchivos = new string[3];
            string[] NuevoNombreArchivos_short = new string[3];
            bool[] display = new bool[3] { false, false, false };
            if (Request.Files.Count > 0)
            {
                string ValImagen1 = string.Empty;
                string ValImagen2 = string.Empty;
                string ValImagen3 = string.Empty;
                string ValImagen1s = string.Empty;
                string ValImagen2s = string.Empty;
                string ValImagen3s = string.Empty;
                try
                {
                    ValImagen1 = Request.Form[0].ToString();
                    ValImagen2 = Request.Form[1].ToString();
                    ValImagen3 = Request.Form[2].ToString();
                    ValImagen1s = Request.Form[3].ToString();
                    ValImagen2s = Request.Form[4].ToString();
                    ValImagen3s = Request.Form[5].ToString();
                }
                catch (Exception)
                {
                    resultado = "";
                    return Json(new { probar, resultado });
                }
                NombreArchivos[0] = ValImagen1;
                NombreArchivos[1] = ValImagen2;
                NombreArchivos[2] = ValImagen3;
                NombreArchivos_short[0] = ValImagen1s;
                NombreArchivos_short[1] = ValImagen2s;
                NombreArchivos_short[2] = ValImagen3s;
                int PosicionVacia = -1;
                for (int i = 0; i < 3; i++)
                {
                    if (NombreArchivos[i] == string.Empty)
                    {
                        PosicionVacia = i;
                    }
                    else
                    {
                        string PathOrigen = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivos[i]));
                        if (!System.IO.File.Exists(PathOrigen))
                        {
                            PosicionVacia = i;
                        }
                    }
                }
                if (PosicionVacia == -1)
                {
                    resultado = "El límite de archivos que el usuario puede cargar es de 3, por favor si desea agregar este archivo primero elimine un archivo ya cargado";
                    return Json(new { probar, resultado });
                }
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        if (file != null)
                        {
                            CrearCarpeta(RutaArchivosBDTemp);
                            CrearCarpeta(RutaArchivosBD);
                            string substring = "evalestmin_file_" + DateTime.Now.ToString().Replace(" ", "").Replace(".", "").Replace(":", "").Replace("/", "");
                            string ImgFileName = substring + file.FileName;
                            string pathsave = Server.MapPath(Path.Combine(RutaArchivosBDTemp, ImgFileName));
                            file.SaveAs(pathsave);
                            NombreArchivos[PosicionVacia] = ImgFileName;
                            NombreArchivos_short[PosicionVacia] = file.FileName;
                            int IndexNuevo = 0;
                            for (int i1 = 0; i1 < 3; i1++)
                            {
                                if (NombreArchivos[i1] == string.Empty)
                                {
                                    display[i1] = false;
                                }
                                else
                                {
                                    string PathOrigen = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivos[i1]));
                                    if (!System.IO.File.Exists(PathOrigen))
                                    {
                                        display[i1] = false;
                                    }
                                    else
                                    {
                                        NuevoNombreArchivos_short[IndexNuevo] = NombreArchivos_short[i1];
                                        NuevoNombreArchivos[IndexNuevo] = NombreArchivos[i1];
                                        try
                                        {
                                            display[IndexNuevo] = true;
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        IndexNuevo = IndexNuevo + 1;
                                    }
                                }
                            }
                        }
                        else
                        {
                            probar = false;
                            resultado = "El archivo que se intento subir no es una imagen o no es un archivo soportado, por favor intente de nuevo con otra imagen";
                            return Json(new { probar, resultado });
                        }
                    }
                    probar = true;
                    return Json(new { probar, resultado, NuevoNombreArchivos, display, NuevoNombreArchivos_short });
                }
                catch (Exception ex)
                {
                    resultado = "No se pudo completar la operación, el tamaño del archivo probablemente es mayor a 4 MB ";
                    return Json(new { probar, resultado });
                }
            }
            else
            {
                resultado = "No ha seleccionado un archivo, antes de adjuntar asegurese que exista un archivo";
                return Json(new { probar, resultado });
            }
        }
        [HttpPost]
        public ActionResult UploadFiles_ed()
        {

            bool probar = false;
            string resultado = "";


            string[] NombreArchivos = new string[3];
            string[] NombreArchivos_short = new string[3];
            string[] NuevoNombreArchivos = new string[3];
            string[] NuevoNombreArchivos_short = new string[3];
            string[] Carpeta = new string[3];
            string[] Paths = new string[3];
            bool[] display = new bool[3] { false, false, false };
            if (Request.Files.Count > 0)
            {

                string idCiclos = Request.Form[9].ToString();
                string idEvals = Request.Form[10].ToString();
                string idElementos = Request.Form[11].ToString();
                int idCiclo = 0;
                int idElemento = 0;


                if (int.TryParse(idCiclos, out idCiclo))
                {
                }
                if (int.TryParse(idElementos, out idElemento))
                {
                }


                var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("idCiclo", idCiclo);
                ServiceClient.AdicionarParametro("NIT", objEvaluacion.NitEmpresa);
                ServiceClient.AdicionarParametro("IdEval", idEvals);
                ServiceClient.AdicionarParametro("idElemento", idElemento);
                ServiceClient.AdicionarParametro("tipo", true);

                var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);

                if (result != null)
                {
                    string ValImagen1 = string.Empty;
                    string ValImagen2 = string.Empty;
                    string ValImagen3 = string.Empty;
                    string ValImagen1s = string.Empty;
                    string ValImagen2s = string.Empty;
                    string ValImagen3s = string.Empty;
                    string ValImagen1c = string.Empty;
                    string ValImagen2c = string.Empty;
                    string ValImagen3c = string.Empty;
                    string IdEHM = string.Empty;
                    try
                    {
                        ValImagen1 = Request.Form[0].ToString();
                        ValImagen2 = Request.Form[1].ToString();
                        ValImagen3 = Request.Form[2].ToString();
                        ValImagen1s = Request.Form[3].ToString();
                        ValImagen2s = Request.Form[4].ToString();
                        ValImagen3s = Request.Form[5].ToString();
                        ValImagen1c = Request.Form[6].ToString();
                        ValImagen2c = Request.Form[7].ToString();
                        ValImagen3c = Request.Form[8].ToString();


                    }
                    catch (Exception)
                    {
                        resultado = "";
                        return Json(new { probar, resultado });
                    }
                    NombreArchivos[0] = ValImagen1;
                    NombreArchivos[1] = ValImagen2;
                    NombreArchivos[2] = ValImagen3;
                    NombreArchivos_short[0] = ValImagen1s;
                    NombreArchivos_short[1] = ValImagen2s;
                    NombreArchivos_short[2] = ValImagen3s;
                    Carpeta[0] = ValImagen1c;
                    Carpeta[1] = ValImagen2c;
                    Carpeta[2] = ValImagen3c;
                    int IdEHMInt = 0;

                    var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                    //if (int.TryParse(IdEHM, out IdEHMInt))
                    //{
                    //    //Cargar servicio
                    //    //EDAdmoEMH = LNAdmoEMH.ConsultarEHM(IdEHMInt, usuarioActual.IdEmpresa);
                    //}
                    for (int i = 0; i < 3; i++)
                    {
                        if (Carpeta[i] != null)
                        {
                            if (Carpeta[i] != "")
                            {
                                if (i == 0)
                                {
                                    Paths[i] = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1, NombreArchivos[i]));
                                }
                                if (i == 1)
                                {
                                    Paths[i] = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2, NombreArchivos[i]));
                                }
                                if (i == 2)
                                {
                                    Paths[i] = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3, NombreArchivos[i]));
                                }
                            }
                            else
                            {
                                Paths[i] = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivos[i]));
                            }
                        }
                        else
                        {
                            Paths[i] = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivos[i]));
                        }
                    }

                    int PosicionVacia = -1;
                    for (int i = 0; i < 3; i++)
                    {
                        if (NombreArchivos[i] == string.Empty)
                        {
                            PosicionVacia = i;
                        }
                        else
                        {
                            if (!System.IO.File.Exists(Paths[i]))
                            {
                                PosicionVacia = i;
                            }
                        }
                    }
                    if (PosicionVacia == -1)
                    {
                        resultado = "El límite de archivos de evidencia que el usuario puede cargar es de 3 archivos, por favor si desea agregar este archivo primero elimine un archivo ya cargado";
                        return Json(new { probar, resultado });
                    }

                    try
                    {
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string fname;
                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                            }
                            else
                            {
                                fname = file.FileName;
                            }
                            if (file != null)
                            {

                                CrearCarpeta(RutaArchivosBDTemp);
                                string substring = "evalestmin_file_" + DateTime.Now.ToString().Replace(" ", "").Replace(".", "").Replace(":", "").Replace("/", "");
                                string ImgFileName = substring + file.FileName;
                                string pathsave = Server.MapPath(Path.Combine(RutaArchivosBDTemp, ImgFileName));
                                file.SaveAs(pathsave);
                                NombreArchivos[PosicionVacia] = ImgFileName;
                                Paths[PosicionVacia] = Server.MapPath(Path.Combine(RutaArchivosBDTemp, ImgFileName));
                                NombreArchivos_short[PosicionVacia] = file.FileName;
                                int IndexNuevo = 0;
                                for (int i1 = 0; i1 < 3; i1++)
                                {
                                    if (NombreArchivos[i1] == string.Empty)
                                    {
                                        display[i1] = false;
                                    }
                                    else
                                    {
                                        string PathOrigen = Paths[i1];
                                        if (!System.IO.File.Exists(PathOrigen))
                                        {
                                            display[i1] = false;
                                        }
                                        else
                                        {
                                            NuevoNombreArchivos_short[IndexNuevo] = NombreArchivos_short[i1];
                                            NuevoNombreArchivos[IndexNuevo] = NombreArchivos[i1];
                                            try
                                            {
                                                display[IndexNuevo] = true;
                                            }
                                            catch (Exception)
                                            {

                                            }
                                            IndexNuevo = IndexNuevo + 1;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                probar = false;
                                resultado = "El archivo que se intento subir no es una imagen o no es un archivo soportado, por favor intente de nuevo con otra imagen";
                                return Json(new { probar, resultado });
                            }
                        }
                        probar = true;
                        return Json(new { probar, resultado, NuevoNombreArchivos, display, NuevoNombreArchivos_short, Carpeta });
                    }
                    catch (Exception ex)
                    {
                        resultado = "No se pudo completar la operación, el tamaño del archivo probablemente es mayor a 3 MB ";
                        return Json(new { probar, resultado });
                    }
                }
                else
                {
                    resultado = "error";
                    return Json(new { probar, resultado });
                }

            }
            else
            {
                resultado = "No ha seleccionado un archivo, antes de adjuntar asegurese que exista un archivo";
                return Json(new { probar, resultado });
            }



        }
        [HttpPost]
        public ActionResult EliminarArchivo(string ruta)
        {
            bool probar = true;
            if (ruta != null)
            {
                try
                {
                    string PathOrigen = Server.MapPath(Path.Combine(RutaArchivosBD, ruta));
                    if (System.IO.File.Exists(PathOrigen))
                    {
                        System.IO.File.Delete(PathOrigen);
                    }
                }
                catch (Exception)
                {
                }
            }
            return Json(new { probar });
        }
        [HttpPost]
        public ActionResult EliminarArchivoTemp(string ruta)
        {
            bool probar = true;
            if (ruta != null)
            {
                try
                {
                    string PathOrigen = Server.MapPath(Path.Combine(RutaArchivosBDTemp, ruta));
                    if (System.IO.File.Exists(PathOrigen))
                    {
                        System.IO.File.Delete(PathOrigen);
                    }
                }
                catch (Exception)
                {
                }
            }
            return Json(new { probar });
        }
        [HttpPost]
        public ActionResult DescargarArchivo(List<String> values)
        {
            bool probar = false;
            string resultado = "El archivo que desea descargar no se encuentra disponible";

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                resultado = "El usuario no ha iniciado sesión en el sistema";
                return Json(new { probar, resultado });
            }

            string NombreArchivo = values[0];
            string nombre_download = values[1];
            string Idelemento = values[2];
            string numero = values[3];
            string IdEval = values[4];
            string Idciclo = values[5];
            string ruta = "";
            string proviene = "";
            string path = "";

            if (NombreArchivo != null && Idelemento != null && numero != null & IdEval != null & Idciclo != null)
            {
                int cicloint = 0;
                int Idelementoint = 0;
                if (int.TryParse(Idciclo, out cicloint))
                {
                }
                if (int.TryParse(Idelemento, out Idelementoint))
                {
                }

                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("idCiclo", cicloint);
                ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
                ServiceClient.AdicionarParametro("IdEval", IdEval.ToString());
                ServiceClient.AdicionarParametro("idElemento", Idelementoint);
                ServiceClient.AdicionarParametro("tipo", true);

                var result = ServiceClient.ObtenerObjetoJsonRestFul<EDCiclo>(urlServicioPlanificacion, CapacidadEvaluacionEstandaresMinimosCons, RestSharp.Method.GET);
                if (result != null)
                {
                    try
                    {
                        if (values[3] == "1")
                        {
                            path = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo1));
                            ruta = result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1;
                            proviene = "db";
                        }
                        if (values[3] == "2")
                        {
                            path = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta2, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo2));
                            ruta = result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1;
                            proviene = "db";
                        }
                        if (values[3] == "3")
                        {
                            path = Server.MapPath(Path.Combine(result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta3, result.Estandar.SubEstandar.Criterio.Evaluacion.NombreArchivo3));
                            ruta = result.Estandar.SubEstandar.Criterio.Evaluacion.Ruta1;
                            proviene = "db";
                        }
                    }
                    catch (Exception)
                    {
                        path = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivo));
                        if (System.IO.File.Exists(path))
                        {
                            ruta = RutaArchivosBDTemp;
                            proviene = "temp";
                            probar = true;
                            return Json(new { probar, resultado, NombreArchivo, nombre_download, proviene, ruta }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { probar, resultado },
                                                            JsonRequestBehavior.AllowGet);
                        }
                    }

                }
                if (System.IO.File.Exists(path))
                {
                    probar = true;
                    return Json(new { probar, resultado, NombreArchivo, nombre_download, proviene, ruta }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    path = Server.MapPath(Path.Combine(RutaArchivosBDTemp, NombreArchivo));
                    if (System.IO.File.Exists(path))
                    {
                        ruta = RutaArchivosBDTemp;
                        proviene = "temp";
                        probar = true;
                        return Json(new { probar, resultado, NombreArchivo, nombre_download, proviene, ruta }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { probar, resultado },
                                                        JsonRequestBehavior.AllowGet);
                    }

                }
            }
            else
            {
                return Json(new { probar, resultado },
            JsonRequestBehavior.AllowGet);
            }

        }
        [AllowAnonymous]
        public ActionResult Download(string Nombre, string Proviene, string Numero, string Ndownload, string ruta)
        {
            string Ruta = "";
            if (Proviene == "db")
            {
                Ruta = ruta;
            }
            if (Proviene == "temp")
            {
                Ruta = RutaArchivosBDTemp;
            }

            if (Ndownload == null)
            {
                Ndownload = Nombre;
            }
            byte[] fileBytes_1 = System.IO.File.ReadAllBytes(Server.MapPath(Path.Combine(Ruta, Nombre)));
            return File(fileBytes_1, System.Net.Mime.MediaTypeNames.Application.Octet, Ndownload);
        }
        public void mover(string archivo)
        {
            try
            {
                string pathorigen = Server.MapPath(Path.Combine(RutaArchivosBDTemp, archivo));
                string pathdestino = Server.MapPath(Path.Combine(RutaArchivosBD, archivo));
                if (System.IO.File.Exists(pathorigen))
                {
                    System.IO.File.Move(pathorigen, pathdestino);
                    eliminar(pathorigen);
                }
            }
            catch (System.Exception)
            {
            }
        }
        public void eliminar(string archivo)
        {
            try
            {
                if (System.IO.File.Exists(archivo))
                {
                    System.IO.File.Delete(archivo);
                }
            }
            catch (System.Exception)
            {
            }
        }
        #endregion
    }
}