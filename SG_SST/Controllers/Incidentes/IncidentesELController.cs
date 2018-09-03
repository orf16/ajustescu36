using RestSharp;
using SG_SST.Controllers.Base;
using SG_SST.Dtos.Empresas;
using SG_SST.Models;
using SG_SST.Models.AdminUsuarios;
using SG_SST.Models.Ausentismo;
using SG_SST.Models.Empresas;
using SG_SST.Models.Incidentes;
using SG_SST.Services.General.IServices;
using SG_SST.Services.General.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace SG_SST.Controllers.Incidentes
{
    public class IncidentesELController : BaseController
    {
        private SG_SSTContext db = new SG_SSTContext();
        IRecursosServicios recursosServicios = new RecursosServicios();
        public ActionResult CrearIncidenteEL(int? pk_id_incidente_el) 
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return View();
            }

            var incidentesmodel = new IncidentesELModel();
            incidentesmodel.DepartamentoI = recursosServicios.ObtenerDepartamentos();
            incidentesmodel.MunicipioI = recursosServicios.ObtenetMunicipios(1);
            incidentesmodel.DeptoCentroTrabajoII = recursosServicios.ObtenerDepartamentos();
            incidentesmodel.McpioCentroTrabajoII = recursosServicios.ObtenetMunicipios(1);
            incidentesmodel.DeptoEmpleadorII = recursosServicios.ObtenerDepartamentos();
            incidentesmodel.McpioEmpleadorII = recursosServicios.ObtenetMunicipios(1);


            var cliente = new RestSharp.RestClient(ConfigurationManager.AppSettings["Url"]);
            var request = new RestRequest(ConfigurationManager.AppSettings["consultaEmpresa"], RestSharp.Method.GET);
            request.RequestFormat = DataFormat.Xml;
            request.Parameters.Clear();
            request.AddParameter("tpDoc", "ni");
            request.AddParameter("doc", usuarioActual.NitEmpresa);
            request.AddParameter("color", "orange");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            //se omite la validación de certificado de SSL
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            IRestResponse<List<EmpresaSiarpDTO>> response = cliente.Execute<List<EmpresaSiarpDTO>>(request);
            var result = response.Content;
            var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmpresaSiarpDTO>>(result);
            //incidentesmodel.DepartamentoIV = recursosServicios.ObtenerDepartamentos();
            //incidentesmodel.MncpioIV = recursosServicios.ObtenetMunicipios(1);
            var empresa = db.Tbl_Empresa.Where(x => x.Nit_Empresa == usuarioActual.NitEmpresa).SingleOrDefault();

            if (pk_id_incidente_el != null)
                incidentesmodel.PK_Incidentes_EL_Id1 = (int)pk_id_incidente_el;
            else
                incidentesmodel.PK_Incidentes_EL_Id1 = 0;

            incidentesmodel.CodActividadII = empresa.Codigo_Actividad.ToString();
            incidentesmodel.ActividadPrincipalII = empresa.Descripcion_Actividad;
            incidentesmodel.TipoIdentificacionII = empresa.Tipo_Documento;
            incidentesmodel.NumIdentificacionII = empresa.Nit_Empresa;
            incidentesmodel.RazonSocialII = empresa.Razon_Social;
            incidentesmodel.DireccionPrincipalII = empresa.Direccion;
            incidentesmodel.TelefonoPpalII = empresa.Telefono.Value.ToString();
            incidentesmodel.FaxII = empresa.Fax.Value.ToString();
            incidentesmodel.EmailII = empresa.Email;
            incidentesmodel.ZonaPpalII = empresa.Zona;
            incidentesmodel.DeptoPpalII = respuesta[0].departamento;
            incidentesmodel.McpioPpalII = respuesta[0].municipio;
            incidentesmodel.tyears = GetYears();
            incidentesmodel.tmonth = GetMonths();
            incidentesmodel.tdays = GetDays();
            return View(incidentesmodel);
        }

        [HttpGet]
        public JsonResult CargarIncidentesEL(int pk_id_incidente_el)
        {
            if (pk_id_incidente_el == 0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var incidentesmodel = new IncidentesELModel();
            var incidentesatel1 = db.Tbl_IncidentesEL1.Where(x => (x.PK_Incidentes_EL == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel2 = db.Tbl_IncidentesEL2.Where(x => (x.FK_Incidentes_EL2 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel3 = db.Tbl_IncidentesEL3.Where(x => (x.FK_Incidentes_EL3 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel4 = db.Tbl_IncidentesEL4.Where(x => (x.FK_Incidentes_EL4 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel5 = db.Tbl_IncidentesEL5.Where(x => (x.FK_Incidentes_EL5 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel6 = db.Tbl_IncidentesEL6.Where(x => (x.FK_Incidentes_EL6 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel7 = db.Tbl_IncidentesEL7.Where(x => (x.FK_Incidentes_EL7 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel8 = db.Tbl_IncidentesEL8.Where(x => (x.FK_Incidentes_EL8 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel9 = db.Tbl_IncidentesEL9.Where(x => (x.FK_Incidentes_EL9 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesatel10 = db.Tbl_IncidentesEL10.Where(x => (x.FK_Incidentes_EL10 == pk_id_incidente_el && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
    
            if (incidentesatel1 == null)
            {
                return Json(incidentesatel1, JsonRequestBehavior.AllowGet);
            }

            if (incidentesatel1!=null)
            {
                incidentesmodel.PK_Incidentes_EL_Id = pk_id_incidente_el;
                incidentesmodel.EnfLabCalificadaI = incidentesatel1.EnfLabCalificadaI;
                incidentesmodel.FechaInvestigacionI = incidentesatel1.FechaInvestigacionI.ToString("dd/MM/yyyy");
                incidentesmodel.HoraInicioI = incidentesatel1.HoraInicioI;
                incidentesmodel.HoraFinI = incidentesatel1.HoraFinI;
                string pk_DepartamentoI = incidentesatel1.DepartamentoI.ToString();
                incidentesmodel.pk_DepartamentoI = int.Parse(pk_DepartamentoI);
                string pk_MunicipioI = incidentesatel1.MunicipioI.ToString();
                incidentesmodel.pk_MunicipioI = int.Parse(pk_MunicipioI);
                incidentesmodel.DireccionI = incidentesatel1.DireccionI;
                incidentesmodel.NombresApellidosI = incidentesatel1.NombresApellidosI;
                incidentesmodel.ProfesionalI = incidentesatel1.ProfesionalI;
                incidentesmodel.NoLicenciaI = incidentesatel1.NoLicenciaI;
                incidentesmodel.FotografiasI = incidentesatel1.FotografiasI;
                incidentesmodel.VideosI = incidentesatel1.VideosI;
                incidentesmodel.CintasAudioI = incidentesatel1.CintasAudioI;
                incidentesmodel.IlustracionesI = incidentesatel1.IlustracionesI;
                incidentesmodel.DiagramasI = incidentesatel1.DiagramasI;
                incidentesmodel.OtrosCualesI = incidentesatel1.OtrosCualesI;
                incidentesmodel.hmyFile1 = incidentesatel1.myFile1; 
            }
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel2!=null)
            {
                incidentesmodel.TempEmpleadorII = incidentesatel2.EmpleadorII;
                incidentesmodel.DireccionCentroTrabajoII = incidentesatel2.DireccionCentroTrabajoII;
                incidentesmodel.CodActividadII = incidentesatel2.CodActividadII;
                incidentesmodel.ActividadPrincipalII = incidentesatel2.ActividadPrincipalII;
                incidentesmodel.RazonSocialII = incidentesatel2.RazonSocialII;
                incidentesmodel.TipoIdentificacionII = incidentesatel2.TipoIdentificacionII;
                incidentesmodel.NumIdentificacionII = incidentesatel2.NumIdentificacionII;
                incidentesmodel.DireccionPrincipalII = incidentesatel2.DireccionPrincipalII;
                incidentesmodel.TelefonoPpalII = incidentesatel2.TelefonoPpalII;
                incidentesmodel.FaxII = incidentesatel2.FaxII;
                incidentesmodel.DeptoPpalII = incidentesatel2.DeptoPpalII;
                incidentesmodel.McpioPpalII = incidentesatel2.McpioPpalII;
                incidentesmodel.EmailII = incidentesatel2.EmailII;
                incidentesmodel.ZonaPpalII = incidentesatel2.ZonaPpalII;
                incidentesmodel.CentroTrabajoPpalII = incidentesatel2.CentroTrabajoPpalII;
                incidentesmodel.CentroCostoTelefonoII = incidentesatel2.CentroCostoTelefonoII;
                incidentesmodel.CentroCostoFaxII = incidentesatel2.CentroCostoFaxII;
                incidentesmodel.CodActEconoPpalII = incidentesatel2.CodActEconoPpalII;
                incidentesmodel.ActEconoCentroTrabajoII = incidentesatel2.ActEconoCentroTrabajoII;
                string DeptoEmpleadorII = incidentesatel2.DeptoEmpleadorII.ToString();
                incidentesmodel.pk_DeptoEmpleadorII = int.Parse(DeptoEmpleadorII);
                string McpioEmpleadorII = incidentesatel2.McpioEmpleadorII.ToString();
                incidentesmodel.pk_McpioEmpleadorII = int.Parse(McpioEmpleadorII);
                incidentesmodel.EmailEmpleadorII = incidentesatel2.EmailEmpleadorII;
                incidentesmodel.ZonaEmpleadorII = incidentesatel2.ZonaEmpleadorII;

                incidentesmodel.pk_DeptoCentroTrabajoII = int.Parse(incidentesatel2.DeptoCentroTrabajoII);
                incidentesmodel.pk_McpioCentroTrabajoII = int.Parse(incidentesatel2.McpioCentroTrabajoII);
            }
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel3!=null)
            {
                incidentesmodel.PlantaIII = incidentesatel3.PlantaIII;
                incidentesmodel.MisionIII = incidentesatel3.MisionIII;
                incidentesmodel.CooperadorIII = incidentesatel3.CooperadorIII;
                incidentesmodel.EstudianteIII = incidentesatel3.EstudianteIII;
                incidentesmodel.IndependienteIII = incidentesatel3.IndependienteIII;
                incidentesmodel.TempTipoIdentificacionIII = incidentesatel3.TipoIdentificacionIII;
                incidentesmodel.NumIdentificacionIII = incidentesatel3.NumIdentificacionIII;
                incidentesmodel.PrimerApellidoIII = incidentesatel3.PrimerApellidoIII;
                incidentesmodel.SegundoApellidoIII = incidentesatel3.SegundoApellidoIII;
                incidentesmodel.PrimerNombreIII = incidentesatel3.PrimerNombreIII;
                incidentesmodel.SegundoNombreIII = incidentesatel3.SegundoNombreIII;
                incidentesmodel.FechaNacimientoIII = incidentesatel3.FechaNacimientoIII;
                incidentesmodel.SexoIII = incidentesatel3.SexoIII;
                incidentesmodel.EPSAfiliadoIII = incidentesatel3.EPSAfiliadoIII;
                incidentesmodel.AFPAfiliadoIII = incidentesatel3.AFPAfiliadoIII;
                incidentesmodel.ARLAfiliadoIII = incidentesatel3.ARLAfiliadoIII;
                incidentesmodel.TelefonoIII = incidentesatel3.TelefonoIII;
                incidentesmodel.FaxIII = incidentesatel3.FaxIII;

                incidentesmodel.CodigoDeptoTrabajadorIII = incidentesatel3.CodigoDeptoTrabajadorIII;
                incidentesmodel.DeptoTrabajadorIII = incidentesatel3.DeptoTrabajadorIII;
                incidentesmodel.CodigoMncpioTrabajadorIII = incidentesatel3.CodigoMncpioTrabajadorIII;
                incidentesmodel.MncpioTrabajadorIII = incidentesatel3.MncpioTrabajadorIII;

                incidentesmodel.EmailTrabajadorIII = incidentesatel3.EmailTrabajadorIII;
                incidentesmodel.DireccionTrabajadorIII = incidentesatel3.DireccionTrabajadorIII;
                incidentesmodel.ZonaIII = incidentesatel3.ZonaIII;
            }
        
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel4!=null)
            {
                incidentesmodel.CargoIV = incidentesatel4.CargoIV;
                incidentesmodel.TiempoOcupacionAniosIV = incidentesatel4.TiempoOcupacionAniosIV;
                incidentesmodel.TiempoOcupacionMesesIV = incidentesatel4.TiempoOcupacionMesesIV;
                incidentesmodel.AntiguedadCargoAIV = incidentesatel4.AntiguedadCargoAIV;
                incidentesmodel.AntiguedadCargoMIV = incidentesatel4.AntiguedadCargoMIV;
                incidentesmodel.CodOcupacionIV = incidentesatel4.CodOcupacionIV;
                incidentesmodel.OcupacionHabitualIV = incidentesatel4.OcupacionHabitualIV;
                incidentesmodel.FechaMuerteIV = incidentesatel4.FechaMuerteIV;
                incidentesmodel.AreaActualIV = incidentesatel4.AreaActualIV;
                incidentesmodel.NombreCargoIV = incidentesatel4.NombreCargoIV;
                incidentesmodel.AntiguedadCargoAnioIV = incidentesatel4.AntiguedadCargoAnioIV;
                incidentesmodel.AntiguedadCargoMesesIV = incidentesatel4.AntiguedadCargoMesesIV;
                incidentesmodel.DiurnoIV = incidentesatel4.DiurnoIV;
                incidentesmodel.NocturnoIV = incidentesatel4.NocturnoIV;
                incidentesmodel.MixtoIV = incidentesatel4.MixtoIV;
                incidentesmodel.TurnosIV = incidentesatel4.TurnosIV;

                incidentesmodel.DiurnoIV2 = incidentesatel4.DiurnoIV2;
                incidentesmodel.NocturnoIV2 = incidentesatel4.NocturnoIV2;
                incidentesmodel.MixtoIV2 = incidentesatel4.MixtoIV2;
                incidentesmodel.TurnosIV2 = incidentesatel4.TurnosIV2;

                incidentesmodel.CondicionesPuestoTrabajoIV = incidentesatel4.CondicionesPuestoTrabajoIV;
                incidentesmodel.TareasCargo1IV = incidentesatel4.TareasCargo1IV;
                incidentesmodel.DedicacionJL1IV = incidentesatel4.DedicacionJL1IV;
                incidentesmodel.DedicacionJL11IV = incidentesatel4.DedicacionJL11IV;
                incidentesmodel.DedicacionJL12IV = incidentesatel4.DedicacionJL12IV;
                incidentesmodel.RelacionMuyProbable1IV = incidentesatel4.RelacionMuyProbable1IV;
                incidentesmodel.RelacionProbable1IV = incidentesatel4.RelacionProbable1IV;
                incidentesmodel.RelacionPocoProbable1IV = incidentesatel4.RelacionPocoProbable1IV;
                incidentesmodel.TareasCargo2IV = incidentesatel4.TareasCargo2IV;
                incidentesmodel.DedicacionJL21IV = incidentesatel4.DedicacionJL21IV;
                incidentesmodel.DedicacionJL22IV = incidentesatel4.DedicacionJL22IV;
                incidentesmodel.DedicacionJL23IV = incidentesatel4.DedicacionJL23IV;
                incidentesmodel.RelacionMuyProbable2IV = incidentesatel4.RelacionMuyProbable2IV;
                incidentesmodel.RelacionProbable2IV = incidentesatel4.RelacionProbable2IV;
                incidentesmodel.RelacionPocoProbable2IV = incidentesatel4.RelacionPocoProbable2IV;
                incidentesmodel.TareasCargo3IV = incidentesatel4.TareasCargo3IV;
                incidentesmodel.DedicacionJL31IV = incidentesatel4.DedicacionJL31IV;
                incidentesmodel.DedicacionJL32IV = incidentesatel4.DedicacionJL32IV;
                incidentesmodel.DedicacionJL33IV = incidentesatel4.DedicacionJL33IV;
                incidentesmodel.RelacionMuyProbable3IV = incidentesatel4.RelacionMuyProbable3IV;
                incidentesmodel.RelacionProbable3IV = incidentesatel4.RelacionProbable3IV;
                incidentesmodel.RelacionPocoProbable3IV = incidentesatel4.RelacionPocoProbable3IV;
                incidentesmodel.TareasCargo4IV = incidentesatel4.TareasCargo4IV;
                incidentesmodel.DedicacionJL41IV = incidentesatel4.DedicacionJL41IV;
                incidentesmodel.DedicacionJL42IV = incidentesatel4.DedicacionJL42IV;
                incidentesmodel.DedicacionJL43IV = incidentesatel4.DedicacionJL43IV;
                incidentesmodel.RelacionMuyProbable4IV = incidentesatel4.RelacionMuyProbable4IV;
                incidentesmodel.RelacionProbable4IV = incidentesatel4.RelacionProbable4IV;
                incidentesmodel.RelacionPocoProbable4IV = incidentesatel4.RelacionPocoProbable4IV;
                incidentesmodel.FormacionInformacionIV = incidentesatel4.FormacionInformacionIV;
                incidentesmodel.ProteccionColectivaIV = incidentesatel4.ProteccionColectivaIV;
                incidentesmodel.EPPIV = incidentesatel4.EPPIV;
                incidentesmodel.DisenoPuestoTrabajoIV = incidentesatel4.DisenoPuestoTrabajoIV;
                incidentesmodel.tempOrganizacionTrabajoIV = incidentesatel4.tempOrganizacionTrabajoIV;
                incidentesmodel.PreventivasIV = incidentesatel4.PreventivasIV;
                incidentesmodel.ImplementadasIV = incidentesatel4.ImplementadasIV;
                incidentesmodel.NoHabitualesIV = incidentesatel4.NoHabitualesIV;
                incidentesmodel.DescripcionIV = incidentesatel4.DescripcionIV;
                incidentesmodel.CodigoCie1 = incidentesatel4.CodigoCie1;
                incidentesmodel.CodigoCie2 = incidentesatel4.CodigoCie2;
                incidentesmodel.CodigoCie3 = incidentesatel4.CodigoCie3;
                incidentesmodel.CodigoCie4 = incidentesatel4.CodigoCie4;
                incidentesmodel.CodigoCie5 = incidentesatel4.CodigoCie5;
                incidentesmodel.DiagnosticoIV1 = incidentesatel4.DiagnosticoIV1;
                incidentesmodel.DiagnosticoIV2 = incidentesatel4.DiagnosticoIV2;
                incidentesmodel.DiagnosticoIV3 = incidentesatel4.DiagnosticoIV3;
                incidentesmodel.DiagnosticoIV4 = incidentesatel4.DiagnosticoIV4;
                incidentesmodel.FechaIngresoIV = incidentesatel4.FechaIngresoIV;
                incidentesmodel.MurioTrabajadorIV = incidentesatel4.MurioTrabajadorIV;
                incidentesmodel.ObservacionesIV = incidentesatel4.ObservacionesIV;
            }
            
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel5!=null)
            {
                incidentesmodel.NoTrabajadoresV = incidentesatel5.NoTrabajadoresV;
                incidentesmodel.CargosSimilaresV = incidentesatel5.CargosSimilaresV;
                incidentesmodel.NombresApellidosV2 = incidentesatel5.NombresApellidosV2;
                incidentesmodel.NombresApellidosV3 = incidentesatel5.NombresApellidosV3;
                incidentesmodel.NombresApellidosV4 = incidentesatel5.NombresApellidosV4;
                incidentesmodel.AnioDiagnosticoV1 = incidentesatel5.AnioDiagnosticoV1;
                incidentesmodel.AnioDiagnosticoV2 = incidentesatel5.AnioDiagnosticoV2;
                incidentesmodel.AnioDiagnosticoV3 = incidentesatel5.AnioDiagnosticoV3;
                incidentesmodel.AnioDiagnosticoV4 = incidentesatel5.AnioDiagnosticoV4;
                incidentesmodel.CodigoCieCIEV = incidentesatel5.CodigoCieCIEV;
                incidentesmodel.DiagnosticosCIEV = incidentesatel5.DiagnosticosCIEV;
                incidentesmodel.NombresApellidosV1 = incidentesatel5.NombresApellidosV1;
                incidentesmodel.NombresApellidosV5 = incidentesatel5.NombresApellidosV5;
                incidentesmodel.FechaOrigenELIV = incidentesatel5.FechaOrigenELV;
                incidentesmodel.OrigenLaboralIV = incidentesatel5.OrigenLaboralIV;
                incidentesmodel.NoTrabajadoresCargos = incidentesatel5.NoTrabajadoresCargos;
                incidentesmodel.CodigoCie1 = incidentesatel5.CodigoCie1;
                incidentesmodel.CodigoCie2 = incidentesatel5.CodigoCie2;
                incidentesmodel.CodigoCie3 = incidentesatel5.CodigoCie3;
                incidentesmodel.CodigoCie4 = incidentesatel5.CodigoCie4;
                incidentesmodel.DiagnosticoIV1 = incidentesatel5.DiagnosticoIV1;
                incidentesmodel.DiagnosticoIV2 = incidentesatel5.DiagnosticoIV2;
                incidentesmodel.DiagnosticoIV3 = incidentesatel5.DiagnosticoIV3;
                incidentesmodel.DiagnosticoIV4 = incidentesatel5.DiagnosticoIV4;
                incidentesmodel.FechaOrigenELIV = incidentesatel5.FechaOrigenELIV;
                incidentesmodel.OrigenLaboralIV = incidentesatel5.OrigenLaboralIV;
            }
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel6!=null)
            {
                incidentesmodel.PuestoEmpresaVI1 = incidentesatel6.PuestoEmpresaVI1;
                incidentesmodel.AgentesBiologicosVI1 = incidentesatel6.AgentesBiologicosVI1;
                incidentesmodel.FrasesVI1 = incidentesatel6.FrasesVI1;
                incidentesmodel.RutinariaVI1 = incidentesatel6.RutinariaVI1;
                incidentesmodel.NORutinariaVI1 = incidentesatel6.NORutinariaVI1;
                incidentesmodel.TiempoExposicionMesesVI1 = incidentesatel6.TiempoExposicionMesesVI1;
                incidentesmodel.TiempoExposicionHorasVI1 = incidentesatel6.TiempoExposicionHorasVI1;
                incidentesmodel.TLVCorregidoVI1 = incidentesatel6.TLVCorregidoVI1;
                incidentesmodel.ConcentracionHalladaVI1 = incidentesatel6.ConcentracionHalladaVI1;
                incidentesmodel.FechaMediacionDiaV1 = incidentesatel6.FechaMediacionDiaV1;
                incidentesmodel.FechaMediaMesV1 = incidentesatel6.FechaMediaMesV1;
                incidentesmodel.FechaMediaAnioV1 = incidentesatel6.FechaMediaAnioV1;
                incidentesmodel.NivelRiesgoV1 = incidentesatel6.NivelRiesgoV1;
                incidentesmodel.ViaEntradaV1 = incidentesatel6.ViaEntradaV1;
                incidentesmodel.PuestoEmpresaVI2 = incidentesatel6.PuestoEmpresaVI2;
                incidentesmodel.AgentesBiologicosVI2 = incidentesatel6.AgentesBiologicosVI2;
                incidentesmodel.FrasesVI2 = incidentesatel6.FrasesVI2;
                incidentesmodel.RutinariaVI2 = incidentesatel6.RutinariaVI2;
                incidentesmodel.NORutinariaVI2 = incidentesatel6.NORutinariaVI2;
                incidentesmodel.TiempoExposicionMesesVI2 = incidentesatel6.TiempoExposicionMesesVI2;
                incidentesmodel.TiempoExposicionHorasVI2 = incidentesatel6.TiempoExposicionHorasVI2;
                incidentesmodel.TLVCorregidoVI2 = incidentesatel6.TLVCorregidoVI2;
                incidentesmodel.ConcentracionHalladaVI2 = incidentesatel6.ConcentracionHalladaVI2;
                incidentesmodel.FechaMediacionDiaV2 = incidentesatel6.FechaMediacionDiaV2;
                incidentesmodel.FechaMediaMesV2 = incidentesatel6.FechaMediaMesV2;
                incidentesmodel.FechaMediaAnioV2 = incidentesatel6.FechaMediaAnioV2;
                incidentesmodel.NivelRiesgoV2 = incidentesatel6.NivelRiesgoV2;
                incidentesmodel.ViaEntradaV2 = incidentesatel6.ViaEntradaV2;
                incidentesmodel.PuestoEmpresaVI3 = incidentesatel6.PuestoEmpresaVI3;
                incidentesmodel.AgentesBiologicosVI3 = incidentesatel6.AgentesBiologicosVI3;
                incidentesmodel.FrasesVI3 = incidentesatel6.FrasesVI3;
                incidentesmodel.RutinariaVI3 = incidentesatel6.RutinariaVI3;
                incidentesmodel.NORutinariaVI3 = incidentesatel6.NORutinariaVI3;
                incidentesmodel.TiempoExposicionMesesVI3 = incidentesatel6.TiempoExposicionMesesVI3;
                incidentesmodel.TiempoExposicionHorasVI3 = incidentesatel6.TiempoExposicionHorasVI3;
                incidentesmodel.TLVCorregidoVI3 = incidentesatel6.TLVCorregidoVI3;
                incidentesmodel.ConcentracionHalladaVI3 = incidentesatel6.ConcentracionHalladaVI3;
                incidentesmodel.FechaMediacionDiaV3 = incidentesatel6.FechaMediacionDiaV3;
                incidentesmodel.FechaMediaMesV3 = incidentesatel6.FechaMediaMesV3;
                incidentesmodel.FechaMediaAnioV3 = incidentesatel6.FechaMediaAnioV3;
                incidentesmodel.NivelRiesgoV3 = incidentesatel6.NivelRiesgoV3;
                incidentesmodel.ViaEntradaV3 = incidentesatel6.ViaEntradaV3;
                incidentesmodel.PuestoEmpresaVI4 = incidentesatel6.PuestoEmpresaVI4;
                incidentesmodel.AgentesBiologicosVI4 = incidentesatel6.AgentesBiologicosVI4;
                incidentesmodel.FrasesVI4 = incidentesatel6.FrasesVI4;
                incidentesmodel.RutinariaVI4 = incidentesatel6.RutinariaVI4;
                incidentesmodel.NORutinariaVI4 = incidentesatel6.NORutinariaVI4;
                incidentesmodel.TiempoExposicionMesesVI4 = incidentesatel6.TiempoExposicionMesesVI4;
                incidentesmodel.TiempoExposicionHorasVI4 = incidentesatel6.TiempoExposicionHorasVI4;
                incidentesmodel.TLVCorregidoVI4 = incidentesatel6.TLVCorregidoVI4;
                incidentesmodel.ConcentracionHalladaVI4 = incidentesatel6.ConcentracionHalladaVI4;
                incidentesmodel.FechaMediacionDiaVI4 = incidentesatel6.FechaMediacionDiaVI4;
                incidentesmodel.FechaMediaMesVI4 = incidentesatel6.FechaMediaMesVI4;
                incidentesmodel.FechaMediaAnioVI4 = incidentesatel6.FechaMediaAnioVI4;
                incidentesmodel.NivelRiesgoVI4 = incidentesatel6.NivelRiesgoVI4;
                incidentesmodel.ViaEntradaVI4 = incidentesatel6.ViaEntradaVI4;
                incidentesmodel.OficioEmpresa2V1 = incidentesatel6.OficioEmpresa2V1;
                incidentesmodel.AgenteRelBiologico2VI = incidentesatel6.AgenteRelBiologico2VI;
                incidentesmodel.FuenteAgente2VI1 = incidentesatel6.FuenteAgente2VI1;
                incidentesmodel.MecanismoTransmicion2VI1 = incidentesatel6.MecanismoTransmicion2VI1;
                incidentesmodel.TipoActividadRutinaria2VI1 = incidentesatel6.TipoActividadRutinaria2VI1;
                incidentesmodel.TipoActividadNoRutinaria2VI1 = incidentesatel6.TipoActividadNoRutinaria2VI1;
                incidentesmodel.TiempoExposicionMeses2VI1 = incidentesatel6.TiempoExposicionMeses2VI1;
                incidentesmodel.TiempoExposicionHoras2VI1 = incidentesatel6.TiempoExposicionHoras2VI1;
                incidentesmodel.ConcentracionHallada2VI1 = incidentesatel6.ConcentracionHallada2VI1;
                incidentesmodel.NivelRiesgo2VI1 = incidentesatel6.NivelRiesgo2VI1;
                incidentesmodel.Dia2VI1 = incidentesatel6.Dia2VI1;
                incidentesmodel.Mes2VI1 = incidentesatel6.Mes2VI1;
                incidentesmodel.Anio2VI1 = incidentesatel6.Anio2VI1;
                incidentesmodel.FrecRiesgo2VI1 = incidentesatel6.FrecRiesgo2VI1;
                incidentesmodel.OficioEmpresa2V2 = incidentesatel6.OficioEmpresa2V2;
                incidentesmodel.AgenteRelBiologico2VI2 = incidentesatel6.AgenteRelBiologico2VI2;
                incidentesmodel.FuenteAgente2VI2 = incidentesatel6.FuenteAgente2VI2;
                incidentesmodel.MecanismoTransmicion2VI2 = incidentesatel6.MecanismoTransmicion2VI2;
                incidentesmodel.TipoActividadRutinaria2VI2 = incidentesatel6.TipoActividadRutinaria2VI2;
                incidentesmodel.TipoActividadNoRutinaria2VI2 = incidentesatel6.TipoActividadNoRutinaria2VI2;
                incidentesmodel.TiempoExposicionMeses2VI2 = incidentesatel6.TiempoExposicionMeses2VI2;
                incidentesmodel.TiempoExposicionHoras2VI2 = incidentesatel6.TiempoExposicionHoras2VI2;
                incidentesmodel.ConcentracionHallada2VI2 = incidentesatel6.ConcentracionHallada2VI2;
                incidentesmodel.NivelRiesgo2VI2 = incidentesatel6.NivelRiesgo2VI2;
                incidentesmodel.Dia2VI2 = incidentesatel6.Dia2VI2;
                incidentesmodel.Mes2VI2 = incidentesatel6.Mes2VI2;
                incidentesmodel.Anio2VI2 = incidentesatel6.Anio2VI2;
                incidentesmodel.FrecRiesgo2VI2 = incidentesatel6.FrecRiesgo2VI2;
                incidentesmodel.OficioEmpresa2V3 = incidentesatel6.OficioEmpresa2V3;
                incidentesmodel.AgenteRelBiologico2VI3 = incidentesatel6.AgenteRelBiologico2VI3;
                incidentesmodel.FuenteAgente2VI3 = incidentesatel6.FuenteAgente2VI3;
                incidentesmodel.MecanismoTransmicion2VI3 = incidentesatel6.MecanismoTransmicion2VI3;
                incidentesmodel.TipoActividadRutinaria2VI3 = incidentesatel6.TipoActividadRutinaria2VI3;
                incidentesmodel.TipoActividadNoRutinaria2VI3 = incidentesatel6.TipoActividadNoRutinaria2VI3;
                incidentesmodel.TiempoExposicionMeses2VI3 = incidentesatel6.TiempoExposicionMeses2VI3;
                incidentesmodel.TiempoExposicionHoras2VI3 = incidentesatel6.TiempoExposicionHoras2VI3;
                incidentesmodel.ConcentracionHallada2VI3 = incidentesatel6.ConcentracionHallada2VI3;
                incidentesmodel.NivelRiesgo2VI3 = incidentesatel6.NivelRiesgo2VI3;
                incidentesmodel.Dia2VI3 = incidentesatel6.Dia2VI3;
                incidentesmodel.Mes2VI3 = incidentesatel6.Mes2VI3;
                incidentesmodel.Anio2VI3 = incidentesatel6.Anio2VI3;
                incidentesmodel.FrecRiesgo2VI3 = incidentesatel6.FrecRiesgo2VI3;
                incidentesmodel.OficioEmpresa2V4 = incidentesatel6.OficioEmpresa2V4;
                incidentesmodel.AgenteRelBiologico2VI4 = incidentesatel6.AgenteRelBiologico2VI4;
                incidentesmodel.FuenteAgente2VI4 = incidentesatel6.FuenteAgente2VI4;
                incidentesmodel.MecanismoTransmicion2VI4 = incidentesatel6.MecanismoTransmicion2VI4;
                incidentesmodel.TipoActividadRutinaria2VI4 = incidentesatel6.TipoActividadRutinaria2VI4;
                incidentesmodel.TipoActividadNoRutinaria2VI4 = incidentesatel6.TipoActividadNoRutinaria2VI4;
                incidentesmodel.TiempoExposicionMeses2VI4 = incidentesatel6.TiempoExposicionMeses2VI4;
                incidentesmodel.TiempoExposicionHoras2VI4 = incidentesatel6.TiempoExposicionHoras2VI4;
                incidentesmodel.ConcentracionHallada2VI4 = incidentesatel6.ConcentracionHallada2VI4;
                incidentesmodel.NivelRiesgo2VI4 = incidentesatel6.NivelRiesgo2VI4;
                incidentesmodel.Dia2VI4 = incidentesatel6.Dia2VI4;
                incidentesmodel.Mes2VI4 = incidentesatel6.Mes2VI4;
                incidentesmodel.Anio2VI4 = incidentesatel6.Anio2VI4;
                incidentesmodel.FrecRiesgo2VI4 = incidentesatel6.FrecRiesgo2VI4;
                incidentesmodel.ExpoAccidentales2VI = incidentesatel6.ExpoAccidentales2VI;
                incidentesmodel.CargoOficioPuesto3VI = incidentesatel6.CargoOficioPuesto3VI;
                incidentesmodel.Fuentes3VI = incidentesatel6.Fuentes3VI;
                incidentesmodel.Meses3VI = incidentesatel6.Meses3VI;
                incidentesmodel.HorasDia3VI = incidentesatel6.HorasDia3VI;
                incidentesmodel.NivelAmbiental3VI = incidentesatel6.NivelAmbiental3VI;
                incidentesmodel.FMDia3VI = incidentesatel6.FMDia3VI;
                incidentesmodel.FMMes3VI = incidentesatel6.FMMes3VI;
                incidentesmodel.FMAnio3VI = incidentesatel6.FMAnio3VI;
                incidentesmodel.DosisRuido3VI = incidentesatel6.DosisRuido3VI;
                incidentesmodel.FecMedDia3VI = incidentesatel6.FecMedDia3VI;
                incidentesmodel.FecMedMes3VI = incidentesatel6.FecMedMes3VI;
                incidentesmodel.FecMEdAnio3VI = incidentesatel6.FecMEdAnio3VI;
                incidentesmodel.ExpSusQuimimcas3VI = incidentesatel6.ExpSusQuimimcas3VI;
                incidentesmodel.ExpoAccPrevias3VI = incidentesatel6.ExpoAccPrevias3VI;
                incidentesmodel.CargoOficioPuesto3VI1 = incidentesatel6.CargoOficioPuesto3VI1;
                incidentesmodel.Fuentes3VI1 = incidentesatel6.Fuentes3VI1;
                incidentesmodel.Meses3VI1 = incidentesatel6.Meses3VI1;
                incidentesmodel.HorasDia3VI1 = incidentesatel6.HorasDia3VI1;
                incidentesmodel.NivelAmbiental3VI1 = incidentesatel6.NivelAmbiental3VI1;
                incidentesmodel.FMDia3VI1 = incidentesatel6.FMDia3VI1;
                incidentesmodel.FMMes3VI1 = incidentesatel6.FMMes3VI1;
                incidentesmodel.FMAnio3VI1 = incidentesatel6.FMAnio3VI1;
                incidentesmodel.DosisRuido3VI1 = incidentesatel6.DosisRuido3VI1;
                incidentesmodel.FecMedDia3VI1 = incidentesatel6.FecMedDia3VI1;
                incidentesmodel.FecMedMes3VI1 = incidentesatel6.FecMedMes3VI1;
                incidentesmodel.FecMEdAnio3VI1 = incidentesatel6.FecMEdAnio3VI1;
                incidentesmodel.ExpSusQuimimcas3VI1 = incidentesatel6.ExpSusQuimimcas3VI1;
                incidentesmodel.ExpoAccPrevias3VI1 = incidentesatel6.ExpoAccPrevias3VI1;
                incidentesmodel.CargoOficioPuesto3VI2 = incidentesatel6.CargoOficioPuesto3VI2;
                incidentesmodel.Fuentes3VI2 = incidentesatel6.Fuentes3VI2;
                incidentesmodel.Meses3VI2 = incidentesatel6.Meses3VI2;
                incidentesmodel.HorasDia3VI2 = incidentesatel6.HorasDia3VI2;
                incidentesmodel.NivelAmbiental3VI2 = incidentesatel6.NivelAmbiental3VI2;
                incidentesmodel.FMDia3VI2 = incidentesatel6.FMDia3VI2;
                incidentesmodel.FMMes3VI2 = incidentesatel6.FMMes3VI2;
                incidentesmodel.FMAnio3VI2 = incidentesatel6.FMAnio3VI2;
                incidentesmodel.DosisRuido3VI2 = incidentesatel6.DosisRuido3VI2;
                incidentesmodel.FecMedDia3VI2 = incidentesatel6.FecMedDia3VI2;
                incidentesmodel.FecMedMes3VI2 = incidentesatel6.FecMedMes3VI2;
                incidentesmodel.FecMEdAnio3VI2 = incidentesatel6.FecMEdAnio3VI2;
                incidentesmodel.ExpSusQuimimcas3VI2 = incidentesatel6.ExpSusQuimimcas3VI2;
                incidentesmodel.ExpoAccPrevias3VI2 = incidentesatel6.ExpoAccPrevias3VI2;
                incidentesmodel.CargoOficioPuesto3VI3 = incidentesatel6.CargoOficioPuesto3VI3;
                incidentesmodel.Fuentes3VI3 = incidentesatel6.Fuentes3VI3;
                incidentesmodel.Meses3VI3 = incidentesatel6.Meses3VI3;
                incidentesmodel.HorasDia3VI3 = incidentesatel6.HorasDia3VI3;
                incidentesmodel.NivelAmbiental3VI3 = incidentesatel6.NivelAmbiental3VI3;
                incidentesmodel.FMDia3VI3 = incidentesatel6.FMDia3VI3;
                incidentesmodel.FMMes3VI3 = incidentesatel6.FMMes3VI3;
                incidentesmodel.FMAnio3VI3 = incidentesatel6.FMAnio3VI3;
                incidentesmodel.DosisRuido3VI3 = incidentesatel6.DosisRuido3VI3;
                incidentesmodel.FecMedDia3VI3 = incidentesatel6.FecMedDia3VI3;
                incidentesmodel.FecMedMes3VI3 = incidentesatel6.FecMedMes3VI3;
                incidentesmodel.FecMEdAnio3VI3 = incidentesatel6.FecMEdAnio3VI3;
                incidentesmodel.ExpSusQuimimcas3VI3 = incidentesatel6.ExpSusQuimimcas3VI3;
                incidentesmodel.ExpoAccPrevias3VI3 = incidentesatel6.ExpoAccPrevias3VI3;
                incidentesmodel.CargoOficio4VI1 = incidentesatel6.CargoOficio4VI1;
                incidentesmodel.DescActividad4VI1 = incidentesatel6.DescActividad4VI1;
                incidentesmodel.Duracion4VI1 = incidentesatel6.Duracion4VI1;
                incidentesmodel.FrecActividad4VI1 = incidentesatel6.FrecActividad4VI1;
                incidentesmodel.TipoTrabajoActividad4VI1 = incidentesatel6.TipoTrabajoActividad4VI1;
                incidentesmodel.WBTG4VI1 = incidentesatel6.WBTG4VI1;
                incidentesmodel.TipoExpMeses4VI1 = incidentesatel6.TipoExpMeses4VI1;
                incidentesmodel.TipoExpHD4VI1 = incidentesatel6.TipoExpHD4VI1;
                incidentesmodel.TasaTrabajo4VI1 = incidentesatel6.TasaTrabajo4VI1;
                incidentesmodel.FechaMedDia4VI1 = incidentesatel6.FechaMedDia4VI1;
                incidentesmodel.FechaMedMes4VI1 = incidentesatel6.FechaMedMes4VI1;
                incidentesmodel.FechaMedAnio4VI1 = incidentesatel6.FechaMedAnio4VI1;
                incidentesmodel.CargoOficio4VI2 = incidentesatel6.CargoOficio4VI2;
                incidentesmodel.DescActividad4VI2 = incidentesatel6.DescActividad4VI2;
                incidentesmodel.Duracion4VI2 = incidentesatel6.Duracion4VI2;
                incidentesmodel.FrecActividad4VI2 = incidentesatel6.FrecActividad4VI2;
                incidentesmodel.TipoTrabajoActividad4VI2 = incidentesatel6.TipoTrabajoActividad4VI2;
                incidentesmodel.WBTG4VI2 = incidentesatel6.WBTG4VI2;
                incidentesmodel.TipoExpMeses4VI2 = incidentesatel6.TipoExpMeses4VI2;
                incidentesmodel.TipoExpHD4VI2 = incidentesatel6.TipoExpHD4VI2;
                incidentesmodel.TasaTrabajo4VI2 = incidentesatel6.TasaTrabajo4VI2;
                incidentesmodel.FechaMedDia4VI2 = incidentesatel6.FechaMedDia4VI2;
                incidentesmodel.FechaMedMes4VI2 = incidentesatel6.FechaMedMes4VI2;
                incidentesmodel.FechaMedAnio4VI2 = incidentesatel6.FechaMedAnio4VI2;
                incidentesmodel.CargoOficio4VI3 = incidentesatel6.CargoOficio4VI3;
                incidentesmodel.DescActividad4VI3 = incidentesatel6.DescActividad4VI3;
                incidentesmodel.Duracion4VI3 = incidentesatel6.Duracion4VI3;
                incidentesmodel.FrecActividad4VI3 = incidentesatel6.FrecActividad4VI3;
                incidentesmodel.TipoTrabajoActividad4VI3 = incidentesatel6.TipoTrabajoActividad4VI3;
                incidentesmodel.WBTG4VI3 = incidentesatel6.WBTG4VI3;
                incidentesmodel.TipoExpMeses4VI3 = incidentesatel6.TipoExpMeses4VI3;
                incidentesmodel.TipoExpHD4VI3 = incidentesatel6.TipoExpHD4VI3;
                incidentesmodel.TasaTrabajo4VI3 = incidentesatel6.TasaTrabajo4VI3;
                incidentesmodel.FechaMedDia4VI3 = incidentesatel6.FechaMedDia4VI3;
                incidentesmodel.FechaMedMes4VI3 = incidentesatel6.FechaMedMes4VI3;
                incidentesmodel.FechaMedAnio4VI3 = incidentesatel6.FechaMedAnio4VI3;
                incidentesmodel.CargoOficio4VI4 = incidentesatel6.CargoOficio4VI4;
                incidentesmodel.DescActividad4VI4 = incidentesatel6.DescActividad4VI4;
                incidentesmodel.Duracion4VI4 = incidentesatel6.Duracion4VI4;
                incidentesmodel.FrecActividad4VI4 = incidentesatel6.FrecActividad4VI4;
                incidentesmodel.TipoTrabajoActividad4VI4 = incidentesatel6.TipoTrabajoActividad4VI4;
                incidentesmodel.WBTG4VI4 = incidentesatel6.WBTG4VI4;
                incidentesmodel.TipoExpMeses4VI4 = incidentesatel6.TipoExpMeses4VI4;
                incidentesmodel.TipoExpHD4VI4 = incidentesatel6.TipoExpHD4VI4;
                incidentesmodel.TasaTrabajo4VI4 = incidentesatel6.TasaTrabajo4VI4;
                incidentesmodel.FechaMedDia4VI4 = incidentesatel6.FechaMedDia4VI4;
                incidentesmodel.FechaMedMes4VI4 = incidentesatel6.FechaMedMes4VI4;
                incidentesmodel.FechaMedAnio4VI4 = incidentesatel6.FechaMedAnio4VI4;
                incidentesmodel.RadCargoEmpresa5VI1 = incidentesatel6.RadCargoEmpresa5VI1;
                incidentesmodel.RadDescripcionFuente5VI1 = incidentesatel6.RadDescripcionFuente5VI1;
                incidentesmodel.RadDescripcionAct5VI1 = incidentesatel6.RadDescripcionAct5VI1;
                incidentesmodel.RadCondiciones5VI1 = incidentesatel6.RadCondiciones5VI1;
                incidentesmodel.RadTEDia5VI1 = incidentesatel6.RadTEDia5VI1;
                incidentesmodel.RadTEMes5VI1 = incidentesatel6.RadTEMes5VI1;
                incidentesmodel.RadTEAnio5VI1 = incidentesatel6.RadTEAnio5VI1;
                incidentesmodel.RadEvalAmbiental5VI1 = incidentesatel6.RadEvalAmbiental5VI1;
                incidentesmodel.RadFMDia5VI1 = incidentesatel6.RadFMDia5VI1;
                incidentesmodel.RadFMMes5VI1 = incidentesatel6.RadFMMes5VI1;
                incidentesmodel.RadFMAnio5VI1 = incidentesatel6.RadFMAnio5VI1;
                incidentesmodel.RadCargoEmpresa5VI2 = incidentesatel6.RadCargoEmpresa5VI2;
                incidentesmodel.RadDescripcionFuente5VI2 = incidentesatel6.RadDescripcionFuente5VI2;
                incidentesmodel.RadDescripcionAct5VI2 = incidentesatel6.RadDescripcionAct5VI2;
                incidentesmodel.RadCondiciones5VI2 = incidentesatel6.RadCondiciones5VI2;
                incidentesmodel.RadTEDia5VI2 = incidentesatel6.RadTEDia5VI2;
                incidentesmodel.RadTEMes5VI2 = incidentesatel6.RadTEMes5VI2;
                incidentesmodel.RadTEAnio5VI2 = incidentesatel6.RadTEAnio5VI2;
                incidentesmodel.RadEvalAmbiental5VI2 = incidentesatel6.RadEvalAmbiental5VI2;
                incidentesmodel.RadFMDia5VI2 = incidentesatel6.RadFMDia5VI2;
                incidentesmodel.RadFMMes5VI2 = incidentesatel6.RadFMMes5VI2;
                incidentesmodel.RadFMAnio5VI2 = incidentesatel6.RadFMAnio5VI2;
                incidentesmodel.RadCargoEmpresa5VI3 = incidentesatel6.RadCargoEmpresa5VI3;
                incidentesmodel.RadDescripcionFuente5VI3 = incidentesatel6.RadDescripcionFuente5VI3;
                incidentesmodel.RadDescripcionAct5VI3 = incidentesatel6.RadDescripcionAct5VI3;
                incidentesmodel.RadCondiciones5VI3 = incidentesatel6.RadCondiciones5VI3;
                incidentesmodel.RadTEDia5VI3 = incidentesatel6.RadTEDia5VI3;
                incidentesmodel.RadTEMes5VI3 = incidentesatel6.RadTEMes5VI3;
                incidentesmodel.RadTEAnio5VI3 = incidentesatel6.RadTEAnio5VI3;
                incidentesmodel.RadEvalAmbiental5VI3 = incidentesatel6.RadEvalAmbiental5VI3;
                incidentesmodel.RadFMDia5VI3 = incidentesatel6.RadFMDia5VI3;
                incidentesmodel.RadFMMes5VI3 = incidentesatel6.RadFMMes5VI3;
                incidentesmodel.RadFMAnio5VI3 = incidentesatel6.RadFMAnio5VI3;
                incidentesmodel.RadCargoEmpresa5VI4 = incidentesatel6.RadCargoEmpresa5VI4;
                incidentesmodel.RadDescripcionFuente5VI4 = incidentesatel6.RadDescripcionFuente5VI4;
                incidentesmodel.RadDescripcionAct5VI4 = incidentesatel6.RadDescripcionAct5VI4;
                incidentesmodel.RadCondiciones5VI4 = incidentesatel6.RadCondiciones5VI4;
                incidentesmodel.RadTEDia5VI4 = incidentesatel6.RadTEDia5VI4;
                incidentesmodel.RadTEMes5VI4 = incidentesatel6.RadTEMes5VI4;
                incidentesmodel.RadTEAnio5V4 = incidentesatel6.RadTEAnio5V4;
                incidentesmodel.RadEvalAmbiental5VI4 = incidentesatel6.RadEvalAmbiental5VI4;
                incidentesmodel.RadFMDia5VI4 = incidentesatel6.RadFMDia5VI4;
                incidentesmodel.RadFMMes5VI4 = incidentesatel6.RadFMMes5VI4;
                incidentesmodel.RadFMAnio5VI4 = incidentesatel6.RadFMAnio5VI4;
                incidentesmodel.VibCargoEmpresa6VI1 = incidentesatel6.VibCargoEmpresa6VI1;
                incidentesmodel.VibDescFuente6VI1 = incidentesatel6.VibDescFuente6VI1;
                incidentesmodel.BooTipoVibCE6VI1 = incidentesatel6.BooTipoVibCE6VI1;
                incidentesmodel.BooTipoVibMB6VI1 = incidentesatel6.BooTipoVibMB6VI1;
                incidentesmodel.TiempoExpMeses6VI1 = incidentesatel6.TiempoExpMeses6VI1;
                incidentesmodel.TiempoExpHD6VI1 = incidentesatel6.TiempoExpHD6VI1;
                incidentesmodel.VCE6VI1 = incidentesatel6.VCE6VI1;
                incidentesmodel.VMB6VI1 = incidentesatel6.VMB6VI1;
                incidentesmodel.AceTotal6VI1 = incidentesatel6.AceTotal6VI1;
                incidentesmodel.EjeDominante6VI1 = incidentesatel6.EjeDominante6VI1;
                incidentesmodel.AceEjeDominante6VI1 = incidentesatel6.AceEjeDominante6VI1;
                incidentesmodel.Frecuencia6VI1 = incidentesatel6.Frecuencia6VI1;
                incidentesmodel.Aceleracion6VI1 = incidentesatel6.Aceleracion6VI1;
                incidentesmodel.FechaMedDia6VI1 = incidentesatel6.FechaMedDia6VI1;
                incidentesmodel.FechaMedMes6VI1 = incidentesatel6.FechaMedMes6VI1;
                incidentesmodel.FechaMedAnio6VI1 = incidentesatel6.FechaMedAnio6VI1;
                incidentesmodel.BooExpoRuido6VI1 = incidentesatel6.BooExpoRuido6VI1;
                incidentesmodel.VibCargoEmpresa6VI2 = incidentesatel6.VibCargoEmpresa6VI2;
                incidentesmodel.VibDescFuente6VI2 = incidentesatel6.VibDescFuente6VI2;
                incidentesmodel.BooTipoVibCE6VI2 = incidentesatel6.BooTipoVibCE6VI2;
                incidentesmodel.BooTipoVibMB6VI2 = incidentesatel6.BooTipoVibMB6VI2;
                incidentesmodel.TiempoExpMeses6VI2 = incidentesatel6.TiempoExpMeses6VI2;
                incidentesmodel.TiempoExpHD6VI2 = incidentesatel6.TiempoExpHD6VI2;
                incidentesmodel.VCE6VI2 = incidentesatel6.VCE6VI2;
                incidentesmodel.VMB6VI2 = incidentesatel6.VMB6VI2;
                incidentesmodel.AceTotal6VI2 = incidentesatel6.AceTotal6VI2;
                incidentesmodel.EjeDominante6VI2 = incidentesatel6.EjeDominante6VI2;
                incidentesmodel.AceEjeDominante6VI2 = incidentesatel6.AceEjeDominante6VI2;
                incidentesmodel.Frecuencia6VI2 = incidentesatel6.Frecuencia6VI2;
                incidentesmodel.Aceleracion6VI2 = incidentesatel6.Aceleracion6VI2;
                incidentesmodel.FechaMedDia6VI2 = incidentesatel6.FechaMedDia6VI2;
                incidentesmodel.FechaMedMes6VI2 = incidentesatel6.FechaMedMes6VI2;
                incidentesmodel.FechaMedAnio6VI2 = incidentesatel6.FechaMedAnio6VI2;
                incidentesmodel.BooExpoRuido6VI2 = incidentesatel6.BooExpoRuido6VI2;
                incidentesmodel.VibCargoEmpresa6VI3 = incidentesatel6.VibCargoEmpresa6VI3;
                incidentesmodel.VibDescFuente6VI3 = incidentesatel6.VibDescFuente6VI3;
                incidentesmodel.BooTipoVibCE6VI3 = incidentesatel6.BooTipoVibCE6VI3;
                incidentesmodel.BooTipoVibMB6VI3 = incidentesatel6.BooTipoVibMB6VI3;
                incidentesmodel.TiempoExpMeses6VI3 = incidentesatel6.TiempoExpMeses6VI3;
                incidentesmodel.TiempoExpHD6VI3 = incidentesatel6.TiempoExpHD6VI3;
                incidentesmodel.VCE6VI3 = incidentesatel6.VCE6VI3;
                incidentesmodel.VMB6VI3 = incidentesatel6.VMB6VI3;
                incidentesmodel.AceTotal6VI3 = incidentesatel6.AceTotal6VI3;
                incidentesmodel.EjeDominante6VI3 = incidentesatel6.EjeDominante6VI3;
                incidentesmodel.AceEjeDominante6VI3 = incidentesatel6.AceEjeDominante6VI3;
                incidentesmodel.Frecuencia6VI3 = incidentesatel6.Frecuencia6VI3;
                incidentesmodel.Aceleracion6VI3 = incidentesatel6.Aceleracion6VI3;
                incidentesmodel.FechaMedDia6VI3 = incidentesatel6.FechaMedDia6VI3;
                incidentesmodel.FechaMedMes6VI3 = incidentesatel6.FechaMedMes6VI3;
                incidentesmodel.FechaMedAnio6VI3 = incidentesatel6.FechaMedAnio6VI3;
                incidentesmodel.BooExpoRuido6VI3 = incidentesatel6.BooExpoRuido6VI3;
                incidentesmodel.VibCargoEmpresa6VI4 = incidentesatel6.VibCargoEmpresa6VI4;
                incidentesmodel.VibDescFuente6VI4 = incidentesatel6.VibDescFuente6VI4;
                incidentesmodel.BooTipoVibCE6VI4 = incidentesatel6.BooTipoVibCE6VI4;
                incidentesmodel.BooTipoVibMB6VI4 = incidentesatel6.BooTipoVibMB6VI4;
                incidentesmodel.TiempoExpMeses6VI4 = incidentesatel6.TiempoExpMeses6VI4;
                incidentesmodel.TiempoExpHD6VI4 = incidentesatel6.TiempoExpHD6VI4;
                incidentesmodel.VCE6VI4 = incidentesatel6.VCE6VI4;
                incidentesmodel.VMB6VI4 = incidentesatel6.VMB6VI4;
                incidentesmodel.AceTotal6VI4 = incidentesatel6.AceTotal6VI4;
                incidentesmodel.EjeDominante6VI4 = incidentesatel6.EjeDominante6VI4;
                incidentesmodel.AceEjeDominante6VI4 = incidentesatel6.AceEjeDominante6VI4;
                incidentesmodel.Frecuencia6VI4 = incidentesatel6.Frecuencia6VI4;
                incidentesmodel.Aceleracion6VI4 = incidentesatel6.Aceleracion6VI4;
                incidentesmodel.FechaMedDia6VI4 = incidentesatel6.FechaMedDia6VI4;
                incidentesmodel.FechaMedMes6VI4 = incidentesatel6.FechaMedMes6VI4;
                incidentesmodel.FechaMedAnio6VI4 = incidentesatel6.FechaMedAnio6VI4;
                incidentesmodel.BooExpoRuido6VI4 = incidentesatel6.BooExpoRuido6VI4;
                incidentesmodel.VibCargoEmpresa6VI5 = incidentesatel6.VibCargoEmpresa6VI5;
                incidentesmodel.VibDescFuente6VI5 = incidentesatel6.VibDescFuente6VI5;
                incidentesmodel.BooTipoVibCE6VI5 = incidentesatel6.BooTipoVibCE6VI5;
                incidentesmodel.BooTipoVibMB6VI5 = incidentesatel6.BooTipoVibMB6VI5;
                incidentesmodel.TiempoExpMeses6VI5 = incidentesatel6.TiempoExpMeses6VI5;
                incidentesmodel.TiempoExpHD6VI5 = incidentesatel6.TiempoExpHD6VI5;
                incidentesmodel.VCE6VI5 = incidentesatel6.VCE6VI5;
                incidentesmodel.VMB6VI5 = incidentesatel6.VMB6VI5;
                incidentesmodel.AceTotal6VI5 = incidentesatel6.AceTotal6VI5;
                incidentesmodel.EjeDominante6VI5 = incidentesatel6.EjeDominante6VI5;
                incidentesmodel.AceEjeDominante6VI5 = incidentesatel6.AceEjeDominante6VI5;
                incidentesmodel.Frecuencia6VI5 = incidentesatel6.Frecuencia6VI5;
                incidentesmodel.Aceleracion6VI5 = incidentesatel6.Aceleracion6VI5;
                incidentesmodel.FechaMedDia6VI5 = incidentesatel6.FechaMedDia6VI5;
                incidentesmodel.FechaMedMes6VI5 = incidentesatel6.FechaMedMes6VI5;
                incidentesmodel.FechaMedAnio6VI5 = incidentesatel6.FechaMedAnio6VI5;
                incidentesmodel.BooExpoRuido6VI5 = incidentesatel6.BooExpoRuido6VI5;
                incidentesmodel.VibCargoEmpresa6VI6 = incidentesatel6.VibCargoEmpresa6VI6;
                incidentesmodel.VibDescFuente6VI6 = incidentesatel6.VibDescFuente6VI6;
                incidentesmodel.BooTipoVibCE6VI6 = incidentesatel6.BooTipoVibCE6VI6;
                incidentesmodel.BooTipoVibMB6VI6 = incidentesatel6.BooTipoVibMB6VI6;
                incidentesmodel.TiempoExpMeses6VI6 = incidentesatel6.TiempoExpMeses6VI6;
                incidentesmodel.TiempoExpHD6VI6 = incidentesatel6.TiempoExpHD6VI6;
                incidentesmodel.VCE6VI6 = incidentesatel6.VCE6VI6;
                incidentesmodel.VMB6VI6 = incidentesatel6.VMB6VI6;
                incidentesmodel.AceTotal6VI6 = incidentesatel6.AceTotal6VI6;
                incidentesmodel.EjeDominante6VI6 = incidentesatel6.EjeDominante6VI6;
                incidentesmodel.AceEjeDominante6VI6 = incidentesatel6.AceEjeDominante6VI6;
                incidentesmodel.Frecuencia6VI6 = incidentesatel6.Frecuencia6VI6;
                incidentesmodel.Aceleracion6VI6 = incidentesatel6.Aceleracion6VI6;
                incidentesmodel.FechaMedDia6VI6 = incidentesatel6.FechaMedDia6VI6;
                incidentesmodel.FechaMedMes6VI6 = incidentesatel6.FechaMedMes6VI6;
                incidentesmodel.FechaMedAnio6VI6 = incidentesatel6.FechaMedAnio6VI6;
                incidentesmodel.BooExpoRuido6VI6 = incidentesatel6.BooExpoRuido6VI6;
                incidentesmodel.DescEventoInv6VI = incidentesatel6.DescEventoInv6VI;
                incidentesmodel.FrecPresAltoVI1 = incidentesatel6.FrecPresAltoVI1;
                incidentesmodel.FrecPresMedioVI1 = incidentesatel6.FrecPresMedioVI1;
                incidentesmodel.FrecPresBajoVI1 = incidentesatel6.FrecPresBajoVI1;
                incidentesmodel.TiempoExpAltoVI1 = incidentesatel6.TiempoExpAltoVI1;
                incidentesmodel.TiempoExpMedioVI1 = incidentesatel6.TiempoExpMedioVI1;
                incidentesmodel.TiempoExpBajoVI1 = incidentesatel6.TiempoExpBajoVI1;
                incidentesmodel.IntensidadAltoVI1 = incidentesatel6.IntensidadAltoVI1;
                incidentesmodel.IntensidadMedioVI1 = incidentesatel6.IntensidadMedioVI1;
                incidentesmodel.IntensidadBajoVI1 = incidentesatel6.IntensidadBajoVI1;
                incidentesmodel.VarPsicoObservacionesVI1 = incidentesatel6.VarPsicoObservacionesVI1;
                incidentesmodel.FrecPresAltoVI2 = incidentesatel6.FrecPresAltoVI2;
                incidentesmodel.FrecPresMedioVI2 = incidentesatel6.FrecPresMedioVI2;
                incidentesmodel.FrecPresBajoVI2 = incidentesatel6.FrecPresBajoVI2;
                incidentesmodel.TiempoExpAltoVI2 = incidentesatel6.TiempoExpAltoVI2;
                incidentesmodel.TiempoExpMedioVI2 = incidentesatel6.TiempoExpMedioVI2;
                incidentesmodel.TiempoExpBajoVI2 = incidentesatel6.TiempoExpBajoVI2;
                incidentesmodel.IntensidadAltoVI2 = incidentesatel6.IntensidadAltoVI2;
                incidentesmodel.IntensidadMedioVI2 = incidentesatel6.IntensidadMedioVI2;
                incidentesmodel.IntensidadBajoVI2 = incidentesatel6.IntensidadBajoVI2;
                incidentesmodel.VarPsicoObservacionesVI2 = incidentesatel6.VarPsicoObservacionesVI2;
                incidentesmodel.FrecPresAltoVI3 = incidentesatel6.FrecPresAltoVI3;
                incidentesmodel.FrecPresMedioVI3 = incidentesatel6.FrecPresMedioVI3;
                incidentesmodel.FrecPresBajoVI3 = incidentesatel6.FrecPresBajoVI3;
                incidentesmodel.TiempoExpAltoVI3 = incidentesatel6.TiempoExpAltoVI3;
                incidentesmodel.TiempoExpMedioVI3 = incidentesatel6.TiempoExpMedioVI3;
                incidentesmodel.TiempoExpBajoVI3 = incidentesatel6.TiempoExpBajoVI3;
                incidentesmodel.IntensidadAltoVI3 = incidentesatel6.IntensidadAltoVI3;
                incidentesmodel.IntensidadMedioVI3 = incidentesatel6.IntensidadMedioVI3;
                incidentesmodel.IntensidadBajoVI3 = incidentesatel6.IntensidadBajoVI3;
                incidentesmodel.VarPsicoObservacionesVI3 = incidentesatel6.VarPsicoObservacionesVI3;
                incidentesmodel.FrecPresAltoVI4 = incidentesatel6.FrecPresAltoVI4;
                incidentesmodel.FrecPresMedioVI4 = incidentesatel6.FrecPresMedioVI4;
                incidentesmodel.FrecPresBajoVI4 = incidentesatel6.FrecPresBajoVI4;
                incidentesmodel.TiempoExpAltoVI4 = incidentesatel6.TiempoExpAltoVI4;
                incidentesmodel.TiempoExpMedioVI4 = incidentesatel6.TiempoExpMedioVI4;
                incidentesmodel.TiempoExpBajoV4 = incidentesatel6.TiempoExpBajoV4;
                incidentesmodel.IntensidadAltoVI4 = incidentesatel6.IntensidadAltoVI4;
                incidentesmodel.IntensidadMedioVI4 = incidentesatel6.IntensidadMedioVI4;
                incidentesmodel.IntensidadBajoVI4 = incidentesatel6.IntensidadBajoVI4;
                incidentesmodel.VarPsicoObservacionesVI4 = incidentesatel6.VarPsicoObservacionesVI4;
                incidentesmodel.IntensidadAltaVI1 = incidentesatel6.IntensidadAltaVI1;
                incidentesmodel.IntensidadMediaVI1 = incidentesatel6.IntensidadMediaVI1;
                incidentesmodel.IntensidadBajaVI1 = incidentesatel6.IntensidadBajaVI1;
                incidentesmodel.IntensidadObservVI1 = incidentesatel6.IntensidadObservVI1;
                incidentesmodel.IntensidadAltaVI2 = incidentesatel6.IntensidadAltaVI2;
                incidentesmodel.IntensidadMediaVI2 = incidentesatel6.IntensidadMediaVI2;
                incidentesmodel.IntensidadBajaVI2 = incidentesatel6.IntensidadBajaVI2;
                incidentesmodel.IntensidadObservVI2 = incidentesatel6.IntensidadObservVI2;
                incidentesmodel.NivelRiesgoLabVI = incidentesatel6.NivelRiesgoLabVI;
                incidentesmodel.NivelRiesgoExtralabVI = incidentesatel6.NivelRiesgoExtralabVI;
                incidentesmodel.NivelRiesgoIndiviVI = incidentesatel6.NivelRiesgoIndiviVI;
                incidentesmodel.NivelEstresVI = incidentesatel6.NivelEstresVI;
                incidentesmodel.BooPostPieProlongada = incidentesatel6.BooPostPieProlongada;
                incidentesmodel.BooPostPieSedente = incidentesatel6.BooPostPieSedente;
                incidentesmodel.BooPosturaIncomodaBrazosManos = incidentesatel6.BooPosturaIncomodaBrazosManos;
                incidentesmodel.BooEsfuerzoBrazosManos = incidentesatel6.BooEsfuerzoBrazosManos;
                incidentesmodel.BooEsfuerzoBrazosManos1 = incidentesatel6.BooEsfuerzoBrazosManos1;
                incidentesmodel.BooPosturaIncomodaEspalda = incidentesatel6.BooPosturaIncomodaEspalda;
                incidentesmodel.BooLabRepetitivaColumna = incidentesatel6.BooLabRepetitivaColumna;
                incidentesmodel.BooLabRepetitivaBrazoMuMano = incidentesatel6.BooLabRepetitivaBrazoMuMano;
                incidentesmodel.BooPeriodoRecuperacionFisica = incidentesatel6.BooPeriodoRecuperacionFisica;
                incidentesmodel.BooEsfuerzoManos = incidentesatel6.BooEsfuerzoManos;
                incidentesmodel.BooEsfuerzoCuerpo = incidentesatel6.BooEsfuerzoCuerpo;
                incidentesmodel.BooManipulacionCargas = incidentesatel6.BooManipulacionCargas;
                incidentesmodel.DMEResumen = incidentesatel6.DMEResumen;
                incidentesmodel.BooCauRelPrevVI1 = incidentesatel6.BooCauRelPrevVI1;
                incidentesmodel.CauRelPrevVI1 = incidentesatel6.CauRelPrevVI1;
                incidentesmodel.BooCauRelPrevVI2 = incidentesatel6.BooCauRelPrevVI2;
                incidentesmodel.CauRelPrevVI2 = incidentesatel6.CauRelPrevVI2;
                incidentesmodel.BooCauRelPrevVI3 = incidentesatel6.BooCauRelPrevVI3;
                incidentesmodel.CauRelPrevVI3 = incidentesatel6.CauRelPrevVI3;
                incidentesmodel.BooCauRelPrevVI4 = incidentesatel6.BooCauRelPrevVI4;
                incidentesmodel.CauRelPrevVI4 = incidentesatel6.CauRelPrevVI4;
                incidentesmodel.BooCauRelPrevVI5 = incidentesatel6.BooCauRelPrevVI5;
                incidentesmodel.CauRelPrevVI5 = incidentesatel6.CauRelPrevVI5;
                incidentesmodel.BooCauRelPrevVI6 = incidentesatel6.BooCauRelPrevVI6;
                incidentesmodel.CauRelPrevVI6 = incidentesatel6.CauRelPrevVI6;
                incidentesmodel.BooCauRelPrevVI7 = incidentesatel6.BooCauRelPrevVI7;
                incidentesmodel.CauRelPrevVI7 = incidentesatel6.CauRelPrevVI7;
                incidentesmodel.BooCauRelPrevVI8 = incidentesatel6.BooCauRelPrevVI8;
                incidentesmodel.CauRelPrevVI8 = incidentesatel6.CauRelPrevVI8;
                incidentesmodel.BooCauRelPrevVI9 = incidentesatel6.BooCauRelPrevVI9;
                incidentesmodel.CauRelPrevVI9 = incidentesatel6.CauRelPrevVI9;
                incidentesmodel.BooCauRelPrevVI10 = incidentesatel6.BooCauRelPrevVI10;
                incidentesmodel.CauRelPrevVI10 = incidentesatel6.CauRelPrevVI10;
                incidentesmodel.BooCauRelPrevVI11 = incidentesatel6.BooCauRelPrevVI11;
                incidentesmodel.CauRelPrevVI11 = incidentesatel6.CauRelPrevVI11;
                incidentesmodel.BooCauRelPrevVI12 = incidentesatel6.BooCauRelPrevVI12;
                incidentesmodel.CauRelPrevVI12 = incidentesatel6.CauRelPrevVI12;
                incidentesmodel.BooCauRelPrevVI13 = incidentesatel6.BooCauRelPrevVI13;
                incidentesmodel.CauRelPrevVI13 = incidentesatel6.CauRelPrevVI13;
                incidentesmodel.BooCauRelPrevVI14 = incidentesatel6.BooCauRelPrevVI14;
                incidentesmodel.CauRelPrevVI14 = incidentesatel6.CauRelPrevVI14;
                incidentesmodel.BooCauRelPrevVI15 = incidentesatel6.BooCauRelPrevVI15;
                incidentesmodel.CauRelPrevVI15 = incidentesatel6.CauRelPrevVI15;
                incidentesmodel.OtrosDatosInteresVI = incidentesatel6.OtrosDatosInteresVI;
                incidentesmodel.CausasEnfermedadLaboralVI = incidentesatel6.CausasEnfermedadLaboralVI;
                incidentesmodel.NivelRiesgoVI1 = incidentesatel6.NivelRiesgoVI1;
                incidentesmodel.ViaEntradaVI1 = incidentesatel6.ViaEntradaVI1;
                incidentesmodel.NivelRiesgoV4 = incidentesatel6.NivelRiesgoV4;
                incidentesmodel.ViaEntradaV4 = incidentesatel6.ViaEntradaV4;
            }
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel7!=null)
            {
                incidentesmodel.MedidasPreventivasVII1 = incidentesatel7.MedidasPreventivasVII1;
                incidentesmodel.ResponsableImplementacionVII1 = incidentesatel7.ResponsableImplementacionVII1;
                incidentesmodel.FechaEjeMesVII1 = incidentesatel7.FechaEjeMesVII1;
                incidentesmodel.FechaEjeDiaVII1 = incidentesatel7.FechaEjeDiaVII1;
                incidentesmodel.MedidasPreventivasVII2 = incidentesatel7.MedidasPreventivasVII2;
                incidentesmodel.ResponsableImplementacionVII2 = incidentesatel7.ResponsableImplementacionVII2;
                incidentesmodel.FechaEjeMesVII3 = incidentesatel7.FechaEjeMesVII3;
                incidentesmodel.FechaEjeDiaVII3 = incidentesatel7.FechaEjeDiaVII3;
                incidentesmodel.MedidasPreventivasVII4 = incidentesatel7.MedidasPreventivasVII4;
                incidentesmodel.ResponsableImplementacionVII4 = incidentesatel7.ResponsableImplementacionVII4;
                incidentesmodel.FechaEjeMesVII4 = incidentesatel7.FechaEjeMesVII4;
                incidentesmodel.FechaEjeDiaVII4 = incidentesatel7.FechaEjeDiaVII4;
                incidentesmodel.MedidasPreventivasVII5 = incidentesatel7.MedidasPreventivasVII5;
                incidentesmodel.ResponsableImplementacionVII5 = incidentesatel7.ResponsableImplementacionVII5;
                incidentesmodel.FechaEjeMesVII5 = incidentesatel7.FechaEjeMesVII5;
                incidentesmodel.FechaEjeDiaVII5 = incidentesatel7.FechaEjeDiaVII5;
                incidentesmodel.MedidasPreventivasVII6 = incidentesatel7.MedidasPreventivasVII6;
                incidentesmodel.ResponsableImplementacionVII6 = incidentesatel7.ResponsableImplementacionVII6;
                incidentesmodel.FechaEjeMesVII6 = incidentesatel7.FechaEjeMesVII6;
                incidentesmodel.FechaEjeDiaVII6 = incidentesatel7.FechaEjeDiaVII6;
                incidentesmodel.MedidasPreventivasVII7 = incidentesatel7.MedidasPreventivasVII7;
                incidentesmodel.ResponsableImplementacionVII7 = incidentesatel7.ResponsableImplementacionVII7;
                incidentesmodel.FechaEjeMesVII7 = incidentesatel7.FechaEjeMesVII7;
                incidentesmodel.FechaEjeDiaVII7 = incidentesatel7.FechaEjeDiaVII7;
                incidentesmodel.MedidasPreventivasVII8 = incidentesatel7.MedidasPreventivasVII8;
                incidentesmodel.ResponsableImplementacionVII8 = incidentesatel7.ResponsableImplementacionVII8;
                incidentesmodel.FechaEjeMesVII8 = incidentesatel7.FechaEjeMesVII8;
                incidentesmodel.FechaEjeDiaVII8 = incidentesatel7.FechaEjeDiaVII8;
                incidentesmodel.MedidasPreventivasVII3 = incidentesatel7.MedidasPreventivasVII3;
                incidentesmodel.ResponsableImplementacionVII3 = incidentesatel7.ResponsableImplementacionVII3;
                incidentesmodel.FechaEjeMesVII2 = incidentesatel7.FechaEjeMesVII2;
                incidentesmodel.FechaEjeDiaVII2 = incidentesatel7.FechaEjeDiaVII2;
            }
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel8!=null)
            {
                incidentesmodel.tempTipoIdentificacionVIII1 = incidentesatel8.tempTipoIdentificacionVIII1;
                incidentesmodel.JefeInmediatoVIII1 = incidentesatel8.JefeInmediatoVIII1;
                incidentesmodel.CargoVIII1 = incidentesatel8.CargoVIII1;
                incidentesmodel.NumeroIdentificacionVIII1 = incidentesatel8.NumeroIdentificacionVIII1;
                incidentesmodel.tempTipoIdentificacionVIII2 = incidentesatel8.tempTipoIdentificacionVIII2;
                incidentesmodel.JefeInmediatoVIII2 = incidentesatel8.JefeInmediatoVIII2;
                incidentesmodel.CargoVIII2 = incidentesatel8.CargoVIII2;
                incidentesmodel.NumeroIdentificacionVIII2 = incidentesatel8.NumeroIdentificacionVIII2;
                incidentesmodel.tempTipoIdentificacionVIII3 = incidentesatel8.tempTipoIdentificacionVIII3;
                incidentesmodel.JefeInmediatoVIII3 = incidentesatel8.JefeInmediatoVIII3;
                incidentesmodel.CargoVIII3 = incidentesatel8.CargoVIII3;
                incidentesmodel.NumeroIdentificacionVIII3 = incidentesatel8.NumeroIdentificacionVIII3;
                incidentesmodel.tempTipoIdentificacionVIII4 = incidentesatel8.tempTipoIdentificacionVIII4;
                incidentesmodel.JefeInmediatoVIII4 = incidentesatel8.JefeInmediatoVIII4;
                incidentesmodel.CargoVIII4 = incidentesatel8.CargoVIII4;
                incidentesmodel.NumeroIdentificacionVIII4 = incidentesatel8.NumeroIdentificacionVIII4;
                incidentesmodel.tempTipoIdentificacionVIII5 = incidentesatel8.tempTipoIdentificacionVIII5;
                incidentesmodel.JefeInmediatoVIII5 = incidentesatel8.JefeInmediatoVIII5;
                incidentesmodel.CargoVIII5 = incidentesatel8.CargoVIII5;
                incidentesmodel.NumeroIdentificacionVIII5 = incidentesatel8.NumeroIdentificacionVIII5;
                incidentesmodel.tempTipoIdentificacionVIII6 = incidentesatel8.tempTipoIdentificacionVIII6;
                incidentesmodel.JefeInmediatoVIII6 = incidentesatel8.JefeInmediatoVIII6;
                incidentesmodel.CargoVIII6 = incidentesatel8.CargoVIII6;
                incidentesmodel.NumeroIdentificacionVIII6 = incidentesatel8.NumeroIdentificacionVIII6;
                incidentesmodel.tempTipoIdentificacionVIII7 = incidentesatel8.tempTipoIdentificacionVIII7;
                incidentesmodel.EspecialistaOcupacionalVIII = incidentesatel8.EspecialistaOcupacionalVIII;
                incidentesmodel.LicenciaNumVIII1 = incidentesatel8.LicenciaNumVIII1;
                incidentesmodel.LicenciaAnioVIII1 = incidentesatel8.LicenciaAnioVIII1;
                incidentesmodel.NumeroIdentificacionVIII7 = incidentesatel8.NumeroIdentificacionVIII7;
                incidentesmodel.tempTipoIdentificacionVIII8 = incidentesatel8.tempTipoIdentificacionVIII8;
                incidentesmodel.RepresentanteArlVIII8 = incidentesatel8.RepresentanteArlVIII8;
                incidentesmodel.LicenciaNumeroVIII8 = incidentesatel8.LicenciaNumeroVIII8;
                incidentesmodel.LicenciaAnioVIII8 = incidentesatel8.LicenciaAnioVIII8;
                incidentesmodel.NumeroIdentificacionVIII8 = incidentesatel8.NumeroIdentificacionVIII8;
                incidentesmodel.EmpresaRepresentaVIII8 = incidentesatel8.EmpresaRepresentaVIII8;
                incidentesmodel.NitVIII8 = incidentesatel8.NitVIII8;
                incidentesmodel.hmyFile2 = incidentesatel8.myFile2;
                incidentesmodel.hmyFile3 = incidentesatel8.myFile3;
                incidentesmodel.hmyFile4 = incidentesatel8.myFile4;
                incidentesmodel.hmyFile5 = incidentesatel8.myFile5;
                incidentesmodel.hmyFile6 = incidentesatel8.myFile6;
                incidentesmodel.hmyFile7 = incidentesatel8.myFile7;
                incidentesmodel.hmyFile8 = incidentesatel8.myFile8;
                incidentesmodel.hmyFile9 = incidentesatel8.myFile9;
                
            }
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel9!=null)
            {
                incidentesmodel.FechaRemisionIX = incidentesatel9.FechaRemisionIX;
                incidentesmodel.NoFoliosIX = incidentesatel9.NoFoliosIX;
                incidentesmodel.tempTipoIdentificacionIX = incidentesatel9.tempTipoIdentificacionIX;
                incidentesmodel.NombreApellidoIX = incidentesatel9.NombreApellidoIX;
                incidentesmodel.CargoIX = incidentesatel9.CargoIX;
                incidentesmodel.NumeroIdentificacionIX = incidentesatel9.NumeroIdentificacionIX;
                incidentesmodel.FechaRemisionARLIX = incidentesatel9.FechaRemisionARLIX;
                incidentesmodel.FecRemisionTerritorialIX = incidentesatel9.FecRemisionTerritorialIX;
                incidentesmodel.DisponibleRemisionARLIX = incidentesatel9.DisponibleRemisionARLIX;
                incidentesmodel.ResponsablesRemisionARLIX = incidentesatel9.ResponsablesRemisionARLIX;
                incidentesmodel.CargoARLIX = incidentesatel9.CargoARLIX;
                incidentesmodel.hmyFile10 = incidentesatel9.myFile10;
            }
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (incidentesatel10!=null)
            {
                incidentesmodel.tempTipoIdentificacionX = incidentesatel10.tempTipoIdentificacionX;
                incidentesmodel.ObservacionesX = incidentesatel10.ObservacionesX;
                incidentesmodel.ResponsableVerficiacionX = incidentesatel10.ResponsableVerficiacionX;
                incidentesmodel.CargoX = incidentesatel10.CargoX;
                incidentesmodel.NumeroIdentificacionX = incidentesatel10.NumeroIdentificacionX;
                incidentesmodel.MedidasIntervencionX = incidentesatel10.MedidasIntervencionX;
                incidentesmodel.ObsevacionesX = incidentesatel10.ObsevacionesX;
                incidentesmodel.FechaVerficacionX = incidentesatel10.FechaVerficacionX;
                incidentesmodel.tempTipoIdentificacionXI = incidentesatel10.tempTipoIdentificacionXI;
                incidentesmodel.ResponsableVerficiacionXI = incidentesatel10.ResponsableVerficiacionXI;
                incidentesmodel.CargoXI = incidentesatel10.CargoXI;
                incidentesmodel.NumeroIdentificacionXI = incidentesatel10.NumeroIdentificacionXI;
                incidentesmodel.MedidasIntervencionXI = incidentesatel10.MedidasIntervencionXI;
                incidentesmodel.ObsevacionesARLXI = incidentesatel10.ObsevacionesARLXI;
                incidentesmodel.FechaVerficacionXI = incidentesatel10.FechaVerficacionXI;
                incidentesmodel.hmyFile11 = incidentesatel10.myFile11;
                incidentesmodel.hmyFile12 = incidentesatel10.myFile12;
                
            }
           
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            return Json(incidentesmodel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ConsultarDatosTrabajador(string numeroDocumento)
        {
            EmpresaAfiliadoModel datos = null;

            try
            {
                if (!string.IsNullOrEmpty(numeroDocumento))
                {
                    var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                    var cliente = new RestSharp.RestClient(ConfigurationManager.AppSettings["Url"]);
                    var request = new RestRequest(consultaAfiliadoEmpresaActivo, RestSharp.Method.GET);
                    request.RequestFormat = DataFormat.Xml;
                    request.Parameters.Clear();
                    request.AddParameter("tpEm", "NI");
                    request.AddParameter("docEm", usuarioActual.NitEmpresa);
                    request.AddParameter("tpAfiliado", "CC");
                    request.AddParameter("docAfiliado", numeroDocumento);
                    request.AddHeader("Content-Type", "application/json");
                    request.AddHeader("Accept", "application/json");
                    //se omite la validación de certificado de SSL
                    ServicePointManager.ServerCertificateValidationCallback = delegate
                    { return true; };
                    IRestResponse<List<EmpresaAfiliadoModel>> response = cliente.Execute<List<EmpresaAfiliadoModel>>(request);
                    var result = response.Content;
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmpresaAfiliadoModel>>(result);

                        if (respuesta.Count == 0)
                        {
                            return Json(new { Data = "El documento ingresado, no pertenece a la empresa", Mensaje = "ERROR" });
                        }
                        else
                        {
                            var nitEmpresaU = "";
                            nitEmpresaU = respuesta[0].documentoEmp;
                            if (nitEmpresaU.Equals(usuarioActual.NitEmpresa))
                            {
                                datos = respuesta.First();
                            }
                            else
                            {
                                return Json(new { Data = "El documento ingresado, no pertenece a la empresa", Mensaje = "ERROR" });

                            }
                        }


                    }
                    if (datos != null)
                    {
                        return Json(new { Data = datos, Mensaje = "OK" });
                    }
                    else
                        return Json(new { Data = "No se encontró información, asociada al documento ingresado.", Mensaje = "NOTFOUND" });
                }

                if (numeroDocumento.Equals(""))
                {

                    return Json(new { Data = "Por favor ingrese un documento", Mensaje = "VACIO" }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                return Json(new { Data = "No se encontró información, asociada al documento ingresado", Mensaje = "ERROR" });
            }

            return Json(new { Data = datos, Mensaje = "ERROR" });
        }

        #region GUARDAR PARCIALES

        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 1
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL1(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL1.Where(x => x.PK_Incidentes_EL == frmIncidentesEL.PK_Incidentes_EL_Id1).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL1.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }


                string[] date = frmIncidentesEL.FechaInvestigacionI.Split('/');
                string fecpattern = date[0] + "-" + date[1] + "-" + date[2];
                DateTime FechaInvestigacionI = Convert.ToDateTime(fecpattern, System.Globalization.CultureInfo.GetCultureInfo("es-CO").DateTimeFormat);
                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL1 Incidentes_EL = new IncidentesEL1()
                {
                    EnfLabCalificadaI = frmIncidentesEL.EnfLabCalificadaI,
                    FechaInvestigacionI = FechaInvestigacionI,
                    HoraInicioI = frmIncidentesEL.HoraInicioI,
                    HoraFinI = frmIncidentesEL.HoraFinI,
                    DepartamentoI = frmIncidentesEL.pk_DepartamentoI.ToString(),
                    MunicipioI = frmIncidentesEL.pk_MunicipioI.ToString(),
                    DireccionI = frmIncidentesEL.DireccionI,
                    NombresApellidosI = frmIncidentesEL.NombresApellidosI,
                    ProfesionalI = frmIncidentesEL.ProfesionalI,
                    NoLicenciaI = frmIncidentesEL.NoLicenciaI,
                    FotografiasI = frmIncidentesEL.FotografiasI,
                    VideosI = frmIncidentesEL.VideosI,
                    CintasAudioI = frmIncidentesEL.CintasAudioI,
                    IlustracionesI = frmIncidentesEL.IlustracionesI,
                    DiagramasI = frmIncidentesEL.DiagramasI,
                    OtrosCualesI = frmIncidentesEL.OtrosCualesI,
                    myFile1 = frmIncidentesEL.hmyFile1,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL1.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 2
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL2(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL2.Where(x => x.FK_Incidentes_EL2 == frmIncidentesEL.PK_Incidentes_EL_Id2).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL2.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL2 Incidentes_EL = new IncidentesEL2()
                {
                    FK_Incidentes_EL2 = frmIncidentesEL.PK_Incidentes_EL_Id2,
                    DireccionCentroTrabajoII = frmIncidentesEL.DireccionCentroTrabajoII,
                    EmpleadorII = frmIncidentesEL.TempEmpleadorII,
                    CodActividadII = frmIncidentesEL.CodActividadII,
                    ActividadPrincipalII = frmIncidentesEL.ActividadPrincipalII,
                    RazonSocialII = frmIncidentesEL.RazonSocialII,
                    TipoIdentificacionII = frmIncidentesEL.TipoIdentificacionII,
                    NumIdentificacionII = frmIncidentesEL.NumIdentificacionII,
                    DireccionPrincipalII = frmIncidentesEL.DireccionPrincipalII,
                    TelefonoPpalII = frmIncidentesEL.TelefonoPpalII,
                    FaxII = frmIncidentesEL.FaxII,
                    DeptoPpalII = frmIncidentesEL.DeptoPpalII,
                    McpioPpalII = frmIncidentesEL.McpioPpalII,
                    EmailII = frmIncidentesEL.EmailII,
                    ZonaPpalII = frmIncidentesEL.ZonaPpalII,
                    CentroTrabajoPpalII = frmIncidentesEL.CentroTrabajoPpalII,
                    CentroCostoTelefonoII = frmIncidentesEL.CentroCostoTelefonoII,
                    CentroCostoFaxII = frmIncidentesEL.CentroCostoFaxII,
                    CodActEconoPpalII = frmIncidentesEL.CodActEconoPpalII,
                    ActEconoCentroTrabajoII = frmIncidentesEL.ActEconoCentroTrabajoII,
                    DeptoEmpleadorII = frmIncidentesEL.pk_DeptoEmpleadorII.ToString(),
                    McpioEmpleadorII = frmIncidentesEL.pk_McpioEmpleadorII.ToString(),
                    EmailEmpleadorII = frmIncidentesEL.EmailEmpleadorII,
                    ZonaEmpleadorII = frmIncidentesEL.ZonaEmpleadorII,
                    DeptoCentroTrabajoII = frmIncidentesEL.pk_DeptoCentroTrabajoII.ToString(),
                    McpioCentroTrabajoII = frmIncidentesEL.pk_McpioCentroTrabajoII.ToString(),
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL2.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL2;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 3
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL3(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id3 != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL3.Where(x => x.FK_Incidentes_EL3 == frmIncidentesEL.PK_Incidentes_EL_Id3).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL3.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL3 Incidentes_EL = new IncidentesEL3()
                {
                    FK_Incidentes_EL3 = frmIncidentesEL.PK_Incidentes_EL_Id3,
                    PlantaIII = frmIncidentesEL.PlantaIII,
                    MisionIII = frmIncidentesEL.MisionIII,
                    CooperadorIII = frmIncidentesEL.CooperadorIII,
                    EstudianteIII = frmIncidentesEL.EstudianteIII,
                    IndependienteIII = frmIncidentesEL.IndependienteIII,
                    TipoIdentificacionIII = frmIncidentesEL.TempTipoIdentificacionIII,
                    NumIdentificacionIII = frmIncidentesEL.NumIdentificacionIII,
                    PrimerApellidoIII = frmIncidentesEL.PrimerApellidoIII,
                    SegundoApellidoIII = frmIncidentesEL.SegundoApellidoIII,
                    PrimerNombreIII = frmIncidentesEL.PrimerNombreIII,
                    SegundoNombreIII = frmIncidentesEL.SegundoNombreIII,
                    FechaNacimientoIII = frmIncidentesEL.FechaNacimientoIII,
                    SexoIII = frmIncidentesEL.SexoIII,
                    EPSAfiliadoIII = frmIncidentesEL.EPSAfiliadoIII,
                    AFPAfiliadoIII = frmIncidentesEL.AFPAfiliadoIII,
                    ARLAfiliadoIII = frmIncidentesEL.ARLAfiliadoIII,
                    TelefonoIII = frmIncidentesEL.TelefonoIII,
                    FaxIII = frmIncidentesEL.FaxIII,
                    EmailTrabajadorIII = frmIncidentesEL.EmailTrabajadorIII,
                    DireccionTrabajadorIII = frmIncidentesEL.DireccionTrabajadorIII,
                    ZonaIII = frmIncidentesEL.ZonaIII,
                    CodigoDeptoTrabajadorIII = frmIncidentesEL.CodigoDeptoTrabajadorIII,
                    DeptoTrabajadorIII = frmIncidentesEL.DeptoTrabajadorIII,
                    CodigoMncpioTrabajadorIII = frmIncidentesEL.CodigoMncpioTrabajadorIII,
                    MncpioTrabajadorIII = frmIncidentesEL.MncpioTrabajadorIII,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL3.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL3;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 4
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL4(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id4 != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL4.Where(x => x.FK_Incidentes_EL4 == frmIncidentesEL.PK_Incidentes_EL_Id4).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL4.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL4 Incidentes_EL = new IncidentesEL4()
                {
                    FK_Incidentes_EL4 = frmIncidentesEL.PK_Incidentes_EL_Id4,
                    DiurnoIV = frmIncidentesEL.DiurnoIV,
                    NocturnoIV = frmIncidentesEL.NocturnoIV,
                    MixtoIV = frmIncidentesEL.MixtoIV,
                    TurnosIV = frmIncidentesEL.TurnosIV,
                    TiempoOcupacionAniosIV = frmIncidentesEL.TiempoOcupacionAniosIV,
                    TiempoOcupacionMesesIV = frmIncidentesEL.TiempoOcupacionMesesIV,
                    TareasCargo2IV = frmIncidentesEL.TareasCargo2IV,
                    CargoIV = frmIncidentesEL.CargoIV,
                    AntiguedadCargoAIV = frmIncidentesEL.AntiguedadCargoAIV,
                    AntiguedadCargoMIV = frmIncidentesEL.AntiguedadCargoMIV,
                    CodOcupacionIV = frmIncidentesEL.CodOcupacionIV,
                    FechaIngresoIV = frmIncidentesEL.FechaIngresoIV,
                    OcupacionHabitualIV = frmIncidentesEL.OcupacionHabitualIV,
                    MurioTrabajadorIV = frmIncidentesEL.MurioTrabajadorIV,
                    FechaMuerteIV = frmIncidentesEL.FechaMuerteIV,
                    AreaActualIV = frmIncidentesEL.AreaActualIV,
                    NombreCargoIV = frmIncidentesEL.NombreCargoIV,
                    AntiguedadCargoAnioIV = frmIncidentesEL.AntiguedadCargoAnioIV,
                    AntiguedadCargoMesesIV = frmIncidentesEL.AntiguedadCargoMesesIV,
                    CondicionesPuestoTrabajoIV = frmIncidentesEL.CondicionesPuestoTrabajoIV,
                    TareasCargo1IV = frmIncidentesEL.TareasCargo1IV,
                    DedicacionJL1IV = frmIncidentesEL.DedicacionJL1IV,
                    DedicacionJL11IV = frmIncidentesEL.DedicacionJL11IV,
                    DedicacionJL12IV = frmIncidentesEL.DedicacionJL12IV,
                    RelacionMuyProbable1IV = frmIncidentesEL.RelacionMuyProbable1IV,
                    RelacionProbable1IV = frmIncidentesEL.RelacionProbable1IV,
                    RelacionPocoProbable1IV = frmIncidentesEL.RelacionPocoProbable1IV,
                    DedicacionJL21IV = frmIncidentesEL.DedicacionJL21IV,
                    DedicacionJL22IV = frmIncidentesEL.DedicacionJL22IV,
                    DedicacionJL23IV = frmIncidentesEL.DedicacionJL23IV,
                    RelacionMuyProbable2IV = frmIncidentesEL.RelacionMuyProbable2IV,
                    RelacionProbable2IV = frmIncidentesEL.RelacionProbable2IV,
                    RelacionPocoProbable2IV = frmIncidentesEL.RelacionPocoProbable2IV,
                    TareasCargo3IV = frmIncidentesEL.TareasCargo3IV,
                    DedicacionJL31IV = frmIncidentesEL.DedicacionJL31IV,
                    DedicacionJL32IV = frmIncidentesEL.DedicacionJL32IV,
                    DedicacionJL33IV = frmIncidentesEL.DedicacionJL33IV,
                    RelacionMuyProbable3IV = frmIncidentesEL.RelacionMuyProbable3IV,
                    RelacionProbable3IV = frmIncidentesEL.RelacionProbable3IV,
                    RelacionPocoProbable3IV = frmIncidentesEL.RelacionPocoProbable3IV,
                    TareasCargo4IV = frmIncidentesEL.TareasCargo4IV,
                    DedicacionJL41IV = frmIncidentesEL.DedicacionJL41IV,
                    DedicacionJL42IV = frmIncidentesEL.DedicacionJL42IV,
                    DedicacionJL43IV = frmIncidentesEL.DedicacionJL43IV,
                    RelacionMuyProbable4IV = frmIncidentesEL.RelacionMuyProbable4IV,
                    RelacionProbable4IV = frmIncidentesEL.RelacionProbable4IV,
                    RelacionPocoProbable4IV = frmIncidentesEL.RelacionPocoProbable4IV,
                    PreventivasIV = frmIncidentesEL.PreventivasIV,
                    ImplementadasIV = frmIncidentesEL.ImplementadasIV,
                    NoHabitualesIV = frmIncidentesEL.NoHabitualesIV,
                    DescripcionIV = frmIncidentesEL.DescripcionIV,
                    CodigoCie1 = frmIncidentesEL.CodigoCie1,
                    CodigoCie2 = frmIncidentesEL.CodigoCie2,
                    CodigoCie3 = frmIncidentesEL.CodigoCie3,
                    CodigoCie4 = frmIncidentesEL.CodigoCie4,
                    CodigoCie5 = frmIncidentesEL.CodigoCie5,
                    DiagnosticoIV1 = frmIncidentesEL.DiagnosticoIV1,
                    DiagnosticoIV2 = frmIncidentesEL.DiagnosticoIV2,
                    DiagnosticoIV3 = frmIncidentesEL.DiagnosticoIV3,
                    DiagnosticoIV4 = frmIncidentesEL.DiagnosticoIV4,
                    FechaOrigenELIV = frmIncidentesEL.FechaOrigenELIV,
                    FormacionInformacionIV = frmIncidentesEL.FormacionInformacionIV,
                    ProteccionColectivaIV = frmIncidentesEL.ProteccionColectivaIV,
                    EPPIV = frmIncidentesEL.EPPIV,
                    DisenoPuestoTrabajoIV = frmIncidentesEL.DisenoPuestoTrabajoIV,
                    tempOrganizacionTrabajoIV = frmIncidentesEL.tempOrganizacionTrabajoIV,
                    DiurnoIV2 = frmIncidentesEL.DiurnoIV2,
                    NocturnoIV2 = frmIncidentesEL.NocturnoIV2,
                    MixtoIV2 = frmIncidentesEL.MixtoIV2,
                    TurnosIV2 = frmIncidentesEL.TurnosIV2,
                    ObservacionesIV = frmIncidentesEL.ObservacionesIV,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL4.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL4;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 5
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL5(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id5 != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL5.Where(x => x.FK_Incidentes_EL5 == frmIncidentesEL.PK_Incidentes_EL_Id5).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL5.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL5 Incidentes_EL = new IncidentesEL5()
                {
                    FK_Incidentes_EL5 = frmIncidentesEL.PK_Incidentes_EL_Id5,
                    NombresApellidosV5 = frmIncidentesEL.NombresApellidosV5,
                    OrigenLaboralV = frmIncidentesEL.OrigenLaboralIV,
                    NoTrabajadoresV = frmIncidentesEL.NoTrabajadoresV,
                    CargosSimilaresV = frmIncidentesEL.CargosSimilaresV,
                    NombresApellidosV2 = frmIncidentesEL.NombresApellidosV2,
                    NombresApellidosV3 = frmIncidentesEL.NombresApellidosV3,
                    NombresApellidosV4 = frmIncidentesEL.NombresApellidosV4,
                    AnioDiagnosticoV1 = frmIncidentesEL.AnioDiagnosticoV1,
                    AnioDiagnosticoV2 = frmIncidentesEL.AnioDiagnosticoV2,
                    AnioDiagnosticoV3 = frmIncidentesEL.AnioDiagnosticoV3,
                    AnioDiagnosticoV4 = frmIncidentesEL.AnioDiagnosticoV4,
                    NombresApellidosV1 = frmIncidentesEL.NombresApellidosV1,
                    NoTrabajadoresCargos = frmIncidentesEL.NoTrabajadoresCargos,
                    CodigoCieCIEV = frmIncidentesEL.CodigoCieCIEV,
                    DiagnosticosCIEV = frmIncidentesEL.DiagnosticosCIEV,
                    NitEmpresa = usuarioActual.NitEmpresa,
                    FechaOrigenELV = frmIncidentesEL.FechaOrigenELIV,
                    CodigoCie1 = frmIncidentesEL.CodigoCie1,
                    CodigoCie2 = frmIncidentesEL.CodigoCie2,
                    CodigoCie3 = frmIncidentesEL.CodigoCie3,
                    CodigoCie4 = frmIncidentesEL.CodigoCie4,
                    DiagnosticoIV1 = frmIncidentesEL.DiagnosticoIV1,
                    DiagnosticoIV2 = frmIncidentesEL.DiagnosticoIV2,
                    DiagnosticoIV3 = frmIncidentesEL.DiagnosticoIV3,
                    DiagnosticoIV4 = frmIncidentesEL.DiagnosticoIV4,
                    FechaOrigenELIV = frmIncidentesEL.FechaOrigenELIV,
                    OrigenLaboralIV = frmIncidentesEL.OrigenLaboralIV
                    
                };

                db.Tbl_IncidentesEL5.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL5;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 6
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL6(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL6.Where(x => x.FK_Incidentes_EL6 == frmIncidentesEL.PK_Incidentes_EL_Id6).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL6.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL6 Incidentes_EL = new IncidentesEL6()
                {
                    FK_Incidentes_EL6 = frmIncidentesEL.PK_Incidentes_EL_Id6,
                    PuestoEmpresaVI1 = frmIncidentesEL.PuestoEmpresaVI1,
                    AgentesBiologicosVI1 = frmIncidentesEL.AgentesBiologicosVI1,
                    FrasesVI1 = frmIncidentesEL.FrasesVI1,
                    RutinariaVI1 = frmIncidentesEL.RutinariaVI1,
                    NORutinariaVI1 = frmIncidentesEL.NORutinariaVI1,
                    TiempoExposicionMesesVI1 = frmIncidentesEL.TiempoExposicionMesesVI1,
                    TiempoExposicionHorasVI1 = frmIncidentesEL.TiempoExposicionHorasVI1,
                    TLVCorregidoVI1 = frmIncidentesEL.TLVCorregidoVI1,
                    ConcentracionHalladaVI1 = frmIncidentesEL.ConcentracionHalladaVI1,
                    FechaMediacionDiaV1 = frmIncidentesEL.FechaMediacionDiaV1,
                    FechaMediaMesV1 = frmIncidentesEL.FechaMediaMesV1,
                    FechaMediaAnioV1 = frmIncidentesEL.FechaMediaAnioV1,
                    NivelRiesgoV1 = frmIncidentesEL.NivelRiesgoV1,
                    ViaEntradaV1 = frmIncidentesEL.ViaEntradaV1,
                    PuestoEmpresaVI2 = frmIncidentesEL.PuestoEmpresaVI2,
                    AgentesBiologicosVI2 = frmIncidentesEL.AgentesBiologicosVI2,
                    FrasesVI2 = frmIncidentesEL.FrasesVI2,
                    RutinariaVI2 = frmIncidentesEL.RutinariaVI2,
                    NORutinariaVI2 = frmIncidentesEL.NORutinariaVI2,
                    TiempoExposicionMesesVI2 = frmIncidentesEL.TiempoExposicionMesesVI2,
                    TiempoExposicionHorasVI2 = frmIncidentesEL.TiempoExposicionHorasVI2,
                    TLVCorregidoVI2 = frmIncidentesEL.TLVCorregidoVI2,
                    ConcentracionHalladaVI2 = frmIncidentesEL.ConcentracionHalladaVI2,
                    FechaMediacionDiaV2 = frmIncidentesEL.FechaMediacionDiaV2,
                    FechaMediaMesV2 = frmIncidentesEL.FechaMediaMesV2,
                    FechaMediaAnioV2 = frmIncidentesEL.FechaMediaAnioV2,
                    NivelRiesgoV2 = frmIncidentesEL.NivelRiesgoV2,
                    ViaEntradaV2 = frmIncidentesEL.ViaEntradaV2,
                    PuestoEmpresaVI3 = frmIncidentesEL.PuestoEmpresaVI3,
                    AgentesBiologicosVI3 = frmIncidentesEL.AgentesBiologicosVI3,
                    FrasesVI3 = frmIncidentesEL.FrasesVI3,
                    RutinariaVI3 = frmIncidentesEL.RutinariaVI3,
                    NORutinariaVI3 = frmIncidentesEL.NORutinariaVI3,
                    TiempoExposicionMesesVI3 = frmIncidentesEL.TiempoExposicionMesesVI3,
                    TiempoExposicionHorasVI3 = frmIncidentesEL.TiempoExposicionHorasVI3,
                    TLVCorregidoVI3 = frmIncidentesEL.TLVCorregidoVI3,
                    ConcentracionHalladaVI3 = frmIncidentesEL.ConcentracionHalladaVI3,
                    FechaMediacionDiaV3 = frmIncidentesEL.FechaMediacionDiaV3,
                    FechaMediaMesV3 = frmIncidentesEL.FechaMediaMesV3,
                    FechaMediaAnioV3 = frmIncidentesEL.FechaMediaAnioV3,
                    NivelRiesgoV3 = frmIncidentesEL.NivelRiesgoV3,
                    ViaEntradaV3 = frmIncidentesEL.ViaEntradaV3,
                    PuestoEmpresaVI4 = frmIncidentesEL.PuestoEmpresaVI4,
                    AgentesBiologicosVI4 = frmIncidentesEL.AgentesBiologicosVI4,
                    FrasesVI4 = frmIncidentesEL.FrasesVI4,
                    RutinariaVI4 = frmIncidentesEL.RutinariaVI4,
                    NORutinariaVI4 = frmIncidentesEL.NORutinariaVI4,
                    TiempoExposicionMesesVI4 = frmIncidentesEL.TiempoExposicionMesesVI4,
                    TiempoExposicionHorasVI4 = frmIncidentesEL.TiempoExposicionHorasVI4,
                    TLVCorregidoVI4 = frmIncidentesEL.TLVCorregidoVI4,
                    ConcentracionHalladaVI4 = frmIncidentesEL.ConcentracionHalladaVI4,
                    FechaMediacionDiaVI4 = frmIncidentesEL.FechaMediacionDiaVI4,
                    FechaMediaMesVI4 = frmIncidentesEL.FechaMediaMesVI4,
                    FechaMediaAnioVI4 = frmIncidentesEL.FechaMediaAnioVI4,
                    NivelRiesgoVI4 = frmIncidentesEL.NivelRiesgoVI4,
                    ViaEntradaVI4 = frmIncidentesEL.ViaEntradaVI4,
                    OficioEmpresa2V1 = frmIncidentesEL.OficioEmpresa2V1,
                    AgenteRelBiologico2VI = frmIncidentesEL.AgenteRelBiologico2VI,
                    FuenteAgente2VI1 = frmIncidentesEL.FuenteAgente2VI1,
                    MecanismoTransmicion2VI1 = frmIncidentesEL.MecanismoTransmicion2VI1,
                    TipoActividadRutinaria2VI1 = frmIncidentesEL.TipoActividadRutinaria2VI1,
                    TipoActividadNoRutinaria2VI1 = frmIncidentesEL.TipoActividadNoRutinaria2VI1,
                    TiempoExposicionMeses2VI1 = frmIncidentesEL.TiempoExposicionMeses2VI1,
                    TiempoExposicionHoras2VI1 = frmIncidentesEL.TiempoExposicionHoras2VI1,
                    ConcentracionHallada2VI1 = frmIncidentesEL.ConcentracionHallada2VI1,
                    NivelRiesgo2VI1 = frmIncidentesEL.NivelRiesgo2VI1,
                    Dia2VI1 = frmIncidentesEL.Dia2VI1,
                    Mes2VI1 = frmIncidentesEL.Mes2VI1,
                    Anio2VI1 = frmIncidentesEL.Anio2VI1,
                    FrecRiesgo2VI1 = frmIncidentesEL.FrecRiesgo2VI1,
                    OficioEmpresa2V2 = frmIncidentesEL.OficioEmpresa2V2,
                    AgenteRelBiologico2VI2 = frmIncidentesEL.AgenteRelBiologico2VI2,
                    FuenteAgente2VI2 = frmIncidentesEL.FuenteAgente2VI2,
                    MecanismoTransmicion2VI2 = frmIncidentesEL.MecanismoTransmicion2VI2,
                    TipoActividadRutinaria2VI2 = frmIncidentesEL.TipoActividadRutinaria2VI2,
                    TipoActividadNoRutinaria2VI2 = frmIncidentesEL.TipoActividadNoRutinaria2VI2,
                    TiempoExposicionMeses2VI2 = frmIncidentesEL.TiempoExposicionMeses2VI2,
                    TiempoExposicionHoras2VI2 = frmIncidentesEL.TiempoExposicionHoras2VI2,
                    ConcentracionHallada2VI2 = frmIncidentesEL.ConcentracionHallada2VI2,
                    NivelRiesgo2VI2 = frmIncidentesEL.NivelRiesgo2VI2,
                    Dia2VI2 = frmIncidentesEL.Dia2VI2,
                    Mes2VI2 = frmIncidentesEL.Mes2VI2,
                    Anio2VI2 = frmIncidentesEL.Anio2VI2,
                    FrecRiesgo2VI2 = frmIncidentesEL.FrecRiesgo2VI2,
                    OficioEmpresa2V3 = frmIncidentesEL.OficioEmpresa2V3,
                    AgenteRelBiologico2VI3 = frmIncidentesEL.AgenteRelBiologico2VI3,
                    FuenteAgente2VI3 = frmIncidentesEL.FuenteAgente2VI3,
                    MecanismoTransmicion2VI3 = frmIncidentesEL.MecanismoTransmicion2VI3,
                    TipoActividadRutinaria2VI3 = frmIncidentesEL.TipoActividadRutinaria2VI3,
                    TipoActividadNoRutinaria2VI3 = frmIncidentesEL.TipoActividadNoRutinaria2VI3,
                    TiempoExposicionMeses2VI3 = frmIncidentesEL.TiempoExposicionMeses2VI3,
                    TiempoExposicionHoras2VI3 = frmIncidentesEL.TiempoExposicionHoras2VI3,
                    ConcentracionHallada2VI3 = frmIncidentesEL.ConcentracionHallada2VI3,
                    NivelRiesgo2VI3 = frmIncidentesEL.NivelRiesgo2VI3,
                    Dia2VI3 = frmIncidentesEL.Dia2VI3,
                    Mes2VI3 = frmIncidentesEL.Mes2VI3,
                    Anio2VI3 = frmIncidentesEL.Anio2VI3,
                    FrecRiesgo2VI3 = frmIncidentesEL.FrecRiesgo2VI3,
                    OficioEmpresa2V4 = frmIncidentesEL.OficioEmpresa2V4,
                    AgenteRelBiologico2VI4 = frmIncidentesEL.AgenteRelBiologico2VI4,
                    FuenteAgente2VI4 = frmIncidentesEL.FuenteAgente2VI4,
                    MecanismoTransmicion2VI4 = frmIncidentesEL.MecanismoTransmicion2VI4,
                    TipoActividadRutinaria2VI4 = frmIncidentesEL.TipoActividadRutinaria2VI4,
                    TipoActividadNoRutinaria2VI4 = frmIncidentesEL.TipoActividadNoRutinaria2VI4,
                    TiempoExposicionMeses2VI4 = frmIncidentesEL.TiempoExposicionMeses2VI4,
                    TiempoExposicionHoras2VI4 = frmIncidentesEL.TiempoExposicionHoras2VI4,
                    ConcentracionHallada2VI4 = frmIncidentesEL.ConcentracionHallada2VI4,
                    NivelRiesgo2VI4 = frmIncidentesEL.NivelRiesgo2VI4,
                    Dia2VI4 = frmIncidentesEL.Dia2VI4,
                    Mes2VI4 = frmIncidentesEL.Mes2VI4,
                    Anio2VI4 = frmIncidentesEL.Anio2VI4,
                    FrecRiesgo2VI4 = frmIncidentesEL.FrecRiesgo2VI4,
                    ExpoAccidentales2VI = frmIncidentesEL.ExpoAccidentales2VI,
                    CargoOficioPuesto3VI = frmIncidentesEL.CargoOficioPuesto3VI,
                    Fuentes3VI = frmIncidentesEL.Fuentes3VI,
                    Meses3VI = frmIncidentesEL.Meses3VI,
                    HorasDia3VI = frmIncidentesEL.HorasDia3VI,
                    NivelAmbiental3VI = frmIncidentesEL.NivelAmbiental3VI,
                    FMDia3VI = frmIncidentesEL.FMDia3VI,
                    FMMes3VI = frmIncidentesEL.FMMes3VI,
                    FMAnio3VI = frmIncidentesEL.FMAnio3VI,
                    DosisRuido3VI = frmIncidentesEL.DosisRuido3VI,
                    FecMedDia3VI = frmIncidentesEL.FecMedDia3VI,
                    FecMedMes3VI = frmIncidentesEL.FecMedMes3VI,
                    FecMEdAnio3VI = frmIncidentesEL.FecMEdAnio3VI,
                    ExpSusQuimimcas3VI = frmIncidentesEL.ExpSusQuimimcas3VI,
                    ExpoAccPrevias3VI = frmIncidentesEL.ExpoAccPrevias3VI,
                    CargoOficioPuesto3VI1 = frmIncidentesEL.CargoOficioPuesto3VI1,
                    Fuentes3VI1 = frmIncidentesEL.Fuentes3VI1,
                    Meses3VI1 = frmIncidentesEL.Meses3VI1,
                    HorasDia3VI1 = frmIncidentesEL.HorasDia3VI1,
                    NivelAmbiental3VI1 = frmIncidentesEL.NivelAmbiental3VI1,
                    FMDia3VI1 = frmIncidentesEL.FMDia3VI1,
                    FMMes3VI1 = frmIncidentesEL.FMMes3VI1,
                    FMAnio3VI1 = frmIncidentesEL.FMAnio3VI1,
                    DosisRuido3VI1 = frmIncidentesEL.DosisRuido3VI1,
                    FecMedDia3VI1 = frmIncidentesEL.FecMedDia3VI1,
                    FecMedMes3VI1 = frmIncidentesEL.FecMedMes3VI1,
                    FecMEdAnio3VI1 = frmIncidentesEL.FecMEdAnio3VI1,
                    ExpSusQuimimcas3VI1 = frmIncidentesEL.ExpSusQuimimcas3VI1,
                    ExpoAccPrevias3VI1 = frmIncidentesEL.ExpoAccPrevias3VI1,
                    CargoOficioPuesto3VI2 = frmIncidentesEL.CargoOficioPuesto3VI2,
                    Fuentes3VI2 = frmIncidentesEL.Fuentes3VI2,
                    Meses3VI2 = frmIncidentesEL.Meses3VI2,
                    HorasDia3VI2 = frmIncidentesEL.HorasDia3VI2,
                    NivelAmbiental3VI2 = frmIncidentesEL.NivelAmbiental3VI2,
                    FMDia3VI2 = frmIncidentesEL.FMDia3VI2,
                    FMMes3VI2 = frmIncidentesEL.FMMes3VI2,
                    FMAnio3VI2 = frmIncidentesEL.FMAnio3VI2,
                    DosisRuido3VI2 = frmIncidentesEL.DosisRuido3VI2,
                    FecMedDia3VI2 = frmIncidentesEL.FecMedDia3VI2,
                    FecMedMes3VI2 = frmIncidentesEL.FecMedMes3VI2,
                    FecMEdAnio3VI2 = frmIncidentesEL.FecMEdAnio3VI2,
                    ExpSusQuimimcas3VI2 = frmIncidentesEL.ExpSusQuimimcas3VI2,
                    ExpoAccPrevias3VI2 = frmIncidentesEL.ExpoAccPrevias3VI2,
                    CargoOficioPuesto3VI3 = frmIncidentesEL.CargoOficioPuesto3VI3,
                    Fuentes3VI3 = frmIncidentesEL.Fuentes3VI3,
                    Meses3VI3 = frmIncidentesEL.Meses3VI3,
                    HorasDia3VI3 = frmIncidentesEL.HorasDia3VI3,
                    NivelAmbiental3VI3 = frmIncidentesEL.NivelAmbiental3VI3,
                    FMDia3VI3 = frmIncidentesEL.FMDia3VI3,
                    FMMes3VI3 = frmIncidentesEL.FMMes3VI3,
                    FMAnio3VI3 = frmIncidentesEL.FMAnio3VI3,
                    DosisRuido3VI3 = frmIncidentesEL.DosisRuido3VI3,
                    FecMedDia3VI3 = frmIncidentesEL.FecMedDia3VI3,
                    FecMedMes3VI3 = frmIncidentesEL.FecMedMes3VI3,
                    FecMEdAnio3VI3 = frmIncidentesEL.FecMEdAnio3VI3,
                    ExpSusQuimimcas3VI3 = frmIncidentesEL.ExpSusQuimimcas3VI3,
                    ExpoAccPrevias3VI3 = frmIncidentesEL.ExpoAccPrevias3VI3,
                    CargoOficio4VI1 = frmIncidentesEL.CargoOficio4VI1,
                    DescActividad4VI1 = frmIncidentesEL.DescActividad4VI1,
                    Duracion4VI1 = frmIncidentesEL.Duracion4VI1,
                    FrecActividad4VI1 = frmIncidentesEL.FrecActividad4VI1,
                    TipoTrabajoActividad4VI1 = frmIncidentesEL.TipoTrabajoActividad4VI1,
                    WBTG4VI1 = frmIncidentesEL.WBTG4VI1,
                    TipoExpMeses4VI1 = frmIncidentesEL.TipoExpMeses4VI1,
                    TipoExpHD4VI1 = frmIncidentesEL.TipoExpHD4VI1,
                    TasaTrabajo4VI1 = frmIncidentesEL.TasaTrabajo4VI1,
                    FechaMedDia4VI1 = frmIncidentesEL.FechaMedDia4VI1,
                    FechaMedMes4VI1 = frmIncidentesEL.FechaMedMes4VI1,
                    FechaMedAnio4VI1 = frmIncidentesEL.FechaMedAnio4VI1,
                    CargoOficio4VI2 = frmIncidentesEL.CargoOficio4VI2,
                    DescActividad4VI2 = frmIncidentesEL.DescActividad4VI2,
                    Duracion4VI2 = frmIncidentesEL.Duracion4VI2,
                    FrecActividad4VI2 = frmIncidentesEL.FrecActividad4VI2,
                    TipoTrabajoActividad4VI2 = frmIncidentesEL.TipoTrabajoActividad4VI2,
                    WBTG4VI2 = frmIncidentesEL.WBTG4VI2,
                    TipoExpMeses4VI2 = frmIncidentesEL.TipoExpMeses4VI2,
                    TipoExpHD4VI2 = frmIncidentesEL.TipoExpHD4VI2,
                    TasaTrabajo4VI2 = frmIncidentesEL.TasaTrabajo4VI2,
                    FechaMedDia4VI2 = frmIncidentesEL.FechaMedDia4VI2,
                    FechaMedMes4VI2 = frmIncidentesEL.FechaMedMes4VI2,
                    FechaMedAnio4VI2 = frmIncidentesEL.FechaMedAnio4VI2,
                    CargoOficio4VI3 = frmIncidentesEL.CargoOficio4VI3,
                    DescActividad4VI3 = frmIncidentesEL.DescActividad4VI3,
                    Duracion4VI3 = frmIncidentesEL.Duracion4VI3,
                    FrecActividad4VI3 = frmIncidentesEL.FrecActividad4VI3,
                    TipoTrabajoActividad4VI3 = frmIncidentesEL.TipoTrabajoActividad4VI3,
                    WBTG4VI3 = frmIncidentesEL.WBTG4VI3,
                    TipoExpMeses4VI3 = frmIncidentesEL.TipoExpMeses4VI3,
                    TipoExpHD4VI3 = frmIncidentesEL.TipoExpHD4VI3,
                    TasaTrabajo4VI3 = frmIncidentesEL.TasaTrabajo4VI3,
                    FechaMedDia4VI3 = frmIncidentesEL.FechaMedDia4VI3,
                    FechaMedMes4VI3 = frmIncidentesEL.FechaMedMes4VI3,
                    FechaMedAnio4VI3 = frmIncidentesEL.FechaMedAnio4VI3,
                    CargoOficio4VI4 = frmIncidentesEL.CargoOficio4VI4,
                    DescActividad4VI4 = frmIncidentesEL.DescActividad4VI4,
                    Duracion4VI4 = frmIncidentesEL.Duracion4VI4,
                    FrecActividad4VI4 = frmIncidentesEL.FrecActividad4VI4,
                    TipoTrabajoActividad4VI4 = frmIncidentesEL.TipoTrabajoActividad4VI4,
                    WBTG4VI4 = frmIncidentesEL.WBTG4VI4,
                    TipoExpMeses4VI4 = frmIncidentesEL.TipoExpMeses4VI4,
                    TipoExpHD4VI4 = frmIncidentesEL.TipoExpHD4VI4,
                    TasaTrabajo4VI4 = frmIncidentesEL.TasaTrabajo4VI4,
                    FechaMedDia4VI4 = frmIncidentesEL.FechaMedDia4VI4,
                    FechaMedMes4VI4 = frmIncidentesEL.FechaMedMes4VI4,
                    FechaMedAnio4VI4 = frmIncidentesEL.FechaMedAnio4VI4,
                    NivelRiesgoVI1 = frmIncidentesEL.NivelRiesgoVI1,
                    ViaEntradaVI1 = frmIncidentesEL.ViaEntradaVI1,
                    NivelRiesgoV4 = frmIncidentesEL.NivelRiesgoV4,
                    ViaEntradaV4 = frmIncidentesEL.ViaEntradaV4,
                    BooEsfuerzoBrazosManos1 = frmIncidentesEL.BooEsfuerzoBrazosManos1,
                    BooCauRelPrevVI13 = frmIncidentesEL.BooCauRelPrevVI13,
                    CauRelPrevVI13 = frmIncidentesEL.CauRelPrevVI13,
                    BooCauRelPrevVI14 = frmIncidentesEL.BooCauRelPrevVI14,
                    CauRelPrevVI14 = frmIncidentesEL.CauRelPrevVI14,
                    BooCauRelPrevVI15 = frmIncidentesEL.BooCauRelPrevVI15,
                    CauRelPrevVI15 = frmIncidentesEL.CauRelPrevVI15,
                    RadCargoEmpresa5VI1 = frmIncidentesEL.RadCargoEmpresa5VI1,
                   RadDescripcionFuente5VI1 = frmIncidentesEL.RadDescripcionFuente5VI1,
                   RadDescripcionAct5VI1 = frmIncidentesEL.RadDescripcionAct5VI1,
                   RadCondiciones5VI1 = frmIncidentesEL.RadCondiciones5VI1,
                   RadTEDia5VI1 = frmIncidentesEL.RadTEDia5VI1,
                   RadTEMes5VI1 = frmIncidentesEL.RadTEMes5VI1,
                   RadTEAnio5VI1 = frmIncidentesEL.RadTEAnio5VI1,
                   RadEvalAmbiental5VI1 = frmIncidentesEL.RadEvalAmbiental5VI1,
                   RadFMDia5VI1 = frmIncidentesEL.RadFMDia5VI1,
                   RadFMMes5VI1 = frmIncidentesEL.RadFMMes5VI1,
                   RadFMAnio5VI1 = frmIncidentesEL.RadFMAnio5VI1,
                   RadCargoEmpresa5VI2 = frmIncidentesEL.RadCargoEmpresa5VI2,
                   RadDescripcionFuente5VI2 = frmIncidentesEL.RadDescripcionFuente5VI2,
                   RadDescripcionAct5VI2 = frmIncidentesEL.RadDescripcionAct5VI2,
                   RadCondiciones5VI2 = frmIncidentesEL.RadCondiciones5VI2,
                   RadTEDia5VI2 = frmIncidentesEL.RadTEDia5VI2,
                   RadTEMes5VI2 = frmIncidentesEL.RadTEMes5VI2,
                   RadTEAnio5VI2 = frmIncidentesEL.RadTEAnio5VI2,
                   RadEvalAmbiental5VI2 = frmIncidentesEL.RadEvalAmbiental5VI2,
                   RadFMDia5VI2 = frmIncidentesEL.RadFMDia5VI2,
                   RadFMMes5VI2 = frmIncidentesEL.RadFMMes5VI2,
                   RadFMAnio5VI2 = frmIncidentesEL.RadFMAnio5VI2,
                   RadCargoEmpresa5VI3 = frmIncidentesEL.RadCargoEmpresa5VI3,
                   RadDescripcionFuente5VI3 = frmIncidentesEL.RadDescripcionFuente5VI3,
                   RadDescripcionAct5VI3 = frmIncidentesEL.RadDescripcionAct5VI3,
                   RadCondiciones5VI3 = frmIncidentesEL.RadCondiciones5VI3,
                   RadTEDia5VI3 = frmIncidentesEL.RadTEDia5VI3,
                   RadTEMes5VI3 = frmIncidentesEL.RadTEMes5VI3,
                   RadTEAnio5VI3 = frmIncidentesEL.RadTEAnio5VI3,
                   RadEvalAmbiental5VI3 = frmIncidentesEL.RadEvalAmbiental5VI3,
                   RadFMDia5VI3 = frmIncidentesEL.RadFMDia5VI3,
                   RadFMMes5VI3 = frmIncidentesEL.RadFMMes5VI3,
                   RadFMAnio5VI3 = frmIncidentesEL.RadFMAnio5VI3,
                   RadCargoEmpresa5VI4 = frmIncidentesEL.RadCargoEmpresa5VI4,
                   RadDescripcionFuente5VI4 = frmIncidentesEL.RadDescripcionFuente5VI4,
                   RadDescripcionAct5VI4 = frmIncidentesEL.RadDescripcionAct5VI4,
                   RadCondiciones5VI4 = frmIncidentesEL.RadCondiciones5VI4,
                   RadTEDia5VI4 = frmIncidentesEL.RadTEDia5VI4,
                   RadTEMes5VI4 = frmIncidentesEL.RadTEMes5VI4,
                   RadTEAnio5V4 = frmIncidentesEL.RadTEAnio5V4,
                   RadEvalAmbiental5VI4 = frmIncidentesEL.RadEvalAmbiental5VI4,
                   RadFMDia5VI4 = frmIncidentesEL.RadFMDia5VI4,
                   RadFMMes5VI4 = frmIncidentesEL.RadFMMes5VI4,
                   RadFMAnio5VI4 = frmIncidentesEL.RadFMAnio5VI4,
                   VibCargoEmpresa6VI1 = frmIncidentesEL.VibCargoEmpresa6VI1,
                   VibDescFuente6VI1 = frmIncidentesEL.VibDescFuente6VI1,
                   BooTipoVibCE6VI1 = frmIncidentesEL.BooTipoVibCE6VI1,
                   BooTipoVibMB6VI1 = frmIncidentesEL.BooTipoVibMB6VI1,
                   TiempoExpMeses6VI1 = frmIncidentesEL.TiempoExpMeses6VI1,
                   TiempoExpHD6VI1 = frmIncidentesEL.TiempoExpHD6VI1,
                   VCE6VI1 = frmIncidentesEL.VCE6VI1,
                   VMB6VI1 = frmIncidentesEL.VMB6VI1,
                   AceTotal6VI1 = frmIncidentesEL.AceTotal6VI1,
                   EjeDominante6VI1 = frmIncidentesEL.EjeDominante6VI1,
                   AceEjeDominante6VI1 = frmIncidentesEL.AceEjeDominante6VI1,
                   Frecuencia6VI1 = frmIncidentesEL.Frecuencia6VI1,
                   Aceleracion6VI1 = frmIncidentesEL.Aceleracion6VI1,
                   FechaMedDia6VI1 = frmIncidentesEL.FechaMedDia6VI1,
                   FechaMedMes6VI1 = frmIncidentesEL.FechaMedMes6VI1,
                   FechaMedAnio6VI1 = frmIncidentesEL.FechaMedAnio6VI1,
                   BooExpoRuido6VI1 = frmIncidentesEL.BooExpoRuido6VI1,
                   VibCargoEmpresa6VI2 = frmIncidentesEL.VibCargoEmpresa6VI2,
                   VibDescFuente6VI2 = frmIncidentesEL.VibDescFuente6VI2,
                   BooTipoVibCE6VI2 = frmIncidentesEL.BooTipoVibCE6VI2,
                   BooTipoVibMB6VI2 = frmIncidentesEL.BooTipoVibMB6VI2,
                   TiempoExpMeses6VI2 = frmIncidentesEL.TiempoExpMeses6VI2,
                   TiempoExpHD6VI2 = frmIncidentesEL.TiempoExpHD6VI2,
                   VCE6VI2 = frmIncidentesEL.VCE6VI2,
                   VMB6VI2 = frmIncidentesEL.VMB6VI2,
                   AceTotal6VI2 = frmIncidentesEL.AceTotal6VI2,
                   EjeDominante6VI2 = frmIncidentesEL.EjeDominante6VI2,
                   AceEjeDominante6VI2 = frmIncidentesEL.AceEjeDominante6VI2,
                   Frecuencia6VI2 = frmIncidentesEL.Frecuencia6VI2,
                   Aceleracion6VI2 = frmIncidentesEL.Aceleracion6VI2,
                   FechaMedDia6VI2 = frmIncidentesEL.FechaMedDia6VI2,
                   FechaMedMes6VI2 = frmIncidentesEL.FechaMedMes6VI2,
                   FechaMedAnio6VI2 = frmIncidentesEL.FechaMedAnio6VI2,
                   BooExpoRuido6VI2 = frmIncidentesEL.BooExpoRuido6VI2,
                   VibCargoEmpresa6VI3 = frmIncidentesEL.VibCargoEmpresa6VI3,
                   VibDescFuente6VI3 = frmIncidentesEL.VibDescFuente6VI3,
                   BooTipoVibCE6VI3 = frmIncidentesEL.BooTipoVibCE6VI3,
                   BooTipoVibMB6VI3 = frmIncidentesEL.BooTipoVibMB6VI3,
                   TiempoExpMeses6VI3 = frmIncidentesEL.TiempoExpMeses6VI3,
                   TiempoExpHD6VI3 = frmIncidentesEL.TiempoExpHD6VI3,
                   VCE6VI3 = frmIncidentesEL.VCE6VI3,
                   VMB6VI3 = frmIncidentesEL.VMB6VI3,
                   AceTotal6VI3 = frmIncidentesEL.AceTotal6VI3,
                   EjeDominante6VI3 = frmIncidentesEL.EjeDominante6VI3,
                   AceEjeDominante6VI3 = frmIncidentesEL.AceEjeDominante6VI3,
                   Frecuencia6VI3 = frmIncidentesEL.Frecuencia6VI3,
                   Aceleracion6VI3 = frmIncidentesEL.Aceleracion6VI3,
                   FechaMedDia6VI3 = frmIncidentesEL.FechaMedDia6VI3,
                   FechaMedMes6VI3 = frmIncidentesEL.FechaMedMes6VI3,
                   FechaMedAnio6VI3 = frmIncidentesEL.FechaMedAnio6VI3,
                   BooExpoRuido6VI3 = frmIncidentesEL.BooExpoRuido6VI3,
                   VibCargoEmpresa6VI4 = frmIncidentesEL.VibCargoEmpresa6VI4,
                   VibDescFuente6VI4 = frmIncidentesEL.VibDescFuente6VI4,
                   BooTipoVibCE6VI4 = frmIncidentesEL.BooTipoVibCE6VI4,
                   BooTipoVibMB6VI4 = frmIncidentesEL.BooTipoVibMB6VI4,
                   TiempoExpMeses6VI4 = frmIncidentesEL.TiempoExpMeses6VI4,
                   TiempoExpHD6VI4 = frmIncidentesEL.TiempoExpHD6VI4,
                   VCE6VI4 = frmIncidentesEL.VCE6VI4,
                   VMB6VI4 = frmIncidentesEL.VMB6VI4,
                   AceTotal6VI4 = frmIncidentesEL.AceTotal6VI4,
                   EjeDominante6VI4 = frmIncidentesEL.EjeDominante6VI4,
                   AceEjeDominante6VI4 = frmIncidentesEL.AceEjeDominante6VI4,
                   Frecuencia6VI4 = frmIncidentesEL.Frecuencia6VI4,
                   Aceleracion6VI4 = frmIncidentesEL.Aceleracion6VI4,
                   FechaMedDia6VI4 = frmIncidentesEL.FechaMedDia6VI4,
                   FechaMedMes6VI4 = frmIncidentesEL.FechaMedMes6VI4,
                   FechaMedAnio6VI4 = frmIncidentesEL.FechaMedAnio6VI4,
                   BooExpoRuido6VI4 = frmIncidentesEL.BooExpoRuido6VI4,
                   VibCargoEmpresa6VI5 = frmIncidentesEL.VibCargoEmpresa6VI5,
                   VibDescFuente6VI5 = frmIncidentesEL.VibDescFuente6VI5,
                   BooTipoVibCE6VI5 = frmIncidentesEL.BooTipoVibCE6VI5,
                   BooTipoVibMB6VI5 = frmIncidentesEL.BooTipoVibMB6VI5,
                   TiempoExpMeses6VI5 = frmIncidentesEL.TiempoExpMeses6VI5,
                   TiempoExpHD6VI5 = frmIncidentesEL.TiempoExpHD6VI5,
                   VCE6VI5 = frmIncidentesEL.VCE6VI5,
                   VMB6VI5 = frmIncidentesEL.VMB6VI5,
                   AceTotal6VI5 = frmIncidentesEL.AceTotal6VI5,
                   EjeDominante6VI5 = frmIncidentesEL.EjeDominante6VI5,
                   AceEjeDominante6VI5 = frmIncidentesEL.AceEjeDominante6VI5,
                   Frecuencia6VI5 = frmIncidentesEL.Frecuencia6VI5,
                   Aceleracion6VI5 = frmIncidentesEL.Aceleracion6VI5,
                   FechaMedDia6VI5 = frmIncidentesEL.FechaMedDia6VI5,
                   FechaMedMes6VI5 = frmIncidentesEL.FechaMedMes6VI5,
                   FechaMedAnio6VI5 = frmIncidentesEL.FechaMedAnio6VI5,
                   BooExpoRuido6VI5 = frmIncidentesEL.BooExpoRuido6VI5,
                   VibCargoEmpresa6VI6 = frmIncidentesEL.VibCargoEmpresa6VI6,
                   VibDescFuente6VI6 = frmIncidentesEL.VibDescFuente6VI6,
                   BooTipoVibCE6VI6 = frmIncidentesEL.BooTipoVibCE6VI6,
                   BooTipoVibMB6VI6 = frmIncidentesEL.BooTipoVibMB6VI6,
                   TiempoExpMeses6VI6 = frmIncidentesEL.TiempoExpMeses6VI6,
                   TiempoExpHD6VI6 = frmIncidentesEL.TiempoExpHD6VI6,
                   VCE6VI6 = frmIncidentesEL.VCE6VI6,
                   VMB6VI6 = frmIncidentesEL.VMB6VI6,
                   AceTotal6VI6 = frmIncidentesEL.AceTotal6VI6,
                   EjeDominante6VI6 = frmIncidentesEL.EjeDominante6VI6,
                   AceEjeDominante6VI6 = frmIncidentesEL.AceEjeDominante6VI6,
                   Frecuencia6VI6 = frmIncidentesEL.Frecuencia6VI6,
                   Aceleracion6VI6 = frmIncidentesEL.Aceleracion6VI6,
                   FechaMedDia6VI6 = frmIncidentesEL.FechaMedDia6VI6,
                   FechaMedMes6VI6 = frmIncidentesEL.FechaMedMes6VI6,
                   FechaMedAnio6VI6 = frmIncidentesEL.FechaMedAnio6VI6,
                   BooExpoRuido6VI6 = frmIncidentesEL.BooExpoRuido6VI6,
                   DescEventoInv6VI = frmIncidentesEL.DescEventoInv6VI,
                   FrecPresAltoVI1 = frmIncidentesEL.FrecPresAltoVI1,
                   FrecPresMedioVI1 = frmIncidentesEL.FrecPresMedioVI1,
                   FrecPresBajoVI1 = frmIncidentesEL.FrecPresBajoVI1,
                   TiempoExpAltoVI1 = frmIncidentesEL.TiempoExpAltoVI1,
                   TiempoExpMedioVI1 = frmIncidentesEL.TiempoExpMedioVI1,
                   TiempoExpBajoVI1 = frmIncidentesEL.TiempoExpBajoVI1,
                   IntensidadAltoVI1 = frmIncidentesEL.IntensidadAltoVI1,
                   IntensidadMedioVI1 = frmIncidentesEL.IntensidadMedioVI1,
                   IntensidadBajoVI1 = frmIncidentesEL.IntensidadBajoVI1,
                   VarPsicoObservacionesVI1 = frmIncidentesEL.VarPsicoObservacionesVI1,
                   FrecPresAltoVI2 = frmIncidentesEL.FrecPresAltoVI2,
                   FrecPresMedioVI2 = frmIncidentesEL.FrecPresMedioVI2,
                   FrecPresBajoVI2 = frmIncidentesEL.FrecPresBajoVI2,
                   TiempoExpAltoVI2 = frmIncidentesEL.TiempoExpAltoVI2,
                   TiempoExpMedioVI2 = frmIncidentesEL.TiempoExpMedioVI2,
                   TiempoExpBajoVI2 = frmIncidentesEL.TiempoExpBajoVI2,
                   IntensidadAltoVI2 = frmIncidentesEL.IntensidadAltoVI2,
                   IntensidadMedioVI2 = frmIncidentesEL.IntensidadMedioVI2,
                   IntensidadBajoVI2 = frmIncidentesEL.IntensidadBajoVI2,
                   VarPsicoObservacionesVI2 = frmIncidentesEL.VarPsicoObservacionesVI2,
                   FrecPresAltoVI3 = frmIncidentesEL.FrecPresAltoVI3,
                   FrecPresMedioVI3 = frmIncidentesEL.FrecPresMedioVI3,
                   FrecPresBajoVI3 = frmIncidentesEL.FrecPresBajoVI3,
                   TiempoExpAltoVI3 = frmIncidentesEL.TiempoExpAltoVI3,
                   TiempoExpMedioVI3 = frmIncidentesEL.TiempoExpMedioVI3,
                   TiempoExpBajoVI3 = frmIncidentesEL.TiempoExpBajoVI3,
                   IntensidadAltoVI3 = frmIncidentesEL.IntensidadAltoVI3,
                   IntensidadMedioVI3 = frmIncidentesEL.IntensidadMedioVI3,
                   IntensidadBajoVI3 = frmIncidentesEL.IntensidadBajoVI3,
                   VarPsicoObservacionesVI3 = frmIncidentesEL.VarPsicoObservacionesVI3,
                   FrecPresAltoVI4 = frmIncidentesEL.FrecPresAltoVI4,
                   FrecPresMedioVI4 = frmIncidentesEL.FrecPresMedioVI4,
                   FrecPresBajoVI4 = frmIncidentesEL.FrecPresBajoVI4,
                   TiempoExpAltoVI4 = frmIncidentesEL.TiempoExpAltoVI4,
                   TiempoExpMedioVI4 = frmIncidentesEL.TiempoExpMedioVI4,
                   TiempoExpBajoV4 = frmIncidentesEL.TiempoExpBajoV4,
                   IntensidadAltoVI4 = frmIncidentesEL.IntensidadAltoVI4,
                   IntensidadMedioVI4 = frmIncidentesEL.IntensidadMedioVI4,
                   IntensidadBajoVI4 = frmIncidentesEL.IntensidadBajoVI4,
                   VarPsicoObservacionesVI4 = frmIncidentesEL.VarPsicoObservacionesVI4,
                   IntensidadAltaVI1 = frmIncidentesEL.IntensidadAltaVI1,
                   IntensidadMediaVI1 = frmIncidentesEL.IntensidadMediaVI1,
                   IntensidadBajaVI1 = frmIncidentesEL.IntensidadBajaVI1,
                   IntensidadObservVI1 = frmIncidentesEL.IntensidadObservVI1,
                   IntensidadAltaVI2 = frmIncidentesEL.IntensidadAltaVI2,
                   IntensidadMediaVI2 = frmIncidentesEL.IntensidadMediaVI2,
                   IntensidadBajaVI2 = frmIncidentesEL.IntensidadBajaVI2,
                   IntensidadObservVI2 = frmIncidentesEL.IntensidadObservVI2,
                   NivelRiesgoLabVI = frmIncidentesEL.NivelRiesgoLabVI,
                   NivelRiesgoExtralabVI = frmIncidentesEL.NivelRiesgoExtralabVI,
                   NivelRiesgoIndiviVI = frmIncidentesEL.NivelRiesgoIndiviVI,
                   NivelEstresVI = frmIncidentesEL.NivelEstresVI,
                   BooPostPieProlongada = frmIncidentesEL.BooPostPieProlongada,
                   BooPostPieSedente = frmIncidentesEL.BooPostPieSedente,
                   BooPosturaIncomodaBrazosManos = frmIncidentesEL.BooPosturaIncomodaBrazosManos,
                   BooEsfuerzoBrazosManos = frmIncidentesEL.BooEsfuerzoBrazosManos,
                   BooPosturaIncomodaEspalda = frmIncidentesEL.BooPosturaIncomodaEspalda,
                   BooLabRepetitivaColumna = frmIncidentesEL.BooLabRepetitivaColumna,
                   BooLabRepetitivaBrazoMuMano = frmIncidentesEL.BooLabRepetitivaBrazoMuMano,
                   BooPeriodoRecuperacionFisica = frmIncidentesEL.BooPeriodoRecuperacionFisica,
                   BooEsfuerzoManos = frmIncidentesEL.BooEsfuerzoManos,
                   BooEsfuerzoCuerpo = frmIncidentesEL.BooEsfuerzoCuerpo,
                   BooManipulacionCargas = frmIncidentesEL.BooManipulacionCargas,
                   DMEResumen = frmIncidentesEL.DMEResumen,
                   BooCauRelPrevVI1 = frmIncidentesEL.BooCauRelPrevVI1,
                   CauRelPrevVI1 = frmIncidentesEL.CauRelPrevVI1,
                   BooCauRelPrevVI2 = frmIncidentesEL.BooCauRelPrevVI2,
                   CauRelPrevVI2 = frmIncidentesEL.CauRelPrevVI2,
                   BooCauRelPrevVI3 = frmIncidentesEL.BooCauRelPrevVI3,
                   CauRelPrevVI3 = frmIncidentesEL.CauRelPrevVI3,
                   BooCauRelPrevVI4 = frmIncidentesEL.BooCauRelPrevVI4,
                   CauRelPrevVI4 = frmIncidentesEL.CauRelPrevVI4,
                   BooCauRelPrevVI5 = frmIncidentesEL.BooCauRelPrevVI5,
                   CauRelPrevVI5 = frmIncidentesEL.CauRelPrevVI5,
                   BooCauRelPrevVI6 = frmIncidentesEL.BooCauRelPrevVI6,
                   CauRelPrevVI6 = frmIncidentesEL.CauRelPrevVI6,
                   BooCauRelPrevVI7 = frmIncidentesEL.BooCauRelPrevVI7,
                   CauRelPrevVI7 = frmIncidentesEL.CauRelPrevVI7,
                   BooCauRelPrevVI8 = frmIncidentesEL.BooCauRelPrevVI8,
                   CauRelPrevVI8 = frmIncidentesEL.CauRelPrevVI8,
                   BooCauRelPrevVI9 = frmIncidentesEL.BooCauRelPrevVI9,
                   CauRelPrevVI9 = frmIncidentesEL.CauRelPrevVI9,
                   BooCauRelPrevVI10 = frmIncidentesEL.BooCauRelPrevVI10,
                   CauRelPrevVI10 = frmIncidentesEL.CauRelPrevVI10,
                   BooCauRelPrevVI11 = frmIncidentesEL.BooCauRelPrevVI11,
                   CauRelPrevVI11 = frmIncidentesEL.CauRelPrevVI11,
                   BooCauRelPrevVI12 = frmIncidentesEL.BooCauRelPrevVI12,
                   CauRelPrevVI12 = frmIncidentesEL.CauRelPrevVI12,
                   OtrosDatosInteresVI = frmIncidentesEL.OtrosDatosInteresVI,
                   CausasEnfermedadLaboralVI = frmIncidentesEL.CausasEnfermedadLaboralVI,
                   NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL6.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL6;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 7
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL7(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL7.Where(x => x.FK_Incidentes_EL7 == frmIncidentesEL.PK_Incidentes_EL_Id7).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL7.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL7 Incidentes_EL = new IncidentesEL7()
                {
                   FK_Incidentes_EL7 = frmIncidentesEL.PK_Incidentes_EL_Id7,
                   MedidasPreventivasVII1 = frmIncidentesEL.MedidasPreventivasVII1,
                   ResponsableImplementacionVII1 = frmIncidentesEL.ResponsableImplementacionVII1,
                   FechaEjeMesVII1 = frmIncidentesEL.FechaEjeMesVII1,
                   FechaEjeDiaVII1 = frmIncidentesEL.FechaEjeDiaVII1,
                   MedidasPreventivasVII2 = frmIncidentesEL.MedidasPreventivasVII2,
                   ResponsableImplementacionVII2 = frmIncidentesEL.ResponsableImplementacionVII2,
                   FechaEjeMesVII3 = frmIncidentesEL.FechaEjeMesVII3,
                   FechaEjeDiaVII3 = frmIncidentesEL.FechaEjeDiaVII3,
                   MedidasPreventivasVII4 = frmIncidentesEL.MedidasPreventivasVII4,
                   ResponsableImplementacionVII4 = frmIncidentesEL.ResponsableImplementacionVII4,
                   FechaEjeMesVII4 = frmIncidentesEL.FechaEjeMesVII4,
                   FechaEjeDiaVII4 = frmIncidentesEL.FechaEjeDiaVII4,
                   MedidasPreventivasVII5 = frmIncidentesEL.MedidasPreventivasVII5,
                   ResponsableImplementacionVII5 = frmIncidentesEL.ResponsableImplementacionVII5,
                   FechaEjeMesVII5 = frmIncidentesEL.FechaEjeMesVII5,
                   FechaEjeDiaVII5 = frmIncidentesEL.FechaEjeDiaVII5,
                   MedidasPreventivasVII6 = frmIncidentesEL.MedidasPreventivasVII6,
                   ResponsableImplementacionVII6 = frmIncidentesEL.ResponsableImplementacionVII6,
                   FechaEjeMesVII6 = frmIncidentesEL.FechaEjeMesVII6,
                   FechaEjeDiaVII6 = frmIncidentesEL.FechaEjeDiaVII6,
                   MedidasPreventivasVII7 = frmIncidentesEL.MedidasPreventivasVII7,
                   ResponsableImplementacionVII7 = frmIncidentesEL.ResponsableImplementacionVII7,
                   FechaEjeMesVII7 = frmIncidentesEL.FechaEjeMesVII7,
                   FechaEjeDiaVII7 = frmIncidentesEL.FechaEjeDiaVII7,
                   MedidasPreventivasVII8 = frmIncidentesEL.MedidasPreventivasVII8,
                   ResponsableImplementacionVII8 = frmIncidentesEL.ResponsableImplementacionVII8,
                   FechaEjeMesVII8 = frmIncidentesEL.FechaEjeMesVII8,
                   FechaEjeDiaVII8 = frmIncidentesEL.FechaEjeDiaVII8,
                   MedidasPreventivasVII3 = frmIncidentesEL.MedidasPreventivasVII3,
                   ResponsableImplementacionVII3 = frmIncidentesEL.ResponsableImplementacionVII3,
                   FechaEjeMesVII2 = frmIncidentesEL.FechaEjeMesVII2,
                   FechaEjeDiaVII2 = frmIncidentesEL.FechaEjeDiaVII2,
                   NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL7.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL7;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 8
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL8(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL8.Where(x => x.FK_Incidentes_EL8 == frmIncidentesEL.PK_Incidentes_EL_Id8).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL8.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL8 Incidentes_EL = new IncidentesEL8()
                {
                   FK_Incidentes_EL8 = frmIncidentesEL.PK_Incidentes_EL_Id8,
                   tempTipoIdentificacionVIII1 = frmIncidentesEL.tempTipoIdentificacionVIII1,
                   JefeInmediatoVIII1 = frmIncidentesEL.JefeInmediatoVIII1,
                   CargoVIII1 = frmIncidentesEL.CargoVIII1,
                   NumeroIdentificacionVIII1 = frmIncidentesEL.NumeroIdentificacionVIII1,
                   tempTipoIdentificacionVIII2 = frmIncidentesEL.tempTipoIdentificacionVIII2,
                   JefeInmediatoVIII2 = frmIncidentesEL.JefeInmediatoVIII2,
                   CargoVIII2 = frmIncidentesEL.CargoVIII2,
                   NumeroIdentificacionVIII2 = frmIncidentesEL.NumeroIdentificacionVIII2,
                   tempTipoIdentificacionVIII3 = frmIncidentesEL.tempTipoIdentificacionVIII3,
                   JefeInmediatoVIII3 = frmIncidentesEL.JefeInmediatoVIII3,
                   CargoVIII3 = frmIncidentesEL.CargoVIII3,
                   NumeroIdentificacionVIII3 = frmIncidentesEL.NumeroIdentificacionVIII3,
                   tempTipoIdentificacionVIII4 = frmIncidentesEL.tempTipoIdentificacionVIII4,
                   JefeInmediatoVIII4 = frmIncidentesEL.JefeInmediatoVIII4,
                   CargoVIII4 = frmIncidentesEL.CargoVIII4,
                   NumeroIdentificacionVIII4 = frmIncidentesEL.NumeroIdentificacionVIII4,
                   tempTipoIdentificacionVIII5 = frmIncidentesEL.tempTipoIdentificacionVIII5,
                   JefeInmediatoVIII5 = frmIncidentesEL.JefeInmediatoVIII5,
                   CargoVIII5 = frmIncidentesEL.CargoVIII5,
                   NumeroIdentificacionVIII5 = frmIncidentesEL.NumeroIdentificacionVIII5,
                   tempTipoIdentificacionVIII6 = frmIncidentesEL.tempTipoIdentificacionVIII6,
                   JefeInmediatoVIII6 = frmIncidentesEL.JefeInmediatoVIII6,
                   CargoVIII6 = frmIncidentesEL.CargoVIII6,
                   NumeroIdentificacionVIII6 = frmIncidentesEL.NumeroIdentificacionVIII6,
                   tempTipoIdentificacionVIII7 = frmIncidentesEL.tempTipoIdentificacionVIII7,
                   EspecialistaOcupacionalVIII = frmIncidentesEL.EspecialistaOcupacionalVIII,
                   LicenciaNumVIII1 = frmIncidentesEL.LicenciaNumVIII1,
                   LicenciaAnioVIII1 = frmIncidentesEL.LicenciaAnioVIII1,
                   NumeroIdentificacionVIII7 = frmIncidentesEL.NumeroIdentificacionVIII7,
                   tempTipoIdentificacionVIII8 = frmIncidentesEL.tempTipoIdentificacionVIII8,
                   RepresentanteArlVIII8 = frmIncidentesEL.RepresentanteArlVIII8,
                   LicenciaNumeroVIII8 = frmIncidentesEL.LicenciaNumeroVIII8,
                   LicenciaAnioVIII8 = frmIncidentesEL.LicenciaAnioVIII8,
                   NumeroIdentificacionVIII8 = frmIncidentesEL.NumeroIdentificacionVIII8,
                   EmpresaRepresentaVIII8 = frmIncidentesEL.EmpresaRepresentaVIII8,
                   NitVIII8 = frmIncidentesEL.NitVIII8,
                   myFile2 = frmIncidentesEL.hmyFile2,
                   myFile3 = frmIncidentesEL.hmyFile3,
                   myFile4 = frmIncidentesEL.hmyFile4,
                   myFile5 = frmIncidentesEL.hmyFile5,
                   myFile6 = frmIncidentesEL.hmyFile6,
                   myFile7 = frmIncidentesEL.hmyFile7,
                   myFile8 = frmIncidentesEL.hmyFile8,
                   myFile9 = frmIncidentesEL.hmyFile9,
                   NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL8.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL8;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 9
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL9(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL9.Where(x => x.FK_Incidentes_EL9 == frmIncidentesEL.PK_Incidentes_EL_Id9).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL9.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL9 Incidentes_EL = new IncidentesEL9()
                {
                   FK_Incidentes_EL9 = frmIncidentesEL.PK_Incidentes_EL_Id9,
                   FechaRemisionIX = frmIncidentesEL.FechaRemisionIX,
                   NoFoliosIX = frmIncidentesEL.NoFoliosIX,
                   tempTipoIdentificacionIX = frmIncidentesEL.tempTipoIdentificacionIX,
                   NombreApellidoIX = frmIncidentesEL.NombreApellidoIX,
                   CargoIX = frmIncidentesEL.CargoIX,
                   NumeroIdentificacionIX = frmIncidentesEL.NumeroIdentificacionIX,
                   FechaRemisionARLIX = frmIncidentesEL.FechaRemisionARLIX,
                   FecRemisionTerritorialIX = frmIncidentesEL.FecRemisionTerritorialIX,
                   DisponibleRemisionARLIX = frmIncidentesEL.DisponibleRemisionARLIX,
                   ResponsablesRemisionARLIX = frmIncidentesEL.ResponsablesRemisionARLIX,
                   CargoARLIX = frmIncidentesEL.CargoARLIX,
                   myFile10 = frmIncidentesEL.hmyFile10,
                   NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL9.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL9;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// PARAMETROS DEL FORMULARIO GUARDADO PARCIAL 10
        /// </summary>
        /// <param name="frmIncidentesEL"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteEL10(IncidentesELModel frmIncidentesEL)
        {
            int PK_frmIncidentesEL_Id = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {

                if (frmIncidentesEL.PK_Incidentes_EL_Id != 0)
                {
                    var incidente_del = db.Tbl_IncidentesEL10.Where(x => x.FK_Incidentes_EL10 == frmIncidentesEL.PK_Incidentes_EL_Id10).SingleOrDefault();
                    if (incidente_del != null)
                    {
                        db.Tbl_IncidentesEL10.Remove(incidente_del);
                        db.SaveChanges();
                    }
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesEL10 Incidentes_EL = new IncidentesEL10()
                {
                   FK_Incidentes_EL10 = frmIncidentesEL.PK_Incidentes_EL_Id10,
                   tempTipoIdentificacionX = frmIncidentesEL.tempTipoIdentificacionX,
                   ResponsableVerficiacionX = frmIncidentesEL.ResponsableVerficiacionX,
                   CargoX = frmIncidentesEL.CargoX,
                   NumeroIdentificacionX = frmIncidentesEL.NumeroIdentificacionX,
                   MedidasIntervencionX = frmIncidentesEL.MedidasIntervencionX,
                   ObsevacionesX = frmIncidentesEL.ObsevacionesX,
                   FechaVerficacionX = frmIncidentesEL.FechaVerficacionX,
                   tempTipoIdentificacionXI = frmIncidentesEL.tempTipoIdentificacionXI,
                   ResponsableVerficiacionXI = frmIncidentesEL.ResponsableVerficiacionXI,
                   CargoXI = frmIncidentesEL.CargoXI,
                   NumeroIdentificacionXI = frmIncidentesEL.NumeroIdentificacionXI,
                   MedidasIntervencionXI = frmIncidentesEL.MedidasIntervencionXI,
                   ObsevacionesARLXI = frmIncidentesEL.ObsevacionesARLXI,
                   FechaVerficacionXI = frmIncidentesEL.FechaVerficacionXI,
                   ObservacionesX = frmIncidentesEL.ObservacionesX,
                   myFile11 = frmIncidentesEL.hmyFile11,
                   myFile12 = frmIncidentesEL.hmyFile12,
                   NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesEL10.Add(Incidentes_EL);
                db.SaveChanges();
                Transaction.Commit();
                PK_frmIncidentesEL_Id = Incidentes_EL.PK_Incidentes_EL10;
            }

            return Json(PK_frmIncidentesEL_Id, JsonRequestBehavior.AllowGet);
        }

        #endregion


        [HttpPost]
        public JsonResult GetCIE10(string Codigo_CIE)
        {
            Diagnostico objDiagnostico = db.Tbl_Diagnosticos.Where(x => x.Codigo_CIE == Codigo_CIE).SingleOrDefault();
            if (objDiagnostico != null)
                return Json(objDiagnostico.Descripcion, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);

        }

        private List<SelectListItem> GetYears()
        {
            List<SelectListItem> vigencias = new List<SelectListItem>();
            for (int i = 1950; i <= 2050; i++)
            {
                vigencias.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            return vigencias;
        }

        private List<SelectListItem> GetMonths()
        {
            List<SelectListItem> vigencias = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                vigencias.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            return vigencias;
        }

        private List<SelectListItem> GetDays()
        {
            List<SelectListItem> vigencias = new List<SelectListItem>();
            for (int i = 1; i <= 31; i++)
            {
                vigencias.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            return vigencias;
        }
    }
}
