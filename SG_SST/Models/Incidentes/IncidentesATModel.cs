using SG_SST.Models.Empresas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace SG_SST.Models.Incidentes
{
    public class IncidentesATModel
    {
        /// <summary>
        /// I. Informe sobre la Investigacion
        /// </summary>
        /// 
        public int PK_Incidentes_AT_Id1 { get; set; }
        public int PK_Incidentes_AT_Id2 { get; set; }
        public int PK_Incidentes_AT_Id3 { get; set; }
        public int PK_Incidentes_AT_Id4 { get; set; }
        public int PK_Incidentes_AT_Id5 { get; set; }
        public int PK_Incidentes_AT_Id6 { get; set; }
        public int PK_Incidentes_AT_Id7 { get; set; }
        public int PK_Incidentes_AT_Id8 { get; set; }
        public int PK_Incidentes_AT_Id9 { get; set; }
        public int PK_Incidentes_AT_Id10 { get; set; }
        public int PK_Incidentes_AT_Id11 { get; set; }
        public int PK_Incidentes_AT_Id12 { get; set; }
        public int PK_Incidentes_AT_Id13 { get; set; }
        public int PK_Incidentes_ATAnexos { get; set; }

        public HttpPostedFileBase adjuntos { get; set; }
        public string ExplosivosUnidadMedidaV2 { get; set; }
        
        public string boIncidente { get; set; }///REQUERIDO
        public string boIncidente1 { get; set; }///REQUERIDO
        public string boAccidenteTrabajo { get; set; }///REQUERIDO
        public string boLeve { get; set; }///REQUERIDO
        public string boGrave { get; set; }///REQUERIDO
        public string boMortal { get; set; }///REQUERIDO
        public string FechaInvestigacionI { get; set; }///REQUERIDO
        public List<Departamento> DepartamentoI { get; set; }///REQUERIDO
        public int pk_DepartamentoI { get; set; }///REQUERIDO
        public List<Municipio> MunicipioI { get; set; }///REQUERIDO
        public int pk_MunicipioI { get; set; }///REQUERIDO
                                              ///
        public string cod_DepartamentoI { get; set; }///REQUERIDO

        public string cod_MunicipioI { get; set; }///REQUERIDO
        public string DireccionI { get; set; }///REQUERIDO
        public string HoraInicialI { get; set; }///REQUERIDO
        public string HoraFinalI { get; set; }///REQUERIDO
        public string ResponsablesI { get; set; }///REQUERIDO
        public bool FotografiasI { get; set; }///REQUERIDO
        public bool VideosI { get; set; }///REQUERIDO
        public bool CintasAudioI { get; set; }///REQUERIDO
        public bool IlustracionesI { get; set; }///REQUERIDO
        public bool DiagramasI { get; set; }///REQUERIDO
        public bool OtrosI { get; set; }///REQUERIDO
        public string CualesI { get; set; }///REQUERIDO




        /// <summary>
        /// II. Identificacion General del Empleador
        /// </summary>
        /// 
        public string boTipoVinculacionII { get; set; }
        public string TipoIdentificacionII { get; set; }
        public string CodigoActividadEconomicaII { get; set; }
        public string ActividadEconomicaII { get; set; }
        public string NumeroIdentificacionII { get; set; }
        public string NombreRazonSocialII { get; set; }
        public string DireccionPpalII { get; set; }
        public string TelefonoII { get; set; }
        public string FaxII { get; set; }
        public string st_DepartamentoII { get; set; }///REQUERIDO
        public string st_MunicipioII { get; set; }///REQUERIDO
                                                  ///
        public string cod_DepartamentoII { get; set; }///REQUERIDO
        public string cod_MunicipioII { get; set; }///REQUERIDO

        public string EmailII { get; set; }
        public string ZonaUrbanaII { get; set; }
        public bool SedePrincipalII { get; set; }
        public string  ActEconoCentroTrabajoII { get; set; }
        public string CentroCostoTelefonoII { get; set; }
        public string CentroCostoFaxII { get; set; }
        public string DireccionCentroTrabajoII { get; set; }
        public string ZonaII { get; set; }
        public List<Departamento> DeptoCentroCostoII { get; set; }
        public List<Municipio> MncpioCentroCostoII { get; set; }
        public int pk_DeptoCentroCostoII { get; set; }///REQUERIDO
        public int pk_MncpioCentroCostoII { get; set; }///REQUERIDO

        public string cod_DeptoCentroCostoII { get; set; }///REQUERIDO
        public string cod_MncpioCentroCostoII { get; set; }///REQUERIDO
        ///

        public string CodigoActEconoCentroTrabajoII { get; set; }

        public List<Departamento> DepartamentoIV { get; set; }
        public List<Municipio> MncpioIV { get; set; }
        public int pk_DepartamentoIV { get; set; }///REQUERIDO
        public int pk_MncpioIV { get; set; }///REQUERIDO
                                            ///

        public string cod_DepartamentoIV { get; set; }///REQUERIDO
        public string cod_MncpioIV { get; set; }///REQUERIDO
        public string str_DepartamentoIV { get; set; }///REQUERIDO
        public string str_MncpioIV { get; set; }///REQUERIDO
       
        public string boTipoVinculacionIII { get; set;}
        public string tempTipoIdentificacionIII { get; set; }
        public string NumeroIdentificacionIII { get; set;}
        public string PrimerApellidoIII { get; set;}
        public string SegundoApellidoIII { get; set;}
        public string PrimerNombreIII { get; set;}
        public string FechaNacimientoIII { get; set;}
        public string DepartamentoIII { get; set; }
        public string MunicipioIII { get; set; }

        public string cod_DepartamentoIII { get; set; }
        public string cod_MunicipioIII { get; set; }

        public string cod_EPSIII { get; set; }
        public string cod_AFPIII { get; set; }
        public string cod_ARLIII { get; set; }

        public string SexoIII { get; set;}
        public string EPSIII { get; set;}
        public string AFPIII { get; set;}
        public string ARLIII { get; set;}
        public string TelefonoIII { get; set;}
        public string FaxIII { get; set;}
        public string EmailIII { get; set;}
        public string DireccionCentroTrabajoIII { get; set;}
        public string ZonaIII { get; set; }
        public string CargoIII { get; set;}
        public string OcupacionIII { get; set;}
        public string FechaIngresoIII { get; set;}
        public string TiempoOcupacionAIII { get; set;}
        public string TiempoOcupacionMIII { get; set;}
        public string AntiguedadAIII { get; set;}
        public string AntiguedadMIII { get; set;}
        public string boJornadaIII { get; set; }
        public string SalarioHonorariosIII { get; set;}
        public string FechaMuerteIII { get; set;}
        public string AtencionOportunaIII {get; set;}
        public string SegundoNombreIII {get; set;}
        public string CodigoOcupacionIII { get; set; }


        /// <summary>
        /// MODULO IV
        /// </summary>
        public string FechaOcurrenciaIV { get; set;}
        public string HoraOcurrenciaIV { get; set;}
        public string boJornadaIV { get; set; }
        public string boDiaSemanaIV { get; set; }
        public string stDiaSemanaIV { get; set; }
        public string LaborHabitualIV { get; set; }
        public string EspecifiqueLaborHabitual { get; set; }
        public string TipoIncidenteIV { get; set;}
        public string EspecTipoIncidenteIV { get; set;}
        public string IPSAtendioIV { get; set;}
        public string ZonaIV { get; set; }
        public string TiempoLaboradoPrevioIV { get; set;}
        public string LugarExactoIV { get; set;}
        public string SitioExactoIV { get; set;}
        public bool OtroSitioIV { get; set;}
        public string EspecifiqueIV { get; set;}
        public string AtencionOportunaOtrosIII { get; set; }

        /// <summary>
        /// /////////////////////////////////////////
        /// </summary>
        public string MarcaVI { get; set; }
        public string textfield74 { get; set; }
        public string FactoresPersonalesVII2 { get; set; }
        public string AnalisisNombresIX { get; set; }


        public string EventosSimilaresV { get; set; }
        public string NumeroPersonasV { get; set;}
        public string OtrosIncidentesV { get; set; }
        public string EventoSimilarV { get; set; }
        public string CondicionPrioritariaV { get; set; }
        public string TrabajadorInvolucradoV { get; set; }
        public string PanoramaRiesgoV { get; set; }
        public string DescripcionAccidenteV { get; set;}


        public string AgenteVI { get; set;}
        public string MaterialVI { get; set;}
        public string ModeloVI { get; set;}
        public string ReferenciaVI { get; set;}
        public string PesoVI { get; set;}
        public string PesoUnidadMedidaVI { get; set;}
        public string AlturaVI { get; set;}
        public string AnchoVI { get; set;}
        public string VolumenVI { get; set;}
        public string ProfundidadVI { get; set;}
        public string VelocidadVI { get; set;}
        public string TiempoUsoVI { get; set;}
        public string TiempoUsoVIA { get; set; }
        public string FechaMantenimientoVI { get; set;}
        public string ReparadoVI { get; set; }
        
        
        public string ExplosivosVI { get; set; }
        public string ExplosivosUnidadMedidaVI { get; set; }
        public string ExplosivosCantidadVI { get; set; }
        
        public string GasesVI { get; set; }
        public string GasesUnidadMedidaVI { get; set; }
        public string GasesCantidadVI { get; set; }


        public string TemperaturaVI { get; set; }
        public string TemperaturaUnidadMedidaVI { get; set; }


        public string SustanciaVI { get; set; }
        public string SustanciaUnidadMedidaVI { get; set; }
        public string SustanciaCantidadVI { get; set; }


        public string VoltajeElectricoVI { get; set; }
        public string VoltajeElectricoUnidadMedidaVI { get; set; }
        public string VoltajeElectricoCantidadVI { get; set; }
 

        public string DetallesAdicionalesVI { get; set; }
        public string EPPVI { get; set; }
        public string TrabajadorEPPVI { get; set; }
        public string ObservacionesVI { get; set; }



        public string CodTipoLesionVII { get; set;}
        public string TipoLesionVII { get; set;}
        public string CodigoParteCuerpoAfectadaVII { get; set;}
        public string CodMecaAccideneteVII { get; set;}
        public string MecanismoAccidenteVII { get; set;}
        public string CodAgenteAccideneteVII { get; set;}
        public string AgenteAccidenteVII { get; set;}
        public string CodFactoresPersonalesVII1 { get; set;}
        public string FactoresPersonalesVII1 { get; set;}
        public string CodFactoresPersonalesVII2 { get; set;}
        public string CodActFactoresPersonalesVII2 { get; set; }
        public string ActFactoresPersonalesVII2 { get; set; }
        public string CodActoSubestandarVII1 { get; set;}
        public string ActosSubestandarVII1 { get; set;}
        public string CodActoSubestandarVII2 { get; set;}
        public string ActosSubestandarVII2 { get; set;}
        public string CodFactoresTrabajoVII1 { get; set;}
        public string FactoresTrabajoVII1 { get; set;}
        public string CodFactoresTrabajoVII2 { get; set;}
        public string FactoresTrabajoVII2 { get; set;}
        public string CodCondAmbientalesVII1 { get; set;}
        public string CondAmbientalesVII1 { get; set;}
        public string CodCondAmbientalesVII2 { get; set;}
        public string CondAmbientalesVII2 { get; set;}
        public string TipoIdentJefeInmediantoIX { get; set;}
        public string NumIdentJefeInmediatoIX { get; set;}
        public string JefeInmediatoNombresIX { get; set;}
        public string JefeInmediatoCargoIX { get; set;}


        public string DescripcionAnalisisIX { get; set;}
        public string TipoIdentEncargadoPSOIX { get; set; }
        public string NumIdentPSOIX { get; set;}
        public string EncargadoPSONombresIX { get; set;}
        public string EncargadoPSOCargoIX { get; set;}
        public string TipoIdentCOPASOIX { get; set; }
        public string COPASONumIdentIX { get; set;}
        public string COPASONombresCompletosIX { get; set;}
        public string COPASOCargoIX { get; set;}
        public string TipoIdentEncargadosPSOIX { get; set; }
        public string TipoIdentBrigadistaIX { get; set; }
        public string NumeroIdentBrigadistaIX { get; set;}
        public string BrigadistaNombresIX { get; set;}
        public string BrigadistaCargoIX { get; set;}
        public string TipoIdentParticipanteIX { get; set; }
        public string NumIdentParticipanteIX { get; set;}
        public string ParticipanteNombreIX { get; set;}
        public string ParticipanteCargoIX { get; set;}

        public string EmpresaRepresentaIX { get; set;}
        public string ObservacionEspecialistaIX { get; set;}

        public string TipoIdentRepresentanteARLIX { get; set; }
        public string RepresentanteARLNombresIX { get; set; }
        public string NumLicenciaEspecialistaSGSSTIX1 { get; set; }
        public string anioLicenciaEspecialistaSGSSTIX1 { get; set; }
        public string NumIdentRepresentanteARLIXIX { get; set; }

        public string TipoIdentEspecialistaSGSSTIX { get; set; }
        public string EspecialistaSGSSTNombresIX { get; set; }
        public string NumLicenciaEspecialistaSGSSTIX2 { get; set; }
        public string anioLicenciaEspecialistaSGSSTIX2 { get; set; }
        public string NumIdentEspecialistaSGSSTIX { get; set; }
        public string FechaVerificacionXII { get; set; }

        

        public string CausasInmediatasTipoC1X { get; set; }
        public string MedidasIntervencion1X { get; set;}
        public string TipoF1X { get; set; }
        public string RespImplementacion1X { get; set;}
        public string FechaImplementacion1X { get; set;}

        public string CausasInmediatasTipoC2X { get; set; }
        public string MedidasIntervencion2X { get; set;}
        public string TipoF2X { get; set; }
        public string RespImplementacion2X { get; set;}
        public string FechaImplementacion2X { get; set;}

        public string CausasInmediatasTipoC3X { get; set; }
        public string MedidasIntervencion3X { get; set;}
        public string TipoF3X { get; set; }
        public string RespImplementacion3X { get; set;}
        public string FechaImplementacion3X { get; set;}

        public string CausasBasicasTipoC1X { get; set; }
        public string BasicasInmediatas1X { get; set;}
        public string BasicasF1X { get; set; }
        public string BasicasRespImplementacion1X { get; set;}
        public string BasicasFechaImplementacion1X { get; set;}

        public string CausasBasicasTipoC2X { get; set; }
        public string BasicasInmediatas2X { get; set;}
        public string BasicasF2X { get; set; }
        public string BasicasRespImplementacion2X { get; set;}
        public string BasicasFechaImplementacion2X { get; set;}

        public string CausasBasicasTipoC3X { get; set; }
        public string BasicasInmediatas3X { get; set;}
        public string BasicasF3X { get; set; }
        public string BasicasRespImplementacion3X { get; set;}
        public string BasicasFechaImplementacion3X { get; set;}

        public string FechaRemisionXI { get; set;}
        public string NoFoliosXI { get; set;}
        public string TipoIdentificacionXI { get; set; }
        public string NumeroIdentificacionXI { get; set;}
        public string NombresXI { get; set;}
        public string CargoXI { get; set;}
        public string RecomendacionesARLXI { get; set;}
        public string RemisionInformeARLXI { get; set;}
        public string RemisionMinisterioTrabajoXI { get; set;}

        
        public string TipoIdentificacionXII { get; set;}
        public string NumeroIdentificacionXII { get; set;}
        public string NombresXII { get; set;}
        public string CargoXII { get; set;}
        public string MedidasIntervencionXII { get; set; }
        public string ObservacionesXII  { get; set;}
  
        public string hmyFile1 { get; set;}
        public string hmyFile2 { get; set;}
        public string hmyFile3 { get; set;}
        public string hmyFile4 { get; set;}
        public string hmyFile5 { get; set;}
        public string hmyFile6 { get; set;}
        public string hmyFile7 { get; set;}
        public string hmyFile8 { get; set;}
        public string hmyFile9 { get; set;}
        public string hmyFile10 { get; set;}
        public string hmyFile11 { get; set;}
        public string hmyFile12 { get; set;}
        public string hmyFile13 { get; set; }
        public string hmyFile14 { get; set; }

        public string RecomendacionesCargoXI { get; set; }
        public string BasicasT3X { get; set; }
        public string VelocidadUnidadMedidaVI { get; set; }

        public string TipoIdentificacionXIII { get; set; }
        public string NombresXIII { get; set; }
        public string CargoXIII { get; set; }
        public string NumeroIdentificacionXIII { get; set; }
        public string MedidasIntervencionXIII { get; set; }
        public string FechaVerificacionXIII { get; set; }
        public string ObservacionesXIII { get; set; }
        public bool boTipoF1X { get; set; }
        public bool boTipoM1X { get; set; }
        public bool boTipoT1X { get; set; }
        public bool boTipoF2X { get; set; }
        public bool boTipoM2X { get; set; }
        public bool boTipoT2X { get; set; }
        public bool boTipoF3X { get; set; }
        public bool boTipoM3X { get; set; }
        public bool boTipoT3X { get; set; }
        public bool boBasicasF1X { get; set; }
        public bool boBasicasM1X { get; set; }
        public bool boBasicasT1X { get; set; }
        public bool boBasicasF2X { get; set; }
        public bool boBasicasM2X { get; set; }
        public bool boBasicasT2X { get; set; }
        public bool boBasicasF3X { get; set; }
        public bool boBasicasM3X { get; set; }
        public bool boBasicasT3X { get; set; }


        public List<IncidentesATAnexos> incidentesatAnexos { get; set; }

        public string AnexoFechaIncidente { get; set; }
        public string AnexoFechaTestimonio { get; set; }
        public string AnexoTipoIdentificacion { get; set; }
        public string AnexoNumIdentificacion { get; set; }
        public string AnexoNombres { get; set; }
        public string AnexoCargo { get; set; }
        public string AnexoDondeSucedio { get; set; }
        public string AnexoPrevenir { get; set; }
        public string AnexoAdicionar { get; set; }
        public string AnexoFirma { get; set; }
        public string myFile13 { get; set; }

        ////////////////////////////////////////////////////////
        ///PARAMETROS REPORTE
        ///
        public string st_DepartamentoI { get; set; }
        public string st_MunicipioI { get; set; }
        public string codActividadII { get; set; }

        public string st_DeptoCentroCostoII { get; set; }
        public string st_MncpioCentroCostoII { get; set; }

        public string TipoIdentJefeInmediantoIXTI { get; set; }
        public string TipoIdentEncargadoPSOIXTI { get; set; }
        public string TipoIdentCOPASOIXTI { get; set; }
        public string TipoIdentBrigadistaIXTI { get; set; }
        public string TipoIdentParticipanteIXTI { get; set; }
        public string TipoIdentRepresentanteARLIXTI { get; set; }
        public string TipoIdentEspecialistaSGSSTIXTI { get; set; }
        public string myFile14 { get; set; }

    }
}