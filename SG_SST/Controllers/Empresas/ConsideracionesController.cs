
namespace SG_SST.Controllers.Empresas
{
    using SG_SST.Models;
    using SG_SST.Models.Empresas;
    using SG_SST.Services.Empresas.IServices;
    using SG_SST.Services.Empresas.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    //using Export_word.Models;
    using System.IO;
    using System.Web.UI.WebControls;
    using System.Web.UI;
    using SG_SST.Controllers.Base;
    using SG_SST.Helpers;
    using SG_SST.EntidadesDominio.Auditoria;


    [GestionAutorizacion]
    public class ConsideracionesController : BaseController
    {
        // GET: Consideraciones        
        IMatrizServicios matrizServicios = new MatrizServicios();
        int tipoDOFA = 1;// Clave Primaria del tipo de analisis dofa en la base de datos
        int tipoPEST = 2;

        public ActionResult Index()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        /// <summary>
        /// Retorna la vista del menu para seleccionar si crear o consultar o tipo de analisis DOFA Y PEST
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuAnalisis()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        /// <summary>
        /// Retorna la vista para crear un matriz de analisis DOFA
        /// </summary>
        /// <returns></returns>
        public ActionResult DOFA()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            List<TipoElementoAnalisis> elementosAnalisis = matrizServicios.ObtenerTipoElementosPorAnalissis(tipoDOFA);
            ViewBag.elementosMatriz = new SelectList(elementosAnalisis, "PK_Tipo_Elemneto_Analisis", "Descripcion_Elemento");
            return View(matrizServicios.ObtenerElementosMatriz(tipoDOFA, usuarioActual.NitEmpresa));
        }

        /// <summary>
        /// Retorna la vista para crear un matriz de analisis PEST
        /// </summary>
        /// <returns></returns>
        public ActionResult PEST()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            List<TipoElementoAnalisis> elementosAnalisis = matrizServicios.ObtenerTipoElementosPorAnalissis(tipoPEST);
            ViewBag.elementosMatriz = new SelectList(elementosAnalisis, "PK_Tipo_Elemneto_Analisis", "Descripcion_Elemento");
            return View(matrizServicios.ObtenerElementosMatriz(tipoPEST, usuarioActual.NitEmpresa));
        }

        /// <summary>
        /// Metodo que retonar el elemento agregado o guardado
        /// </summary>
        /// <param name="elementoMatriz">elemento de la matriz a guardar</param>
        /// <returns></returns>
        public ActionResult elementoMatriz(ElementoMatriz elementoMatriz, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            ElementoMatriz elementoGuardado = matrizServicios.AgregarElementoMatriz(elementoMatriz, usuarioActual.IdEmpresa, edInfoauditoria);


            if (elementoGuardado.Descripcion_Elemento != null)
            {
                return Json(new
                {
                    success = true,
                    PK_Elemento_Matriz = elementoGuardado.PK_Elemento_Matriz,
                    Descripcion_Elemento = elementoGuardado.Descripcion_Elemento,
                    FK_Matriz = elementoGuardado.FK_Matriz,
                    FK_TipoElementoAnalisis = elementoGuardado.FK_TipoElementoAnalisis
                }
                , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Eliminar un elemento de la matriz
        /// </summary>
        /// <param name="Pk_elementoMatriz">pk o clave primaria del elemento a eliminar </param>
        /// <returns></returns>
        public ActionResult EliminarElementoMatriz(int Pk_elementoMatriz, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            return Json(new
            {
                success = matrizServicios.EliminarElementoMatriz(Pk_elementoMatriz, edInfoauditoria)
            }
                 , JsonRequestBehavior.AllowGet);
        }

        public ActionResult DOFA_PDF()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View(matrizServicios.ObtenerElementosMatriz(tipoDOFA, usuarioActual.NitEmpresa));
        }

        public ActionResult PEST_PDF(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }


        /// <summary>
        /// Controlador para mostrar la matria DOFA
        /// </summary>
        /// <returns></returns>
        public ActionResult MostrarDOFA()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View(matrizServicios.ObtenerElementosMatriz(tipoDOFA, usuarioActual.NitEmpresa));
        }

        /// <summary>
        /// Controlador para mostrar la matriz PEST
        /// </summary>
        /// <returns></returns>
        public ActionResult MostrarPEST()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return View(matrizServicios.ObtenerElementosMatriz(tipoPEST, usuarioActual.NitEmpresa));
        }




        public ActionResult CargarMatrizElemento2(int customerIDs)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            string matriz_Cargar;
            try
            {
                matriz_Cargar = matrizServicios.ObtenerElementoDofa(customerIDs);
                return Json(new { success = true, jsmatriz_Cargar = matriz_Cargar }
                     , JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult MatrizEditarElemento(ElementoMatriz elementoMatriz, string ipUsuario)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            EDInformacionAuditoria edInfoauditoria = new EDInformacionAuditoria()
            {
                IdentificacionUsuario = usuarioActual.Documento,
                NombreUsuario = usuarioActual.NombreUsuario,
                NitEmpresa = usuarioActual.NitEmpresa,
                NombreEmpresa = usuarioActual.RazonSocialEmpresa,
                IpUsuario = ipUsuario
            };
            ElementoMatriz elementoGuardado = matrizServicios.GrabarElementoMatrizEdicion(elementoMatriz, edInfoauditoria);
            if (elementoGuardado.FK_Matriz != null)
            {
                return Json(new
                {
                    success = true,
                    PK_Elemento_Matriz = elementoGuardado.PK_Elemento_Matriz,
                    Descripcion_Elemento = elementoGuardado.Descripcion_Elemento,
                    FK_Matriz = elementoGuardado.FK_Matriz,
                    FK_TipoElementoAnalisis = elementoGuardado.FK_TipoElementoAnalisis
                }
                , JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }






        public ActionResult cargarMatBoton(int id)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.mensaje1 = "Debe Registrarse para Ingresar a este Modulo.";
                return RedirectToAction("Login", "Home");
            }
            string matriz_Cargar;
            matriz_Cargar = matrizServicios.ObtenerElementoDofa(id);
            return RedirectToAction("DOFA");
        }


        [AllowAnonymous]
        public ActionResult ReporteDOFA_PDF()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return new Rotativa.PartialViewAsPdf("DOFA_PDF", matrizServicios.ObtenerElementosMatriz(tipoDOFA, usuarioActual.NitEmpresa)) { FileName = "DOFA.pdf" };

        }
         [AllowAnonymous]
        public ActionResult ReportePEST_PDF()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            return new Rotativa.PartialViewAsPdf("PEST_PDF", matrizServicios.ObtenerElementosMatriz(tipoPEST, usuarioActual.NitEmpresa)) { FileName = "PEST.pdf" };


        }
        
        public ActionResult ExportData()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return RedirectToAction("Login", "Home");
            }
            GridView gv = new GridView();
            gv.DataSource = matrizServicios.ObtenerElementosMatriz(tipoDOFA, usuarioActual.NitEmpresa);
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Marklist.doc");
            Response.ContentType = "application/vnd.ms-word ";
            Response.Charset = string.Empty;

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("MostarDOFA");
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }


}

