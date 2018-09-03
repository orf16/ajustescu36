using Newtonsoft.Json;
using RestSharp;
using Rotativa;
using SG_SST.Controllers.Base;
using SG_SST.Dtos.Empresas;
using SG_SST.Helpers;
using SG_SST.Models;
using SG_SST.Models.AdminUsuarios;
using SG_SST.Models.Incidentes;
using SG_SST.Models.Login;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace SG_SST.Controllers.ReportesIncidentes
{

    public class ReportesIncidentesController : BaseController
    {
        private SG_SSTContext db = new SG_SSTContext();
        //
        // GET: /ReportesIncidentes/

        /// <summary>
        /// Obtiene los datos de sesion asociados a un usuario
        /// </summary>
        /// <returns></returns>
        public UsuarioSessionModel ObtenerUsuarioEnSesion(HttpContext context)
        {
            System.Web.HttpContext.Current = context;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Session["UsuarioSession"] != null
                && !String.IsNullOrWhiteSpace(System.Web.HttpContext.Current.Session["UsuarioSession"].ToString()))
            {
                var datosUsuario = DesEncriptar(System.Web.HttpContext.Current.Session["UsuarioSession"].ToString());
                var usuario = JsonConvert.DeserializeObject<UsuarioSessionModel>(datosUsuario);
                return usuario;
            }
            else
                return null;
        }


        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

        public string ObtenerNombreDeptoById(int pk_id_depto)
        {
            var depto = db.Tbl_Departamento.Where(x => x.Pk_Id_Departamento == pk_id_depto).SingleOrDefault();
            return depto.Nombre_Departamento;
        }

        public string ObtenerNombreMunicipioById(int pk_id_mncpio)
        {
            var municipio = db.Tbl_Municipio.Where(x => x.Pk_Id_Municipio == pk_id_mncpio).SingleOrDefault();
            return municipio.Nombre_Municipio;
        }

        public string ObtenerCodigoDeptoByName(string name_depto)
        {
            var depto = db.Tbl_Departamento.Where(x => x.Nombre_Departamento == name_depto).SingleOrDefault();
            return depto.Codigo_Departamento;
        }

        public string ObtenerCodigoMunicipioByName(string name_mncpio)
        {

            var municipio = db.Tbl_Municipio.Where(x => x.Nombre_Municipio == name_mncpio).SingleOrDefault();
            return municipio.Codigo_Municipio;
        }

        public string TipoIncidente(int valor)
        {
            string TipoIncidente = string.Empty;
            switch (valor)
            {
                case 1: TipoIncidente = "Violencia";
                    break;
                case 2: TipoIncidente = "Tránsito";
                    break;
                case 3: TipoIncidente = "Deportivo";
                    break;
                case 4: TipoIncidente = "Recreativo o cultural";
                    break;
                case 5: TipoIncidente = "Propios del trabajo";
                    break;
                default: return string.Empty;
            }

            return TipoIncidente;
        }

        public ActionResult ReporteIncidenteAT(IncidentesATModel model)
        {
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult GenerarATPDF(int pk_id_incidente)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            var incidentesmodel = new IncidentesATModel();
            var incidentesat = db.Tbl_IncidentesAT1.Where(x => x.PK_Incidentes_AT == pk_id_incidente).SingleOrDefault();
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
            var incidentesatAnexos = db.Tbl_IncidentesATAnexos.Where(x => (x.FK_incidentes_ATAnexos == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).ToList();

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
                incidentesmodel.st_DepartamentoI = ObtenerNombreDeptoById(incidentesat1.pk_DepartamentoI);
                incidentesmodel.st_MunicipioI = ObtenerNombreMunicipioById(incidentesat1.pk_MunicipioI);

                incidentesmodel.cod_DepartamentoI = this.ObtenerCodigoDeptoByName(incidentesmodel.st_DepartamentoI);
                incidentesmodel.cod_MunicipioI = this.ObtenerCodigoMunicipioByName(incidentesmodel.st_MunicipioI);

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

                incidentesmodel.st_DepartamentoII = respuesta[0].departamento;
                incidentesmodel.st_MunicipioII = respuesta[0].municipio;
                incidentesmodel.cod_DepartamentoII = this.ObtenerCodigoDeptoByName(respuesta[0].departamento);
                incidentesmodel.cod_MunicipioII = this.ObtenerCodigoMunicipioByName(respuesta[0].municipio);

                incidentesmodel.codActividadII = respuesta[0].actividadEconomica;
                incidentesmodel.st_DeptoCentroCostoII = ObtenerNombreDeptoById(incidentesat2.pk_DeptoCentroCostoII);
                incidentesmodel.st_MncpioCentroCostoII = ObtenerNombreMunicipioById(incidentesat2.pk_MncpioCentroCostoII);
                incidentesmodel.cod_DeptoCentroCostoII = this.ObtenerCodigoDeptoByName(incidentesmodel.st_DeptoCentroCostoII);
                incidentesmodel.cod_MncpioCentroCostoII = this.ObtenerCodigoMunicipioByName(incidentesmodel.st_MncpioCentroCostoII);

                incidentesmodel.CodigoActividadEconomicaII = incidentesat2.CodigoActEconoCentroTrabajoII;
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat3 != null)
            {
                var clientes = new RestSharp.RestClient(ConfigurationManager.AppSettings["Url"]);
                var requests = new RestRequest(consultaAfiliadoEmpresaActivo, RestSharp.Method.GET);
                requests.RequestFormat = DataFormat.Xml;
                requests.Parameters.Clear();
                requests.AddParameter("tpEm", "NI");
                requests.AddParameter("docEm", usuarioActual.NitEmpresa);
                requests.AddParameter("tpAfiliado", "CC");
                requests.AddParameter("docAfiliado", incidentesat3.NumeroIdentificacionIII);
                requests.AddHeader("Content-Type", "application/json");
                requests.AddHeader("Accept", "application/json");
                //se omite la validación de certificado de SSL
                ServicePointManager.ServerCertificateValidationCallback = delegate
                { return true; };
                IRestResponse<List<EmpresaAfiliadoModel>> responses = cliente.Execute<List<EmpresaAfiliadoModel>>(requests);
                var results = responses.Content;
                var respuestas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmpresaAfiliadoModel>>(results);
                incidentesmodel.boTipoVinculacionIII = incidentesat3.boTipoVinculacionIII;
                incidentesmodel.tempTipoIdentificacionIII = respuestas[0].tipoDoc;
                incidentesmodel.NumeroIdentificacionIII = incidentesat3.NumeroIdentificacionIII;
                incidentesmodel.PrimerApellidoIII = incidentesat3.PrimerApellidoIII;
                incidentesmodel.SegundoApellidoIII = incidentesat3.SegundoApellidoIII;
                incidentesmodel.PrimerNombreIII = incidentesat3.PrimerNombreIII;
                incidentesmodel.FechaNacimientoIII = incidentesat3.FechaNacimientoIII;
                incidentesmodel.DepartamentoIII = incidentesat3.DepartamentoIII;
                incidentesmodel.MunicipioIII = incidentesat3.MunicipioIII;

                incidentesmodel.cod_DepartamentoIII = this.ObtenerCodigoDeptoByName(incidentesmodel.DepartamentoIII);
                incidentesmodel.cod_MunicipioIII = this.ObtenerCodigoMunicipioByName(incidentesmodel.MunicipioIII);


                incidentesmodel.SexoIII = respuestas[0].sexoPersona;
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
                incidentesmodel.CodigoOcupacionIII = respuestas[0].idOcupacion.ToString();

                incidentesmodel.cod_EPSIII = respuestas[0].idEps.ToString();
                incidentesmodel.cod_AFPIII = respuestas[0].idAfp.ToString();
                incidentesmodel.cod_ARLIII = respuestas[0].idArl.ToString();
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat4 != null)
            {
                incidentesmodel.FechaOcurrenciaIV = incidentesat4.FechaOcurrenciaIV;
                incidentesmodel.HoraOcurrenciaIV = incidentesat4.HoraOcurrenciaIV;
                incidentesmodel.boJornadaIV = incidentesat4.boJornadaIV;
                incidentesmodel.boDiaSemanaIV = incidentesat4.boDiaSemanaIV;
                incidentesmodel.LaborHabitualIV = incidentesat4.LaborHabitualIV;

                incidentesmodel.TipoIncidenteIV = this.TipoIncidente(int.Parse(incidentesat4.TipoIncidenteIV));
                incidentesmodel.EspecTipoIncidenteIV = incidentesat4.EspecTipoIncidenteIV;
                incidentesmodel.IPSAtendioIV = incidentesat4.IPSAtendioIV;
                incidentesmodel.ZonaIV = incidentesat4.ZonaIV;
                incidentesmodel.TiempoLaboradoPrevioIV = incidentesat4.TiempoLaboradoPrevioIV;
                incidentesmodel.LugarExactoIV = incidentesat4.LugarExactoIV;
                incidentesmodel.SitioExactoIV = incidentesat4.SitioExactoIV;
                incidentesmodel.OtroSitioIV = incidentesat4.OtroSitioIV;
                incidentesmodel.EspecifiqueIV = incidentesat4.EspecifiqueIV;

                incidentesmodel.str_DepartamentoIV = this.ObtenerNombreDeptoById(incidentesat4.pk_DepartamentoIV);
                incidentesmodel.str_MncpioIV = this.ObtenerNombreMunicipioById(incidentesat4.pk_MncpioIV);

                incidentesmodel.cod_DepartamentoIV = this.ObtenerCodigoDeptoByName(incidentesmodel.str_DepartamentoIV);
                incidentesmodel.cod_MncpioIV = this.ObtenerCodigoMunicipioByName(incidentesmodel.str_MncpioIV);


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
                
                incidentesmodel.TiempoUsoVI = incidentesat6.TiempoUsoVI;
                incidentesmodel.TiempoUsoVIA = incidentesat6.TiempoUsoVIA;
                incidentesmodel.FechaMantenimientoVI = incidentesat6.FechaMantenimientoVI;
                incidentesmodel.ReparadoVI = incidentesat6.ReparadoVI;

                incidentesmodel.VelocidadVI = incidentesat6.VelocidadVI;
                incidentesmodel.VelocidadUnidadMedidaVI = incidentesat6.VelocidadUnidadMedidaVI;

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
                
            }
            ///////////////////////////////////////////////////////////////////////
            if (incidentesat7 != null)
            {
                incidentesmodel.CodTipoLesionVII = incidentesat7.CodTipoLesionVII;
                incidentesmodel.TipoLesionVII = this.GetTipoLesion(int.Parse(incidentesat7.CodTipoLesionVII));
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
                incidentesmodel.DescripcionAnalisisIX = incidentesat9.DescripcionAnalisisIX;

                incidentesmodel.TipoIdentJefeInmediantoIX = incidentesat9.TipoIdentJefeInmediantoIX;
                incidentesmodel.NumIdentJefeInmediatoIX = incidentesat9.NumIdentJefeInmediatoIX;
                incidentesmodel.JefeInmediatoNombresIX = incidentesat9.JefeInmediatoNombresIX;
                incidentesmodel.JefeInmediatoCargoIX = incidentesat9.JefeInmediatoCargoIX;
                
                
                incidentesmodel.TipoIdentEncargadoPSOIX = incidentesat9.TipoIdentEncargadoPSOIX;
                incidentesmodel.NumIdentPSOIX = incidentesat9.NumIdentPSOIX;
                incidentesmodel.EncargadoPSONombresIX = incidentesat9.EncargadoPSONombresIX;
                incidentesmodel.EncargadoPSOCargoIX = incidentesat9.EncargadoPSOCargoIX;
                
                incidentesmodel.TipoIdentCOPASOIX = incidentesat9.TipoIdentCOPASOIX;
                incidentesmodel.COPASONumIdentIX = incidentesat9.COPASONumIdentIX;
                incidentesmodel.COPASONombresCompletosIX = incidentesat9.COPASONombresCompletosIX;
                incidentesmodel.COPASOCargoIX = incidentesat9.COPASOCargoIX;

                incidentesmodel.TipoIdentBrigadistaIX = incidentesat9.TipoIdentBrigadistaIX;
                incidentesmodel.NumeroIdentBrigadistaIX = incidentesat9.NumeroIdentBrigadistaIX;
                incidentesmodel.BrigadistaNombresIX = incidentesat9.BrigadistaNombresIX;
                incidentesmodel.BrigadistaCargoIX = incidentesat9.BrigadistaCargoIX;

                incidentesmodel.TipoIdentParticipanteIX = incidentesat9.TipoIdentParticipanteIX;
                incidentesmodel.NumIdentParticipanteIX = incidentesat9.NumIdentParticipanteIX;
                incidentesmodel.ParticipanteNombreIX = incidentesat9.ParticipanteNombreIX;
                incidentesmodel.ParticipanteCargoIX = incidentesat9.ParticipanteCargoIX;

                incidentesmodel.TipoIdentRepresentanteARLIX = incidentesat9.TipoIdentRepresentanteARLIX;
                incidentesmodel.RepresentanteARLNombresIX = incidentesat9.RepresentanteARLNombresIX;
                incidentesmodel.NumIdentRepresentanteARLIXIX = incidentesat9.NumIdentRepresentanteARLIXIX;
                
                incidentesmodel.TipoIdentEspecialistaSGSSTIX = incidentesat9.TipoIdentEspecialistaSGSSTIX;
                incidentesmodel.EspecialistaSGSSTNombresIX = incidentesat9.EspecialistaSGSSTNombresIX;
                incidentesmodel.NumIdentEspecialistaSGSSTIX = incidentesat9.NumIdentEspecialistaSGSSTIX;


                incidentesmodel.EmpresaRepresentaIX = incidentesat9.EmpresaRepresentaIX;
                incidentesmodel.ObservacionEspecialistaIX = incidentesat9.ObservacionEspecialistaIX;

               
               
                
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
                incidentesmodel.hmyFile10 = incidentesat10.myFile10;

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
            //if (incidentesatAnexos.Count > 0 )
            //{
                incidentesmodel.incidentesatAnexos = incidentesatAnexos;
            //}
            //////////////////////////////////////////////////////////////////////
            var footurl = "https://alissta.gov.co/Acciones/Footer";
            //string cusomtSwitches = string.Format("--footer-line --print-media-type --allow {0} --footer-html {0}", footurl);
            return new Rotativa.PartialViewAsPdf("ReporteIncidenteAT", incidentesmodel) { FileName = "ReporteIncidenteAT.pdf" };
        }


        public string GetTipoLesion(int PK_Tipo_De_Lesion)
        {
            TipoLesion objTipoLesion = db.Tbl_Tipo_De_Lesion.Where(x => x.PK_Tipo_De_Lesion == PK_Tipo_De_Lesion).SingleOrDefault();
            if (objTipoLesion != null)
                return objTipoLesion.Descripcion_Tipo_De_Lesion;
            else
                return "0";

        }


        public string GetMecanismo(int PK_Mecanismo)
        {
            Mecanismo objMecanismo = db.Tbl_Mecanismo.Where(x => x.PK_Mecanismo == PK_Mecanismo).SingleOrDefault();
            if (objMecanismo != null)
                return objMecanismo.Descripcion_Mecanismo;
            else
                return "0";
        
        }


        public string GetAgente(int PK_Agente)
        {
            Agente objAgente = db.Tbl_Agente.Where(x => x.PK_Agente == PK_Agente).SingleOrDefault();
            if (objAgente != null)
                return objAgente.Descripcion_Agente;
            else
                return "0";
        
        }


        public string GetParteCuerpo(int PK_PDCA_Corto)
        {
            PDCACorto objPDCACorto = db.Tbl_PDCA_Corto.Where(x => x.PK_PDCA_Corto == PK_PDCA_Corto).SingleOrDefault();
            if (objPDCACorto != null)
                return objPDCACorto.Descripcion_PDCA_Corto;
            else
                return "0";
        }


        public string GetFactoresPersonales(int PK_FactoresPersonales)
        {
            FactoresPersonales objFactoresPersonales = db.Tbl_FactoresPersonales.Where(x => x.PK_FactoresPersonales == PK_FactoresPersonales).SingleOrDefault();
            if (objFactoresPersonales != null)
                return objFactoresPersonales.Descripcion_FP;
            else
                return "0";
        }

        public string GetFactoresTrabajo(int PK_Factores_De_Trabajo)
        {
            FactoresDeTrabajo objFactoresDeTrabajo = db.Tbl_Factores_De_Trabajo.Where(x => x.PK_Factores_De_Trabajo == PK_Factores_De_Trabajo).SingleOrDefault();
            if (objFactoresDeTrabajo != null)
                return objFactoresDeTrabajo.Descripcion_FDT;
            else
                return "0";
        }


        public string GetActosSubestandar(int PK_Actos_Subestandar)
        {
            ActosSubestandar objActosSubestandar = db.Tbl_Actos_Subestandar.Where(x => x.PK_Actos_Subestandar == PK_Actos_Subestandar).SingleOrDefault();
            if (objActosSubestandar != null)
                return objActosSubestandar.Descripcion_AS;
            else
                return "0";

        }


        public string GetCondicionesAmbientales(int PK_Condiciones_Ambientales_Subestandar)
        {
            CondicionesAmbientalesSubestandar objCondicionesAmbientalesSubestandar = db.Tbl_Condiciones_Ambientales_Subestandar.Where(x => x.PK_Condiciones_Ambientales_Subestandar == PK_Condiciones_Ambientales_Subestandar).SingleOrDefault();
            if (objCondicionesAmbientalesSubestandar != null)
                return objCondicionesAmbientalesSubestandar.Descripcion_CAS;
            else
                return "0";
        
        }





        [AllowAnonymous]
        public ActionResult ReporteIncidenteEL(int pk_id_incidente)
        {
            var incidentesmodel = new IncidentesELModel();
            var incidentesatel = db.Tbl_IncidentesEL1.Where(x => x.PK_Incidentes_EL == pk_id_incidente).SingleOrDefault();
            //var incidentesatel2 = db.Tbl_IncidentesEL2.Where(x => x.FK_incidentes_EL2 == pk_id_incidente).SingleOrDefault();
            if (incidentesatel == null)
            {
                return Json(incidentesatel, JsonRequestBehavior.AllowGet);
            }

            /*incidentesmodel.PK_Incidentes_EL_Id = pk_id_incidente;
            incidentesmodel.EnfLabCalificadaI = incidentesatel.EnfLabCalificadaI;
            incidentesmodel.FechaInvestigacionI = incidentesatel.FechaInvestigacionI.ToString("dd/MM/yyyy");
            incidentesmodel.HoraInicioI = incidentesatel.HoraInicioI;
            incidentesmodel.HoraFinI = incidentesatel.HoraFinI;
            string pk_DepartamentoI = incidentesatel.DepartamentoI.ToString();
            incidentesmodel.pk_DepartamentoI = int.Parse(pk_DepartamentoI);
            string pk_MunicipioI = incidentesatel.MunicipioI.ToString();
            incidentesmodel.pk_MunicipioI = int.Parse(pk_MunicipioI);
            incidentesmodel.DireccionI = incidentesatel.DireccionI;
            incidentesmodel.NombresApellidosI = incidentesatel.NombresApellidosI;
            incidentesmodel.ProfesionalI = incidentesatel.ProfesionalI;
            incidentesmodel.NoLicenciaI = incidentesatel.NoLicenciaI;
            incidentesmodel.FotografiasI = incidentesatel.FotografiasI;
            incidentesmodel.VideosI = incidentesatel.VideosI;
            incidentesmodel.CintasAudioI = incidentesatel.CintasAudioI;
            incidentesmodel.IlustracionesI = incidentesatel.IlustracionesI;
            incidentesmodel.DiagramasI = incidentesatel.DiagramasI;
            incidentesmodel.OtrosCualesI = incidentesatel.OtrosCualesI;
            incidentesmodel.TempEmpleadorII = incidentesatel.EmpleadorII;
            incidentesmodel.CodActividadII = incidentesatel.CodActividadII;
            incidentesmodel.ActividadPrincipalII = incidentesatel.ActividadPrincipalII;
            incidentesmodel.RazonSocialII = incidentesatel.RazonSocialII;
            incidentesmodel.TipoIdentificacionII = incidentesatel.TipoIdentificacionII;
            incidentesmodel.NumIdentificacionII = incidentesatel.NumIdentificacionII;
            incidentesmodel.DireccionPrincipalII = incidentesatel.DireccionPrincipalII;
            incidentesmodel.TelefonoPpalII = incidentesatel.TelefonoPpalII;
            incidentesmodel.FaxII = incidentesatel.FaxII;
            incidentesmodel.DeptoPpalII = incidentesatel.DeptoPpalII;
            incidentesmodel.McpioPpalII = incidentesatel.McpioPpalII;
            incidentesmodel.EmailII = incidentesatel.EmailII;
            incidentesmodel.ZonaPpalII = incidentesatel.ZonaPpalII;
            incidentesmodel.CentroTrabajoPpalII = incidentesatel.CentroTrabajoPpalII;
            incidentesmodel.CentroCostoTelefonoII = incidentesatel.CentroCostoTelefonoII;
            incidentesmodel.CentroCostoFaxII = incidentesatel.CentroCostoFaxII;
            incidentesmodel.CodActEconoPpalII = incidentesatel.CodActEconoPpalII;
            incidentesmodel.ActEconoCentroTrabajoII = incidentesatel.ActEconoCentroTrabajoII;



            string DeptoEmpleadorII = incidentesatel.DeptoEmpleadorII.ToString();
            incidentesmodel.pk_DeptoEmpleadorII = int.Parse(DeptoEmpleadorII);
            string McpioEmpleadorII = incidentesatel.McpioEmpleadorII.ToString();
            incidentesmodel.pk_McpioEmpleadorII = int.Parse(McpioEmpleadorII);
            incidentesmodel.EmailEmpleadorII = incidentesatel.EmailEmpleadorII;
            incidentesmodel.ZonaEmpleadorII = incidentesatel.ZonaEmpleadorII;


            //incidentesmodel.pk_DeptoCentroTrabajoII = incidentesatel.DeptoCentroTrabajoII;
            //incidentesmodel.pk_McpioCentroTrabajoII = int.Parse(McpioCentroTrabajoII);
            
            
            
            incidentesmodel.PlantaIII = incidentesatel.PlantaIII;
            incidentesmodel.MisionIII = incidentesatel.MisionIII;
            incidentesmodel.CooperadorIII = incidentesatel.CooperadorIII;
            incidentesmodel.EstudianteIII = incidentesatel.EstudianteIII;
            incidentesmodel.IndependienteIII = incidentesatel.IndependienteIII;
            incidentesmodel.TempTipoIdentificacionIII = incidentesatel.TipoIdentificacionIII;
            incidentesmodel.NumIdentificacionIII = incidentesatel.NumIdentificacionIII;
            incidentesmodel.PrimerApellidoIII = incidentesatel.PrimerApellidoIII;
            incidentesmodel.SegundoApellidoIII = incidentesatel.SegundoApellidoIII;
            incidentesmodel.PrimerNombreIII = incidentesatel.PrimerNombreIII;
            incidentesmodel.SegundoNombreIII = incidentesatel.SegundoNombreIII;
            incidentesmodel.FechaNacimientoIII = incidentesatel.FechaNacimientoIII;
            incidentesmodel.SexoIII = incidentesatel.SexoIII;
            incidentesmodel.EPSAfiliadoIII = incidentesatel.EPSAfiliadoIII;
            incidentesmodel.AFPAfiliadoIII = incidentesatel.AFPAfiliadoIII;
            incidentesmodel.ARLAfiliadoIII = incidentesatel.ARLAfiliadoIII;
            incidentesmodel.TelefonoIII = incidentesatel.TelefonoIII;
            incidentesmodel.FaxIII = incidentesatel.FaxIII;
            incidentesmodel.EmailTrabajadorIII = incidentesatel.EmailTrabajadorIII;
            incidentesmodel.DireccionTrabajadorIII = incidentesatel.DireccionTrabajadorIII;
            incidentesmodel.ZonaIII = incidentesatel.ZonaIII;
            incidentesmodel.CargoIV = incidentesatel.CargoIV;
            incidentesmodel.AntiguedadCargoAIV = incidentesatel.AntiguedadCargoAIV;
            incidentesmodel.AntiguedadCargoMIV = incidentesatel.AntiguedadCargoMIV;
            incidentesmodel.CodOcupacionIV = incidentesatel.CodOcupacionIV;
            incidentesmodel.OcupacionHabitualIV = incidentesatel.OcupacionHabitualIV;
            incidentesmodel.FechaMuerteIV = incidentesatel.FechaMuerteIV;
            incidentesmodel.AreaActualIV = incidentesatel.AreaActualIV;
            incidentesmodel.NombreCargoIV = incidentesatel.NombreCargoIV;
            incidentesmodel.AntiguedadCargoAnioIV = incidentesatel.AntiguedadCargoAnioIV;
            incidentesmodel.AntiguedadCargoMesesIV = incidentesatel.AntiguedadCargoMesesIV;
            incidentesmodel.DiurnoIV = incidentesatel.DiurnoIV;
            incidentesmodel.NocturnoIV = incidentesatel.NocturnoIV;
            incidentesmodel.MixtoIV = incidentesatel.MixtoIV;
            incidentesmodel.TurnosIV = incidentesatel.TurnosIV;
            incidentesmodel.CondicionesPuestoTrabajoIV = incidentesatel.CondicionesPuestoTrabajoIV;
            incidentesmodel.TareasCargo1IV = incidentesatel.TareasCargo1IV;
            incidentesmodel.DedicacionJL1IV = incidentesatel.DedicacionJL1IV;
            incidentesmodel.DedicacionJL11IV = incidentesatel.DedicacionJL11IV;
            incidentesmodel.DedicacionJL12IV = incidentesatel.DedicacionJL12IV;
            incidentesmodel.RelacionMuyProbable1IV = incidentesatel.RelacionMuyProbable1IV;
            incidentesmodel.RelacionProbable1IV = incidentesatel.RelacionProbable1IV;
            incidentesmodel.RelacionPocoProbable1IV = incidentesatel.RelacionPocoProbable1IV;
            incidentesmodel.TareasCargo2IV = incidentesatel.TareasCargo2IV;
            incidentesmodel.DedicacionJL21IV = incidentesatel.DedicacionJL21IV;
            incidentesmodel.DedicacionJL22IV = incidentesatel.DedicacionJL22IV;
            incidentesmodel.DedicacionJL23IV = incidentesatel.DedicacionJL23IV;
            incidentesmodel.RelacionMuyProbable2IV = incidentesatel.RelacionMuyProbable2IV;
            incidentesmodel.RelacionProbable2IV = incidentesatel.RelacionProbable2IV;
            incidentesmodel.RelacionPocoProbable2IV = incidentesatel.RelacionPocoProbable2IV;
            incidentesmodel.TareasCargo3IV = incidentesatel.TareasCargo3IV;
            incidentesmodel.DedicacionJL31IV = incidentesatel.DedicacionJL31IV;
            incidentesmodel.DedicacionJL32IV = incidentesatel.DedicacionJL32IV;
            incidentesmodel.DedicacionJL33IV = incidentesatel.DedicacionJL33IV;
            incidentesmodel.RelacionMuyProbable3IV = incidentesatel.RelacionMuyProbable3IV;
            incidentesmodel.RelacionProbable3IV = incidentesatel.RelacionProbable3IV;
            incidentesmodel.RelacionPocoProbable3IV = incidentesatel.RelacionPocoProbable3IV;
            incidentesmodel.TareasCargo4IV = incidentesatel.TareasCargo4IV;
            incidentesmodel.DedicacionJL41IV = incidentesatel.DedicacionJL41IV;
            incidentesmodel.DedicacionJL42IV = incidentesatel.DedicacionJL42IV;
            incidentesmodel.DedicacionJL43IV = incidentesatel.DedicacionJL43IV;
            incidentesmodel.RelacionMuyProbable4IV = incidentesatel.RelacionMuyProbable4IV;
            incidentesmodel.RelacionProbable4IV = incidentesatel.RelacionProbable4IV;
            incidentesmodel.RelacionPocoProbable4IV = incidentesatel.RelacionPocoProbable4IV;
            incidentesmodel.FormacionInformacionIV = incidentesatel.FormacionInformacionIV;
            incidentesmodel.ProteccionColectivaIV = incidentesatel.ProteccionColectivaIV;
            incidentesmodel.EPPIV = incidentesatel.EPPIV;
            incidentesmodel.DisenoPuestoTrabajoIV = incidentesatel.DisenoPuestoTrabajoIV;
            incidentesmodel.tempOrganizacionTrabajoIV = incidentesatel.tempOrganizacionTrabajoIV;
            incidentesmodel.PreventivasIV = incidentesatel.PreventivasIV;
            incidentesmodel.ImplementadasIV = incidentesatel.ImplementadasIV;
            incidentesmodel.DescripcionIV = incidentesatel.DescripcionIV;
            incidentesmodel.CodigoCie1 = incidentesatel.CodigoCie1;
            incidentesmodel.CodigoCie2 = incidentesatel.CodigoCie2;
            incidentesmodel.CodigoCie3 = incidentesatel.CodigoCie3;
            incidentesmodel.CodigoCie4 = incidentesatel.CodigoCie4;
            incidentesmodel.CodigoCie5 = incidentesatel.CodigoCie5;
            incidentesmodel.DiagnosticoIV1 = incidentesatel.DiagnosticoIV1;
            incidentesmodel.DiagnosticoIV2 = incidentesatel.DiagnosticoIV2;
            incidentesmodel.DiagnosticoIV3 = incidentesatel.DiagnosticoIV3;
            incidentesmodel.DiagnosticoIV4 = incidentesatel.DiagnosticoIV4;
            incidentesmodel.FechaOrigenELV = incidentesatel.FechaOrigenELV;
            incidentesmodel.OrigenLaboralIV = incidentesatel.OrigenLaboralIV;
            incidentesmodel.NoTrabajadoresV = incidentesatel.NoTrabajadoresV;
            incidentesmodel.CargosSimilaresV = incidentesatel.CargosSimilaresV;
            incidentesmodel.NombresApellidosV2 = incidentesatel.NombresApellidosV2;
            incidentesmodel.NombresApellidosV3 = incidentesatel.NombresApellidosV3;
            incidentesmodel.NombresApellidosV4 = incidentesatel.NombresApellidosV4;
            incidentesmodel.AnioDiagnosticoV1 = incidentesatel.AnioDiagnosticoV1;
            incidentesmodel.AnioDiagnosticoV2 = incidentesatel.AnioDiagnosticoV2;
            incidentesmodel.AnioDiagnosticoV3 = incidentesatel.AnioDiagnosticoV3;
            incidentesmodel.AnioDiagnosticoV4 = incidentesatel.AnioDiagnosticoV4;
            incidentesmodel.PuestoEmpresaVI1 = incidentesatel.PuestoEmpresaVI1;
            incidentesmodel.AgentesBiologicosVI1 = incidentesatel.AgentesBiologicosVI1;
            incidentesmodel.FrasesVI1 = incidentesatel.FrasesVI1;
            incidentesmodel.RutinariaVI1 = incidentesatel.RutinariaVI1;
            incidentesmodel.NORutinariaVI1 = incidentesatel.NORutinariaVI1;
            incidentesmodel.TiempoExposicionMesesVI1 = incidentesatel.TiempoExposicionMesesVI1;
            incidentesmodel.TiempoExposicionHorasVI1 = incidentesatel.TiempoExposicionHorasVI1;
            incidentesmodel.TLVCorregidoVI1 = incidentesatel.TLVCorregidoVI1;
            incidentesmodel.ConcentracionHalladaVI1 = incidentesatel.ConcentracionHalladaVI1;
            incidentesmodel.FechaMediacionDiaV1 = incidentesatel.FechaMediacionDiaV1;
            incidentesmodel.FechaMediaMesV1 = incidentesatel.FechaMediaMesV1;
            incidentesmodel.FechaMediaAnioV1 = incidentesatel.FechaMediaAnioV1;
            incidentesmodel.NivelRiesgoV1 = incidentesatel.NivelRiesgoV1;
            incidentesmodel.ViaEntradaV1 = incidentesatel.ViaEntradaV1;
            incidentesmodel.PuestoEmpresaVI2 = incidentesatel.PuestoEmpresaVI2;
            incidentesmodel.AgentesBiologicosVI2 = incidentesatel.AgentesBiologicosVI2;
            incidentesmodel.FrasesVI2 = incidentesatel.FrasesVI2;
            incidentesmodel.RutinariaVI2 = incidentesatel.RutinariaVI2;
            incidentesmodel.NORutinariaVI2 = incidentesatel.NORutinariaVI2;
            incidentesmodel.TiempoExposicionMesesVI2 = incidentesatel.TiempoExposicionMesesVI2;
            incidentesmodel.TiempoExposicionHorasVI2 = incidentesatel.TiempoExposicionHorasVI2;
            incidentesmodel.TLVCorregidoVI2 = incidentesatel.TLVCorregidoVI2;
            incidentesmodel.ConcentracionHalladaVI2 = incidentesatel.ConcentracionHalladaVI2;
            incidentesmodel.FechaMediacionDiaV2 = incidentesatel.FechaMediacionDiaV2;
            incidentesmodel.FechaMediaMesV2 = incidentesatel.FechaMediaMesV2;
            incidentesmodel.FechaMediaAnioV2 = incidentesatel.FechaMediaAnioV2;
            incidentesmodel.NivelRiesgoV2 = incidentesatel.NivelRiesgoV2;
            incidentesmodel.ViaEntradaV2 = incidentesatel.ViaEntradaV2;
            incidentesmodel.PuestoEmpresaVI3 = incidentesatel.PuestoEmpresaVI3;
            incidentesmodel.AgentesBiologicosVI3 = incidentesatel.AgentesBiologicosVI3;
            incidentesmodel.FrasesVI3 = incidentesatel.FrasesVI3;
            incidentesmodel.RutinariaVI3 = incidentesatel.RutinariaVI3;
            incidentesmodel.NORutinariaVI3 = incidentesatel.NORutinariaVI3;
            incidentesmodel.TiempoExposicionMesesVI3 = incidentesatel.TiempoExposicionMesesVI3;
            incidentesmodel.TiempoExposicionHorasVI3 = incidentesatel.TiempoExposicionHorasVI3;
            incidentesmodel.TLVCorregidoVI3 = incidentesatel.TLVCorregidoVI3;
            incidentesmodel.ConcentracionHalladaVI3 = incidentesatel.ConcentracionHalladaVI3;
            incidentesmodel.FechaMediacionDiaV3 = incidentesatel.FechaMediacionDiaV3;
            incidentesmodel.FechaMediaMesV3 = incidentesatel.FechaMediaMesV3;
            incidentesmodel.FechaMediaAnioV3 = incidentesatel.FechaMediaAnioV3;
            incidentesmodel.NivelRiesgoV3 = incidentesatel.NivelRiesgoV3;
            incidentesmodel.ViaEntradaV3 = incidentesatel.ViaEntradaV3;
            incidentesmodel.PuestoEmpresaVI4 = incidentesatel.PuestoEmpresaVI4;
            incidentesmodel.AgentesBiologicosVI4 = incidentesatel.AgentesBiologicosVI4;
            incidentesmodel.FrasesVI4 = incidentesatel.FrasesVI4;
            incidentesmodel.RutinariaVI4 = incidentesatel.RutinariaVI4;
            incidentesmodel.NORutinariaVI4 = incidentesatel.NORutinariaVI4;
            incidentesmodel.TiempoExposicionMesesVI4 = incidentesatel.TiempoExposicionMesesVI4;
            incidentesmodel.TiempoExposicionHorasVI4 = incidentesatel.TiempoExposicionHorasVI4;
            incidentesmodel.TLVCorregidoVI4 = incidentesatel.TLVCorregidoVI4;
            incidentesmodel.ConcentracionHalladaVI4 = incidentesatel.ConcentracionHalladaVI4;
            incidentesmodel.FechaMediacionDiaVI4 = incidentesatel.FechaMediacionDiaVI4;
            incidentesmodel.FechaMediaMesVI4 = incidentesatel.FechaMediaMesVI4;
            incidentesmodel.FechaMediaAnioVI4 = incidentesatel.FechaMediaAnioVI4;
            incidentesmodel.NivelRiesgoVI4 = incidentesatel.NivelRiesgoVI4;
            incidentesmodel.ViaEntradaVI4 = incidentesatel.ViaEntradaVI4;
            incidentesmodel.OficioEmpresa2V1 = incidentesatel.OficioEmpresa2V1;
            incidentesmodel.AgenteRelBiologico2VI = incidentesatel.AgenteRelBiologico2VI;
            incidentesmodel.FuenteAgente2VI1 = incidentesatel.FuenteAgente2VI1;
            incidentesmodel.MecanismoTransmicion2VI1 = incidentesatel.MecanismoTransmicion2VI1;
            incidentesmodel.TipoActividadRutinaria2VI1 = incidentesatel.TipoActividadRutinaria2VI1;
            incidentesmodel.TipoActividadNoRutinaria2VI1 = incidentesatel.TipoActividadNoRutinaria2VI1;
            incidentesmodel.TiempoExposicionMeses2VI1 = incidentesatel.TiempoExposicionMeses2VI1;
            incidentesmodel.TiempoExposicionHoras2VI1 = incidentesatel.TiempoExposicionHoras2VI1;
            incidentesmodel.ConcentracionHallada2VI1 = incidentesatel.ConcentracionHallada2VI1;
            incidentesmodel.NivelRiesgo2VI1 = incidentesatel.NivelRiesgo2VI1;
            incidentesmodel.Dia2VI1 = incidentesatel.Dia2VI1;
            incidentesmodel.Mes2VI1 = incidentesatel.Mes2VI1;
            incidentesmodel.Anio2VI1 = incidentesatel.Anio2VI1;
            incidentesmodel.FrecRiesgo2VI1 = incidentesatel.FrecRiesgo2VI1;
            incidentesmodel.OficioEmpresa2V2 = incidentesatel.OficioEmpresa2V2;
            incidentesmodel.AgenteRelBiologico2VI2 = incidentesatel.AgenteRelBiologico2VI2;
            incidentesmodel.FuenteAgente2VI2 = incidentesatel.FuenteAgente2VI2;
            incidentesmodel.MecanismoTransmicion2VI2 = incidentesatel.MecanismoTransmicion2VI2;
            incidentesmodel.TipoActividadRutinaria2VI2 = incidentesatel.TipoActividadRutinaria2VI2;
            incidentesmodel.TipoActividadNoRutinaria2VI2 = incidentesatel.TipoActividadNoRutinaria2VI2;
            incidentesmodel.TiempoExposicionMeses2VI2 = incidentesatel.TiempoExposicionMeses2VI2;
            incidentesmodel.TiempoExposicionHoras2VI2 = incidentesatel.TiempoExposicionHoras2VI2;
            incidentesmodel.ConcentracionHallada2VI2 = incidentesatel.ConcentracionHallada2VI2;
            incidentesmodel.NivelRiesgo2VI2 = incidentesatel.NivelRiesgo2VI2;
            incidentesmodel.Dia2VI2 = incidentesatel.Dia2VI2;
            incidentesmodel.Mes2VI2 = incidentesatel.Mes2VI2;
            incidentesmodel.Anio2VI2 = incidentesatel.Anio2VI2;
            incidentesmodel.FrecRiesgo2VI2 = incidentesatel.FrecRiesgo2VI2;
            incidentesmodel.OficioEmpresa2V3 = incidentesatel.OficioEmpresa2V3;
            incidentesmodel.AgenteRelBiologico2VI3 = incidentesatel.AgenteRelBiologico2VI3;
            incidentesmodel.FuenteAgente2VI3 = incidentesatel.FuenteAgente2VI3;
            incidentesmodel.MecanismoTransmicion2VI3 = incidentesatel.MecanismoTransmicion2VI3;
            incidentesmodel.TipoActividadRutinaria2VI3 = incidentesatel.TipoActividadRutinaria2VI3;
            incidentesmodel.TipoActividadNoRutinaria2VI3 = incidentesatel.TipoActividadNoRutinaria2VI3;
            incidentesmodel.TiempoExposicionMeses2VI3 = incidentesatel.TiempoExposicionMeses2VI3;
            incidentesmodel.TiempoExposicionHoras2VI3 = incidentesatel.TiempoExposicionHoras2VI3;
            incidentesmodel.ConcentracionHallada2VI3 = incidentesatel.ConcentracionHallada2VI3;
            incidentesmodel.NivelRiesgo2VI3 = incidentesatel.NivelRiesgo2VI3;
            incidentesmodel.Dia2VI3 = incidentesatel.Dia2VI3;
            incidentesmodel.Mes2VI3 = incidentesatel.Mes2VI3;
            incidentesmodel.Anio2VI3 = incidentesatel.Anio2VI3;
            incidentesmodel.FrecRiesgo2VI3 = incidentesatel.FrecRiesgo2VI3;
            incidentesmodel.OficioEmpresa2V4 = incidentesatel.OficioEmpresa2V4;
            incidentesmodel.AgenteRelBiologico2VI4 = incidentesatel.AgenteRelBiologico2VI4;
            incidentesmodel.FuenteAgente2VI4 = incidentesatel.FuenteAgente2VI4;
            incidentesmodel.MecanismoTransmicion2VI4 = incidentesatel.MecanismoTransmicion2VI4;
            incidentesmodel.TipoActividadRutinaria2VI4 = incidentesatel.TipoActividadRutinaria2VI4;
            incidentesmodel.TipoActividadNoRutinaria2VI4 = incidentesatel.TipoActividadNoRutinaria2VI4;
            incidentesmodel.TiempoExposicionMeses2VI4 = incidentesatel.TiempoExposicionMeses2VI4;
            incidentesmodel.TiempoExposicionHoras2VI4 = incidentesatel.TiempoExposicionHoras2VI4;
            incidentesmodel.ConcentracionHallada2VI4 = incidentesatel.ConcentracionHallada2VI4;
            incidentesmodel.NivelRiesgo2VI4 = incidentesatel.NivelRiesgo2VI4;
            incidentesmodel.Dia2VI4 = incidentesatel.Dia2VI4;
            incidentesmodel.Mes2VI4 = incidentesatel.Mes2VI4;
            incidentesmodel.Anio2VI4 = incidentesatel.Anio2VI4;
            incidentesmodel.FrecRiesgo2VI4 = incidentesatel.FrecRiesgo2VI4;
            incidentesmodel.ExpoAccidentales2VI = incidentesatel.ExpoAccidentales2VI;
            incidentesmodel.CargoOficioPuesto3VI = incidentesatel.CargoOficioPuesto3VI;
            incidentesmodel.Fuentes3VI = incidentesatel.Fuentes3VI;
            incidentesmodel.Meses3VI = incidentesatel.Meses3VI;
            incidentesmodel.HorasDia3VI = incidentesatel.HorasDia3VI;
            incidentesmodel.NivelAmbiental3VI = incidentesatel.NivelAmbiental3VI;
            incidentesmodel.FMDia3VI = incidentesatel.FMDia3VI;
            incidentesmodel.FMMes3VI = incidentesatel.FMMes3VI;
            incidentesmodel.FMAnio3VI = incidentesatel.FMAnio3VI;
            incidentesmodel.DosisRuido3VI = incidentesatel.DosisRuido3VI;
            incidentesmodel.FecMedDia3VI = incidentesatel.FecMedDia3VI;
            incidentesmodel.FecMedMes3VI = incidentesatel.FecMedMes3VI;
            incidentesmodel.FecMEdAnio3VI = incidentesatel.FecMEdAnio3VI;
            incidentesmodel.ExpSusQuimimcas3VI = incidentesatel.ExpSusQuimimcas3VI;
            incidentesmodel.ExpoAccPrevias3VI = incidentesatel.ExpoAccPrevias3VI;
            incidentesmodel.CargoOficioPuesto3VI1 = incidentesatel.CargoOficioPuesto3VI1;
            incidentesmodel.Fuentes3VI1 = incidentesatel.Fuentes3VI1;
            incidentesmodel.Meses3VI1 = incidentesatel.Meses3VI1;
            incidentesmodel.HorasDia3VI1 = incidentesatel.HorasDia3VI1;
            incidentesmodel.NivelAmbiental3VI1 = incidentesatel.NivelAmbiental3VI1;
            incidentesmodel.FMDia3VI1 = incidentesatel.FMDia3VI1;
            incidentesmodel.FMMes3VI1 = incidentesatel.FMMes3VI1;
            incidentesmodel.FMAnio3VI1 = incidentesatel.FMAnio3VI1;
            incidentesmodel.DosisRuido3VI1 = incidentesatel.DosisRuido3VI1;
            incidentesmodel.FecMedDia3VI1 = incidentesatel.FecMedDia3VI1;
            incidentesmodel.FecMedMes3VI1 = incidentesatel.FecMedMes3VI1;
            incidentesmodel.FecMEdAnio3VI1 = incidentesatel.FecMEdAnio3VI1;
            incidentesmodel.ExpSusQuimimcas3VI1 = incidentesatel.ExpSusQuimimcas3VI1;
            incidentesmodel.ExpoAccPrevias3VI1 = incidentesatel.ExpoAccPrevias3VI1;
            incidentesmodel.CargoOficioPuesto3VI2 = incidentesatel.CargoOficioPuesto3VI2;
            incidentesmodel.Fuentes3VI2 = incidentesatel.Fuentes3VI2;
            incidentesmodel.Meses3VI2 = incidentesatel.Meses3VI2;
            incidentesmodel.HorasDia3VI2 = incidentesatel.HorasDia3VI2;
            incidentesmodel.NivelAmbiental3VI2 = incidentesatel.NivelAmbiental3VI2;
            incidentesmodel.FMDia3VI2 = incidentesatel.FMDia3VI2;
            incidentesmodel.FMMes3VI2 = incidentesatel.FMMes3VI2;
            incidentesmodel.FMAnio3VI2 = incidentesatel.FMAnio3VI2;
            incidentesmodel.DosisRuido3VI2 = incidentesatel.DosisRuido3VI2;
            incidentesmodel.FecMedDia3VI2 = incidentesatel.FecMedDia3VI2;
            incidentesmodel.FecMedMes3VI2 = incidentesatel.FecMedMes3VI2;
            incidentesmodel.FecMEdAnio3VI2 = incidentesatel.FecMEdAnio3VI2;
            incidentesmodel.ExpSusQuimimcas3VI2 = incidentesatel.ExpSusQuimimcas3VI2;
            incidentesmodel.ExpoAccPrevias3VI2 = incidentesatel.ExpoAccPrevias3VI2;
            incidentesmodel.CargoOficioPuesto3VI3 = incidentesatel.CargoOficioPuesto3VI3;
            incidentesmodel.Fuentes3VI3 = incidentesatel.Fuentes3VI3;
            incidentesmodel.Meses3VI3 = incidentesatel.Meses3VI3;
            incidentesmodel.HorasDia3VI3 = incidentesatel.HorasDia3VI3;
            incidentesmodel.NivelAmbiental3VI3 = incidentesatel.NivelAmbiental3VI3;
            incidentesmodel.FMDia3VI3 = incidentesatel.FMDia3VI3;
            incidentesmodel.FMMes3VI3 = incidentesatel.FMMes3VI3;
            incidentesmodel.FMAnio3VI3 = incidentesatel.FMAnio3VI3;
            incidentesmodel.DosisRuido3VI3 = incidentesatel.DosisRuido3VI3;
            incidentesmodel.FecMedDia3VI3 = incidentesatel.FecMedDia3VI3;
            incidentesmodel.FecMedMes3VI3 = incidentesatel.FecMedMes3VI3;
            incidentesmodel.FecMEdAnio3VI3 = incidentesatel.FecMEdAnio3VI3;
            incidentesmodel.ExpSusQuimimcas3VI3 = incidentesatel.ExpSusQuimimcas3VI3;
            incidentesmodel.ExpoAccPrevias3VI3 = incidentesatel.ExpoAccPrevias3VI3;
            incidentesmodel.CargoOficio4VI1 = incidentesatel.CargoOficio4VI1;
            incidentesmodel.DescActividad4VI1 = incidentesatel.DescActividad4VI1;
            incidentesmodel.Duracion4VI1 = incidentesatel.Duracion4VI1;
            incidentesmodel.FrecActividad4VI1 = incidentesatel.FrecActividad4VI1;
            incidentesmodel.TipoTrabajoActividad4VI1 = incidentesatel.TipoTrabajoActividad4VI1;
            incidentesmodel.WBTG4VI1 = incidentesatel.WBTG4VI1;
            incidentesmodel.TipoExpMeses4VI1 = incidentesatel.TipoExpMeses4VI1;
            incidentesmodel.TipoExpHD4VI1 = incidentesatel.TipoExpHD4VI1;
            incidentesmodel.TasaTrabajo4VI1 = incidentesatel.TasaTrabajo4VI1;
            incidentesmodel.FechaMedDia4VI1 = incidentesatel.FechaMedDia4VI1;
            incidentesmodel.FechaMedMes4VI1 = incidentesatel.FechaMedMes4VI1;
            incidentesmodel.FechaMedAnio4VI1 = incidentesatel.FechaMedAnio4VI1;
            incidentesmodel.CargoOficio4VI2 = incidentesatel.CargoOficio4VI2;
            incidentesmodel.DescActividad4VI2 = incidentesatel.DescActividad4VI2;
            incidentesmodel.Duracion4VI2 = incidentesatel.Duracion4VI2;
            incidentesmodel.FrecActividad4VI2 = incidentesatel.FrecActividad4VI2;
            incidentesmodel.TipoTrabajoActividad4VI2 = incidentesatel.TipoTrabajoActividad4VI2;
            incidentesmodel.WBTG4VI2 = incidentesatel.WBTG4VI2;
            incidentesmodel.TipoExpMeses4VI2 = incidentesatel.TipoExpMeses4VI2;
            incidentesmodel.TipoExpHD4VI2 = incidentesatel.TipoExpHD4VI2;
            incidentesmodel.TasaTrabajo4VI2 = incidentesatel.TasaTrabajo4VI2;
            incidentesmodel.FechaMedDia4VI2 = incidentesatel.FechaMedDia4VI2;
            incidentesmodel.FechaMedMes4VI2 = incidentesatel.FechaMedMes4VI2;
            incidentesmodel.FechaMedAnio4VI2 = incidentesatel.FechaMedAnio4VI2;
            incidentesmodel.CargoOficio4VI3 = incidentesatel.CargoOficio4VI3;
            incidentesmodel.DescActividad4VI3 = incidentesatel.DescActividad4VI3;
            incidentesmodel.Duracion4VI3 = incidentesatel.Duracion4VI3;
            incidentesmodel.FrecActividad4VI3 = incidentesatel.FrecActividad4VI3;
            incidentesmodel.TipoTrabajoActividad4VI3 = incidentesatel.TipoTrabajoActividad4VI3;
            incidentesmodel.WBTG4VI3 = incidentesatel.WBTG4VI3;
            incidentesmodel.TipoExpMeses4VI3 = incidentesatel.TipoExpMeses4VI3;
            incidentesmodel.TipoExpHD4VI3 = incidentesatel.TipoExpHD4VI3;
            incidentesmodel.TasaTrabajo4VI3 = incidentesatel.TasaTrabajo4VI3;
            incidentesmodel.FechaMedDia4VI3 = incidentesatel.FechaMedDia4VI3;
            incidentesmodel.FechaMedMes4VI3 = incidentesatel.FechaMedMes4VI3;
            incidentesmodel.FechaMedAnio4VI3 = incidentesatel.FechaMedAnio4VI3;
            incidentesmodel.CargoOficio4VI4 = incidentesatel.CargoOficio4VI4;
            incidentesmodel.DescActividad4VI4 = incidentesatel.DescActividad4VI4;
            incidentesmodel.Duracion4VI4 = incidentesatel.Duracion4VI4;
            incidentesmodel.FrecActividad4VI4 = incidentesatel.FrecActividad4VI4;
            incidentesmodel.TipoTrabajoActividad4VI4 = incidentesatel.TipoTrabajoActividad4VI4;
            incidentesmodel.WBTG4VI4 = incidentesatel.WBTG4VI4;
            incidentesmodel.TipoExpMeses4VI4 = incidentesatel.TipoExpMeses4VI4;
            incidentesmodel.TipoExpHD4VI4 = incidentesatel.TipoExpHD4VI4;
            incidentesmodel.TasaTrabajo4VI4 = incidentesatel.TasaTrabajo4VI4;
            incidentesmodel.FechaMedDia4VI4 = incidentesatel.FechaMedDia4VI4;
            incidentesmodel.FechaMedMes4VI4 = incidentesatel.FechaMedMes4VI4;
            incidentesmodel.FechaMedAnio4VI4 = incidentesatel.FechaMedAnio4VI4;
            incidentesmodel.RadCargoEmpresa5VI1 = incidentesatel2.RadCargoEmpresa5VI1;
            incidentesmodel.RadDescripcionFuente5VI1 = incidentesatel2.RadDescripcionFuente5VI1;
            incidentesmodel.RadDescripcionAct5VI1 = incidentesatel2.RadDescripcionAct5VI1;
            incidentesmodel.RadCondiciones5VI1 = incidentesatel2.RadCondiciones5VI1;
            incidentesmodel.RadTEDia5VI1 = incidentesatel2.RadTEDia5VI1;
            incidentesmodel.RadTEMes5VI1 = incidentesatel2.RadTEMes5VI1;
            incidentesmodel.RadTEAnio5VI1 = incidentesatel2.RadTEAnio5VI1;
            incidentesmodel.RadEvalAmbiental5VI1 = incidentesatel2.RadEvalAmbiental5VI1;
            incidentesmodel.RadFMDia5VI1 = incidentesatel2.RadFMDia5VI1;
            incidentesmodel.RadFMMes5VI1 = incidentesatel2.RadFMMes5VI1;
            incidentesmodel.RadFMAnio5VI1 = incidentesatel2.RadFMAnio5VI1;
            incidentesmodel.RadCargoEmpresa5VI2 = incidentesatel2.RadCargoEmpresa5VI2;
            incidentesmodel.RadDescripcionFuente5VI2 = incidentesatel2.RadDescripcionFuente5VI2;
            incidentesmodel.RadDescripcionAct5VI2 = incidentesatel2.RadDescripcionAct5VI2;
            incidentesmodel.RadCondiciones5VI2 = incidentesatel2.RadCondiciones5VI2;
            incidentesmodel.RadTEDia5VI2 = incidentesatel2.RadTEDia5VI2;
            incidentesmodel.RadTEMes5VI2 = incidentesatel2.RadTEMes5VI2;
            incidentesmodel.RadTEAnio5VI2 = incidentesatel2.RadTEAnio5VI2;
            incidentesmodel.RadEvalAmbiental5VI2 = incidentesatel2.RadEvalAmbiental5VI2;
            incidentesmodel.RadFMDia5VI2 = incidentesatel2.RadFMDia5VI2;
            incidentesmodel.RadFMMes5VI2 = incidentesatel2.RadFMMes5VI2;
            incidentesmodel.RadFMAnio5VI2 = incidentesatel2.RadFMAnio5VI2;
            incidentesmodel.RadCargoEmpresa5VI3 = incidentesatel2.RadCargoEmpresa5VI3;
            incidentesmodel.RadDescripcionFuente5VI3 = incidentesatel2.RadDescripcionFuente5VI3;
            incidentesmodel.RadDescripcionAct5VI3 = incidentesatel2.RadDescripcionAct5VI3;
            incidentesmodel.RadCondiciones5VI3 = incidentesatel2.RadCondiciones5VI3;
            incidentesmodel.RadTEDia5VI3 = incidentesatel2.RadTEDia5VI3;
            incidentesmodel.RadTEMes5VI3 = incidentesatel2.RadTEMes5VI3;
            incidentesmodel.RadTEAnio5VI3 = incidentesatel2.RadTEAnio5VI3;
            incidentesmodel.RadEvalAmbiental5VI3 = incidentesatel2.RadEvalAmbiental5VI3;
            incidentesmodel.RadFMDia5VI3 = incidentesatel2.RadFMDia5VI3;
            incidentesmodel.RadFMMes5VI3 = incidentesatel2.RadFMMes5VI3;
            incidentesmodel.RadFMAnio5VI3 = incidentesatel2.RadFMAnio5VI3;
            incidentesmodel.RadCargoEmpresa5VI4 = incidentesatel2.RadCargoEmpresa5VI4;
            incidentesmodel.RadDescripcionFuente5VI4 = incidentesatel2.RadDescripcionFuente5VI4;
            incidentesmodel.RadDescripcionAct5VI4 = incidentesatel2.RadDescripcionAct5VI4;
            incidentesmodel.RadCondiciones5VI4 = incidentesatel2.RadCondiciones5VI4;
            incidentesmodel.RadTEDia5VI4 = incidentesatel2.RadTEDia5VI4;
            incidentesmodel.RadTEMes5VI4 = incidentesatel2.RadTEMes5VI4;
            incidentesmodel.RadTEAnio5V4 = incidentesatel2.RadTEAnio5V4;
            incidentesmodel.RadEvalAmbiental5VI4 = incidentesatel2.RadEvalAmbiental5VI4;
            incidentesmodel.RadFMDia5VI4 = incidentesatel2.RadFMDia5VI4;
            incidentesmodel.RadFMMes5VI4 = incidentesatel2.RadFMMes5VI4;
            incidentesmodel.RadFMAnio5VI4 = incidentesatel2.RadFMAnio5VI4;
            incidentesmodel.VibCargoEmpresa6VI1 = incidentesatel2.VibCargoEmpresa6VI1;
            incidentesmodel.VibDescFuente6VI1 = incidentesatel2.VibDescFuente6VI1;
            incidentesmodel.BooTipoVibCE6VI1 = incidentesatel2.BooTipoVibCE6VI1;
            incidentesmodel.BooTipoVibMB6VI1 = incidentesatel2.BooTipoVibMB6VI1;
            incidentesmodel.TiempoExpMeses6VI1 = incidentesatel2.TiempoExpMeses6VI1;
            incidentesmodel.TiempoExpHD6VI1 = incidentesatel2.TiempoExpHD6VI1;
            incidentesmodel.VCE6VI1 = incidentesatel2.VCE6VI1;
            incidentesmodel.VMB6VI1 = incidentesatel2.VMB6VI1;
            incidentesmodel.AceTotal6VI1 = incidentesatel2.AceTotal6VI1;
            incidentesmodel.EjeDominante6VI1 = incidentesatel2.EjeDominante6VI1;
            incidentesmodel.AceEjeDominante6VI1 = incidentesatel2.AceEjeDominante6VI1;
            incidentesmodel.Frecuencia6VI1 = incidentesatel2.Frecuencia6VI1;
            incidentesmodel.Aceleracion6VI1 = incidentesatel2.Aceleracion6VI1;
            incidentesmodel.FechaMedDia6VI1 = incidentesatel2.FechaMedDia6VI1;
            incidentesmodel.FechaMedMes6VI1 = incidentesatel2.FechaMedMes6VI1;
            incidentesmodel.FechaMedAnio6VI1 = incidentesatel2.FechaMedAnio6VI1;
            incidentesmodel.BooExpoRuido6VI1 = incidentesatel2.BooExpoRuido6VI1;
            incidentesmodel.VibCargoEmpresa6VI2 = incidentesatel2.VibCargoEmpresa6VI2;
            incidentesmodel.VibDescFuente6VI2 = incidentesatel2.VibDescFuente6VI2;
            incidentesmodel.BooTipoVibCE6VI2 = incidentesatel2.BooTipoVibCE6VI2;
            incidentesmodel.BooTipoVibMB6VI2 = incidentesatel2.BooTipoVibMB6VI2;
            incidentesmodel.TiempoExpMeses6VI2 = incidentesatel2.TiempoExpMeses6VI2;
            incidentesmodel.TiempoExpHD6VI2 = incidentesatel2.TiempoExpHD6VI2;
            incidentesmodel.VCE6VI2 = incidentesatel2.VCE6VI2;
            incidentesmodel.VMB6VI2 = incidentesatel2.VMB6VI2;
            incidentesmodel.AceTotal6VI2 = incidentesatel2.AceTotal6VI2;
            incidentesmodel.EjeDominante6VI2 = incidentesatel2.EjeDominante6VI2;
            incidentesmodel.AceEjeDominante6VI2 = incidentesatel2.AceEjeDominante6VI2;
            incidentesmodel.Frecuencia6VI2 = incidentesatel2.Frecuencia6VI2;
            incidentesmodel.Aceleracion6VI2 = incidentesatel2.Aceleracion6VI2;
            incidentesmodel.FechaMedDia6VI2 = incidentesatel2.FechaMedDia6VI2;
            incidentesmodel.FechaMedMes6VI2 = incidentesatel2.FechaMedMes6VI2;
            incidentesmodel.FechaMedAnio6VI2 = incidentesatel2.FechaMedAnio6VI2;
            incidentesmodel.BooExpoRuido6VI2 = incidentesatel2.BooExpoRuido6VI2;
            incidentesmodel.VibCargoEmpresa6VI3 = incidentesatel2.VibCargoEmpresa6VI3;
            incidentesmodel.VibDescFuente6VI3 = incidentesatel2.VibDescFuente6VI3;
            incidentesmodel.BooTipoVibCE6VI3 = incidentesatel2.BooTipoVibCE6VI3;
            incidentesmodel.BooTipoVibMB6VI3 = incidentesatel2.BooTipoVibMB6VI3;
            incidentesmodel.TiempoExpMeses6VI3 = incidentesatel2.TiempoExpMeses6VI3;
            incidentesmodel.TiempoExpHD6VI3 = incidentesatel2.TiempoExpHD6VI3;
            incidentesmodel.VCE6VI3 = incidentesatel2.VCE6VI3;
            incidentesmodel.VMB6VI3 = incidentesatel2.VMB6VI3;
            incidentesmodel.AceTotal6VI3 = incidentesatel2.AceTotal6VI3;
            incidentesmodel.EjeDominante6VI3 = incidentesatel2.EjeDominante6VI3;
            incidentesmodel.AceEjeDominante6VI3 = incidentesatel2.AceEjeDominante6VI3;
            incidentesmodel.Frecuencia6VI3 = incidentesatel2.Frecuencia6VI3;
            incidentesmodel.Aceleracion6VI3 = incidentesatel2.Aceleracion6VI3;
            incidentesmodel.FechaMedDia6VI3 = incidentesatel2.FechaMedDia6VI3;
            incidentesmodel.FechaMedMes6VI3 = incidentesatel2.FechaMedMes6VI3;
            incidentesmodel.FechaMedAnio6VI3 = incidentesatel2.FechaMedAnio6VI3;
            incidentesmodel.BooExpoRuido6VI3 = incidentesatel2.BooExpoRuido6VI3;
            incidentesmodel.VibCargoEmpresa6VI4 = incidentesatel2.VibCargoEmpresa6VI4;
            incidentesmodel.VibDescFuente6VI4 = incidentesatel2.VibDescFuente6VI4;
            incidentesmodel.BooTipoVibCE6VI4 = incidentesatel2.BooTipoVibCE6VI4;
            incidentesmodel.BooTipoVibMB6VI4 = incidentesatel2.BooTipoVibMB6VI4;
            incidentesmodel.TiempoExpMeses6VI4 = incidentesatel2.TiempoExpMeses6VI4;
            incidentesmodel.TiempoExpHD6VI4 = incidentesatel2.TiempoExpHD6VI4;
            incidentesmodel.VCE6VI4 = incidentesatel2.VCE6VI4;
            incidentesmodel.VMB6VI4 = incidentesatel2.VMB6VI4;
            incidentesmodel.AceTotal6VI4 = incidentesatel2.AceTotal6VI4;
            incidentesmodel.EjeDominante6VI4 = incidentesatel2.EjeDominante6VI4;
            incidentesmodel.AceEjeDominante6VI4 = incidentesatel2.AceEjeDominante6VI4;
            incidentesmodel.Frecuencia6VI4 = incidentesatel2.Frecuencia6VI4;
            incidentesmodel.Aceleracion6VI4 = incidentesatel2.Aceleracion6VI4;
            incidentesmodel.FechaMedDia6VI4 = incidentesatel2.FechaMedDia6VI4;
            incidentesmodel.FechaMedMes6VI4 = incidentesatel2.FechaMedMes6VI4;
            incidentesmodel.FechaMedAnio6VI4 = incidentesatel2.FechaMedAnio6VI4;
            incidentesmodel.BooExpoRuido6VI4 = incidentesatel2.BooExpoRuido6VI4;
            incidentesmodel.VibCargoEmpresa6VI5 = incidentesatel2.VibCargoEmpresa6VI5;
            incidentesmodel.VibDescFuente6VI5 = incidentesatel2.VibDescFuente6VI5;
            incidentesmodel.BooTipoVibCE6VI5 = incidentesatel2.BooTipoVibCE6VI5;
            incidentesmodel.BooTipoVibMB6VI5 = incidentesatel2.BooTipoVibMB6VI5;
            incidentesmodel.TiempoExpMeses6VI5 = incidentesatel2.TiempoExpMeses6VI5;
            incidentesmodel.TiempoExpHD6VI5 = incidentesatel2.TiempoExpHD6VI5;
            incidentesmodel.VCE6VI5 = incidentesatel2.VCE6VI5;
            incidentesmodel.VMB6VI5 = incidentesatel2.VMB6VI5;
            incidentesmodel.AceTotal6VI5 = incidentesatel2.AceTotal6VI5;
            incidentesmodel.EjeDominante6VI5 = incidentesatel2.EjeDominante6VI5;
            incidentesmodel.AceEjeDominante6VI5 = incidentesatel2.AceEjeDominante6VI5;
            incidentesmodel.Frecuencia6VI5 = incidentesatel2.Frecuencia6VI5;
            incidentesmodel.Aceleracion6VI5 = incidentesatel2.Aceleracion6VI5;
            incidentesmodel.FechaMedDia6VI5 = incidentesatel2.FechaMedDia6VI5;
            incidentesmodel.FechaMedMes6VI5 = incidentesatel2.FechaMedMes6VI5;
            incidentesmodel.FechaMedAnio6VI5 = incidentesatel2.FechaMedAnio6VI5;
            incidentesmodel.BooExpoRuido6VI5 = incidentesatel2.BooExpoRuido6VI5;
            incidentesmodel.VibCargoEmpresa6VI6 = incidentesatel2.VibCargoEmpresa6VI6;
            incidentesmodel.VibDescFuente6VI6 = incidentesatel2.VibDescFuente6VI6;
            incidentesmodel.BooTipoVibCE6VI6 = incidentesatel2.BooTipoVibCE6VI6;
            incidentesmodel.BooTipoVibMB6VI6 = incidentesatel2.BooTipoVibMB6VI6;
            incidentesmodel.TiempoExpMeses6VI6 = incidentesatel2.TiempoExpMeses6VI6;
            incidentesmodel.TiempoExpHD6VI6 = incidentesatel2.TiempoExpHD6VI6;
            incidentesmodel.VCE6VI6 = incidentesatel2.VCE6VI6;
            incidentesmodel.VMB6VI6 = incidentesatel2.VMB6VI6;
            incidentesmodel.AceTotal6VI6 = incidentesatel2.AceTotal6VI6;
            incidentesmodel.EjeDominante6VI6 = incidentesatel2.EjeDominante6VI6;
            incidentesmodel.AceEjeDominante6VI6 = incidentesatel2.AceEjeDominante6VI6;
            incidentesmodel.Frecuencia6VI6 = incidentesatel2.Frecuencia6VI6;
            incidentesmodel.Aceleracion6VI6 = incidentesatel2.Aceleracion6VI6;
            incidentesmodel.FechaMedDia6VI6 = incidentesatel2.FechaMedDia6VI6;
            incidentesmodel.FechaMedMes6VI6 = incidentesatel2.FechaMedMes6VI6;
            incidentesmodel.FechaMedAnio6VI6 = incidentesatel2.FechaMedAnio6VI6;
            incidentesmodel.BooExpoRuido6VI6 = incidentesatel2.BooExpoRuido6VI6;
            incidentesmodel.DescEventoInv6VI = incidentesatel2.DescEventoInv6VI;
            incidentesmodel.FrecPresAltoVI1 = incidentesatel2.FrecPresAltoVI1;
            incidentesmodel.FrecPresMedioVI1 = incidentesatel2.FrecPresMedioVI1;
            incidentesmodel.FrecPresBajoVI1 = incidentesatel2.FrecPresBajoVI1;
            incidentesmodel.TiempoExpAltoVI1 = incidentesatel2.TiempoExpAltoVI1;
            incidentesmodel.TiempoExpMedioVI1 = incidentesatel2.TiempoExpMedioVI1;
            incidentesmodel.TiempoExpBajoVI1 = incidentesatel2.TiempoExpBajoVI1;
            incidentesmodel.IntensidadAltoVI1 = incidentesatel2.IntensidadAltoVI1;
            incidentesmodel.IntensidadMedioVI1 = incidentesatel2.IntensidadMedioVI1;
            incidentesmodel.IntensidadBajoVI1 = incidentesatel2.IntensidadBajoVI1;
            incidentesmodel.VarPsicoObservacionesVI1 = incidentesatel2.VarPsicoObservacionesVI1;
            incidentesmodel.FrecPresAltoVI2 = incidentesatel2.FrecPresAltoVI2;
            incidentesmodel.FrecPresMedioVI2 = incidentesatel2.FrecPresMedioVI2;
            incidentesmodel.FrecPresBajoVI2 = incidentesatel2.FrecPresBajoVI2;
            incidentesmodel.TiempoExpAltoVI2 = incidentesatel2.TiempoExpAltoVI2;
            incidentesmodel.TiempoExpMedioVI2 = incidentesatel2.TiempoExpMedioVI2;
            incidentesmodel.TiempoExpBajoVI2 = incidentesatel2.TiempoExpBajoVI2;
            incidentesmodel.IntensidadAltoVI2 = incidentesatel2.IntensidadAltoVI2;
            incidentesmodel.IntensidadMedioVI2 = incidentesatel2.IntensidadMedioVI2;
            incidentesmodel.IntensidadBajoVI2 = incidentesatel2.IntensidadBajoVI2;
            incidentesmodel.VarPsicoObservacionesVI2 = incidentesatel2.VarPsicoObservacionesVI2;
            incidentesmodel.FrecPresAltoVI3 = incidentesatel2.FrecPresAltoVI3;
            incidentesmodel.FrecPresMedioVI3 = incidentesatel2.FrecPresMedioVI3;
            incidentesmodel.FrecPresBajoVI3 = incidentesatel2.FrecPresBajoVI3;
            incidentesmodel.TiempoExpAltoVI3 = incidentesatel2.TiempoExpAltoVI3;
            incidentesmodel.TiempoExpMedioVI3 = incidentesatel2.TiempoExpMedioVI3;
            incidentesmodel.TiempoExpBajoVI3 = incidentesatel2.TiempoExpBajoVI3;
            incidentesmodel.IntensidadAltoVI3 = incidentesatel2.IntensidadAltoVI3;
            incidentesmodel.IntensidadMedioVI3 = incidentesatel2.IntensidadMedioVI3;
            incidentesmodel.IntensidadBajoVI3 = incidentesatel2.IntensidadBajoVI3;
            incidentesmodel.VarPsicoObservacionesVI3 = incidentesatel2.VarPsicoObservacionesVI3;
            incidentesmodel.FrecPresAltoVI4 = incidentesatel2.FrecPresAltoVI4;
            incidentesmodel.FrecPresMedioVI4 = incidentesatel2.FrecPresMedioVI4;
            incidentesmodel.FrecPresBajoVI4 = incidentesatel2.FrecPresBajoVI4;
            incidentesmodel.TiempoExpAltoVI4 = incidentesatel2.TiempoExpAltoVI4;
            incidentesmodel.TiempoExpMedioVI4 = incidentesatel2.TiempoExpMedioVI4;
            incidentesmodel.TiempoExpBajoV4 = incidentesatel2.TiempoExpBajoV4;
            incidentesmodel.IntensidadAltoVI4 = incidentesatel2.IntensidadAltoVI4;
            incidentesmodel.IntensidadMedioVI4 = incidentesatel2.IntensidadMedioVI4;
            incidentesmodel.IntensidadBajoVI4 = incidentesatel2.IntensidadBajoVI4;
            incidentesmodel.VarPsicoObservacionesVI4 = incidentesatel2.VarPsicoObservacionesVI4;
            incidentesmodel.IntensidadAltaVI1 = incidentesatel2.IntensidadAltaVI1;
            incidentesmodel.IntensidadMediaVI1 = incidentesatel2.IntensidadMediaVI1;
            incidentesmodel.IntensidadBajaVI1 = incidentesatel2.IntensidadBajaVI1;
            incidentesmodel.IntensidadObservVI1 = incidentesatel2.IntensidadObservVI1;
            incidentesmodel.IntensidadAltaVI2 = incidentesatel2.IntensidadAltaVI2;
            incidentesmodel.IntensidadMediaVI2 = incidentesatel2.IntensidadMediaVI2;
            incidentesmodel.IntensidadBajaVI2 = incidentesatel2.IntensidadBajaVI2;
            incidentesmodel.IntensidadObservVI2 = incidentesatel2.IntensidadObservVI2;
            incidentesmodel.NivelRiesgoLabVI = incidentesatel2.NivelRiesgoLabVI;
            incidentesmodel.NivelRiesgoExtralabVI = incidentesatel2.NivelRiesgoExtralabVI;
            incidentesmodel.NivelRiesgoIndiviVI = incidentesatel2.NivelRiesgoIndiviVI;
            incidentesmodel.NivelEstresVI = incidentesatel2.NivelEstresVI;
            incidentesmodel.BooPostPieProlongada = incidentesatel2.BooPostPieProlongada;
            incidentesmodel.BooPostPieSedente = incidentesatel2.BooPostPieSedente;
            incidentesmodel.BooPosturaIncomodaBrazosManos = incidentesatel2.BooPosturaIncomodaBrazosManos;
            incidentesmodel.BooEsfuerzoBrazosManos = incidentesatel2.BooEsfuerzoBrazosManos;
            incidentesmodel.BooPosturaIncomodaEspalda = incidentesatel2.BooPosturaIncomodaEspalda;
            incidentesmodel.BooLabRepetitivaColumna = incidentesatel2.BooLabRepetitivaColumna;
            incidentesmodel.BooLabRepetitivaBrazoMuMano = incidentesatel2.BooLabRepetitivaBrazoMuMano;
            incidentesmodel.BooPeriodoRecuperacionFisica = incidentesatel2.BooPeriodoRecuperacionFisica;
            incidentesmodel.BooEsfuerzoManos = incidentesatel2.BooEsfuerzoManos;
            incidentesmodel.BooEsfuerzoCuerpo = incidentesatel2.BooEsfuerzoCuerpo;
            incidentesmodel.BooManipulacionCargas = incidentesatel2.BooManipulacionCargas;
            incidentesmodel.DMEResumen = incidentesatel2.DMEResumen;
            incidentesmodel.BooCauRelPrevVI1 = incidentesatel2.BooCauRelPrevVI1;
            incidentesmodel.CauRelPrevVI1 = incidentesatel2.CauRelPrevVI1;
            incidentesmodel.BooCauRelPrevVI2 = incidentesatel2.BooCauRelPrevVI2;
            incidentesmodel.CauRelPrevVI2 = incidentesatel2.CauRelPrevVI2;
            incidentesmodel.BooCauRelPrevVI3 = incidentesatel2.BooCauRelPrevVI3;
            incidentesmodel.CauRelPrevVI3 = incidentesatel2.CauRelPrevVI3;
            incidentesmodel.BooCauRelPrevVI4 = incidentesatel2.BooCauRelPrevVI4;
            incidentesmodel.CauRelPrevVI4 = incidentesatel2.CauRelPrevVI4;
            incidentesmodel.BooCauRelPrevVI5 = incidentesatel2.BooCauRelPrevVI5;
            incidentesmodel.CauRelPrevVI5 = incidentesatel2.CauRelPrevVI5;
            incidentesmodel.BooCauRelPrevVI6 = incidentesatel2.BooCauRelPrevVI6;
            incidentesmodel.CauRelPrevVI6 = incidentesatel2.CauRelPrevVI6;
            incidentesmodel.BooCauRelPrevVI7 = incidentesatel2.BooCauRelPrevVI7;
            incidentesmodel.CauRelPrevVI7 = incidentesatel2.CauRelPrevVI7;
            incidentesmodel.BooCauRelPrevVI8 = incidentesatel2.BooCauRelPrevVI8;
            incidentesmodel.CauRelPrevVI8 = incidentesatel2.CauRelPrevVI8;
            incidentesmodel.BooCauRelPrevVI9 = incidentesatel2.BooCauRelPrevVI9;
            incidentesmodel.CauRelPrevVI9 = incidentesatel2.CauRelPrevVI9;
            incidentesmodel.BooCauRelPrevVI10 = incidentesatel2.BooCauRelPrevVI10;
            incidentesmodel.CauRelPrevVI10 = incidentesatel2.CauRelPrevVI10;
            incidentesmodel.BooCauRelPrevVI11 = incidentesatel2.BooCauRelPrevVI11;
            incidentesmodel.CauRelPrevVI11 = incidentesatel2.CauRelPrevVI11;
            incidentesmodel.BooCauRelPrevVI12 = incidentesatel2.BooCauRelPrevVI12;
            incidentesmodel.CauRelPrevVI12 = incidentesatel2.CauRelPrevVI12;
            incidentesmodel.OtrosDatosInteresVI = incidentesatel2.OtrosDatosInteresVI;
            incidentesmodel.CausasEnfermedadLaboralVI = incidentesatel2.CausasEnfermedadLaboralVI;
            incidentesmodel.MedidasPreventivasVII1 = incidentesatel2.MedidasPreventivasVII1;
            incidentesmodel.ResponsableImplementacionVII1 = incidentesatel2.ResponsableImplementacionVII1;
            incidentesmodel.FechaEjeMesVII1 = incidentesatel2.FechaEjeMesVII1;
            incidentesmodel.FechaEjeDiaVII1 = incidentesatel2.FechaEjeDiaVII1;
            incidentesmodel.MedidasPreventivasVII2 = incidentesatel2.MedidasPreventivasVII2;
            incidentesmodel.ResponsableImplementacionVII2 = incidentesatel2.ResponsableImplementacionVII2;
            incidentesmodel.FechaEjeMesVII3 = incidentesatel2.FechaEjeMesVII3;
            incidentesmodel.FechaEjeDiaVII3 = incidentesatel2.FechaEjeDiaVII3;
            incidentesmodel.MedidasPreventivasVII4 = incidentesatel2.MedidasPreventivasVII4;
            incidentesmodel.ResponsableImplementacionVII4 = incidentesatel2.ResponsableImplementacionVII4;
            incidentesmodel.FechaEjeMesVII4 = incidentesatel2.FechaEjeMesVII4;
            incidentesmodel.FechaEjeDiaVII4 = incidentesatel2.FechaEjeDiaVII4;
            incidentesmodel.MedidasPreventivasVII5 = incidentesatel2.MedidasPreventivasVII5;
            incidentesmodel.ResponsableImplementacionVII5 = incidentesatel2.ResponsableImplementacionVII5;
            incidentesmodel.FechaEjeMesVII5 = incidentesatel2.FechaEjeMesVII5;
            incidentesmodel.FechaEjeDiaVII5 = incidentesatel2.FechaEjeDiaVII5;
            incidentesmodel.MedidasPreventivasVII6 = incidentesatel2.MedidasPreventivasVII6;
            incidentesmodel.ResponsableImplementacionVII6 = incidentesatel2.ResponsableImplementacionVII6;
            incidentesmodel.FechaEjeMesVII6 = incidentesatel2.FechaEjeMesVII6;
            incidentesmodel.FechaEjeDiaVII6 = incidentesatel2.FechaEjeDiaVII6;
            incidentesmodel.MedidasPreventivasVII7 = incidentesatel2.MedidasPreventivasVII7;
            incidentesmodel.ResponsableImplementacionVII7 = incidentesatel2.ResponsableImplementacionVII7;
            incidentesmodel.FechaEjeMesVII7 = incidentesatel2.FechaEjeMesVII7;
            incidentesmodel.FechaEjeDiaVII7 = incidentesatel2.FechaEjeDiaVII7;
            incidentesmodel.MedidasPreventivasVII8 = incidentesatel2.MedidasPreventivasVII8;
            incidentesmodel.ResponsableImplementacionVII8 = incidentesatel2.ResponsableImplementacionVII8;
            incidentesmodel.FechaEjeMesVII8 = incidentesatel2.FechaEjeMesVII8;
            incidentesmodel.FechaEjeDiaVII8 = incidentesatel2.FechaEjeDiaVII8;
            incidentesmodel.tempTipoIdentificacionVIII1 = incidentesatel2.tempTipoIdentificacionVIII1;
            incidentesmodel.JefeInmediatoVIII1 = incidentesatel2.JefeInmediatoVIII1;
            incidentesmodel.CargoVIII1 = incidentesatel2.CargoVIII1;
            incidentesmodel.NumeroIdentificacionVIII1 = incidentesatel2.NumeroIdentificacionVIII1;
            incidentesmodel.tempTipoIdentificacionVIII2 = incidentesatel2.tempTipoIdentificacionVIII2;
            incidentesmodel.JefeInmediatoVIII2 = incidentesatel2.JefeInmediatoVIII2;
            incidentesmodel.CargoVIII2 = incidentesatel2.CargoVIII2;
            incidentesmodel.NumeroIdentificacionVIII2 = incidentesatel2.NumeroIdentificacionVIII2;
            incidentesmodel.tempTipoIdentificacionVIII3 = incidentesatel2.tempTipoIdentificacionVIII3;
            incidentesmodel.JefeInmediatoVIII3 = incidentesatel2.JefeInmediatoVIII3;
            incidentesmodel.CargoVIII3 = incidentesatel2.CargoVIII3;
            incidentesmodel.NumeroIdentificacionVIII3 = incidentesatel2.NumeroIdentificacionVIII3;
            incidentesmodel.tempTipoIdentificacionVIII4 = incidentesatel2.tempTipoIdentificacionVIII4;
            incidentesmodel.JefeInmediatoVIII4 = incidentesatel2.JefeInmediatoVIII4;
            incidentesmodel.CargoVIII4 = incidentesatel2.CargoVIII4;
            incidentesmodel.NumeroIdentificacionVIII4 = incidentesatel2.NumeroIdentificacionVIII4;
            incidentesmodel.tempTipoIdentificacionVIII5 = incidentesatel2.tempTipoIdentificacionVIII5;
            incidentesmodel.JefeInmediatoVIII5 = incidentesatel2.JefeInmediatoVIII5;
            incidentesmodel.CargoVIII5 = incidentesatel2.CargoVIII5;
            incidentesmodel.NumeroIdentificacionVIII5 = incidentesatel2.NumeroIdentificacionVIII5;
            incidentesmodel.tempTipoIdentificacionVIII6 = incidentesatel2.tempTipoIdentificacionVIII6;
            incidentesmodel.JefeInmediatoVIII6 = incidentesatel2.JefeInmediatoVIII6;
            incidentesmodel.CargoVIII6 = incidentesatel2.CargoVIII6;
            incidentesmodel.NumeroIdentificacionVIII6 = incidentesatel2.NumeroIdentificacionVIII6;
            incidentesmodel.tempTipoIdentificacionVIII7 = incidentesatel2.tempTipoIdentificacionVIII7;
            incidentesmodel.EspecialistaOcupacionalVIII = incidentesatel2.EspecialistaOcupacionalVIII;
            incidentesmodel.LicenciaNumVIII1 = incidentesatel2.LicenciaNumVIII1;
            incidentesmodel.LicenciaAnioVIII1 = incidentesatel2.LicenciaAnioVIII1;
            incidentesmodel.NumeroIdentificacionVIII7 = incidentesatel2.NumeroIdentificacionVIII7;
            incidentesmodel.tempTipoIdentificacionVIII8 = incidentesatel2.tempTipoIdentificacionVIII8;
            incidentesmodel.RepresentanteArlVIII8 = incidentesatel2.RepresentanteArlVIII8;
            incidentesmodel.LicenciaNumeroVIII8 = incidentesatel2.LicenciaNumeroVIII8;
            incidentesmodel.LicenciaAnioVIII8 = incidentesatel2.LicenciaAnioVIII8;
            incidentesmodel.NumeroIdentificacionVIII8 = incidentesatel2.NumeroIdentificacionVIII8;
            incidentesmodel.EmpresaRepresentaVIII8 = incidentesatel2.EmpresaRepresentaVIII8;
            incidentesmodel.NitVIII8 = incidentesatel2.NitVIII8;
            incidentesmodel.FechaRemisionIX = incidentesatel2.FechaRemisionIX;
            incidentesmodel.NoFoliosIX = incidentesatel2.NoFoliosIX;
            incidentesmodel.tempTipoIdentificacionIX = incidentesatel2.tempTipoIdentificacionIX;
            incidentesmodel.NombreApellidoIX = incidentesatel2.NombreApellidoIX;
            incidentesmodel.CargoIX = incidentesatel2.CargoIX;
            incidentesmodel.NumeroIdentificacionIX = incidentesatel2.NumeroIdentificacionIX;
            incidentesmodel.FechaRemisionARLIX = incidentesatel2.FechaRemisionARLIX;
            incidentesmodel.FecRemisionTerritorialIX = incidentesatel2.FecRemisionTerritorialIX;
            incidentesmodel.DisponibleRemisionARLIX = incidentesatel2.DisponibleRemisionARLIX;
            incidentesmodel.ResponsablesRemisionARLIX = incidentesatel2.ResponsablesRemisionARLIX;
            incidentesmodel.CargoARLIX = incidentesatel2.CargoARLIX;
            incidentesmodel.tempTipoIdentificacionX = incidentesatel2.tempTipoIdentificacionX;
            incidentesmodel.ResponsableVerficiacionX = incidentesatel2.ResponsableVerficiacionX;
            incidentesmodel.CargoX = incidentesatel2.CargoX;
            incidentesmodel.NumeroIdentificacionX = incidentesatel2.NumeroIdentificacionX;
            incidentesmodel.MedidasIntervencionX = incidentesatel2.MedidasIntervencionX;
            incidentesmodel.ObsevacionesX = incidentesatel2.ObsevacionesX;
            incidentesmodel.FechaVerficacionX = incidentesatel2.FechaVerficacionX;
            incidentesmodel.tempTipoIdentificacionXI = incidentesatel2.tempTipoIdentificacionXI;
            incidentesmodel.ResponsableVerficiacionXI = incidentesatel2.ResponsableVerficiacionXI;
            incidentesmodel.CargoXI = incidentesatel2.CargoXI;
            incidentesmodel.NumeroIdentificacionXI = incidentesatel2.NumeroIdentificacionXI;
            incidentesmodel.MedidasIntervencionXI = incidentesatel2.MedidasIntervencionXI;
            incidentesmodel.ObsevacionesARLXI = incidentesatel2.ObsevacionesARLXI;
            incidentesmodel.FechaVerficacionXI = incidentesatel2.FechaVerficacionXI;
            incidentesmodel.FechaIngresoIV = incidentesatel.FechaIngresoIV;
            incidentesmodel.MurioTrabajadorIV = incidentesatel.MurioTrabajadorIV;*/
            var footurl = "https://alissta.gov.co/Acciones/Footer";
            string cusomtSwitches = string.Format("--footer-line --print-media-type --allow {0} --footer-html {0}", footurl);
            return new Rotativa.PartialViewAsPdf("ReporteIncidenteEL", incidentesmodel) { FileName = "ReporteIncidenteEL.pdf", CustomSwitches = cusomtSwitches };
        }
    }
}