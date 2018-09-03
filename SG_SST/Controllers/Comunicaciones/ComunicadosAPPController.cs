using SG_SST.Controllers.Base;
using SG_SST.EntidadesDominio.ComunicadosAPP;
using SG_SST.Models;
using SG_SST.Models.Comunicaciones;
using SG_SST.Models.ComunicadosAPP;
using SG_SST.Models.Organizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Configuration;
using RestSharp;
using SG_SST.Dtos.Organizacion;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web;


namespace SG_SST.Controllers.Comunicaciones
{
    public class ComunicadosAPPController : BaseController
    {
        private SG_SSTContext db = new SG_SSTContext();

        public ActionResult Index()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            if (usuarioActual == null)
            {
                ViewBag.Mensaje = "El usuario no ha iniciado sesión el sistema";
                return View();
            }

            ComunicadosAPPModel objcomunicadosapp = new ComunicadosAPPModel();
            //objcomunicadosapp.ListarComunicadosAPP = ListarComunicadosAPP();
            return View(objcomunicadosapp);
        }

        public JsonResult ListarComunicadosAPP()
        {
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            var comunicadoapp = db.Tbl_ComunicadosAPP.Where(x => x.NitEmpresa==usuarioActual.NitEmpresa).ToList();
            return Json(comunicadoapp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ValidateInput(false)]
        public JsonResult EliminarComunicado(int? IDComunicadosAPP)
        {

            using (var Transaction = db.Database.BeginTransaction())
            {
                if (IDComunicadosAPP > 0)
                {
                    var comunicaciones = db.Tbl_UsuarioComunicadoAPP.Where(x => x.FK_Id_ComunicadosAPP == IDComunicadosAPP).ToList();
                    db.Tbl_UsuarioComunicadoAPP.RemoveRange(comunicaciones);
                    var comunicaciones1 = db.Tbl_ComunicadosAPP.Where(x => x.IDComunicadosAPP == IDComunicadosAPP).SingleOrDefault();
                    db.Tbl_ComunicadosAPP.Remove(comunicaciones1);
                }

                db.SaveChanges();
                Transaction.Commit();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private static string[] FindHrefs(string input)
        {
            Regex regex = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase);
            Match match;
            string[] links = new string[100];
            int i = 0;
            for (match = regex.Match(input); match.Success; match = match.NextMatch())
            {
                foreach (Group group in match.Groups)
                {
                    links[i] = group.Value;
                    i++;
                }
            }

            return links;

        }
       
        [HttpGet]
        [ValidateInput(false)]
        public JsonResult GuardarComunicado(int? IDComunicadosAPP, string Titulo, string Asunto, string arreglo, string Origen, bool esEncuesta)
        {
         
                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            int PK_Id_Comunicado_temp = 0;
            string[] title = new string[100];
            string[] test = Asunto.Split('>');
            int c = 0;
            for (int i = 0; i < test.Length; i++)
            {
                string[] tag = test[i].Split('<');
                if (tag[0] != "")
                {
                    if (tag[1] == "/a")
                    {
                        title[c] = tag[0];
                        c++;
                    }
                }  
            }

            string[] input = FindHrefs(Asunto);
            string links = string.Empty;
            foreach (var item in input)
            {
                if (item!=null)
                {
                    string href = item;
                    if (!href.Contains("href"))
                    {
                        links += href+'|';
                    } 
                }
            }

            string[] enlaces = links.Split('|');
            string link = "<links>";
            c = 0;
            for (int i = 0; i < enlaces.Length; i++)
            {
                
                if (enlaces[i] != "") {
                    link += "<link>";
                    link += "<titulo>" + title[c] + "</titulo>";
                    link += "<enlace>" + enlaces[i] + "</enlace>";
                    link += "</link>";
                    c++;
                }
            }
             link +="</links>";


             string cadenaConTags = Asunto;
             //string preub = Asunto.Substring(Asunto.IndexOf("<a"), Asunto.IndexOf("/a>"));
           //  string cadenaSinTags = Regex.Replace(cadenaConTags, "<div.*?>|<span.*?>|<class.*?>|<h.*?>|<h2.*?>|<h3.*?>|<h4.*?>|<h5.*?>|<h6.*?>|<table.*?>|<tbody.*?>|<strong.*?>|<tr.*?>|<th.*?>|<td.*?>|<em.*?> |<img.*?>|<blockquote.*?>|<ul.*?>|<li.*?> |<li.*?>|<b.*?>|<i.*?>|<thead.*?>|<col.*?>|<t.*?>|<w.*?>", string.Empty);
             string cadenaSinTags = Regex.Replace(cadenaConTags, "<b.*?>|<c.*?>|<d.*?>|<e.*?>|<f.*?>|<g.*?>|<h.*?>|<i.*?>|<j.*?>|<k.*?>|<l.*?>|<m.*?>|<n.*?> |<ñ.*?>|<o.*?>|<p.*?>|<q.*?> |<r.*?>|<s.*?>|<t.*?>|<u.*?> |<v.*?>|<w.*?>|<x.*?>|<y.*?>|<z.*?> |<ul.*?>| <!.*?>", string.Empty);
             string cadenaSinTags2 = Regex.Replace(cadenaSinTags, "</b.*?>|</c.*?>|</d.*?>|</e.*?>|</f.*?>|</g.*?>|</h.*?>|</i.*?>|</j.*?>|</k.*?>|</l.*?>|</m.*?>|</n.*?> |</ñ.*?>|</o.*?>|</p.*?>|</q.*?> |</r.*?>|</s.*?>|</t.*?>|</u.*?> |</v.*?>|</w.*?>|</x.*?>|</y.*?> <z.*?> |</ul.*?> ", string.Empty);
     

             ////string cadenaSinTags1 = Regex.Replace(cadenaConTags, "<.*?>", string.Empty);
             string Asunto1 = cadenaSinTags2.Replace("&nbsp;", " ");

           // string cadenaConTags = Asunto;

            Asunto1 = Asunto1.Replace("\n", " ");
          
            Asunto1 = Asunto1.Replace("&aacute;", "á");
            Asunto1 = Asunto1.Replace("&eacute;", "é");
            Asunto1 = Asunto1.Replace("&iacute;", "í");
            Asunto1 = Asunto1.Replace("&oacute;", "ó");
            Asunto1 = Asunto1.Replace("&uacute;", "ú");
            Asunto1 = Asunto1.Replace("&Aacute;", "Á");
            Asunto1 = Asunto1.Replace("&Eacute;", "É");
            Asunto1 = Asunto1.Replace("&Iacute;", "Í");
            Asunto1 = Asunto1.Replace("&Oacute;", "Ó");
            Asunto1 = Asunto1.Replace("&Uacute;", "Ú");
            Asunto1 = Asunto1.Replace("&ntilde;", "ñ");
            Asunto1 = Asunto1.Replace("&mdash;", "_");
            Asunto1 = Asunto1.Replace("&ndash;", "-");
            Asunto1 = Asunto1.Replace("&&middot;", ".");
            Asunto1 = Asunto1.Replace("&permil;", "%");
            Asunto1 = Asunto1.Replace("&deg;", "°");
            Asunto1 = Asunto1.Replace("&trade;", "™");
            Asunto1 = Asunto1.Replace("&reg;", "®");
            Asunto1 = Asunto1.Replace("&copy;", "©");
            Asunto1 = Asunto1.Replace("&dagger;", "†");
            Asunto1 = Asunto1.Replace("&bull;", "•");
            Asunto1 = Asunto1.Replace("&laquo;", "«");
            Asunto1 = Asunto1.Replace("&raquo;", "»");
            Asunto1 = Asunto1.Replace("&#8470;", "№");
            Asunto1 = Asunto1.Replace("&euro;", "€");
            
            Asunto1 = Asunto1.Replace("&ldquo;", "\"");
            Asunto1 = Asunto1.Replace("&rdquo;", "“");
            Asunto1 = Asunto1.Replace("&lsquo;", "'");
            Asunto1 = Asunto1.Replace("&rsquo;", "’");
            Asunto1 = Asunto1.Replace("&lt;", "<");
            Asunto1 = Asunto1.Replace("&gt;", ">");
            Asunto1 = Asunto1.Replace("&le;", "<=");
            Asunto1 = Asunto1.Replace("&ge;", ">=");
            Asunto1 = Asunto1.Replace("&iquest;", "¿");
            Asunto1 = Asunto1.Replace("</ul>", "");
            Asunto1 = Asunto1.Replace("&iexcl;", "¡");

            string AsuntoMod = Regex.Replace(Asunto1, "&.*?;", "");
            if (Origen == "E")
            {
                using (var Transaction = db.Database.BeginTransaction())
                {
                    var comunicado = db.Tbl_ComunicadosAPP.Where(x => x.IDComunicadosAPP == IDComunicadosAPP).SingleOrDefault();
                    comunicado.Titulo = Titulo;
                    comunicado.Asunto = Asunto;
                    comunicado.AsuntoAPP = AsuntoMod;
                    comunicado.Estado = "Enviado";
                    comunicado.FechaEnvio = DateTime.Now.ToString();
                    comunicado.esEncuesta = esEncuesta;
                    comunicado.Enlaces = link;
                    db.Tbl_ComunicadosAPP.Attach(comunicado);
                    var entry = db.Entry(comunicado);
                    entry.State = System.Data.Entity.EntityState.Modified;
                    entry.Property(x => x.Titulo).IsModified = true;
                    entry.Property(x => x.Asunto).IsModified = true;
                    entry.Property(x => x.Estado).IsModified = true;
                    entry.Property(x => x.esEncuesta).IsModified = true;
                    entry.Property(x => x.Enlaces).IsModified = true;
                    db.SaveChanges();
                    Transaction.Commit();
                    Thread myNewThread = new Thread(() => EnviarNotificacionesPush(IDComunicadosAPP));
                    myNewThread.Start();
                }
            }
            else {
                string FechaEnvio = string.Empty;
                string EstadoComunicado = "En Espera";
                using (var Transaction = db.Database.BeginTransaction())
                {
                    if (IDComunicadosAPP > 0)
                    {
                        var comunicaciones = db.Tbl_UsuarioComunicadoAPP.Where(x => x.FK_Id_ComunicadosAPP == IDComunicadosAPP).ToList();
                        db.Tbl_UsuarioComunicadoAPP.RemoveRange(comunicaciones);
                        db.SaveChanges();

                        var comunicaciones1 = db.Tbl_ComunicadosAPP.Where(x => x.IDComunicadosAPP == IDComunicadosAPP).SingleOrDefault();
                        db.Tbl_ComunicadosAPP.Remove(comunicaciones1);
                        db.SaveChanges();

                    }

                    string asun = StripTagsRegex(Asunto);
                    asun = HttpUtility.HtmlDecode(asun);
                    ComunicacionesAPP comunicadosapp = new ComunicacionesAPP()
                    {
                        Titulo = Titulo,
                        Asunto = Asunto,
                        AsuntoAPP = Asunto1,
                        Destinatarios = arreglo,
                        FechaCreacion = DateTime.Now.ToString(),
                        FechaEnvio = FechaEnvio,
                        Estado = EstadoComunicado,
                        NitEmpresa = usuarioActual.NitEmpresa,
                        esEncuesta = esEncuesta,
                        Enlaces = link
                    };
                    db.Tbl_ComunicadosAPP.Add(comunicadosapp);
                    db.SaveChanges();
                    PK_Id_Comunicado_temp = comunicadosapp.IDComunicadosAPP;
                    Transaction.Commit();
                    Transaction.Dispose();
                    Thread myNewThread = new Thread(() => GuardarUsuariosComunicados(comunicadosapp, arreglo, usuarioActual.NitEmpresa));
                    myNewThread.Start();
                    }

            }

            var parametros = new { PK_Id_Comunicado_temp = PK_Id_Comunicado_temp, origen = Origen };
            return Json(parametros, JsonRequestBehavior.AllowGet);
        }

        public void GuardarUsuariosComunicados(ComunicacionesAPP comunicadosapp, string arreglo, string NitEmpresa)
        {
            using (var Transaction = db.Database.BeginTransaction())
            {
                var cliente = new RestSharp.RestClient(ConfigurationManager.AppSettings["Url"]);
                var request = new RestRequest(ConfigurationManager.AppSettings["consultaAfiliados"], RestSharp.Method.GET);
                request.RequestFormat = DataFormat.Xml;
                request.Parameters.Clear();
                request.AddParameter("tpEm", "NI");
                request.AddParameter("docEm", NitEmpresa);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                //se omite la validación de certificado de SSL
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                IRestResponse<List<EmpleadosWSDTO>> response = cliente.Execute<List<EmpleadosWSDTO>>(request);
                var result = response.Content;
                var respuesta = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmpleadosWSDTO>>(result);
                bool boTransaction = false;
                string[] arreglos = arreglo.Split(',');
                arreglos = arreglos.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                for (int i = 0; i < arreglos.Length; i++)
                {
                    string[] persona = arreglos[i].Split('-');
                    if (persona[0] != null)
                    {
                        string cedula = string.Empty;
                        try
                        {
                            cedula = persona[1];
                            var usuariosuscrito = db.Tbl_ComunicacionesUsuariosSuscritosAPP.Where(x => x.IdentificacionUsuario == cedula).SingleOrDefault();
                            if (usuariosuscrito != null)
                            {
                                var usuarioexiste = db.Tbl_UsuarioComunicadoAPP.Where(x => (x.IdentificacionUsuario == cedula && x.FK_Id_ComunicadosAPP == comunicadosapp.IDComunicadosAPP)).SingleOrDefault();
                                if (usuarioexiste == null)
                                {
                                    UsuarioComunicadoAPP objusuarios = new UsuarioComunicadoAPP()
                                    {
                                        FK_Id_ComunicadosAPP = comunicadosapp.IDComunicadosAPP,
                                        IdentificacionUsuario = cedula,
                                        PlayerID = usuariosuscrito.PlayerID,
                                        IDEstadoComunicado = 4
                                    };
                                    db.Tbl_UsuarioComunicadoAPP.Add(objusuarios);
                                    db.SaveChanges();
                                    boTransaction = true;
                                }
                            } 
                        }
                        catch (Exception e)
                        {
                            string message = e.Message;
                            //throw;
                        }
                        finally
                        {
                            string parametro = arreglos[i];
                            var cargos_temporales = respuesta.Where(x => x.cargo == parametro).ToList();
                            if (cargos_temporales.Count > 0)
                            {
                                foreach (var item in cargos_temporales)
                                {
                                    string cedula1 = item.idPersona;
                                    var usuariosuscrito1 = db.Tbl_ComunicacionesUsuariosSuscritosAPP.Where(x => x.IdentificacionUsuario == cedula1).SingleOrDefault();
                                    if (usuariosuscrito1 != null)
                                    {
                                        var usuarioexiste = db.Tbl_UsuarioComunicadoAPP.Where(x => (x.IdentificacionUsuario == cedula && x.FK_Id_ComunicadosAPP == comunicadosapp.IDComunicadosAPP)).SingleOrDefault();
                                        if (usuarioexiste == null)
                                        {
                                            UsuarioComunicadoAPP objusuarios = new UsuarioComunicadoAPP()
                                            {
                                                FK_Id_ComunicadosAPP = comunicadosapp.IDComunicadosAPP,
                                                IdentificacionUsuario = usuariosuscrito1.IdentificacionUsuario,
                                                PlayerID = usuariosuscrito1.PlayerID,
                                                IDEstadoComunicado = 4
                                            };
                                            db.Tbl_UsuarioComunicadoAPP.Add(objusuarios);
                                            db.SaveChanges();
                                            boTransaction = true;
                                        }
                                    }
                                }
                            }
                        } 
                    }
                }

                if (boTransaction)
                {
                    Transaction.Commit();
                }
            }
        }

        public void EnviarNotificacionesPush(int? pk_id_comunicado)
        {
            var usuariosapp = db.Tbl_UsuarioComunicadoAPP.Where(x => x.FK_Id_ComunicadosAPP == pk_id_comunicado).ToList();
            using (var Transaction = db.Database.BeginTransaction())
            {
                foreach (var item in usuariosapp)
                {
                    item.IDEstadoComunicado = 1;
                    db.Tbl_UsuarioComunicadoAPP.Attach(item);
                    var entry = db.Entry(item);
                    entry.State = System.Data.Entity.EntityState.Modified;
                    entry.Property(x => x.IDEstadoComunicado).IsModified = true;
                    db.SaveChanges();
                }
                Transaction.Commit();
            }
            
            var comunicado = db.Tbl_ComunicadosAPP.Where(x => x.IDComunicadosAPP == pk_id_comunicado).SingleOrDefault();
            var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("authorization", "Basic NGEwMGZmMjItY2NkNy0xMWUzLTk5ZDUtMDAwYzI5NDBlNjJj");
            string asunto = comunicado.Titulo;
            string contenido = comunicado.AsuntoAPP;
            string[] in_player_ids = new string[usuariosapp.Count];

            for (int i = 0; i < usuariosapp.Count; i++)
            {
                if (usuariosapp[i].PlayerID != "") { 
                    in_player_ids[i] = usuariosapp[i].PlayerID;            
                } 
            }

            if (in_player_ids.Length>0)
            {
                var serializer = new JavaScriptSerializer();
                var obj = new
                {
                    app_id = "117eabf4-4cdd-4bf9-ad76-c9e62d373568",
                    contents = new { en = contenido, es = contenido },
                    headings = new { en = asunto, es = asunto },
                    ios_badgeType = "Increase",
                    ios_badgeCount = 1,
                    include_player_ids = in_player_ids
                };


                var param = serializer.Serialize(obj);
                byte[] byteArray = Encoding.UTF8.GetBytes(param);

                string responseContent = null;

                try
                {
                    using (var writer = request.GetRequestStream())
                    {
                        writer.Write(byteArray, 0, byteArray.Length);
                    }

                    using (var response = request.GetResponse() as HttpWebResponse)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseContent = reader.ReadToEnd();
                        }
                    }
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    System.Diagnostics.Debug.WriteLine(new StreamReader(ex.Response.GetResponseStream()).ReadToEnd());
                    using (var Transaction = db.Database.BeginTransaction())
                    {
                        ComunicacionesLog log = new ComunicacionesLog()
                        {
                            fk_id_comunicaciones = (int)pk_id_comunicado,
                            modulo = "app",
                            enviado_rechazado = false,
                            fecha_envio = DateTime.Now.ToString()

                        };
                        db.Tbl_ComunicacionesLog.Add(log);
                        db.SaveChanges();
                        Transaction.Commit();
                    }

                }

                System.Diagnostics.Debug.WriteLine(responseContent);
            }
        }

        #region DECODE HTML

        private string StripTagsRegex(string source)
        {
            return Regex.Replace(source, "<.*?>", string.Empty);
        }

        static Regex _htmlRegex = new Regex("<.*?>", RegexOptions.Compiled);

        private string StripTagsRegexCompiled(string source)
        {
            return _htmlRegex.Replace(source, string.Empty);
        }

        private string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        #endregion

        [HttpGet]
        [ValidateInput(false)]
        public JsonResult EditarComunicado(int? IDComunicadosAPP)
        {
            var comunicadoapp = db.Tbl_ComunicadosAPP.Where(x => x.IDComunicadosAPP == IDComunicadosAPP).SingleOrDefault();
            return Json(comunicadoapp, JsonRequestBehavior.AllowGet);
        }


    }
}
