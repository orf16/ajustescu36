using SG_SST.Controllers.Base;
using SG_SST.Models;
using SG_SST.Models.Incidentes;
using SG_SST.Utilidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SG_SST.Controllers.IncidentesConsulta
{
    public class IncidentesConsultaController : BaseController
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

            return View();
        }


        [HttpGet]
        public JsonResult ListarIncidentesAT(string tipo, string fechaini, string fechafin)
        {
            DateTime fecini = FormatDate(fechaini);
            DateTime fecfin = FormatDate(fechafin);
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            List<IncidentesAT1> listIncidenteAT = db.Tbl_IncidentesAT1.Where(x => x.boIncidente == tipo && x.NitEmpresa == usuarioActual.NitEmpresa).ToList();
            List<ConsultasIncidentesModel> objConsultasIncidentesModel = new List<ConsultasIncidentesModel>();
            foreach (var item in listIncidenteAT)
            {
                ConsultasIncidentesModel objConsultasModel = new ConsultasIncidentesModel();
                objConsultasModel.pk_id_incidente = item.PK_Incidentes_AT;
                //string fechas = FormatDatesI(item.FechaInvestigacionI);
                objConsultasModel.fechainvestigacion = item.FechaInvestigacionI;
                objConsultasIncidentesModel.Add(objConsultasModel);
            }

            var incidentes = objConsultasIncidentesModel.Where(x => x.fechainvestigacion >= fecini && x.fechainvestigacion <= fecfin).ToList();
            List<RetornoIncidentesModel> listRetornoConsultas = new List<RetornoIncidentesModel>();
            foreach (var item in incidentes)
            {
                RetornoIncidentesModel objRetornoIncidentesModel = new RetornoIncidentesModel() {
                    fechainvestigacion = FormatDatesI(item.fechainvestigacion),
                    pk_id_incidente = item.pk_id_incidente
                };

                listRetornoConsultas.Add(objRetornoIncidentesModel);
            }

            return Json(listRetornoConsultas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarIncidentesEL(string tipo, string fechaini, string fechafin)
        {
            DateTime fecini = FormatDate(fechaini);
            DateTime fecfin = FormatDate(fechafin);
            var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
            List<IncidentesEL1> listIncidenteEL = db.Tbl_IncidentesEL1.Where(x => x.NitEmpresa == usuarioActual.NitEmpresa).ToList();
            List<ConsultasIncidentesModel> objConsultasIncidentesModel = new List<ConsultasIncidentesModel>();
            foreach (var item in listIncidenteEL)
            {
                ConsultasIncidentesModel objConsultasModel = new ConsultasIncidentesModel();
                objConsultasModel.pk_id_incidente = item.PK_Incidentes_EL;
                string fechas = FormatDatesI(item.FechaInvestigacionI);
                objConsultasModel.fechainvestigacion = Convert.ToDateTime(fechas);
                objConsultasIncidentesModel.Add(objConsultasModel);
            }

            var incidentes = objConsultasIncidentesModel.Where(x => x.fechainvestigacion >= fecini && x.fechainvestigacion <= fecfin).ToList();
            List<RetornoIncidentesModel> listRetornoConsultas = new List<RetornoIncidentesModel>();
            foreach (var item in incidentes)
            {
                RetornoIncidentesModel objRetornoIncidentesModel = new RetornoIncidentesModel()
                {
                    fechainvestigacion = FormatDatesI(item.fechainvestigacion),
                    pk_id_incidente = item.pk_id_incidente
                };

                listRetornoConsultas.Add(objRetornoIncidentesModel);
            }

            return Json(listRetornoConsultas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EliminarIncidente(int pk_id_incidente, string tipo)
        {
            using (var Transaction = db.Database.BeginTransaction())
            {
                var usuarioActual = ObtenerUsuarioEnSesion(System.Web.HttpContext.Current);
                if (tipo == "AT")
                {
                    var incidentesat1 = db.Tbl_IncidentesAT1.Where(x => (x.PK_Incidentes_AT == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat1 != null)
                    {
                        db.Tbl_IncidentesAT1.Remove(incidentesat1);
                        db.SaveChanges();
                    }

                    var incidentesat2 = db.Tbl_IncidentesAT2.Where(x => (x.FK_incidentes_AT2 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat2 != null)
                    {
                        db.Tbl_IncidentesAT2.Remove(incidentesat2);
                        db.SaveChanges();
                    }
                    var incidentesat3 = db.Tbl_IncidentesAT3.Where(x => (x.FK_incidentes_AT3 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat3 != null)
                    {
                        db.Tbl_IncidentesAT3.Remove(incidentesat3);
                        db.SaveChanges();
                    }
                    var incidentesat4 = db.Tbl_IncidentesAT4.Where(x => (x.FK_incidentes_AT4 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat4 != null)
                    {
                        db.Tbl_IncidentesAT4.Remove(incidentesat4);
                        db.SaveChanges();
                    }
                    var incidentesat5 = db.Tbl_IncidentesAT5.Where(x => (x.FK_incidentes_AT5 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat5 != null)
                    {
                        db.Tbl_IncidentesAT5.Remove(incidentesat5);
                        db.SaveChanges();
                    }
                    var incidentesat6 = db.Tbl_IncidentesAT6.Where(x => (x.FK_incidentes_AT6 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat6 != null)
                    {
                        db.Tbl_IncidentesAT6.Remove(incidentesat6);
                        db.SaveChanges();
                    }
                    var incidentesat7 = db.Tbl_IncidentesAT7.Where(x => (x.FK_incidentes_AT7 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat7 != null)
                    {
                        db.Tbl_IncidentesAT7.Remove(incidentesat7);
                        db.SaveChanges();
                    }
                    var incidentesat8 = db.Tbl_IncidentesAT8.Where(x => (x.FK_incidentes_AT8 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat8 != null)
                    {
                        db.Tbl_IncidentesAT8.Remove(incidentesat8);
                        db.SaveChanges();
                    }
                    var incidentesat9 = db.Tbl_IncidentesAT9.Where(x => (x.FK_incidentes_AT9 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat9 != null)
                    {
                        db.Tbl_IncidentesAT9.Remove(incidentesat9);
                        db.SaveChanges();
                    }
                    var incidentesat10 = db.Tbl_IncidentesAT10.Where(x => (x.FK_incidentes_AT10 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat10 != null)
                    {
                        db.Tbl_IncidentesAT10.Remove(incidentesat10);
                        db.SaveChanges();
                    }
                    var incidentesat11 = db.Tbl_IncidentesAT11.Where(x => (x.FK_incidentes_AT11 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat11 != null)
                    {
                        db.Tbl_IncidentesAT11.Remove(incidentesat11);
                        db.SaveChanges();
                    }
                    var incidentesat12 = db.Tbl_IncidentesAT12.Where(x => (x.FK_incidentes_AT12 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat12 != null)
                    {
                        db.Tbl_IncidentesAT12.Remove(incidentesat12);
                        db.SaveChanges();
                    }
                    var incidentesat13 = db.Tbl_IncidentesAT13.Where(x => (x.FK_incidentes_AT13 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesat13 != null)
                    {
                        db.Tbl_IncidentesAT13.Remove(incidentesat13);
                        db.SaveChanges();
                    }
                }

                if (tipo == "EL")
                {
                    var incidentesatel1 = db.Tbl_IncidentesEL1.Where(x => (x.PK_Incidentes_EL == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel1 != null)
                    {
                        db.Tbl_IncidentesEL1.Remove(incidentesatel1);
                        db.SaveChanges();
                    }
                    var incidentesatel2 = db.Tbl_IncidentesEL2.Where(x => (x.FK_Incidentes_EL2 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel2 != null)
                    {
                        db.Tbl_IncidentesEL2.Remove(incidentesatel2);
                        db.SaveChanges();
                    }
                    var incidentesatel3 = db.Tbl_IncidentesEL3.Where(x => (x.FK_Incidentes_EL3 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel3 != null)
                    {
                        db.Tbl_IncidentesEL3.Remove(incidentesatel3);
                        db.SaveChanges();
                    }
                    var incidentesatel4 = db.Tbl_IncidentesEL4.Where(x => (x.FK_Incidentes_EL4 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel4 != null)
                    {
                        db.Tbl_IncidentesEL4.Remove(incidentesatel4);
                        db.SaveChanges();
                    }
                    var incidentesatel5 = db.Tbl_IncidentesEL5.Where(x => (x.FK_Incidentes_EL5 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel5 != null)
                    {
                        db.Tbl_IncidentesEL5.Remove(incidentesatel5);
                        db.SaveChanges();
                    }
                    var incidentesatel6 = db.Tbl_IncidentesEL6.Where(x => (x.FK_Incidentes_EL6 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel6 != null)
                    {
                        db.Tbl_IncidentesEL6.Remove(incidentesatel6);
                        db.SaveChanges();
                    }
                    var incidentesatel7 = db.Tbl_IncidentesEL7.Where(x => (x.FK_Incidentes_EL7 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel7 != null)
                    {
                        db.Tbl_IncidentesEL7.Remove(incidentesatel7);
                        db.SaveChanges();
                    }
                    var incidentesatel8 = db.Tbl_IncidentesEL8.Where(x => (x.FK_Incidentes_EL8 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel8 != null)
                    {
                        db.Tbl_IncidentesEL8.Remove(incidentesatel8);
                        db.SaveChanges();
                    }
                    var incidentesatel9 = db.Tbl_IncidentesEL9.Where(x => (x.FK_Incidentes_EL9 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel9 != null)
                    {
                        db.Tbl_IncidentesEL9.Remove(incidentesatel9);
                        db.SaveChanges();
                    }
                    var incidentesatel10 = db.Tbl_IncidentesEL10.Where(x => (x.FK_Incidentes_EL10 == pk_id_incidente && x.NitEmpresa == usuarioActual.NitEmpresa)).SingleOrDefault();
                    if (incidentesatel10 != null)
                    {
                        db.Tbl_IncidentesEL10.Remove(incidentesatel10);
                        db.SaveChanges();
                    }

                }

                Transaction.Commit();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        private DateTime FormatDate(string Fecha)
        {
            string[] date = Fecha.Split('/');
            string fecpattern = date[0] + "-" + date[1] + "-" + date[2];
            return Convert.ToDateTime(fecpattern, System.Globalization.CultureInfo.GetCultureInfo("es-CO").DateTimeFormat);
        }

        private string FormatDates(DateTime Fecha)
        {
            Fecha = Convert.ToDateTime(Fecha, System.Globalization.CultureInfo.GetCultureInfo("es-CO").DateTimeFormat);
            //string fecpattern = Fecha.Year + "-" + Fecha.Month + "-" + Fecha.Day;
            string fecpattern = Fecha.Month + "/" + Fecha.Day + "/" + Fecha.Year;
            return fecpattern;
        }

        private string FormatDatesI(DateTime Fecha)
        {
            Fecha = Convert.ToDateTime(Fecha, System.Globalization.CultureInfo.GetCultureInfo("es-CO").DateTimeFormat);
            //string fecpattern = Fecha.Year + "-" + Fecha.Month + "-" + Fecha.Day;
            string fecpattern = Fecha.Day + "/" + Fecha.Month + "/" + Fecha.Year;
            return fecpattern;
        }

    }
}