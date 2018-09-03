using RestSharp;
using SG_SST.Audotoria;
using SG_SST.Controllers.Base;
using SG_SST.EntidadesDominio.Empresas;
using SG_SST.EntidadesDominio.Usuario;
using SG_SST.Helpers;
using SG_SST.Logica.Ausentismo;
using SG_SST.Logica.Empresas;
using SG_SST.Logica.Usuarios;
using SG_SST.Models.AdminUsuarios;
using SG_SST.Models.Usuarios;
using SG_SST.ServiceRequest;
using SG_SST.Utilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Controllers.AdminUsuarios
{
    public class AdminUsuariosController : BaseController
    {
        RegistraLog registroLog = new RegistraLog();
        private string claveTemporalUsuarios = ConfigurationManager.AppSettings["ClaveTemporalUsuarioSistema"];
        //private string Usupuedeaprobar = ConfigurationManager.AppSettings["Usupuedeaprobar"];
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var lnUsuario = new LNUsuario();
            var adminSistema = new AdministrarUsuariosModel();
            adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            return View(adminSistema);
        }
        /// <summary>
        /// Registra un nuevo usuario para ser aprobado. Previo a esto se valida
        /// la siguiente información:
        /// 1. Que la empresa exista y se encuentra activa
        /// 2. Que el empleado exista y se encuentre activo
        /// 3. si el rol del usuario a aprobar es diferente de Representante legal,
        /// se debe validar que dicha empresa tenga ya creado y aprobado un usuario
        /// con rol de representante legal.
        /// 4. Se debe validar que no se hayan superado el la cantidad de usuarios para
        /// el rol a crear.
        /// </summary>
        /// <param name="adminSistema"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(AdministrarUsuariosModel usuarioSolicitado)
        {
            var accion = string.Empty;
            if (usuarioSolicitado != null && usuarioSolicitado.IdRolSeleccionado > 0)
            {
                switch (usuarioSolicitado.IdRolSeleccionado)
                {
                    case (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST: //Asesor SST
                        accion = "RegistrarSolicitudUsuarioAsesorSST";
                        break;
                    default:
                        TempData["RolSeleccionado"] = usuarioSolicitado.IdRolSeleccionado;
                        accion = "RegistrarSolicitudUsuarioEmpresa";
                        break;
                }
                return RedirectToAction(accion);
            }
            else
            {
                var lnUsuario = new LNUsuario();
                usuarioSolicitado.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
                {
                    Value = rs.IdRolSistema.ToString(),
                    Text = rs.NombreRol
                }).ToList();
                return View(usuarioSolicitado);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistrarSolicitudUsuarioEmpresa()
        {
            var lnUsuario = new LNUsuario();
            var adminSistema = new AdministrarUsuariosModel();
            adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            adminSistema.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
            {
                PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                {
                    Value = ps.IdPreguntaSeguridad.ToString(),
                    Text = ps.NombrePreguntaSeguridad
                }).ToList()
            };
            adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 1 && rs.IdRolSistema != 11).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol,
            }).ToList();
            if (TempData["RolSeleccionado"] != null)
            {
                var idRolSelecciondo = (int)TempData["RolSeleccionado"];
                var rolseleccionado = adminSistema.RolesRegistrados.Where(rr => rr.Value.Equals(idRolSelecciondo.ToString())).Select(rr => rr).FirstOrDefault();
                adminSistema.RolesRegistrados = new List<SelectListItem>() { rolseleccionado };
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(adminSistema);
        }
        /// <summary>
        /// Registra un nuevo usuario para ser aprobado. Previo a esto se valida
        /// la siguiente información:
        /// 1. Que la empresa exista y se encuentra activa
        /// 2. Que el empleado exista y se encuentre activo
        /// 3. si el rol del usuario a aprobar es diferente de Representante legal,
        /// se debe validar que dicha empresa tenga ya creado y aprobado un usuario
        /// con rol de representante legal.
        /// 4. Se debe validar que no se hayan superado el la cantidad de usuarios para
        /// el rol a crear.
        /// </summary>
        /// <param name="adminSistema"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegistrarSolicitudUsuarioEmpresa(AdministrarUsuariosModel adminSistema)
        {
            var lnUsuario = new LNUsuario();
            if (!ModelState.IsValid)
            {
                adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                {
                    Value = td.Sigla,
                    Text = td.Descripcion
                }).ToList();
                adminSistema.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
                {
                    PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                    {
                        Value = ps.IdPreguntaSeguridad.ToString(),
                        Text = ps.NombrePreguntaSeguridad
                    }).ToList()
                };
                adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema != 11 && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
                {
                    Value = rs.IdRolSistema.ToString(),
                    Text = rs.NombreRol
                }).ToList();
                return View(adminSistema);
            }
            else
            {
                if (!reCaptcha.ReCaptcha.Validate(privateKey: System.Configuration.ConfigurationManager.AppSettings["ReCaptchaPrivateKey"].ToString()))
                {
                    adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                    {
                        Value = td.Sigla,
                        Text = td.Descripcion
                    }).ToList();
                    adminSistema.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
                    {
                        PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                        {
                            Value = ps.IdPreguntaSeguridad.ToString(),
                            Text = ps.NombrePreguntaSeguridad
                        }).ToList()
                    };
                    adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema != 11 && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
                    {
                        Value = rs.IdRolSistema.ToString(),
                        Text = rs.NombreRol
                    }).ToList();
                    return View(adminSistema);
                }
                int resultEmpresa = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp;
                int resultEmpleado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteAfi;
                var objEmpAfil = ConsultaSIARP.ConsultarAfiliadoEmpresaActivos(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, adminSistema.TipoDocumento, adminSistema.Documento, out resultEmpresa, out resultEmpleado);
                //la empresa existe y se encuentra activa
                if (resultEmpresa == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoEmp)
                {
                    //el empleado existe y se encuentra activo
                    if (resultEmpleado == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoAfi)
                    {
                        var resultExistenciaUsuarioRL = lnUsuario.ValidarExistenciaUsusarioReprLegal(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.RepresentanteLegal);
                        //valida que el usuario con rol especificado exista y se encuentre activo
                        if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExisteActivo == resultExistenciaUsuarioRL)
                        {
                            var resultCantUsuarios = lnUsuario.validarCantidadUsuariosPorRol(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, adminSistema.IdRolSeleccionado);
                            //valida la cantidad máxima de usuarios por rol que se pueden crear para la empresa
                            if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.SePuedeCrear == resultCantUsuarios)
                            {
                                //se registra un nuevo usuario en el sistema
                                adminSistema.Nombres = string.Format("{0} {1}", objEmpAfil.nombre1, objEmpAfil.nombre2);
                                adminSistema.Apellidos = string.Format("{0} {1}", objEmpAfil.apellido1, objEmpAfil.apellido2);
                                ViewBag.Mensaje = CrearUsuarioSistema(adminSistema);
                            }
                            else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.NoSePuedeCrearTodosAprobados == resultCantUsuarios)
                                ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.CantidadUsuariosAprobadosPorRolSuperada;
                            else
                                ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.CantidadUsuariosPorRolSuperada;
                        }
                        else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.NoExiste == resultExistenciaUsuarioRL)
                        {
                            if (adminSistema.IdRolSeleccionado == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.RepresentanteLegal)
                            {
                                //se registra un nuevo usuario en el sistema
                                adminSistema.Nombres = string.Format("{0} {1}", objEmpAfil.nombre1, objEmpAfil.nombre2);
                                adminSistema.Apellidos = string.Format("{0} {1}", objEmpAfil.apellido1, objEmpAfil.apellido2);
                                ViewBag.Mensaje = CrearUsuarioSistema(adminSistema);
                            }
                            else
                                ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioPorRolNoExiste;
                        }
                        else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExistePorAprobar == resultExistenciaUsuarioRL)
                            ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioPorRolPorAprobar;
                        else
                            ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioPorRolInactivo;
                    }
                    else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteAfi == resultEmpleado)
                        ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpleadoNoExiste;
                    else
                        ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpleadoInactivo;
                }
                else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp == resultEmpresa)
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaNoExiste;
                else
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaInactiva;
            }
            var usuario = new AdministrarUsuariosModel();
            usuario.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            usuario.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
            {
                PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                {
                    Value = ps.IdPreguntaSeguridad.ToString(),
                    Text = ps.NombrePreguntaSeguridad
                }).ToList()
            };
            usuario.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema != 11 && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            return View(usuario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistrarSolicitudUsuarioAsesorSST()
        {
            var lnUsuario = new LNUsuario();
            var adminSistema = new AdministrarUsuarioAsesorSSTModel();
            adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            adminSistema.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
            {
                PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                {
                    Value = ps.IdPreguntaSeguridad.ToString(),
                    Text = ps.NombrePreguntaSeguridad
                }).ToList()
            };
            adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            return View(adminSistema);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminSistema"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegistrarSolicitudUsuarioAsesorSST(AdministrarUsuarioAsesorSSTModel adminSistema)
        {
            var lnUsuario = new LNUsuario();
            if (!ModelState.IsValid)
            {
                adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                {
                    Value = td.Sigla,
                    Text = td.Descripcion
                }).ToList();
                adminSistema.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
                {
                    PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                    {
                        Value = ps.IdPreguntaSeguridad.ToString(),
                        Text = ps.NombrePreguntaSeguridad
                    }).ToList()
                };
                adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
                {
                    Value = rs.IdRolSistema.ToString(),
                    Text = rs.NombreRol
                }).ToList();
                return View(adminSistema);
            }
            else
            {
                if (!reCaptcha.ReCaptcha.Validate(privateKey: System.Configuration.ConfigurationManager.AppSettings["ReCaptchaPrivateKey"].ToString()))
                {
                    adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                    {
                        Value = td.Sigla,
                        Text = td.Descripcion
                    }).ToList();
                    adminSistema.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
                    {
                        PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                        {
                            Value = ps.IdPreguntaSeguridad.ToString(),
                            Text = ps.NombrePreguntaSeguridad
                        }).ToList()
                    };
                    adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
                    {
                        Value = rs.IdRolSistema.ToString(),
                        Text = rs.NombreRol
                    }).ToList();
                    return View(adminSistema);
                }
                var resultExistenciaUsuarioRL = lnUsuario.ValidarExistenciaUsusarioReprLegal(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.RepresentanteLegal);
                //valida que el usuario con rol especificado exista y se encuentre activo
                if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExisteActivo == resultExistenciaUsuarioRL)
                {
                    var resultCantUsuarios = lnUsuario.validarCantidadUsuariosPorRol(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, adminSistema.IdRolSeleccionado);
                    //valida la cantidad máxima de usuarios por rol que se pueden crear para la empresa
                    if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.SePuedeCrear == resultCantUsuarios)
                    {
                        var nuevoGuid = Guid.NewGuid();
                        adminSistema.GuidTemporal = nuevoGuid;
                        adminSistema.RutaPdfAutorizacion = ManejoArchivos.GuardarArchivos(adminSistema.PdfAutorizacion, rutaFisicaDocumentosPdfAutorizacion, nuevoGuid, usuarioImp, passwordImp, dominio);
                        //se registra un nuevo usuario en el sistema
                        ViewBag.Mensaje = CrearUsuarioAsesorSSTSistema(adminSistema);
                    }
                    else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.NoSePuedeCrearTodosAprobados == resultCantUsuarios)
                        ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.CantidadUsuariosAprobadosPorRolSuperada;
                    else
                        ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.CantidadUsuariosPorRolSuperada;
                }
                else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.NoExiste == resultExistenciaUsuarioRL)
                {
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioPorRolNoExiste;
                }
                else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExistePorAprobar == resultExistenciaUsuarioRL)
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioPorRolPorAprobar;
                else
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.UsuarioPorRolInactivo;

            }
            var usuario = new AdministrarUsuarioAsesorSSTModel();
            usuario.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            usuario.ConfiguracionPreguntasSeguridad = new ConfiguracionPreguntasSeguridad()
            {
                PreguntasSeguridad = lnUsuario.ObtenerPreguntasSeguridad().Select(ps => new SelectListItem()
                {
                    Value = ps.IdPreguntaSeguridad.ToString(),
                    Text = ps.NombrePreguntaSeguridad
                }).ToList()
            };
            usuario.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Where(rs => rs.IdRolSistema == 11 && rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            return View(usuario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoDocumentoEmp"></param>
        /// <param name="numDocumentoEmp"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConsultarInformacionEmpresaSiarp(string tipoDocumentoEmp, string numDocumentoEmp)
        {
            var resultadoEmp = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp;
            var resultado = ConsultaSIARP.ConsultarDatosEmpresaSiarp(tipoDocumentoEmp, numDocumentoEmp, out resultadoEmp);
            //la empresa existe y se encuentra activa
            if (resultadoEmp == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoEmp)
            {
                var lnUsuario = new LNUsuario();
                return Json(new
                {
                    Telefono = resultado.telefonoEmpresa,
                    RazonSocialEmpresa = resultado.razonSocial,
                    MunicipioSedePpalEmrpresa = resultado.municipio,
                    MensajeError = string.Empty,
                    Estado = "OK"
                });
            }
            else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp == resultadoEmp)
                return Json(new
                {
                    RazonSocialEmpresa = string.Empty,
                    MunicipioSedePpalEmrpresa = string.Empty,
                    MensajeError = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaNoExiste,
                    Estado = "OK"
                });
            else
                return Json(new
                {
                    RazonSocialEmpresa = string.Empty,
                    MunicipioSedePpalEmrpresa = string.Empty,
                    MensajeError = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaInactiva,
                    Estado = "OK"
                });
        }
        /// <summary>
        /// Consulta información de la empresa y usuario ante SIARP
        /// y devuelve un json con los nombres y apellidos del usuario 
        /// asociado a la empresa consultada.
        /// </summary>
        /// <param name="tipoDocumentoEmp"></param>
        /// <param name="numDocumentoEmp"></param>
        /// <param name="tipoDocumento"></param>
        /// <param name="numDucumento"></param>
        /// <param name="resultadoEmp"></param>
        /// <param name="resultadoAfi"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConsultarInformacionUsuarioEmpresaSiarp(string tipoDocumentoEmp, string numDocumentoEmp, string tipoDocumento, string numDucumento)
        {
            var resultadoEmp = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp;
            var resultadoAfi = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteAfi;
            var resultado = ConsultaSIARP.ConsultarAfiliadoEmpresaActivos(tipoDocumentoEmp, numDocumentoEmp, tipoDocumento, numDucumento, out resultadoEmp, out resultadoAfi);
            //la empresa existe y se encuentra activa
            if (resultadoEmp == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoEmp)
            {
                //el empleado existe y se encuentra activo
                if (resultadoAfi == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoAfi)
                {
                    var lnUsuario = new LNUsuario();
                    var usuarioRecupClave = lnUsuario.ConsultarDatosUsuarioPorRelacionLaboral(tipoDocumentoEmp, numDocumentoEmp, tipoDocumento, numDucumento);
                    return Json(new
                    {
                        NombresUsuario = string.Format("{0} {1}", resultado.nombre1, resultado.nombre2),
                        ApellidosUsuario = string.Format("{0} {1}", resultado.apellido1, resultado.apellido2),
                        Telefono = resultado.telPersona,
                        RazonSocialEmpresa = resultado.razonSocial,
                        MunicipioSedePpalEmrpresa = resultado.nomMunEmpresa,
                        PreguntasSeguridad = usuarioRecupClave == null ? new List<PreguntasSeguridadSeleccionada>() { } : usuarioRecupClave.PreguntasSeguridad,
                        MensajeError = string.Empty,
                        Estado = "OK"
                    });
                }
                else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteAfi == resultadoAfi)
                    return Json(new
                    {
                        NombresUsuario = string.Empty,
                        ApellidosUsuario = string.Empty,
                        RazonSocialEmpresa = string.Empty,
                        MunicipioSedePpalEmrpresa = string.Empty,
                        MensajeError = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpleadoNoExiste,
                        Estado = "OK"
                    });
                else
                    return Json(new { NombresUsuario = string.Empty, ApellidosUsuario = string.Empty, MensajeError = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpleadoInactivo, Estado = "OK" });
            }
            else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp == resultadoEmp)
                return Json(new
                {
                    NombresUsuario = string.Empty,
                    ApellidosUsuario = string.Empty,
                    RazonSocialEmpresa = string.Empty,
                    MunicipioSedePpalEmrpresa = string.Empty,
                    MensajeError = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaNoExiste,
                    Estado = "OK"
                });
            else
                return Json(new
                {
                    NombresUsuario = string.Empty,
                    ApellidosUsuario = string.Empty,
                    RazonSocialEmpresa = string.Empty,
                    MunicipioSedePpalEmrpresa = string.Empty,
                    MensajeError = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaInactiva,
                    Estado = "OK"
                });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutorizacionAdminSistema]
        public ActionResult AprobarUsuariosSistema()
        {
            var codUsuarioAprobador = 0;
            var objUsuarioSesion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objUsuarioSesion == null)
            {
                ViewBag.Mensaje = "La sesion a finalizado.";
                return RedirectToAction("Login", "Home");
            }
            else
                codUsuarioAprobador = objUsuarioSesion.IdUsuario;
            var lnUsuario = new LNUsuario();
            ViewBag.RolesSistema = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();

            ViewBag.Municipios = lnUsuario.ObtenerMunicipios(codUsuarioAprobador).Select(rs => new SelectListItem()
            {
                Value = rs.IdMunicipio.ToString(),
                Text = rs.NombreMunicipio
            }).ToList();
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuariosAprobar"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AprobarUsuariosSistema(List<AdministrarUsuarioAsesorSSTModel> usuariosAprobar)
        {
            var lnUsuario = new LNUsuario();
            var usuariosSistema = usuariosAprobar.Select(u => new EDUsuarioPorAprobar()
            {
                IdUsuarioPorAprobar = u.IdUsuarioSistema,
                TipoDocumentoEmpresa = u.TipoDocumentoEmpresa,
                NumDocumentoEmpresa = u.DocumentoEmpresa,
                TipoDocumentoAfi = u.TipoDocumento,
                NumDocumentoAfi = u.Documento,
                Aprobado = string.IsNullOrEmpty(u.IdCausalRechazoSeleccionada) ? u.Aprobado : false,
                Nombres = string.IsNullOrEmpty(u.Nombres) ? string.Empty : u.Nombres.TrimStart().TrimEnd(),
                Apellidos = string.IsNullOrEmpty(u.Apellidos) ? string.Empty : u.Apellidos.TrimStart().TrimEnd(),
                Correo = string.IsNullOrEmpty(u.EmailPersona) ? string.Empty : u.EmailPersona.TrimStart().TrimEnd(),
                CausalRechazo = string.IsNullOrEmpty(u.IdCausalRechazoSeleccionada) ? 0 : Convert.ToInt32(u.IdCausalRechazoSeleccionada),
                NombreCausalRechazo = string.IsNullOrEmpty(u.CausalRechazoSeleccionada) ? string.Empty : u.CausalRechazoSeleccionada.TrimStart().TrimEnd(),
                PeriodoInactividad = string.IsNullOrEmpty(periodoInactivacionUsuario) ? DateTime.Now.AddDays(30) : DateTime.Now.AddDays(Convert.ToInt32(periodoInactivacionUsuario)),
                RutaPdfAutorizacion = u.RutaPdfAutorizacion
            }).ToList();
            Dictionary<string, string> soporteUsuarios = null;
            var result = lnUsuario.RegistrarUsusariosPorEmpresa(usuariosSistema, out soporteUsuarios);
            if (soporteUsuarios != null)
            {
                foreach (var item in soporteUsuarios)
                {
                    ManejoArchivos.ActualizarRutaArchivos(item.Key, item.Value, usuarioImp, passwordImp, dominio);
                }
            }
            if (result)
            {
                var adminSistema1 = lnUsuario.ObtenerUsuariosParaAprobar(string.Empty, string.Empty, string.Empty, string.Empty, 1, 0);
            
                var usuariosAprobar1 = adminSistema1.Select(ua => new AdministrarUsuarioAsesorSSTModel()
                {
                    IdUsuarioSistema = ua.IdUsuarioPorAprobar,
                    IdRolSeleccionado = ua.IdUsuarioPorAprobar,
                    Nombres = ua.Nombres,
                    Apellidos = ua.Apellidos,
                    TipoDocumentoEmpresa = ua.TipoDocumentoEmpresa,
                    DocumentoEmpresa = ua.NumDocumentoEmpresa,
                    RazonSocialEmpresa = ua.RazonSocialEmpresa,
                    MunicipioSedePpalEmpresa = ua.MunicipioSedePpalEmpresa,
                    TipoDocumento = ua.TipoDocumentoAfi,
                    Documento = ua.NumDocumentoAfi,
                    NombreRolSeleccionado = ua.NombreRol,
                    EmailPersona = ua.Correo,
                    FechaInicioContrato = ua.FechaInicioContrato,
                    FechaFinContrato = ua.FechaFinContrato,
                    RutaPdfAutorizacion = ua.RutaPdfAutorizacion,
                    CausalesRechazoUsuarioSistema = lnUsuario.ObtenerCausalesRechazoUsuariosSistema().Select(crs => new SelectListItem()
                    {
                        Value = crs.IdCausalRechazo.ToString(),
                        Text = crs.NombreCausalRechazo
                    }).ToList()
                }).ToList();
                Dictionary<int, ConfigurarDatosAdicionalesModel> relacionDatosAdi = new Dictionary<int, ConfigurarDatosAdicionalesModel>();
                foreach (var usuarios in adminSistema1)
                {
                    var datosAdicion = new ConfigurarDatosAdicionalesModel();
                    usuarios.DatosAdicionales.ForEach(dau =>
                    {
                        if (dau.NombreDato == "FechaInicioContrato")
                        {
                            datosAdicion.FechaInicioContrato = dau.ValorDato.Substring(0,10);
                        }
                        if (dau.NombreDato == "FechaFinContrato")
                        {
                            datosAdicion.FechaFinContrato = dau.ValorDato.Substring(0,10);
                        }

                    });
                    relacionDatosAdi.Add(usuarios.IdUsuarioPorAprobar, datosAdicion);
                }
                var usuariosAAFinal = (from ua in usuariosAprobar
                                       join da in relacionDatosAdi on ua.IdUsuarioSistema equals da.Key
                                       select new AdministrarUsuarioAsesorSSTModel
                                       {
                                           IdUsuarioSistema = ua.IdUsuarioSistema,
                                           IdRolSeleccionado = ua.IdRolSeleccionado,
                                           Nombres = ua.Nombres,
                                           Apellidos = ua.Apellidos,
                                           TipoDocumentoEmpresa = ua.TipoDocumentoEmpresa,
                                           DocumentoEmpresa = ua.DocumentoEmpresa,
                                           RazonSocialEmpresa = ua.RazonSocialEmpresa,
                                           MunicipioSedePpalEmpresa = ua.MunicipioSedePpalEmpresa,
                                           TipoDocumento = ua.TipoDocumento,
                                           Documento = ua.Documento,
                                           NombreRolSeleccionado = ua.NombreRolSeleccionado,
                                           EmailPersona = ua.EmailPersona,
                                           FechaInicioContrato = ua.FechaInicioContrato,
                                           FechaFinContrato = ua.FechaFinContrato,
                                           RutaPdfAutorizacion = ua.RutaPdfAutorizacion,
                                           CausalesRechazoUsuarioSistema = lnUsuario.ObtenerCausalesRechazoUsuariosSistema().Select(crs => new SelectListItem()
                                           {
                                               Value = crs.IdCausalRechazo.ToString(),
                                               Text = crs.NombreCausalRechazo
                                           }).ToList(),
                                           ConfigurarDatosAdicionalesModel = da.Value == null ? null : da.Value
                                       }).ToList();
                //var adminSistema = lnUsuario.ObtenerUsuariosParaAprobar(string.Empty, string.Empty, string.Empty, string.Empty, 1, 0).Select(ua => new AdministrarUsuarioAsesorSSTModel()
                //{
                //    IdUsuarioSistema = ua.IdUsuarioPorAprobar,
                //    IdRolSeleccionado = ua.IdUsuarioPorAprobar,
                //    Nombres = ua.Nombres,
                //    Apellidos = ua.Apellidos,
                //    TipoDocumentoEmpresa = ua.TipoDocumentoEmpresa,
                //    DocumentoEmpresa = ua.NumDocumentoEmpresa,
                //    TipoDocumento = ua.TipoDocumentoAfi,
                //    Documento = ua.NumDocumentoAfi,
                //    NombreRolSeleccionado = ua.NombreRol,
                //    EmailPersona = ua.Correo,
                //    RutaPdfAutorizacion = ua.RutaPdfAutorizacion,
                //    CausalesRechazoUsuarioSistema = lnUsuario.ObtenerCausalesRechazoUsuariosSistema().Select(crs => new SelectListItem()
                //    {
                //        Value = crs.IdCausalRechazo.ToString(),
                //        Text = crs.NombreCausalRechazo
                //    }).ToList()
                //}).ToList();
                var datos = RenderRazorViewToString("_AprobarUsuarioSistema", usuariosAAFinal);
                return Json(new { Datos = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, Mensaje = "NOTFOUND" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDocEmp"></param>
        /// <param name="numDocUsu"></param>
        /// <param name="rolSeleccionado"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BuscarUsuariosAprobarBuscador(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int paginaActual = 0)
        {
            var lnUsuario = new LNUsuario();
            var codUsuarioAprobador = 0;
            var usuario = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuario != null)
            {
                codUsuarioAprobador = usuario.IdUsuario;
            }
            var cantRegistrosPag = Convert.ToInt32(cantidadRegistrosPagina);
            var adminSistema = lnUsuario.ObtenerUsuariosParaAprobar(numDocEmp, numDocUsu, rolSeleccionado, idMunicipio, paginaActual, codUsuarioAprobador);
            var totalRegistros = lnUsuario.ObtenerTotalUsuariosParaAprobar(numDocEmp, numDocUsu, rolSeleccionado, idMunicipio, codUsuarioAprobador);
            if (adminSistema != null && adminSistema.Count() > 0)
            {
                var usuariosAprobar = adminSistema.Select(ua => new AdministrarUsuarioAsesorSSTModel()
                {
                    IdUsuarioSistema = ua.IdUsuarioPorAprobar,
                    IdRolSeleccionado = ua.IdUsuarioPorAprobar,
                    Nombres = ua.Nombres,
                    Apellidos = ua.Apellidos,
                    TipoDocumentoEmpresa = ua.TipoDocumentoEmpresa,
                    DocumentoEmpresa = ua.NumDocumentoEmpresa,
                    RazonSocialEmpresa = ua.RazonSocialEmpresa,
                    MunicipioSedePpalEmpresa = ua.MunicipioSedePpalEmpresa,
                    TipoDocumento = ua.TipoDocumentoAfi,
                    Documento = ua.NumDocumentoAfi,
                    NombreRolSeleccionado = ua.NombreRol,
                    EmailPersona = ua.Correo,                    
                    RutaPdfAutorizacion = ua.RutaPdfAutorizacion,
                    CausalesRechazoUsuarioSistema = lnUsuario.ObtenerCausalesRechazoUsuariosSistema().Select(crs => new SelectListItem()
                    {
                        Value = crs.IdCausalRechazo.ToString(),
                        Text = crs.NombreCausalRechazo
                    }).ToList()
                }).ToList();
                Dictionary<int, ConfigurarDatosAdicionalesModel> relacionDatosAdi = new Dictionary<int, ConfigurarDatosAdicionalesModel>();
                foreach (var usuarios in adminSistema)
                {
                    var datosAdicion = new ConfigurarDatosAdicionalesModel();
                    usuarios.DatosAdicionales.ForEach(dau =>
                    {
                        if (dau.NombreDato == "FechaInicioContrato")
                        {
                            datosAdicion.FechaInicioContrato = dau.ValorDato.Substring(0,10);
                        }
                        if (dau.NombreDato == "FechaFinContrato")
                        {
                            datosAdicion.FechaFinContrato = dau.ValorDato.Substring(0,10);
                        }

                    });
                    relacionDatosAdi.Add(usuarios.IdUsuarioPorAprobar, datosAdicion);
                }
                var usuariosAAFinal = (from ua in usuariosAprobar
                                       join da in relacionDatosAdi on ua.IdUsuarioSistema equals da.Key
                                       select new AdministrarUsuarioAsesorSSTModel
                                       {
                                            IdUsuarioSistema = ua.IdUsuarioSistema,
                                            IdRolSeleccionado = ua.IdRolSeleccionado,
                                            Nombres = ua.Nombres,
                                            Apellidos = ua.Apellidos,
                                            TipoDocumentoEmpresa = ua.TipoDocumentoEmpresa,
                                            DocumentoEmpresa = ua.DocumentoEmpresa,
                                            RazonSocialEmpresa = ua.RazonSocialEmpresa,
                                            MunicipioSedePpalEmpresa = ua.MunicipioSedePpalEmpresa,
                                            TipoDocumento = ua.TipoDocumento,
                                            Documento = ua.Documento,
                                            NombreRolSeleccionado = ua.NombreRolSeleccionado,
                                            EmailPersona = ua.EmailPersona,                                           
                                            RutaPdfAutorizacion = ua.RutaPdfAutorizacion,
                                            CausalesRechazoUsuarioSistema = lnUsuario.ObtenerCausalesRechazoUsuariosSistema().Select(crs => new SelectListItem()
                                            {
                                                Value = crs.IdCausalRechazo.ToString(),
                                                Text = crs.NombreCausalRechazo
                                            }).ToList(),
                                           ConfigurarDatosAdicionalesModel = da.Value == null ? null : da.Value
                                       }).ToList();
                var totalPagPaginador = 0;
                var residuo = totalRegistros % cantRegistrosPag;
                if (residuo == 0)
                    totalPagPaginador = totalRegistros / cantRegistrosPag;
                else
                    totalPagPaginador = (totalRegistros / cantRegistrosPag) + 1;
                ViewBag.TotalPagPaginador = totalPagPaginador;
                ViewBag.PaginaActual = paginaActual;
                var datos = RenderRazorViewToString("_AprobarUsuarioSistema", usuariosAAFinal);
                return Json(new { Datos = datos, TotalUsuarios = totalRegistros, RegistrosPorPag = cantRegistrosPag, PaginaActual = paginaActual, Mensaje = "OK" });
            }
            else
            {
                return Json(new { Datos = string.Empty, TotalUsuarios = totalRegistros, RegistrosPorPag = cantRegistrosPag, PaginaActual = paginaActual, Mensaje = "NOTFOUND" });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[GestionAutorizacion]
        public ActionResult CambiarClave()
        {
            var usuarioSession = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioSession != null)
            {
                var usuario = new CambiarClaveModel();
                usuario.IdUsuarioSession = usuarioSession.IdUsuario;
                usuario.AceptaTerminosCondiciones = false;
                usuario.PrimerAcceso = usuarioSession.PrimerAcceso;
                ViewBag.mensajeUsu = usuarioSession.FechaCreacion.AddDays(+30);
                return View(usuario);
            }
            else
                return RedirectToAction("CerrarSesion", "Home");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RecuperarClave()
        {
            var lnUsuario = new LNUsuario();
            var adminSistema = new AdministrarUsuariosModel();
            adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            return View(adminSistema);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CambiarClave(CambiarClaveModel usuario)
        {
            if (ModelState.IsValid)
            {
                var result = false;
                var lnUsuario = new LNUsuario();
                //if (!usuario.AceptaTerminosCondiciones)
                //    return RedirectToAction("CerrarSesion", "Home");
                var usuarioSession = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                if (usuarioSession != null)
                {
                    if (usuario.IdUsuarioSession == usuarioSession.IdUsuario)
                    {
                        var usuarioRegistrar = new EDUsuarioSistema()
                        {
                            IdUsuarioSistema = usuario.IdUsuarioSession,
                            Clave = usuario.Clave
                        };
                        result = lnUsuario.CambiarClaveUsuario(usuarioRegistrar);
                    }
                    if (result)
                        //return RedirectToAction("Index", "Home");
                        return RedirectToAction("CerrarSesion", "Home");
                    else
                        return RedirectToAction("CerrarSesion", "Home");
                }
                else
                    return RedirectToAction("CerrarSesion", "Home");
            }
            else
                ViewBag.mensajeUsu = DateTime.MaxValue;
                return View(usuario);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminSistema"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RecuperarClave(AdministrarUsuariosModel adminSistema)
        {
            var lnUsuario = new LNUsuario();
            if (string.IsNullOrEmpty(adminSistema.TipoDocumentoEmpresa) ||
                string.IsNullOrEmpty(adminSistema.DocumentoEmpresa) ||
                string.IsNullOrEmpty(adminSistema.TipoDocumento) ||
                string.IsNullOrEmpty(adminSistema.Documento))
            {
                adminSistema.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                {
                    Value = td.Sigla,
                    Text = td.Descripcion
                }).ToList();
                adminSistema.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Select(rs => new SelectListItem()
                {
                    Value = rs.IdRolSistema.ToString(),
                    Text = rs.NombreRol
                }).ToList();
                return View(adminSistema);
            }
            else
            {
                int resultEmpresa = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp;
                int resultEmpleado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteAfi;
                var objEmpAfil = ConsultaSIARP.ConsultarAfiliadoEmpresaActivos(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, adminSistema.TipoDocumento, adminSistema.Documento, out resultEmpresa, out resultEmpleado);
                //la empresa existe y se encuentra activa
                if (resultEmpresa == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoEmp)
                {
                    //el empleado existe y se encuentra activo
                    if (resultEmpleado == (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.ExisteActivoAfi)
                    {
                        //obtiene el usuario que desea recuperar su clave
                        var respuesta = string.Empty;
                        var result = lnUsuario.RecuperarClaveUsuario(adminSistema.TipoDocumentoEmpresa, adminSistema.DocumentoEmpresa, adminSistema.TipoDocumento, adminSistema.Documento,
                            adminSistema.ConfiguracionPreguntasSeguridad.RespuestaUno,
                            adminSistema.ConfiguracionPreguntasSeguridad.RespuestaDos,
                            adminSistema.ConfiguracionPreguntasSeguridad.RespuestaTres, out respuesta);
                        if (result)
                            ViewBag.Mensaje = "El proceso de recuperación de clave fue exitoso. A su correo se le enviará una clave temporal. Con esta clave podrá acceder al sistema y realizar el proceso de cambio de clave.";
                        else
                        {
                            if (string.IsNullOrEmpty(respuesta))
                                ViewBag.Mensaje = "El proceso de recuperación de clave no se pudo completar. Por favor intente nuevamente.";
                            else
                                ViewBag.Mensaje = respuesta;
                        }
                    }
                    else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteAfi == resultEmpleado)
                        ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpleadoNoExiste;
                    else
                        ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpleadoInactivo;
                }
                else if ((int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoEmpAfi.NoExisteEmp == resultEmpresa)
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaNoExiste;
                else
                    ViewBag.Mensaje = Recursos.AdministracionUsuarios.MensajesAdministracionUsuarios.EmpresaInactiva;
            }
            var usuario = new AdministrarUsuariosModel();
            usuario.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            usuario.RolesRegistrados = lnUsuario.ObtenerRolesSistema().Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult IngresarPreguntasSeguridad(AdministrarUsuariosModel adminSistema)
        {
            var lnUsuario = new LNUsuario();
            var usuarioRegistrar = new EDUsuarioPorAprobar()
            {
                NumDocumentoEmpresa = adminSistema.DocumentoEmpresa,
                TipoDocumentoEmpresa = adminSistema.TipoDocumentoEmpresa,
                RazonSocialEmpresa = adminSistema.RazonSocialEmpresa,
                MunicipioSedePpalEmpresa = adminSistema.MunicipioSedePpalEmpresa,
                TipoDocumentoAfi = adminSistema.TipoDocumento,
                NumDocumentoAfi = adminSistema.Documento,
                Nombres = adminSistema.Nombres,
                Apellidos = adminSistema.Apellidos,
                Correo = adminSistema.EmailPersona,
                RolUsuario = adminSistema.IdRolSeleccionado,
                IdUsuarioPorAprobar = adminSistema.IdUsuarioSistema,
                PreguntasSeguridadSeleccionadas = new List<PreguntasSeguridadSeleccionadas>()
                {
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaUno,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaUno
                    },
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaDos,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaDos
                    },
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaTres,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaTres
                    }
                }
            };
            bool respuesta = lnUsuario.IngresarPreguntasSeguridad(usuarioRegistrar);
            return RedirectToAction("IngresarPreguntasSeguridad", "Home", new { respuesta = respuesta });
        }

        /// <summary>
        /// Obtiene la ruta donde se encuentra el archivo de términos y condiciones
        /// </summary>
        /// <param name="identificador"></param>
        /// <param name="tipoSoporte"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CargarTerminosCondiciones()
        {
            if (!string.IsNullOrEmpty(rutaArchivoTerminosCondiciones))
                return Json(new { status = 200, url = rutaArchivoTerminosCondiciones });
            else
                return Json(new { status = 400, url = string.Empty });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult TerminosCodiciones()
        {
            return File(rutaArchivoTerminosCondiciones, "application/pdf", Server.UrlEncode(rutaArchivoTerminosCondiciones));
        }
        /// <summary>
        /// Retorna la ruta del soporte pdf del usuario Asesor SST a ser aprobado
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult VisualizarSoporte(string IdUsuario, string RutaSoporte)
        {
            if (!string.IsNullOrEmpty(rutaHttpSoporteAutorizacionAsesorSST) && !string.IsNullOrEmpty(RutaSoporte))
            {
                var rutaSoporte = RutaSoporte.Split('\\');
                var guid = new Guid();
                var guidSoporteUsuario = rutaSoporte.Where(rs => Guid.TryParse(rs, out guid) == true).Select(rs => rs).FirstOrDefault();
                var nombreoporteUsuario = rutaSoporte.Select(rs => rs).LastOrDefault();
                return Json(new { status = 200, url = string.Format("{0}/{1}/{2}", rutaHttpSoporteAutorizacionAsesorSST, guidSoporteUsuario, nombreoporteUsuario) });
            }
            else
                return Json(new { status = 400, url = string.Empty });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutorizacionAdminSistema]
        public ActionResult CrearUsuarioArlPositiva()
        {
            var lnUsuario = new LNUsuario();
            var lnDepto = new LNDepartamento();
            var usuarioArl = new UsuarioArlPositivaModel();
            usuarioArl.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
            {
                Value = td.Sigla,
                Text = td.Descripcion
            }).ToList();
            usuarioArl.RolesSistema = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 2).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            usuarioArl.Departamentos = lnDepto.ObtenerListadoDepartamento().Select(dto => new SelectListItem()
            {
                Value = dto.IdDepartamento.ToString(),
                Text = dto.Nombre
            }).ToList();
            usuarioArl.Municipios = new List<SelectListItem>();
            usuarioArl.Estados = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdActivo.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Activo
                },
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdInactivo.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Inactivo
                },
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdBloqueado.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Bloqueado
                }
            };
            return View(usuarioArl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioArl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CrearUsuarioArlPositiva(UsuarioArlPositivaModel usuarioArl)
        {
            var lnUsuario = new LNUsuario();
            var lnDepto = new LNDepartamento();
            if (ModelState.IsValid)
            {
                var usuarioRegistrar = new EDUsuarioPorAprobar()
                {
                    NumDocumentoEmpresa = usuarioArl.DocumentoEmpresa,
                    TipoDocumentoEmpresa = usuarioArl.TipoDocumentoEmpresa,
                    RazonSocialEmpresa = usuarioArl.RazonSocialEmpresa,
                    DepartamentoSedePpalEmpresa = usuarioArl.DeptoSedePpalEmpresa,
                    MunicipioSedePpalEmpresa = usuarioArl.MunicipioSedePpalEmpresa,
                    TipoDocumentoAfi = usuarioArl.TipoDocumento,
                    NumDocumentoAfi = usuarioArl.Documento,
                    Nombres = usuarioArl.Nombres,
                    Apellidos = usuarioArl.Apellidos,
                    Telefono = usuarioArl.Telefono,
                    Correo = usuarioArl.EmailPersona,
                    RolUsuario = usuarioArl.IdRolSeleccionado,
                    EstadoUsuario = Convert.ToInt32(usuarioArl.EstadoSeleccionado),
                    PeriodoInactividad = DateTime.Now
                };
                var respuesta = string.Empty;
                lnUsuario.RegistrarUsusariosArlPositiva(usuarioRegistrar, out respuesta);
                ViewBag.Mensaje = respuesta;
                usuarioArl.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                {
                    Value = td.Sigla,
                    Text = td.Descripcion
                }).ToList();
                usuarioArl.RolesSistema = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 2).Select(rs => new SelectListItem()
                {
                    Value = rs.IdRolSistema.ToString(),
                    Text = rs.NombreRol
                }).ToList();
                usuarioArl.Departamentos = lnDepto.ObtenerListadoDepartamento().Select(dto => new SelectListItem()
                {
                    Value = dto.IdDepartamento.ToString(),
                    Text = dto.Nombre
                }).ToList();
                usuarioArl.Municipios = new List<SelectListItem>();
                usuarioArl.Estados = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdActivo.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Activo
                },
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdInactivo.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Inactivo
                },
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdBloqueado.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Bloqueado
                }
            };
                return View(usuarioArl);
            }
            else
            {
                usuarioArl.TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                {
                    Value = td.Sigla,
                    Text = td.Descripcion
                }).ToList();
                usuarioArl.RolesSistema = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 2).Select(rs => new SelectListItem()
                {
                    Value = rs.IdRolSistema.ToString(),
                    Text = rs.NombreRol
                }).ToList();
                usuarioArl.Departamentos = lnDepto.ObtenerListadoDepartamento().Select(dto => new SelectListItem()
                {
                    Value = dto.IdDepartamento.ToString(),
                    Text = dto.Nombre
                }).ToList();
                usuarioArl.Municipios = new List<SelectListItem>();
                usuarioArl.Estados = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdActivo.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Activo
                },
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdInactivo.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Inactivo
                },
                new SelectListItem()
                {
                    Value = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.IdBloqueado.ToString(),
                    Text = Enumeraciones.EnumAdministracionUsuarios.NombresEstadosUsuariosSistema.Bloqueado
                }
            };
                return View(usuarioArl);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutorizacionAdminSistema]
        public ActionResult ConfigurarRecursosSistema()
        {

            var lnUsuario = new LNUsuario();
            var configuracionPermisosPorRol = new ConfiguracionRecursosSistemaPorRolModel();
            configuracionPermisosPorRol.RolesSistema = lnUsuario.ObtenerRolesSistema().OrderBy(rs => rs.TipoRolSistema).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            return View(configuracionPermisosPorRol);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRol"></param>
        /// <param name="codEmpresa"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ObtenerRecursosSistemaParaAccesos(int codRol, int codEmpresa, string documentoAsesorSST = "")
        {
            var lnUsuario = new LNUsuario();
            var configuracionPermisosPorRol = new ConfiguracionRecursosSistemaPorRolModel();
            var resultado = lnUsuario.ObtenerMenuRecursosSistema(codRol, codEmpresa, documentoAsesorSST);
            configuracionPermisosPorRol.MenuRecursoSistemaModel = resultado.Select(rs => new MenuRecursoSistemaModel()
            {
                IdRecursoSistema = rs.IdRecursoSistema,
                NombreRecursoSistema = rs.NombreRecursoSistema,
                UrlRecursoSistema = rs.UrlRecursoSistema,
                CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
                Activo = rs.Acceso,
                RecursosSistemaHijos = rs.RecursosSistemaHijos.Select(rsd => new MenuRecursoSistemaModel()
                {
                    IdRecursoSistema = rsd.IdRecursoSistema,
                    NombreRecursoSistema = rsd.NombreRecursoSistema,
                    UrlRecursoSistema = rsd.UrlRecursoSistema,
                    CodRecursoSistemaPadre = rsd.CodRecursoSistemaPadre,
                    Activo = rsd.Acceso,
                    RecursosSistemaHijos = rsd.RecursosSistemaHijos.Select(rst => new MenuRecursoSistemaModel()
                    {
                        IdRecursoSistema = rst.IdRecursoSistema,
                        NombreRecursoSistema = rst.NombreRecursoSistema,
                        UrlRecursoSistema = rst.UrlRecursoSistema,
                        CodRecursoSistemaPadre = rst.CodRecursoSistemaPadre,
                        Activo = rst.Acceso
                    }).ToList()
                }).ToList()
            }).ToList();
            var recursos = RenderRazorViewToString("_RecursosParaAccesos", configuracionPermisosPorRol);
            return Json(new { Data = recursos, Status = "OK" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recursosConf"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConfigurarRecursosSistema(List<MenuRecursoSistemaModel> recursosConf, int codRolSistema, int codEmpresa)
        {
            var usuarioLog = ObtenerUusuarioLogueado(System.Web.HttpContext.Current);
            if (usuarioLog == null)
                return RedirectToAction("Index", "Home");
            var lnUsuario = new LNUsuario();
            var confiRecSx = recursosConf == null ? new List<EDMenuRecursoSistema>() : recursosConf.Where(rs => rs.Activo == false).Select(rs => new EDMenuRecursoSistema()
            {
                IdRecursoSistema = rs.IdRecursoSistema,
                CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre
            }).ToList();
            var resultado = lnUsuario.GuardarConfiguracionRecursosSistema(confiRecSx, codRolSistema, codEmpresa);
            if (resultado)
                return Json(new { Data = "La configuración se realizó con éxito.", Status = "OK" });
            else
                return Json(new { Data = "Ocurrió un error en el sistema. Intente más tarde.", Status = "ERROR" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recursosConf"></param>
        /// <param name="codRolSistema"></param>
        /// <returns></returns>
        [AutorizacionAdminSistema]
        public ActionResult ConfigurarRecursosSistemaAsesorSST()
        {
            var lnUsuario = new LNUsuario();
            var configuracionPermisosPorRol = new ConfiguracionRecursosSistemaPorRolModel();
            configuracionPermisosPorRol.RolesSistema = lnUsuario.ObtenerRolesSistema().Where(rs => rs.TipoRolSistema == 1).Select(rs => new SelectListItem()
            {
                Value = rs.IdRolSistema.ToString(),
                Text = rs.NombreRol
            }).ToList();
            //configuracionPermisosPorRol.MenuRecursoSistemaModel = resultado.Select(rs => new MenuRecursoSistemaModel()
            //{
            //    IdRecursoSistema = rs.IdRecursoSistema,
            //    NombreRecursoSistema = rs.NombreRecursoSistema,
            //    UrlRecursoSistema = rs.UrlRecursoSistema,
            //    CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
            //    RecursosSistemaHijos = rs.RecursosSistemaHijos.Select(rsd => new MenuRecursoSistemaModel()
            //    {
            //        IdRecursoSistema = rsd.IdRecursoSistema,
            //        NombreRecursoSistema = rsd.NombreRecursoSistema,
            //        UrlRecursoSistema = rsd.UrlRecursoSistema,
            //        CodRecursoSistemaPadre = rsd.CodRecursoSistemaPadre,
            //        RecursosSistemaHijos = rsd.RecursosSistemaHijos.Select(rst => new MenuRecursoSistemaModel()
            //        {
            //            IdRecursoSistema = rst.IdRecursoSistema,
            //            NombreRecursoSistema = rst.NombreRecursoSistema,
            //            UrlRecursoSistema = rst.UrlRecursoSistema,
            //            CodRecursoSistemaPadre = rst.CodRecursoSistemaPadre
            //        }).ToList()
            //    }).ToList()
            //}).ToList();
            return View(configuracionPermisosPorRol);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recursosConf"></param>
        /// <param name="empresas"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ConfigurarRecursosSistemaAsesorSST(List<MenuRecursoSistemaModel> recursosConf, List<EmpresaAsesorSSTModel> empresas)
        {
            var lnUsuario = new LNUsuario();
            var empresasAsesor = empresas.Select(e => new EDEmpresas()
            {
                Id_Empresa = e.IdEmpresa,
                Tipo_Documento = e.DocumentoAsesorSST //se utiliza esta propiedad para guardar el documento del asesor
            }).ToList();
            if (recursosConf == null)
                recursosConf = new List<MenuRecursoSistemaModel>();
            var confiRecSx = recursosConf.Where(rs => rs.Activo == false).Select(rs => new EDMenuRecursoSistema()
            {
                IdRecursoSistema = rs.IdRecursoSistema,
                CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre
            }).ToList();
            var resultado = lnUsuario.GuardarConfiguracionRecursosSistemaAsesorSST(confiRecSx, empresasAsesor);
            if (resultado)
                return Json(new { Data = "La configuración se realizó con éxito.", Status = "OK" });
            else
                return Json(new { Data = "Ocurrió un error en el sistema. Intente más tarde.", Status = "ERROR" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDocumento"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult BuscarUsuarioAsesorSST(string numDocumento)
        {
            if (!string.IsNullOrEmpty(numDocumento))
            {
                var lnUsuario = new LNUsuario();
                var resultado = lnUsuario.ObtenerDatosUsuarioAsesorSST(numDocumento);
                var empresasAsesorSST = resultado.Select(emp => new EmpresaAsesorSSTModel()
                {
                    IdEmpresa = emp.Id_Empresa,
                    RazonSocial = emp.Razon_Social,
                    Activo = false,
                    CodRol = (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST
                }).ToList();
                var datosAsesorSST = RenderRazorViewToString("_EmpresasAsociadasAsesorSST", empresasAsesorSST);
                return Json(new { Data = datosAsesorSST, Mensaje = "OK", Status = 200, CantidadEmpresas = empresasAsesorSST.Count() });
            }
            else
                return Json(new { Data = new object(), Mensaje = "No se encontro informacion", Status = 501 });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDepto"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ConsultarMunicipiosPorDepto(int idDepto)
        {
            var lnMpio = new LNMunicipio();
            var municipios = lnMpio.ObtenerListadoMunicipio(idDepto).Select(m => new SelectListItem()
            {
                Value = m.IdMunicipio.ToString(),
                Text = m.Nombre
            }).ToList();
            if (municipios.Count > 0)
                return Json(new { Data = municipios, Mensaje = "OK" });
            else
                return Json(new { Data = "No fue posible realizar obtener los municipios", Mensaje = "Fail" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefijo"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AutoCompletarEmpresas(string prefijo)
        {
            LNEmpresa lnempresa = new LNEmpresa();
            return Json(lnempresa.ObtenerEmpresasRegistradasPorPrefijo(prefijo), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [GestionAutorizacion]
        public ActionResult MesaAyuda()
        {
            var objUsuarioSesion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (objUsuarioSesion == null)
            {
                ViewBag.Mensaje = "La sesion a finalizado.";
                return RedirectToAction("Login", "Home");
            }
            var lnUsuario = new LNUsuario();
            var administradorUsuario = new AdministrarUsuariosModel();
            administradorUsuario.BuscadorUsuariosSistema = new BuscardorModel()
            {
                TiposDocumento = lnUsuario.ObtenerTiposDocumento().Select(td => new SelectListItem()
                {
                    Value = td.Id_Tipo_Documento.ToString(),
                    Text = td.Descripcion
                }).ToList()
            };
            return View(administradorUsuario);
        }
        /// <summary>
        /// Devuelve los datos del usuario encontrado
        /// </summary>
        /// <param name="tidDocUsu"></param>
        /// <param name="numDocUsu"></param>
        /// <param name="paginaActual"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BuscarUsuarioMesaAyuda(string tidDocUsu, string numDocUsu, int paginaActual = 1)
        {
            var lnUsuario = new LNUsuario();
            var codTidDocUsu = Convert.ToInt32(tidDocUsu);
            var usuariosMAyuda = lnUsuario.ObtenerUsuarioMesaAyuda(codTidDocUsu, numDocUsu, paginaActual);
            if (usuariosMAyuda != null && usuariosMAyuda.Count() > 0)
            {
                var usuariosMesaAyuda = usuariosMAyuda.Select(ua => new AdministrarUsuariosModel()
                {
                    IdUsuarioSistema = ua.IdUsuarioSistema,
                    Nombres = ua.Nombres,
                    Apellidos = ua.Apellidos,
                    TipoDocumentoEmpresa = ua.TipoDocumentoSiglaEmpresa,
                    DocumentoEmpresa = ua.DocumentoEmpresa,
                    RazonSocialEmpresa = ua.RazonSocial,
                    MunicipioSedePpalEmpresa = ua.MunicipioSedePpalEmpresa,
                    TipoDocumento = ua.TipoDocumentoSigla,
                    Documento = ua.Documento,
                    NombreRolSeleccionado = ua.NombreRol,
                    EmailPersona = ua.Correo,
                    IdEstado = ua.IdEstado,
                    Estado = ua.NombreEstado,
                    PeriodoInactividad = ua.PeriodoInactividad.AddDays(-30) //se utiliza para la fecha de creaci[on del usuario,
                }).ToList();
                var validaciones = new List<bool>();
                Dictionary<int, ConfiguracionPreguntasSeguridad> relacionPrg = new Dictionary<int, ConfiguracionPreguntasSeguridad>();
                Dictionary<int, ConfigurarDatosAdicionalesModel> relacionDatosAdi = new Dictionary<int, ConfigurarDatosAdicionalesModel>();
                foreach (var usuario in usuariosMAyuda)
                {
                    var contador = 1;
                    var preguntasSeguridad = new ConfiguracionPreguntasSeguridad();
                    var datosAdicion = new ConfigurarDatosAdicionalesModel();
                    usuario.PreguntasSeguridad.ForEach(rps =>
                    {
                        if (contador == 1)
                        {
                            preguntasSeguridad.NombrePreguntaUno = rps.NombrePregunta;
                            preguntasSeguridad.RespuestaUno = rps.RespuestaSeguridad;
                        }
                        if (contador == 2)
                        {
                            preguntasSeguridad.NombrePreguntaDos = rps.NombrePregunta;
                            preguntasSeguridad.RespuestaDos = rps.RespuestaSeguridad;
                        }
                        if (contador == 3)
                        {
                            preguntasSeguridad.NombrePreguntaTres = rps.NombrePregunta;
                            preguntasSeguridad.RespuestaTres = rps.RespuestaSeguridad;
                        }
                        contador += 1;
                    });
                    relacionPrg.Add(usuario.IdUsuarioSistema, preguntasSeguridad);
                    usuario.DatosAdicionalesUsuarios.ForEach(dau =>
                    {
                        if (dau.NombreDato == "FechaInicioContrato")
                        {
                            datosAdicion.FechaInicioContrato = dau.ValorDato.Substring(0, 10); 
                        }
                        if (dau.NombreDato == "FechaFinContrato")
                        {
                            datosAdicion.FechaFinContrato = dau.ValorDato.Substring(0, 10);
                        }

                    });
                    relacionDatosAdi.Add(usuario.IdUsuarioSistema, datosAdicion);
                }
                var usuariosMAFinal = (from ua in usuariosMesaAyuda
                                       join ru in relacionPrg on ua.IdUsuarioSistema equals ru.Key
                                       join da in relacionDatosAdi on ua.IdUsuarioSistema equals da.Key
                                       select new AdministrarUsuariosModel
                                       {
                                           IdUsuarioSistema = ua.IdUsuarioSistema,
                                           Nombres = ua.Nombres,
                                           Apellidos = ua.Apellidos,
                                           TipoDocumentoEmpresa = ua.TipoDocumentoEmpresa,
                                           DocumentoEmpresa = ua.DocumentoEmpresa,
                                           RazonSocialEmpresa = ua.RazonSocialEmpresa,
                                           MunicipioSedePpalEmpresa = ua.MunicipioSedePpalEmpresa,
                                           TipoDocumento = ua.TipoDocumento,
                                           Documento = ua.Documento,
                                           NombreRolSeleccionado = ua.NombreRolSeleccionado,
                                           EmailPersona = ua.EmailPersona,
                                           IdEstado = ua.IdEstado,
                                           Estado = ua.Estado,
                                           PeriodoInactividad = ua.PeriodoInactividad,
                                           ConfiguracionPreguntasSeguridad = ru.Value == null ? null : ru.Value,
                                           ConfigurarDatosAdicionalesModel = da.Value == null ? null : da.Value
                                       }).ToList();
                var datos = RenderRazorViewToString("_UsuarioMesaAyuda", usuariosMAFinal);
                return Json(new { Datos = datos, Mensaje = "OK" });
            }
            else
                return Json(new { Datos = string.Empty, IdUsuario = 0, Mensaje = "NOTFOUND" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EnviarClaveTemporalUsuarioMesaAyuda(int idUsuario)
        {
            var lnUsuario = new LNUsuario();
            var resultado = lnUsuario.EnviarClaveTemporalUsuarioMesaAyuda(idUsuario);
            if (resultado != null)
                return Json(new { Datos = resultado, IdUsuario = resultado.IdUsuarioSistema, Mensaje = "OK" });
            else
                return Json(new { Datos = string.Empty, IdUsuario = 0, Mensaje = "NOTFOUND" });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nuevoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CambiarCorreoUsuario(int idUsuario, string nuevoCorreoUsuario)
        {
            var lnUsuario = new LNUsuario();
            var resultado = lnUsuario.CambiarCorreoUsuario(idUsuario, nuevoCorreoUsuario);
            if (resultado != null)
                return Json(new { Datos = resultado, IdUsuario = resultado.IdUsuarioSistema, Mensaje = "OK" });
            else
                return Json(new { Datos = string.Empty, IdUsuario = 0, Mensaje = "NOTFOUND" });
        }
        /// <summary>
        /// Registra un nuevo usuario del sistema
        /// </summary>
        /// <param name="adminSistema"></param>
        /// <returns></returns>
        private string CrearUsuarioSistema(AdministrarUsuariosModel adminSistema)
        {
            var result = string.Empty;
            var lnUsuario = new LNUsuario();
            var usuarioRegistrar = new EDUsuarioPorAprobar()
            {
                NumDocumentoEmpresa = adminSistema.DocumentoEmpresa,
                TipoDocumentoEmpresa = adminSistema.TipoDocumentoEmpresa,
                RazonSocialEmpresa = adminSistema.RazonSocialEmpresa,
                MunicipioSedePpalEmpresa = adminSistema.MunicipioSedePpalEmpresa,
                TipoDocumentoAfi = adminSistema.TipoDocumento,
                NumDocumentoAfi = adminSistema.Documento,
                Nombres = adminSistema.Nombres,
                Apellidos = adminSistema.Apellidos,
                Correo = adminSistema.EmailPersona,
                RolUsuario = adminSistema.IdRolSeleccionado,
                PreguntasSeguridadSeleccionadas = new List<PreguntasSeguridadSeleccionadas>()
                {
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaUno,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaUno
                    },
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaDos,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaDos
                    },
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaTres,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaTres
                    }
                }
            };
            result = lnUsuario.RegistrarUsusariosParaAprobar(usuarioRegistrar);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="adminSistema"></param>
        /// <returns></returns>
        private string CrearUsuarioAsesorSSTSistema(AdministrarUsuarioAsesorSSTModel adminSistema)
        {
            var result = string.Empty;
            var lnUsuario = new LNUsuario();
            var usuarioRegistrar = new EDUsuarioPorAprobar()
            {
                NumDocumentoEmpresa = adminSistema.DocumentoEmpresa,
                TipoDocumentoEmpresa = adminSistema.TipoDocumentoEmpresa,
                RazonSocialEmpresa = adminSistema.RazonSocialEmpresa,
                MunicipioSedePpalEmpresa = adminSistema.MunicipioSedePpalEmpresa,
                TipoDocumentoAfi = adminSistema.TipoDocumento,
                NumDocumentoAfi = adminSistema.Documento,
                Nombres = adminSistema.Nombres,
                Apellidos = adminSistema.Apellidos,
                Correo = adminSistema.EmailPersona,
                RolUsuario = adminSistema.IdRolSeleccionado,
                FechaInicioContrato = adminSistema.FechaInicioContrato,
                FechaFinContrato = adminSistema.FechaFinContrato,
                RutaPdfAutorizacion = adminSistema.RutaPdfAutorizacion,
                PreguntasSeguridadSeleccionadas = new List<PreguntasSeguridadSeleccionadas>()
                {
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaUno,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaUno
                    },
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaDos,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaDos
                    },
                    new PreguntasSeguridadSeleccionadas()
                    {
                        CodPreguntaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.CodPreguntaTres,
                        RespuestaSeguridad = adminSistema.ConfiguracionPreguntasSeguridad.RespuestaTres
                    }
                }
            };
            result = lnUsuario.RegistrarUsusariosParaAprobar(usuarioRegistrar);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AutorizacionAdminSistema]
        public ActionResult ConsultaUsuariosSistema()
        {
            UsuarioModel model = new UsuarioModel();
            var lnUsuario = new LNUsuario();
            var estados = lnUsuario.ConsultaEstadosUsuario();
            model.EstadosUsuario = estados.Select(e => new SelectListItem()
            {
                Value = e.IdEstado.ToString(),
                Text = e.NombreEstado
            }).ToList();

            return View("ConsultaUsuariosSistema", model);
        }

        [HttpPost]
        public JsonResult ConsultaUsuariosSistema(string idEstado, string NitEmpresa, string numPagina)
        {
            if (idEstado.Equals("0") && NitEmpresa.Equals("0") && numPagina.Equals("0"))
            {
                idEstado = System.Web.HttpContext.Current.Session["cuidEstado"].ToString();
                NitEmpresa = System.Web.HttpContext.Current.Session["cuNitEmpresa"].ToString();
                numPagina = System.Web.HttpContext.Current.Session["cunumPagina"].ToString();
            }

            List<UsuarioModel> modelUsuarios = new List<UsuarioModel>();
            var lnUsuario = new LNUsuario();
            int cantidadPorPagina = Convert.ToInt16(ConfigurationManager.AppSettings["CantidadPaginaUsuarioSistema"]);
            var usuarios = lnUsuario.ConsultaUsuariosSistema(Convert.ToInt32(idEstado), NitEmpresa, Convert.ToInt32(numPagina), cantidadPorPagina);

            if (usuarios.Count() == 0 && Convert.ToInt32(numPagina) > 0)
            {
                numPagina = (Convert.ToInt32(numPagina) - 1).ToString();
                usuarios = lnUsuario.ConsultaUsuariosSistema(Convert.ToInt32(idEstado), NitEmpresa, Convert.ToInt32(numPagina), cantidadPorPagina);
            }

            var estados = lnUsuario.ConsultaEstadosUsuario();
            var EstadosUsuario = estados.Select(e => new SelectListItem()
            {
                Value = e.IdEstado.ToString(),
                Text = e.NombreEstado
            }).ToList();

            Session["cuidEstado"] = idEstado;
            Session["cuNitEmpresa"] = NitEmpresa;
            Session["cunumPagina"] = numPagina;

            modelUsuarios = usuarios.Select(u => new UsuarioModel()
            {
                IdUsuarioSistema = u.IdUsuarioSistema,
                Correo = u.Correo,
                TipoDocumentoSiglaEmpresa = u.TipoDocumentoSiglaEmpresa,
                DocumentoEmpresa = u.DocumentoEmpresa,
                RazonSocial = u.RazonSocial,
                TipoDocumentoSigla = u.TipoDocumentoSigla,
                Documento = u.Documento,
                MunicipioSedePpalEmpresa = u.MunicipioSedePpalEmpresa,
                Nombres = u.Nombres,
                Apellidos = u.Apellidos,
                RolUsuario = u.RolUsuario,
                NombreEstado = u.NombreEstado,
                IdEstado = u.IdEstado,
                EstadosUsuario = EstadosUsuario
            }).ToList();

            Dictionary<int, ConfigurarDatosAdicionalesUsuariosModel> relacionDatosAdi = new Dictionary<int, ConfigurarDatosAdicionalesUsuariosModel>();
            foreach (var daUsuarios in usuarios)
            {
                var datosAdicion = new ConfigurarDatosAdicionalesUsuariosModel();
                daUsuarios.DatosAdicionalesUsuarios.ForEach(dau =>
                {
                    if (dau.NombreDato == "FechaInicioContrato")
                    {
                        datosAdicion.FechaInicioContrato = dau.ValorDato.Substring(0, 10);
                    }
                    if (dau.NombreDato == "FechaFinContrato")
                    {
                        datosAdicion.FechaFinContrato = dau.ValorDato.Substring(0, 10);
                    }

                });
                relacionDatosAdi.Add(daUsuarios.IdUsuarioSistema, datosAdicion);
            }
            var usuariosDetSist = (from u in modelUsuarios
                                   join da in relacionDatosAdi on u.IdUsuarioSistema equals da.Key
                                   select new UsuarioModel
                                   {
                                       IdUsuarioSistema = u.IdUsuarioSistema,
                                       Correo = u.Correo,
                                       TipoDocumentoSiglaEmpresa = u.TipoDocumentoSiglaEmpresa,
                                       DocumentoEmpresa = u.DocumentoEmpresa,
                                       RazonSocial = u.RazonSocial,
                                       TipoDocumentoSigla = u.TipoDocumentoSigla,
                                       Documento = u.Documento,
                                       MunicipioSedePpalEmpresa = u.MunicipioSedePpalEmpresa,
                                       Nombres = u.Nombres,
                                       Apellidos = u.Apellidos,
                                       RolUsuario = u.RolUsuario,
                                       NombreEstado = u.NombreEstado,
                                       IdEstado = u.IdEstado,
                                       EstadosUsuario = EstadosUsuario,
                                       ConfigurarDatosAdicionalesUsuariosModel = da.Value == null ? null : da.Value
                                   }).ToList();

            if (usuarios.Count > 0 && estados.Count > 0)
            {
                if ((usuarios[0].CantidadRegistros % cantidadPorPagina) == 0)
                    ViewBag.PageCount = usuarios[0].CantidadRegistros / cantidadPorPagina;
                else
                    ViewBag.PageCount = (usuarios[0].CantidadRegistros / cantidadPorPagina) + 1;

                string vista = RenderRazorViewToString("_DetalleUsuariosSistema", usuariosDetSist);
                return Json(new { Data = vista, Mensaje = "Success" });
            }
            else
                return Json(new { Data = "La se encontraron registros para los parametros de busqueda", Mensaje = "Fail" });
        }

        [HttpPost]
        public JsonResult ActualizarUsuarioSistema(string idEstado, string idUsuario)
        {
            var lnUsuario = new LNUsuario();
            EDUsuarioSistema usuario = new EDUsuarioSistema();
            usuario.IdEstado = Convert.ToInt32(idEstado);
            usuario.IdUsuarioSistema = Convert.ToInt32(idUsuario); ;

            var estado = lnUsuario.ActualizarUsuario(usuario);

            if (estado)
                return Json(new { Data = "Proceso finalizado con éxito", Mensaje = "Success" });
            else
                return Json(new { Data = "No fue posible actualizar la información del usuario", Mensaje = "Fail" });
        }

        [AutorizacionAdminSistema]
        public ActionResult CargarExcelRecursosDefault()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargarExcelRecursosDefault(object form_data)
        {
            try
            {
                var lnUsuario = new LNUsuario();
                var objEvaluacion = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                string rutaAlistaFile = ConfigurationManager.AppSettings["rutaRepositorioFile"];
                string rutaTemRecursosDefault = ConfigurationManager.AppSettings["rutaMMaestros"];



                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["cargarArchivo"];

                    HttpPostedFileBase file = new HttpPostedFileWrapper(pic);
                    if (file.FileName.EndsWith("xls") || file.FileName.EndsWith("xlsx"))
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        string path = string.Empty;
                        path = Path.Combine(rutaAlistaFile + rutaTemRecursosDefault);
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);


                        path = Path.Combine(path, fileName);
                        if (System.IO.File.Exists(path))
                            System.IO.File.Delete(path);
                        file.SaveAs(path);

                        EDRecursosDefault result = lnUsuario.CargarExcelRecursosDefault(path);



                        if (result != null)
                        {
                            if (result.respuesta)
                                return Json(new { Data = "Plantilla cargada correctamente!.", Mensaje = "Success" });
                            else
                                return Json(new { Data = result.mensaje, Mensaje = "ERROR" });
                        }
                        else
                            return Json(new { Data = "Se presentó un error de comunicación con el servidor; por favor intente nuevamente o comuníquese con el administrador del sistema.", Mensaje = "ERROR" });

                    }
                    else
                    {
                        return Json(new { Data = "Debe seleccionar un archivo en formato Excel con extensión .xls o .xlsx", Mensaje = "ERROR" });
                    }
                }
                else
                    return Json(new { Data = "Se presentó un error en la carga del archivo; por favor intente ingresando nuevamente o comuníquese con el administrador del sistema.", Mensaje = "ERROR" });

            }
            catch (Exception e)
            {
                return Json(new { Data = "Se presentó un error con la conexión.", Mensaje = "CONEXION" });

            }
        }
    }
}