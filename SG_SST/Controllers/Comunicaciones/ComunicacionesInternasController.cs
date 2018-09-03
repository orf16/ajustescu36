using SG_SST.Controllers.Base;
using SG_SST.Models;
using SG_SST.Models.Comunicaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace SG_SST.Controllers.Comunicaciones
{
    public class ComunicacionesInternasController : BaseController
    {
        private SG_SSTContext db = new SG_SSTContext();

        public ActionResult Index() {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return View();
            }

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GuardarEncuestaT(int PK_Id_Encuesta, string Titulo, string CuerpoEncuesta, string buildform, string webControls, string EstadoEncuesta, string vigencia, string[] url) 
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var encuesta = db.Tbl_ComunicacionesInternas.Where(x => x.PK_Id_Encuesta == PK_Id_Encuesta).SingleOrDefault();
            string url1 = url[0];
            string url2 = url[1];
            string FechaEnvio = string.Empty;
            string web_controls = string.Empty;
            string[] TokenPublico = url[1].Split('=');
            string[] webctrl = webControls.Split('|');
            int cont = 1;
            for (int i = 0; i < webctrl.Length; i++)
            {
                if (webctrl[i]!="")
                {
                    if (cont<=2)
                    {
                        if(cont==2)
                            web_controls += webctrl[i] + '|';
                        else
                            web_controls += webctrl[i] + ',';
                        
                        cont++;
                    }

                    if (cont == 3)
                        cont = 1;

                }
            }

            using (var Transaction = db.Database.BeginTransaction())
            {
            
            if (encuesta != null)
            {
                encuesta.Titulo = Titulo;
                encuesta.CuerpoHTML = CuerpoEncuesta;
                encuesta.BuildFormHtml = buildform;
                encuesta.webControls = web_controls;
                encuesta.FechaCreacion = DateTime.Now.ToString();
                encuesta.FechaEnvio = DateTime.Now.ToString();
                encuesta.EstadoEncuesta = "Publicado";
                encuesta.vigencia = vigencia;
                encuesta.URL = url1 + '?' + url2;
                encuesta.TokenPublico = TokenPublico[1];
                db.Tbl_ComunicacionesInternas.Attach(encuesta);
                var entry = db.Entry(encuesta);
                entry.State = System.Data.Entity.EntityState.Modified;
                entry.Property(x => x.Titulo).IsModified = true;
                entry.Property(x => x.CuerpoHTML).IsModified = true;
                entry.Property(x => x.BuildFormHtml).IsModified = true;
                entry.Property(x => x.webControls).IsModified = true;
                entry.Property(x => x.FechaCreacion).IsModified = true;
                entry.Property(x => x.FechaEnvio).IsModified = true;
                entry.Property(x => x.EstadoEncuesta).IsModified = true;
                db.SaveChanges();

                var encuestas_preguntas = db.Tbl_ComunicacionesEncuestasPreguntas.Where(x => x.fk_pk_id_encuesta == PK_Id_Encuesta).ToList();
                db.Tbl_ComunicacionesEncuestasPreguntas.RemoveRange(encuestas_preguntas);
                db.SaveChanges();

                string[] webControl = web_controls.Split('|');
                for (int i = 0; i < webControl.Length; i++)
                {
                    string[] controls = webControl[i].Split(',');
                    if (controls[0] != "")
                    {
                        ComunicacionesEncuestasPreguntas objpreguntas = new ComunicacionesEncuestasPreguntas()
                        {
                            fk_pk_id_encuesta = PK_Id_Encuesta,
                            pregunta = controls[0],
                            control = controls[1]
                        };
                        db.Tbl_ComunicacionesEncuestasPreguntas.Add(objpreguntas);
                        db.SaveChanges();
                    }

                }
            }
            else 
            { 
                ComunicacionesInternas comunicados = new ComunicacionesInternas()
                {
                    Titulo = Titulo,
                    CuerpoHTML = CuerpoEncuesta,
                    BuildFormHtml = buildform,
                    webControls = web_controls,
                    EstadoEncuesta = EstadoEncuesta,
                    FechaCreacion = DateTime.Now.ToString(),
                    FechaEnvio = FechaEnvio,
                    NitEmpresa = usuarioActual.NitEmpresa,
                    vigencia = vigencia,
                    URL = url1 + '?' + url2,
                    TokenPublico = TokenPublico[1]
                };
                db.Tbl_ComunicacionesInternas.Add(comunicados);
                db.SaveChanges();

                string[] webControl = web_controls.Split('|');
                for (int i = 0; i < webControl.Length; i++)
                {
                    string[] controls = webControl[i].Split(',');
                    if (controls[0]!="")
                    {
                        ComunicacionesEncuestasPreguntas objpreguntas = new ComunicacionesEncuestasPreguntas()
                        {
                            fk_pk_id_encuesta = PK_Id_Encuesta,
                            pregunta = controls[0],
                            control = controls[1]
                        };
                        db.Tbl_ComunicacionesEncuestasPreguntas.Add(objpreguntas);
                        db.SaveChanges();
                    }
                    
                }
            }
                Transaction.Commit();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

         
        [HttpGet]
        public JsonResult CopiarEncuesta(int PK_Id_Encuesta) 
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var comunicaciones = db.Tbl_ComunicacionesInternas.Where(x => (x.PK_Id_Encuesta == PK_Id_Encuesta && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();

            using (var Transaction = db.Database.BeginTransaction())
            {
                ComunicacionesInternas comunicados = new ComunicacionesInternas()
                {
                    Titulo = comunicaciones.Titulo,
                    CuerpoHTML = comunicaciones.CuerpoHTML,
                    BuildFormHtml = comunicaciones.BuildFormHtml,
                    webControls = comunicaciones.webControls,
                    EstadoEncuesta = "Copia/En Espera",
                    FechaCreacion = DateTime.Now.ToString(),
                    FechaEnvio = "",
                    NitEmpresa = usuarioActual.NitEmpresa
                };
                db.Tbl_ComunicacionesInternas.Add(comunicados);
                db.SaveChanges();
                Transaction.Commit();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult ListarComunicacionesInternas() 
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            List<ComunicacionesInternas> comunicaciones = db.Tbl_ComunicacionesInternas.Where(x => x.NitEmpresa==usuarioActual.NitEmpresa).ToList();
            return Json(comunicaciones, JsonRequestBehavior.AllowGet);
        }

        
         [HttpGet]
        public JsonResult GenerarLink(int PK_Id_Encuesta) 
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            string TokenPublico = RandomString(24);
            string baseUrl = Request.Url.Scheme;
            baseUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Publicacion/PublicarEncuesta/?formdata=" + TokenPublico;
            var regex = new Regex(@":\d+");
            var cleanUrl = regex.Replace(baseUrl, "");
            return Json(baseUrl, JsonRequestBehavior.AllowGet);
        }

         private static Random random = new Random();
         public static string RandomString(int length)
         {
             const string chars = "123456789abcdefghijklmnopqrstvwxyzABCDEFGHIJKLMOPQRSTVWXYZ";
             return new string(Enumerable.Repeat(chars, length)
               .Select(s => s[random.Next(s.Length)]).ToArray());
         }


        [HttpPost]
         public JsonResult GuardarEncuesta(string[] arRespuesta, int fk_pk_id_encuesta)
        {
            //string param = formulario.Replace("%20"," ");
            //string[] frm = formulario.Split('&');
            //string[] id_encuesta = frm[0].Split('=');
            //int  fk_pk_id_encuesta = int.Parse(id_encuesta[1]);
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var url_path = db.Tbl_ComunicacionesInternas.Where(x => x.PK_Id_Encuesta == fk_pk_id_encuesta).SingleOrDefault();
            using (var Transaction = db.Database.BeginTransaction())
            {
                var preguntas = db.Tbl_ComunicacionesEncuestasPreguntas.Where(x => x.fk_pk_id_encuesta == fk_pk_id_encuesta).ToList();
                int pk = 0;
                var qry_cons = db.Tbl_ComunicacionesEncuestas.Where(x => x.fk_pk_id_encuesta == fk_pk_id_encuesta).ToList();
                if (qry_cons.Count>0){
                    var cons = db.Tbl_ComunicacionesEncuestas.Max(x => x.pk_id_encuesta_publicada);
                    pk = cons + 1;
                }else
                    pk = 1;

                int cont = 0;
                foreach (var item in preguntas)
                {
                    if (item.control!="label_etiqueta")
                    {
                        var param = arRespuesta[cont].Split('|');
                        if (item.control=="label")
                        {
                            param[1] = "[titulo_seleccion_multiple]";
                            cont--;
                        }

                        if (item.control == "checkbox") {
                            if (param[1]=="on")
                                param[1] = "true";
                            else
                                param[1] = "false";

                        }
                        
                        
                        ComunicacionesEncuestas objComunicacionesEncuestas = new ComunicacionesEncuestas()
                        {
                            fk_pk_id_encuesta = fk_pk_id_encuesta,
                            pk_id_encuesta_publicada = pk,
                            pregunta = item.pregunta,
                            control = item.control,
                            respuesta = param[1],
                            fechacreacion = DateTime.Now.ToString(),
                            NitEmpresa = usuarioActual.NitEmpresa,
                            URL = url_path.URL
                        };
                        db.Tbl_ComunicacionesEncuestas.Add(objComunicacionesEncuestas);
                        db.SaveChanges();
                        cont++;
                    }
                }

                Transaction.Commit();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EditarEncuesta(int PK_Id_Encuesta)
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var comunicaciones = db.Tbl_ComunicacionesInternas.Where(x => (x.PK_Id_Encuesta == PK_Id_Encuesta && x.NitEmpresa== usuarioActual.NitEmpresa)).SingleOrDefault();
            return Json(comunicaciones, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EliminarEncuesta(int PK_Id_Encuesta)
        {
            var comunicaciones = db.Tbl_ComunicacionesInternas.Where(x => x.PK_Id_Encuesta == PK_Id_Encuesta).SingleOrDefault();
            using (var Transaction = db.Database.BeginTransaction())
            {
                db.Tbl_ComunicacionesInternas.Remove(comunicaciones);
                db.SaveChanges();
                Transaction.Commit();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
