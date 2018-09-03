using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SG_SST.Models.Organizacion;
using SG_SST.Services.Organizacion.IServices;
using SG_SST.Services.Organizacion.Services;
using System.IO;
using SG_SST.Models;
using System.Data.Entity;
using SG_SST.Controllers.Base;

using SG_SST.EntidadesDominio.Aplicacion;
using SG_SST.ServiceRequest;
using SG_SST.Services.Empresas.IServices;
using SG_SST.Services.Empresas.Services;
using SG_SST.Models.Aplicacion;
using SG_SST.Audotoria;
using Rotativa.Options;
using System.Configuration;

using System.Web.UI.WebControls.WebParts;
using System.Web.Management;
using SG_SST.Helpers;

//System.Web.UI.WebControls.FileUpload



namespace SG_SST.Controllers.Aplicacion
{
    [GestionAutorizacion]
    public class OrganizacionController : BaseController
    {

        DocumentacionServicios gs;/// Defino variable gs
        private SG_SSTContext db = new SG_SSTContext();

        string rutaDocumentacionArchivos = ConfigurationManager.AppSettings["rutaDocumentacionArchivos"];
        string rutaRepositorioFile = ConfigurationManager.AppSettings["rutaRepositorioFile"];
        string rutaMOrganizacion = ConfigurationManager.AppSettings["rutaMOrganizacion"];
        string rutaODocumentacion = ConfigurationManager.AppSettings["rutaODocumentacion"];
        

        // GET: Organizacion
        public ActionResult Index()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");

            return View(db.Tbl_Documentacion_Organizacion.ToList());
        }
/// <summary>
/// 
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
 /////////////////////////////////////////////////////////////////////////
        private void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();
            var httpException = ex as HttpException ?? ex.InnerException as HttpException;
            if (httpException == null) return;

            if (httpException.WebEventCode == WebEventCodes.RuntimeErrorPostTooLarge)
            {
                //handle the error
                Response.Write("Sorry, file is too big"); //show this message for instance
            }
        }
        public ActionResult CargarArchivoOrganizacion(Documentacion_Organizacion Doc_Organizacion, HttpPostedFileBase NombreArchivo_Documentacion, int ID_TipoModulo_Organizacion, object source)
        //public ActionResult CargarArchivoOrganizacion(Documentacion_Organizacion Doc_Organizacion, HttpPostedFileBase NombreArchivo_Documentacion, int ID_TipoModulo_Organizacion, object source)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            var path = "";
            Doc_Organizacion.FK_Empresa = usuarioActual.IdEmpresa;
            try
            {
            
                    if (NombreArchivo_Documentacion != null)
                    {
                        if (NombreArchivo_Documentacion.ContentLength > 0)
                        {
                            if (Path.GetExtension(NombreArchivo_Documentacion.FileName).ToLower() == ".pdf" || Path.GetExtension(NombreArchivo_Documentacion.FileName).ToLower() == ".xlsx" || Path.GetExtension(NombreArchivo_Documentacion.FileName).ToLower() == ".docx" || Path.GetExtension(NombreArchivo_Documentacion.FileName).ToLower() == ".xls" || Path.GetExtension(NombreArchivo_Documentacion.FileName).ToLower() == ".doc")
                            {
                                path = rutaRepositorioFile + rutaMOrganizacion + rutaODocumentacion + db.Tbl_TipoModulo_Organizacion.Find(ID_TipoModulo_Organizacion).Descripcion_ModuloOrg +'/'+ usuarioActual.NitEmpresa;
                                if (!Directory.Exists(path))
                                {
                                    System.IO.Directory.CreateDirectory(path);
                                }
                                path = Path.Combine(path, NombreArchivo_Documentacion.FileName);
                                NombreArchivo_Documentacion.SaveAs(path);
                                ViewBag.UploadSuccess = true;
                                Doc_Organizacion.NombreArchivo_Documentacion = NombreArchivo_Documentacion.FileName;
                                Doc_Organizacion.FK_TipoModuloOrganizacion = ID_TipoModulo_Organizacion;
                                Doc_Organizacion.FechaModificacion_Documentacion = DateTime.Now;
                            }
                            else
                            {
                                ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                                ViewBag.Messages1 = "Debe cargar documentos tipo PDF, Excel y Word";

                                return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                            }
                        }

                        gs = new DocumentacionServicios();

                        if (gs.GrabarDocumentacion(Doc_Organizacion) == true)
                        {
                            ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                            ViewBag.Messages2 = "Archivo cargado correctamente";
                            return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                        }
                        else
                        {
                            ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                            ViewBag.Messages1 = "Solo se permiten cargar documentos con formato PDF";
                            return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                        }
                    }

                    else
                    {
                        ViewBag.Messages1 = "Debe cargar un archivo";
                        ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                        return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                    }
               
               
            }
            catch (Exception)
            {
                ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                ViewBag.Messages1 = "Debe cargar un archivo con peso menor a 4 MG!";
                return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                throw;
            }
        }

        public ActionResult MostrarArchivosVPbusqueda()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }        
            List<Documentacion_Organizacion> ListDocum = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();
            return PartialView("EmpresaVP", ListDocum);
        }

        public ActionResult MostrarArchivosVPEmpresa(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("EmpresaVP", ListDoc);

        }

        public ActionResult MostrarArchivosVPLiderazgo(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("LiderazgoGerencialVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPPolitica(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("PoliticaVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPOrganizacion(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("OrganizacionVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPPlanificacion(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("PlanificacionVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPAplicacion(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("AplicacionVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPReporteInvestigacion(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("Reporte_E_InvestigacionVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPMedicionEvaluacion(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("Medicion_Y_EvaluacionVP", ListDoc);
        }

        public ActionResult MostrarArchivosVPParticipacionColaboradores(string Busqueda)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListDoc = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();

            return PartialView("Participacion_ColaboradoresVP", ListDoc);
        }
        
        public ActionResult MostrarOrganizacion_Documentacion(int ID_Documentacion_Org)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            List<Documentacion_Organizacion> ListOtrasInteracciones = db.Tbl_Documentacion_Organizacion.Where(p => p.FK_Empresa == usuarioActual.IdEmpresa).ToList();
            if (ListOtrasInteracciones.Count() > 0)
            {
                if (ListOtrasInteracciones.FirstOrDefault().NombreArchivo_Documentacion != null && ListOtrasInteracciones.FirstOrDefault().NombreArchivo_Documentacion != "")
                {
                    ViewBag.FK_Empresa = usuarioActual.IdEmpresa;
                    ViewBag.ID_Documentacion_Org = ID_Documentacion_Org;

                    return View();
                }


            }

            return View("Index");
        }

        [AllowAnonymous]
        public FileStreamResult Organizacion_DocumentacionPDF(int ID_Documentacion_Org)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
            }
            Documentacion_Organizacion ListOtrasInteracciones = db.Tbl_Documentacion_Organizacion.Find(ID_Documentacion_Org);
            var path = rutaRepositorioFile + rutaMOrganizacion + rutaODocumentacion + db.Tbl_TipoModulo_Organizacion.Find(ListOtrasInteracciones.FK_TipoModuloOrganizacion).Descripcion_ModuloOrg + '/' + usuarioActual.NitEmpresa;
            var file = ListOtrasInteracciones.NombreArchivo_Documentacion;
            var fullPath = Path.Combine(path, file);
            FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
            return File(fs, "application/pdf");
        }

        [AllowAnonymous]
        public ActionResult EliminarArchivoDocumetacion(int PKdArchivo)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new DocumentacionServicios();

            Documentacion_Organizacion ListOtrasInteracciones = db.Tbl_Documentacion_Organizacion.Find(PKdArchivo);
            var path = rutaRepositorioFile + rutaMOrganizacion + rutaODocumentacion + db.Tbl_TipoModulo_Organizacion.Find(ListOtrasInteracciones.FK_TipoModuloOrganizacion).Descripcion_ModuloOrg + '/' + usuarioActual.NitEmpresa;
            bool restpuestaGuardado = gs.Eliminar_DocumentacionArchivo(PKdArchivo);

            path = Path.Combine(path, ListOtrasInteracciones.NombreArchivo_Documentacion);
            if (System.IO.File.Exists(@path))
            {
                try
                {
                    System.IO.File.Delete(@path);
                    ViewBag.Messages2 = "Archivo eliminado correctamente";
                    ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                    return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                }
                catch (System.IO.IOException e)
                {
                    ViewBag.Messages2 = "No fue  posible eliminar el archivo " + ListOtrasInteracciones.NombreArchivo_Documentacion + "en la ruta " + path;
                    ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");
                    return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
                }

            }           
            
            ViewBag.ID_TipoModulo_Organizacion = new SelectList(db.Tbl_TipoModulo_Organizacion, "ID_TipoModulo_Organizacion", "Descripcion_ModuloOrg");                 
            return View("Index", db.Tbl_Documentacion_Organizacion.ToList());
        }

        [AllowAnonymous]
        public ActionResult EliminarArchivoDocumetacionController(int PKdArchivo)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }
            gs = new DocumentacionServicios();

            gs.Eliminar_DocumentacionArchivo(PKdArchivo);
            ViewBag.Messages2 = "Archivo eliminado satisfactoriamente";

            return RedirectToAction("Index");


        }

        [AllowAnonymous]
        public ActionResult DescargaDocumentacion(int idArchivoDocumentacion)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Módulo.";
                return RedirectToAction("Login", "Home");
            }


            string doc = null;
            using (SG_SSTContext context = new SG_SSTContext())
            {                
                doc = context.Tbl_Documentacion_Organizacion.Find(idArchivoDocumentacion).NombreArchivo_Documentacion;
            }
            Documentacion_Organizacion ListOtrasInteracciones = db.Tbl_Documentacion_Organizacion.Find(idArchivoDocumentacion);
            var path = rutaRepositorioFile + rutaMOrganizacion + rutaODocumentacion + db.Tbl_TipoModulo_Organizacion.Find(ListOtrasInteracciones.FK_TipoModuloOrganizacion).Descripcion_ModuloOrg + '/' + usuarioActual.NitEmpresa;
            var file = doc;
            var fullPath = Path.Combine(path, file);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            MemoryStream ms = new MemoryStream(fileBytes, 0, 0, true, true);
            Response.AddHeader("content-disposition", "attachment;filename=" + doc + "");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();
            if (Path.GetExtension(doc).ToLower() == ".pdf")
            {
                return new FileStreamResult(Response.OutputStream, "application/pdf");
            }
            else if (Path.GetExtension(doc).ToLower() == ".png")
            {
                return new FileStreamResult(Response.OutputStream, "application/png");
            }
            else if (Path.GetExtension(doc).ToLower() == ".jpg")
            {
                return new FileStreamResult(Response.OutputStream, "application/jpg");
            }
            else if (Path.GetExtension(doc).ToLower() == ".doc")
            {
                return new FileStreamResult(Response.OutputStream, "application/doc");
            }
            else if (Path.GetExtension(doc).ToLower() == ".docx")
            {
                return new FileStreamResult(Response.OutputStream, "application/docx");
            }
            else if (Path.GetExtension(doc).ToLower() == ".ppt")
            {
                return new FileStreamResult(Response.OutputStream, "application/doc");
            }
            else if (Path.GetExtension(doc).ToLower() == ".pptx")
            {
                return new FileStreamResult(Response.OutputStream, "application/docx");
            }
            else
            {
                return new FileStreamResult(Response.OutputStream, "application/vnd.ms-excel");
            }

        }
    }
}
