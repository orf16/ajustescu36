using SG_SST.EntidadesDominio.Empresas;
using SG_SST.EntidadesDominio.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Usuarios
{
    public interface IUsuario
    {
        IEnumerable<EDTipoDocumento> ObtenerTiposDocumento();
        IEnumerable<EDRolSistema> ObtenerRolesSistema();
        IEnumerable<EDCausalRechazoUsuarioSistema> ObtenerCausalesRechazoUsuariosSistema();
        IEnumerable<EDPreguntaSeguridad> ObtenerPreguntasSeguridad();
        IEnumerable<EDParametroSistema> ObtenerParametrosSistema(List<int> idParametros);
        EDParametroSistema ObtenerParametrosSistema(string NombrePlantilla);
        Dictionary<string, string> ObtenerEmpresasSinRegistrar(List<EDUsuarioPorAprobar> usuariosAprobar);
        List<EDUsuarioSistema> ObtenerDatosUsuariosSistema(List<EDUsuarioPorAprobar> usuariosAprobar);
        IEnumerable<EDUsuarioPorAprobar> ObtenerUsuariosParaAprobar(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int paginaActual, int codUsuarioAprobador);
        IEnumerable<EDUsuarioSistema> ObtenerUsuarioMesaAyuda(int codTidDocUsu, string numDocUsu, int paginaActual);
        EDUsuarioSistema EnviarClaveTemporalUsuarioMesaAyuda(int idUsuario, string passwordTemporal, string saltPassword, string hashPassword);
        EDUsuarioSistema CambiarCorreoUsuario(int idUsuario, string nuevoUsuario);
        int ObtenerTotalUsuariosParaAprobar(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int codUsuarioAprobador);
        EDParametroSistema ObtenerParametrosSistema(int codPlantilla);
        bool ValidarExistenciaUsuario(EDUsuarioPorAprobar usuarioRegistrar, out int error);
        bool ValidarSolicitudAprobacionPendiente(EDUsuarioPorAprobar usuarioRegistrar, out int error);
        bool RegistrarUsuarioParaAprobar(EDUsuarioPorAprobar usuarioSistema);
        List<EDUsuarioSistema> InsertarUsuariosAprobadosSistema(List<EDUsuarioSistema> usuariosRegistrar, out Dictionary<string, string> idsUsuarioSistema);
        bool InsertarUsuarioArlSistema(EDUsuarioSistema usuario);
        List<EDUsuarioPorAprobar> InsertarUsuariosNoAprobadosSistema(List<EDUsuarioPorAprobar> usuariosSistema);
        EDUsuarioSistema AutenticarUsuario(EDUsuarioSistema usuarioActual);
        EDUsuarioSistema ConsultarUsuarioPorRelacionLaboral(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario);
        EDUsuarioSistema ConsultarDatosUsuarioPorRelacionLaboral(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario);
        List<EDUsuarioSistema> ConsultarUsuariosSistemaPorNit(int idEstado, string nitEmpresa, int numPgina, int cantidadPorPagina);
        List<EDUsuarioSistema> ConsultarEstadosUsuarios();
        bool ActualizarEstadoUsuario(EDUsuarioSistema usuario);
        bool CambiarClaveUsuario(EDUsuarioSistema usuario);
        bool ActualizarClaveUsuarioParaRecuperarClave(EDUsuarioSistema usuario);
        bool ActualizarIntentosParaRecuperarClave(EDUsuarioSistema usuario, out int numeroIntentos);
        int ValidarExistenciaUsuarioRolRepresLegal(string tipoDocumentoEmpresa, string numeroDocEmpresa, int RolEvaluar);
        int validarCantidadUsuariosPorRol(string tipoDocumentoEmpresa, string documentoEmpresa, int idRolSeleccionado);
        void ActualizarRolesNuevaEmpresa(int id);
        IEnumerable<EDMenuRecursoSistema> ObtenerMenuRecursosSistema();
        IEnumerable<EDMenuRecursoSistema> ObtenerRecursosParaConfiguracionAccesos(int codRol, int codEmpresa, string documentoAsesorSST = "");
        bool GuardarConfiguracionRecursosSistema(IEnumerable<EDMenuRecursoSistema> confiRecSx, int codRolSistema, int idEmpresaUsuario);
        bool GuardarConfiguracionRecursosSistemaAsesorSST(IEnumerable<EDMenuRecursoSistema> confiRecSx, List<EDEmpresas> empresas);
        List<EDMenuRecursoSistema> ObtenerRecursosPorRol(int codRol, int codEmpresa);
        List<EDMenuRecursoSistema> ObtenerRecursosPorRolMenu(int codRol, int codEmpresa);
        List<EDEmpresas> ObtenerDatosUsuarioAsesorSST(string numDocumento);
        bool IngresarPreguntasSeguridad(EDUsuarioPorAprobar usuarioRegistrar);
        List<EDMunicipio> ObtenerMunicipios(int codUsuarioAprobador);
        Boolean GuardarRecursosDefault(List<EDRecursosDefault> recursosDefault);
        bool validarIdRecursoSistema(int idRecurso);
        bool validarIdRolSistema(int idRol);
        bool ElimiarRecursosPorDefaultXIdRol(int idRol);

    }
}
