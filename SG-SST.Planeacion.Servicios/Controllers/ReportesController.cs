using SG_SST.Logica.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SG_SST.Planeacion.Servicios.Controllers
{
    public class ReportesController : ApiController
    {
        [HttpGet]
        [ActionName("estandares-minimos-excel")]
        public HttpResponseMessage ObtenerReporteExcel(string Nit, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var archivo = logica.GenerarArchivoExcel(Nit, Idval);
                if (archivo != null)
                {
                    response = Request.CreateResponse<byte[]>(HttpStatusCode.OK, archivo);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-plan-accion-excel")]
        public HttpResponseMessage ObtenerReporteActividadesExcel(string Nit, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var archivo = logica.ObtenerActividadesExcel(Nit, Idval);
                if (archivo != null)
                {
                    response = Request.CreateResponse<byte[]>(HttpStatusCode.OK, archivo);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-respuestas")]
        public HttpResponseMessage ObtenerPorcentajeDeRespuestas(string Nit, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerPorcentajeDeRespuestas(Nit, Idval);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-respuestas-excel")]
        public HttpResponseMessage ObtenerExcelPorcentajeDeRespuestas(string Nit, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerExcelPorcentajeDeRespuestas(Nit, Idval);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-puntaje")]
        public HttpResponseMessage ObtenerPorcentajeObtenido(string Nit, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerPorcentajeObtenido(Nit, Idval);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-puntaje-excel")]
        public HttpResponseMessage ObtenerExcelPorcentajeObtenido(string Nit, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerExcelPorcentajeObtenido(Nit, Idval);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-calificacion-final")]
        public HttpResponseMessage ObtenerPorcentajeObtenidoCiclo(string Nit, int IdCiclo, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerCalificacionEstandresPorCliclo(Nit, IdCiclo, Idval);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-calificacion-ciclo")]
        public HttpResponseMessage ObtenerExcelPorcentajeObtenidoCiclo(string Nit, int IdCiclo, int Idval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerExcelCalificacionEstandresPorCliclo(Nit, IdCiclo, Idval);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("estandares-minimos-comparar")]
        public HttpResponseMessage ObtenerPorcentajeObtenidoCicloComparar(string Nit, int fi, int ff)
        {
            HttpResponseMessage response = null;
            try
            {
                LNReportesEstandaresMinimos logica = new LNReportesEstandaresMinimos();
                var Ciclos = logica.ObtenerCalificacionEstandresPorClicloComparar(Nit, fi, ff);
                if (Ciclos != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Ciclos);
                    return response;
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
    }
}
