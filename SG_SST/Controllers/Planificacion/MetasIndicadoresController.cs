using SG_SST.Controllers.Base;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Models.Planificacion;
using SG_SST.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Controllers.Planificacion
{
    public class MetasIndicadoresController : BaseController
    {
        string UrlServicioPlanificacion = ConfigurationManager.AppSettings["UrlServicioPlanificacion"];

        string capaObtenerIndicadoresTipo = ConfigurationManager.AppSettings["ObtenerIndicadoresTipo"];
        string capaObtenerIndicadorId = ConfigurationManager.AppSettings["ObtenerIndicadorId"];
        string capaObtenerMetasIndicadoresEmpresa = ConfigurationManager.AppSettings["ObtenerMetasIndicadoresEmpresa"];
        string capaObtenerMetaIndicadorId = ConfigurationManager.AppSettings["ObtenerMetaIndicadorId"];
        string capaGuardarMetaIndicador = ConfigurationManager.AppSettings["GuardarMetaIndicador"];
        string capaModificarMetaIndicador = ConfigurationManager.AppSettings["ModificarMetaIndicador"];
        string capaEliminarMetaIndicador = ConfigurationManager.AppSettings["EliminarMetaIndicador"];



        // GET: MetasIndicadores
        public ActionResult MetasIndicadores()
        {
            var metas = new MetasIndicadoresModel();
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "Debe estar autenticado para ingresar a este módulo.";
                return RedirectToAction("Login", "Home");
            }
            metas.FKEmpresa = usuarioActual.IdEmpresa;
            List<SelectListItem> tipos = new List<SelectListItem>();
            SelectListItem sli;
            sli = new SelectListItem();
            sli.Value = "Estructura";
            sli.Text = "Estructura";
            tipos.Add(sli);
            sli = new SelectListItem();
            sli.Value = "Proceso";
            sli.Text = "Proceso";
            tipos.Add(sli); 
            sli = new SelectListItem();
            sli.Value = "Resultado";
            sli.Text = "Resultado";
            tipos.Add(sli);
            metas.TiposIndicadores = tipos;

            return View(metas);
        }


        public ActionResult ObtenerIndicadores(string tipo)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("tipo", tipo);
                var indicadores = ServiceClient.ObtenerArrayJsonRestFul<EDIndicador>(UrlServicioPlanificacion, capaObtenerIndicadoresTipo, RestSharp.Method.GET);
                if (indicadores != null || indicadores[0] != null)
                {
                    return Json(new { Data = indicadores, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ObtenerIndicador(string id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("IdIndicador", id);
                var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDIndicador>(UrlServicioPlanificacion, capaObtenerIndicadorId, RestSharp.Method.GET);
                if (indicador != null)
                {
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GuardarMetaIndicador(EDMetaIndicador metaNueva)
        {
            bool esNuevo = false;
            bool sonNumeros = false;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    metaNueva.ValorRojoString = metaNueva.ValorRojoString.Replace(".", ",");
                    metaNueva.ValorAmarilloString = metaNueva.ValorAmarilloString.Replace(".", ",");
                    metaNueva.ValorVerdeString = metaNueva.ValorVerdeString.Replace(".", ",");
                    metaNueva.ValorMetaString = metaNueva.ValorMetaString.Replace(".", ",");
                    metaNueva.ValorRojo = decimal.Parse(metaNueva.ValorRojoString);
                    metaNueva.ValorAmarillo = decimal.Parse(metaNueva.ValorAmarilloString);
                    metaNueva.ValorVerde = decimal.Parse(metaNueva.ValorVerdeString);
                    metaNueva.ValorMeta = decimal.Parse(metaNueva.ValorMetaString);
                    sonNumeros = true;
                }
                catch (Exception e)
                {
                    sonNumeros = false;
                }
                if (sonNumeros)
                {
                    ServiceClient.EliminarParametros();
                    ServiceClient.AdicionarParametro("id", usuarioActual.IdEmpresa);
                    var metas = ServiceClient.ObtenerArrayJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, capaObtenerMetasIndicadoresEmpresa, RestSharp.Method.GET);
                    if (metas != null || metas[0] != null)
                    {
                        var m = (from act in metas
                                 where act.FK_Indicador == metaNueva.FK_Indicador
                                 select act).FirstOrDefault();
                        if (m != null && m != default(EDMetaIndicador))
                        {
                            esNuevo = false;
                        }
                        else
                        {
                            esNuevo = true;
                        }
                    }
                    else
                    {
                        esNuevo = true;
                    }
                    if (esNuevo)
                    {
                        ServiceClient.EliminarParametros();
                        var result = ServiceClient.RealizarPeticionesPostJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, capaGuardarMetaIndicador, metaNueva);
                        if (result != null)
                        {
                            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { Data = string.Empty, Mensaje = "ERRORYAAGREGADO" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERRORNUMEROS" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ObtenerMetasIndicadoresEmpresa(string id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("id", id);
                var metas = ServiceClient.ObtenerArrayJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, capaObtenerMetasIndicadoresEmpresa, RestSharp.Method.GET);
                if (metas != null || metas[0] != null)
                {
                    return Json(new { Data = metas, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ObtenerMetaIndicador(string id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("id", id);
                var indicador = ServiceClient.ObtenerObjetoJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, capaObtenerMetaIndicadorId, RestSharp.Method.GET);
                if (indicador != null)
                {
                    return Json(new { Data = indicador, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ModificarMetaIndicador(EDMetaIndicador metaModificada)
        {
            bool sonNumeros = false;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    metaModificada.ValorRojoString = metaModificada.ValorRojoString.Replace(".", ",");
                    metaModificada.ValorAmarilloString = metaModificada.ValorAmarilloString.Replace(".", ",");
                    metaModificada.ValorVerdeString = metaModificada.ValorVerdeString.Replace(".", ",");
                    metaModificada.ValorMetaString = metaModificada.ValorMetaString.Replace(".", ",");
                    metaModificada.ValorRojo = decimal.Parse(metaModificada.ValorRojoString);
                    metaModificada.ValorAmarillo = decimal.Parse(metaModificada.ValorAmarilloString);
                    metaModificada.ValorVerde = decimal.Parse(metaModificada.ValorVerdeString);
                    metaModificada.ValorMeta = decimal.Parse(metaModificada.ValorMetaString);
                    sonNumeros = true;
                }
                catch (Exception e)
                {
                    sonNumeros = false;
                }
                if (sonNumeros)
                {
                    ServiceClient.EliminarParametros();
                    var result = ServiceClient.RealizarPeticionesPostJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, capaModificarMetaIndicador, metaModificada);
                    if (result != null)
                    {
                        return Json(new { Data = result, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERRORNUMEROS" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EliminarMetaIndicador(int idMetaIndicador, int idEmpresa)
        {

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                ServiceClient.EliminarParametros();
                ServiceClient.AdicionarParametro("IdMetaInd", idMetaIndicador);
                ServiceClient.AdicionarParametro("IdEmpresa", idEmpresa);
                var result = ServiceClient.ObtenerArrayJsonRestFul<EDMetaIndicador>(UrlServicioPlanificacion, capaEliminarMetaIndicador, RestSharp.Method.GET);
                if (result != null || result[0] != null)
                {
                    return Json(new { Data = result, Mensaje = "OK" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { Data = string.Empty, Mensaje = "ERROR" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}