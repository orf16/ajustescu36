using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Enumeraciones
{
    public class EnumAuditoriaSistema
    {

        public static class Modulos
        {
            public static string Empresa { get { return "Empresa"; } }
            public static string Liderazgo_Gerencial { get { return "Liderazgo Gerencial"; } }
            public static string Politica { get { return "Política"; } }
            public static string Organizacion { get { return "Organización"; } }           
            public static string Planificacion { get { return "Planificación"; } }
            public static string Aplicacion { get { return "Aplicación"; } }
            public static string Reporte_e_Investigacion { get { return "Reporte e Investigación"; } }
            public static string Medicion_y_Evaluación_SG_SST { get { return "Medición y Evaluación SG-SST"; } }
            public static string Participacion_Trabajadores { get { return "Participacion Trabajadores"; } }
            public static string Revision_por_la_Direccion { get { return "Revisión por la Dirección"; } }
            public static string Configuracion_Maestros { get { return "Configuración Maestros"; } }
            public static string Usuarios_del_Sistema { get { return "Usuarios del Sistema"; } }
        }

        public static class SubModulos
        {
            public static string Dx_Gral_condiciones_de_salud { get { return "Dx. Gral. condiciones de salud"; } }
            public static string Identificacion_de_peligros_evaluacion_y_valoracion_riesgos { get { return "Identificación de peligros, evaluación y valoración riesgos"; } }
            public static string Presupuesto { get { return "Presupuesto"; } }
            public static string Roles_y_Responsabilidades_SST { get { return "Roles y responsabilidades SST"; } }
            public static string Perfil_sociodemográfico { get { return "Perfil sociodemográfico"; } }
            public static string Consulta_SST { get { return "Consulta SST"; } }
            public static string Buzon_Consulta_SST { get { return "Buzón Consulta SST"; } }
            public static string Gobierno_organizacional { get { return "Gobierno organizacional"; } }
            public static string Consideraciones_internas_y_externas { get { return "Consideraciones internas y externas"; } }
            public static string Revision_del_SG_SST { get { return "Revisión del SG-SST"; } }
            public static string Política_del_SG_SST { get { return "Política del SG-SST"; } }
            public static string Competencias_SST { get { return "Competencias SST"; } }
            public static string Adquisiciones_Bienes_o_Contratacion { get { return "Adquisiciones_Bienes_o_Contratacion"; } }
            public static string Datos_generales_de_la_empresa { get { return "Datos generales de la empresa"; } }
            public static string Sedes { get { return "Sedes"; } }
            public static string Inspecciones_de_Seguridad { get { return "Inspecciones de Seguridad"; } }
            public static string Reporte_Actos_Condiciones_Inseguras { get { return "Reporte de Actos y condiciones Inseguras"; } }
       

            

        }
        public static class Opciones
        { 
            public static string Crear_Dx_General_de_Condiciones_de_salud { get { return "Crear Dx General de Condiciones de salud"; } }
            public static string Historico_de_Diagnostico { get { return " Histórico de Diagnóstico"; } }
            public static string  Cargar_Dx_General_de_Condiciones_de_salud { get { return " Cargar Dx General de Condiciones de salud"; } }
            public static string GenerarMetodologia { get { return " GenerarMetodologia"; } }
            public static string ModificarPeligro { get { return " ModificarPeligro"; } }
            public static string EliminarPeligro { get { return " EliminarPeligro"; } }
            public static string CrearPresupuesto { get { return " Crear"; } }
            public static string ConsultarPresupuesto { get { return " Consultar"; } }
            public static string CrearRol { get { return " CrearRol"; } }
            public static string EliminarRol { get { return " Eliminar Rol"; } }
            public static string CrearResponsabilidad { get { return " Crear Responsabilidad"; } }
            public static string EliminarResponsabilidad { get { return " Eliminar Responsabilidad"; } }
            public static string ModificarResponsabilidad { get { return " Modificar Responsabilidad"; } }
            public static string ModificarRendicionDeCuenta { get { return " Modificar rendicion de cuenta"; } }
            public static string CrearRendicionDeCuenta { get { return " Crear rendicion de cuenta"; } }
            public static string EliminarRendicionDeCuenta { get { return " Eliminar rendicion de cuenta"; } }
            public static string Crear_Perfil_Sociodemográfico { get { return " Crear Perfil Sociodemográfico"; } }
            public static string Modificar_Perfil_Sociodemográfico { get { return " Modificar Perfil Sociodemográfico"; } }
            public static string Condiciones_Riesgo_Perfil { get { return " Condiciones Riesgo Perfil"; } }
            public static string Cargar_Plantilla { get { return " Cargar Plantilla"; } }
            public static string Consulta_en_Seguridad_y_Salud_en_el_Trabajo { get { return " Consulta en Seguridad y Salud en el Trabajo"; } }
            public static string Trazabilidad_Consulta_SST { get { return " Trazabilidad Consulta SST"; } }
            public static string Mision { get { return "Misión"; } }
            public static string Vision { get { return "Visión"; } }
            public static string Organigrama { get { return "Organigrama"; } }
            public static string Mapa_de_procesos { get { return "Mapa de procesos"; } }
            public static string Crear_DOFA { get { return "Crear DOFA"; } }
            public static string Crear_PEST { get { return "Crear PEST"; } }  
            public static string CrearActaRevision { get { return "Crear Acta Revisión"; } }
            public static string EliminarActaRevision { get { return "Eliminar Acta Revisión"; } }
            public static string ModificarActaRevision { get { return "Modificar Acta Revisión"; } }
            public static string AgregarParticipanteRevision { get { return "Agregar Participante Revisión"; } }
            public static string EliminarParticipanteRevision { get { return "Eliminar Participante Revisión"; } }
            public static string CrearAgendaRevision { get { return "Crear Agenda Revisión"; } }
            public static string ModificarAgendaRevision { get { return "Modificar Agenda Revisión"; } }
            public static string EliminarAgendaRevision { get { return "Eliminar Agenda Revisión"; } }
            public static string AdjuntarArchivoAgendaRevision { get { return "Adjuntar Archivo Agenda Revisión"; } }
            public static string EliminarArchivoAgendaRevision { get { return "Eliminar Archivo Agenda Revisión"; } }
            public static string AgregarPlanAccionRevision { get { return "Agregar Plan Acción Revisión"; } }
            public static string Crear_Modificar_Politica { get { return "Crear-Modificar Política"; } }
            public static string Crear_Asignar_Competencia { get { return "Crear/Asignar Competencia"; } }
            public static string Consultar_Competencia { get { return "Consultar Competencia"; } }
            public static string Guia_Adquisicion_de_Bienes { get { return "Guía Adquisición de Bienes"; } }
            public static string Proveedores_y_Contratistas { get { return "Proveedores y Contratistas"; } }
            public static string Datos_generales_de_la_empresa { get { return "Datos generales de la empresa"; } }
            public static string Sedes { get { return "Sedes"; } }
            public static string Roles_SGSST { get { return "Roles SGSST"; } }
            public static string Planeacion_de_Inspeccion { get { return "Planeación de Inspección"; } }
            public static string Eliminar_Reporte_Actos_Inseguros { get { return "Eliminar Reporte de Actos Inseguros"; } }
            
        }

        public static class Acciones
        {
            public static string CREACION { get { return "CREACIÓN"; } }
            public static string MODIFICACION { get { return "MODIFICACIÓN"; } }
            public static string ELIMINACION { get { return "ELIMINACIÓN"; } }              
        }
    }
}
