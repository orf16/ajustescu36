using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SG_SST.Models;
using System.Data.Entity;
using SG_SST.Services.Empresas.IServices;
using SG_SST.Services.Empresas.Services;
using SG_SST.Controllers.Base;
using SG_SST.Audotoria;
using System.Configuration;
using SG_SST.Helpers;
using SG_SST.EntidadesDominio.Auditoria;
using SG_SST.Repositorio.AuditoriaSistema;

namespace SG_SST.Controllers.Empresas
{
    [GestionAutorizacion]
    public class OrganigramaController : BaseController
    {
        private SG_SSTContext db = new SG_SSTContext();
        private IEmpresaServicios EmpresaServicios = new EmpresaServicios();
        string rutaRepositorioFile = ConfigurationManager.AppSettings["rutaRepositorioFile"];
        string rutaMEmpresa = ConfigurationManager.AppSettings["rutaMEmpresa"];
        string rutaOGobiernoOrganizacional = ConfigurationManager.AppSettings["rutaOGobiernoOrganizacional"];
        string rutaOOrganigrama = ConfigurationManager.AppSettings["rutaOOrganigrama"];
        AuditoriaSistemaManager auditoriaSistema = new AuditoriaSistemaManager();
        // GET: Organigrama
        [AllowAnonymous]
        public ActionResult Index()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            int pkorganigrama = 0;
            string NombreOrganigrama = "";
            bool respuesta = false;

            try
            {

                Organigrama ime = db.Tbl_Organigrama.FirstOrDefault(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa && o.Imagen_Organigrama != null);
                if (ime != null)
                {
                    if (Path.GetExtension(ime.Imagen_Organigrama).ToLower() == ".pdf")
                    {
                        respuesta = true;
                    }
                    pkorganigrama = ime.Pk_Id_Organigrama;
                    NombreOrganigrama = ime.Imagen_Organigrama;
                }

            }
            catch
            {
                return View();

            }
            ViewBag.NombreOrganigrama = NombreOrganigrama;
            ViewBag.pkorganigrama = pkorganigrama;
            ViewBag.espdf = respuesta;
            return View();
        }




        // GET: Organigrama/Details/5
        public ActionResult Details(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // GET: Organigrama/Create
        public ActionResult Create()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: Organigrama/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organigrama/Edit/5
        public ActionResult Edit(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: Organigrama/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organigrama/Delete/5
        public ActionResult Delete(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: Organigrama/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]

        //Metodo para Cargar Archivo Organigrama
        public ActionResult CreateO(HttpPostedFileBase CargarImagen, string ipUsuario)
        {
            int sw = 0;
            var pkorganigrama = 0;
            string NombreOrganigrama = "";
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            EmpresaServicios = new EmpresaServicios(db);

            var path = "";
            ViewBag.espdf = false;

            try
            {
                Organigrama organigrama = db.Tbl_Organigrama.Find(usuarioActual.IdEmpresa);


                if (CargarImagen != null
                    && (Path.GetExtension(CargarImagen.FileName).ToLower() == ".jpg"
                    || Path.GetExtension(CargarImagen.FileName).ToLower() == ".png"
                    || Path.GetExtension(CargarImagen.FileName).ToLower() == ".pdf")
                    && CargarImagen.ContentLength <= (6 * 1024 * 1024))
                {

                    if (Path.GetExtension(CargarImagen.FileName).ToLower() == ".pdf")
                    {
                        ViewBag.espdf = true;
                    }
                    Organigrama ime = db.Tbl_Organigrama.First(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa);
                    EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
                    {
                        IdentificacionUsuario = usuarioActual.Documento,
                        NombreUsuario = usuarioActual.NombreUsuario,
                        NitEmpresa = usuarioActual.NitEmpresa,
                        NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                        IpUsuario = ipUsuario
                    };
                    /*inicio auditoria*/
                    if (db.Tbl_ActivaAuditoriaSistema.ToList().FirstOrDefault().EsActivaEmpresa)
                    {                       
                        db.Tbl_AuditoriaEmpresaSistema.Add(auditoriaSistema.ObtenerAuditoriaEmpresa(edInfoauditoria,
                             Enumeraciones.EnumAuditoriaSistema.Acciones.MODIFICACION,
                             Enumeraciones.EnumAuditoriaSistema.Modulos.Empresa,
                             Enumeraciones.EnumAuditoriaSistema.SubModulos.Gobierno_organizacional,
                             Enumeraciones.EnumAuditoriaSistema.Opciones.Organigrama,
                             ime.ToString()));
                    }
                    /*fin auditoria*/
                    if (ime == null || ime.Imagen_Organigrama == null)
                    {

                        path = rutaRepositorioFile + rutaMEmpresa + rutaOGobiernoOrganizacional + rutaOOrganigrama + usuarioActual.NitEmpresa;
                        if (!Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, CargarImagen.FileName);
                        ime.Imagen_Organigrama = CargarImagen.FileName;
                        ime.Descripcion_Organigrama = "Organigrama: " + usuarioActual.RazonSocialEmpresa;
                        CargarImagen.SaveAs(path);
                        NombreOrganigrama = ime.Imagen_Organigrama;
                        pkorganigrama = ime.Pk_Id_Organigrama;
                        sw = pkorganigrama;
                        db.SaveChanges();
                        ViewBag.mensaje = "Archivo Almacenado Correctamente.!";
                    }
                    else
                    {

                        path = rutaRepositorioFile + rutaMEmpresa + rutaOGobiernoOrganizacional + rutaOOrganigrama + usuarioActual.NitEmpresa;
                        var file = ime.Imagen_Organigrama;
                        var fullPath = Path.Combine(path, file);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);

                        }
                        if (!Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, CargarImagen.FileName);
                        CargarImagen.SaveAs(path);
                        ime.Imagen_Organigrama = CargarImagen.FileName;
                        ime.Descripcion_Organigrama = "Organigrama: " + usuarioActual.RazonSocialEmpresa;
                        db.Entry(ime).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        NombreOrganigrama = ime.Imagen_Organigrama;
                        pkorganigrama = ime.Pk_Id_Organigrama;
                        sw = pkorganigrama;
                        ViewBag.mensaje = "Archivo  almacenado correctamente.!";
                    }
                }
                else
                {

                    Organigrama ime = db.Tbl_Organigrama.FirstOrDefault(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa && o.Imagen_Organigrama != null);
                    if (ime != null)
                    {
                        if (Path.GetExtension(ime.Imagen_Organigrama).ToLower() == ".pdf")
                        {
                            ViewBag.espdf = true;
                        }
                        NombreOrganigrama = ime.Imagen_Organigrama;
                    }
                    ViewBag.pkidempresa = usuarioActual.IdEmpresa;

                    //ViewBag.mensaje1 = "No cargaste ningun archivo, o el archivo supera el maximo permitido que son 6 megabytes, y solo se pueden cargar archivos .PDF, .JPG o .PNG.!";
                    ViewBag.mensaje3 = true;
                }
            }
            catch (Exception e)
            {
                //ViewBag.mensaje1 = "No se pudo realizar la transaccion, Primero debe Registrar los Cargos.";
                ViewBag.mensaje4 = true;
            }
            if (sw != null)
            {
                ViewBag.pkorgranigrama = sw;
                //ViewBag.NombreOrganigrama = NombreOrganigrama;
            }
            ViewBag.NombreOrganigrama = NombreOrganigrama;
            ViewBag.Entro = 1;
            return View("Index", ViewBag.pkorgranigrama);
        }

        //Metodo para Eliminar Archivo Cargado de Organigrama del Servidor.
        public ActionResult Eliminar(int pkorganigrama)
        {
            bool sw = false;
            bool respuesta = false;
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            Organigrama ime = db.Tbl_Organigrama.FirstOrDefault(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa
                && o.Imagen_Organigrama != null
                && o.Pk_Id_Organigrama == pkorganigrama);
            if (ime != null)
            {
                var path = rutaRepositorioFile + rutaMEmpresa + rutaOGobiernoOrganizacional + rutaOOrganigrama + usuarioActual.NitEmpresa;
                var file = ime.Imagen_Organigrama;
                var fullPath = Path.Combine(path, file);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                    sw = true;
                    ime.Imagen_Organigrama = "";
                    ime.Descripcion_Organigrama = "";
                    db.SaveChanges();
                }
            }


            respuesta = true;
            ViewBag.espdf = respuesta;
            //pkorganigrama = ime.Pk_Id_Organigrama;
            return View("Index");
        }


        [AllowAnonymous]
        //Metodo para  Visualizar Imagen de organigrama Cargado.
        public ActionResult GetImagen()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }

            try
            {
                int pkidempresa = usuarioActual.IdEmpresa;

                Organigrama ime = db.Tbl_Organigrama.FirstOrDefault(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa && o.Imagen_Organigrama != null);
                if (ime != null)
                {
                    string nombreFirma = ime.Imagen_Organigrama;
                    var path = rutaRepositorioFile + rutaMEmpresa + rutaOGobiernoOrganizacional + rutaOOrganigrama + usuarioActual.NitEmpresa;
                    var file = nombreFirma;
                    var fullPath = Path.Combine(path, file);
                    return File(fullPath, "image/jpg", file);
                }
            }
            catch (Exception e)
            {
                Organigrama ime = db.Tbl_Organigrama.FirstOrDefault(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa && o.Imagen_Organigrama != null);
                string nombreFirma = ime.Imagen_Organigrama;
                var path = rutaRepositorioFile + rutaMEmpresa + rutaOGobiernoOrganizacional + rutaOOrganigrama + usuarioActual.NitEmpresa;
                var file = nombreFirma;
                var fullPath = Path.Combine(path, file);
                return File(fullPath, "image/pdf", file);
            }
            return null;

        }//fin metodo obtener imagen de organigrama.

        //obtener el nombre del pdf
        [HttpGet]
        [AllowAnonymous]
        public ActionResult OrganigramaPdfMod()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje1 = "El usuario no ha iniciado sesión el sistema";
                return View("Login", "Home");
            }
            string [] Archivo = new string[2];
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    //Archivo = db.CondicionInsegura.Find(clavecondicion).Evidencia;
                    Organigrama ime = db.Tbl_Organigrama.FirstOrDefault(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa && o.Imagen_Organigrama != null);
                    Archivo [1] = ime.Imagen_Organigrama;
                    Archivo[0] = usuarioActual.NitEmpresa;
                }
                catch (Exception)
                {
                    transaction.Rollback();

                }
            }
            return Json(Archivo, JsonRequestBehavior.AllowGet);

        }

        //Metodo para Ver Organigrama cargado en PDF.
        [AllowAnonymous]
        public FileStreamResult OrganigramaPdf()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                //return RedirectToAction("Login", "Home");
            }
            Organigrama imo = db.Tbl_Organigrama.First(o => o.Fk_Id_Empresa == usuarioActual.IdEmpresa && o.Imagen_Organigrama != null);
            if (imo == null)
            {
                ViewBag.Mensaje = "No hay Archivo Cargado";
            }

            var path = rutaRepositorioFile + rutaMEmpresa + rutaOGobiernoOrganizacional + rutaOOrganigrama + usuarioActual.NitEmpresa;
            var file = imo.Imagen_Organigrama;
            var fullPath = Path.Combine(path, file);
            FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            if (fs == null)
            {
                fs.Dispose();
            }
            return File(fs, "application/pdf");
        }
    }
}








