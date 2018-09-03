using Newtonsoft.Json;
using SG_SST.Logica.Usuarios;
using SG_SST.Models.AdminUsuarios;
using SG_SST.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Helpers
{
    public class GestionAutorizacion : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var autorizado = false;
            if (System.Web.HttpContext.Current.Session["UsuarioSession"] != null)
            {
                var datosUsuario = DesEncriptar(System.Web.HttpContext.Current.Session["UsuarioSession"].ToString());
                var usuario = JsonConvert.DeserializeObject<UsuarioSessionModel>(datosUsuario);
                if (usuario != null)
                {
                    if (usuario.PrimerAcceso)
                        return false;
                }
                if (httpContext.Session["RecursosPorRol"] != null)
                {
                    var recursosPorRol = httpContext.Session["RecursosPorRol"] as List<RecursosPorRolModel>;
                    var httpMethod = httpContext.Request.RequestContext.HttpContext.Request.HttpMethod;
                    if (!httpMethod.ToUpper().Equals("GET"))
                        return true;
                    var datosRequest = httpContext.Request.RequestContext.RouteData;
                    var actualControlador = datosRequest.GetRequiredString("controller");
                    var actualAccion = datosRequest.GetRequiredString("action");
                    if (recursosPorRol != null)
                    {
                        var result = recursosPorRol.Where(rp => rp.Controlador.ToUpper().Equals(actualControlador.ToUpper()) && rp.Accion.ToUpper().Equals(actualAccion.ToUpper())).SingleOrDefault();
                        if (result != null)
                            autorizado = true;
                    }
                }
            }
            return autorizado;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["UsuarioSession"] != null)
            {
                var datosUsuario = DesEncriptar(System.Web.HttpContext.Current.Session["UsuarioSession"].ToString());
                var usuario = JsonConvert.DeserializeObject<UsuarioSessionModel>(datosUsuario);
                if (usuario != null)
                {
                    if (usuario.PrimerAcceso)
                    {
                        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                        {
                            { "action", "CambiarClave" },
                            { "controller", "AdminUsuarios" }
                        });
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                        {
                            { "action", "MostrarAccesoDenegado" },
                            { "controller", "Home" }
                        });
                    }
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                    {
                        { "action", "MostrarAccesoDenegado" },
                        { "controller", "Home" }
                    });
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    { "action", "MostrarAccesoDenegado" },
                    { "controller", "Home" }
                });
            }
        }
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