using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SG_SST.Models.AdminUsuarios;
using Newtonsoft.Json;
using SG_SST.Models.Login;

namespace SG_SST.Helpers
{
    public class AutorizacionAdminSistema : AuthorizeAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var autorizado = false;
            var usuario = ObtenerUsuarioEnSesion(HttpContext.Current);
            if (usuario != null)
            {
                var codRol = usuario.RolSistema;
                var httpMethod = httpContext.Request.RequestContext.HttpContext.Request.HttpMethod;
                if (!httpMethod.ToUpper().Equals("GET"))
                    return true;
                var datosRequest = httpContext.Request.RequestContext.RouteData;
                var actualControlador = datosRequest.GetRequiredString("controller");
                var actualAccion = datosRequest.GetRequiredString("action");
                if (actualControlador.ToUpper().Equals("ADMINUSUARIOS") && actualAccion.ToUpper().Equals("APROBARUSUARIOSSISTEMA"))
                {
                    if (codRol == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorSistema ||
                        codRol == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorNacional ||
                        codRol == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorSucursal)
                        autorizado = true;
                }
                else if (codRol == (int)Enumeraciones.EnumAdministracionUsuarios.RolesSistema.AdministradorSistema)
                    autorizado = true;
            }
            return autorizado;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            {
                { "action", "MostrarAccesoDenegado" },
                { "controller", "Home" }
            });
        }
        /// <summary>
        /// Obtiene los datos de sesion asociados a un usuario
        /// </summary>
        /// <returns></returns>
        private UsuarioSessionModel ObtenerUsuarioEnSesion(HttpContext context)
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
        /// Encripta una cadena
        private string Encriptar(string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        private string DesEncriptar(string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}