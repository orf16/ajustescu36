using SG_SST.Models.Empresas;
using SG_SST.Models.Planificacion;
using SG_SST.Models.Politica;
using SG_SST.Models.Empleado;
using System.Data.Entity;
using SG_SST.Models.Organizacion;
using SG_SST.Models.LiderazgoGerencial;
using SG_SST.Models.Ausentismo;
using SG_SST.Models.MedicionEvaluacion;
using SG_SST.Models.Aplicacion;
using SG_SST.Models.Usuarios;
using SG_SST.Models.PlanCapacitacion;
using SG_SST.Models.Participacion;
using SG_SST.Models.ComunicadosAPP;
using SG_SST.Models.Incidentes;
using SG_SST.Models.Comunicaciones;
using SG_SST.Models.EnfermedadesLaborales;
using SG_SST.Models.Emergencias;
using SG_SST.Models.Revision;
using SG_SST.Models.PlanTrabajoAnual;
using SG_SST.Models.Vulnerabilidad;
using SG_SST.Models.Calendario;
using SG_SST.Models.Auditoria;

namespace SG_SST.Models
{
    public class SG_SSTContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public SG_SSTContext()
            : base("name=SG_SSTContext")
        {
        }
        /// <summary>

        /// Modulo Aplicacion
        /// </summary>
        public DbSet<UsuarioEstados> Tbl_UsuarioEstados { get; set; }
        public DbSet<PlaneacionInspeccion> Tbl_Planeacion_Inspeccion { get; set; }
        public DbSet<MaestroTipoInspeccion> Tbl_Maestro_Planeación_Inspeccion { get; set; }
        public DbSet<MaestroConfiguracionPrioridades> Tbl_Maestro_Configuracion_Prioridad { get; set; }
        public DbSet<ConfiguracionporInspeccion> Tbl_ConfiguracionPrioridadInspeccion { get; set; }
        public DbSet<Asistentes> Tbl_AsistentesInspeccion { get; set; }
        public DbSet<AsistentesporInspeccion> Tbl_AsistentesporInspeccion { get; set; }
        public DbSet<Inspecciones> Tbl_Inspecciones { get; set; }
        public DbSet<CondicionesInsegurasporInspeccion> Tbl_CondicionesInseguraporasInspeccion { get; set; }
        public DbSet<CondicionInsegura> CondicionInsegura { get; set; }
        public DbSet<PlanAccionporInspeccion> Tbl_PlanAccionporInspeccion { get; set; }
        public DbSet<ConfiguracionInspeccion> Tbl_Configuracion_Inspeccion { get; set; }
        public DbSet<PlanAccionInspeccion> Tbl_PlanAccionInspeccion { get; set; }
        public DbSet<PlanaccionPorCondicion> Tbl_PlanAccionporCondicion { get; set; }

        public DbSet<PlanAccionCorrectiva> Tbl_PlanAccionCorrectiva { get; set; }

        public DbSet<GestionDelCambio> Tbl_GestionDelCambio { get; set; }

        public DbSet<ManualGuiaAdBienes> Tbl_ManualGuiaAdBienes { get; set; }
        public DbSet<ServicioOProducto> Tbl_ServicioOProducto { get; set; }
        public DbSet<CriterioSST> Tbl_CriterioSST { get; set; }
        public DbSet<ProductoPorCriterio> Tbl_Producto_Por_Criterio { get; set; }
        public DbSet<ProveedorContratista> Tbl_ProveedorContratista { get; set; }
        public DbSet<ProveedorPorProducto> Tbl_Proveedor_Por_Producto { get; set; }
        public DbSet<ProveedorPorProductoPorCriterio> Tbl_Proveedor_ProductoPorCriterio { get; set; }
        public DbSet<ArchivosAnexos> Tbl_Archivos_Anexos { get; set; }
        public DbSet<ProveedorPorAnexo> Tbl_Proveedor_Por_Anexo { get; set; }
        public DbSet<CalificacionProveedor> Tbl_CalificacionProveedor { get; set; }
        public DbSet<ProveedorPorNumeroCalificacion> Tbl_Proveedor_Por_NumeroCalificacion { get; set; }

        /// <summary>
        /// Usuarios del sistema
        /// </summary>
        public DbSet<UsuarioSistemaEmpresa> Tbl_UsuarioSistemaEmpresa { get; set; }
        public DbSet<UsuarioSistema> Tbl_UsuarioSistema { get; set; }
        public DbSet<RolSistema> Tbl_RolesSistema { get; set; }
        public DbSet<UsuarioPorRol> Tbl_UsuariosPorRol { get; set; }
        public DbSet<UsuarioParaAprobar> Tbl_UsuariosParaAprobar { get; set; }
        public DbSet<UsuarioRechazadoSistema> Tbl_UsuariosRechazadosSitema { get; set; }
        public DbSet<RecursoSistema> Tbl_RecursosSistema { get; set; }
        public DbSet<RecursoDenegadoPorRol> Tbl_RecursosDenegadosPorRol { get; set; }
        public DbSet<CausalRechazoUsuariosSistema> Tbl_CausalesRechazoUsuariosSistems { get; set; }
        public DbSet<PlantillaCorreosSistema> Tbl_PlantillasCorreosSistema { get; set; }
        public DbSet<ParametroSistema> Tbl_ParametrosSistema { get; set; }
        public DbSet<PasswordTemporalUsuariosSistema> Tbl_PasswordsTemporalesUsuariosSistema { get; set; }
        public DbSet<PreguntaSeguridad> Tbl_PreguntasSeguridad { get; set; }
        public DbSet<RespuestaAPreguntaSeguridad> Tbl_RespuestasAPreguntasSeguridad { get; set; }
        public DbSet<DatoAdicionalUsuario> Tbl_DatosAdicionalesUsuario { get; set; }

        /// <summary>
        /// Modulo Empleado
        /// </summary>
        /// 


        public DbSet<tblEmpleado> tblEmpleado { get; set; }
        public DbSet<TipoCotizante> Tbl_TipoCotizante { get; set; }
        public DbSet<Estado_Empleado> Tbl_Estado_Empl { get; set; }
        public DbSet<TipoInconsistencia> Tbl_TipoInconsistenciaLaboral { get; set; }
        public DbSet<Inconsistecialaboral> Tbl_InconsistenciasLaborales { get; set; }

        public DbSet<Ingresos> Tbl_Ingresos { get; set; }
        public DbSet<Hijos> Tbl_Hijos { get; set; }
        public DbSet<GradoEscolaridad> Tbl_GradoEscolaridad { get; set; }
        public DbSet<Estrato> Tbl_Estrato { get; set; }
        public DbSet<Raza> Tbl_Raza { get; set; }

        public DbSet<Etnia> Tbl_Etnia { get; set; }
        public DbSet<Ocupacion> Tbl_Ocupacion { get; set; }
        public DbSet<Sexo> Tbl_Sexo { get; set; }

        public DbSet<EstadoCivil> Tbl_Estado_Civil { get; set; }




        /// <summary>
        /// Modulo Empresa
        /// </summary>
        /// 

        public DbSet<TipoAnalisis> Tbl_Tipo_Analisis { get; set; }
        public DbSet<TipoElementoAnalisis> Tbl_Tipo_Elemento_Analisis { get; set; }
        public DbSet<ElementoMatriz> Tbl_Elemento_Matriz { get; set; }
        public DbSet<Matriz> Tbl_Matriz { get; set; }
        public DbSet<Incidente> Tbl_Incidentes { get; set; }
        public DbSet<SitioIncidente> Tbl_Sitio_Incidente { get; set; }
        public DbSet<TipoIncidente> Tbl_Tipo_Incidente { get; set; }
        public DbSet<TipoJornada> Tbl_Tipo_Jornada { get; set; }
        public DbSet<IncidenteConsecuencia> Tbl_Incidente_Consecuencia { get; set; }

        /// <summary>
        /// Modulo Empresa
        /// </summary>
        /// 
        public DbSet<RolesBase> Tbl_RolesBase { get; set; }
        public DbSet<ResponsabilidadesBase> Tbl_ResponsabilidadesBase { get; set; }
        public DbSet<RolesPorResponsabilidadesBase> Tbl_Roles_Por_ResponsabilidadesBase { get; set; }
        public DbSet<RendicionDeCuentasBase> Tbl_RendicionDeCuentasBase { get; set; }
        public DbSet<RolesPorRendicionDeCuentasBase> Tbl_Roles_Por_RendicionDeCuentasBase { get; set; }


        /// <summary>
        /// Modulo Política
        /// </summary>

        public DbSet<mPolitica> Tbl_Politica { get; set; }
        public DbSet<Mod_OtrasInteracciones> Tbl_OtrasInteracciones { get; set; }


        /// <summary>
        /// Modulo Gobierno
        /// </summary>

        public DbSet<CentroTrabajo> Tbl_Centro_de_Trabajo { get; set; }
        public DbSet<CIU> Tbl_CIU { get; set; }
        public DbSet<Departamento> Tbl_Departamento { get; set; }
        public DbSet<Empresa> Tbl_Empresa { get; set; }
        public DbSet<Gobierno> Tbl_Gobierno { get; set; }
        public DbSet<Municipio> Tbl_Municipio { get; set; }


        public DbSet<Privilegios> Tbl_Priviegios { get; set; }
        public DbSet<Proceso> Tbl_Procesos { get; set; }
        public DbSet<ProcesoEmpresa> Tbl_ProcesoEmpresa { get; set; }

        public DbSet<Rol> Tbl_Rol { get; set; }
        public DbSet<Sede> Tbl_Sede { get; set; }
        public DbSet<Usuario> Tbl_Usuario { get; set; }
        public DbSet<Organigrama> Tbl_Organigrama { get; set; }
        public DbSet<EmpleadoOrg> Tbl_EmpleadoOrg { get; set; }


        public DbSet<SedeMunicipio> Tbl_SedeMunicipio { get; set; }
        public DbSet<UsuarioRol> Tbl_UsuarioRol { get; set; }
        //public DbSet<UsuarioEmpresa> Tbl_Usuario_Empresa  { get; set; }

        public DbSet<PrivilegiosPorRol> Tbl_Privilegios_Por_Rol { get; set; }

        /// <summary>
        /// Ausentismo
        /// </summary>
        public DbSet<Dias_Laborables_Empresa> Tbl_Dias_Laborables_Empresa { get; set; }
        public DbSet<Dia_Laborable> Tbl_Dias_Laborables { get; set; }
        public DbSet<Diagnostico> Tbl_Diagnosticos { get; set; }
        public DbSet<Contingencia> Tbl_Contingencias { get; set; }
        public DbSet<ConfiguracionHHT> Tbl_ConfiguracionesHHT { get; set; }
        public DbSet<Ausencia> Tbl_Ausencias { get; set; }
        public DbSet<TipoContigencia> Tbl_Tipo_Contigencias { get; set; }

        /// <summary>
        /// RELACION EMPRESAS
        /// </summary>
        public DbSet<Empresa_Usuaria> Tbl_Empresas_Usuarias { get; set; }
        public DbSet<RelacionesLaboralesTercero> Tbl_RelacionesLaboralesTercero { get; set; }
        public DbSet<EmpresaTercero> Tbl_EmpresaTercero { get; set; }
        public DbSet<EmpleadoTercero> Tbl_EmpleadoTercero { get; set; }
        public DbSet<TipoTercero> Tbl_TipoTercero { get; set; }

        /// <summary>
        /// Modulo planificacion
        /// </summary>
        public DbSet<Peligro> Tbl_Peligro { get; set; }
        public DbSet<GTC45> Tbl_GTC45 { get; set; }
        public DbSet<INSHT> Tbl_INSHT { get; set; }
        public DbSet<RAM> Tbl_RAM { get; set; }
        public DbSet<TipoMetodologia> Tbl_Metodologia { get; set; }
        public DbSet<TipoDePeligro> Tbl_Tipo_De_Peligro { get; set; }
        public DbSet<ClasificacionDePeligro> Tbl_Clasificacion_De_Peligro { get; set; }
        public DbSet<EstimacionDeRiesgo> Tbl_Estimacion_De_Riesgo { get; set; }
        public DbSet<InterpretacionDeProbabilidad> Tbl_Interpretacion_De_Probabilidad { get; set; }
        public DbSet<InterpretacionNivelDeRiesgo> Tbl_Interpretacion_Nivel_Riesgo { get; set; }
        public DbSet<NivelDeDeficiencia> Tbl_Nivel_De_Deficiencia { get; set; }
        public DbSet<NivelDeExposicion> Tbl_Nivel_De_Exposicion { get; set; }
        public DbSet<Grupo> Tbl_Grupos { get; set; }
        public DbSet<Consecuencia> Tbl_Consecuencias { get; set; }
        public DbSet<Probabilidad> Tbl_Probabilidades { get; set; }
        public DbSet<EstimacionDeRiesgoPorRAM> Tbl_Estimacion_Riesgo_Por_RAM { get; set; }
        public DbSet<ConsecuenciaPorPeligro> Tbl_Consecuencia_Por_Peligro { get; set; }
        public DbSet<ProbabilidadPorPersonaExpuesta> Tbl_Probabilidad_Por_PersonaExpuesta { get; set; }

        public DbSet<PersonaExpuesta> Tbl_PersonaExpuesta { get; set; }
        public System.Data.Entity.DbSet<SG_SST.Models.Empleado.TipoDocumento> Tbl_TipoDocumentos { get; set; }
        public DbSet<ObjetivoSST> Tbl_Objetivos_SST { get; set; }

        //Metas Indicadores - Módulo Planificación
        public DbSet<Indicador> Tbl_Indicador { get; set; }
        public DbSet<MetaIndicador> Tbl_MetaIndicador { get; set; }

        //Módulo requisitos legales - Modulo planificacion
        public DbSet<RequisitosLegalesOtros> Tbl_Requisitos_legales_Otros { get; set; }
        public DbSet<Cumplimiento_Evaluacion> Tbl_Cumplimiento_Evaluacion { get; set; }
        public DbSet<Estado_RequisitoslegalesOtros> Tbl_Estado_RequisitoslegalesOtros { get; set; }

        public DbSet<ActividadEconomica> Tbl_Actividad_Economica { get; set; }
        public DbSet<Requisitos_Matriz> Tbl_Requisitos_Matriz { get; set; }
        public DbSet<RequisitosLegalesPosipedia> Tbl_Requisitos_Legales_Posipedia { get; set; }
        public DbSet<MatrizRequisitosLegales> Tbl_Matriz_RequisitosLegales { get; set; }



        public DbSet<EvaluacionEmpresa> Tbl_EvaluacionEmpresa { get; set; }
        public DbSet<Empresa_Evaluar> Tbl_Empresas_Evaluar { get; set; }
        public DbSet<Aspecto> Tbl_Aspectos { get; set; }
        public DbSet<Valoracion_Aspecto> Tbl_Valoracion_Aspectos { get; set; }
        public DbSet<Empresa_Aspecto> Tbl_Empresa_Aspectos { get; set; }
        public DbSet<Evaluacion_Inicial_Aspecto> Tbl_Evaluacion_Inicial_Aspectos { get; set; }
        public DbSet<ActividadEvaluacion> Tbl_Actividades_Evaluacion { get; set; }
        public DbSet<Estandar> Tbl_Estandares { get; set; }
        public DbSet<Ciclo> Tbl_Ciclos { get; set; }
        public DbSet<SubEstandar> Tbl_SubEstandares { get; set; }
        public DbSet<Criterio> Tbl_Criterios { get; set; }
        public DbSet<Actividad_Criterio> Tbl_Actividades_Criterio { get; set; }
        public DbSet<Valoracion_Criterio> Tbl_Valoracion_Criterios { get; set; }
        public DbSet<Valoracion_Final> Tbl_Valoracion_Final { get; set; }
        public DbSet<Evaluacion_Estandar_Minimo> Tbl_Evaluacion_Estandares_Minimos { get; set; }
        public DbSet<Config_Valoracion_SubEstand> Tbl_Config_Valoracion_SubEstandares { get; set; }
        public DbSet<ZonaLugar> Tbl_ZonaLugar { get; set; }
        public DbSet<Aspecto_Base> Tbl_Aspecto_Base { get; set; }

        //perfil SocioDemoGráfico
 
        public DbSet<VinculacionLaboral> Tbl_VinculacionLaboral { get; set; }
        public DbSet<AntecedentesExposicionLaboral> Tbl_AntecedentesExposicionLaboral { get; set; }
        public DbSet<SedePeligro> Tbl_SedePeligro { get; set; }
        public DbSet<PerfilSocioDemograficoPlanificacion> Tbl_PerfilSocioDemograficoPlanificacion { get; set; }
        
        public DbSet<Condiciones_Riesgo_Perfil>Tbl_Condiciones_Riesgo_Perfil {get;set;}

        //dx condicion de salud
        public DbSet<DxCondicionesDeSalud> Tbl_Dx_Condiciones_De_Salud { get; set; }
        public DbSet<DocDxCondicionesDeSalud> Tbl_Doc_Dx_Condiciones_De_Salud { get; set; }

        public DbSet<SintomatologiaDx> Tbl_Sintomatologia_Dx { get; set; }

        public DbSet<PruebasClinicasDx> Tbl_Pruebas_Clinica_Dx { get; set; }

        public DbSet<PruebasPClinicasDx> Tbl_Pruebas_P_Clinica_Dx { get; set; }
        public DbSet<DiagnosticoCie10Dx> Tbl_Diagnostico_Cie10_Dx { get; set; }

        public DbSet<ClasificacionPeligroDx> Tbl_Clasificacion_Peligro_Dx { get; set; }
        

        ///Modulo Organizacion 
        ///
        //public DbSet<Actividad> Tbl_Actividad { get; set; }
        //public DbSet<PlanDeEstudio> Tbl_Plan_De_Estudio { get; set; }

        public DbSet<Recurso> Tbl_Recurso { get; set; }
        public DbSet<Fase> Tbl_Fase { get; set; }
        public DbSet<TipoRecurso> Tbl_Tipo_Recurso { get; set; }
        public DbSet<RecursoFase> Tbl_RecursoFase { get; set; }
        public DbSet<RecursoporSede> Tbl_RecursoporSede { get; set; }
        public DbSet<RecursoTipoRecurso> Tbl_RecursoTipoRecurso { get; set; }
        public DbSet<Documentacion_Organizacion> Tbl_Documentacion_Organizacion { get; set; }
        public DbSet<TipoModulo_Organizacion> Tbl_TipoModulo_Organizacion { get; set; }
        public DbSet<Cargo> Tbl_Cargo { get; set; }
        public DbSet<Tematica> Tbl_Tematica { get; set; }
        public DbSet<CargoPorRol> Tbl_Cargo_Por_Rol { get; set; }
        public DbSet<RolPorTematica> Tbl_Rol_Por_Tematica { get; set; }
        public DbSet<Competencia> Tbl_Competencia { get; set; }
        public DbSet<TematicaPorEmpresa> Tbl_Tematica_Por_Empresa { get; set; }

        public DbSet<EmpleadoTematica> Tbl_Empleado_Tematica { get; set; }
        public DbSet<EmpleadoPorTematica> Tbl_Empleado_Por_Tematica { get; set; }


        ///Modulo Liderazgo gerencial
        public DbSet<PresupuestoPorAnio> Tbl_Presupuesto_Por_Anio { get; set; }
        public DbSet<Presupuesto> Tbl_Presupuesto { get; set; }
        public DbSet<PresupuestoPorMes> Tbl_Presupuesto_Por_Mes { get; set; }
        public DbSet<ActividadPresupuesto> Tbl_Actividad_Presupuesto { get; set; }

        //public DbSet<RolesPorEmpresa> Tbl_Roles_Por_Empresa { get; set; }
        public DbSet<Responsabilidades> Tbl_Responsabilidades { get; set; }
        public DbSet<RendicionDeCuentas> Tbl_RendicionDeCuentas { get; set; }

        public DbSet<RendicionDeCuentasPorRol> Tbl_Rendicion_Cuenta_Por_Rol { get; set; }

        public DbSet<ResponsabilidadesPorRol> Tbl_Responsabilidades_Por_Rol { get; set; }

        public DbSet<ObligacionesEmpleadores> Tbl_Obligaciones_Empleadores { get; set; }
        public DbSet<ObligacionesArl> Tbl_Obligaciones_Arl { get; set; }


        //Planes de accion
        public DbSet<ModulosPlanAccion> Tbl_Modulos_Plan_Accion { get; set; }
        public DbSet<ActividadPlanDeAccion> Tbl_Actividad_Plan_Accion { get; set; }

        /// <summary>
        /// Modulo Participacion ConsultaSST
        /// </summary>
        
        public DbSet<ConsultaSST> Tbl_ConsultaSST { get; set; }       

        /// <summary>
        /// Acciones correctivas y preventivas
        /// </summary>

        public DbSet<Accion> Tbl_Acciones { get; set; }
        public DbSet<Hallazgo> Tbl_Hallazgo { get; set; }
        public DbSet<ActividadAccion> Tbl_ActividadAccion { get; set; }
        public DbSet<Seguimiento> Tbl_Seguimiento { get; set; }
        public DbSet<Analisis> Tbl_Analisis { get; set; }
        public DbSet<ArchivosAccion> Tbl_ArchivosAccion { get; set; }


        /// <summary>
        /// Auditorias
        /// </summary>
        public DbSet<Auditorias> Tbl_Auditorias { get; set; }
        public DbSet<AuditoriaListaVer> Tbl_AuditoriaListaVer { get; set; }
        public DbSet<AuditoriaInforme> Tbl_AuditoriaInforme { get; set; }
        public DbSet<AuditoriaCronograma> Tbl_AuditoriaCronograma { get; set; }
        public DbSet<AuditoriaPrograma> Tbl_AuditoriaPrograma { get; set; }
        public DbSet<ActividadAuditoria> Tbl_ActividadAuditoria { get; set; }
        public DbSet<PlanEmpresa> Tbl_Plan_Empresa { get; set; }
        public DbSet<PlanEmpresaActividad> Tbl_Plan_Empresa_Actividad { get; set; }
        
        //Reportes condiciones y actos inseguros
        public DbSet<Reporte> Tbl_Reportes { get; set; }
        public DbSet<TipoReporte> Tbl_Tipo_Reporte { get; set; }        

        public DbSet<ImagenesReportes> Tbl_ImagenesReportes { get; set; }
        
        public DbSet<ActividadesActosInseguros> Tbl_ActividadesActosInseguros { get; set; }

        public DbSet<Ocupaciones_Perfil> Tbl_Ocupaciones_De_Perfil { get; set; }

        //Modulo Participacion
        public DbSet<TipoPrioridadMiembro> Tbl_TipoPrioridadMiembroComite { get; set; }
        public DbSet<TipoPrincipalActa> Tbl_TipoPrincipalActa { get; set; }
        public DbSet<ActasCopasst> Tbl_ActasCopasst { get; set; }
        public DbSet<MiembrosActaCopasst> Tbl_MiembrosActaCopasst { get; set; }
        public DbSet<AuditoriaActaCopasst> Tbl_AuditoriaActaCopasst { get; set; }
        public DbSet<Participantes> Tbl_Participantes { get; set; }
        public DbSet<AccionesActaCopasst> Tbl_AccionesActaCopasst { get; set; }
        public DbSet<TemasActaCopasst> Tbl_TemasActaCopasst { get; set; }
        public DbSet<ActasConvivencia> Tbl_ActasConvivencia { get; set; }
        public DbSet<MiembrosActaConvivencia> Tbl_MiembrosActaConvivencia { get; set; }
        public DbSet<AuditoriaActaConvivencia> Tbl_AuditoriaActaConvivencia { get; set; }
        public DbSet<ParticipantesActasConvivencia> Tbl_ParticipantesActasConvivencia { get; set; }
        public DbSet<AccionesActaConvivencia> Tbl_AccionesActaConvivencia { get; set; }
        public DbSet<TemasActaConvivencia> Tbl_TemasActaConvivencia { get; set; }
        public DbSet<ActaConvivenciaQuejas> Tbl_ActaConvivenciaQuejas { get; set; }
        public DbSet<ResponsablesQuejas> Tbl_ResponsablesQuejas { get; set; }
        public DbSet<AccionesActaQuejas> Tbl_AccionesActaQuejas { get; set; }
        public DbSet<SeguimientoActaConvivencia> Tbl_SeguimientoActaConvivencia { get; set; }
        public DbSet<CompromisosPendientes> Tbl_CompromisosPendientes { get; set; }


        public DbSet<EstudioPuestoTrabajo> Tbl_EstudioPuestoTrabajo { get; set; }
        public DbSet<ObjetivoAnalisis> Tbl_ObjetivoAnalisis { get; set; }
        public DbSet<TipoAnalisisPuestoTrabajo> Tbl_Tipo_Analisis_Puesto_Trabajo { get; set; }
        public DbSet<ArchivosEstudioPuestoTrabajo> Tbl_Archivos_Estudio_Puesto_Trabajo { get; set; }
        public DbSet<SeguimientoEstudioPuestoTrabajo> Tbl_Seguimiento_Estudio_Puesto_Trabajo { get; set; }

        /// <summary>
        /// Modulo Administración de equipos, maquinaria y herramientas
        /// </summary>

        public DbSet<AdmoEMH> Tbl_AdministracionEMH { get; set; }
        public DbSet<PeligroEMH> Tbl_PeligroEMH { get; set; }
        public DbSet<EHMInspecciones> Tbl_AdministracionEMHInspecciones { get; set; }

        /// <summary>
        /// Modulo Administración de elementos de protección personal
        /// </summary>

        public DbSet<EPP> Tbl_EPP { get; set; }
        public DbSet<EPPCargo> Tbl_EPPCargo { get; set; }
        public DbSet<EPPSuministro> Tbl_EPPSuministro { get; set; }
        public DbSet<EPPSuministroEPP> Tbl_EPPSuministroEPP { get; set; }

        /// <summary>
        /// Modulo PESV VIAL
        /// </summary>
        public DbSet<PlanVial> Tbl_PlanVial { get; set; }
        public DbSet<SegVialDetalle> Tbl_SegVialDetalle { get; set; }
        public DbSet<SegVialParametro> Tbl_SegVialParametro { get; set; }
        public DbSet<SegVialPilar> Tbl_SegVialPilar { get; set; }
        public DbSet<SegVialResultado> Tbl_SegVialResultado { get; set; }
        
        /// <summary>
        /// NUEVAS TABLAS INCIDENTES AT
        /// </summary>
        public DbSet<IncidentesAT1> Tbl_IncidentesAT1 { get; set; }
        public DbSet<IncidentesAT2> Tbl_IncidentesAT2 { get; set; }
        public DbSet<IncidentesAT3> Tbl_IncidentesAT3 { get; set; }
        public DbSet<IncidentesAT4> Tbl_IncidentesAT4 { get; set; }
        public DbSet<IncidentesAT5> Tbl_IncidentesAT5 { get; set; }
        public DbSet<IncidentesAT6> Tbl_IncidentesAT6 { get; set; }
        public DbSet<IncidentesAT7> Tbl_IncidentesAT7 { get; set; }
        public DbSet<IncidentesAT8> Tbl_IncidentesAT8 { get; set; }
        public DbSet<IncidentesAT9> Tbl_IncidentesAT9 { get; set; }
        public DbSet<IncidentesAT10> Tbl_IncidentesAT10 { get; set; }
        public DbSet<IncidentesAT11> Tbl_IncidentesAT11 { get; set; }
        public DbSet<IncidentesAT12> Tbl_IncidentesAT12 { get; set; }
        public DbSet<IncidentesAT13> Tbl_IncidentesAT13 { get; set; }
        public DbSet<IncidentesATAnexos> Tbl_IncidentesATAnexos { get; set; }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>

        public DbSet<IncidentesEL1> Tbl_IncidentesEL1 { get; set; }
        public DbSet<IncidentesEL2> Tbl_IncidentesEL2 { get; set; }
        public DbSet<IncidentesEL3> Tbl_IncidentesEL3 { get; set; }
        public DbSet<IncidentesEL4> Tbl_IncidentesEL4 { get; set; }
        public DbSet<IncidentesEL5> Tbl_IncidentesEL5 { get; set; }
        public DbSet<IncidentesEL6> Tbl_IncidentesEL6 { get; set; }
        public DbSet<IncidentesEL7> Tbl_IncidentesEL7 { get; set; }
        public DbSet<IncidentesEL8> Tbl_IncidentesEL8 { get; set; }
        public DbSet<IncidentesEL9> Tbl_IncidentesEL9 { get; set; }
        public DbSet<IncidentesEL10> Tbl_IncidentesEL10 { get; set; }

        /// <summary>
        /// Tablas Maestros Incidentes
        /// </summary>
        public DbSet<FactoresPersonales> Tbl_FactoresPersonales { get; set;  }
        public DbSet<FactoresDeTrabajo> Tbl_Factores_De_Trabajo { get; set; }
        public DbSet<ActosSubestandar> Tbl_Actos_Subestandar { get; set; }
        public DbSet<CondicionesAmbientalesSubestandar> Tbl_Condiciones_Ambientales_Subestandar { get; set; }
        public DbSet<Agente> Tbl_Agente { get; set; }
        public DbSet<Mecanismo> Tbl_Mecanismo { get; set; }
        public DbSet<PDCACorto> Tbl_PDCA_Corto {get; set;}
        public DbSet<SitioAT> Tbl_Sitio_AT {get; set;}
        public DbSet<TipoAT> Tbl_Tipo_AT {get; set;}
        public DbSet<TipoLesion> Tbl_Tipo_De_Lesion {get; set;}

        /// <summary>
        /// MODULO ENFERMEDAD LABORAL DIAGNOSTICADA
        /// </summary>
        public DbSet<EnfermedadLaboral> Tbl_EnfermedadesLaboralesDiagnosticadas { get; set; }
        public DbSet<DocumentoEnviadoEPS> Tbl_DocumentosEnviadosEPS { get; set; }
        public DbSet<InstanciaEnfermedadLaboral> Tbl_InstanciasEnfermedadLaboralDiagnosticada { get; set; }
        public DbSet<EstadoInstanciaRegistrada> Tbl_EstadosInstanciasRegistradas { get; set; }

        /// <summary>
        /// COMUNICADOS APP
        /// </summary>
        /// 
        public DbSet<ComunicacionesEncuestasPreguntas> Tbl_ComunicacionesEncuestasPreguntas { get; set; }
        public DbSet<ComunicacionesCargos> Tbl_ComunicacionesCargos { get; set; }
        public DbSet<ComunicacionesAPP> Tbl_ComunicadosAPP { get; set; }
        public DbSet<UsuarioComunicadoAPP> Tbl_UsuarioComunicadoAPP { get; set; }
        public DbSet<EstadosComunicadosAPP> Tbl_EstadosComunicadosAPP { get; set; }
        public DbSet<ComunicacionesInternas> Tbl_ComunicacionesInternas { get; set; }
        public DbSet<ComunicacionesExternas> Tbl_ComunicacionesExternas { get; set; }
        public DbSet<GruposComuniciones> Tbl_GruposComuniciones { get; set; }
        public DbSet<GrupoUsuariosComunicaciones> Tbl_GrupoUsuariosComunicaciones { get; set; }
        public DbSet<ComunicadosAdjuntos> Tbl_ComunicadosAdjuntos { get; set; }
        public DbSet<ComunicacionesEncuestas> Tbl_ComunicacionesEncuestas { get; set; }
        public DbSet<ComunicacionesUsuariosSuscritosAPP> Tbl_ComunicacionesUsuariosSuscritosAPP { get; set; }
        public DbSet<ComunicacionesLog> Tbl_ComunicacionesLog { get; set; }
        
        
        /// <summary>
        /// PLAN CAPACITACION
        /// </summary>
        public DbSet<PlanCapacitacion_Soporte> Tbl_PlanCapacitacion_Soporte { get; set; }
        public DbSet<PlanCapacitacion_Asignaciones> Tbl_PlanCapacitacion_Asignaciones { get; set; }

        public DbSet<Plan_Capacitacion> Tbl_PlanCapacitacion { get; set; }
        /// <summary>
        /// PREVENCION PREPARACION Y RESPUESTA ANTE EMERGENCIAS
        /// </summary>
        public DbSet<Eme_AnalisisRiesgo> Tbl_Eme_AnalisisRiesgo { get; set; }
        public DbSet<Eme_Bd_Externa> Tbl_Eme_Bd_Externa { get; set; }
        public DbSet<Eme_bd_Interna> Tbl_Eme_bd_Interna { get; set; }
        public DbSet<Eme_CaracteristicasInstalacion> Tbl_Eme_CaracteristicasInstalacion { get; set; }
        public DbSet<Eme_DescripcionOcupacion> Tbl_Eme_DescripcionOcupacion { get; set; }
        public DbSet<Eme_Elementos> Tbl_Eme_Elementos { get; set; }
        public DbSet<Eme_EsquemaOrganizacional> Tbl_Eme_EsquemaOrganizacional { get; set; }
        public DbSet<Eme_FrentesAccion> Tbl_Eme_FrentesAccion { get; set; }
        public DbSet<Eme_Generalidades> Tbl_Eme_Generalidades { get; set; }
        public DbSet<Eme_Georeferenciacion> Tbl_Eme_Georeferenciacion { get; set; }
        public DbSet<Eme_InfoGeneral> Tbl_Eme_InfoGeneral { get; set; }
        public DbSet<Eme_NivelEmergencia> Tbl_Eme_NivelEmergencia { get; set; }
        public DbSet<Eme_PlanAyuda> Tbl_Eme_PlanAyuda { get; set; }
        public DbSet<Eme_ProcOpera_Normalizados> Tbl_Eme_ProcOpera_Normalizados { get; set; }
        public DbSet<Eme_RecursosHumanos> Tbl_Eme_RecursosHumanos { get; set; }
        public DbSet<Eme_RecursosTecnicos> Tbl_Eme_RecursosTecnicos { get; set; }
        public DbSet<Eme_Roles> Tbl_Eme_Roles { get; set; }
        public DbSet<Eme_FrentesAccionAdjuntos> Tbl_Eme_FrentesAccionAdjuntos { get; set; }
        public DbSet<Eme_EstructuraOrganizacion> Tbl_Eme_EstructuraOrganizacion { get; set; }

        
        //Modulo Promoción y Prevencion: baterias

        public DbSet<Bateria> Tbl_Bateria { get; set; }
        public DbSet<BateriaCuestionario> Tbl_BateriaCuestionario { get; set; }
        public DbSet<BateriaDimension> Tbl_BateriaDimension { get; set; }
        public DbSet<BateriaGestion> Tbl_BateriaGestion { get; set; }
        public DbSet<BateriaResultado> Tbl_BateriaResultado { get; set; }
        public DbSet<BateriaUsuario> Tbl_BateriaUsuario { get; set; }
        public DbSet<BateriaInicial> Tbl_BateriaInicial { get; set; }


        /// <summary>
        /// REVISIÓN
        /// </summary>
        public DbSet<ActaRevision> Tbl_ActaRevision { get; set; }

        public DbSet<ItemRevision> Tbl_ItemRevision { get; set; }

        public DbSet<ParticipanteRevision> Tbl_ParticipanteRevision { get; set; }

        public DbSet<PlanAccionRevision> Tbl_PlanAccionRevision { get; set; }

        public DbSet<AgendaRevision> Tbl_AgendaRevision { get; set; }

        public DbSet<AdjuntoAgendaRevision> Tbl_AdjuntoAgendaRevision { get; set; }


        /// <summary>
        /// Modulo Promoción y Prevencion: Plan de Trabajo
        /// </summary>
        public DbSet<AplicacionPlanTrabajo> Tbl_AplicacionPlanTrabajo { get; set; }
        public DbSet<AplicacionPlanTrabajoDetalle> Tbl_AplicacionPlanTrabajoDetalle { get; set; }
        public DbSet<AplicacionPlanTrabajoActividad> Tbl_AplicacionPlanTrabajoActividad { get; set; }
        public DbSet<AplicacionPlanTrabajoProgramacion> Tbl_AplicacionPlanTrabajoProgramacion { get; set; }
        //ANALISIS DE VULNERABILIDADES

        public DbSet<vul_eme_Consolidado> Tbl_vul_eme_Consolidado { get; set; }
        public DbSet<vul_eme_IdentificacionAmenazas> Tbl_vul_eme_IdentificacionAmenazas { get; set; }
        public DbSet<vul_eme_Personas> Tbl_vul_eme_Personas { get; set; }
        public DbSet<vul_eme_Recursos> Tbl_vul_eme_Recursos { get; set; }
        public DbSet<vul_eme_sistemas_procesos> Tbl_vul_eme_sistemas_procesos { get; set; }
        public DbSet<vul_Identificacion_Personas> Tbl_vul_Identificacion_Personas { get; set; }
        public DbSet<vul_Personas> Tbl_vul_Personas { get; set; }
        public DbSet<vul_Recursos> Tbl_vul_Recursos { get; set; }
        public DbSet<vul_SistemasProcesos> Tbl_vul_SistemasProcesos { get; set; }
        //probar borrado


        /// <summary>
        /// Calendario
        /// </summary>
        public DbSet<DiaFestivo> Tbl_DiaFestivo { get; set; }
        public DbSet<RecursoDenegadoPorRolDefault> Tbl_RecursoDenegadoPorRolDefault { get; set; }

        /// <summary>
        /// Auditoria
        /// </summary>
        public DbSet<AuditoriaPlanificacion> Tbl_AuditoriaPlanificacionSistema { get; set; }
        public DbSet<AuditoriaAplicacion> Tbl_AuditoriaAplicacionSistema { get; set; }
        public DbSet<AuditoriaConfiguracionMaestros> Tbl_AuditoriaConfiguracionMaestrosSistema { get; set; }
        public DbSet<AuditoriaEmpresa> Tbl_AuditoriaEmpresaSistema { get; set; }
        public DbSet<AuditoriaLiderazgoGerencial> Tbl_AuditoriaLiderazgoGerencialSistema { get; set; }
        public DbSet<AuditoriaMedicionYEvaluaciónSGSST> Tbl_AuditoriaMedicionYEvaluaciónSGSSTSistema { get; set; }
        public DbSet<AuditoriaOrganizacion> Tbl_AuditoriaOrganizacionSistema { get; set; }
        public DbSet<AuditoriaParticipacionTrabajadores> Tbl_AuditoriaParticipacionTrabajadoresSistema { get; set; }
        public DbSet<AuditoriaPolitica> Tbl_AuditoriaPoliticaSistema { get; set; }
        public DbSet<AuditoriaReporteEInvestigacion> Tbl_AuditoriaReporteEInvestigacionSistema { get; set; }
        public DbSet<AuditoriaRevisionPorLaDireccion> Tbl_AuditoriaRevisionPorLaDireccionSistema { get; set; }
        public DbSet<AuditoriaUsuariosDelSistema> Tbl_AuditoriaUsuariosDelSistema { get; set; }
        public DbSet<ActivaAuditoriaSistema> Tbl_ActivaAuditoriaSistema { get; set; }
        public DbSet<RegistroIngresoSistema> Tbl_RegistroIngresoSistema { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstimacionDeRiesgoPorRAM>()
                .HasRequired(d => d.EstimacionDeRiesgo)
                .WithMany(w => w.EstimacionDeRiesgosPorRAM)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioRol>()
                .HasRequired(d => d.Rol)
                .WithMany(w => w.UsuarioRoles)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Probabilidad>()
                .HasRequired(d => d.Metodologia)
                .WithMany(w => w.Probabilidades)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Criterio>()
               .HasRequired(d => d.SubEstandar)
               .WithMany(d => d.Criterios)
               .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

           

            //Relacion Hallazgo - Accion
            modelBuilder.Entity<Hallazgo>()
                 .HasKey<int>(s => s.Pk_Id_Hallazgo)
                 .HasRequired(s => s.Accion)
                 .WithMany(q => q.Hallazgos)
                 .HasForeignKey(s => s.Fk_Id_Accion)
                 .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            //Relacion Actividad - Accion
            modelBuilder.Entity<ActividadAccion>()
                .HasKey<int>(s => s.Pk_Id_Actividad)
                .HasRequired(s => s.Accion)
                .WithMany(q => q.ActividadAcciones)
                .HasForeignKey(s => s.Fk_Id_Accion)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
            //Relacion Seguimiento - Accion
            modelBuilder.Entity<Seguimiento>()
                .HasKey<int>(s => s.Pk_Id_Seguimiento)
                .HasRequired(s => s.Accion)
                .WithMany(q => q.Seguimientos)
                .HasForeignKey(s => s.Fk_Id_Accion)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
            //Relacion Analisis - Accion
            modelBuilder.Entity<Analisis>()
                .HasKey<int>(s => s.Pk_Id_Analisis)
                .HasRequired(s => s.Accion)
                .WithMany(q => q.Analisis)
                .HasForeignKey(s => s.Fk_Id_Accion)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);


            //Relacion ArchivosAccion - Accion
            modelBuilder.Entity<ArchivosAccion>()
                .HasKey<int>(s => s.Pk_Id_Archivo)
                .HasRequired(s => s.Accion)
                .WithMany(q => q.Archivos)
                .HasForeignKey(s => s.Fk_Id_Accion)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            //Relacion AuditoriaPrograma - Auditorias
            modelBuilder.Entity<Auditorias>()
                .HasKey<int>(s => s.Pk_Id_Auditoria)
                .HasRequired(s => s.AuditoriaPrograma)
                .WithMany(q => q.Auditorias)
                .HasForeignKey(s => s.Fk_Id_Programa)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            //Relacion Auditorias - Lista Verificación
            modelBuilder.Entity<AuditoriaListaVer>()
                .HasKey<int>(s => s.Pk_Id_Lista_Verificacion)
                .HasRequired(s => s.Auditoria)
                .WithMany(q => q.AuditoriaListaVers)
                .HasForeignKey(s => s.Fk_Id_Auditoria)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            //Relacion Auditorias - Auditoria Cronograma
            modelBuilder.Entity<AuditoriaCronograma>()
                .HasKey<int>(s => s.Pk_Id_Cronograma_Auditoria)
                .HasRequired(s => s.Auditoria)
                .WithMany(q => q.AuditoriaCronogramas)
                .HasForeignKey(s => s.Fk_Id_Auditoria)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            //Relacion Auditorias - Actividades plan de acción
            modelBuilder.Entity<ActividadAuditoria>()
                .HasKey<int>(s => s.Pk_Id_Actividad)
                .HasRequired(s => s.Auditoria)
                .WithMany(q => q.AuditoriaActividades)
                .HasForeignKey(s => s.Fk_Id_Auditoria)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            //Tamaño Decimal Seguridad Vial
            modelBuilder.Entity<SegVialResultado>().Property(e => e.ValorObtenido).HasPrecision(5, 2);
            modelBuilder.Entity<SegVialPilar>().Property(e => e.Valor_Ponderado).HasPrecision(5, 2);
            modelBuilder.Entity<SegVialParametro>().Property(e => e.Valor_Parametro).HasPrecision(5, 2);

            //modelBuilder.Entity<Incidente>()
            //    .HasRequired(s => s.Incidente_municipio)
            //    .WithRequiredDependent()
            //    .WillCascadeOnDelete(true);
            //base.OnModelCreating(modelBuilder);








        }
    }
}
