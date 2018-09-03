using OfficeOpenXml;
using SG_SST.Audotoria;
using SG_SST.ClienteServicios;
using SG_SST.EntidadesDominio.Empresas;
using SG_SST.EntidadesDominio.Usuario;
using SG_SST.Interfaces.Usuarios;
using SG_SST.InterfazManager.Usuarios;
using SG_SST.Logica.Empresas;
using SG_SST.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Logica.Usuarios
{
    public class LNUsuario
    {
        private static IUsuario us = IMUsuario.UsuarioSesion();

        public IEnumerable<EDTipoDocumento> ObtenerTiposDocumento()
        {
            return us.ObtenerTiposDocumento();
        }
        public IEnumerable<EDRolSistema> ObtenerRolesSistema()
        {
            return us.ObtenerRolesSistema();
        }
        public IEnumerable<EDCausalRechazoUsuarioSistema> ObtenerCausalesRechazoUsuariosSistema()
        {
            return us.ObtenerCausalesRechazoUsuariosSistema();
        }
        public IEnumerable<EDPreguntaSeguridad> ObtenerPreguntasSeguridad()
        {
            return us.ObtenerPreguntasSeguridad();
        }
        public IEnumerable<EDUsuarioPorAprobar> ObtenerUsuariosParaAprobar(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int paginaActual, int codUsuarioAprobador)
        {
            return us.ObtenerUsuariosParaAprobar(numDocEmp, numDocUsu, rolSeleccionado, idMunicipio, paginaActual, codUsuarioAprobador);
        }
        public IEnumerable<EDUsuarioSistema> ObtenerUsuarioMesaAyuda(int codTidDocUsu, string numDocUsu, int paginaActual)
        {
            return us.ObtenerUsuarioMesaAyuda(codTidDocUsu, numDocUsu, paginaActual);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public EDUsuarioSistema EnviarClaveTemporalUsuarioMesaAyuda(int idUsuario)
        {
            var caracteresPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CaracteresPasswordTemporal }).FirstOrDefault().Valor;
            var longitudPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.LongitudPasswordTemporal }).FirstOrDefault().Valor;
            var passwordTemporal = LNGeneraPassword.GenerarPasswordTemporalAleatorio(caracteresPasswordTemporal, longitudPasswordTemporal);
            var saltPassword = LNGeneraPassword.GenerarSalt();
            var hashPassword = LNGeneraPassword.CalcularHash(passwordTemporal, saltPassword);
            var passwordSalt = Convert.ToBase64String(saltPassword);
            var passwordHash = Convert.ToBase64String(hashPassword);
            var resultado = us.EnviarClaveTemporalUsuarioMesaAyuda(idUsuario, passwordTemporal, passwordSalt, passwordHash);
            if (resultado != null)
                //envia correo a los usuarios aprobados y activados
                EnviarCorreoParaNotificacion(0, resultado);
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nuevoUsuario"></param>
        /// <returns></returns>
        public EDUsuarioSistema CambiarCorreoUsuario(int idUsuario, string nuevoUsuario)
        {
            var resultado = us.CambiarCorreoUsuario(idUsuario, nuevoUsuario);
            if (resultado != null)
                EnviarCorreoParaNotificacionCambioCorreo(resultado);
            return resultado;
        }
        public int ObtenerTotalUsuariosParaAprobar(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int codUsuarioAprobador)
        {
            return us.ObtenerTotalUsuariosParaAprobar(numDocEmp, numDocUsu, rolSeleccionado, idMunicipio, codUsuarioAprobador);
        }

        public EDUsuarioSistema ConsultarDatosUsuarioPorRelacionLaboral(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario)
        {
            return us.ConsultarDatosUsuarioPorRelacionLaboral(tipoDocEmp, numDocEmp, tipoDocUsuario, numDocUsuario);
        }
        /// <summary>
        /// Se regsitra la información del empleado que ha solicitado
        /// la creación de su usuario.
        /// </summary>
        /// <param name="usuarioRegistrar"></param>
        /// <returns></returns>
        public string RegistrarUsusariosParaAprobar(EDUsuarioPorAprobar usuarioRegistrar)
        {
            var resultado = string.Empty;
            try
            {
                var error = 0;
                //se valida que el usuario no esté registrado en el Sistema
                var valid = us.ValidarExistenciaUsuario(usuarioRegistrar, out error);
                if (valid == false && error == 0)
                {
                    //se valida que el usuario no tenga registrada una solicitud de aprobación pendiente
                    //para la misma empresa, mismo perfil y mismos tipo y número de identificación.
                    var validSol = us.ValidarSolicitudAprobacionPendiente(usuarioRegistrar, out error);
                    if (validSol == false && error == 0)
                    {
                        var result = us.RegistrarUsuarioParaAprobar(usuarioRegistrar);
                        if (result)
                        {
                            var enviarCorreo = EnvioCorreos.EnviarCorreo(string.Empty, string.Empty, string.Empty, false, string.Empty, 25, string.Empty, "Usuario para Aprobar", usuarioRegistrar.Correo);
                        }
                        resultado = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioParaAprobarRegistrado;
                    }
                    else if (error > 0)
                        resultado = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.ErrorUsuarioParaAprobar;
                    else
                        resultado = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.SolicitudPendienteParaAprobarExiste;
                }
                else if (error > 0)
                    resultado = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.ErrorUsuarioParaAprobar;
                else
                    resultado = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioParaAprobarExiste;
            }
            catch (Exception ex)
            {
                resultado = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.ErrorUsuarioParaAprobar;
            }
            return resultado;
        }

        /// <summary>
        /// Se registran los usuarios que han sido aprobados en la tabla UsuariosSistema
        /// y los que han sido rechazados en la tabla UsuariosRechazados
        /// </summary>
        /// <param name="usuarioRegistrar"></param>
        /// <returns></returns>
        public bool RegistrarUsusariosPorEmpresa(List<EDUsuarioPorAprobar> usuariosAprobar, out Dictionary<string, string> soporteUsuarios)
        {
            soporteUsuarios = null;
            try
            {
                //Se obtienen los usuarios que han sido aprobados
                var usuariosAprobados = usuariosAprobar.Where(ua => ua.Aprobado == true).ToList();
                //Se obtienen los usuarios que no fueron aprobados
                var usuariosNoAprobados = usuariosAprobar.Where(ua => ua.Aprobado == false).ToList();
                //Se obtienen las empresas que no se encuentran registradas en Alista
                var usuariosSinEmpresas = us.ObtenerEmpresasSinRegistrar(usuariosAprobados);
                var infoEmpresasSiarp = new List<EDEmpresas>();
                //se obtiene la informacion de las empresas ante Siarp
                foreach (var empresa in usuariosSinEmpresas)
                {
                    infoEmpresasSiarp.Add(ClienteEmpresa.ObtenerEmpresasSiarp(empresa.Value, empresa.Key));
                }
                if (infoEmpresasSiarp != null && infoEmpresasSiarp.Count > 0)
                {
                    var lnEmpresa = new LNEmpresa();
                    foreach (var infoEmp in infoEmpresasSiarp)
                    {
                        if (infoEmp != null)
                        {
                            //se guardan los roles para asociarlos a la nueva empresa
                            var emp = lnEmpresa.GuardarEmpresaYSusRelaciones(infoEmp);
                        }
                    }
                }
                //Se obtiene la información de los usuarios que han sido aprobados.
                var usuariosSistema = us.ObtenerDatosUsuariosSistema(usuariosAprobados);
                if (usuariosSistema != null && usuariosSistema.Count > 0)
                {
                    var caracteresPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CaracteresPasswordTemporal }).FirstOrDefault().Valor;
                    var longitudPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.LongitudPasswordTemporal }).FirstOrDefault().Valor;
                    var passwordTemporal = LNGeneraPassword.GenerarPasswordTemporalAleatorio(caracteresPasswordTemporal, longitudPasswordTemporal);
                    var saltPassword = LNGeneraPassword.GenerarSalt();
                    var hashPassword = LNGeneraPassword.CalcularHash(passwordTemporal, saltPassword);
                    //se le asigna clave temporal a los usuarios que han sido aprobados
                    usuariosSistema.ForEach(u =>
                    {
                        u.ClaveSalt = Convert.ToBase64String(saltPassword);
                        u.ClaveHash = Convert.ToBase64String(hashPassword);
                        u.Activo = true;
                        u.Clave = passwordTemporal;
                    });
                    //se insertan en base de datos los usuarios aprobados

                    var result = us.InsertarUsuariosAprobadosSistema(usuariosSistema, out soporteUsuarios);
                    if (result != null && result.Count() > 0)
                    {
                        foreach (var u in result)
                        {
                            //envia correo a los usuarios aprobados y activados
                            EnviarCorreoParaNotificacion((int)Enumeraciones.EnumAdministracionUsuarios.PlantillasCorreo.NotificacionAprobacionUsuario, u);
                        }
                    }
                }
                if (usuariosNoAprobados != null && usuariosNoAprobados.Count > 0)
                {
                    var result = us.InsertarUsuariosNoAprobadosSistema(usuariosNoAprobados);
                    if (result != null && result.Count() > 0 )
                    {
                        foreach (var u in result)
                        {
                            EnviarCorreoParaNotificacion((int)Enumeraciones.EnumAdministracionUsuarios.PlantillasCorreo.NotificacionRechazoUsuario, u);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioArlRegistrar"></param>
        /// <returns></returns>
        public bool RegistrarUsusariosArlPositiva(EDUsuarioPorAprobar usuarioArlRegistrar, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                var error = 0;
                EDEmpresas empresa = null;
                //Se obtienen las empresas que no se encuentran registradas en Alista
                var existenciaUsuario = us.ValidarExistenciaUsuario(usuarioArlRegistrar, out error);
                if (existenciaUsuario)
                {
                    mensaje = "El usuario ya se encuentra registrado en el Sistema.";
                    return false;
                }
                var lnEmpresa = new LNEmpresa();
                var existeEmpresa = lnEmpresa.ValidarExitenciaEmpresa(usuarioArlRegistrar.TipoDocumentoEmpresa, usuarioArlRegistrar.NumDocumentoEmpresa);
                if (existeEmpresa == null)
                {
                    //se obtiene la informacion de las empresas ante Siarp
                    empresa = ClienteEmpresa.ObtenerEmpresasSiarp(usuarioArlRegistrar.TipoDocumentoEmpresa, usuarioArlRegistrar.NumDocumentoEmpresa);
                    if (empresa != null)
                        //se guardan los roles para asociarlos a la nueva empresa
                        empresa = lnEmpresa.GuardarEmpresaYSusRelaciones(empresa);
                    else
                        mensaje = "La empresa  asociada al usuario no se encuentra en SIARP.";
                }
                else
                    empresa = existeEmpresa;
                var result = false;
                //Se obtiene la información de los usuarios que han sido aprobados.
                if (empresa != null && usuarioArlRegistrar != null)
                {
                    var estadoActivo = false;
                    var bloqueado = true;
                    if (usuarioArlRegistrar.EstadoUsuario == 1)
                    {
                        estadoActivo = true;
                        bloqueado = false;
                    }
                    else if (usuarioArlRegistrar.EstadoUsuario == 2)
                    {
                        estadoActivo = false;
                        bloqueado = false;
                    }
                    else if (usuarioArlRegistrar.EstadoUsuario == 3)
                    {
                        estadoActivo = false;
                        bloqueado = true;
                    }
                    var caracteresPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CaracteresPasswordTemporal }).FirstOrDefault().Valor;
                    var longitudPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.LongitudPasswordTemporal }).FirstOrDefault().Valor;
                    var passwordTemporal = LNGeneraPassword.GenerarPasswordTemporalAleatorio(caracteresPasswordTemporal, longitudPasswordTemporal);
                    var saltPassword = LNGeneraPassword.GenerarSalt();
                    var hashPassword = LNGeneraPassword.CalcularHash(passwordTemporal, saltPassword);
                    //se le asigna clave temporal a los usuarios que han sido aprobados
                    var usuarioArlSistema = new EDUsuarioSistema()
                    {
                        CodEmpresa = empresa.Id_Empresa,
                        TipoDocumentoEmpresa = 2,
                        DocumentoEmpresa = usuarioArlRegistrar.NumDocumentoEmpresa,
                        Nombres = usuarioArlRegistrar.Nombres,
                        Apellidos = usuarioArlRegistrar.Apellidos,
                        Documento = usuarioArlRegistrar.NumDocumentoAfi,
                        TipoDocumento = 1,//por defecto es CC
                        Correo = usuarioArlRegistrar.Correo,
                        ClaveSalt = Convert.ToBase64String(saltPassword),
                        ClaveHash = Convert.ToBase64String(hashPassword),
                        Activo = estadoActivo,
                        Bloqueado = bloqueado,
                        PrimerAcceso = true,
                        IdRol = usuarioArlRegistrar.RolUsuario,
                        Clave = passwordTemporal,
                        DepartamentoSedePpalEmpresa = usuarioArlRegistrar.DepartamentoSedePpalEmpresa,
                        MunicipioSedePpalEmpresa = usuarioArlRegistrar.MunicipioSedePpalEmpresa,
                        Telefono = usuarioArlRegistrar.Telefono,
                        PeriodoInactividad = usuarioArlRegistrar.PeriodoInactividad
                    };
                    //se insertan en base de datos los usuarios aprobados
                    result = us.InsertarUsuarioArlSistema(usuarioArlSistema);
                    if (result)
                    {
                        mensaje = "El usuario se registró con éxito en el Sistema.";
                        //envia correo a los usuarios aprobados y activados
                        EnviarCorreoParaNotificacion((int)Enumeraciones.EnumAdministracionUsuarios.PlantillasCorreo.NotificacionAprobacionUsuario, usuarioArlSistema);
                    }
                }
                else
                    mensaje = "El usuario no se pudo registrar en el Sistema. Intente más tarde.";
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// Valida la autenticidad del usuario y devuelve los 
        /// datos del usuario si la autenticación fue correcta
        /// </summary>
        /// <param name="usuarioRegistrar"></param>
        /// <returns></returns>
        public EDUsuarioSistema AutenticarUsuario(EDUsuarioSistema usuarioRegistrar)
        {
            try
            {
                var usuarioPorAutenticar = us.AutenticarUsuario(usuarioRegistrar);
                if (usuarioPorAutenticar != null)
                {
                    var saltPassword = Convert.FromBase64String(usuarioPorAutenticar.ClaveSalt);
                    var hashPassword = Convert.FromBase64String(usuarioPorAutenticar.ClaveHash);
                    var validaAutenticacion = LNGeneraPassword.VerificarPassword(usuarioRegistrar.Clave, saltPassword, hashPassword);
                    if (validaAutenticacion)
                        return usuarioPorAutenticar;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool CambiarClaveUsuario(EDUsuarioSistema usuario)
        {
            var saltPassword = LNGeneraPassword.GenerarSalt();
            var hashPassword = LNGeneraPassword.CalcularHash(usuario.Clave, saltPassword);
            //se le asigna clave temporal a los usuarios que han sido aprobados
            usuario.ClaveSalt = Convert.ToBase64String(saltPassword);
            usuario.ClaveHash = Convert.ToBase64String(hashPassword);
            usuario.Activo = true;
            usuario.Clave = string.Empty;
            usuario.PrimerAcceso = false;
            var result = us.CambiarClaveUsuario(usuario);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoDocEmp"></param>
        /// <param name="numDocEmp"></param>
        /// <param name="tipoDocUsuario"></param>
        /// <param name="numDocUsuario"></param>
        /// <returns></returns>
        public bool RecuperarClaveUsuario(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario, string respuestaUno, string respuestaDos, string respuestaTres, out string resultadoRecuperarClave)
        {
            var result = false;
            resultadoRecuperarClave = string.Empty;
            var usuario = us.ConsultarDatosUsuarioPorRelacionLaboral(tipoDocEmp, numDocEmp, tipoDocUsuario, numDocUsuario);
            if (usuario != null)
            {
                if (usuario.PreguntasSeguridad != null && usuario.PreguntasSeguridad.Count() > 0)
                {
                    var contador = 1;
                    var validaciones = new List<bool>();
                    usuario.PreguntasSeguridad.ForEach(rps =>
                    {
                        if (contador == 1)
                        {
                            var resultUno = rps.RespuestaSeguridad.Equals(respuestaUno);
                            validaciones.Add(resultUno);
                        }
                        if (contador == 2)
                        {
                            var resultDos = rps.RespuestaSeguridad.Equals(respuestaDos);
                            validaciones.Add(resultDos);
                        }
                        if (contador == 3)
                        {
                            var resultTres = rps.RespuestaSeguridad.Equals(respuestaTres);
                            validaciones.Add(resultTres);
                        }
                        contador += 1;
                    });
                    var resultRespuestas = validaciones.Where(v => v == false).ToList();
                    if (resultRespuestas == null || resultRespuestas.Count() == 0)
                    {
                        var caracteresPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CaracteresPasswordTemporal }).FirstOrDefault().Valor;
                        var longitudPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.LongitudPasswordTemporal }).FirstOrDefault().Valor;
                        var passwordTemporal = LNGeneraPassword.GenerarPasswordTemporalAleatorio(caracteresPasswordTemporal, longitudPasswordTemporal);
                        var saltPassword = LNGeneraPassword.GenerarSalt();
                        var hashPassword = LNGeneraPassword.CalcularHash(passwordTemporal, saltPassword);
                        //se le asigna clave temporal al usuario que desea recuperar su clave y 
                        //se obliga a que realice el proceso de cambiar su clave (primerAcceso = true)
                        usuario.Clave = passwordTemporal;
                        usuario.ClaveHash = Convert.ToBase64String(hashPassword);
                        usuario.ClaveSalt = Convert.ToBase64String(saltPassword);
                        usuario.PrimerAcceso = true;
                        //actualiza el usuario del sistema con una clave temporal
                        var resultado = us.ActualizarClaveUsuarioParaRecuperarClave(usuario);
                        if (resultado)
                        {
                            //envia correo a los usuarios aprobados y activados
                            EnviarCorreoParaNotificacion(0, usuario);
                            result = true;
                        }
                    }
                    else
                    {
                        var numeroIntentos = 0;
                        var resultAcInt = us.ActualizarIntentosParaRecuperarClave(usuario, out numeroIntentos);
                        if (numeroIntentos < 3)
                            resultadoRecuperarClave = "Las respuestas diligenciadas no corresponden con las registradas en el sistema.";
                        else
                            resultadoRecuperarClave = "Ha superado el número máximo de intentos permitidos (3) para recuperar su clave. Por favor comuníquese con la Mesa de Ayuda";
                    }
                }
                else
                {
                    resultadoRecuperarClave = "El usuario aún no tiene preguntas de seguridad asociadas. Debe actualizar sus datos.";
                }
            }
            else
                resultadoRecuperarClave = "No existe un usuario asociado a los datos ingresados.";
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoDocEmp"></param>
        /// <param name="numDocEmp"></param>
        /// <param name="tipoDocUsuario"></param>
        /// <param name="numDocUsuario"></param>
        /// <returns></returns>
        public bool GuardarPreguntasUsuario(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario, string respuestaUno, string respuestaDos, string respuestaTres, out string resultadoRecuperarClave)
        {
            var result = false;
            resultadoRecuperarClave = string.Empty;
            var usuario = us.ConsultarDatosUsuarioPorRelacionLaboral(tipoDocEmp, numDocEmp, tipoDocUsuario, numDocUsuario);
            if (usuario != null)
            {
                if (usuario.PreguntasSeguridad != null && usuario.PreguntasSeguridad.Count() > 0)
                {
                    var contador = 1;
                    var validaciones = new List<bool>();
                    usuario.PreguntasSeguridad.ForEach(rps =>
                    {
                        if (contador == 1)
                        {
                            var resultUno = rps.RespuestaSeguridad.Equals(respuestaUno);
                            validaciones.Add(resultUno);
                        }
                        if (contador == 2)
                        {
                            var resultDos = rps.RespuestaSeguridad.Equals(respuestaDos);
                            validaciones.Add(resultDos);
                        }
                        if (contador == 3)
                        {
                            var resultTres = rps.RespuestaSeguridad.Equals(respuestaTres);
                            validaciones.Add(resultTres);
                        }
                        contador += 1;
                    });
                    var resultRespuestas = validaciones.Where(v => v == false).ToList();
                    if (resultRespuestas == null || resultRespuestas.Count() == 0)
                    {
                        var caracteresPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CaracteresPasswordTemporal }).FirstOrDefault().Valor;
                        var longitudPasswordTemporal = us.ObtenerParametrosSistema(new List<int>() { (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.LongitudPasswordTemporal }).FirstOrDefault().Valor;
                        var passwordTemporal = LNGeneraPassword.GenerarPasswordTemporalAleatorio(caracteresPasswordTemporal, longitudPasswordTemporal);
                        var saltPassword = LNGeneraPassword.GenerarSalt();
                        var hashPassword = LNGeneraPassword.CalcularHash(passwordTemporal, saltPassword);
                        //se le asigna clave temporal al usuario que desea recuperar su clave y 
                        //se obliga a que realice el proceso de cambiar su clave (primerAcceso = true)
                        usuario.Clave = passwordTemporal;
                        usuario.ClaveHash = Convert.ToBase64String(hashPassword);
                        usuario.ClaveSalt = Convert.ToBase64String(saltPassword);
                        usuario.PrimerAcceso = true;
                        //actualiza el usuario del sistema con una clave temporal
                        var resultado = us.ActualizarClaveUsuarioParaRecuperarClave(usuario);
                        if (resultado)
                        {
                            //envia correo a los usuarios aprobados y activados
                            EnviarCorreoParaNotificacion(0, usuario);
                            result = true;
                        }
                    }
                    else
                    {
                        var numeroIntentos = 0;
                        var resultAcInt = us.ActualizarIntentosParaRecuperarClave(usuario, out numeroIntentos);
                        if (numeroIntentos < 3)
                            resultadoRecuperarClave = "Las respuestas diligenciadas no corresponden con las registradas en el sistema.";
                        else
                            resultadoRecuperarClave = "Ha superado el número máximo de intentos permitidos (3) para recuperar su cleve. Por favor comuníquese con la Mesa de Ayuda";
                    }
                }
                else
                {
                    resultadoRecuperarClave = "El usuario aún no tiene preguntas de seguridad asociadas. Debe actualizar sus datos.";
                }
            }
            else
                resultadoRecuperarClave = "No existe un usuario asociado a los datos ingresados.";
            return result;
        }

        public int ValidarExistenciaUsusarioReprLegal(string tipoDocumentoEmpresa, string numeroDocEmpresa, int RolEvaluar)
        {
            return us.ValidarExistenciaUsuarioRolRepresLegal(tipoDocumentoEmpresa, numeroDocEmpresa, RolEvaluar);
        }

        public int validarCantidadUsuariosPorRol(string tipoDocumentoEmpresa, string documentoEmpresa, int idRolSeleccionado)
        {
            return us.validarCantidadUsuariosPorRol(tipoDocumentoEmpresa, documentoEmpresa, idRolSeleccionado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codPlantilla"></param>
        /// <param name="usuario"></param>
        private void EnviarCorreoParaNotificacion(int codPlantilla, EDUsuarioSistema usuario)
        {
            var idParametros = new List<int>() {
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp
                };
            var parametros = us.ObtenerParametrosSistema(idParametros);
            var plantilla = us.ObtenerParametrosSistema(codPlantilla);
            if (plantilla == null)
                plantilla = us.ObtenerParametrosSistema(Enumeraciones.EnumAdministracionUsuarios.PlantillasCorreoPorNombre.NotificacionRecuperarClave);
            var rutaHttpSitio = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio).Select(p => p).FirstOrDefault().Valor;
            var servidorSTMP = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var remitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion).Select(p => p).FirstOrDefault().Valor;
            var correoRemitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente).Select(p => p).FirstOrDefault().Valor;
            var puertoServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var usuarioServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var passwordServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp).Select(p => p).FirstOrDefault().Valor;

            var plantillaHtml = plantilla.Valor.Replace("[[RutaHttpSitio]]", rutaHttpSitio);
            plantillaHtml = plantillaHtml.Replace("[[NombreUsuario]]", string.Format("{0} {1}", usuario.Nombres, usuario.Apellidos));
            plantillaHtml = plantillaHtml.Replace("[[EmailUsuario]]", usuario.Correo);
            plantillaHtml = plantillaHtml.Replace("[[LoguinUsuario]]", usuario.Documento);
            plantillaHtml = plantillaHtml.Replace("[[PasswordTemporal]]", usuario.Clave);
            EnvioCorreos.EnviarCorreo(plantillaHtml, correoRemitente, remitente, true, passwordServidorStmp, Convert.ToInt32(puertoServidorStmp), servidorSTMP, "Aprobación de usuario", usuario.Correo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        private void EnviarCorreoParaNotificacionCambioCorreo(EDUsuarioSistema usuario)
        {
            var idParametros = new List<int>() {
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp
                };
            var parametros = us.ObtenerParametrosSistema(idParametros);
            var plantilla = us.ObtenerParametrosSistema(Enumeraciones.EnumAdministracionUsuarios.PlantillasCorreoPorNombre.NotificacionCambioCorreo);
            var rutaHttpSitio = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio).Select(p => p).FirstOrDefault().Valor;
            var servidorSTMP = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var remitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion).Select(p => p).FirstOrDefault().Valor;
            var correoRemitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente).Select(p => p).FirstOrDefault().Valor;
            var puertoServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var usuarioServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var passwordServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp).Select(p => p).FirstOrDefault().Valor;

            var plantillaHtml = plantilla.Valor.Replace("[[RutaHttpSitio]]", rutaHttpSitio);
            plantillaHtml = plantillaHtml.Replace("[[NombreUsuario]]", string.Format("{0} {1}", usuario.Nombres, usuario.Apellidos));
            plantillaHtml = plantillaHtml.Replace("[[EmailUsuario]]", usuario.Correo);
            plantillaHtml = plantillaHtml.Replace("[[NuevoCorreo]]", usuario.Correo);
            EnvioCorreos.EnviarCorreo(plantillaHtml, correoRemitente, remitente, true, passwordServidorStmp, Convert.ToInt32(puertoServidorStmp), servidorSTMP, "Aprobación de usuario", usuario.Correo);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codPlantilla"></param>
        /// <param name="usuario"></param>
        private void EnviarCorreoParaNotificacion(int codPlantilla, EDUsuarioPorAprobar usuario)
        {
            var idParametros = new List<int>() {
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp
                };
            var parametros = us.ObtenerParametrosSistema(idParametros);
            var plantilla = us.ObtenerParametrosSistema(codPlantilla);
            var rutaHttpSitio = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio).Select(p => p).FirstOrDefault().Valor;
            var servidorSTMP = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var remitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion).Select(p => p).FirstOrDefault().Valor;
            var correoRemitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente).Select(p => p).FirstOrDefault().Valor;
            var puertoServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var usuarioServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var passwordServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp).Select(p => p).FirstOrDefault().Valor;

            var plantillaHtml = plantilla.Valor.Replace("[[RutaHttpSitio]]", rutaHttpSitio);
            plantillaHtml = plantillaHtml.Replace("[[NombreUsuario]]", string.Format("{0} {1}", usuario.Nombres, usuario.Apellidos));
            plantillaHtml = plantillaHtml.Replace("[[EmailUsuario]]", usuario.Correo);
            plantillaHtml = plantillaHtml.Replace("[[CausalRechazo]]", usuario.NombreCausalRechazo);
            EnvioCorreos.EnviarCorreo(plantillaHtml, correoRemitente, remitente, true, passwordServidorStmp, Convert.ToInt32(puertoServidorStmp), servidorSTMP, "Rechazo solicitud usuario Alissta", usuario.Correo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombrePlantilla"></param>
        /// <param name="notIncon"></param>
        /// <returns></returns>
        public EDNotificarInconsistencia EnviaNotificacionInconsistenciaLaborales(string NombrePlantilla, EDNotificarInconsistencia notIncon)
        {
            var idParametros = new List<int>() {
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp,
                    (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp
                };
            var parametros = us.ObtenerParametrosSistema(idParametros);
            var plantilla = us.ObtenerParametrosSistema(NombrePlantilla);
            var rutaHttpSitio = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RutaHttpSitio).Select(p => p).FirstOrDefault().Valor;
            var servidorSTMP = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.ServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var remitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.RemitenteNotificaion).Select(p => p).FirstOrDefault().Valor;
            var correoRemitente = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.CorreoRemitente).Select(p => p).FirstOrDefault().Valor;
            var puertoServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PuertoServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var usuarioServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.UsuarioServidorStmp).Select(p => p).FirstOrDefault().Valor;
            var passwordServidorStmp = parametros.Where(p => p.IdParametro == (int)Enumeraciones.EnumAdministracionUsuarios.ParametrosSistema.PasswordServidorStmp).Select(p => p).FirstOrDefault().Valor;

            var plantillaHtml = plantilla.Valor.Replace("[[RutaHttpSitio]]", rutaHttpSitio);
            plantillaHtml = plantillaHtml.Replace("[[NombreUsuario]]", string.Format("{0}", notIncon.Nombre_Gerente));
            plantillaHtml = plantillaHtml.Replace("[[USUARIO_SISTEMA]]", notIncon.usuario_sistema);
            plantillaHtml = plantillaHtml.Replace("[[EMPRESA_SISTEMA]]", notIncon.empresa_sistema);
            plantillaHtml = plantillaHtml.Replace("[[OBSERVACION]]", notIncon.Observacion);

            notIncon.Rta = EnvioCorreos.EnviarCorreo(plantillaHtml, correoRemitente, remitente, true, passwordServidorStmp, Convert.ToInt32(puertoServidorStmp), servidorSTMP, "Inconsistencia No. " + notIncon.Id.ToString() + " de Relaciones Laborales", notIncon.Email_Gerente);

            return notIncon;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDMenuRecursoSistema> ObtenerMenuRecursosSistema(int codRol, int codEmpresa, string documentoAsesorSST = "")
        {
            return us.ObtenerRecursosParaConfiguracionAccesos(codRol, codEmpresa, documentoAsesorSST);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="confiRecSx"></param>
        /// <param name="codRolSistema"></param>
        /// <returns></returns>
        public bool GuardarConfiguracionRecursosSistema(List<EDMenuRecursoSistema> confiRecSx, int codRolSistema, int idEmpresaUsuario)
        {
            return us.GuardarConfiguracionRecursosSistema(confiRecSx, codRolSistema, idEmpresaUsuario);
        }
        public bool GuardarConfiguracionRecursosSistemaAsesorSST(List<EDMenuRecursoSistema> confiRecSx, List<EDEmpresas> empresas)
        {
            return us.GuardarConfiguracionRecursosSistemaAsesorSST(confiRecSx, empresas);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRol"></param>
        /// <returns></returns>
        public IEnumerable<EDMenuRecursoSistema> ObtenerRecursosPorRol(int codRol, int codEmpresa)
        {
            var recursosSx = us.ObtenerRecursosPorRol(codRol, codEmpresa);
            var recursosConf = recursosSx.Select(rs => new EDMenuRecursoSistema()
            {
                IdRecursoSistema = rs.IdRecursoSistema,
                NombreRecursoSistema = rs.NombreRecursoSistema,
                CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
                UrlRecursoSistema = rs.UrlRecursoSistema,
                Controlador = rs.UrlRecursoSistema.Split('/')[1],
                Accion = rs.UrlRecursoSistema.Split('/')[2]
            }).OrderBy(rs => rs.IdRecursoSistema).ToList();
            return recursosConf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRol"></param>
        /// <returns></returns>
        public IEnumerable<EDMenuRecursoSistema> ObtenerRecursosPorRolMenu(int codRol, int codEmpresa)
        {
            var recursosSx = us.ObtenerRecursosPorRolMenu(codRol, codEmpresa);
            var recursosConf = recursosSx.Select(rs => new EDMenuRecursoSistema()
            {
                IdRecursoSistema = rs.IdRecursoSistema,
                NombreRecursoSistema = rs.NombreRecursoSistema,
                CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
                UrlRecursoSistema = rs.UrlRecursoSistema,
               
            }).OrderBy(rs => rs.IdRecursoSistema).ToList();
            return recursosConf;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDocumento"></param>
        /// <returns></returns>
        public IEnumerable<EDEmpresas> ObtenerDatosUsuarioAsesorSST(string numDocumento)
        {
            var resultado = us.ObtenerDatosUsuarioAsesorSST(numDocumento);
            return resultado;
        }

        public List<EDUsuarioSistema> ConsultaUsuariosSistema(int idEstado, string NitEmpresa, int numPgina, int cantidadPorPagina)
        {
            return us.ConsultarUsuariosSistemaPorNit(idEstado, NitEmpresa, numPgina, cantidadPorPagina);
        }

        public List<EDUsuarioSistema> ConsultaEstadosUsuario()
        {
            return us.ConsultarEstadosUsuarios();
        }

        public bool ActualizarUsuario(EDUsuarioSistema Usuario)
        {
            return us.ActualizarEstadoUsuario(Usuario);
        }

        public bool IngresarPreguntasSeguridad(EDUsuarioPorAprobar usuarioRegistrar)
        {
            return us.IngresarPreguntasSeguridad(usuarioRegistrar);
        }


        public List<EDMunicipio> ObtenerMunicipios(int codUsuarioAprobador)
        {
            return us.ObtenerMunicipios(codUsuarioAprobador);
        }

        public EDRecursosDefault CargarExcelRecursosDefault(string path)
        {
            RegistraLog registraLog = new RegistraLog();
            EDRecursosDefault edrecursosdefault = new EDRecursosDefault();
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
                {
                    var sheet = package.Workbook.Worksheets["Plano"];
                    bool validaEstruc = ValidarNombreColumnas(sheet);
                    if (validaEstruc)
                        edrecursosdefault = ProcesarCargue(sheet);
                    else
                        edrecursosdefault.mensaje = "El cargue fallo: Los nombres de las columnas de la plantilla fueron modificados.";
                    edrecursosdefault.respuesta = false;
                    return edrecursosdefault;
                }
            }
            catch (Exception ex)
            {
                registraLog.RegistrarError(typeof(EDRecursosDefault), string.Format("Error en el método CargarExcelRecursosDefault {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                edrecursosdefault.mensaje = "El proceso  fallo: La estructura del archivo no es valida";
                edrecursosdefault.respuesta = false;
                return edrecursosdefault;
            }
        }
        private bool ValidarNombreColumnas(ExcelWorksheet sheet)
        {
            if (sheet.Cells[1, 1].Value.Equals("ID Recurso") && sheet.Cells[1, 2].Value.Equals("Opciones del Sistema")
                && sheet.Cells[1, 3].Value.Equals("IDROL") &&
                sheet.Cells[1, 4].Value.Equals("ROL") &&
                sheet.Cells[1, 5].Value.Equals("PERMISO")
                )
                return true;
            else
                return false;
        }

        private EDRecursosDefault ProcesarCargue(ExcelWorksheet sheet)
        {
            string mensaje = "";
            List<EDRecursosDefault> recursoPorDefautl = new List<EDRecursosDefault>();
            RegistraLog registraLog = new RegistraLog();
            try
            {
                int rowCont = sheet.Dimension.End.Row;
                for (var fila = 2; fila <= rowCont; fila++)
                {
                    if (sheet.Cells[fila, 1].Value != null && sheet.Cells[fila, 2].Value != null &&
                        sheet.Cells[fila, 3].Value != null && sheet.Cells[fila, 4].Value != null &&
                        sheet.Cells[fila, 5].Value != null)
                    {

                        if (sheet.Cells[fila, 5].Value.Equals("NO"))
                        {
                            EDRecursosDefault recursoPorRol = new EDRecursosDefault();
                            recursoPorRol.idRecurso = int.Parse(sheet.Cells[fila, 1].Value.ToString());
                            recursoPorRol.idRol = int.Parse(sheet.Cells[fila, 3].Value.ToString());
                            bool respuestaIdRecurso = us.validarIdRecursoSistema(recursoPorRol.idRecurso);
                            bool respuestaIdRol = us.validarIdRolSistema(recursoPorRol.idRol);
                            if (respuestaIdRecurso && respuestaIdRol)
                            {
                                recursoPorDefautl.Add(recursoPorRol);
                            }
                            else
                            {
                                if (!respuestaIdRecurso && !respuestaIdRol)
                                {
                                    mensaje = mensaje + string.Format("el siguiente IdRecurso sistema:{0} y el siguiente IdRol sistema {1} en la fila {2} no se encuentran registrados en sistema; ", recursoPorRol.idRecurso, recursoPorRol.idRol, fila);
                                }
                                else
                                {
                                    if (!respuestaIdRecurso)
                                    {
                                        mensaje = mensaje + string.Format("el siguiente IdRecurso sistema:{0} en la fila {1} no se encuentra registrado en sistema; ", recursoPorRol.idRecurso, fila);

                                    }
                                    else
                                    {
                                        EDRecursosDefault recursoRolNoExite = new EDRecursosDefault();
                                        recursoRolNoExite.respuesta = false;
                                        recursoRolNoExite.mensaje = string.Format("No fue posible realizar el guardo,el siguiente IdRol sistema {0} en la fila {1} no se encuentra registrado en sistema; ", recursoPorRol.idRol, fila);
                                        return recursoRolNoExite;
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        mensaje = mensaje + string.Format("La siguiente fila tiene celdas en blanco: {0}; ", fila);
                    }
                }

                EDRecursosDefault recurso = new EDRecursosDefault();
                if (us.ElimiarRecursosPorDefaultXIdRol(recursoPorDefautl.FirstOrDefault().idRol))
                {
                    recurso.respuesta = us.GuardarRecursosDefault(recursoPorDefautl);
                }
                else
                {
                    recurso.mensaje = "Error eliminando los anterior recursos por defecto";
                    recurso.respuesta = false;
                    return recurso;
                }


                if (recurso.respuesta)
                {
                    if (mensaje != "")
                        recurso.mensaje = "Archivo de los roles por defecto cargado con éxito, Observaciones: " + mensaje;
                    else
                        recurso.mensaje = "Archivo de los roles por defecto cargado con éxito, Observaciones: Ninguna";
                }
                else
                {
                    recurso.mensaje = "Error Guardando en la base de datos";
                }
                return recurso;
            }
            catch (Exception ex)
            {
                registraLog.RegistrarError(typeof(EDRecursosDefault), string.Format("Error en el método CargarExcelRecursosDefault {0}: {1}", DateTime.Now, ex.StackTrace), ex);
                EDRecursosDefault recursoPorRol = new EDRecursosDefault();
                recursoPorRol.mensaje = "El proceso  fallo: hubo un error leyendo una fila";
                recursoPorRol.respuesta = false;
                return recursoPorRol;
            }

        }
    }
}
