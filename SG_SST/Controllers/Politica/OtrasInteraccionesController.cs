﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SG_SST.Models.Politica;
using SG_SST.Services.Politica.IServices;
using SG_SST.Services.Politica.Services;
using System.IO;
using SG_SST.Models;
using SG_SST.Controllers.Base;
using System.Configuration;
using SG_SST.Helpers;

namespace SG_SST.Controllers.Politica
{
    [GestionAutorizacion]
    public class OtrasInteraccionesController : BaseController
    {


        IpoliticaServicios gs;/// Defino variable gs
        private SG_SSTContext db = new SG_SSTContext();
        string rutaRepositorioFile = ConfigurationManager.AppSettings["rutaRepositorioFile"];
        string rutaMpolitica = ConfigurationManager.AppSettings["rutaMPolitica"];
        string rutaOIntenciones = ConfigurationManager.AppSettings["rutaOIntenciones"];
        // GET: Cont_OtrasInteracciones

        /// <summary>
        /// CONTROLADOR QUE MANEJA EL MODULO OTRAS INTERACIONES Y DIRECTICES-POLITICA
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult Index()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            List<Mod_OtrasInteracciones> objlist = db.Tbl_OtrasInteracciones.Where(g => g.FK_Empresa == usuarioActual.IdEmpresa).ToList();
             return View(objlist);//lista para mostrar los archivos cargados
        }


        [HttpGet]
        public ActionResult ValorCheckBox(FormCollection collection)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            var showAll = collection["showAll"];
            TempData["showAll"] = showAll;

            if (showAll == "on")
            {
                ViewBag.Messages = "seleccionó el checked";
            }
            return View();
        }




        public ActionResult CargarArchivoOtrasInteracciones(int nit)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            List<Mod_OtrasInteracciones> Interacciones = db.Tbl_OtrasInteracciones.Where(p => p.Nit_Empresa == nit).ToList();
            if (Interacciones.Count() > 60)
            {


                ViewBag.Messages = "Solo se permiten cargar documentos en formato PDF";
                return View("MenuPolitica", db.Tbl_OtrasInteracciones.ToList());
            }
            else
            {
                return View("Index");               

            }

        }

        public ActionResult CargarArchivoOtrasInt(Mod_OtrasInteracciones OtrasInteracciones, HttpPostedFileBase ArchivoOtrasInteracciones)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            var path = "";

            OtrasInteracciones.FK_Empresa = usuarioActual.IdEmpresa;

            if (ArchivoOtrasInteracciones != null)
            {

                if (ArchivoOtrasInteracciones.ContentLength > 0)
                {
                    if (Path.GetExtension(ArchivoOtrasInteracciones.FileName).ToLower() == ".pdf")
                    {
                        path = rutaRepositorioFile + rutaMpolitica + rutaOIntenciones + usuarioActual.NitEmpresa;
                        if (!Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, ArchivoOtrasInteracciones.FileName);
                        ArchivoOtrasInteracciones.SaveAs(path);
                        ViewBag.UploadSuccess = true;
                        OtrasInteracciones.Archivo_OtrasInteracciones = ArchivoOtrasInteracciones.FileName;
                    }
                }

                gs = new PoliticaServicios();

                if (gs.GrabarOtrasInteracciones(OtrasInteracciones) == true)
                {

                    ViewBag.Messages2 = "Documento cargado correctamente";
                    List<Mod_OtrasInteracciones> objlist = db.Tbl_OtrasInteracciones.Where(g => g.FK_Empresa == usuarioActual.IdEmpresa).ToList();

                    return View("Index", objlist);//lista para mostrar los archivos cargado
                }
                else
                {
                    ViewBag.Messages1 = "Solo se permiten cargar documentos en formato PDF";
                    List<Mod_OtrasInteracciones> objlist = db.Tbl_OtrasInteracciones.Where(g => g.FK_Empresa == usuarioActual.IdEmpresa).ToList();

                    return View("Index", objlist);//lista para mostrar los archivos cargado
                }
            }
            else
            {
                ViewBag.Messages1 = "No ha seleccionado un documento para cargar";


                List<Mod_OtrasInteracciones> objlist = db.Tbl_OtrasInteracciones.Where(g => g.FK_Empresa == usuarioActual.IdEmpresa).ToList();

                return View("Index", objlist);//lista para mostrar los archivos cargados



            }

        }


        



        /// <summary>
        /// controlador que maneja el cargue de archivos otras interacciones y directrices
        /// </summary>
        /// <returns></returns>
        public ActionResult CargarOtrasInteracciones()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View(db.Tbl_OtrasInteracciones.ToList());//se muestra la lista de archivos
        }





        /// <summary>
        /// metodo para eliminar los archivos desde la tabla - uno por uno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EliminarArchivoOtrasInteracciones_tabla(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            gs = new PoliticaServicios();

            gs.EliminarOtrasInteracciones(id);

            return RedirectToAction("Index");

        }



        /// <summary>
        /// metodo para eliminar los archivos seleccionados con el checkbox - ajax jquery - llama al metodo: EliminararchivoOtrasInteracciones_servidor, para eliminar fisicamente los archivos q se encuentran en la carpeta del servidor
        /// </summary>
        /// <param name="customerIDs"></param>
        /// <returns></returns>
        public ActionResult EliminarArchivoOtrasInteracciones(Int32[] customerIDs)
        {         
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }

            try
            {
                foreach (Int32 customerID in customerIDs)
                {
                    Mod_OtrasInteracciones mod_OtrasInteracciones = db.Tbl_OtrasInteracciones.Find(customerID);
                    db.Tbl_OtrasInteracciones.Remove(mod_OtrasInteracciones);

                    EliminararchivoOtrasInteracciones_servidor(customerID);               

                }
                db.SaveChanges();
                
                return Json(new { success = true }
                    , JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                ViewBag.Messages = "Error";
                return RedirectToAction("Index");
            }


        }


        /// <summary>
        /// metodo para poner como documento privado desde la tabla
        /// </summary>
        /// <param name="otrasInteracciones"></param>
        /// <returns></returns>
        public ActionResult DocumentoPrivado(Mod_OtrasInteracciones otrasInteracciones)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            gs = new PoliticaServicios();
            gs.ModificarDocumentoPrivado(otrasInteracciones.ID_OtrasInteraciones);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// metodo para poner como documento privado los archivos desde script js
        /// </summary>
        /// <param name="customerIDs"></param>
        /// <param name="otrasInteracciones"></param>
        /// <returns></returns>
        public ActionResult DocumentoPrivado_script(Int32[] customerIDs, Mod_OtrasInteracciones otrasInteracciones)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }

            try
            {
                foreach (Int32 customerID in customerIDs)
                {
                    gs = new PoliticaServicios();
                    gs.ModificarDocumentoPrivado(customerID);
                }
                db.SaveChanges();

                //return RedirectToAction("Index");
                return Json(new { success = true }
                    , JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                ViewBag.Messages = "Error";
                return RedirectToAction("Index");

            }

        }



        /// <summary>
        /// Metodo para manejar las acciones de los checkbox en el formulario otras interacciones
        /// </summary>
        /// <returns></returns>
        ///         
        public ActionResult ModificarNombre_ArchivoOtrasIntercciones(int id, string Nombre_Archivo)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            gs = new PoliticaServicios();
            gs.ModificarNombreOtrasInteracciones(id, Nombre_Archivo);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Método utilizado para mostrar el nombre de archivo a editar - en archivo js
        /// </summary>
        /// <param name="nit"></param>
        /// <returns></returns>
        public ActionResult CargarNombreArchivoOtrasInteracciones(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            gs = new PoliticaServicios();
            string interacciones = gs.ObtenerNombreArchivootrasInteracciones(id);
            if (interacciones != "")
            {
                return Json(new { success = true, Interacciones = interacciones }
                , JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);

            }

        }



        /// <summary>
        /// Metodo para manejar las acciones de los checkbox en el formulario otras interacciones
        /// </summary>
        /// <returns></returns>
        public ActionResult AccionesCheckBox()
        {
            //return  ViewBag.Message = "El Checkbox ha sido seleccionado";    
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            string mensajeCheck = "Checkbox seleccionado";

            if (mensajeCheck != "")
            {
                return Json(new { success = true, vistaCheck = mensajeCheck }
                , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult BusquedaArchivo(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            List<Mod_OtrasInteracciones> ListOtrasinteraciones = db.Tbl_OtrasInteracciones.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa && p.Archivo_OtrasInteracciones.Contains(Busqueda)).ToList();

            return PartialView("OtrasInteraccionesVP", ListOtrasinteraciones);

        }

        [AllowAnonymous]
        public FileStreamResult MostrarOtrasInteraccionesPDF(int ID_OtrasInteraciones)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
            }
            string nombreFirma = db.Tbl_OtrasInteracciones.Find(ID_OtrasInteraciones).Archivo_OtrasInteracciones;
            var path = rutaRepositorioFile + rutaMpolitica + rutaOIntenciones + usuarioActual.NitEmpresa;
            var file = nombreFirma;
            var fullPath = Path.Combine(path, file);
            FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");


        }


        /// <summary>
        /// metodo 2 para eliminar fisicamente archivos del servidor - metodo llamado desde: EliminarArchivoOtrasInteracciones()
        /// </summary>
        /// <param name="ID_VID_OtrasInteracciones"></param>
        /// <returns></returns>
        public ActionResult EliminararchivoOtrasInteracciones_servidor(int customerIDs)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión en el sistema";
                return RedirectToAction("Login", "Home");
            }
            Mod_OtrasInteracciones ListOtrasInteracciones = db.Tbl_OtrasInteracciones.Find(customerIDs);
            var path = rutaRepositorioFile + rutaMpolitica + rutaOIntenciones + usuarioActual.NitEmpresa;
            var file = ListOtrasInteracciones.Archivo_OtrasInteracciones;

            path = Path.Combine(path,file);

            if (System.IO.File.Exists(path))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(path);
                    return View("Index");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return View("Index");
                }

            }
            else return View("Index");


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}