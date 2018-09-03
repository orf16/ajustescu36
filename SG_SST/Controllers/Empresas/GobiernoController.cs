// <copyright file="GobiernoController.cs" company="Ada SA">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Robinson Correa</author>
// <date>03/01/2017</date>
// <summary>Controlador que gestiona la mision de la empresa</summary>
namespace SG_SST.Controllers.Empresas
{
    using SG_SST.Models.Empresas;
    using SG_SST.Services.Empresas.IServices;
    using SG_SST.Services.Empresas.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.IO;
    using SG_SST.Models;
    using SG_SST.Controllers.Base;
    using SG_SST.Helpers;
    using SG_SST.EntidadesDominio.Auditoria;

    [GestionAutorizacion]
    public class GobiernoController : BaseController
    {
        IGobiernoServicios gs;/// Defino variable gs
       
        private SG_SSTContext db = new SG_SSTContext();


        // GET: Gobierno
        public ActionResult Index()//index de gobierno
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult misionM()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.texto = "mision";
            return View("misionM");
        }

        public ActionResult visionV()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            return View("visionV");
        }

        public ActionResult Gobierno(Gobierno gobierno, string ipUsuario)
        {

            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            gs.GrabarGobierno(gobierno, usuarioActual.IdEmpresa, edInfoauditoria);
            return RedirectToAction("misionM");
        }


        //metodo que recibe el submit de la vista
        public ActionResult Mision(string mision, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            bool respuesta = gs.GrabarMision(mision, usuarioActual.IdEmpresa, edInfoauditoria);
            if (respuesta)
            {
                // se grabo mision con exito 
                ViewBag.Messages2= true;
                return View("misionM");
            }
            else
            {
                ViewBag.Message = false;
                return View("misionM");
            }
        }
        public ActionResult Gobiernov(Gobierno gobiernov, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            var NitEmpres = Convert.ToInt32(usuarioActual.NitEmpresa);
            gs.GrabarGobiernoV(gobiernov, usuarioActual.IdEmpresa, NitEmpres, edInfoauditoria);
            return RedirectToAction("visionV");
        }

        public ActionResult Vision(string vision,string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            var NitEmpres = Convert.ToInt32(usuarioActual.NitEmpresa);
            bool respuesta = gs.GrabarVision(vision, usuarioActual.IdEmpresa, NitEmpres,edInfoauditoria);
            if (respuesta)
            {
                //ViewBag.Message = "Visión Almacenada Exitosamente.!";
                ViewBag.Messages3 = true;
                return View("visionV");
            }
            else
            {
                
                return View("visionV");
            }
        }
        //Metodo para Cargar la mision en el Modal de registro
        public ActionResult CargarMision()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            string mision = gs.ObtenerMision(usuarioActual.IdEmpresa);
            if (mision != "")
            {
                return Json(new { success = true, Mision = mision }
                , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        //Metodo para Cargar la vision en el Modal de registro
        public ActionResult CargarVision()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            string vision = gs.ObtenerVision(usuarioActual.IdEmpresa);
            if (vision != "")
            {
                return Json(new { success = true, Vision = vision }
                , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
          

       //Metodo para Eliminar la mision
        [AllowAnonymous]
        public ActionResult EliminarMision(string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            ViewBag.mensaje = gs.EliminarMision(usuarioActual.IdEmpresa, edInfoauditoria);
            ViewBag.mensaje="Se ha eliminado la Mision.";
            //ViewBag.Messages4 = true;
            return View("misionM");
           
        }

        [AllowAnonymous]
        public ActionResult EliminarVision(string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new GobiernoServicios();
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            ViewBag.mensaje = gs.EliminarVision(usuarioActual.IdEmpresa, edInfoauditoria);
            ViewBag.mensaje = "Se ha eliminado la Vision.";
            //ViewBag.Messages5 = true;
            return View("visionV");
        }

    }



}