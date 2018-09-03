using RestSharp;
using SG_SST.Controllers.Base;
using SG_SST.Dtos.Empresas;
using SG_SST.Models;
using SG_SST.Models.AdminUsuarios;
using SG_SST.Models.Empresas;
using SG_SST.Models.Incidentes;
using SG_SST.Services.General.IServices;
using SG_SST.Services.General.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SG_SST.Controllers.Incidentes
{
    public class IncidentesATController : BaseController
    {
        private SG_SSTContext db = new SG_SSTContext();
        IRecursosServicios recursosServicios = new RecursosServicios();
        public ActionResult CrearIncidenteAT(int? pk_id_incidente)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return View();
            }

            var incidentesmodel = new IncidentesATModel();
            incidentesmodel.DepartamentoI = recursosServicios.ObtenerDepartamentos();
            incidentesmodel.MunicipioI = recursosServicios.ObtenetMunicipios(1);
            //incidentesmodel.DepartamentoII = recursosServicios.ObtenerDepartamentos();
            //incidentesmodel.MunicipioII = recursosServicios.ObtenetMunicipios(1);
            incidentesmodel.DeptoCentroCostoII = recursosServicios.ObtenerDepartamentos();
            incidentesmodel.MncpioCentroCostoII = recursosServicios.ObtenetMunicipios(1);
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
            incidentesmodel.DepartamentoIV = recursosServicios.ObtenerDepartamentos();
            incidentesmodel.MncpioIV = recursosServicios.ObtenetMunicipios(1);
            var empresa = db.Tbl_Empresa.Where(x => x.Nit_Empresa == usuarioActual.NitEmpresa).SingleOrDefault();

            if (pk_id_incidente != null)
                incidentesmodel.PK_Incidentes_AT_Id1 = (int)pk_id_incidente;
            else
                incidentesmodel.PK_Incidentes_AT_Id1 = 0;

            incidentesmodel.TipoIdentificacionII = empresa.Tipo_Documento;
            incidentesmodel.CodigoActividadEconomicaII = empresa.Codigo_Actividad.ToString();
            incidentesmodel.ActividadEconomicaII = empresa.Descripcion_Actividad;
            incidentesmodel.NumeroIdentificacionII = empresa.Nit_Empresa;
            incidentesmodel.NombreRazonSocialII = empresa.Razon_Social;
            incidentesmodel.DireccionPpalII = empresa.Direccion;
            incidentesmodel.TelefonoII = empresa.Telefono.Value.ToString();
            incidentesmodel.FaxII = empresa.Fax.Value.ToString();
            /*var sede = db.Tbl_Sede.Where(x => x.Fk_Id_Empresa == empresa.Pk_Id_Empresa).SingleOrDefault();
            var sedemunicipio = db.Tbl_SedeMunicipio.Where(x => x.Fk_id_Sede == sede.Pk_Id_Sede).SingleOrDefault();
            var municipiosede = db.Tbl_Municipio.Where(x => x.Pk_Id_Municipio == sedemunicipio.Fk_Id_Municipio).SingleOrDefault();
            var depto = db.Tbl_Departamento.Where(x => x.Pk_Id_Departamento == municipiosede.Fk_Nombre_Departamento).SingleOrDefault();*/
            incidentesmodel.st_DepartamentoII = respuesta[0].departamento;
            incidentesmodel.st_MunicipioII = respuesta[0].municipio;
            incidentesmodel.EmailII = empresa.Email;
            incidentesmodel.ZonaUrbanaII = empresa.Zona;

            return View(incidentesmodel);
        }

        [HttpGet]
        public JsonResult CargarIncidenteAT(int pk_id_incidente)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var incidentesmodel = new IncidentesATModel();
            var incidentesat1 = db.Tbl_IncidentesAT1.Where(x => (x.PK_Incidentes_AT == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat2 = db.Tbl_IncidentesAT2.Where(x => (x.FK_incidentes_AT2 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat3 = db.Tbl_IncidentesAT3.Where(x => (x.FK_incidentes_AT3 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat4 = db.Tbl_IncidentesAT4.Where(x => (x.FK_incidentes_AT4 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat5 = db.Tbl_IncidentesAT5.Where(x => (x.FK_incidentes_AT5 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat6 = db.Tbl_IncidentesAT6.Where(x => (x.FK_incidentes_AT6 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat7 = db.Tbl_IncidentesAT7.Where(x => (x.FK_incidentes_AT7 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat8 = db.Tbl_IncidentesAT8.Where(x => (x.FK_incidentes_AT8 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat9 = db.Tbl_IncidentesAT9.Where(x => (x.FK_incidentes_AT9 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat10 = db.Tbl_IncidentesAT10.Where(x => (x.FK_incidentes_AT10 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat11 = db.Tbl_IncidentesAT11.Where(x => (x.FK_incidentes_AT11 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat12 = db.Tbl_IncidentesAT12.Where(x => (x.FK_incidentes_AT12 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            var incidentesat13 = db.Tbl_IncidentesAT13.Where(x => (x.FK_incidentes_AT13 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
            //var incidentesatAnexos = db.Tbl_IncidentesATAnexos.Where(x => (x.FK_incidentes_ATAnexos == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();

            if (incidentesat1 == null)
            {
                return Json(incidentesat1, JsonRequestBehavior.AllowGet);
            }

            if (incidentesat1 != null)
            {
                incidentesmodel.boIncidente = incidentesat1.boIncidente;
                incidentesmodel.boIncidente1 = incidentesat1.boIncidente1;
                incidentesmodel.boAccidenteTrabajo = incidentesat1.boAccidenteTrabajo;
                incidentesmodel.boLeve = incidentesat1.boLeve;
                incidentesmodel.boGrave = incidentesat1.boGrave;
                incidentesmodel.boMortal = incidentesat1.boMortal;
                incidentesmodel.FechaInvestigacionI = incidentesat1.FechaInvestigacionI.ToString("dd/MM/yyyy");
                incidentesmodel.pk_DepartamentoI = incidentesat1.pk_DepartamentoI;
                incidentesmodel.pk_MunicipioI = incidentesat1.pk_MunicipioI;
                incidentesmodel.DireccionI = incidentesat1.DireccionI;
                incidentesmodel.HoraInicialI = incidentesat1.HoraInicialI;
                incidentesmodel.HoraFinalI = incidentesat1.HoraFinalI;
                incidentesmodel.ResponsablesI = incidentesat1.ResponsablesI;
                incidentesmodel.FotografiasI = incidentesat1.FotografiasI;
                incidentesmodel.VideosI = incidentesat1.VideosI;
                incidentesmodel.CintasAudioI = incidentesat1.CintasAudioI;
                incidentesmodel.IlustracionesI = incidentesat1.IlustracionesI;
                incidentesmodel.DiagramasI = incidentesat1.DiagramasI;
                incidentesmodel.OtrosI = incidentesat1.OtrosI;
                incidentesmodel.CualesI = incidentesat1.CualesI;
                incidentesmodel.hmyFile1 = incidentesat1.myFile1;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat2 != null)
            {
                incidentesmodel.boTipoVinculacionII = incidentesat2.boTipoVinculacionII;
                incidentesmodel.TipoIdentificacionII = incidentesat2.TipoIdentificacionII;
                incidentesmodel.ActividadEconomicaII = incidentesat2.ActividadEconomicaII;
                incidentesmodel.NumeroIdentificacionII = incidentesat2.NumeroIdentificacionII;
                incidentesmodel.NombreRazonSocialII = incidentesat2.NombreRazonSocialII;
                incidentesmodel.DireccionPpalII = incidentesat2.DireccionPpalII;
                incidentesmodel.TelefonoII = incidentesat2.TelefonoII;
                incidentesmodel.FaxII = incidentesat2.FaxII;
                incidentesmodel.EmailII = incidentesat2.EmailII;
                incidentesmodel.ZonaUrbanaII = incidentesat2.ZonaUrbanaII;
                incidentesmodel.SedePrincipalII = incidentesat2.SedePrincipalII;
                incidentesmodel.ActEconoCentroTrabajoII = incidentesat2.ActEconoCentroTrabajoII;
                incidentesmodel.CentroCostoTelefonoII = incidentesat2.CentroCostoTelefonoII;
                incidentesmodel.CentroCostoFaxII = incidentesat2.CentroCostoFaxII;
                incidentesmodel.DireccionCentroTrabajoII = incidentesat2.DireccionCentroTrabajoII;
                incidentesmodel.ZonaII = incidentesat2.ZonaII;
                incidentesmodel.pk_DeptoCentroCostoII = incidentesat2.pk_DeptoCentroCostoII;
                incidentesmodel.pk_MncpioCentroCostoII = incidentesat2.pk_MncpioCentroCostoII;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat3 != null)
            {
                incidentesmodel.boTipoVinculacionIII = incidentesat3.boTipoVinculacionIII;
                incidentesmodel.tempTipoIdentificacionIII = incidentesat3.tempTipoIdentificacionIII;
                incidentesmodel.NumeroIdentificacionIII = incidentesat3.NumeroIdentificacionIII;
                incidentesmodel.PrimerApellidoIII = incidentesat3.PrimerApellidoIII;
                incidentesmodel.SegundoApellidoIII = incidentesat3.SegundoApellidoIII;
                incidentesmodel.PrimerNombreIII = incidentesat3.PrimerNombreIII;
                incidentesmodel.FechaNacimientoIII = incidentesat3.FechaNacimientoIII;
                incidentesmodel.DepartamentoIII = incidentesat3.DepartamentoIII;
                incidentesmodel.MunicipioIII = incidentesat3.MunicipioIII;
                incidentesmodel.SexoIII = incidentesat3.SexoIII;
                incidentesmodel.EPSIII = incidentesat3.EPSIII;
                incidentesmodel.AFPIII = incidentesat3.AFPIII;
                incidentesmodel.ARLIII = incidentesat3.ARLIII;
                incidentesmodel.TelefonoIII = incidentesat3.TelefonoIII;
                incidentesmodel.FaxIII = incidentesat3.FaxIII;
                incidentesmodel.EmailIII = incidentesat3.EmailIII;
                incidentesmodel.DireccionCentroTrabajoIII = incidentesat3.DireccionCentroTrabajoIII;
                incidentesmodel.ZonaIII = incidentesat3.ZonaIII;
                incidentesmodel.CargoIII = incidentesat3.CargoIII;
                incidentesmodel.OcupacionIII = incidentesat3.OcupacionIII;
                incidentesmodel.FechaIngresoIII = incidentesat3.FechaIngresoIII;
                incidentesmodel.TiempoOcupacionAIII = incidentesat3.TiempoOcupacionAIII;
                incidentesmodel.TiempoOcupacionMIII = incidentesat3.TiempoOcupacionMIII;
                incidentesmodel.AntiguedadAIII = incidentesat3.AntiguedadAIII;
                incidentesmodel.AntiguedadMIII = incidentesat3.AntiguedadMIII;
                incidentesmodel.boJornadaIII = incidentesat3.boJornadaIII;
                incidentesmodel.SalarioHonorariosIII = incidentesat3.SalarioHonorariosIII;
                incidentesmodel.FechaMuerteIII = incidentesat3.FechaMuerteIII;
                incidentesmodel.AtencionOportunaIII = incidentesat3.AtencionOportunaIII;
                incidentesmodel.AtencionOportunaOtrosIII = incidentesat3.AtencionOportunaOtrosIII;
                incidentesmodel.SegundoNombreIII = incidentesat3.SegundoNombreIII;
                incidentesmodel.CodigoOcupacionIII = incidentesat3.CodigoOcupacionIII;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat4 != null)
            {
                incidentesmodel.FechaOcurrenciaIV = incidentesat4.FechaOcurrenciaIV;
                incidentesmodel.HoraOcurrenciaIV = incidentesat4.HoraOcurrenciaIV;
                incidentesmodel.boJornadaIV = incidentesat4.boJornadaIV;
                incidentesmodel.boDiaSemanaIV = incidentesat4.boDiaSemanaIV;
                incidentesmodel.LaborHabitualIV = incidentesat4.LaborHabitualIV;
                incidentesmodel.EspecifiqueLaborHabitual = incidentesat4.EspecifiqueLaborHabitual;
                incidentesmodel.TipoIncidenteIV = incidentesat4.TipoIncidenteIV;
                incidentesmodel.EspecTipoIncidenteIV = incidentesat4.EspecTipoIncidenteIV;
                incidentesmodel.IPSAtendioIV = incidentesat4.IPSAtendioIV;
                incidentesmodel.ZonaIV = incidentesat4.ZonaIV;
                incidentesmodel.TiempoLaboradoPrevioIV = incidentesat4.TiempoLaboradoPrevioIV;
                incidentesmodel.LugarExactoIV = incidentesat4.LugarExactoIV;
                incidentesmodel.SitioExactoIV = incidentesat4.SitioExactoIV;
                incidentesmodel.OtroSitioIV = incidentesat4.OtroSitioIV;
                incidentesmodel.EspecifiqueIV = incidentesat4.EspecifiqueIV;
                incidentesmodel.pk_DepartamentoIV = incidentesat4.pk_DepartamentoIV;
                incidentesmodel.pk_MncpioIV = incidentesat4.pk_MncpioIV;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat5 != null)
            {
                incidentesmodel.EventosSimilaresV = incidentesat5.EventosSimilaresV;
                incidentesmodel.NumeroPersonasV = incidentesat5.NumeroPersonasV;
                incidentesmodel.OtrosIncidentesV = incidentesat5.OtrosIncidentesV;
                incidentesmodel.EventoSimilarV = incidentesat5.EventoSimilarV;
                incidentesmodel.CondicionPrioritariaV = incidentesat5.CondicionPrioritariaV;
                incidentesmodel.TrabajadorInvolucradoV = incidentesat5.TrabajadorInvolucradoV;
                incidentesmodel.PanoramaRiesgoV = incidentesat5.PanoramaRiesgoV;
                incidentesmodel.DescripcionAccidenteV = incidentesat5.DescripcionAccidenteV;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat6 != null)
            {
                incidentesmodel.AgenteVI = incidentesat6.AgenteVI;
                incidentesmodel.MaterialVI = incidentesat6.MaterialVI;
                incidentesmodel.ModeloVI = incidentesat6.ModeloVI;
                incidentesmodel.ReferenciaVI = incidentesat6.ReferenciaVI;
                incidentesmodel.PesoVI = incidentesat6.PesoVI;
                incidentesmodel.PesoUnidadMedidaVI = incidentesat6.PesoUnidadMedidaVI;
                incidentesmodel.AlturaVI = incidentesat6.AlturaVI;
                incidentesmodel.AnchoVI = incidentesat6.AnchoVI;
                incidentesmodel.VolumenVI = incidentesat6.VolumenVI;
                incidentesmodel.ProfundidadVI = incidentesat6.ProfundidadVI;
                incidentesmodel.VelocidadVI = incidentesat6.VelocidadVI;
                incidentesmodel.TiempoUsoVI = incidentesat6.TiempoUsoVI;
                incidentesmodel.TiempoUsoVIA = incidentesat6.TiempoUsoVIA;
                incidentesmodel.FechaMantenimientoVI = incidentesat6.FechaMantenimientoVI;
                incidentesmodel.ReparadoVI = incidentesat6.ReparadoVI;


                incidentesmodel.ExplosivosVI = incidentesat6.ExplosivosVI;
                incidentesmodel.ExplosivosUnidadMedidaVI = incidentesat6.ExplosivosUnidadMedidaVI;
                incidentesmodel.ExplosivosCantidadVI = incidentesat6.ExplosivosCantidadVI;

                incidentesmodel.GasesVI = incidentesat6.GasesVI;
                incidentesmodel.GasesUnidadMedidaVI = incidentesat6.GasesUnidadMedidaVI;
                incidentesmodel.GasesCantidadVI = incidentesat6.GasesCantidadVI;

                incidentesmodel.TemperaturaVI = incidentesat6.TemperaturaVI;
                incidentesmodel.TemperaturaUnidadMedidaVI = incidentesat6.TemperaturaUnidadMedidaVI;

                incidentesmodel.SustanciaVI = incidentesat6.SustanciaVI;
                incidentesmodel.SustanciaUnidadMedidaVI = incidentesat6.SustanciaUnidadMedidaVI;
                incidentesmodel.SustanciaCantidadVI = incidentesat6.SustanciaCantidadVI;


                incidentesmodel.VoltajeElectricoVI = incidentesat6.VoltajeElectricoVI;
                incidentesmodel.VoltajeElectricoUnidadMedidaVI = incidentesat6.VoltajeElectricoUnidadMedidaVI;
                incidentesmodel.VoltajeElectricoCantidadVI = incidentesat6.VoltajeElectricoCantidadVI;

                incidentesmodel.DetallesAdicionalesVI = incidentesat6.DetallesAdicionalesVI;
                incidentesmodel.EPPVI = incidentesat6.EPPVI;
                incidentesmodel.TrabajadorEPPVI = incidentesat6.TrabajadorEPPVI;
                incidentesmodel.ObservacionesVI = incidentesat6.ObservacionesVI;
                incidentesmodel.MarcaVI = incidentesat6.MarcaVI;
                incidentesmodel.VelocidadUnidadMedidaVI = incidentesat6.VelocidadUnidadMedidaVI;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat7 != null)
            {
                incidentesmodel.CodTipoLesionVII = incidentesat7.CodTipoLesionVII;
                incidentesmodel.TipoLesionVII = incidentesat7.CodTipoLesionVII;
                incidentesmodel.CodigoParteCuerpoAfectadaVII = incidentesat7.CodigoParteCuerpoAfectadaVII;
                incidentesmodel.CodMecaAccideneteVII = incidentesat7.CodMecaAccideneteVII;
                incidentesmodel.MecanismoAccidenteVII = incidentesat7.MecanismoAccidenteVII;
                incidentesmodel.CodAgenteAccideneteVII = incidentesat7.CodAgenteAccideneteVII;
                incidentesmodel.AgenteAccidenteVII = incidentesat7.AgenteAccidenteVII;
                incidentesmodel.CodFactoresPersonalesVII1 = incidentesat7.CodFactoresPersonalesVII1;
                incidentesmodel.FactoresPersonalesVII1 = incidentesat7.FactoresPersonalesVII1;
                incidentesmodel.CodFactoresPersonalesVII2 = incidentesat7.CodFactoresPersonalesVII2;
                incidentesmodel.FactoresPersonalesVII2 = incidentesat7.FactoresPersonalesVII2;
                incidentesmodel.CodActoSubestandarVII1 = incidentesat7.CodActoSubestandarVII1;
                incidentesmodel.ActosSubestandarVII1 = incidentesat7.ActosSubestandarVII1;
                incidentesmodel.CodActoSubestandarVII2 = incidentesat7.CodActoSubestandarVII2;
                incidentesmodel.ActosSubestandarVII2 = incidentesat7.ActosSubestandarVII2;
                incidentesmodel.CodFactoresTrabajoVII1 = incidentesat7.CodFactoresTrabajoVII1;
                incidentesmodel.FactoresTrabajoVII1 = incidentesat7.FactoresTrabajoVII1;
                incidentesmodel.CodFactoresTrabajoVII2 = incidentesat7.CodFactoresTrabajoVII2;
                incidentesmodel.FactoresTrabajoVII2 = incidentesat7.FactoresTrabajoVII2;
                incidentesmodel.CodCondAmbientalesVII1 = incidentesat7.CodCondAmbientalesVII1;
                incidentesmodel.CondAmbientalesVII1 = incidentesat7.CondAmbientalesVII1;
                incidentesmodel.CodCondAmbientalesVII2 = incidentesat7.CodCondAmbientalesVII2;
                incidentesmodel.CondAmbientalesVII2 = incidentesat7.CondAmbientalesVII2;
                incidentesmodel.textfield74 = incidentesat7.textfield74;
                incidentesmodel.FactoresPersonalesVII2 = incidentesat7.FactoresPersonalesVII2;
                incidentesmodel.CodActFactoresPersonalesVII2 = incidentesat7.CodActFactoresPersonalesVII2;
                incidentesmodel.ActFactoresPersonalesVII2 = incidentesat7.ActFactoresPersonalesVII2;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat8 != null)
            {
                incidentesmodel.hmyFile8 = incidentesat8.myFile8;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat9 != null)
            {
                incidentesmodel.TipoIdentJefeInmediantoIX = incidentesat9.TipoIdentJefeInmediantoIX;
                incidentesmodel.NumIdentJefeInmediatoIX = incidentesat9.NumIdentJefeInmediatoIX;
                incidentesmodel.JefeInmediatoNombresIX = incidentesat9.JefeInmediatoNombresIX;
                incidentesmodel.JefeInmediatoCargoIX = incidentesat9.JefeInmediatoCargoIX;
                incidentesmodel.DescripcionAnalisisIX = incidentesat9.DescripcionAnalisisIX;
                incidentesmodel.TipoIdentEncargadoPSOIX = incidentesat9.TipoIdentEncargadoPSOIX;
                incidentesmodel.NumIdentPSOIX = incidentesat9.NumIdentPSOIX;
                incidentesmodel.EncargadoPSONombresIX = incidentesat9.EncargadoPSONombresIX;
                incidentesmodel.EncargadoPSOCargoIX = incidentesat9.EncargadoPSOCargoIX;
                incidentesmodel.TipoIdentCOPASOIX = incidentesat9.TipoIdentCOPASOIX;
                incidentesmodel.COPASONumIdentIX = incidentesat9.COPASONumIdentIX;
                incidentesmodel.COPASONombresCompletosIX = incidentesat9.COPASONombresCompletosIX;
                incidentesmodel.COPASOCargoIX = incidentesat9.COPASOCargoIX;
                incidentesmodel.TipoIdentEncargadosPSOIX = incidentesat9.TipoIdentEncargadosPSOIX;
                incidentesmodel.NumeroIdentBrigadistaIX = incidentesat9.NumeroIdentBrigadistaIX;
                incidentesmodel.BrigadistaNombresIX = incidentesat9.BrigadistaNombresIX;
                incidentesmodel.BrigadistaCargoIX = incidentesat9.BrigadistaCargoIX;
                incidentesmodel.TipoIdentParticipanteIX = incidentesat9.TipoIdentParticipanteIX;
                incidentesmodel.NumIdentParticipanteIX = incidentesat9.NumIdentParticipanteIX;
                incidentesmodel.ParticipanteNombreIX = incidentesat9.ParticipanteNombreIX;
                incidentesmodel.ParticipanteCargoIX = incidentesat9.ParticipanteCargoIX;
                incidentesmodel.EmpresaRepresentaIX = incidentesat9.EmpresaRepresentaIX;
                incidentesmodel.ObservacionEspecialistaIX = incidentesat9.ObservacionEspecialistaIX;
                incidentesmodel.TipoIdentBrigadistaIX = incidentesat9.TipoIdentBrigadistaIX;
                incidentesmodel.TipoIdentRepresentanteARLIX = incidentesat9.TipoIdentRepresentanteARLIX;
                incidentesmodel.RepresentanteARLNombresIX = incidentesat9.RepresentanteARLNombresIX;
                incidentesmodel.NumIdentRepresentanteARLIXIX = incidentesat9.NumIdentRepresentanteARLIXIX;
                incidentesmodel.TipoIdentEspecialistaSGSSTIX = incidentesat9.TipoIdentEspecialistaSGSSTIX;
                incidentesmodel.EspecialistaSGSSTNombresIX = incidentesat9.EspecialistaSGSSTNombresIX;
                incidentesmodel.NumIdentEspecialistaSGSSTIX = incidentesat9.NumIdentEspecialistaSGSSTIX;
                incidentesmodel.NumLicenciaEspecialistaSGSSTIX1 = incidentesat9.NumLicenciaEspecialistaSGSSTIX1;
                incidentesmodel.anioLicenciaEspecialistaSGSSTIX1 = incidentesat9.anioLicenciaEspecialistaSGSSTIX1;
                incidentesmodel.NumLicenciaEspecialistaSGSSTIX2 = incidentesat9.NumLicenciaEspecialistaSGSSTIX2;
                incidentesmodel.anioLicenciaEspecialistaSGSSTIX2 = incidentesat9.anioLicenciaEspecialistaSGSSTIX2;
                incidentesmodel.hmyFile3 = incidentesat9.myFile3;
                incidentesmodel.hmyFile4 = incidentesat9.myFile4;
                incidentesmodel.hmyFile5 = incidentesat9.myFile5;
                incidentesmodel.hmyFile6 = incidentesat9.myFile6;
                incidentesmodel.hmyFile7 = incidentesat9.myFile7;
                incidentesmodel.hmyFile9 = incidentesat9.myFile9;
                incidentesmodel.hmyFile10 = incidentesat9.myFile10;
                incidentesmodel.TipoIdentJefeInmediantoIXTI = incidentesat9.TipoIdentJefeInmediantoIXTI;
                incidentesmodel.TipoIdentEncargadoPSOIXTI = incidentesat9.TipoIdentEncargadoPSOIXTI;
                incidentesmodel.TipoIdentCOPASOIXTI = incidentesat9.TipoIdentCOPASOIXTI;
                incidentesmodel.TipoIdentBrigadistaIXTI = incidentesat9.TipoIdentBrigadistaIXTI;
                incidentesmodel.TipoIdentParticipanteIXTI = incidentesat9.TipoIdentParticipanteIXTI;
                incidentesmodel.TipoIdentRepresentanteARLIXTI = incidentesat9.TipoIdentRepresentanteARLIXTI;
                incidentesmodel.TipoIdentEspecialistaSGSSTIXTI = incidentesat9.TipoIdentEspecialistaSGSSTIXTI;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat10 != null)
            {
                incidentesmodel.CausasInmediatasTipoC1X = incidentesat10.CausasInmediatasTipoC1X;
                incidentesmodel.MedidasIntervencion1X = incidentesat10.MedidasIntervencion1X;
                incidentesmodel.TipoF1X = incidentesat10.TipoF1X;
                incidentesmodel.RespImplementacion1X = incidentesat10.RespImplementacion1X;
                incidentesmodel.FechaImplementacion1X = incidentesat10.FechaImplementacion1X;
                incidentesmodel.CausasInmediatasTipoC2X = incidentesat10.CausasInmediatasTipoC2X;
                incidentesmodel.MedidasIntervencion2X = incidentesat10.MedidasIntervencion2X;
                incidentesmodel.TipoF2X = incidentesat10.TipoF2X;
                incidentesmodel.RespImplementacion2X = incidentesat10.RespImplementacion2X;
                incidentesmodel.FechaImplementacion2X = incidentesat10.FechaImplementacion2X;
                incidentesmodel.CausasInmediatasTipoC3X = incidentesat10.CausasInmediatasTipoC3X;
                incidentesmodel.MedidasIntervencion3X = incidentesat10.MedidasIntervencion3X;
                incidentesmodel.TipoF3X = incidentesat10.TipoF3X;
                incidentesmodel.RespImplementacion3X = incidentesat10.RespImplementacion3X;
                incidentesmodel.FechaImplementacion3X = incidentesat10.FechaImplementacion3X;
                incidentesmodel.CausasBasicasTipoC1X = incidentesat10.CausasBasicasTipoC1X;
                incidentesmodel.BasicasInmediatas1X = incidentesat10.BasicasInmediatas1X;
                incidentesmodel.BasicasF1X = incidentesat10.BasicasF1X;
                incidentesmodel.BasicasRespImplementacion1X = incidentesat10.BasicasRespImplementacion1X;
                incidentesmodel.BasicasFechaImplementacion1X = incidentesat10.BasicasFechaImplementacion1X;
                incidentesmodel.CausasBasicasTipoC2X = incidentesat10.CausasBasicasTipoC2X;
                incidentesmodel.BasicasInmediatas2X = incidentesat10.BasicasInmediatas2X;
                incidentesmodel.BasicasF2X = incidentesat10.BasicasF2X;
                incidentesmodel.BasicasRespImplementacion2X = incidentesat10.BasicasRespImplementacion2X;
                incidentesmodel.BasicasFechaImplementacion2X = incidentesat10.BasicasFechaImplementacion2X;
                incidentesmodel.CausasBasicasTipoC3X = incidentesat10.CausasBasicasTipoC3X;
                incidentesmodel.BasicasInmediatas3X = incidentesat10.BasicasInmediatas3X;
                incidentesmodel.BasicasF3X = incidentesat10.BasicasF3X;
                incidentesmodel.BasicasT3X = incidentesat10.BasicasT3X;
                incidentesmodel.BasicasRespImplementacion3X = incidentesat10.BasicasRespImplementacion3X;
                incidentesmodel.BasicasFechaImplementacion3X = incidentesat10.BasicasFechaImplementacion3X;
                incidentesmodel.boTipoF1X = incidentesat10.boTipoF1X;
                incidentesmodel.boTipoM1X = incidentesat10.boTipoM1X;
                incidentesmodel.boTipoT1X = incidentesat10.boTipoT1X;
                incidentesmodel.boTipoF2X = incidentesat10.boTipoF2X;
                incidentesmodel.boTipoM2X = incidentesat10.boTipoM2X;
                incidentesmodel.boTipoT2X = incidentesat10.boTipoT2X;
                incidentesmodel.boTipoF3X = incidentesat10.boTipoF3X;
                incidentesmodel.boTipoM3X = incidentesat10.boTipoM3X;
                incidentesmodel.boTipoT3X = incidentesat10.boTipoT3X;
                incidentesmodel.boBasicasF1X = incidentesat10.boBasicasF1X;
                incidentesmodel.boBasicasM1X = incidentesat10.boBasicasM1X;
                incidentesmodel.boBasicasT1X = incidentesat10.boBasicasT1X;
                incidentesmodel.boBasicasF2X = incidentesat10.boBasicasF2X;
                incidentesmodel.boBasicasM2X = incidentesat10.boBasicasM2X;
                incidentesmodel.boBasicasT2X = incidentesat10.boBasicasT2X;
                incidentesmodel.boBasicasF3X = incidentesat10.boBasicasF3X;
                incidentesmodel.boBasicasM3X = incidentesat10.boBasicasM3X;
                incidentesmodel.boBasicasT3X = incidentesat10.boBasicasT3X;
                //incidentesmodel.hmyFile11 = incidentesat10.myFile11;

            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat11 != null)
            {
                incidentesmodel.FechaRemisionXI = incidentesat11.FechaRemisionXI;
                incidentesmodel.NoFoliosXI = incidentesat11.NoFoliosXI;
                incidentesmodel.TipoIdentificacionXI = incidentesat11.TipoIdentificacionXI;
                incidentesmodel.NumeroIdentificacionXI = incidentesat11.NumeroIdentificacionXI;
                incidentesmodel.NombresXI = incidentesat11.NombresXI;
                incidentesmodel.CargoXI = incidentesat11.CargoXI;
                incidentesmodel.RecomendacionesARLXI = incidentesat11.RecomendacionesARLXI;
                incidentesmodel.RemisionInformeARLXI = incidentesat11.RemisionInformeARLXI;
                incidentesmodel.RemisionMinisterioTrabajoXI = incidentesat11.RemisionMinisterioTrabajoXI;
                incidentesmodel.RecomendacionesCargoXI = incidentesat11.RecomendacionesCargoXI;
                incidentesmodel.hmyFile11 = incidentesat11.myFile11;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat12 != null)
            {
                incidentesmodel.TipoIdentificacionXII = incidentesat12.TipoIdentificacionXII;
                incidentesmodel.NumeroIdentificacionXII = incidentesat12.NumeroIdentificacionXII;
                incidentesmodel.NombresXII = incidentesat12.NombresXII;
                incidentesmodel.CargoXII = incidentesat12.CargoXII;
                incidentesmodel.MedidasIntervencionXII = incidentesat12.MedidasIntervencionXII;
                incidentesmodel.ObservacionesXII = incidentesat12.ObservacionesXII;
                incidentesmodel.FechaVerificacionXII = incidentesat12.FechaVerificacionXII;
                incidentesmodel.hmyFile12 = incidentesat12.myFile12;

            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat13 != null)
            {
                incidentesmodel.TipoIdentificacionXIII = incidentesat13.TipoIdentificacionXIII;
                incidentesmodel.NombresXIII = incidentesat13.NombresXIII;
                incidentesmodel.CargoXIII = incidentesat13.CargoXIII;
                incidentesmodel.NumeroIdentificacionXIII = incidentesat13.NumeroIdentificacionXIII;
                incidentesmodel.MedidasIntervencionXIII = incidentesat13.MedidasIntervencionXIII;
                incidentesmodel.FechaVerificacionXIII = incidentesat13.FechaVerificacionXIII;
                incidentesmodel.ObservacionesXIII = incidentesat13.ObservacionesXIII;
                incidentesmodel.hmyFile13 = incidentesat13.myFile13;
            }
            ///////////////////////////////////////////////////////////////////////
            return Json(incidentesmodel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerMunicipiosxDepto(int pk_id_depto)
        {
            List<Municipio> listMunicipio = recursosServicios.ObtenetMunicipios(pk_id_depto);
            return Json(listMunicipio, JsonRequestBehavior.AllowGet);
        }

        private DateTime FormatDate(string Fecha)
        {
            string[] date = Fecha.Split('/');
            string fecpattern = date[0] + "-" + date[1] + "-" + date[2];
            return Convert.ToDateTime(fecpattern, System.Globalization.CultureInfo.GetCultureInfo("es-CO").DateTimeFormat);
        }

        private string FormatDatesI(string Fecha)
        {//"1985-02-15"
            string[] fec = Fecha.Split('-');
            string fecpattern = fec[2] + "/" + fec[1] + "/" + fec[0];
            return fecpattern;
        }

        #region GUARDADOS PARCIALES

        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT1
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT1(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT1.Where(x => x.PK_Incidentes_AT == frmIncidentesAT.PK_Incidentes_AT_Id1).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT1.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT1 incidentes = new IncidentesAT1()
                {
                    boIncidente = frmIncidentesAT.boIncidente,
                    boIncidente1 = frmIncidentesAT.boIncidente1,
                    boAccidenteTrabajo = frmIncidentesAT.boAccidenteTrabajo,
                    boLeve = frmIncidentesAT.boLeve,
                    boGrave = frmIncidentesAT.boGrave,
                    boMortal = frmIncidentesAT.boMortal,
                    FechaInvestigacionI = FormatDate(frmIncidentesAT.FechaInvestigacionI),
                    pk_DepartamentoI = frmIncidentesAT.pk_DepartamentoI,
                    pk_MunicipioI = frmIncidentesAT.pk_MunicipioI,
                    DireccionI = frmIncidentesAT.DireccionI,
                    HoraInicialI = frmIncidentesAT.HoraInicialI,
                    HoraFinalI = frmIncidentesAT.HoraFinalI,
                    ResponsablesI = frmIncidentesAT.ResponsablesI,
                    FotografiasI = frmIncidentesAT.FotografiasI,
                    VideosI = frmIncidentesAT.VideosI,
                    CintasAudioI = frmIncidentesAT.CintasAudioI,
                    IlustracionesI = frmIncidentesAT.IlustracionesI,
                    DiagramasI = frmIncidentesAT.DiagramasI,
                    OtrosI = frmIncidentesAT.OtrosI,
                    CualesI = frmIncidentesAT.CualesI,
                    myFile1 = frmIncidentesAT.hmyFile1,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT1.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT2
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT2(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT2.Where(x => x.FK_incidentes_AT2 == frmIncidentesAT.PK_Incidentes_AT_Id2).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT2.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT2 incidentes = new IncidentesAT2()
                {
                    FK_incidentes_AT2 = frmIncidentesAT.PK_Incidentes_AT_Id2,
                    boTipoVinculacionII = frmIncidentesAT.boTipoVinculacionII,
                    TipoIdentificacionII = frmIncidentesAT.TipoIdentificacionII,
                    ActividadEconomicaII = frmIncidentesAT.ActividadEconomicaII,
                    NumeroIdentificacionII = frmIncidentesAT.NumeroIdentificacionII,
                    NombreRazonSocialII = frmIncidentesAT.NombreRazonSocialII,
                    DireccionPpalII = frmIncidentesAT.DireccionPpalII,
                    TelefonoII = frmIncidentesAT.TelefonoII,
                    FaxII = frmIncidentesAT.FaxII,
                    st_DepartamentoII = frmIncidentesAT.st_DepartamentoII,
                    st_MunicipioII = frmIncidentesAT.st_MunicipioII,
                    EmailII = frmIncidentesAT.EmailII,
                    ZonaUrbanaII = frmIncidentesAT.ZonaUrbanaII,
                    SedePrincipalII = frmIncidentesAT.SedePrincipalII,
                    CodigoActEconoCentroTrabajoII = frmIncidentesAT.CodigoActEconoCentroTrabajoII,
                    ActEconoCentroTrabajoII = frmIncidentesAT.ActEconoCentroTrabajoII,
                    CentroCostoTelefonoII = frmIncidentesAT.CentroCostoTelefonoII,
                    CentroCostoFaxII = frmIncidentesAT.CentroCostoFaxII,
                    DireccionCentroTrabajoII = frmIncidentesAT.DireccionCentroTrabajoII,
                    ZonaII = frmIncidentesAT.ZonaII,
                    pk_DeptoCentroCostoII = frmIncidentesAT.pk_DeptoCentroCostoII,
                    pk_MncpioCentroCostoII = frmIncidentesAT.pk_MncpioCentroCostoII,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT2.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT2;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT3
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT3(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT3.Where(x => x.FK_incidentes_AT3 == frmIncidentesAT.PK_Incidentes_AT_Id3).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT3.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT3 incidentes = new IncidentesAT3()
                {
                    FK_incidentes_AT3 = frmIncidentesAT.PK_Incidentes_AT_Id3,
                    boTipoVinculacionIII = frmIncidentesAT.boTipoVinculacionIII,
                    tempTipoIdentificacionIII = frmIncidentesAT.tempTipoIdentificacionIII,
                    NumeroIdentificacionIII = frmIncidentesAT.NumeroIdentificacionIII,
                    PrimerApellidoIII = frmIncidentesAT.PrimerApellidoIII,
                    SegundoApellidoIII = frmIncidentesAT.SegundoApellidoIII,
                    PrimerNombreIII = frmIncidentesAT.PrimerNombreIII,
                    FechaNacimientoIII = frmIncidentesAT.FechaNacimientoIII,
                    DepartamentoIII = frmIncidentesAT.DepartamentoIII,
                    MunicipioIII = frmIncidentesAT.MunicipioIII,
                    SexoIII = frmIncidentesAT.SexoIII,
                    EPSIII = frmIncidentesAT.EPSIII,
                    AFPIII = frmIncidentesAT.AFPIII,
                    ARLIII = frmIncidentesAT.ARLIII,
                    TelefonoIII = frmIncidentesAT.TelefonoIII,
                    FaxIII = frmIncidentesAT.FaxIII,
                    EmailIII = frmIncidentesAT.EmailIII,
                    DireccionCentroTrabajoIII = frmIncidentesAT.DireccionCentroTrabajoIII,
                    ZonaIII = frmIncidentesAT.ZonaIII,
                    CargoIII = frmIncidentesAT.CargoIII,
                    OcupacionIII = frmIncidentesAT.OcupacionIII,
                    FechaIngresoIII = frmIncidentesAT.FechaIngresoIII,
                    TiempoOcupacionAIII = frmIncidentesAT.TiempoOcupacionAIII,
                    TiempoOcupacionMIII = frmIncidentesAT.TiempoOcupacionMIII,
                    AntiguedadAIII = frmIncidentesAT.AntiguedadAIII,
                    AntiguedadMIII = frmIncidentesAT.AntiguedadMIII,
                    boJornadaIII = frmIncidentesAT.boJornadaIII,
                    SalarioHonorariosIII = frmIncidentesAT.SalarioHonorariosIII,
                    FechaMuerteIII = frmIncidentesAT.FechaMuerteIII,
                    AtencionOportunaIII = frmIncidentesAT.AtencionOportunaIII,
                    AtencionOportunaOtrosIII = frmIncidentesAT.AtencionOportunaOtrosIII,
                    SegundoNombreIII = frmIncidentesAT.SegundoNombreIII,
                    CodigoOcupacionIII = frmIncidentesAT.CodigoOcupacionIII,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT3.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT3;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT4
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT4(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT4.Where(x => x.FK_incidentes_AT4 == frmIncidentesAT.PK_Incidentes_AT_Id4).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT4.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT4 incidentes = new IncidentesAT4()
                {
                    FK_incidentes_AT4 = frmIncidentesAT.PK_Incidentes_AT_Id4,
                    pk_DepartamentoIV= frmIncidentesAT.pk_DepartamentoIV,
                    pk_MncpioIV = frmIncidentesAT.pk_MncpioIV,
                    FechaOcurrenciaIV = frmIncidentesAT.FechaOcurrenciaIV,
                    HoraOcurrenciaIV = frmIncidentesAT.HoraOcurrenciaIV,
                    boJornadaIV = frmIncidentesAT.boJornadaIV,
                    boDiaSemanaIV = frmIncidentesAT.stDiaSemanaIV,
                    LaborHabitualIV = frmIncidentesAT.LaborHabitualIV,
                    EspecifiqueLaborHabitual = frmIncidentesAT.EspecifiqueLaborHabitual,
                    TipoIncidenteIV = frmIncidentesAT.TipoIncidenteIV,
                    EspecTipoIncidenteIV = frmIncidentesAT.EspecTipoIncidenteIV,
                    IPSAtendioIV = frmIncidentesAT.IPSAtendioIV,
                    ZonaIV = frmIncidentesAT.ZonaIV,
                    TiempoLaboradoPrevioIV = frmIncidentesAT.TiempoLaboradoPrevioIV,
                    LugarExactoIV = frmIncidentesAT.LugarExactoIV,
                    SitioExactoIV = frmIncidentesAT.SitioExactoIV,
                    OtroSitioIV = frmIncidentesAT.OtroSitioIV,
                    EspecifiqueIV = frmIncidentesAT.EspecifiqueIV,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT4.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT4;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT5
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT5(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT5.Where(x => x.FK_incidentes_AT5 == frmIncidentesAT.PK_Incidentes_AT_Id5).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT5.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT5 incidentes = new IncidentesAT5()
                {
                    FK_incidentes_AT5 = frmIncidentesAT.PK_Incidentes_AT_Id5,
                    EventosSimilaresV = frmIncidentesAT.EventosSimilaresV,
                    NumeroPersonasV = frmIncidentesAT.NumeroPersonasV,
                    OtrosIncidentesV = frmIncidentesAT.OtrosIncidentesV,
                    EventoSimilarV = frmIncidentesAT.EventoSimilarV,
                    CondicionPrioritariaV = frmIncidentesAT.CondicionPrioritariaV,
                    TrabajadorInvolucradoV = frmIncidentesAT.TrabajadorInvolucradoV,
                    PanoramaRiesgoV = frmIncidentesAT.PanoramaRiesgoV,
                    DescripcionAccidenteV = frmIncidentesAT.DescripcionAccidenteV,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT5.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT5;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT6
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT6(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT6.Where(x => x.FK_incidentes_AT6 == frmIncidentesAT.PK_Incidentes_AT_Id6).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT6.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT6 incidentes = new IncidentesAT6()
                {
                    FK_incidentes_AT6 = frmIncidentesAT.PK_Incidentes_AT_Id6,
                    AgenteVI = frmIncidentesAT.AgenteVI,
                    MaterialVI = frmIncidentesAT.MaterialVI,
                    ModeloVI = frmIncidentesAT.ModeloVI,
                    ReferenciaVI = frmIncidentesAT.ReferenciaVI,
                    PesoVI = frmIncidentesAT.PesoVI,
                    PesoUnidadMedidaVI = frmIncidentesAT.PesoUnidadMedidaVI,
                    AlturaVI = frmIncidentesAT.AlturaVI,
                    AnchoVI = frmIncidentesAT.AnchoVI,
                    VolumenVI = frmIncidentesAT.VolumenVI,
                    ProfundidadVI = frmIncidentesAT.ProfundidadVI,
                    VelocidadVI = frmIncidentesAT.VelocidadVI,
                    TiempoUsoVI = frmIncidentesAT.TiempoUsoVI,
                    TiempoUsoVIA = frmIncidentesAT.TiempoUsoVIA,
                    FechaMantenimientoVI = frmIncidentesAT.FechaMantenimientoVI,
                    ReparadoVI = frmIncidentesAT.ReparadoVI,
                    VelocidadUnidadMedidaVI = frmIncidentesAT.VelocidadUnidadMedidaVI,
                    MarcaVI = frmIncidentesAT.MarcaVI,
                    ExplosivosVI = frmIncidentesAT.ExplosivosVI,
                    ExplosivosUnidadMedidaVI = frmIncidentesAT.ExplosivosUnidadMedidaVI,
                    ExplosivosCantidadVI = frmIncidentesAT.ExplosivosCantidadVI,
                    GasesVI = frmIncidentesAT.GasesVI,
                    GasesUnidadMedidaVI = frmIncidentesAT.GasesUnidadMedidaVI,
                    GasesCantidadVI = frmIncidentesAT.GasesCantidadVI,
                    TemperaturaVI = frmIncidentesAT.TemperaturaVI,
                    TemperaturaUnidadMedidaVI = frmIncidentesAT.TemperaturaUnidadMedidaVI,
                    SustanciaVI = frmIncidentesAT.SustanciaVI,
                    SustanciaUnidadMedidaVI = frmIncidentesAT.SustanciaUnidadMedidaVI,
                    SustanciaCantidadVI = frmIncidentesAT.SustanciaCantidadVI,
                    VoltajeElectricoVI = frmIncidentesAT.VoltajeElectricoVI,
                    VoltajeElectricoUnidadMedidaVI = frmIncidentesAT.VoltajeElectricoUnidadMedidaVI,
                    VoltajeElectricoCantidadVI = frmIncidentesAT.VoltajeElectricoCantidadVI,
                    DetallesAdicionalesVI = frmIncidentesAT.DetallesAdicionalesVI,
                    EPPVI = frmIncidentesAT.EPPVI,
                    TrabajadorEPPVI = frmIncidentesAT.TrabajadorEPPVI,
                    ObservacionesVI = frmIncidentesAT.ObservacionesVI,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT6.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT6;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT7
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT7(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT7.Where(x => x.FK_incidentes_AT7 == frmIncidentesAT.PK_Incidentes_AT_Id7).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT7.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT7 incidentes = new IncidentesAT7()
                {
                    FK_incidentes_AT7 = frmIncidentesAT.PK_Incidentes_AT_Id7,
                    CodTipoLesionVII = frmIncidentesAT.CodTipoLesionVII,
                    TipoLesionVII = frmIncidentesAT.TipoLesionVII,
                    CodigoParteCuerpoAfectadaVII = frmIncidentesAT.CodigoParteCuerpoAfectadaVII,
                    CodMecaAccideneteVII = frmIncidentesAT.CodMecaAccideneteVII,
                    MecanismoAccidenteVII = frmIncidentesAT.MecanismoAccidenteVII,
                    CodAgenteAccideneteVII = frmIncidentesAT.CodAgenteAccideneteVII,
                    AgenteAccidenteVII = frmIncidentesAT.AgenteAccidenteVII,
                    CodFactoresPersonalesVII1 = frmIncidentesAT.CodFactoresPersonalesVII1,
                    FactoresPersonalesVII1 = frmIncidentesAT.FactoresPersonalesVII1,
                    CodFactoresPersonalesVII2 = frmIncidentesAT.CodFactoresPersonalesVII2,
                    FactoresPersonalesVII2 = frmIncidentesAT.FactoresPersonalesVII2,
                    CodActoSubestandarVII1 = frmIncidentesAT.CodActoSubestandarVII1,
                    ActosSubestandarVII1 = frmIncidentesAT.ActosSubestandarVII1,
                    CodActoSubestandarVII2 = frmIncidentesAT.CodActoSubestandarVII2,
                    ActosSubestandarVII2 = frmIncidentesAT.ActosSubestandarVII2,
                    CodFactoresTrabajoVII1 = frmIncidentesAT.CodFactoresTrabajoVII1,
                    FactoresTrabajoVII1 = frmIncidentesAT.FactoresTrabajoVII1,
                    CodFactoresTrabajoVII2 = frmIncidentesAT.CodFactoresTrabajoVII2,
                    FactoresTrabajoVII2 = frmIncidentesAT.FactoresTrabajoVII2,
                    CodCondAmbientalesVII1 = frmIncidentesAT.CodCondAmbientalesVII1,
                    CondAmbientalesVII1 = frmIncidentesAT.CondAmbientalesVII1,
                    CodCondAmbientalesVII2 = frmIncidentesAT.CodCondAmbientalesVII2,
                    CondAmbientalesVII2 = frmIncidentesAT.CondAmbientalesVII2,
                    textfield74 = frmIncidentesAT.textfield74,
                    CodActFactoresPersonalesVII2 = frmIncidentesAT.CodActFactoresPersonalesVII2,
                    ActFactoresPersonalesVII2 = frmIncidentesAT.ActFactoresPersonalesVII2,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT7.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT7;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT8
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT8(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT8.Where(x => x.FK_incidentes_AT8 == frmIncidentesAT.PK_Incidentes_AT_Id8).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT8.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT8 incidentes = new IncidentesAT8()
                {
                    FK_incidentes_AT8 = frmIncidentesAT.PK_Incidentes_AT_Id8,
                    myFile8 = frmIncidentesAT.hmyFile8,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT8.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT8;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT9
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT9(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT9.Where(x => x.FK_incidentes_AT9 == frmIncidentesAT.PK_Incidentes_AT_Id9).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT9.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT9 incidentes = new IncidentesAT9()
                {
                    FK_incidentes_AT9 = frmIncidentesAT.PK_Incidentes_AT_Id9,
                    DescripcionAnalisisIX = frmIncidentesAT.DescripcionAnalisisIX,
                    
                    TipoIdentJefeInmediantoIX = frmIncidentesAT.TipoIdentJefeInmediantoIX,
                    NumIdentJefeInmediatoIX = frmIncidentesAT.NumIdentJefeInmediatoIX,
                    JefeInmediatoNombresIX = frmIncidentesAT.JefeInmediatoNombresIX,
                    JefeInmediatoCargoIX = frmIncidentesAT.JefeInmediatoCargoIX,


                    TipoIdentEncargadoPSOIX = frmIncidentesAT.TipoIdentEncargadoPSOIX,
                    NumIdentPSOIX = frmIncidentesAT.NumIdentPSOIX,
                    EncargadoPSONombresIX = frmIncidentesAT.EncargadoPSONombresIX,
                    EncargadoPSOCargoIX = frmIncidentesAT.EncargadoPSOCargoIX,


                    TipoIdentCOPASOIX = frmIncidentesAT.TipoIdentCOPASOIX,
                    COPASONumIdentIX = frmIncidentesAT.COPASONumIdentIX,
                    COPASONombresCompletosIX = frmIncidentesAT.COPASONombresCompletosIX,
                    COPASOCargoIX = frmIncidentesAT.COPASOCargoIX,

                    TipoIdentBrigadistaIX = frmIncidentesAT.TipoIdentBrigadistaIX,
                    NumeroIdentBrigadistaIX = frmIncidentesAT.NumeroIdentBrigadistaIX,
                    BrigadistaNombresIX = frmIncidentesAT.BrigadistaNombresIX,
                    BrigadistaCargoIX = frmIncidentesAT.BrigadistaCargoIX,

                    TipoIdentParticipanteIX = frmIncidentesAT.TipoIdentParticipanteIX,
                    NumIdentParticipanteIX = frmIncidentesAT.NumIdentParticipanteIX,
                    ParticipanteNombreIX = frmIncidentesAT.ParticipanteNombreIX,
                    ParticipanteCargoIX = frmIncidentesAT.ParticipanteCargoIX,

                    TipoIdentRepresentanteARLIX = frmIncidentesAT.TipoIdentRepresentanteARLIX,
                    RepresentanteARLNombresIX = frmIncidentesAT.RepresentanteARLNombresIX,
                    NumIdentRepresentanteARLIXIX = frmIncidentesAT.NumIdentRepresentanteARLIXIX,

                    TipoIdentEspecialistaSGSSTIX = frmIncidentesAT.TipoIdentEspecialistaSGSSTIX,
                    EspecialistaSGSSTNombresIX = frmIncidentesAT.EspecialistaSGSSTNombresIX,
                    NumIdentEspecialistaSGSSTIX = frmIncidentesAT.NumIdentEspecialistaSGSSTIX,

                    EmpresaRepresentaIX = frmIncidentesAT.EmpresaRepresentaIX,
                    ObservacionEspecialistaIX = frmIncidentesAT.ObservacionEspecialistaIX,
                    NumLicenciaEspecialistaSGSSTIX1 = frmIncidentesAT.NumLicenciaEspecialistaSGSSTIX1,
                    anioLicenciaEspecialistaSGSSTIX1 = frmIncidentesAT.anioLicenciaEspecialistaSGSSTIX1,
                    NumLicenciaEspecialistaSGSSTIX2 = frmIncidentesAT.NumLicenciaEspecialistaSGSSTIX2,
                    anioLicenciaEspecialistaSGSSTIX2 = frmIncidentesAT.anioLicenciaEspecialistaSGSSTIX2,
                    

                    myFile3 = frmIncidentesAT.hmyFile3,
                    myFile4 = frmIncidentesAT.hmyFile4,
                    myFile5 = frmIncidentesAT.hmyFile5,
                    myFile6 = frmIncidentesAT.hmyFile6,
                    myFile7 = frmIncidentesAT.hmyFile7,
                    myFile9 = frmIncidentesAT.hmyFile9,
                    myFile10 = frmIncidentesAT.hmyFile10,
                    NitEmpresa = usuarioActual.NitEmpresa
                   
                };

                db.Tbl_IncidentesAT9.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT9;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT10
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT10(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT10.Where(x => x.FK_incidentes_AT10 == frmIncidentesAT.PK_Incidentes_AT_Id10).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT10.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT10 incidentes = new IncidentesAT10()
                {
                    FK_incidentes_AT10 = frmIncidentesAT.PK_Incidentes_AT_Id10,
                    CausasInmediatasTipoC1X = frmIncidentesAT.CausasInmediatasTipoC1X,
                    MedidasIntervencion1X = frmIncidentesAT.MedidasIntervencion1X,
                    TipoF1X = frmIncidentesAT.TipoF1X,
                    RespImplementacion1X = frmIncidentesAT.RespImplementacion1X,
                    FechaImplementacion1X = frmIncidentesAT.FechaImplementacion1X,
                    CausasInmediatasTipoC2X = frmIncidentesAT.CausasInmediatasTipoC2X,
                    MedidasIntervencion2X = frmIncidentesAT.MedidasIntervencion2X,
                    TipoF2X = frmIncidentesAT.TipoF2X,
                    RespImplementacion2X = frmIncidentesAT.RespImplementacion2X,
                    FechaImplementacion2X = frmIncidentesAT.FechaImplementacion2X,
                    CausasInmediatasTipoC3X = frmIncidentesAT.CausasInmediatasTipoC3X,
                    MedidasIntervencion3X = frmIncidentesAT.MedidasIntervencion3X,
                    TipoF3X = frmIncidentesAT.TipoF3X,
                    RespImplementacion3X = frmIncidentesAT.RespImplementacion3X,
                    FechaImplementacion3X = frmIncidentesAT.FechaImplementacion3X,
                    CausasBasicasTipoC1X = frmIncidentesAT.CausasBasicasTipoC1X,
                    BasicasInmediatas1X = frmIncidentesAT.BasicasInmediatas1X,
                    BasicasF1X = frmIncidentesAT.BasicasF1X,
                    BasicasRespImplementacion1X = frmIncidentesAT.BasicasRespImplementacion1X,
                    BasicasFechaImplementacion1X = frmIncidentesAT.BasicasFechaImplementacion1X,
                    CausasBasicasTipoC2X = frmIncidentesAT.CausasBasicasTipoC2X,
                    BasicasInmediatas2X = frmIncidentesAT.BasicasInmediatas2X,
                    BasicasF2X = frmIncidentesAT.BasicasF2X,
                    BasicasRespImplementacion2X = frmIncidentesAT.BasicasRespImplementacion2X,
                    BasicasFechaImplementacion2X = frmIncidentesAT.BasicasFechaImplementacion2X,
                    CausasBasicasTipoC3X = frmIncidentesAT.CausasBasicasTipoC3X,
                    BasicasInmediatas3X = frmIncidentesAT.BasicasInmediatas3X,
                    BasicasF3X = frmIncidentesAT.BasicasF3X,
                    BasicasRespImplementacion3X = frmIncidentesAT.BasicasRespImplementacion3X,
                    BasicasFechaImplementacion3X = frmIncidentesAT.BasicasFechaImplementacion3X,
                    boTipoF1X = frmIncidentesAT.boTipoF1X,
                    boTipoM1X = frmIncidentesAT.boTipoM1X,
                    boTipoT1X = frmIncidentesAT.boTipoT1X,
                    boTipoF2X = frmIncidentesAT.boTipoF2X,
                    boTipoM2X = frmIncidentesAT.boTipoM2X,
                    boTipoT2X = frmIncidentesAT.boTipoT2X,
                    boTipoF3X = frmIncidentesAT.boTipoF3X,
                    boTipoM3X = frmIncidentesAT.boTipoM3X,
                    boTipoT3X = frmIncidentesAT.boTipoT3X,
                    boBasicasF1X = frmIncidentesAT.boBasicasF1X,
                    boBasicasM1X = frmIncidentesAT.boBasicasM1X,
                    boBasicasT1X = frmIncidentesAT.boBasicasT1X,
                    boBasicasF2X = frmIncidentesAT.boBasicasF2X,
                    boBasicasM2X = frmIncidentesAT.boBasicasM2X,
                    boBasicasT2X = frmIncidentesAT.boBasicasT2X,
                    boBasicasF3X = frmIncidentesAT.boBasicasF3X,
                    boBasicasM3X = frmIncidentesAT.boBasicasM3X,
                    boBasicasT3X = frmIncidentesAT.boBasicasT3X,
                    BasicasT3X = frmIncidentesAT.BasicasT3X,
                    myFile10 = frmIncidentesAT.hmyFile10,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT10.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT10;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT11
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT11(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT11.Where(x => x.FK_incidentes_AT11 == frmIncidentesAT.PK_Incidentes_AT_Id11).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT11.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT11 incidentes = new IncidentesAT11()
                {
                    FK_incidentes_AT11 = frmIncidentesAT.PK_Incidentes_AT_Id11,
                    FechaRemisionXI = frmIncidentesAT.FechaRemisionXI,
                    NoFoliosXI = frmIncidentesAT.NoFoliosXI,
                    TipoIdentificacionXI = frmIncidentesAT.TipoIdentificacionXI,
                    NumeroIdentificacionXI = frmIncidentesAT.NumeroIdentificacionXI,
                    NombresXI = frmIncidentesAT.NombresXI,
                    CargoXI = frmIncidentesAT.RecomendacionesCargoXI,
                    RecomendacionesARLXI = frmIncidentesAT.RecomendacionesARLXI,
                    RemisionInformeARLXI = frmIncidentesAT.RemisionInformeARLXI,
                    RemisionMinisterioTrabajoXI = frmIncidentesAT.RemisionMinisterioTrabajoXI,
                    RecomendacionesCargoXI = frmIncidentesAT.RecomendacionesCargoXI,
                    NitEmpresa = usuarioActual.NitEmpresa,
                    myFile11 = frmIncidentesAT.hmyFile11
                };

                db.Tbl_IncidentesAT11.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT11;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT12
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT12(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT12.Where(x => x.FK_incidentes_AT12 == frmIncidentesAT.PK_Incidentes_AT_Id12).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT12.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT12 incidentes = new IncidentesAT12()
                {
                    FK_incidentes_AT12 = frmIncidentesAT.PK_Incidentes_AT_Id12,
                    TipoIdentificacionXII = frmIncidentesAT.TipoIdentificacionXII,
                    NumeroIdentificacionXII = frmIncidentesAT.NumeroIdentificacionXII,
                    NombresXII = frmIncidentesAT.NombresXII,
                    CargoXII = frmIncidentesAT.CargoXII,
                    MedidasIntervencionXII = frmIncidentesAT.MedidasIntervencionXII,
                    ObservacionesXII = frmIncidentesAT.ObservacionesXII,
                    FechaVerificacionXII = frmIncidentesAT.FechaVerificacionXII,
                    myFile12 = frmIncidentesAT.hmyFile12,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT12.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT12;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT13
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteAT13(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                var incidente_at = db.Tbl_IncidentesAT13.Where(x => x.FK_incidentes_AT13 == frmIncidentesAT.PK_Incidentes_AT_Id13).SingleOrDefault();
                if (incidente_at != null)
                {
                    db.Tbl_IncidentesAT13.Remove(incidente_at);
                    db.SaveChanges();
                }

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesAT13 incidentes = new IncidentesAT13()
                {
                    FK_incidentes_AT13 = frmIncidentesAT.PK_Incidentes_AT_Id13,
                    TipoIdentificacionXIII = frmIncidentesAT.TipoIdentificacionXIII,
                    NombresXIII = frmIncidentesAT.NombresXIII,
                    NumeroIdentificacionXIII = frmIncidentesAT.NumeroIdentificacionXIII,
                    MedidasIntervencionXIII = frmIncidentesAT.MedidasIntervencionXIII,
                    FechaVerificacionXIII = frmIncidentesAT.FechaVerificacionXIII,
                    ObservacionesXIII = frmIncidentesAT.ObservacionesXIII,
                    myFile13 = frmIncidentesAT.hmyFile13,
                    CargoXIII = frmIncidentesAT.CargoXIII,
                    NitEmpresa = usuarioActual.NitEmpresa
                };

                db.Tbl_IncidentesAT13.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_AT13;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Obteniendo parametros del formulario IncidentesAT13
        /// </summary>
        /// <param name="frmIncidentesAT"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GuardarIncidenteATAnexos(IncidentesATModel frmIncidentesAT)
        {
            int pk_incidentes = 0;
            using (var Transaction = db.Database.BeginTransaction())
            {
                //var incidente_at = db.Tbl_IncidentesATAnexos.Where(x => x.FK_incidentes_ATAnexos == frmIncidentesAT.PK_Incidentes_ATAnexos).SingleOrDefault();
                //if (incidente_at != null)
                //{
                //    db.Tbl_IncidentesATAnexos.Remove(incidente_at);
                //    db.SaveChanges();
                //}

                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                IncidentesATAnexos incidentes = new IncidentesATAnexos()
                {
                    FK_incidentes_ATAnexos = frmIncidentesAT.PK_Incidentes_ATAnexos,
                    AnexoFechaIncidente = frmIncidentesAT.AnexoFechaIncidente,
                    AnexoFechaTestimonio = frmIncidentesAT.AnexoFechaTestimonio,
                    AnexoTipoIdentificacion = frmIncidentesAT.AnexoTipoIdentificacion,
                    AnexoNumIdentificacion = frmIncidentesAT.AnexoNumIdentificacion,
                    AnexoNombres = frmIncidentesAT.AnexoNombres,
                    AnexoCargo = frmIncidentesAT.AnexoCargo,
                    AnexoDondeSucedio = frmIncidentesAT.AnexoDondeSucedio,
                    AnexoPrevenir = frmIncidentesAT.AnexoPrevenir,
                    AnexoAdicionar = frmIncidentesAT.AnexoAdicionar,
                    AnexoFirma = frmIncidentesAT.AnexoFirma,
                    myFile14 = frmIncidentesAT.myFile14,
                    NitEmpresa = usuarioActual.NitEmpresa,
                };

                db.Tbl_IncidentesATAnexos.Add(incidentes);
                db.SaveChanges();
                Transaction.Commit();
                pk_incidentes = incidentes.PK_Incidentes_ATAnexos;
            }

            return Json(pk_incidentes, JsonRequestBehavior.AllowGet);
        }

        #endregion

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
                                datos.fechaNacimiento = FormatDatesI(datos.fechaNacimiento);
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

        [HttpPost]
        public JsonResult GetTipoLesion(int PK_Tipo_De_Lesion)
        {
            TipoLesion objTipoLesion = db.Tbl_Tipo_De_Lesion.Where(x => x.PK_Tipo_De_Lesion == PK_Tipo_De_Lesion).SingleOrDefault();
            if (objTipoLesion != null)
                return Json(objTipoLesion.Descripcion_Tipo_De_Lesion, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetMecanismo(int PK_Mecanismo)
        {
            Mecanismo objMecanismo = db.Tbl_Mecanismo.Where(x => x.PK_Mecanismo == PK_Mecanismo).SingleOrDefault();
            if (objMecanismo != null)
                return Json(objMecanismo.Descripcion_Mecanismo, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetAgente(int PK_Agente)
        {
            Agente objAgente = db.Tbl_Agente.Where(x => x.PK_Agente == PK_Agente).SingleOrDefault();
            if (objAgente != null)
                return Json(objAgente.Descripcion_Agente, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetParteCuerpo(int PK_PDCA_Corto)
        {
            PDCACorto objPDCACorto = db.Tbl_PDCA_Corto.Where(x => x.PK_PDCA_Corto == PK_PDCA_Corto).SingleOrDefault();
            if (objPDCACorto != null)
                return Json(objPDCACorto.Descripcion_PDCA_Corto, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFactoresPersonales(int PK_FactoresPersonales)
        {
            FactoresPersonales objFactoresPersonales = db.Tbl_FactoresPersonales.Where(x => x.PK_FactoresPersonales == PK_FactoresPersonales).SingleOrDefault();
            if (objFactoresPersonales != null)
                return Json(objFactoresPersonales.Descripcion_FP, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetFactoresTrabajo(int PK_Factores_De_Trabajo)
        {
            FactoresDeTrabajo objFactoresDeTrabajo = db.Tbl_Factores_De_Trabajo.Where(x => x.PK_Factores_De_Trabajo == PK_Factores_De_Trabajo).SingleOrDefault();
            if (objFactoresDeTrabajo != null)
                return Json(objFactoresDeTrabajo.Descripcion_FDT, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetActosSubestandar(int PK_Actos_Subestandar)
        {
            ActosSubestandar objActosSubestandar = db.Tbl_Actos_Subestandar.Where(x => x.PK_Actos_Subestandar == PK_Actos_Subestandar).SingleOrDefault();
            if (objActosSubestandar != null)
                return Json(objActosSubestandar.Descripcion_AS, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetCondicionesAmbientales(int PK_Condiciones_Ambientales_Subestandar)
        {
            CondicionesAmbientalesSubestandar objCondicionesAmbientalesSubestandar = db.Tbl_Condiciones_Ambientales_Subestandar.Where(x => x.PK_Condiciones_Ambientales_Subestandar == PK_Condiciones_Ambientales_Subestandar).SingleOrDefault();
            if (objCondicionesAmbientalesSubestandar != null)
                return Json(objCondicionesAmbientalesSubestandar.Descripcion_CAS, JsonRequestBehavior.AllowGet);
            else
                return Json("0", JsonRequestBehavior.AllowGet);
        }

    }
}