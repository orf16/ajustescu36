using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SG_SST.Models;
using SG_SST.Controllers.Base;
using SG_SST.Models.Comunicaciones;

namespace SG_SST.Controllers.Comunicaciones
{
    public class PublicacionController : Controller
    {
        private SG_SSTContext db = new SG_SSTContext();

        [HttpGet]
        public JsonResult GenerarEncuesta(int PK_Id_Encuesta)
        {
            var comunicaciones = db.Tbl_ComunicacionesInternas.Where(x => x.PK_Id_Encuesta == PK_Id_Encuesta).SingleOrDefault();
            //string[] newurl = comunicaciones.URL.Split(':');
            //string[] _newurl = newurl[2].Split('/');

            //string url = newurl[0] + ":" + newurl[1] + "/" + _newurl[1] + "/" + _newurl[2] + "/" + _newurl[3];

            return Json(comunicaciones.URL, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PublicarEncuesta(string formdata)
        {
            var comunicaciones = db.Tbl_ComunicacionesInternas.Where(x => x.TokenPublico == formdata).SingleOrDefault();

            DateTime FechaVigencia = FormatDate(comunicaciones.vigencia);
            DateTime hoy = DateTime.Today;
            string mensaje = "La encuesta que está consultando se encuentra caducada. Agradecemos su participación";
            bool caduca = false;
            if (FechaVigencia < hoy)
                caduca = true;


            ComunicacionesPublicas objComunicacionesPublicas = new ComunicacionesPublicas()
            {
                fk_pk_id_encuesta = comunicaciones.PK_Id_Encuesta,
                contenido = comunicaciones.CuerpoHTML,
                titulo = comunicaciones.Titulo,
                caducado = caduca,
                mensaje = mensaje
            };
            
            return View(objComunicacionesPublicas);
        }

        private DateTime FormatDate(string Fecha)
        {
            string[] date = Fecha.Split('/');
            string fecpattern = date[0] + "-" + date[1] + "-" + date[2];
            return Convert.ToDateTime(fecpattern, System.Globalization.CultureInfo.GetCultureInfo("es-CO").DateTimeFormat);
        }

    }
}
