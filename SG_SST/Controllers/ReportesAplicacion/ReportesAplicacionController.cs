using SG_SST.Controllers.Base;
using SG_SST.Logica.Ausentismo;
using SG_SST.Models.Participacion;
using SG_SST.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SG_SST.Models.Ausentismo;
using SG_SST.ServiceRequest;
using System.Configuration;
using SG_SST.EntidadesDominio.Empresas;
using SG_SST.EntidadesDominio.ComunicadosAPP;
using SG_SST.EntidadesDominio.Participacion;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.EntidadesDominio.MedicionEvaluacion;
using SG_SST.Services.Empresas.IServices;
using SG_SST.Services.Empresas.Services;
using SG_SST.Models.Empresas;
using SG_SST.Models.MedicionEvaluacion;
using SG_SST.Logica.Indicadores;
using SG_SST.Models;
using SG_SST.Helpers;
namespace SG_SST.Controllers.ReportesAplicacion
{
    [GestionAutorizacion]


    public class ReportesAplicacionController : BaseController
    {

        private SG_SSTContext db = new SG_SSTContext(); 

        string UrlServicioPlanificacion = ConfigurationManager.AppSettings["UrlServicioPlanificacion"];
        string UrlServicioParticipacion = ConfigurationManager.AppSettings["UrlServicioParticipacion"];
        string UrlServicioMedicionEvaluacion = ConfigurationManager.AppSettings["UrlServicioMedicionEvaluacion"];
        string CapacidadObtenerPlanesDeAccion = ConfigurationManager.AppSettings["CapacidadObtenerPlanesDeAccion"];
        string CapacidadObtenerModulos = ConfigurationManager.AppSettings["CapacidadObtenerModulos"];
        string CapacidadObtenerAnoInicioEmpresa = ConfigurationManager.AppSettings["CapacidadObtenerAnoInicioEmpresa"];
        string capacidadObtenerGrupoComunicaciones = ConfigurationManager.AppSettings["capacidadObtenerGrupoComunicaciones"];
        string capacidadObtenerCargoComunicaciones = ConfigurationManager.AppSettings["capacidadObtenerCargoComunicaciones"];
        string capacidadObtenerCargoAPPComunicaciones = ConfigurationManager.AppSettings["capacidadObtenerCargoAPPComunicaciones"];
        string CapacidadMetodologiaSede = ConfigurationManager.AppSettings["CapacidadMetodologiaSede"];
        string CapacidadProcesoMetodologia = ConfigurationManager.AppSettings["CapacidadProcesoMetodologia"];
        string CapacidadZonaLugar = ConfigurationManager.AppSettings["CapacidadZonaLugar"];
        string CapacidadActividadMetodologia = ConfigurationManager.AppSettings["CapacidadActividadMetodologia"];
        string CapacidadPeligrosIdentificados = ConfigurationManager.AppSettings["CapacidadPeligrosIdentificados"];
        string CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa = ConfigurationManager.AppSettings["ObtenerMetaIndicadorNombreIndicadorEmpresa"];

        private ISedeServicios sedeServicio = new SedeServicios();
        private IProcesoServicios procesoServicios = new ProcesoServicios();
       
        LNIndicadores lnInd = new LNIndicadores();
        // GET: Indicadores
        public ActionResult IndicadoresAunsentismo()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            var objIndicadores = new IndicadoresModel();
            objIndicadores.IdEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current) == null ? string.Empty : ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;
            objIndicadores.RazonSocial = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current) == null ? string.Empty : ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).RazonSocialEmpresa;
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDEmpresa_Usuaria>(urlServicioEmpresas, CapacidadObtenerEmpresasusuarias, RestSharp.Method.GET);
            if (result != null && result.Count() > 0)
            {
                objIndicadores.EmpresasUsuarias = result.Select(c => new SelectListItem()
                {
                    Value = c.IdEmpresaUsuaria.ToString(),
                    Text = c.RazonSocial
                }).ToList();
            }
            else
                objIndicadores.EmpresasUsuarias = new List<SelectListItem>();

            objIndicadores.Constante = objIndicadores.Configurconstante();
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var resultAno = ServiceClient.ObtenerObjetoJsonRestFul<int>(UrlServicioPlanificacion, CapacidadObtenerAnoInicioEmpresa, RestSharp.Method.GET);
            if (resultAno > 0)
            {
                objIndicadores.Anios = GetAnios(resultAno);
            }
            else
                objIndicadores.Anios = GetAnios(2010);


            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;

            return View(objIndicadores);
        }

        // GET: ReportesAplicacion


        public ActionResult ReportesAusentismo()
        {
            LNAusencia lnausencia = new LNAusencia();
            LNDepartamento lnDepartamento = new LNDepartamento();
            ReportesModel reporte = new ReportesModel();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            reporte.RazonSocial = usuarioActual.RazonSocialEmpresa;
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var resultAno = ServiceClient.ObtenerObjetoJsonRestFul<int>(UrlServicioPlanificacion, CapacidadObtenerAnoInicioEmpresa, RestSharp.Method.GET);
            if (resultAno > 0)
            {
                reporte.Anios = GetAnios(resultAno);
            }
            else
                reporte.Anios = GetAnios(2010);

            reporte.Departamentos = lnDepartamento.ObtenerListadoDepartamento().Select(d => new SelectListItem() { Value = d.IdDepartamento.ToString(), Text = d.Nombre }).ToList();
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var resultEU = ServiceClient.ObtenerArrayJsonRestFul<EDEmpresa_Usuaria>(urlServicioEmpresas, CapacidadObtenerEmpresasusuarias, RestSharp.Method.GET);
            if (resultEU != null && resultEU.Count() > 0)
            {
                reporte.EmpresasUsuarias = resultEU.Select(c => new SelectListItem()
                {
                    Value = c.IdEmpresaUsuaria.ToString(),
                    Text = c.RazonSocial
                }).ToList();
            }
            else
                reporte.EmpresasUsuarias = new List<SelectListItem>();
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var resultSede = ServiceClient.ObtenerArrayJsonRestFul<EDSede>(urlServicioEmpresas, CapacidadObtenerSedesPorNit, RestSharp.Method.GET);
            if (resultSede != null && resultSede.Count() > 0)
            {
                reporte.Sedes = resultSede.Select(c => new SelectListItem()
                {
                    Value = c.IdSede.ToString(),
                    Text = c.NombreSede
                }).ToList();
            }
            else
                reporte.Sedes = new List<SelectListItem>();


            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;

            reporte.Reportes = reporte.GetResportes();

            return View(reporte);
        }
        public ActionResult EstadisticasComunicacion()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            var encuestas = ObtenerEncuestasComunicacion(usuarioActual.NitEmpresa).ToList();

            ViewBag.Encuesta = encuestas.Select(c => new SelectListItem()
               {
                   Value = c.idEncuensta.ToString(),
                   Text = c.tituloEncuesta
               }).ToList();

            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;



            return View();
        }
        public ActionResult ReportesIndicadores()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }


            List<Proceso> procesos = procesoServicios.ObtenerProcesosPrincipales(usuarioActual.IdEmpresa);
            ViewBag.Procesos = new SelectList(procesos, "Pk_Id_Proceso", "Descripcion_Proceso");


            ViewBag.FKSede = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");
            ViewBag.FKSedePeligro = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");


            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("nit", usuarioActual.NitEmpresa);
            var resultGrupo = ServiceClient.ObtenerArrayJsonRestFul<EDGrupo>(UrlServicioParticipacion, capacidadObtenerGrupoComunicaciones, RestSharp.Method.GET);

            ViewBag.Grupo = resultGrupo.Select(c => new SelectListItem()
            {
                Value = c.IDGrupo.ToString(),
                Text = c.NombreGrupo
            }).ToList();

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("nit", usuarioActual.NitEmpresa);
            var resultCargo = ServiceClient.ObtenerArrayJsonRestFul<EDCargo>(UrlServicioParticipacion, capacidadObtenerCargoComunicaciones, RestSharp.Method.GET);

            ViewBag.Cargo = resultCargo.Select(c => new SelectListItem()
            {
                Value = c.Destinatarios.ToString(),
                Text = c.Destinatarios
            }).ToList();


            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("nit", usuarioActual.NitEmpresa);
            var resultCargoAPP = ServiceClient.ObtenerArrayJsonRestFul<EDCargo>(UrlServicioParticipacion, capacidadObtenerCargoAPPComunicaciones, RestSharp.Method.GET);

            ViewBag.CargoAPP = resultCargoAPP.Select(c => new SelectListItem()
            {
                Value = c.Destinatarios.ToString(),
                Text = c.Destinatarios
            }).ToList();

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var resultEmpEval = ServiceClient.ObtenerObjetoJsonRestFul<List<EDPlanDeAccion>>(UrlServicioMedicionEvaluacion, CapacidadObtenerPlanesDeAccion, RestSharp.Method.GET);
            var resultModulo = ServiceClient.ObtenerObjetoJsonRestFul<List<ModulosPlanAccion>>(UrlServicioMedicionEvaluacion, CapacidadObtenerModulos, RestSharp.Method.GET);
            var result = (resultModulo.Select(x => new { Pk_Id_PlanDeAccion = x.Pk_Id_ModuloPlanAccion, Origen = x.Modulo })).Distinct().ToList();
            ViewBag.modulo = new SelectList(result, "Pk_Id_PlanDeAccion", "Origen");

            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;
            return View();
        }


        //Indicadores Estructura

        public ActionResult IndicadoresEstructura()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);

            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }

            List<Proceso> procesos = procesoServicios.ObtenerProcesosPrincipales(usuarioActual.IdEmpresa);
            ViewBag.Procesos = new SelectList(procesos, "Pk_Id_Proceso", "Descripcion_Proceso");
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("nit", usuarioActual.NitEmpresa);
            var resultGrupo = ServiceClient.ObtenerArrayJsonRestFul<EDGrupo>(UrlServicioParticipacion, capacidadObtenerGrupoComunicaciones, RestSharp.Method.GET);

            ViewBag.Grupo = resultGrupo.Select(c => new SelectListItem()
            {
                Value = c.IDGrupo.ToString(),
                Text = c.NombreGrupo
            }).ToList();

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("nit", usuarioActual.NitEmpresa);
            var resultCargo = ServiceClient.ObtenerArrayJsonRestFul<EDCargo>(UrlServicioParticipacion, capacidadObtenerCargoComunicaciones, RestSharp.Method.GET);

            ViewBag.Cargo = resultCargo.Select(c => new SelectListItem()
               {
                   Value = c.Destinatarios.ToString(),
                   Text = c.Destinatarios
               }).ToList();


            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("nit", usuarioActual.NitEmpresa);
            var resultCargoAPP = ServiceClient.ObtenerArrayJsonRestFul<EDCargo>(UrlServicioParticipacion, capacidadObtenerCargoAPPComunicaciones, RestSharp.Method.GET);

            ViewBag.CargoAPP = resultCargoAPP.Select(c => new SelectListItem()
            {
                Value = c.Destinatarios.ToString(),
                Text = c.Destinatarios
            }).ToList();

            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;




            ViewBag.FKSede = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");
            return View();
        }



        //Indicadores Resultado

        public ActionResult IndicadoresResultado()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.FKSede = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");

            ViewBag.FKSedePeligro = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("NIT", usuarioActual.NitEmpresa);
            var resultEmpEval = ServiceClient.ObtenerObjetoJsonRestFul<List<EDPlanDeAccion>>(UrlServicioMedicionEvaluacion, CapacidadObtenerPlanesDeAccion, RestSharp.Method.GET);
            var resultModulo = ServiceClient.ObtenerObjetoJsonRestFul<List<ModulosPlanAccion>>(UrlServicioMedicionEvaluacion, CapacidadObtenerModulos, RestSharp.Method.GET);
            var result = (resultModulo.Select(x => new { Pk_Id_PlanDeAccion = x.Pk_Id_ModuloPlanAccion, Origen = x.Modulo })).Distinct().ToList();

            ViewBag.modulo = new SelectList(result, "Pk_Id_PlanDeAccion", "Origen");


            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;

            return View();
        }



        //Indicadores Proceso

        public ActionResult IndicadoresProceso()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }



            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;

            ViewBag.FKSede = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");
            return View();
        }

        public ActionResult ReportesAplicacion()
        {

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.FKSede = new SelectList(sedeServicio.SedesPorEmpresa(usuarioActual.IdEmpresa), "Pk_Id_Sede", "Nombre_Sede");

            ViewBag.nitEmpresa = SG_SST.Reportes.RecursoParametros.NitEmpresa;
            return View();
        }

        public void ReporteAusentismo()
        {

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AUSENTISMO";

            RecursoParametros.NombreReporte = "Reporte_au_por_proceso.rdlc";
            RecursoParametros.Reporte = "AUSENTISMO";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReportePresupuesto(int periodo, int idSede, string sedeTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PRESUPUESTO";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "Reporte_Presupuesto.rdlc";
            RecursoParametros.Reporte = "PRESUPUESTO";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeTexto = sedeTexto;
            RecursoParametros.SedeInd = idSede;
            RecursoParametros.Anio = periodo;


            RenderRazorViewToString("Reportes", accionARealizar);
        }
        public void ReporteCompetencias()
        {
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "COMPETENCIAS";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "COMPETENCIAS.rdlc";
            RecursoParametros.Reporte = "COMPETENCIAS";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RenderRazorViewToString("Reportes", accionARealizar);
        }




        public ActionResult ReporteMetodologiaInsht()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "METODOLOGÍA_INSHT.rdlc";
            RecursoParametros.Reporte = "METODOLOGIAINSHT";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult ReportePlanTrabajo()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "PLANDETRABAJO.rdlc";
            RecursoParametros.Reporte = "PLANTRABAJO";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult ReporteDiagnosticoSalud()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReporteDiagnosticoCondicionesdeSalud.rdlc";
            RecursoParametros.Reporte = "DIAGNOSTICOSALUD";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult AccionesCorrectivas()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ACCIONESCORRECTIVASYPREVENTIVAS.rdlc";
            RecursoParametros.Reporte = "AccionesCorrectivas";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult GestionCambio()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "GESTIONDELCAMBIO.rdlc";
            RecursoParametros.Reporte = "GestionCambio";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult Incidentes()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "REPORTEDEINCIDENTES.rdlc";
            RecursoParametros.Reporte = "Incidentes";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult InspeccionesSeguridad()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "INSPECCIONESDESEGURIDAD.rdlc";
            RecursoParametros.Reporte = "InspeccionesSeguridad";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult PerfilSocio()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "PERFILSOCIODEMOGRÁFICO.rdlc";
            RecursoParametros.Reporte = "PerfilSocio";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult IdentificacionPeligro()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReporteMetodologiaGTC45.rdlc";
            RecursoParametros.Reporte = "IdentificacionPeligro";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult MetodologiaRam()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReporteMetodologiaRAM.rdlc";
            RecursoParametros.Reporte = "MetodologiaRam";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult PuestosTrabajo()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "EstudioPTrabajo.rdlc";
            RecursoParametros.Reporte = "PuestosTrabajo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult PlanEmergenciaAccion()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReportePlanEmergenciaFrentesAccion.rdlc";
            RecursoParametros.Reporte = "PlanEmergenciaAccion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult PlanEmergenciaGeneral()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReportePlanEmergenciaInfoGeneral.rdlc";
            RecursoParametros.Reporte = "PlanEmergenciaGeneral";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult ActosCondicionesInseguras()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ACTOSYCONDICIONESINSEGURAS.rdlc";
            RecursoParametros.Reporte = "ActosCondicionesInseguras";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult AdquisicionesBienes()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ADQUISCIONESBIENESOCONTRATACION.rdlc";
            RecursoParametros.Reporte = "AdquisicionesBienes";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult RelacionesLaborales()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "Relacioneslaborales.rdlc";
            RecursoParametros.Reporte = "RelacionesLaborales";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }
        public ActionResult PlanCapacitacion()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "PLANDECAPACITACION.rdlc";
            RecursoParametros.Reporte = "PlanCapacitacion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            return PartialView("Reportes");
        }


        //Nuevo



        public void MedidasDePrevencion()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "MEDIDASPREV";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "MEDIDASDEPREVENCIONYCONTROL.rdlc";
            RecursoParametros.Reporte = "MEDIDASPREV";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void PlanesDeAccion()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PLANESACCION";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "PlanesAccion.rdlc";
            RecursoParametros.Reporte = "PLANESACCION";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteEnfermedadLaboral()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ENFERMEDADLAB";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "REPORTEENFERMEDADLABORAL.rdlc";
            RecursoParametros.Reporte = "ENFERMEDADLAB";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteIncidenteAT()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "IncidenteAT";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "Incidentes_EL.rdlc";
            RecursoParametros.Reporte = "IncidenteAT";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteActividadesComunicaciones(int anio, string estado)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ActividadesComunicaciones";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "Comunicados_actividades.rdlc";
            RecursoParametros.Reporte = "ActividadesComunicaciones";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Estado = estado;

            RenderRazorViewToString("Reportes", accionARealizar);
        }




        #region graficasAunsentismo

       

        public void ReporteDiasAunsentismoPorContigencia(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "DIASCONTIGENCIA";

            RecursoParametros.NombreReporte = "RepDiasContingencia.rdlc";
            RecursoParametros.Reporte = "DIASCONTIGENCIA";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteNumeroDeEventosPorContigencia(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EVENTOSCONTIGENCIA";

            RecursoParametros.NombreReporte = "RepNumEventosContingencia.rdlc";
            RecursoParametros.Reporte = "EVENTOSCONTIGENCIA";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteDiasAusentismoPorDepartamentos(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "DEPARTAMENTOS";

            RecursoParametros.NombreReporte = "Rep_Departamento.rdlc";
            RecursoParametros.Reporte = "DEPARTAMENTOS";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteDiasAusentismoPorEnfermedadesCIE10(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "DIASENFERMEDADES";

            RecursoParametros.NombreReporte = "DiasAusentismoEnfermedadesCIE10.rdlc";
            RecursoParametros.Reporte = "DIASENFERMEDADES";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteEventosPorEnfermedadesCIE10(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EVENTOENFERMEDADES";

            RecursoParametros.NombreReporte = "NumeroDeEventosEnfermedadesCIE10.rdlc";
            RecursoParametros.Reporte = "EVENTOENFERMEDADES";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void ReporteDiasAusentismoPorProceso(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PROCESO";

            RecursoParametros.NombreReporte = "ReportAusenciasProceso.rdlc";
            RecursoParametros.Reporte = "PROCESO";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);

        }
        public void ReporteDiasAusentismoPorSede(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "SEDE";

            RecursoParametros.NombreReporte = "ReportSedes.rdlc";
            RecursoParametros.Reporte = "SEDE";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteCostoPorContigencia(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "COSTOCONTIGENCIA";

            RecursoParametros.NombreReporte = "RepCostosContingencia.rdlc";
            RecursoParametros.Reporte = "COSTOCONTIGENCIA";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteAusentismoPorEPS(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        //public void ReporteAusentismoPorEPS()
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EPS";

            RecursoParametros.NombreReporte = "AusentismosPorEPS.rdlc";
            RecursoParametros.Reporte = "EPS";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void ReporteAusentismoPorSexo(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "SEXO";

            RecursoParametros.NombreReporte = "RepSexo.rdlc";
            RecursoParametros.Reporte = "SEXO";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void ReporteAusentismoPorTipoVinculacion(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "TIPOVINCULACION";

            RecursoParametros.NombreReporte = "TipoVinculacion.rdlc";
            RecursoParametros.Reporte = "TIPOVINCULACION";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void ReporteAusentismoPorOcupacionCIUO(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {

            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "OCUPACION";

            RecursoParametros.NombreReporte = "RepOcupacion.rdlc";
            RecursoParametros.Reporte = "OCUPACION";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void ReporteAusentismoPorGrupoEtareo(int anio, int? idorigen, int? idEmpresa, int? idSede, int? idDepartamento)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "GRUPOETAREO";

            RecursoParametros.NombreReporte = "GruposEtarios.rdlc";
            RecursoParametros.Reporte = "GRUPOETAREO";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Origen = idorigen;
            RecursoParametros.EmpresaUsuaria = idEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Departamento = idDepartamento;

            RenderRazorViewToString("Reportes", accionARealizar);

        }



        #endregion




        #region indicadores


        public void ReporteAccionCorrectivaPreventiva(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccionCorrectivaPreventiva";

            RecursoParametros.NombreReporte = "ReporteIndAccionCorrectivaPreventiva.rdlc";
            RecursoParametros.Reporte = "AccionCorrectivaPreventiva";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorCondicionesInseguras(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CondicionInsegura";

            RecursoParametros.NombreReporte = "ReporteIndCondicionInsegura.rdlc";
            RecursoParametros.Reporte = "CondicionInsegura";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorPlanTrabajoAnual(int anio, int idSede, string sedeTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PlanTrabajoAnual";

            RecursoParametros.NombreReporte = "ReporteIndPlanTrabajoAnual.rdlc";
            RecursoParametros.Reporte = "PlanTrabajoAnual";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.SedeInd = idSede;
            RecursoParametros.SedeTexto = sedeTexto;
            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorEstandaresMinimos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EstandaresMinimos";

            RecursoParametros.NombreReporte = "ReporteIndEvalEstandaresMinimos.rdlc";
            RecursoParametros.Reporte = "EstandaresMinimos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorAccidentesDeTrabajo(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccidentesDeTrabajo";

            RecursoParametros.NombreReporte = "ReporteIndFrecuenciaAccidentesTrabajo.rdlc";
            RecursoParametros.Reporte = "AccidentesDeTrabajo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorTasaAccidentalidad(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "TasaAccidentalidad";

            RecursoParametros.NombreReporte = "ReporteIndTasaAccidentalidad.rdlc";
            RecursoParametros.Reporte = "TasaAccidentalidad";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorCapacitacionEntrenamiento(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CapacitacionEntrenamiento";

            RecursoParametros.NombreReporte = "ReporteIndPlanCapacitacion.rdlc";
            RecursoParametros.Reporte = "CapacitacionEntrenamiento";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }


        public void IndicadorFrecuenciaAusentismo(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "FrecuenciaAusentismo";

            RecursoParametros.NombreReporte = "ReporteIndFrecuenciaAusentismo.rdlc";
            RecursoParametros.Reporte = "FrecuenciaAusentismo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorSeveridadAusentismo(int anio, int contigencia, string contigenciaTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "SeveridadAusentismo";

            RecursoParametros.NombreReporte = "ReporteIndSeveridadAusentismo.rdlc";
            RecursoParametros.Reporte = "SeveridadAusentismo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Contigencia = contigencia;
            RecursoParametros.ContigenciaTexto = contigenciaTexto;
            RenderRazorViewToString("Reportes", accionARealizar);

        }


        public void IndicadorSeveridadAccidenteTrabajo(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "SeveridadAccidenteTrabajo";

            RecursoParametros.NombreReporte = "ÍndicedeSeveridaddeAccidentesdeTrabajo.rdlc";
            RecursoParametros.Reporte = "SeveridadAccidenteTrabajo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorLesionesIncapacitantes(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "LesionesIncapacitantes";

            RecursoParametros.NombreReporte = "ÍndicedeLesionesIncapacitantesporAT.rdlc";
            RecursoParametros.Reporte = "LesionesIncapacitantes";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorCumplimientoRequisitosLegales(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CumplimientoRequisitosLegales";

            RecursoParametros.NombreReporte = "Indicadordelcumplimientodelosrequisitoslegales.rdlc";
            RecursoParametros.Reporte = "CumplimientoRequisitosLegales";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }


        public void IndicadorComiteComiteConvivencia(int anio, int? idSede, string sedeTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ConvivenciaLaboral";

            RecursoParametros.NombreReporte = "RepIndicadorActas.rdlc";
            RecursoParametros.Reporte = "ConvivenciaLaboral";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RecursoParametros.SedeTexto = sedeTexto;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorComiteCoppast(int anio, int? idSede, string sedeTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComiteCoppast";

            RecursoParametros.NombreReporte = "RepIndicadorCoppast.rdlc";
            RecursoParametros.Reporte = "ComiteCoppast";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RecursoParametros.SedeTexto = sedeTexto;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorDxCondicionesSalud(int anio, int? idSede, string sedeTexto, int? idProceso, string procesoTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "DxCondicionesSalud";

            RecursoParametros.NombreReporte = "ReporteIndDxCondicionesSalud.rdlc";
            RecursoParametros.Reporte = "DxCondicionesSalud";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RecursoParametros.SedeTexto = sedeTexto;
            RecursoParametros.Proceso = idProceso;
            RecursoParametros.ProcesoTexto = procesoTexto;

            RenderRazorViewToString("Reportes", accionARealizar);

        }


        public void IndicadorPerfilSocioDemografico(int? idSede, string sedeTexto, int? idProceso, string procesoTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PerfilSocioDemografico";

            RecursoParametros.NombreReporte = "RepIndicadorPerfilSocioDemografico.rdlc";
            RecursoParametros.Reporte = "PerfilSocioDemografico";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Sede = idSede;
            RecursoParametros.SedeTexto = sedeTexto;
            RecursoParametros.Proceso = idProceso;
            RecursoParametros.ProcesoTexto = procesoTexto;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorComunicaciones(int anio, string estado)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "Comunicaciones";

            RecursoParametros.NombreReporte = "Comu_ini.rdlc";
            RecursoParametros.Reporte = "Comunicaciones";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Estado = estado;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorAnalisisVulnerabilidad(string sedeTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AnalisisVulnerabilidad";

            RecursoParametros.NombreReporte = "Plan de Emergencia Analisis Vulnerabilidad.rdlc";
            RecursoParametros.Reporte = "AnalisisVulnerabilidad";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeTexto = sedeTexto;


            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorComunicacionesInternasPersonas(int anio, string documento, string tipoComTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndPersonas";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - personas.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndPersonas";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Documento = documento;
            RecursoParametros.TipoComTexto = tipoComTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorComunicacionesInternasCargo(int anio, string cargoTexto, string tipoComTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndCargo";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - cargo.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndCargo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.CargoTexto = cargoTexto;
            RecursoParametros.TipoComTexto = tipoComTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorComunicacionesInternasGrupos(int anio, string grupoTexto, string tipoComTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndGrupo";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - grupo.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndGrupo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.GrupoTexto = grupoTexto;
            RecursoParametros.TipoComTexto = tipoComTexto;

            RenderRazorViewToString("Reportes", accionARealizar);
        }




        public void IndicadorComunicacionesInternasPersonasAPP(int anio, string documento, string tipoComTextoAPP)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndPersonasAPP";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - apppersonas.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndPersonasAPP";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Documento = documento;
            RecursoParametros.TipoComTexto = tipoComTextoAPP;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorComunicacionesInternasCargoAPP(int anio, string cargoTextoAPP, string tipoComTextoAPP)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndCargoAPP";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - apppcargos.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndCargoAPP";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.CargoTexto = cargoTextoAPP;
            RecursoParametros.TipoComTexto = tipoComTextoAPP;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void identificacionPeligrosFiltroSedeMetodologiaProcesoLugarActividadValoracion(int sedePeligro, string sedePelTexto, int metodologia, string metodologiaTexto, int procesoPel, string procesoPelTexto, string zonaLugarTexto, string actividadTexto, int tipoPeligro, string tipoPeligroTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ProcesoLugarActividadValoracion";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaProcesoLugarActividadValoracion.rdlc";
            RecursoParametros.Reporte = "ProcesoLugarActividadValoracion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.SedeTexto = sedePelTexto;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.MetodologiaTexto = metodologiaTexto;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.ProcesoTexto = procesoPelTexto;

            RecursoParametros.Sede = sedePeligro;

            RecursoParametros.ZonaLugarTexto = zonaLugarTexto;
            RecursoParametros.ActividadTexto = actividadTexto;
            RecursoParametros.TipoPeligro = tipoPeligro;
            RecursoParametros.TipoPeligroTexto = tipoPeligroTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void identificacionPeligrosFiltroSedeMetodologiaProcesoLugarValoracion(int sedePeligro, string sedePelTexto, int metodologia, string metodologiaTexto, int procesoPel, string procesoPelTexto, string zonaLugarTexto, int tipoPeligro, string tipoPeligroTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ProcesoLugarValoracion";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaProcesoLugarValoracion.rdlc";
            RecursoParametros.Reporte = "ProcesoLugarValoracion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.SedeTexto = sedePelTexto;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.MetodologiaTexto = metodologiaTexto;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.ProcesoTexto = procesoPelTexto;
            RecursoParametros.ZonaLugarTexto = zonaLugarTexto;
            RecursoParametros.TipoPeligro = tipoPeligro;
            RecursoParametros.TipoPeligroTexto = tipoPeligroTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void identificacionPeligrosFiltroSedeMetodologiaProcesoValoracion(int sedePeligro, string sedePelTexto, int metodologia, string metodologiaTexto, int procesoPel, string procesoPelTexto, int tipoPeligro, string tipoPeligroTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "MetodologiaProcesoValoracion";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaProcesoValoracion.rdlc";
            RecursoParametros.Reporte = "MetodologiaProcesoValoracion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.SedeTexto = sedePelTexto;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.MetodologiaTexto = metodologiaTexto;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.ProcesoTexto = procesoPelTexto;
            RecursoParametros.TipoPeligro = tipoPeligro;
            RecursoParametros.TipoPeligroTexto = tipoPeligroTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void identificacionPeligrosFiltroSedeMetodologiaValoracion(int sedePeligro, string sedePelTexto, int metodologia, string metodologiaTexto, int tipoPeligro, string tipoPeligroTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "MetodologiaValoracion";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaValoracion.rdlc";
            RecursoParametros.Reporte = "MetodologiaValoracion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.SedeTexto = sedePelTexto;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.MetodologiaTexto = metodologiaTexto;

            RecursoParametros.TipoPeligro = tipoPeligro;
            RecursoParametros.TipoPeligroTexto = tipoPeligroTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionEvaluacionSGSST(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EvaluacionSGSST";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepIndPlaccEvaluacion.rdlc";
            RecursoParametros.Reporte = "EvaluacionSGSST";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionAccionesPrevCorrectivas(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccionesPrevCorrectivas";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepIndPlanAccionACyAP.rdlc";
            RecursoParametros.Reporte = "AccionesPrevCorrectivas";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionAuditorias(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "Auditorias";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepIndPlanAccAuditoria.rdlc";
            RecursoParametros.Reporte = "Auditorias";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionInspeccion(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "Inspeccion";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepIndPlanAccionInspeccion.rdlc";
            RecursoParametros.Reporte = "Inspeccion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionActosInseguros(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ActosInseguros";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReporteActosConInseguras.rdlc";
            RecursoParametros.Reporte = "ActosInseguros";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionCoppast(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "Coppast";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReporteCopasst.rdlc";
            RecursoParametros.Reporte = "Coppast";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionComiteConvivencia(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComiteConvivencia";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ReporteComiteConvivenciaLaboral.rdlc";
            RecursoParametros.Reporte = "ComiteConvivencia";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionRevisionSGSST(int anio, int modulo, string moduloTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "RevisionSGSST";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "Reporte_IndicadorSGSST.rdlc";
            RecursoParametros.Reporte = "RevisionSGSST";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.ModuloTexto = moduloTexto;
            RecursoParametros.Modulo = modulo;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }



        #endregion


        #region indicadores datos

        public void IndicadorEstandaresMinimosDatos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EstandaresMinimosDatos";

            RecursoParametros.NombreReporte = "ReporteIndEvalEstandaresMinimosDatos.rdlc";
            RecursoParametros.Reporte = "EstandaresMinimosDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void ReporteAccionCorrectivaPreventivaDatos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccionCorrectivaPreventivaDatos";

            RecursoParametros.NombreReporte = "ReporteIndAccionCorrectivaPreventivaDatos.rdlc";
            RecursoParametros.Reporte = "AccionCorrectivaPreventivaDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorCondicionesInsegurasDatos(int anio, int? tipoReporte, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CondicionInseguraDatos";

            RecursoParametros.NombreReporte = "ReporteIndCondicionInseguraDatos.rdlc";
            RecursoParametros.Reporte = "CondicionInseguraDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.TipoReporte = tipoReporte;
            RecursoParametros.Sede = idSede;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorAccidentesDeTrabajoDatos(int anio, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccidentesDeTrabajoDatos";

            RecursoParametros.NombreReporte = "ReporteIndFrecuenciaAccidentesTrabajoDatos.rdlc";
            RecursoParametros.Reporte = "AccidentesDeTrabajoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorFrecuenciaAusentismoDatos(int anio, int contigencia, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "FrecuenciaAusentismoDatos";

            RecursoParametros.NombreReporte = "ReporteIndFrecuenciaAusentismoDatos.rdlc";
            RecursoParametros.Reporte = "FrecuenciaAusentismoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Contigencia = contigencia;



            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorCapacitacionEntrenamientoDatos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CapacitacionEntrenamientoDatos";

            RecursoParametros.NombreReporte = "ReporteIndPlanCapacitacionDatos.rdlc";
            RecursoParametros.Reporte = "CapacitacionEntrenamientoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorPlanTrabajoAnualDatos(int anio, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PlanTrabajoAnualDatos";

            RecursoParametros.NombreReporte = "ReporteIndPlanTrabajoAnualDatos.rdlc";
            RecursoParametros.Reporte = "PlanTrabajoAnualDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorSeveridadAusentismoDatos(int anio, int contigencia, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "SeveridadAusentismoDatos";

            RecursoParametros.NombreReporte = "ReporteIndSeveridadAusentismoDatos.rdlc";
            RecursoParametros.Reporte = "SeveridadAusentismoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Contigencia = contigencia;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorTasaAccidentalidadDatos(int anio, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "TasaAccidentalidadDatos";

            RecursoParametros.NombreReporte = "ReporteIndTasaAccidentalidadDatos.rdlc";
            RecursoParametros.Reporte = "TasaAccidentalidadDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorCumplimientoRequisitosLegalesDatos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CumplimientoRequisitosLegalesDatos";

            RecursoParametros.NombreReporte = "ReporteIndRequisitosLegalesDatos.rdlc";
            RecursoParametros.Reporte = "CumplimientoRequisitosLegalesDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorAccidenteDeTrabajoDatos(int anio, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccidenteDeTrabajoDatos";

            RecursoParametros.NombreReporte = "ReporteIndSeveridadAccidentesTrabajoDatos.rdlc";
            RecursoParametros.Reporte = "AccidenteDeTrabajoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorLesionesIncapacitantesDatos(int anio, int? idSede)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "LesionesIncapacitantesDatos";

            RecursoParametros.NombreReporte = "ReporteIndLesionesIncapacitantesATDatos.rdlc";
            RecursoParametros.Reporte = "LesionesIncapacitantesDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;

            RenderRazorViewToString("Reportes", accionARealizar);

        }


        public void IndicadorDxCondicionesSaludDatos(int anio, int? idSede, int? idProceso)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "DxCondicionesSaludDatos";

            RecursoParametros.NombreReporte = "ReporteIndDxCondicionesSaludDatos.rdlc";
            RecursoParametros.Reporte = "DxCondicionesSaludDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Sede = idSede;
            RecursoParametros.Proceso = idProceso;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorAnalisisVulnerabilidadDatos(string sedeTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AnalisisVulnerabilidadDatos";

            RecursoParametros.NombreReporte = "Analisis Vulnerabilidad Detalle.rdlc";
            RecursoParametros.Reporte = "AnalisisVulnerabilidadDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeTexto = sedeTexto;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorPerfilSociodemograficoDatos(int? idSede, int? idProceso)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "PerfilSocioDemograficoDatos";

            RecursoParametros.NombreReporte = "ReporteGralPerfilSocioDatos.rdlc";
            RecursoParametros.Reporte = "PerfilSocioDemograficoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Sede = idSede;

            RecursoParametros.Proceso = idProceso;


            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadorComunicacionesInternasPersonasDatos(int anio, string documento, string tipoComTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndPersonasDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - DetalleP.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndPersonasDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Documento = documento;
            RecursoParametros.TipoComTexto = tipoComTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorComunicacionesInternasCargoDatos(int anio, string cargoTexto, string tipoComTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndCargoDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - DetalleC.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndCargoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.CargoTexto = cargoTexto;
            RecursoParametros.TipoComTexto = tipoComTexto;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorComunicacionesInternasGruposDatos(int anio, string grupoTexto, string tipoComTexto)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndGrupoDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicadorInterno - DetalleG.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndGrupoDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.GrupoTexto = grupoTexto;
            RecursoParametros.TipoComTexto = tipoComTexto;

            RenderRazorViewToString("Reportes", accionARealizar);
        }




        public void IndicadorComunicacionesInternasPersonasAPPDatos(int anio, string documento, string tipoComTextoAPP)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndPersonasAPPDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicador_appDetalleP.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndPersonasAPPDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RecursoParametros.Documento = documento;
            RecursoParametros.TipoComTexto = tipoComTextoAPP;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorComunicacionesInternasCargoAPPDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesIndCargoAPPDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComunicacionesIndicador_appDetalleC.rdlc";
            RecursoParametros.Reporte = "ComunicacionesIndCargoAPPDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionEvaluacionSGSSTDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EvaluacionSGSSTDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepGralPlaccEvaluacionDatos.rdlc";
            RecursoParametros.Reporte = "EvaluacionSGSSTDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionAccionesPrevCorrectivasDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AccionesPrevCorrectivasDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepPlanAccionGralACyAPDatos.rdlc";
            RecursoParametros.Reporte = "AccionesPrevCorrectivasDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionAuditoriasDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AuditoriasDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepIndPlaccionAuditoriasDatos.rdlc";
            RecursoParametros.Reporte = "AuditoriasDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionInspeccionDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "InspeccionDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "RepGralPlanAccInspeccionDatos.rdlc";
            RecursoParametros.Reporte = "InspeccionDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionActosInsegurosDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ActosInsegurosDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ActosCondicionesInsegurasDatos.rdlc";
            RecursoParametros.Reporte = "ActosInsegurosDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void IndicadorPlanesDeAccionCoppastDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "CoppastDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "COPASSTDatos.rdlc";
            RecursoParametros.Reporte = "CoppastDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionComiteConvivenciaDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComiteConvivenciaDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "ComiteConvivenciaLaboralDatos.rdlc";
            RecursoParametros.Reporte = "ComiteConvivenciaDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void IndicadorPlanesDeAccionRevisionSGSSTDatos(int anio)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "RevisionSGSSTDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "IndicadorSGSSTDatos.rdlc";
            RecursoParametros.Reporte = "RevisionSGSSTDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void identificacionPeligrosFiltroSedeMetodologiaProcesoLugarActividadValoracionDatos(int sedePeligro, int metodologia, int procesoPel, string zonaLugarTexto, string actividadTexto, int tipoPeligro)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ProcesoLugarActividadValoracionDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;
            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaProcesoLugarActividadTabla.rdlc";
            RecursoParametros.Reporte = "ProcesoLugarActividadValoracionDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.Sede = sedePeligro;
            RecursoParametros.ZonaLugarTexto = zonaLugarTexto;
            RecursoParametros.ActividadTexto = actividadTexto;
            RecursoParametros.TipoPeligro = tipoPeligro;
            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void identificacionPeligrosFiltroSedeMetodologiaProcesoLugarValoracionDatos(int sedePeligro, int metodologia, int procesoPel, string zonaLugarTexto, int tipoPeligro)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ProcesoLugarValoracionDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaProcesoLugarTabla.rdlc";
            RecursoParametros.Reporte = "ProcesoLugarValoracionDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.ZonaLugarTexto = zonaLugarTexto;
            RecursoParametros.TipoPeligro = tipoPeligro;

            RenderRazorViewToString("Reportes", accionARealizar);
        }

        public void identificacionPeligrosFiltroSedeMetodologiaProcesoValoracionDatos(int sedePeligro, int metodologia, int procesoPel, int tipoPeligro)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "MetodologiaProcesoValoracionDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaProcesoTabla.rdlc";
            RecursoParametros.Reporte = "MetodologiaProcesoValoracionDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.ProcesoInt = procesoPel;
            RecursoParametros.TipoPeligro = tipoPeligro;
            RenderRazorViewToString("Reportes", accionARealizar);
        }


        public void identificacionPeligrosFiltroSedeMetodologiaValoracionDatos(int sedePeligro, int metodologia, int tipoPeligro)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "MetodologiaValoracionDatos";
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            RecursoParametros.NombreReporte = "identificacionPeligrosFiltroSedeMetodologiaTabla.rdlc";
            RecursoParametros.Reporte = "MetodologiaValoracionDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.SedeInd = sedePeligro;
            RecursoParametros.Metodologia = metodologia;
            RecursoParametros.TipoPeligro = tipoPeligro;
            RenderRazorViewToString("Reportes", accionARealizar);
        }



        #endregion

        #region indicadoresAusentismo


        public void IndicadoresAusentismo(int AnioSeleccionado, int IdContingencia, string contigenciaTexto, string ConstanteSeleccionada, int? IdEmpresaUsuaria)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();

            RecursoParametros.NombreReporte = "ReporteIndicadoresAusentismo.rdlc";
            RecursoParametros.Reporte = "IndicadorAusentismo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = AnioSeleccionado;
            RecursoParametros.Contigencia = IdContingencia;
            RecursoParametros.ConstanteK = ConstanteSeleccionada;
            RecursoParametros.EmpresaUsuaria = IdEmpresaUsuaria;
            RecursoParametros.ContigenciaTexto = contigenciaTexto;
            accionARealizar.AccionARealizar = "IndicadorAusentismo";


            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void IndicadoresAusentismoComparacion(int PrimerAnio, int SegundoAnio, int IdContingencia, string contigenciaTexto, string ConstanteSeleccionada, int? IdEmpresaUsuaria)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "AusentismoComparacion";

            RecursoParametros.NombreReporte = "ReporteIndicadoresAusentismoComparacion.rdlc";
            RecursoParametros.Reporte = "AusentismoComparacion";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = PrimerAnio;
            RecursoParametros.Contigencia = IdContingencia;
            RecursoParametros.ConstanteK = ConstanteSeleccionada;
            RecursoParametros.EmpresaUsuaria = IdEmpresaUsuaria;
            RecursoParametros.AnioComparacion = SegundoAnio;
            RecursoParametros.ContigenciaTexto = contigenciaTexto;
            accionARealizar.AccionARealizar = "IndicadorAusentismo";


            RenderRazorViewToString("Reportes", accionARealizar);

        }


        #endregion

        #region indicadoresMetodologia

        public ActionResult ObtenerMetodologia(int PK_Sede)
        {

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("id_Sede", PK_Sede);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDMetodologia>(UrlServicioParticipacion, CapacidadMetodologiaSede, RestSharp.Method.GET);
            var resultList = result.ToList();
            if (resultList.Count() >= 0)
            {
                return Json(resultList.Select(c => new
              {
                  PK_Metodologia = c.PK_Metodologia,
                  Descripcion_Metodologia = c.Descripcion_Metodologia
              })
              , JsonRequestBehavior.AllowGet);


            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ObtenerProceso(int PK_Sede, int Pk_Metodologia)
        {

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("id_Sede", PK_Sede);
            ServiceClient.AdicionarParametro("idMetodologia", Pk_Metodologia);
            var result = ServiceClient.ObtenerArrayJsonRestFul<EDProceso>(UrlServicioParticipacion, CapacidadProcesoMetodologia, RestSharp.Method.GET);
            var resultList = result.ToList();
            if (resultList.Count() >= 0)
            {
                return Json(resultList.Select(c => new
                {
                    PK_Proceso = c.Id_Proceso,
                    Descripcion_Proceso = c.Descripcion
                })
              , JsonRequestBehavior.AllowGet);


            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult ObtenerZonaLugar(int PK_Sede, int Pk_Metodologia, int Pk_Proceso)
        {

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("id_Sede", PK_Sede);
            ServiceClient.AdicionarParametro("idMetodologia", Pk_Metodologia);
            ServiceClient.AdicionarParametro("id_Proceso", Pk_Proceso);

            var result = ServiceClient.ObtenerArrayJsonRestFul<EDZonaLugar>(UrlServicioParticipacion, CapacidadZonaLugar, RestSharp.Method.GET);
            var resultList = result.ToList();
            if (resultList.Count() >= 0)
            {
                return Json(resultList.Select(c => new
                {
                    PK_ZonaLugar = c.PK_ZonaLugar,
                    Descripcion_ZonaLugar = c.Descripcion_ZonaLugar
                })
              , JsonRequestBehavior.AllowGet);


            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult ObtenerActividadMetodologia(int PK_Sede, int Pk_Metodologia, int Pk_Proceso, string Pk_ZonaLugar)
        {

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("id_Sede", PK_Sede);
            ServiceClient.AdicionarParametro("idMetodologia", Pk_Metodologia);
            ServiceClient.AdicionarParametro("id_Proceso", Pk_Proceso);
            ServiceClient.AdicionarParametro("zonaLugar", Pk_ZonaLugar);

            var result = ServiceClient.ObtenerArrayJsonRestFul<EDActividadApp>(UrlServicioParticipacion, CapacidadActividadMetodologia, RestSharp.Method.GET);
            var resultList = result.ToList();
            if (resultList.Count() >= 0)
            {
                return Json(resultList.Select(c => new
                {
                    PK_Actividad = c.pk_proceso,
                    Descripcion_Actividad = c.descripcionProceso
                })
              , JsonRequestBehavior.AllowGet);


            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult ObtenerTipoDePeligro(int PK_Sede, int Pk_Metodologia, int Pk_Proceso, string Pk_ZonaLugar, string Pk_Actividad)
        {

            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("id_Sede", PK_Sede);
            ServiceClient.AdicionarParametro("idMetodologia", Pk_Metodologia);
            ServiceClient.AdicionarParametro("id_Proceso", Pk_Proceso);
            ServiceClient.AdicionarParametro("zonaLugar", Pk_ZonaLugar);
            ServiceClient.AdicionarParametro("actividad", Pk_Actividad);



            var result = ServiceClient.ObtenerArrayJsonRestFul<EDPeligroIdentificadoApp>(UrlServicioParticipacion, CapacidadPeligrosIdentificados, RestSharp.Method.GET);
            var resultList = result.ToList();
            if (resultList.Count() >= 0)
            {
                return Json(resultList.Select(c => new
                {
                    PK_Peligro = c.idClasificacionPeligro,
                    Descripcion_Peligro = c.descripcionClasificacion
                })
              , JsonRequestBehavior.AllowGet);


            }
            else
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }


        #endregion


        #region semaforizacion

        public JsonResult ObtenerSemaforoEstandaresMinimos()
        {
            decimal resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }

            resultados = lnInd.ObtenerResultadoEstandaresMinimos(usuarioActual.NitEmpresa);
            if (resultados != null && resultados.Count() > 0)
            {
                decimal sum = 0;
                int con = 0;
                foreach (decimal vlr in resultados)
                {
                    sum = sum + vlr;
                    con++;
                }
                if (con >= 1)
                {
                    resultado = sum / con;
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "Error" });
            }
            if (resultado >= 0)
            {
                return Json(new { Data = resultado, Mensaje = "OK" });
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "Error" });
            }
        }

        public JsonResult ObtenerSemaforoPlanTrabajoAnual()
        {
            decimal? resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de ejecución del plan de trabajo anual en SST");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de plan de trabajo anual
                resultado = lnInd.ObtenerResultadoPlanTrabajoAnual(usuarioActual.NitEmpresa);
               // resultado = null;
                //Fin parte que falta adecuar para el resultado de plan de trabajo anual
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoReporteSST()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de gestión de la mejora continua en el SG de SST");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de ReporteSST
                 resultado = lnInd.ObtenerResultadoReporteSST(usuarioActual.NitEmpresa);
                //resultado = null;
                //Fin parte que falta adecuar para el resultado de ReporteSST
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoCondicionActosInseguros()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de gestión sobre las condiciones y actos inseguros");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de CondicionActosInseguros
                resultado = lnInd.ObtenerResultadoCondicionActoInseguro(usuarioActual.NitEmpresa);
               // resultado = null;
                //Fin parte que falta adecuar para el resultado de CondicionActosInseguros
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoSeveridadAccidenteTrabajo()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Severidad de los accidentes laborales");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de CondicionActosInseguros
                //resultado = lnInd.ObtenerResultadoReporteSST(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de CondicionActosInseguros
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoAccidentesDeTrabajo()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Severidad de los accidentes laborales");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de CondicionActosInseguros
                //resultado = lnInd.ObtenerResultadoReporteSST(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de CondicionActosInseguros
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoFrecuenciaAusentismo()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Ausentismo por incapacidad médica");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                resultado = lnInd.ObtenerResultadoFrecuenciaAusentismo(usuarioActual.NitEmpresa);
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoTasaAccidentalidad()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Tasa accidentalidad");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de TasaAccidentalidad
                resultado = lnInd.ObtenerResultadoTasaAccidentalidad(usuarioActual.NitEmpresa);
               // resultado = null;
                //Fin parte que falta adecuar para el resultado de TasaAccidentalidad
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoSeveridadAusentismo()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Índice de Severidad del Ausentismo");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de SeveridadAusentismo
                //resultado = lnInd.ObtenerResultadoSeveridadAusentismo(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de SeveridadAusentismo
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoLesionesIncapacitantes()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Índice de Lesiones Incapacitantes por A.T");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de LesionesIncapacitantes
                //resultado = lnInd.ObtenerResultadoLesionesIncapacitantes(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de LesionesIncapacitantes
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoCumplimientoRequisitosLegales()
        {
            decimal? resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador del cumplimiento de los requisitos legales");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                resultado = lnInd.ObtenerResultadoCumplimientoRequisitosLegales(usuarioActual.NitEmpresa);
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoCapacitacionEntrenamiento()
        {
            decimal? resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Cumplimiento programa de capacitación y entrenamiento");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                resultado = lnInd.ObtenerResultadoCapacitacionEntrenamiento(usuarioActual.NitEmpresa);
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoAnalisisVulnerabilidad()
        {
            decimal? resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador ánalisis vulnerabilidad");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de AnalisisVulnerabilidad
                //resultado = lnInd.ObtenerResultadoAnalisisVulnerabilidad(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de AnalisisVulnerabilidad
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoPeligroYRiesgos()
        {
            decimal? resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de identificación y valoración de peligros y riesgos");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de PeligroYRiesgos
                //resultado = lnInd.ObtenerResultadoPeligroYRiesgos(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de PeligroYRiesgos
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoPlanesDeAccion()
        {
            decimal? resultado = 0;
            List<decimal> resultados = new List<decimal>();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de eficacia de cierre de planes de acción");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de PlanesDeAccion
                //resultado = lnInd.ObtenerResultadoPlanesDeAccion(usuarioActual.NitEmpresa);
                resultado = null;
                //Fin parte que falta adecuar para el resultado de PlanesDeAccion
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult ObtenerSemaforoCoppast()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de comité Copasst");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de CondicionActosInseguros
                resultado = lnInd.ObtenerResultadoComiteCoppast(usuarioActual.NitEmpresa);
                // resultado = null;
                //Fin parte que falta adecuar para el resultado de CondicionActosInseguros
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoConvivenciaLaboral()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de Comité Convivencia Laboral");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de CondicionActosInseguros
                resultado = lnInd.ObtenerResultadoComiteConvivenciaLaboral(usuarioActual.NitEmpresa);
                // resultado = null;
                //Fin parte que falta adecuar para el resultado de CondicionActosInseguros
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerSemaforoPerfilSocio()
        {
            decimal? resultado = 0;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return Json(new { Data = "La sesión ha finalizado", Mensaje = "Fin Sesión" });
            }
            ServiceClient.EliminarParametros();
            ServiceClient.AdicionarParametro("indicador", "Indicador de perfil sociodemográfico");
            ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
            var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, CapacidadObtenerMetaIndicadorNombreIndicadorEmpresa, RestSharp.Method.GET);
            if (indicador != null)
            {
                //Inicio parte que falta adecuar para el resultado de CondicionActosInseguros
                resultado = lnInd.ObtenerResultadoPerfilSocioDemografico(usuarioActual.NitEmpresa);
                // resultado = null;
                //Fin parte que falta adecuar para el resultado de CondicionActosInseguros
                if (resultado != null && resultado.Value >= 0)
                {
                    indicador.ValorResultado = resultado.Value;
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = indicador, Mensaje = "METAOK" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }




        #endregion

        #region EstadisticasComunicaciones
        public List<EDEncuesta> ObtenerEncuestasComunicacion(string nit)
        {
            List<EDEncuesta> encuestas = new List<EDEncuesta>();
            
                encuestas = (from com in db.Tbl_ComunicacionesInternas
                            where com.NitEmpresa==nit
                            && com.EstadoEncuesta == "Publicado"
                             
                          select new EDEncuesta
                          {
                              idEncuensta = com.PK_Id_Encuesta,
                              tituloEncuesta = com.Titulo
                          }).ToList();

                return encuestas;
        }

        public void EstadisticaComunicaciones(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "Comunicaciones";

            RecursoParametros.NombreReporte = "ReporteEstComunicaciones.rdlc";
            RecursoParametros.Reporte = "Comunicaciones";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void EstadisticasEncuestas(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "Encuestas";

            RecursoParametros.NombreReporte = "ReporteEstEncuestas.rdlc";
            RecursoParametros.Reporte = "Encuestas";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void EstadisticasTabulacionEncuestas(int encuesta)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "TabulacionEncuestas";

            RecursoParametros.NombreReporte = "ReporteEstTabulacionEncuestas.rdlc";
            RecursoParametros.Reporte = "TabulacionEncuestas";
            RecursoParametros.NitEmpresa = nitEmpresa;
          
            RecursoParametros.Encuesta = encuesta;
            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void EstadisticasTabulacionEncuestasDatos(int encuesta,string encuestaTexto)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "TabulacionEncuestasDatos";

            RecursoParametros.NombreReporte = "ReporteEstTabulacionEncuestasDatos.rdlc";
            RecursoParametros.Reporte = "TabulacionEncuestasDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;

            RecursoParametros.Encuesta = encuesta;
            RecursoParametros.EncuestaTexto = encuestaTexto;
            RenderRazorViewToString("Reportes", accionARealizar);

        }


        public void EstadisticaComunicacionesDatos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "ComunicacionesDatos";

            RecursoParametros.NombreReporte = "ReporteEstComunicacionesDatos.rdlc";
            RecursoParametros.Reporte = "ComunicacionesDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        public void EstadisticasEncuestasDatos(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;

            CrearActaConvivenciaVM accionARealizar = new CrearActaConvivenciaVM();
            accionARealizar.AccionARealizar = "EncuestasDatos";

            RecursoParametros.NombreReporte = "ReporteEstEncuestasDatos.rdlc";
            RecursoParametros.Reporte = "EncuestasDatos";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;

            RenderRazorViewToString("Reportes", accionARealizar);

        }

        #endregion

        #region EstadisticasdelSGSST

        public ActionResult ReporteDesempeñoDelSistema(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            RecursoParametros.NombreReporte = "DesempeñoDelSistema.rdlc";
            RecursoParametros.Reporte = "DesempeñoDelSistema";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            return PartialView("Reportes");
        }


        public ActionResult ReporteGestionDelRiesgo(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            RecursoParametros.NombreReporte = "ReporteEstGestionRiesgoSistemaSST.rdlc";
            RecursoParametros.Reporte = "GestionDelRiesgo";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            return PartialView("Reportes");
        }


        public ActionResult ReporteEntrenamientoSGSST(int anio)
        {
            var nitEmpresa = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current).NitEmpresa;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                return RedirectToAction("Login", "Home");
            }

            RecursoParametros.NombreReporte = "ReporteEstEntrenamiento.rdlc";
            RecursoParametros.Reporte = "EntrenamientoSGSST";
            RecursoParametros.NitEmpresa = nitEmpresa;
            RecursoParametros.Anio = anio;
            return PartialView("Reportes");
        }



        #endregion 
    }

   

}

