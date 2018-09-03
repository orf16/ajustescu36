using SG_SST.Audotoria;
using SG_SST.EntidadesDominio.Empresas;
using SG_SST.EntidadesDominio.Usuario;
using SG_SST.Interfaces.Usuarios;
using SG_SST.Models;
using SG_SST.Models.Empresas;
using SG_SST.Models.LiderazgoGerencial;
using SG_SST.Models.Usuarios;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Repositorio.Usuarios
{
    public class UsuarioManager : IUsuario
    {
        RegistraLog registroLog = new RegistraLog();
        /// <summary>
        /// Obtiene los tipos de documento configurados en el sistema
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDTipoDocumento> ObtenerTiposDocumento()
        {
            try
            {
                List<EDTipoDocumento> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_TipoDocumentos.Select(td => new EDTipoDocumento()
                    {
                        Id_Tipo_Documento = td.PK_IDTipo_Documento,
                        Descripcion = td.Descripcion,
                        Sigla = td.Sigla
                    }).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new List<EDTipoDocumento>() { };//Se debe configurar para que se registe el Log
            }
        }

        /// <summary>
        /// Obtiene los roles definidos en el sistema
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDRolSistema> ObtenerRolesSistema()
        {
            try
            {
                List<EDRolSistema> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_RolesSistema.Where(rs => rs.Activo == true).Select(rs => new EDRolSistema()
                    {
                        IdRolSistema = rs.Pk_Id_RolSistema,
                        NombreRol = rs.Nombre,
                        Sigla = rs.Sigla,
                        CantidadMaxUsuarios = rs.CantidadUsuariosPorRol,
                        Activo = rs.Activo,
                        TipoRolSistema = rs.TipoRolSistema
                    }).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new List<EDRolSistema>() { };//Se debe configurar para que se registe el Log
            }
        }

        /// <summary>
        /// Obitiene el listado de causales de rechazo de un usuario
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDCausalRechazoUsuarioSistema> ObtenerCausalesRechazoUsuariosSistema()
        {
            try
            {
                List<EDCausalRechazoUsuarioSistema> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_CausalesRechazoUsuariosSistems.Select(crs => new EDCausalRechazoUsuarioSistema()
                    {
                        IdCausalRechazo = crs.Pk_Id_CausalRechazo,
                        NombreCausalRechazo = crs.Nombre,
                        DescripcionCausalRechazo = crs.Descripcion
                    }).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new List<EDCausalRechazoUsuarioSistema>() { };//Se debe configurar para que se registe el Log
            }
        }

        /// <summary>
        /// Obtiene la preguntas de seguridad configuradas en el sistema Alista
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDPreguntaSeguridad> ObtenerPreguntasSeguridad()
        {
            try
            {
                List<EDPreguntaSeguridad> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_PreguntasSeguridad.Select(ps => new EDPreguntaSeguridad()
                    {
                        IdPreguntaSeguridad = ps.Pk_Id_PreguntaSeguridad,
                        NombrePreguntaSeguridad = ps.NombrePreguntaSeguridad,
                        Descripcion = ps.Descricion
                    }).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new List<EDPreguntaSeguridad>() { };//Se debe configurar para que se registe el Log
            }
        }
        public IEnumerable<EDParametroSistema> ObtenerParametrosSistema(List<int> idParametros)
        {
            try
            {
                List<EDParametroSistema> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_ParametrosSistema.Where(ps => idParametros.Contains(ps.IdParametro)).Select(ps => new EDParametroSistema()
                    {
                        IdParametro = ps.IdParametro,
                        Valor = ps.Valor
                    }).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new List<EDParametroSistema>() { };//Se debe configurar para que se registe el Log
            }
        }

        public EntidadesDominio.Usuario.EDParametroSistema ObtenerParametrosSistema(string NombrePlantilla)
        {
            try
            {
                EntidadesDominio.Usuario.EDParametroSistema resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_PlantillasCorreosSistema.Where(pc => pc.NombrePlantilla == NombrePlantilla).Select(pc => new EDParametroSistema()
                    {
                        IdParametro = pc.IdPlantilla,
                        NombreParametro = pc.NombrePlantilla,
                        Valor = pc.Plantilla
                    }).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new EDParametroSistema { };//Se debe configurar para que se registe el Log
            }
        }
        public EDParametroSistema ObtenerParametrosSistema(int codPlantilla)
        {
            try
            {
                EDParametroSistema resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_PlantillasCorreosSistema.Where(pc => pc.IdPlantilla == codPlantilla).Select(pc => new EDParametroSistema()
                    {
                        IdParametro = pc.IdPlantilla,
                        NombreParametro = pc.NombrePlantilla,
                        Valor = pc.Plantilla
                    }).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return new EDParametroSistema { };//Se debe configurar para que se registe el Log
            }
        }

        /// <summary>
        /// Retorna los datos del usuario asociado al documento pasado por parametro
        /// </summary>
        /// <returns></returns>
        public EDUsuarioSistema ObtenerUsuarioPorId(string documento)
        {
            try
            {
                EDUsuarioSistema resultado = null;
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Tbl_UsuarioSistema.Where(us => us.Documento.Equals(documento)).Select(us => new EDUsuarioSistema
                    {
                        IdUsuarioSistema = us.Pk_Id_UsuarioSistema,
                        Documento = us.Documento,
                        ClaveSalt = us.ClaveSalt,
                        ClaveHash = us.ClaveHash,
                        Correo = us.Correo,
                        Activo = us.Activo,

                    }).FirstOrDefault();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene las empresas que no estan registras en Alista
        /// </summary>
        /// <param name="usuariosAprobar"></param>
        /// <returns></returns>
        public Dictionary<string, string> ObtenerEmpresasSinRegistrar(List<EDUsuarioPorAprobar> usuariosAprobar)
        {
            try
            {
                List<int> usuariosConEmpresas = null;
                var idUsuariosAprobar = usuariosAprobar.Select(ua => ua.IdUsuarioPorAprobar).ToList();
                Dictionary<string, string> empresasSinRegistrar = null;
                using (var context = new SG_SSTContext())
                {
                    usuariosConEmpresas = (from e in context.Tbl_Empresa
                                           join td in context.Tbl_TipoDocumentos on e.Tipo_Documento.ToUpper() equals td.Sigla.ToUpper()
                                           join ua in context.Tbl_UsuariosParaAprobar on new { A = td.PK_IDTipo_Documento, B = e.Nit_Empresa } equals new { A = ua.TipoDocumentoEmpresa, B = ua.NumeroDocumentoEmprsa }
                                           where idUsuariosAprobar.Contains(ua.Pk_id_UsuarioParaAprobar)
                                           select ua.Pk_id_UsuarioParaAprobar).ToList();
                    var empresas = (from up in context.Tbl_UsuariosParaAprobar
                                    join td in context.Tbl_TipoDocumentos on up.TipoDocumentoEmpresa equals td.PK_IDTipo_Documento
                                    where !usuariosConEmpresas.Contains(up.Pk_id_UsuarioParaAprobar)
                                    select new
                                    {
                                        IdEmpresa = (up == null ? 0 : up.Pk_id_UsuarioParaAprobar),
                                        Tid = (td == null ? string.Empty : td.Sigla),
                                        Nid = (up == null ? string.Empty : up.NumeroDocumentoEmprsa)
                                    }).ToList();
                    empresasSinRegistrar = (from e in empresas
                                            where idUsuariosAprobar.Contains(e.IdEmpresa)
                                            group e by e.Nid into agrp

                                            select new
                                            {
                                                Nid = agrp.Key,
                                                Tid = (agrp.FirstOrDefault() == null ? string.Empty : agrp.FirstOrDefault().Tid)
                                            }).ToDictionary(e => e.Nid, e => e.Tid);
                }
                return empresasSinRegistrar;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Devuelve el listado de usuarios del sistema a crear a partir
        /// de los usuarios aprobados
        /// </summary>
        /// <param name="usuariosAprobar"></param>
        /// <returns></returns>
        public List<EDUsuarioSistema> ObtenerDatosUsuariosSistema(List<EDUsuarioPorAprobar> usuariosAprobar)
        {
            try
            {
                List<EDUsuarioSistema> usuariosSistema = null;
                List<EDUsuarioSistema> usuariosSistemaFnal = null;
                var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                var idUsuariosAprobar = usuariosAprobar.Select(ua => ua.IdUsuarioPorAprobar).ToList();
                using (var context = new SG_SSTContext())
                {
                    usuariosSistema = (from e in context.Tbl_Empresa
                                       join td in context.Tbl_TipoDocumentos on e.Tipo_Documento.ToUpper() equals td.Sigla.ToUpper()
                                       join ua in context.Tbl_UsuariosParaAprobar on new { A = td.PK_IDTipo_Documento, B = e.Nit_Empresa } equals new { A = ua.TipoDocumentoEmpresa, B = ua.NumeroDocumentoEmprsa }
                                       where idUsuariosAprobar.Contains(ua.Pk_id_UsuarioParaAprobar)
                                       && ua.FK_Id_EstadoUsuario == estadoPendiente
                                       select new EDUsuarioSistema()
                                       {
                                           IdUsuarioSistema = ua.Pk_id_UsuarioParaAprobar,//este id es el usuario a aprobar
                                           Nombres = ua.Nombres,
                                           Apellidos = ua.Apellidos,
                                           IdRol = ua.Fk_Id_RolSistema,
                                           CodEmpresa = e.Pk_Id_Empresa,
                                           TipoDocumentoEmpresa = td.PK_IDTipo_Documento,
                                           DocumentoEmpresa = e.Nit_Empresa,
                                           TipoDocumento = ua.TipoDocumentoUsuario,
                                           Documento = ua.NumeroDocumentoUsuario,
                                           Correo = ua.EmailUsuario,
                                       }).Distinct().ToList();
                }
                if (usuariosSistema != null && usuariosSistema.Count > 0)
                {
                    usuariosSistemaFnal = (from us in usuariosSistema
                                           join ua in usuariosAprobar on us.IdUsuarioSistema equals ua.IdUsuarioPorAprobar
                                           select new EDUsuarioSistema()
                                           {
                                               IdUsuarioSistema = us.IdUsuarioSistema,
                                               Nombres = us.Nombres,
                                               Apellidos = us.Apellidos,
                                               IdRol = us.IdRol,
                                               CodEmpresa = us.CodEmpresa,
                                               TipoDocumentoEmpresa = us.TipoDocumentoEmpresa,
                                               DocumentoEmpresa = us.DocumentoEmpresa,
                                               TipoDocumento = us.TipoDocumento,
                                               Documento = us.Documento,
                                               Correo = us.Correo,
                                               PeriodoInactividad = ua.PeriodoInactividad
                                           }).ToList();

                }
                return usuariosSistemaFnal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el listado de usuarios del sistema para aprobar
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDUsuarioPorAprobar> ObtenerUsuariosParaAprobar(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int paginaActual, int codUsuarioAprobador)
        {
            try
            {
                var codDeptoCob = 0;
                var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                idMunicipio = idMunicipio.Contains("Seleccione") ? "" : idMunicipio;
                rolSeleccionado = rolSeleccionado.Contains("Seleccione") ? "" : rolSeleccionado;
                var HaynumDocEmp = !string.IsNullOrWhiteSpace(numDocEmp.Trim());
                var HaynumDocUsu = !string.IsNullOrWhiteSpace(numDocUsu.Trim());
                var HayrolSeleccionado = !string.IsNullOrWhiteSpace(rolSeleccionado.Trim());
                var HayidMunicipio = !string.IsNullOrWhiteSpace(idMunicipio.Trim());
                string[] municipiosCobertutra = new string[] { };
                var HayMunicipiosCob = false;
                List<EDUsuarioPorAprobar> resultado = null;
                using (
                    var context = new SG_SSTContext())
                {
                    int cantidad = Convert.ToInt16(context.Tbl_ParametrosSistema.Where(p => p.NombreParametro.Equals("CantRegistrosPagPaginador")).Select(p => p.Valor).FirstOrDefault());
                    int numPagina = 0;
                    if (paginaActual > 1)
                        numPagina = (paginaActual * cantidad) - cantidad;

                    var infoCobertura = (from us in context.Tbl_UsuarioSistema
                                         join ur in context.Tbl_UsuariosPorRol on us.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                         join rs in context.Tbl_RolesSistema on ur.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema
                                         join dau in context.Tbl_DatosAdicionalesUsuario on us.Pk_Id_UsuarioSistema equals dau.CodUsuarioSistema
                                         where us.Pk_Id_UsuarioSistema == codUsuarioAprobador
                                         && dau.NombreDato == "Departamento"
                                         select new { RolUsuario = rs.Pk_Id_RolSistema, DeptoCob = dau.ValorDato }).FirstOrDefault();
                    if (infoCobertura != null && !string.IsNullOrEmpty(infoCobertura.DeptoCob))
                        codDeptoCob = Convert.ToInt32(infoCobertura.DeptoCob);
                    //se obtiene el listado de muncipios de conbertura por pate del
                    //Administrador Sucursal 
                    if (infoCobertura != null && infoCobertura.RolUsuario == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorSucursal)
                    {
                        municipiosCobertutra = (from d in context.Tbl_Departamento
                                                join m in context.Tbl_Municipio on d.Pk_Id_Departamento equals m.Fk_Nombre_Departamento
                                                where d.Pk_Id_Departamento == codDeptoCob
                                                select m.Nombre_Municipio).ToArray();
                        if (municipiosCobertutra != null && municipiosCobertutra.Count() > 0)
                            HayMunicipiosCob = true;
                    }
                    resultado = (from ua in context.Tbl_UsuariosParaAprobar
                                 join dau in (context.Tbl_DatosAdicionalesUsuario.Where(d => d.NombreDato.Equals("RutaPdfAutorizacion")).Select(d => d)) on ua.Pk_id_UsuarioParaAprobar equals dau.CodUsuarioAprobar
                                 into leftdau
                                 from joindau in leftdau.DefaultIfEmpty()
                                 join tde in context.Tbl_TipoDocumentos on ua.TipoDocumentoEmpresa equals tde.PK_IDTipo_Documento
                                 join tda in context.Tbl_TipoDocumentos on ua.TipoDocumentoUsuario equals tda.PK_IDTipo_Documento
                                 join rs in context.Tbl_RolesSistema on ua.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema
                                 join ur in context.Tbl_UsuariosRechazadosSitema on ua.Pk_id_UsuarioParaAprobar equals ur.Fk_Id_UsuarioParaActivar
                                 into lefttur
                                 from joinur in lefttur.DefaultIfEmpty()
                                 where (!HayMunicipiosCob || municipiosCobertutra.Contains(ua.MunicipioSedePpal))
                                 && (!HaynumDocEmp || ua.NumeroDocumentoEmprsa.Equals(numDocEmp))
                                 && (!HaynumDocUsu || ua.NumeroDocumentoUsuario.Equals(numDocUsu))
                                 && (!HayrolSeleccionado || ua.Fk_Id_RolSistema.ToString().Equals(rolSeleccionado))
                                 && (!HayidMunicipio || ua.MunicipioSedePpal.Equals(idMunicipio))
                                 && joinur == null
                                 && ua.FK_Id_EstadoUsuario == estadoPendiente
                                 select new EDUsuarioPorAprobar
                                 {
                                     IdUsuarioPorAprobar = ua.Pk_id_UsuarioParaAprobar,
                                     Nombres = ua.Nombres,
                                     Apellidos = ua.Apellidos,
                                     Correo = ua.EmailUsuario,
                                     TipoDocumentoEmpresa = tde.Descripcion,
                                     NumDocumentoEmpresa = ua.NumeroDocumentoEmprsa,
                                     RazonSocialEmpresa = ua.RazonSocial,
                                     MunicipioSedePpalEmpresa = ua.MunicipioSedePpal,
                                     TipoDocumentoAfi = tda.Descripcion,
                                     NumDocumentoAfi = ua.NumeroDocumentoUsuario,
                                     RolUsuario = ua.Fk_Id_RolSistema,
                                     NombreRol = rs.Nombre,
                                     RutaPdfAutorizacion = string.IsNullOrEmpty(joindau.ValorDato) ? "No Aplica" : joindau.ValorDato
                                 }).OrderBy(u => u.IdUsuarioPorAprobar).Skip(numPagina).Take(cantidad).ToList();
                    if (resultado != null && resultado.Count() > 0)
                    {
                        foreach (var usuario in resultado)
                        {
                            usuario.DatosAdicionales = context.Tbl_DatosAdicionalesUsuario.Where(dau => dau.CodUsuarioAprobar == usuario.IdUsuarioPorAprobar).Select(dau => new DatosAdicionalesUsuario()
                            {
                                NombreDato = dau.NombreDato,
                                ValorDato = dau.ValorDato
                            }).ToList();

                        }
                    }
                    //resultado = context.Database.SqlQuery<EDUsuarioPorAprobar>("BuscarUsuariosParaAprobar @NumDocEmp, @NumDocUsu, @RolSeleccionado, @Municipio, @Pagina",
                    //new SqlParameter("@NumDocEmp", numDocEmp),
                    //new SqlParameter("@NumDocUsu", numDocUsu),
                    //new SqlParameter("@RolSeleccionado", rolSeleccionado),
                    //new SqlParameter("@Municipio", idMunicipio),
                    //new SqlParameter("@Pagina", paginaActual)).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Obtiene los datos del usuario para la mesa de ayuda
        /// </summary>
        /// <param name="tidDocUsu"></param>
        /// <param name="numDocUsu"></param>
        /// <param name="paginaActual"></param>
        /// <returns></returns>
        public IEnumerable<EDUsuarioSistema> ObtenerUsuarioMesaAyuda(int codTidDocUsu, string numDocUsu, int paginaActual)
        {
            IEnumerable<EDUsuarioSistema> usuariosMesaAyuda = null;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    usuariosMesaAyuda = (from u in context.Tbl_UsuarioSistema
                                         join eu in context.Tbl_UsuarioEstados on u.FK_Id_EstadoUsuario equals eu.Pk_Id_UsuarioEstados
                                         join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                         join emp in context.Tbl_Empresa on ue.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                                         join sd in context.Tbl_Sede on emp.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                                         join sm in context.Tbl_SedeMunicipio on sd.Pk_Id_Sede equals sm.Fk_id_Sede
                                         join m in context.Tbl_Municipio on sm.Fk_Id_Municipio equals m.Pk_Id_Municipio
                                         join td in context.Tbl_TipoDocumentos on u.Fk_Id_TipoDocumento equals td.PK_IDTipo_Documento
                                         join ur in context.Tbl_UsuariosPorRol on u.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                         join r in context.Tbl_RolesSistema on ur.Fk_Id_RolSistema equals r.Pk_Id_RolSistema
                                         where td.PK_IDTipo_Documento == codTidDocUsu
                                         && u.Documento.Equals(numDocUsu)
                                         && sd.Pk_Id_Sede == emp.sedes.FirstOrDefault().Pk_Id_Sede
                                         select new EDUsuarioSistema
                                         {
                                             IdUsuarioSistema = u.Pk_Id_UsuarioSistema,
                                             TipoDocumentoSiglaEmpresa = emp.Tipo_Documento,
                                             DocumentoEmpresa = emp.Nit_Empresa,
                                             RazonSocial = emp.Razon_Social,
                                             TipoDocumentoSigla = td.Descripcion,
                                             Documento = u.Documento,
                                             Nombres = u.Nombres,
                                             Apellidos = u.Apellidos,
                                             NombreRol = r.Nombre,
                                             Correo = u.Correo,
                                             MunicipioSedePpalEmpresa = m.Nombre_Municipio,
                                             IdEstado = eu.Pk_Id_UsuarioEstados,
                                             NombreEstado = eu.EstadoUsuario,
                                             PeriodoInactividad = (u.PeriodoInactivacionCuenta == null ? DateTime.Now : u.PeriodoInactivacionCuenta.Value)
                                         }).ToList();
                    if (usuariosMesaAyuda != null && usuariosMesaAyuda.Count() > 0)
                    {
                        foreach (var usuario in usuariosMesaAyuda)
                        {
                            usuario.PreguntasSeguridad = context.Tbl_RespuestasAPreguntasSeguridad.Where(rps => rps.CodUsuarioSistema == usuario.IdUsuarioSistema).Select(rps => new PreguntasSeguridadSeleccionada()
                            {
                                CodPreguntaSeguridad = rps.Fk_Id_PreguntaSeguridad,
                                NombrePregunta = rps.PreguntaSeguridad.NombrePreguntaSeguridad,
                                RespuestaSeguridad = rps.RespuestareguntaSeguridad
                            }).OrderBy(rps => rps.CodPreguntaSeguridad).ToList();

                            usuario.DatosAdicionalesUsuarios = context.Tbl_DatosAdicionalesUsuario.Where(dau => dau.CodUsuarioSistema == usuario.IdUsuarioSistema).Select(dau => new DatosAdicionalesUsuarios()
                            {
                                NombreDato = dau.NombreDato,
                                ValorDato = dau.ValorDato
                            }).ToList();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return usuariosMesaAyuda;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public EDUsuarioSistema EnviarClaveTemporalUsuarioMesaAyuda(int idUsuario, string passwordTemporal, string saltPassword, string hashPassword)
        {
            EDUsuarioSistema resultado = null;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    var usuario = context.Tbl_UsuarioSistema.Where(us => us.Pk_Id_UsuarioSistema == idUsuario).Select(us => us).FirstOrDefault();
                    if (usuario != null)
                    {
                        usuario.ClaveSalt = saltPassword;
                        usuario.ClaveHash = hashPassword;
                        usuario.PrimerAcceso = true;
                        context.SaveChanges();
                        resultado = new EDUsuarioSistema
                        {
                            IdUsuarioSistema = usuario.Pk_Id_UsuarioSistema,
                            Documento = usuario.Documento,
                            Clave = passwordTemporal,
                            Nombres = usuario.Nombres,
                            Apellidos = usuario.Apellidos,
                            Correo = usuario.Correo,
                            Activo = usuario.Activo
                        };
                    }
                }
            }
            catch (Exception ex)
            {
            }
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
            EDUsuarioSistema resultado = null;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    var usuario = context.Tbl_UsuarioSistema.Where(us => us.Pk_Id_UsuarioSistema == idUsuario).Select(us => us).FirstOrDefault();
                    if (usuario != null)
                    {
                        usuario.Correo = nuevoUsuario;
                        context.SaveChanges();
                        resultado = new EDUsuarioSistema
                        {
                            IdUsuarioSistema = usuario.Pk_Id_UsuarioSistema,
                            Documento = usuario.Documento,
                            Nombres = usuario.Nombres,
                            Apellidos = usuario.Apellidos,
                            Correo = usuario.Correo,
                            Activo = usuario.Activo
                        };
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDocEmp"></param>
        /// <param name="numDocUsu"></param>
        /// <param name="rolSeleccionado"></param>
        /// <returns></returns>
        public int ObtenerTotalUsuariosParaAprobar(string numDocEmp, string numDocUsu, string rolSeleccionado, string idMunicipio, int codUsuarioAprobador)
        {

            try
            {
                var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                var codDeptoCob = 0;
                idMunicipio = idMunicipio.Contains("Seleccione") ? "" : idMunicipio;
                rolSeleccionado = rolSeleccionado.Contains("Seleccione") ? "" : rolSeleccionado;
                var HaynumDocEmp = !string.IsNullOrWhiteSpace(numDocEmp.Trim());
                var HaynumDocUsu = !string.IsNullOrWhiteSpace(numDocUsu.Trim());
                var HayrolSeleccionado = !string.IsNullOrWhiteSpace(rolSeleccionado.Trim());
                var HayidMunicipio = !string.IsNullOrWhiteSpace(idMunicipio.Trim());
                string[] municipiosCobertutra = new string[] { };
                var HayMunicipiosCob = false;
                int resultado = 0;
                using (
                    var context = new SG_SSTContext())
                {

                    var infoCobertura = (from us in context.Tbl_UsuarioSistema
                                         join ur in context.Tbl_UsuariosPorRol on us.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                         join rs in context.Tbl_RolesSistema on ur.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema
                                         join dau in context.Tbl_DatosAdicionalesUsuario on us.Pk_Id_UsuarioSistema equals dau.CodUsuarioSistema
                                         where us.Pk_Id_UsuarioSistema == codUsuarioAprobador
                                         && dau.NombreDato == "Departamento"
                                         select new { RolUsuario = rs.Pk_Id_RolSistema, DeptoCob = dau.ValorDato }).FirstOrDefault();
                    if (infoCobertura != null && !string.IsNullOrEmpty(infoCobertura.DeptoCob))
                        codDeptoCob = Convert.ToInt32(infoCobertura.DeptoCob);
                    //se obtiene el listado de muncipios de conbertura por pate del
                    //Administrador Sucursal 
                    if (infoCobertura != null && infoCobertura.RolUsuario == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorSucursal)
                    {
                        municipiosCobertutra = (from d in context.Tbl_Departamento
                                                join m in context.Tbl_Municipio on d.Pk_Id_Departamento equals m.Fk_Nombre_Departamento
                                                where d.Pk_Id_Departamento == codDeptoCob
                                                select m.Nombre_Municipio).ToArray();
                        if (municipiosCobertutra != null && municipiosCobertutra.Count() > 0)
                            HayMunicipiosCob = true;
                    }
                    resultado = (from ua in context.Tbl_UsuariosParaAprobar
                                 join dau in (context.Tbl_DatosAdicionalesUsuario.Where(d => d.NombreDato.Equals("RutaPdfAutorizacion")).Select(d => d)) on ua.Pk_id_UsuarioParaAprobar equals dau.CodUsuarioAprobar
                                 into leftdau
                                 from joindau in leftdau.DefaultIfEmpty()
                                 join tde in context.Tbl_TipoDocumentos on ua.TipoDocumentoEmpresa equals tde.PK_IDTipo_Documento
                                 join tda in context.Tbl_TipoDocumentos on ua.TipoDocumentoUsuario equals tda.PK_IDTipo_Documento
                                 join rs in context.Tbl_RolesSistema on ua.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema
                                 join ur in context.Tbl_UsuariosRechazadosSitema on ua.Pk_id_UsuarioParaAprobar equals ur.Fk_Id_UsuarioParaActivar
                                 into lefttur
                                 from joinur in lefttur.DefaultIfEmpty()
                                 where (!HayMunicipiosCob || municipiosCobertutra.Contains(ua.MunicipioSedePpal))
                                 && (!HaynumDocEmp || ua.NumeroDocumentoEmprsa.Equals(numDocEmp))
                                 && (!HaynumDocUsu || ua.NumeroDocumentoUsuario.Equals(numDocUsu))
                                 && (!HayrolSeleccionado || ua.Fk_Id_RolSistema.ToString().Equals(rolSeleccionado))
                                 && (!HayidMunicipio || ua.MunicipioSedePpal.Equals(idMunicipio))
                                 && joinur == null
                                 && ua.FK_Id_EstadoUsuario == estadoPendiente
                                 select new EDUsuarioPorAprobar
                                 {
                                     IdUsuarioPorAprobar = ua.Pk_id_UsuarioParaAprobar,
                                     Nombres = ua.Nombres,
                                     Apellidos = ua.Apellidos,
                                     Correo = ua.EmailUsuario,
                                     TipoDocumentoEmpresa = tde.Descripcion,
                                     NumDocumentoEmpresa = ua.NumeroDocumentoEmprsa,
                                     RazonSocialEmpresa = ua.RazonSocial,
                                     MunicipioSedePpalEmpresa = ua.MunicipioSedePpal,
                                     TipoDocumentoAfi = tda.Descripcion,
                                     NumDocumentoAfi = ua.NumeroDocumentoUsuario,
                                     RolUsuario = ua.Fk_Id_RolSistema,
                                     NombreRol = rs.Nombre,
                                     RutaPdfAutorizacion = string.IsNullOrEmpty(joindau.ValorDato) ? "No Aplica" : joindau.ValorDato
                                 }).ToList().Count();

                    //resultado = context.Database.SqlQuery<EDUsuarioPorAprobar>("BuscarUsuariosParaAprobar @NumDocEmp, @NumDocUsu, @RolSeleccionado, @Municipio, @Pagina",
                    //new SqlParameter("@NumDocEmp", numDocEmp),
                    //new SqlParameter("@NumDocUsu", numDocUsu),
                    //new SqlParameter("@RolSeleccionado", rolSeleccionado),
                    //new SqlParameter("@Municipio", idMunicipio),
                    //new SqlParameter("@Pagina", paginaActual)).ToList();
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

            //try
            //{
            //    var resultado = 0;
            //    using (var context = new SG_SSTContext())
            //    {
            //        resultado = context.Database.SqlQuery<int>("ObtenerCantidadUsuariosParaAprobar @NumDocEmp, @NumDocUsu, @RolSeleccionado",
            //            new SqlParameter("@NumDocEmp", numDocEmp),
            //            new SqlParameter("@NumDocUsu", numDocUsu),
            //            new SqlParameter("@RolSeleccionado", rolSeleccionado)).FirstOrDefault();
            //    }
            //    return resultado;
            //}
            //catch (Exception ex)
            //{
            //    return 0;
            //}
        }

        /// <summary>
        /// Valida que no exista un usuario registrado bajo el mismo documento de
        /// empresa y afiliado
        /// </summary>
        /// <param name="usuarioRegistrar"></param>
        /// <returns></returns>
        public bool ValidarExistenciaUsuario(EDUsuarioPorAprobar usuarioRegistrar, out int error)
        {
            try
            {
                var resultado = false;
                using (var context = new SG_SSTContext())
                {
                    var usuarioSistema = (from u in context.Tbl_UsuarioSistema
                                          join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                          join emp in context.Tbl_Empresa on ue.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                                          where u.Documento.Equals(usuarioRegistrar.NumDocumentoAfi) && emp.Nit_Empresa.Equals(usuarioRegistrar.NumDocumentoEmpresa)
                                          select u).FirstOrDefault();
                    if (usuarioSistema != null)
                        resultado = true;
                }
                error = 0;
                return resultado;
            }
            catch (Exception ex)
            {
                error = 1;
                return false;
            }
        }
        /// <summary>
        /// Valida que no exista una solicitud de aprobación pendiente para el mismo usuario
        /// teniendo en cuenta el tipo y número de identificación de la empresa, el perfil solicitado
        /// y el tipo y número de identificación del usuario
        /// </summary>
        /// <param name="usuarioRegistrar"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool ValidarSolicitudAprobacionPendiente(EDUsuarioPorAprobar usuarioRegistrar, out int error)
        {
            try
            {
                var resultado = false;
                using (var context = new SG_SSTContext())
                {
                    var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                    var tipoDocumentoEmpresa = context.Tbl_TipoDocumentos.Where(td => td.Sigla.ToUpper().Equals(usuarioRegistrar.TipoDocumentoEmpresa.ToUpper())).Select(td => td.PK_IDTipo_Documento).SingleOrDefault();
                    var tipoDocumentoEmpleado = context.Tbl_TipoDocumentos.Where(td => td.Sigla.ToUpper().Equals(usuarioRegistrar.TipoDocumentoAfi.ToUpper())).Select(td => td.PK_IDTipo_Documento).SingleOrDefault();
                    var usuarioSistema = (from ua in context.Tbl_UsuariosParaAprobar
                                          where ua.TipoDocumentoEmpresa == tipoDocumentoEmpresa
                                          && ua.NumeroDocumentoEmprsa.Equals(usuarioRegistrar.NumDocumentoEmpresa)
                                          && ua.TipoDocumentoUsuario == tipoDocumentoEmpleado
                                          && ua.NumeroDocumentoUsuario.Equals(usuarioRegistrar.NumDocumentoAfi)
                                          && ua.Fk_Id_RolSistema == usuarioRegistrar.RolUsuario
                                          && ua.FK_Id_EstadoUsuario == estadoPendiente
                                          select ua).FirstOrDefault();
                    if (usuarioSistema != null)
                        resultado = true;
                }
                error = 0;
                return resultado;
            }
            catch (Exception ex)
            {
                error = 1;
                return false;
            }
        }
        /// <summary>
        /// Registra al empleado que ha solicitado la creaciión de su usuario en el sistema
        /// </summary>
        /// <param name="usuarioSistema"></param>
        /// <returns></returns>
        public bool RegistrarUsuarioParaAprobar(EDUsuarioPorAprobar usuarioAprobar)
        {
            try
            {
                var resultado = false;
                using (var context = new SG_SSTContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                            var tipoDocumentoEmpresa = context.Tbl_TipoDocumentos.Where(td => td.Sigla.ToUpper().Equals(usuarioAprobar.TipoDocumentoEmpresa.ToUpper())).Select(td => td.PK_IDTipo_Documento).FirstOrDefault();
                            var tipoDocumentoEmpleado = context.Tbl_TipoDocumentos.Where(td => td.Sigla.ToUpper().Equals(usuarioAprobar.TipoDocumentoAfi.ToUpper())).Select(td => td.PK_IDTipo_Documento).FirstOrDefault();
                            var usuarioPorAprobar = new UsuarioParaAprobar();
                            usuarioPorAprobar.TipoDocumentoEmpresa = tipoDocumentoEmpresa;
                            usuarioPorAprobar.NumeroDocumentoEmprsa = usuarioAprobar.NumDocumentoEmpresa;
                            usuarioPorAprobar.RazonSocial = usuarioAprobar.RazonSocialEmpresa;
                            usuarioPorAprobar.MunicipioSedePpal = usuarioAprobar.MunicipioSedePpalEmpresa;
                            usuarioPorAprobar.TipoDocumentoUsuario = tipoDocumentoEmpleado;
                            usuarioPorAprobar.NumeroDocumentoUsuario = usuarioAprobar.NumDocumentoAfi;
                            usuarioPorAprobar.Nombres = usuarioAprobar.Nombres;
                            usuarioPorAprobar.Apellidos = usuarioAprobar.Apellidos;
                            usuarioPorAprobar.Fk_Id_RolSistema = usuarioAprobar.RolUsuario;
                            usuarioPorAprobar.EmailUsuario = usuarioAprobar.Correo;
                            usuarioPorAprobar.FK_Id_EstadoUsuario = estadoPendiente;
                            context.Tbl_UsuariosParaAprobar.Add(usuarioPorAprobar);
                            context.SaveChanges();
                            if (usuarioAprobar.PreguntasSeguridadSeleccionadas != null && usuarioAprobar.PreguntasSeguridadSeleccionadas.Count > 0)
                            {
                                var preguntasSeguridadSelec = new List<RespuestaAPreguntaSeguridad>();
                                foreach (var ps in usuarioAprobar.PreguntasSeguridadSeleccionadas)
                                {
                                    var rps = new RespuestaAPreguntaSeguridad();
                                    rps.Fk_Id_PreguntaSeguridad = ps.CodPreguntaSeguridad;
                                    rps.RespuestareguntaSeguridad = ps.RespuestaSeguridad;
                                    rps.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                    preguntasSeguridadSelec.Add(rps);
                                }
                                context.Tbl_RespuestasAPreguntasSeguridad.AddRange(preguntasSeguridadSelec);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuarioAprobar.DepartamentoSedePpalEmpresa))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                nuevoDatoUsuario.NombreDato = "Departamento";
                                nuevoDatoUsuario.ValorDato = usuarioAprobar.DepartamentoSedePpalEmpresa;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuarioAprobar.MunicipioSedePpalEmpresa))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                nuevoDatoUsuario.NombreDato = "Municipio";
                                nuevoDatoUsuario.ValorDato = usuarioAprobar.MunicipioSedePpalEmpresa;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuarioAprobar.Telefono))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                nuevoDatoUsuario.NombreDato = "Telefono";
                                nuevoDatoUsuario.ValorDato = usuarioAprobar.Telefono;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuarioAprobar.FechaInicioContrato.ToString()))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                nuevoDatoUsuario.NombreDato = "FechaInicioContrato";
                                nuevoDatoUsuario.ValorDato = usuarioAprobar.FechaInicioContrato.ToString();
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuarioAprobar.FechaFinContrato.ToString()))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                nuevoDatoUsuario.NombreDato = "FechaFinContrato";
                                nuevoDatoUsuario.ValorDato = usuarioAprobar.FechaFinContrato.ToString();
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuarioAprobar.RutaPdfAutorizacion))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioAprobar = usuarioPorAprobar.Pk_id_UsuarioParaAprobar;
                                nuevoDatoUsuario.NombreDato = "RutaPdfAutorizacion";
                                nuevoDatoUsuario.ValorDato = usuarioAprobar.RutaPdfAutorizacion;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            tx.Commit();
                            resultado = true;
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Inserta los usuarios aprobados en la base de datos, validando previamente
        /// que ya no estén registrados.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="usuariosRegistrar"></param>
        /// <returns></returns>
        public List<EDUsuarioSistema> InsertarUsuariosAprobadosSistema(List<EDUsuarioSistema> usuariosRegistrar, out Dictionary<string, string> idsUsuarioSistema)
        {
            idsUsuarioSistema = null;
            try
            {
                List<EDUsuarioSistema> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var estadoActivo = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuario.Activo;
                            foreach (var usuario in usuariosRegistrar)
                            {
                                //se valida que el usuario a insertar no exista en la base de datos
                                var usuarioSistema = (from u in context.Tbl_UsuarioSistema
                                                      join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                                      join emp in context.Tbl_Empresa on ue.Fk_Id_Empresa equals emp.Pk_Id_Empresa
                                                      join td in context.Tbl_TipoDocumentos on emp.Tipo_Documento equals td.Sigla
                                                      join ru in context.Tbl_UsuariosPorRol on u.Pk_Id_UsuarioSistema equals ru.Fk_Id_UsuarioSistema
                                                      where td.PK_IDTipo_Documento == usuario.TipoDocumentoEmpresa
                                                      && emp.Nit_Empresa.Equals(usuario.DocumentoEmpresa)
                                                      && u.Fk_Id_TipoDocumento == usuario.TipoDocumento
                                                      && u.Documento.Equals(usuario.Documento)
                                                      && ru.Fk_Id_RolSistema == usuario.IdRol
                                                      select u).FirstOrDefault();
                                if (usuarioSistema == null)
                                {
                                    var guidUsuario = new Guid();
                                    //se registra un nuevo UsuarioSistema
                                    var nuevoUsuario = new UsuarioSistema();
                                    nuevoUsuario.Fk_Id_TipoDocumento = usuario.TipoDocumento;
                                    nuevoUsuario.ClaveSalt = usuario.ClaveSalt;
                                    nuevoUsuario.ClaveHash = usuario.ClaveHash;
                                    nuevoUsuario.Correo = usuario.Correo;
                                    nuevoUsuario.Documento = usuario.Documento;
                                    nuevoUsuario.Nombres = usuario.Nombres;
                                    nuevoUsuario.Apellidos = usuario.Apellidos;
                                    nuevoUsuario.Activo = true;
                                    nuevoUsuario.FK_Id_EstadoUsuario = estadoActivo;
                                    nuevoUsuario.PrimerAcceso = true;
                                    nuevoUsuario.PeriodoInactivacionCuenta = usuario.PeriodoInactividad;
                                    context.Tbl_UsuarioSistema.Add(nuevoUsuario);
                                    context.SaveChanges();
                                    usuario.IdUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                                    //se registra un nuevo UsuarioSistemaEmpresa
                                    var nuevoUsuarioEmpresa = new UsuarioSistemaEmpresa();
                                    nuevoUsuarioEmpresa.Fk_Id_Empresa = usuario.CodEmpresa;
                                    nuevoUsuarioEmpresa.Fk_Id_UsuarioSistema = usuario.IdUsuarioSistema;
                                    context.Tbl_UsuarioSistemaEmpresa.Add(nuevoUsuarioEmpresa);
                                    context.SaveChanges();
                                    //se registra un nuevo usuario por rol
                                    var usuariosPorRol = new UsuarioPorRol();
                                    usuariosPorRol.Fk_Id_RolSistema = usuario.IdRol;
                                    usuariosPorRol.Fk_Id_UsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                                    context.Tbl_UsuariosPorRol.Add(usuariosPorRol);
                                    //se registra una nueva clave temporal para el usuario
                                    var passwordTemporal = new PasswordTemporalUsuariosSistema();
                                    passwordTemporal.Fk_Id_UsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                                    passwordTemporal.Password = usuario.Clave;
                                    passwordTemporal.PasswordSalt = nuevoUsuario.ClaveSalt;
                                    passwordTemporal.PasswordHash = nuevoUsuario.ClaveHash;
                                    context.Tbl_PasswordsTemporalesUsuariosSistema.Add(passwordTemporal);
                                    context.SaveChanges();
                                    usuario.IdUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                                    int codUsuarioPorAprobar = 0;
                                    EliminarUsuariosPorAprovar(context, usuario, out codUsuarioPorAprobar);
                                    //actualizar id usuario en preguntas seguridad
                                    var rtaptasdad = context.Tbl_RespuestasAPreguntasSeguridad.Where(rps => rps.CodUsuarioAprobar == codUsuarioPorAprobar).Select(rps => rps).ToList();
                                    if (rtaptasdad != null && rtaptasdad.Count() > 0)
                                        rtaptasdad.ForEach(rps => { rps.CodUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema; rps.CodUsuarioAprobar = null; });
                                    //actualizar datos adicionales del usuario aprobado
                                    if (usuario.IdRol == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST)
                                    {
                                        var directorioSoporte = context.Tbl_DatosAdicionalesUsuario.Where(da => da.CodUsuarioAprobar == codUsuarioPorAprobar && da.NombreDato.Equals("RutaPdfAutorizacion")).Select(da => da).FirstOrDefault();
                                        if (directorioSoporte != null)
                                        {
                                            var nuevaRutaSoporte = string.Empty;
                                            var rutaSoporteActual = directorioSoporte.ValorDato;
                                            var rutaSoporte = directorioSoporte.ValorDato.Split('\\');
                                            for (var i = 0; i < rutaSoporte.Length; i++)
                                            {
                                                if (Guid.TryParse(rutaSoporte[i], out guidUsuario))
                                                    nuevaRutaSoporte = nuevaRutaSoporte + string.Format("{0}\\", nuevoUsuario.Pk_Id_UsuarioSistema);
                                                else
                                                {
                                                    if ((i + 1) < rutaSoporte.Length)
                                                        nuevaRutaSoporte = nuevaRutaSoporte + string.Format("{0}\\", rutaSoporte[i]);
                                                    else
                                                        nuevaRutaSoporte = nuevaRutaSoporte + string.Format("{0}", rutaSoporte[i]);
                                                }
                                            }
                                            directorioSoporte.ValorDato = nuevaRutaSoporte;
                                            context.SaveChanges();
                                            idsUsuarioSistema = new Dictionary<string, string>();
                                            idsUsuarioSistema.Add(rutaSoporteActual, nuevaRutaSoporte);
                                        }
                                    }
                                    var datosAdicionales = context.Tbl_DatosAdicionalesUsuario.Where(dau => dau.CodUsuarioAprobar == codUsuarioPorAprobar).Select(dau => dau).ToList();
                                    if (datosAdicionales != null && datosAdicionales.Count() > 0)
                                        datosAdicionales.ForEach(dau => { dau.CodUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema; dau.CodUsuarioAprobar = null; });
                                    context.SaveChanges();
                                    var empresaActualizar = context.Tbl_Empresa.Where(e => e.Pk_Id_Empresa == usuario.CodEmpresa).Select(e => e).FirstOrDefault();
                                    if (empresaActualizar != null)
                                    {
                                        empresaActualizar.Nit_Empresa = usuario.DocumentoEmpresa;
                                        context.SaveChanges();
                                        if (resultado == null)
                                            resultado = new List<EDUsuarioSistema>();
                                        resultado.Add(usuario);
                                    }
                                }
                                //se elimina la información de este usuario debido a que ya existe en la base de datos
                                else {
                                    int codUsuarioPorAprobar = 0;
                                    EliminarUsuariosPorAprovar(context, usuario, out codUsuarioPorAprobar);
                                    //se eliminan las respuestas de seguridad configuradas por el usuario
                                    var rtaptasdad = context.Tbl_RespuestasAPreguntasSeguridad.Where(rps => rps.CodUsuarioAprobar == codUsuarioPorAprobar).Select(rps => rps).ToList();
                                    if (rtaptasdad != null && rtaptasdad.Count() > 0)
                                        context.Tbl_RespuestasAPreguntasSeguridad.RemoveRange(rtaptasdad);
                                    //se eliminan los datos adicionales del usuario
                                    var datosAdicionales = context.Tbl_DatosAdicionalesUsuario.Where(dau => dau.CodUsuarioAprobar == codUsuarioPorAprobar).Select(dau => dau).ToList();
                                    if (datosAdicionales != null && datosAdicionales.Count() > 0)
                                        context.Tbl_DatosAdicionalesUsuario.RemoveRange(datosAdicionales);
                                    context.SaveChanges();
                                }
                            }
                            tx.Commit();
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            idsUsuarioSistema = null;
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                idsUsuarioSistema = null;
                return null;
            }
        }
        /// <summary>
        /// Inserta Usuario Arl positiva
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertarUsuarioArlSistema(EDUsuarioSistema usuario)
        {
            try
            {
                var resultado = false;
                var estadoActivo = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuario.Activo;
                using (var context = new SG_SSTContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            //se registra un nuevo UsuarioSistema
                            var nuevoUsuario = new UsuarioSistema();
                            nuevoUsuario.Fk_Id_TipoDocumento = usuario.TipoDocumento;
                            nuevoUsuario.ClaveSalt = usuario.ClaveSalt;
                            nuevoUsuario.ClaveHash = usuario.ClaveHash;
                            nuevoUsuario.Correo = usuario.Correo;
                            nuevoUsuario.Documento = usuario.Documento;
                            nuevoUsuario.Nombres = usuario.Nombres;
                            nuevoUsuario.Apellidos = usuario.Apellidos;
                            nuevoUsuario.Activo = usuario.Activo;
                            nuevoUsuario.FK_Id_EstadoUsuario = estadoActivo;
                            nuevoUsuario.Bloqueado = usuario.Bloqueado;
                            nuevoUsuario.PrimerAcceso = true;
                            nuevoUsuario.PeriodoInactivacionCuenta = usuario.PeriodoInactividad;
                            context.Tbl_UsuarioSistema.Add(nuevoUsuario);
                            context.SaveChanges();
                            usuario.IdUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                            //se registra un nuevo UsuarioSistemaEmpresa
                            var nuevoUsuarioEmpresa = new UsuarioSistemaEmpresa();
                            nuevoUsuarioEmpresa.Fk_Id_Empresa = usuario.CodEmpresa;
                            nuevoUsuarioEmpresa.Fk_Id_UsuarioSistema = usuario.IdUsuarioSistema;
                            context.Tbl_UsuarioSistemaEmpresa.Add(nuevoUsuarioEmpresa);
                            context.SaveChanges();
                            //se registra un nuevo usuario por rol
                            var usuariosPorRol = new UsuarioPorRol();
                            usuariosPorRol.Fk_Id_RolSistema = usuario.IdRol;
                            usuariosPorRol.Fk_Id_UsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                            context.Tbl_UsuariosPorRol.Add(usuariosPorRol);
                            //se registra una nueva clave temporal para el usuario
                            var passwordTemporal = new PasswordTemporalUsuariosSistema();
                            passwordTemporal.Fk_Id_UsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                            passwordTemporal.Password = usuario.Clave;
                            passwordTemporal.PasswordSalt = nuevoUsuario.ClaveSalt;
                            passwordTemporal.PasswordHash = nuevoUsuario.ClaveHash;
                            context.Tbl_PasswordsTemporalesUsuariosSistema.Add(passwordTemporal);
                            context.SaveChanges();
                            usuario.IdUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema;
                            int codUsuarioPorAprobar = 0;
                            EliminarUsuariosPorAprovar(context, usuario, out codUsuarioPorAprobar);
                            //actualizar id usuario en preguntas seguridad
                            var rtaptasdad = context.Tbl_RespuestasAPreguntasSeguridad.Where(rps => rps.CodUsuarioAprobar == codUsuarioPorAprobar).Select(rps => rps).ToList();
                            if (rtaptasdad != null && rtaptasdad.Count() > 0)
                                rtaptasdad.ForEach(rps => { rps.CodUsuarioSistema = nuevoUsuario.Pk_Id_UsuarioSistema; rps.CodUsuarioAprobar = null; });
                            context.SaveChanges();
                            var empresaActualizar = context.Tbl_Empresa.Where(e => e.Pk_Id_Empresa == usuario.CodEmpresa).Select(e => e).FirstOrDefault();
                            if (empresaActualizar != null)
                            {
                                empresaActualizar.Nit_Empresa = usuario.DocumentoEmpresa;
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuario.DepartamentoSedePpalEmpresa))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioSistema = usuario.IdUsuarioSistema;
                                nuevoDatoUsuario.NombreDato = "Departamento";
                                nuevoDatoUsuario.ValorDato = usuario.DepartamentoSedePpalEmpresa;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuario.MunicipioSedePpalEmpresa))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioSistema = usuario.IdUsuarioSistema;
                                nuevoDatoUsuario.NombreDato = "Municipio";
                                nuevoDatoUsuario.ValorDato = usuario.MunicipioSedePpalEmpresa;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            if (!string.IsNullOrEmpty(usuario.Telefono))
                            {
                                var nuevoDatoUsuario = new DatoAdicionalUsuario();
                                nuevoDatoUsuario.CodUsuarioSistema = usuario.IdUsuarioSistema;
                                nuevoDatoUsuario.NombreDato = "Telefono";
                                nuevoDatoUsuario.ValorDato = usuario.Telefono;
                                context.Tbl_DatosAdicionalesUsuario.Add(nuevoDatoUsuario);
                                context.SaveChanges();
                            }
                            tx.Commit();
                            resultado = true;
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// se insertan los usuarios que fueron rechazados por alguna causal
        /// </summary>
        /// <param name="usuariosSistema"></param>
        /// <returns></returns>
        public List<EDUsuarioPorAprobar> InsertarUsuariosNoAprobadosSistema(List<EDUsuarioPorAprobar> usuariosRechazados)
        {
            try
            {
                List<EDUsuarioPorAprobar> resultado = null;
                using (var context = new SG_SSTContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var estadoRechazado = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Rechazado;
                            if (usuariosRechazados != null && usuariosRechazados.Count > 0)
                            {
                                foreach (var usuario in usuariosRechazados)
                                {
                                    //se obtiene el usuario que se debe rechazar
                                    var usuarioRechazado = context.Tbl_UsuariosParaAprobar.Where(ua => ua.Pk_id_UsuarioParaAprobar == usuario.IdUsuarioPorAprobar).Select(ua => ua).SingleOrDefault();
                                    if(usuarioRechazado != null)
                                    {
                                        usuarioRechazado.FK_Id_EstadoUsuario = estadoRechazado;
                                        //nuevo Usuario rechazado
                                        var nuevoUsuario = new UsuarioRechazadoSistema();
                                        nuevoUsuario.Fk_Id_UsuarioParaActivar = usuario.IdUsuarioPorAprobar;
                                        nuevoUsuario.Fk_Id_CausalRechazoUsuario = usuario.CausalRechazo;
                                        context.Tbl_UsuariosRechazadosSitema.Add(nuevoUsuario);
                                        context.SaveChanges();
                                        if (resultado == null)
                                            resultado = new List<EDUsuarioPorAprobar>();
                                        resultado.Add(usuario);
                                    }
                                }
                                tx.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                        }
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioActual"></param>
        /// <returns></returns>
        public EDUsuarioSistema AutenticarUsuario(EDUsuarioSistema usuarioActual)
        {
            try
            {
                EDUsuarioSistema resultado = null;
                using (var context = new SG_SSTContext())
                {
                    var result = (from u in context.Tbl_UsuarioSistema
                                  join ur in context.Tbl_UsuariosPorRol on u.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                  join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                  join e in context.Tbl_Empresa on ue.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                  where u.Documento.Equals(usuarioActual.Documento) && e.Nit_Empresa.Equals(usuarioActual.DocumentoEmpresa)
                                  select new EDUsuarioSistema()
                                  {
                                      IdUsuarioSistema = u.Pk_Id_UsuarioSistema,
                                      CodEmpresa = e.Pk_Id_Empresa,
                                      TipoDocumentoSiglaEmpresa = e.Tipo_Documento,
                                      DocumentoEmpresa = e.Nit_Empresa,
                                      RazonSocial = e.Razon_Social,
                                      TipoDocumentoSigla = u.TipoDocumento.Sigla,
                                      Documento = u.Documento,
                                      Nombres = u.Nombres,
                                      Apellidos = u.Apellidos,
                                      ClaveSalt = u.ClaveSalt,
                                      ClaveHash = u.ClaveHash,
                                      PrimerAcceso = u.PrimerAcceso,
                                      Activo = u.Activo,
                                      EstadoUsuario = u.FK_Id_EstadoUsuario,
                                      IdRol = ur.Fk_Id_RolSistema,
                                      NombreRol = ur.RolSistema.Nombre,
                                      PeriodoInactividad = (u.PeriodoInactivacionCuenta == null ? DateTime.Now : u.PeriodoInactivacionCuenta.Value)
                                  });
                    resultado = result.FirstOrDefault();
                    if (resultado != null)
                    {
                        resultado.PreguntasSeguridad = context.Tbl_RespuestasAPreguntasSeguridad.Where(rps => rps.CodUsuarioSistema == resultado.IdUsuarioSistema).Select(rps => new PreguntasSeguridadSeleccionada()
                        {
                            CodPreguntaSeguridad = rps.Fk_Id_PreguntaSeguridad,
                            NombrePregunta = rps.PreguntaSeguridad.NombrePreguntaSeguridad,
                            RespuestaSeguridad = rps.RespuestareguntaSeguridad
                        }).OrderBy(rps => rps.CodPreguntaSeguridad).ToList();
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                registroLog.RegistrarError(typeof(UsuarioManager), string.Format("Error en la accion AutenticarUsuario Servicio Autenticacion . Hora: {0}, Error: {1}", DateTime.Now, ex.StackTrace), ex);
                return null;//Se debe configurar para que se registe el Log
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoDocEmp"></param>
        /// <param name="numDocEmp"></param>
        /// <param name="tipoDocUsuario"></param>
        /// <param name="numDocUsuario"></param>
        /// <returns></returns>
        public EDUsuarioSistema ConsultarUsuarioPorRelacionLaboral(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario)
        {
            try
            {
                EDUsuarioSistema usuarioSistema = null;
                using (var context = new SG_SSTContext())
                {
                    //obtener el usuario de sistema que desea recuperar su clave
                    usuarioSistema = (from u in context.Tbl_UsuarioSistema
                                      join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                      join e in context.Tbl_Empresa on ue.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                      join td in context.Tbl_TipoDocumentos on u.Fk_Id_TipoDocumento equals td.PK_IDTipo_Documento
                                      where td.Sigla == tipoDocUsuario
                                      && e.Nit_Empresa.Equals(numDocEmp)
                                      && u.Documento.Equals(numDocUsuario)
                                      && e.Tipo_Documento.Equals(tipoDocEmp)
                                      select new EDUsuarioSistema()
                                      {
                                          IdUsuarioSistema = u.Pk_Id_UsuarioSistema,
                                          Correo = u.Correo,
                                          Activo = u.Activo,
                                          Nombres = u.Nombres,
                                          Apellidos = u.Apellidos,
                                          Documento = u.Documento,
                                          PrimerAcceso = u.PrimerAcceso
                                      }).FirstOrDefault();
                }
                return usuarioSistema;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public EDUsuarioSistema ConsultarDatosUsuarioPorRelacionLaboral(string tipoDocEmp, string numDocEmp, string tipoDocUsuario, string numDocUsuario)
        {
            try
            {
                EDUsuarioSistema usuarioSistema = null;
                using (var context = new SG_SSTContext())
                {
                    //obtener el usuario de sistema que desea recuperar su clave
                    usuarioSistema = (from u in context.Tbl_UsuarioSistema
                                      join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                      join e in context.Tbl_Empresa on ue.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                      join td in context.Tbl_TipoDocumentos on u.Fk_Id_TipoDocumento equals td.PK_IDTipo_Documento
                                      where td.Sigla == tipoDocUsuario
                                      && e.Nit_Empresa.Equals(numDocEmp)
                                      && u.Documento.Equals(numDocUsuario)
                                      && e.Tipo_Documento.Equals(tipoDocEmp)
                                      select new EDUsuarioSistema()
                                      {
                                          IdUsuarioSistema = u.Pk_Id_UsuarioSistema,
                                          Correo = u.Correo,
                                          Activo = u.Activo,
                                          Nombres = u.Nombres,
                                          Apellidos = u.Apellidos,
                                          Documento = u.Documento,
                                          PrimerAcceso = u.PrimerAcceso
                                      }).FirstOrDefault();
                    if (usuarioSistema != null)
                    {
                        usuarioSistema.PreguntasSeguridad = context.Tbl_RespuestasAPreguntasSeguridad.Where(rps => rps.CodUsuarioSistema == usuarioSistema.IdUsuarioSistema).Select(rps => new PreguntasSeguridadSeleccionada()
                        {
                            CodPreguntaSeguridad = rps.Fk_Id_PreguntaSeguridad,
                            NombrePregunta = rps.PreguntaSeguridad.NombrePreguntaSeguridad,
                            RespuestaSeguridad = rps.RespuestareguntaSeguridad
                        }).OrderBy(rps => rps.CodPreguntaSeguridad).ToList();
                    }
                }
                return usuarioSistema;
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
            try
            {
                var resultado = false;
                using (var context = new SG_SSTContext())
                {
                    //obtener el usuario sistema
                    var usuarioSistema = context.Tbl_UsuarioSistema.Where(u => u.Pk_Id_UsuarioSistema == usuario.IdUsuarioSistema).Select(u => u).FirstOrDefault();
                    if (usuarioSistema != null)
                    {
                        usuarioSistema.ClaveSalt = usuario.ClaveSalt;
                        usuarioSistema.ClaveHash = usuario.ClaveHash;
                        usuarioSistema.Activo = usuario.Activo;
                        usuarioSistema.PrimerAcceso = usuario.PrimerAcceso;
                        usuarioSistema.PeriodoInactivacionCuenta = DateTime.Now.AddDays(30);
                        context.SaveChanges();
                        resultado = true;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizarClaveUsuarioParaRecuperarClave(EDUsuarioSistema usuario)
        {
            try
            {
                var resultado = false;
                using (var context = new SG_SSTContext())
                {
                    //obtener el usuario sistema
                    var usuarioSistema = context.Tbl_UsuarioSistema.Where(u => u.Pk_Id_UsuarioSistema == usuario.IdUsuarioSistema).Select(u => u).FirstOrDefault();
                    if (usuarioSistema != null)
                    {
                        usuarioSistema.ClaveSalt = usuario.ClaveSalt;
                        usuarioSistema.ClaveHash = usuario.ClaveHash;
                        usuarioSistema.Activo = usuario.Activo;
                        usuarioSistema.PrimerAcceso = usuario.PrimerAcceso;
                        context.SaveChanges();
                        resultado = true;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Actualiza la cantidad de intentos para recuperar clave y 
        /// devuelve el dicha cantidad.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool ActualizarIntentosParaRecuperarClave(EDUsuarioSistema usuario, out int numeroIntentos)
        {
            numeroIntentos = 0;
            try
            {
                var resultado = false;
                using (var context = new SG_SSTContext())
                {
                    //obtener el usuario sistema
                    var usuarioSistema = context.Tbl_UsuarioSistema.Where(u => u.Pk_Id_UsuarioSistema == usuario.IdUsuarioSistema).Select(u => u).FirstOrDefault();
                    if (usuarioSistema != null)
                    {
                        numeroIntentos = usuarioSistema.IntentosRecuperarClave;
                        if (numeroIntentos < 3)
                        {
                            usuarioSistema.IntentosRecuperarClave += 1;
                            context.SaveChanges();
                            numeroIntentos = usuarioSistema.IntentosRecuperarClave;
                        }
                        resultado = true;
                    }
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Valida que exista creado al menos un usuario con el rol pasado por parámetro y retorna:
        /// 0: Si el usuario no existe, 1: Si el usuario existe y se encuentra Inactivo, 2: si el usuario
        /// existe y se encuentra Activo
        /// </summary>
        /// <param name="usuarioActual"></param>
        /// <returns></returns>
        public int ValidarExistenciaUsuarioRolRepresLegal(string tipoDocumentoEmpresa, string numeroDocEmpresa, int RolEvaluar)
        {
            try
            {
                var resultado = 0;
                using (var context = new SG_SSTContext())
                {
                    var result = (from u in context.Tbl_UsuarioSistema
                                  join ur in context.Tbl_UsuariosPorRol on u.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                  join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                  join e in context.Tbl_Empresa on ue.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                  where e.Nit_Empresa.ToUpper().Equals(numeroDocEmpresa) && e.Tipo_Documento.ToUpper().Equals(tipoDocumentoEmpresa.ToUpper()) && ur.Fk_Id_RolSistema == RolEvaluar
                                  select u).FirstOrDefault();
                    if (result == null)
                    {
                        //validar si existe un usuario bajo este rol pendiente por aprobación
                        var tipDocumentoEmpresa = context.Tbl_TipoDocumentos.Where(td => td.Sigla.ToUpper().Equals(tipoDocumentoEmpresa.ToUpper())).Select(td => td.PK_IDTipo_Documento).FirstOrDefault();
                        var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                        var usuarioPorAprobar = context.Tbl_UsuariosParaAprobar
                            .Where(ua => ua.TipoDocumentoEmpresa == tipDocumentoEmpresa && ua.NumeroDocumentoEmprsa.Equals(numeroDocEmpresa) && ua.Fk_Id_RolSistema == RolEvaluar && ua.FK_Id_EstadoUsuario == estadoPendiente)
                            .Select(ua => ua).FirstOrDefault();
                        if (usuarioPorAprobar == null)
                            resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.NoExiste;
                        else
                            resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExistePorAprobar;
                    }
                    else if (result.Activo)
                        resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExisteActivo;
                    else
                        resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaEstadoObjeto.ExisteInactivo;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        /// <summary>
        /// Retorna la cantidad de usuarios por el rol pasado por parámetro, que están asociados a la empresa relacionada
        /// con el tipo y número de identificación. Devuelve el siguiente resultado:
        /// 0: Si no existe ningun usuario, 1: si ýa existen todos los usuarios permitidos para ese rol y se encuentran aprobados,
        /// 2. Si ya existen todos los usuarios permitidos para ese rol pero aun hay usuarios sin aprobar
        /// </summary>
        /// <param name="tipoDocumentoEmpresa"></param>
        /// <param name="documentoEmpresa"></param>
        /// <param name="idRolSeleccionado"></param>
        /// <returns></returns>
        public int validarCantidadUsuariosPorRol(string tipoDocumentoEmpresa, string documentoEmpresa, int idRolSeleccionado)
        {
            try
            {
                var resultado = 0;
                var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                using (var context = new SG_SSTContext())
                {
                    var cantidadMaxUsuarios = context.Tbl_RolesSistema.Where(r => r.Pk_Id_RolSistema == idRolSeleccionado).Select(r => r.CantidadUsuariosPorRol).FirstOrDefault();
                    var cantUsuariosAprobados = (from u in context.Tbl_UsuarioSistema
                                                 join ur in context.Tbl_UsuariosPorRol on u.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                                 join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                                 join e in context.Tbl_Empresa on ue.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                                 where e.Nit_Empresa.ToUpper().Equals(documentoEmpresa) && e.Tipo_Documento.ToUpper().Equals(tipoDocumentoEmpresa.ToUpper()) && ur.Fk_Id_RolSistema == idRolSeleccionado
                                                 select u).Count();
                    var cantUsuariosSinAprobar = (from ua in context.Tbl_UsuariosParaAprobar
                                                  join td in context.Tbl_TipoDocumentos on ua.TipoDocumentoEmpresa equals td.PK_IDTipo_Documento
                                                  where ua.NumeroDocumentoEmprsa.Equals(documentoEmpresa) && td.Sigla.ToUpper().Equals(tipoDocumentoEmpresa.ToUpper())
                                                  && ua.Fk_Id_RolSistema == idRolSeleccionado
                                                  && ua.FK_Id_EstadoUsuario == estadoPendiente
                                                  select ua).Count();
                    //ya se superó la cantidad de usuarios y están aprobados
                    if (cantUsuariosAprobados >= cantidadMaxUsuarios)
                        resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.NoSePuedeCrearTodosAprobados;
                    //ya se superó la cantidad de usuarios y algunos se encuentran sin aprobar
                    else if ((cantUsuariosAprobados + cantUsuariosSinAprobar) >= cantidadMaxUsuarios)
                        resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.NoSePuedeCrearAlgunosSinAprobar;
                    else
                        resultado = (int)Enumeraciones.EnumAdministracionUsuarios.ValidaCantidadUsuariosPorRol.SePuedeCrear;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Inserta un registro controlando la cantidad de commits
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="entity"></param>
        /// <param name="count"></param>
        /// <param name="commitCount"></param>
        /// <param name="recreateContext"></param>
        /// <returns></returns>
        private SG_SSTContext AdicionarUsuarioContexto(SG_SSTContext context, UsuarioSistema usuario, UsuarioSistemaEmpresa usuarioSxEmp, int count, int commitCount, bool recreateContext)
        {
            context.Set<UsuarioSistema>().Add(usuario);
            context.Set<UsuarioSistemaEmpresa>().Add(usuarioSxEmp);
            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = new SG_SSTContext();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }
            return context;
        }

        /// <summary>
        /// Elimina los usuarios que han sido aprobados
        /// </summary>
        /// <param name="usuariosEliminar"></param>
        private void EliminarUsuariosPorAprovar(SG_SSTContext context, EDUsuarioSistema usuariosEliminar, out int codUsuarioPorAprobar)
        {
            codUsuarioPorAprobar = 0;
            try
            {
                var estadoPendiente = (int)Enumeraciones.EnumAdministracionUsuarios.EstadosUsuariosSistema.Pendiente;
                if (context != null)
                {
                    var usuario = context.Tbl_UsuariosParaAprobar.Where(ua => ua.TipoDocumentoEmpresa == usuariosEliminar.TipoDocumentoEmpresa
                    && ua.NumeroDocumentoEmprsa == usuariosEliminar.DocumentoEmpresa
                    && ua.TipoDocumentoUsuario == usuariosEliminar.TipoDocumento
                    && ua.NumeroDocumentoUsuario == usuariosEliminar.Documento
                    && ua.FK_Id_EstadoUsuario == estadoPendiente).Select(ua => ua).FirstOrDefault();
                    if (usuario != null)
                    {
                        codUsuarioPorAprobar = usuario.Pk_id_UsuarioParaAprobar;
                        context.Tbl_UsuariosParaAprobar.Remove(usuario);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuariosEliminar"></param>
        private void EliminarUsuariosPorRechazar(SG_SSTContext context, EDUsuarioPorAprobar usuariosEliminar)
        {
            try
            {
                if (context != null)
                {
                    var usuario = context.Tbl_UsuariosParaAprobar.Where(ua => ua.Pk_id_UsuarioParaAprobar == usuariosEliminar.IdUsuarioPorAprobar).Select(ua => ua).FirstOrDefault();
                    if (usuario != null)
                        context.Tbl_UsuariosParaAprobar.Remove(usuario);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuariosEliminar"></param>
        private void EliminarUsuariosPorAprovar(EDUsuarioPorAprobar usuariosEliminar)
        {
            try
            {
                using (var context = new SG_SSTContext())
                {
                    var tipoIdentificacionEmpresa = (from e in context.Tbl_Empresa
                                                     join td in context.Tbl_TipoDocumentos on e.Tipo_Documento.ToUpper() equals td.Sigla.ToUpper()
                                                     where td.Sigla.Equals(usuariosEliminar.TipoDocumentoEmpresa)
                                                     select td.PK_IDTipo_Documento).FirstOrDefault();
                    var tipoIdentificacionAfiliado = (from e in context.Tbl_Empresa
                                                      join td in context.Tbl_TipoDocumentos on e.Tipo_Documento.ToUpper() equals td.Sigla.ToUpper()
                                                      where td.Sigla.Equals(usuariosEliminar.TipoDocumentoAfi)
                                                      select td.PK_IDTipo_Documento).FirstOrDefault();

                    var usuario = context.Tbl_UsuariosParaAprobar.Where(ua => ua.TipoDocumentoEmpresa == tipoIdentificacionEmpresa
                    && ua.NumeroDocumentoEmprsa == usuariosEliminar.NumDocumentoEmpresa
                    && ua.TipoDocumentoUsuario == tipoIdentificacionAfiliado
                    && ua.NumeroDocumentoUsuario == usuariosEliminar.NumDocumentoAfi).Select(ua => ua).FirstOrDefault();
                    if (usuario != null)
                    {
                        context.Tbl_UsuariosParaAprobar.Remove(usuario);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void ActualizarRolesNuevaEmpresa(int id)
        {
            try
            {
                using (var context = new SG_SSTContext())
                {
                    context.Tbl_Rol.Where(r => r.Fk_Id_Empresa.Equals(null)).ToList().ForEach(r => r.Fk_Id_Empresa = id);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EDMenuRecursoSistema> ObtenerMenuRecursosSistema()
        {
            List<EDMenuRecursoSistema> menuRecursoSistemaOrd = null;
            try
            {
                List<EDMenuRecursoSistema> menuRecursoSistema = null;
                using (var context = new SG_SSTContext())
                {
                    menuRecursoSistema = context.Tbl_RecursosSistema.Select(rs => new EDMenuRecursoSistema()
                    {
                        IdRecursoSistema = rs.Pk_Id_RecursoSistema,
                        CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre.Value,
                        NombreRecursoSistema = rs.Nombre,
                        UrlRecursoSistema = rs.UrlRecurso
                    }).ToList();
                }
                if (menuRecursoSistema != null && menuRecursoSistema.Count() > 0)
                {
                    menuRecursoSistemaOrd =
                        (from rs in menuRecursoSistema
                         where rs.CodRecursoSistemaPadre == null
                         select new EDMenuRecursoSistema
                         {
                             IdRecursoSistema = rs.IdRecursoSistema,
                             NombreRecursoSistema = rs.NombreRecursoSistema,
                             UrlRecursoSistema = rs.UrlRecursoSistema,
                             CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
                             Acceso = rs.Acceso,
                             RecursosSistemaHijos =
                             (from rsd in menuRecursoSistema
                              where rs.IdRecursoSistema == rsd.CodRecursoSistemaPadre
                              select new EDMenuRecursoSistema()
                              {
                                  IdRecursoSistema = rsd.IdRecursoSistema,
                                  NombreRecursoSistema = rsd.NombreRecursoSistema,
                                  UrlRecursoSistema = rsd.UrlRecursoSistema,
                                  CodRecursoSistemaPadre = rsd.CodRecursoSistemaPadre,
                                  Acceso = rsd.Acceso,
                                  RecursosSistemaHijos =
                                 (from rst in menuRecursoSistema
                                  where rsd.IdRecursoSistema == rst.CodRecursoSistemaPadre
                                  select new EDMenuRecursoSistema()
                                  {
                                      IdRecursoSistema = rst.IdRecursoSistema,
                                      NombreRecursoSistema = rst.NombreRecursoSistema,
                                      UrlRecursoSistema = rst.UrlRecursoSistema,
                                      CodRecursoSistemaPadre = rst.CodRecursoSistemaPadre,
                                      Acceso = rst.Acceso
                                  }).ToList()
                              }).ToList()
                         }).ToList();
                }
                return menuRecursoSistemaOrd;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="confiRecSx"></param>
        /// <returns></returns>
        public bool GuardarConfiguracionRecursosSistema(IEnumerable<EDMenuRecursoSistema> confiRecSx, int codRolSistema, int idEmpresaUsuario)
        {
            var resultado = false;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var recDeg = context.Tbl_RecursosDenegadosPorRol.Where(rs => rs.Fk_Id_RolSistema == codRolSistema && rs.Fk_Id_Empresa == idEmpresaUsuario).Select(rs => rs).ToList();
                            context.Tbl_RecursosDenegadosPorRol.RemoveRange(recDeg);
                            var nuevosRecSxDeg =
                                (from nrd in confiRecSx
                                 //join rd in recDeg on nrd.IdRecursoSistema equals rd.Fk_Id_Recurso into leftjoin
                                 //from nrdr in leftjoin.DefaultIfEmpty()
                                 //where nrdr == null
                                 select new RecursoDenegadoPorRol()
                                 {
                                     Fk_Id_RolSistema = codRolSistema,
                                     Fk_Id_Recurso = nrd.IdRecursoSistema,
                                     Fk_Id_Empresa = idEmpresaUsuario
                                 }).ToList();
                            context.Tbl_RecursosDenegadosPorRol.AddRange(nuevosRecSxDeg);
                            context.SaveChanges();
                            tx.Commit();
                            resultado = true;
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            resultado = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }
        /// <summary>
        /// Guarda para cada empresa, la configuracion de los recursos denegados para el rol AsesorSST
        /// </summary>
        /// <param name="confiRecSx"></param>
        /// <param name="empresas"></param>
        /// <returns></returns>
        public bool GuardarConfiguracionRecursosSistemaAsesorSST(IEnumerable<EDMenuRecursoSistema> confiRecSx, List<EDEmpresas> empresas)
        {
            var resultado = false;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    using (var tx = context.Database.BeginTransaction())
                    {
                        try
                        {
                            //se registra la configuracion para cada empresa
                            foreach (var e in empresas)
                            {
                                var codRol = (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST;
                                var recDeg = context.Tbl_RecursosDenegadosPorRol.Where(rs => rs.Fk_Id_RolSistema == codRol && rs.Fk_Id_Empresa == e.Id_Empresa && rs.DocumentoAsesorSST.Equals(e.Tipo_Documento)).Select(rs => rs).ToList();
                                context.Tbl_RecursosDenegadosPorRol.RemoveRange(recDeg);
                                var nuevosRecSxDeg =
                                    (from nrd in confiRecSx
                                     select new RecursoDenegadoPorRol()
                                     {
                                         Fk_Id_RolSistema = codRol,
                                         Fk_Id_Recurso = nrd.IdRecursoSistema,
                                         Fk_Id_Empresa = e.Id_Empresa,
                                         DocumentoAsesorSST = e.Tipo_Documento
                                     }).ToList();
                                context.Tbl_RecursosDenegadosPorRol.AddRange(nuevosRecSxDeg);
                                context.SaveChanges();
                            }
                            tx.Commit();
                            resultado = true;
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            resultado = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRol"></param>
        /// <returns></returns>
        public List<EDMenuRecursoSistema> ObtenerRecursosPorRol(int codRol, int codEmpresa)
        {
            List<EDMenuRecursoSistema> recursosPorRol = null;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    var recursosDeg = context.Tbl_RecursosDenegadosPorRol.Where(rd => rd.Fk_Id_RolSistema == codRol && rd.Fk_Id_Empresa == codEmpresa).Select(rd => rd.Fk_Id_Recurso).ToList();
                    recursosPorRol = (from rr in context.Tbl_RecursosSistema
                                      where !recursosDeg.Contains(rr.Pk_Id_RecursoSistema)
                                      && rr.UrlRecurso != string.Empty
                                      select new EDMenuRecursoSistema()
                                      {
                                          IdRecursoSistema = rr.Pk_Id_RecursoSistema,
                                          CodRecursoSistemaPadre = rr.CodRecursoSistemaPadre,
                                          NombreRecursoSistema = rr.Nombre,
                                          UrlRecursoSistema = rr.UrlRecurso
                                      }).ToList();
                    return recursosPorRol;
                }
            }
            catch (Exception ex)
            {
                return recursosPorRol;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codRol"></param>
        /// <returns></returns>
        public List<EDMenuRecursoSistema> ObtenerRecursosPorRolMenu(int codRol, int codEmpresa)
        {
            List<EDMenuRecursoSistema> recursosPorRol = null;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    var recursosDeg = context.Tbl_RecursosDenegadosPorRol.Where(rd => rd.Fk_Id_RolSistema == codRol && rd.Fk_Id_Empresa == codEmpresa).Select(rd => rd.Fk_Id_Recurso).ToList();
                    recursosPorRol = (from rr in context.Tbl_RecursosSistema
                                      where !recursosDeg.Contains(rr.Pk_Id_RecursoSistema)
                                      select new EDMenuRecursoSistema()
                                      {
                                          IdRecursoSistema = rr.Pk_Id_RecursoSistema,
                                          CodRecursoSistemaPadre = rr.CodRecursoSistemaPadre,
                                          NombreRecursoSistema = rr.Nombre,
                                          UrlRecursoSistema = rr.UrlRecurso
                                      }).ToList();
                    return recursosPorRol;
                }
            }
            catch (Exception ex)
            {
                return recursosPorRol;
            }
        }

        /// <summary>
        /// Obtiene los recursos configurados para un rol y una empresa específica
        /// </summary>
        /// <param name="codRol"></param>
        /// <param name="codEmpresa"></param>
        /// <returns></returns>
        public IEnumerable<EDMenuRecursoSistema> ObtenerRecursosParaConfiguracionAccesos(int codRol, int codEmpresa, string documentoAsesorSST = "")
        {
            List<EDMenuRecursoSistema> recursosPorRolOrd = null;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    List<RecursoDenegadoPorRol> recursosDeg = new List<RecursoDenegadoPorRol>();
                    List<RecursoDenegadoPorRolDefault> recusosDegDefault = new List<RecursoDenegadoPorRolDefault>();
                    List<EDMenuRecursoSistema> recursosPorRol = new List<EDMenuRecursoSistema>();
                    var recursos = context.Tbl_RecursosSistema.ToList();
                    if (codRol == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST)
                        recursosDeg = context.Tbl_RecursosDenegadosPorRol.Where(rd => rd.Fk_Id_RolSistema == codRol && rd.Fk_Id_Empresa == codEmpresa && rd.DocumentoAsesorSST.Equals(documentoAsesorSST)).Select(rd => rd).ToList();
                    else
                        recursosDeg = context.Tbl_RecursosDenegadosPorRol.Where(rd => rd.Fk_Id_RolSistema == codRol && rd.Fk_Id_Empresa == codEmpresa).Select(rd => rd).ToList();
                    if (recursosDeg != null && recursosDeg.Count() > 0)
                    {
                        recursosPorRol = (from rr in recursos
                                          join rd in recursosDeg on rr.Pk_Id_RecursoSistema equals rd.Fk_Id_Recurso into leftjoin
                                          from confrecursos in leftjoin.DefaultIfEmpty()
                                          select new EDMenuRecursoSistema()
                                          {
                                              IdRecursoSistema = rr.Pk_Id_RecursoSistema,
                                              CodRecursoSistemaPadre = rr.CodRecursoSistemaPadre,
                                              NombreRecursoSistema = rr.Nombre,
                                              UrlRecursoSistema = rr.UrlRecurso,
                                              Acceso = (confrecursos == null ? true : false)
                                          }).ToList();
                    }
                    else
                    {
                        recusosDegDefault = context.Tbl_RecursoDenegadoPorRolDefault.Where(rd => rd.Fk_Id_RolSistema == codRol).Select(rd => rd).ToList();
                        recursosPorRol = (from rs in recursos
                                          join rsd in recusosDegDefault on rs.Pk_Id_RecursoSistema equals rsd.Fk_Id_Recurso into leftJoin
                                          from confRecursos in leftJoin.DefaultIfEmpty()
                                          select new EDMenuRecursoSistema()
                                          {
                                              IdRecursoSistema = rs.Pk_Id_RecursoSistema,
                                              CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
                                              NombreRecursoSistema = rs.Nombre,
                                              UrlRecursoSistema = rs.UrlRecurso,
                                              Acceso = (confRecursos == null ? true : false)
                                          }).ToList();
                    }
                    if (recursosPorRol != null && recursosPorRol.Count() > 0)
                    {
                        recursosPorRolOrd =
                            (from rs in recursosPorRol
                             where rs.CodRecursoSistemaPadre == null
                             select new EDMenuRecursoSistema
                             {
                                 IdRecursoSistema = rs.IdRecursoSistema,
                                 NombreRecursoSistema = rs.NombreRecursoSistema,
                                 UrlRecursoSistema = rs.UrlRecursoSistema,
                                 CodRecursoSistemaPadre = rs.CodRecursoSistemaPadre,
                                 Acceso = rs.Acceso,
                                 RecursosSistemaHijos =
                                 (from rsd in recursosPorRol
                                  where rs.IdRecursoSistema == rsd.CodRecursoSistemaPadre
                                  select new EDMenuRecursoSistema()
                                  {
                                      IdRecursoSistema = rsd.IdRecursoSistema,
                                      NombreRecursoSistema = rsd.NombreRecursoSistema,
                                      UrlRecursoSistema = rsd.UrlRecursoSistema,
                                      CodRecursoSistemaPadre = rsd.CodRecursoSistemaPadre,
                                      Acceso = rsd.Acceso,
                                      RecursosSistemaHijos =
                                     (from rst in recursosPorRol
                                      where rsd.IdRecursoSistema == rst.CodRecursoSistemaPadre
                                      select new EDMenuRecursoSistema()
                                      {
                                          IdRecursoSistema = rst.IdRecursoSistema,
                                          NombreRecursoSistema = rst.NombreRecursoSistema,
                                          UrlRecursoSistema = rst.UrlRecursoSistema,
                                          Acceso = rst.Acceso,
                                          CodRecursoSistemaPadre = rst.CodRecursoSistemaPadre
                                      }).ToList()
                                  }).ToList()
                             }).ToList();
                    }
                    return recursosPorRolOrd;
                }
            }
            catch (Exception ex)
            {
                return recursosPorRolOrd;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDocumento"></param>
        /// <returns></returns>
        public List<EDEmpresas> ObtenerDatosUsuarioAsesorSST(string numDocumento)
        {
            List<EDEmpresas> resultado = new List<EDEmpresas>();
            try
            {
                using (var context = new SG_SSTContext())
                {
                    resultado = (from u in context.Tbl_UsuarioSistema
                                 join ue in context.Tbl_UsuarioSistemaEmpresa on u.Pk_Id_UsuarioSistema equals ue.Fk_Id_UsuarioSistema
                                 join e in context.Tbl_Empresa on ue.Fk_Id_Empresa equals e.Pk_Id_Empresa
                                 join ur in context.Tbl_UsuariosPorRol on u.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                 where u.Documento.Equals(numDocumento)
                                 && ur.Fk_Id_RolSistema == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AsesorSST
                                 select new EDEmpresas()
                                 {
                                     Id_Empresa = e.Pk_Id_Empresa,
                                     Razon_Social = e.Razon_Social
                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }


        public List<EDUsuarioSistema> ConsultarUsuariosSistemaPorNit(int idEstado, string nitEmpresa, int numPgina, int cantidadPorPagina)
        {
            List<EDUsuarioSistema> resultado = new List<EDUsuarioSistema>();
            try
            {
                using (var context = new SG_SSTContext())
                {
                    int numPaginas = 0;                   
                    int nitxsede = (from e in context.Tbl_Empresa
                                     join sd in context.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                                        where sd.Empresa.Nit_Empresa == nitEmpresa
                                    select  sd.Pk_Id_Sede).FirstOrDefault();                                                                            
                    if (numPgina > 1)
                        numPaginas = (numPgina * cantidadPorPagina) - cantidadPorPagina;

                    resultado = (from e in context.Tbl_Empresa
                                 join tp in context.Tbl_TipoDocumentos on e.Tipo_Documento equals tp.Sigla
                                 join us in context.Tbl_UsuarioSistemaEmpresa on e.Pk_Id_Empresa equals us.Fk_Id_Empresa
                                 join ue in context.Tbl_UsuarioSistema on us.Fk_Id_UsuarioSistema equals ue.Pk_Id_UsuarioSistema
                                 join et in context.Tbl_UsuarioEstados on ue.FK_Id_EstadoUsuario equals et.Pk_Id_UsuarioEstados
                                 join tp1 in context.Tbl_TipoDocumentos on ue.Fk_Id_TipoDocumento equals tp1.PK_IDTipo_Documento
                                 join sd in context.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                                 join sm in context.Tbl_SedeMunicipio on sd.Pk_Id_Sede equals sm.Fk_id_Sede
                                 join m in context.Tbl_Municipio on sm.Fk_Id_Municipio equals m.Pk_Id_Municipio
                                 join url in context.Tbl_UsuariosPorRol on ue.Pk_Id_UsuarioSistema equals url.Fk_Id_UsuarioSistema into leftjoinur
                                 from jurl in leftjoinur.DefaultIfEmpty()
                                 join rs in context.Tbl_RolesSistema on jurl.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema into leftjoinrs
                                 from jrs in leftjoinrs.DefaultIfEmpty()
                                 //where ue.FK_Id_EstadoUsuario == idEstado && e.Nit_Empresa.Equals(nitEmpresa) && (sd.Nombre_Sede.Equals("CASA MATRIZ") || sd.Nombre_Sede.Equals("Principal"))
                                 where ue.FK_Id_EstadoUsuario == idEstado && e.Nit_Empresa.Equals(nitEmpresa) && sd.Pk_Id_Sede == nitxsede
                                 group ue by new
                                 {
                                     ue.Pk_Id_UsuarioSistema,
                                     ue.Correo,
                                     tp.Descripcion,
                                     e.Nit_Empresa,
                                     e.Razon_Social,
                                     Descripcion2 = tp1.Descripcion,
                                     ue.Documento,
                                     m.Nombre_Municipio,
                                     ue.Nombres,
                                     ue.Apellidos,
                                     jrs.Nombre,
                                     ue.Fk_Id_TipoDocumento,
                                     et.EstadoUsuario
                                 } into grupo
                                 select new EDUsuarioSistema
                                 {
                                     IdUsuarioSistema = grupo.Key.Pk_Id_UsuarioSistema,
                                     Correo = grupo.Key.Correo,
                                     TipoDocumentoSiglaEmpresa = grupo.Key.Descripcion,
                                     DocumentoEmpresa = grupo.Key.Nit_Empresa,
                                     RazonSocial = grupo.Key.Razon_Social,
                                     TipoDocumentoSigla = grupo.Key.Descripcion2,
                                     Documento = grupo.Key.Documento,
                                     MunicipioSedePpalEmpresa = grupo.Key.Nombre_Municipio,
                                     Nombres = grupo.Key.Nombres,
                                     Apellidos = grupo.Key.Apellidos,
                                     RolUsuario = grupo.Key.Nombre,
                                     IdEstado = grupo.Key.Fk_Id_TipoDocumento,
                                     NombreEstado = grupo.Key.EstadoUsuario
                                 }).OrderBy(x => x.IdUsuarioSistema).Skip(numPaginas).Take(cantidadPorPagina).ToList();

                    if (resultado != null && resultado.Count() > 0)
                    {
                        foreach (var usuario in resultado)
                        {
                            usuario.DatosAdicionalesUsuarios = context.Tbl_DatosAdicionalesUsuario.Where(dau => dau.CodUsuarioSistema == usuario.IdUsuarioSistema).Select(dau => new DatosAdicionalesUsuarios()
                            {
                                NombreDato = dau.NombreDato,
                                ValorDato = dau.ValorDato
                            }).ToList();

                        }
                    }

                    resultado[0].CantidadRegistros = (from e in context.Tbl_Empresa
                                                      join tp in context.Tbl_TipoDocumentos on e.Tipo_Documento equals tp.Sigla
                                                      join us in context.Tbl_UsuarioSistemaEmpresa on e.Pk_Id_Empresa equals us.Fk_Id_Empresa
                                                      join ue in context.Tbl_UsuarioSistema on us.Fk_Id_UsuarioSistema equals ue.Pk_Id_UsuarioSistema
                                                      join et in context.Tbl_UsuarioEstados on ue.FK_Id_EstadoUsuario equals et.Pk_Id_UsuarioEstados
                                                      join tp1 in context.Tbl_TipoDocumentos on ue.Fk_Id_TipoDocumento equals tp1.PK_IDTipo_Documento
                                                      join sd in context.Tbl_Sede on e.Pk_Id_Empresa equals sd.Fk_Id_Empresa
                                                      join sm in context.Tbl_SedeMunicipio on sd.Pk_Id_Sede equals sm.Fk_id_Sede
                                                      join m in context.Tbl_Municipio on sm.Fk_Id_Municipio equals m.Pk_Id_Municipio
                                                      join url in context.Tbl_UsuariosPorRol on ue.Pk_Id_UsuarioSistema equals url.Fk_Id_UsuarioSistema into leftjoinur
                                                      from jurl in leftjoinur.DefaultIfEmpty()
                                                      join rs in context.Tbl_RolesSistema on jurl.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema into leftjoinrs
                                                      from jrs in leftjoinrs.DefaultIfEmpty()
                                                      //--Cambió la forma de consultar: porque las sedes ("CASA MATRIZ" y "Principal") se pueden editar.
                                                      //where ue.FK_Id_EstadoUsuario == idEstado && e.Nit_Empresa.Equals(nitEmpresa) && (sd.Nombre_Sede.Equals("CASA MATRIZ") || sd.Nombre_Sede.Equals("Principal"))
                                                      where ue.FK_Id_EstadoUsuario == idEstado && e.Nit_Empresa.Equals(nitEmpresa) && sd.Pk_Id_Sede == nitxsede
                                                      group ue by new
                                                      {
                                                          ue.Pk_Id_UsuarioSistema,
                                                          ue.Correo,
                                                          tp.Descripcion,
                                                          e.Nit_Empresa,
                                                          e.Razon_Social,
                                                          Descripcion2 = tp1.Descripcion,
                                                          ue.Documento,
                                                          m.Nombre_Municipio,
                                                          ue.Nombres,
                                                          ue.Apellidos,
                                                          jrs.Nombre,
                                                          ue.Fk_Id_TipoDocumento,
                                                          et.EstadoUsuario
                                                      } into grupo
                                                      select new EDUsuarioSistema
                                                      {
                                                          IdUsuarioSistema = grupo.Key.Pk_Id_UsuarioSistema,
                                                          Correo = grupo.Key.Correo,
                                                          TipoDocumentoSiglaEmpresa = grupo.Key.Descripcion,
                                                          DocumentoEmpresa = grupo.Key.Nit_Empresa,
                                                          RazonSocial = grupo.Key.Razon_Social,
                                                          TipoDocumentoSigla = grupo.Key.Descripcion2,
                                                          Documento = grupo.Key.Documento,
                                                          MunicipioSedePpalEmpresa = grupo.Key.Nombre_Municipio,
                                                          Nombres = grupo.Key.Nombres,
                                                          Apellidos = grupo.Key.Apellidos,
                                                          RolUsuario = grupo.Key.Nombre,
                                                          IdEstado = grupo.Key.Fk_Id_TipoDocumento,
                                                          NombreEstado = grupo.Key.EstadoUsuario
                                                      }).ToList().Count();
                }
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }


        public List<EDUsuarioSistema> ConsultarEstadosUsuarios()
        {
            List<EDUsuarioSistema> resultado = new List<EDUsuarioSistema>();
            try
            {
                using (var context = new SG_SSTContext())
                {
                    resultado = context.Database.SqlQuery<EDUsuarioSistema>("SP_OBTENER_ESTADOS_USUARIO").ToList();
                }
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public bool ActualizarEstadoUsuario(EDUsuarioSistema usuario)
        {
            bool result = false;
            try
            {
                using (var context = new SG_SSTContext())
                {
                    context.Database.SqlQuery<EDUsuarioSistema>("SP_ACTUALIZA_ESTADO_USUARIO @idEstado, @IdUsuario",
                        new SqlParameter("@idEstado", usuario.IdEstado),
                        new SqlParameter("@IdUsuario", usuario.IdUsuarioSistema)).ToList();
                    result = true;
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public bool IngresarPreguntasSeguridad(EDUsuarioPorAprobar usuarioRegistrar)
        {
            var resultado = false;
            using (var context = new SG_SSTContext())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    try
                    {
                        var preguntasSeguridadSelec = new List<RespuestaAPreguntaSeguridad>();
                        foreach (var ps in usuarioRegistrar.PreguntasSeguridadSeleccionadas)
                        {
                            var rps = new RespuestaAPreguntaSeguridad();
                            rps.Fk_Id_PreguntaSeguridad = ps.CodPreguntaSeguridad;
                            rps.RespuestareguntaSeguridad = ps.RespuestaSeguridad;
                            rps.CodUsuarioSistema = usuarioRegistrar.IdUsuarioPorAprobar;
                            preguntasSeguridadSelec.Add(rps);
                        }
                        context.Tbl_RespuestasAPreguntasSeguridad.AddRange(preguntasSeguridadSelec);
                        context.SaveChanges();
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                    }
                }
            }
            return resultado;
        }


        public List<EDMunicipio> ObtenerMunicipios(int codUsuarioAprobador)
        {
            var codDeptoCob = 0;
            List<EDMunicipio> resultado = new List<EDMunicipio>();
            try
            {
                using (var context = new SG_SSTContext())
                {
                    var infoCobertura = (from us in context.Tbl_UsuarioSistema
                                         join ur in context.Tbl_UsuariosPorRol on us.Pk_Id_UsuarioSistema equals ur.Fk_Id_UsuarioSistema
                                         join rs in context.Tbl_RolesSistema on ur.Fk_Id_RolSistema equals rs.Pk_Id_RolSistema
                                         join dau in context.Tbl_DatosAdicionalesUsuario on us.Pk_Id_UsuarioSistema equals dau.CodUsuarioSistema
                                         where us.Pk_Id_UsuarioSistema == codUsuarioAprobador
                                         && dau.NombreDato == "Departamento"
                                         select new { RolUsuario = rs.Pk_Id_RolSistema, DeptoCob = dau.ValorDato }).FirstOrDefault();
                    if (infoCobertura != null && !string.IsNullOrEmpty(infoCobertura.DeptoCob))
                        codDeptoCob = Convert.ToInt32(infoCobertura.DeptoCob);
                    //se obtiene el listado de muncipios de conbertura por pate del
                    //Administrador Sucursal 
                    if (infoCobertura != null && infoCobertura.RolUsuario == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorSucursal)
                    {
                        var municipiosCobertutra = (from d in context.Tbl_Departamento
                                                    join m in context.Tbl_Municipio on d.Pk_Id_Departamento equals m.Fk_Nombre_Departamento
                                                    where d.Pk_Id_Departamento == codDeptoCob
                                                    select m.Nombre_Municipio).ToArray();
                        resultado = (from m in context.Tbl_UsuariosParaAprobar
                                     where municipiosCobertutra.Contains(m.MunicipioSedePpal)
                                     select new EDMunicipio()
                                     {
                                         IdMunicipio = 0,
                                         NombreMunicipio = m.MunicipioSedePpal
                                     }).OrderBy(m => m.NombreMunicipio).Distinct().ToList();
                    }
                    else
                    {
                        resultado = (from m in context.Tbl_UsuariosParaAprobar
                                     select new EDMunicipio()
                                     {
                                         IdMunicipio = 0,
                                         NombreMunicipio = m.MunicipioSedePpal
                                     }).OrderBy(m => m.NombreMunicipio).Distinct().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public Boolean GuardarRecursosDefault(List<EDRecursosDefault> recursosDefault)
        {
            var resultado = false;
            using (var context = new SG_SSTContext())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<RecursoDenegadoPorRolDefault> ListaRecursoDenegados = new List<RecursoDenegadoPorRolDefault>();
                        foreach (var recurosrol in recursosDefault)
                        {
                            RecursoDenegadoPorRolDefault rdpr = new RecursoDenegadoPorRolDefault();
                            rdpr.Fk_Id_Recurso = recurosrol.idRecurso;
                            rdpr.Fk_Id_RolSistema = recurosrol.idRol;
                            ListaRecursoDenegados.Add(rdpr);
                        }
                        context.Tbl_RecursoDenegadoPorRolDefault.AddRange(ListaRecursoDenegados);
                        context.SaveChanges();
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                    }
                }
            }
            return resultado;
        }

        public bool validarIdRecursoSistema(int idRecurso) {
            using (var context = new SG_SSTContext())
            {
                RecursoSistema recurso = context.Tbl_RecursosSistema.Find(idRecurso);
                if (recurso == null)
                    return false;
                else
                    return true;
            }
        }

        public bool validarIdRolSistema(int idRol)
        {
            using (var context = new SG_SSTContext())
            {
                RolSistema rol = context.Tbl_RolesSistema.Find(idRol);
                if (rol == null)
                    return false;
                else
                    return true;
            }
        }

        public bool ElimiarRecursosPorDefaultXIdRol(int idRol)
        { 
            var resultado = false;
            using (var context = new SG_SSTContext())
            {
                using (var tx = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<RecursoDenegadoPorRolDefault> rdpr = context.Tbl_RecursoDenegadoPorRolDefault.Where(rdd => rdd.Fk_Id_RolSistema == idRol).ToList();
                        context.Tbl_RecursoDenegadoPorRolDefault.RemoveRange(rdpr);
                        context.SaveChanges();
                        tx.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                    }
                }
            }
            return resultado;
        }
    }
}
