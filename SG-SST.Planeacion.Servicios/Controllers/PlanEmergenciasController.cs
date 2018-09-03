using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Logica.Planificacion;
namespace SG_SST.Planeacion.Servicios.Controllers
{
    public class PlanEmergenciasController : ApiController
    {
        [HttpPost]
        [ActionName("cargar-plantilla-bdInterna")]
        public HttpResponseMessage CargarPlantillaBDINterna(EDCarguePlanEmergencia cargue)
        {
            HttpResponseMessage response = null;
            try
            {
                LNCarguePlanEmergencia logica = new LNCarguePlanEmergencia();
                var archivo = logica.CargarPlantillaBDInterna(cargue);
                if (archivo != null)
                {
                    response = Request.CreateResponse<EDCarguePlanEmergencia>(HttpStatusCode.Created, archivo);
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

        [HttpPost]
        [ActionName("cargar-plantilla-bdExterna")]
        public HttpResponseMessage CargarPantillaBDExterna(EDCarguePlanEmergencia cargue)
        {
            HttpResponseMessage response = null;
            try
            {
                LNCarguePlanEmergencia logica = new LNCarguePlanEmergencia();
                var archivo = logica.CargarPlantillaBDExterna(cargue);
                if (archivo != null)
                {
                    response = Request.CreateResponse<EDCarguePlanEmergencia>(HttpStatusCode.Created, archivo);
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

        [HttpPost]
        [ActionName("cargar-plantilla-bdPlanAyuda")]
        public HttpResponseMessage CargarPantillaBDPlanAyuda(EDCarguePlanEmergencia cargue)
        {
            HttpResponseMessage response = null;
            try
            {
                LNCarguePlanEmergencia logica = new LNCarguePlanEmergencia();
                var archivo = logica.CargarPlantillaBDPlanAyuda(cargue);
                if (archivo != null)
                {
                    response = Request.CreateResponse<EDCarguePlanEmergencia>(HttpStatusCode.Created, archivo);
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