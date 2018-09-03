using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Logica.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SG_SST.Planeacion.Servicios.Controllers
{
    public class MetasIndicadoresController : ApiController
    {
        [HttpGet]
        [ActionName("Obtener-Indicadores-Tipo")]
        public HttpResponseMessage ObtenerIndicadoresPorTipo(string tipo)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.ObtenerIndicadoresPorTipo(tipo);
                if (result != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("Obtener-Indicador-Id")]
        public HttpResponseMessage ObtenerIndicadorPorId(int IdIndicador)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.ObtenerIndicadorPorId(IdIndicador);
                if (result != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("Obtener-Metas-Indicadores-Empresa")]
        public HttpResponseMessage ObtenerMetasIndicadoresPorEmpresa(int id)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.ObtenerMetasIndicadoresPorEmpresa(id);
                if (result != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("Obtener-Meta-Indicador-Id")]
        public HttpResponseMessage ObtenerMetaIndicadorPorId(int id)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.ObtenerMetaIndicadorPorId(id);
                if (result != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpPost]
        [ActionName("Guardar-Meta-Indicador")]
        public HttpResponseMessage GuardarMetaIndicador(EDMetaIndicador metaInd)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.GuardarMetaIndicador(metaInd);
                if (result != null)
                {
                    var response = Request.CreateResponse<EDMetaIndicador>(HttpStatusCode.Created, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpPost]
        [ActionName("Modificar-Meta-Indicador")]
        public HttpResponseMessage ModificarMetaIndicador(EDMetaIndicador metaInd)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.ModificarMetaIndicador(metaInd);
                if (result != null)
                {
                    var response = Request.CreateResponse<EDMetaIndicador>(HttpStatusCode.Created, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpGet]
        [ActionName("Eliminar-Meta-Indicador")]
        public HttpResponseMessage EliminarMetaIndicador(int IdMetaInd, int IdEmpresa)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.EliminarMetaIndicador(IdMetaInd, IdEmpresa);
                if (result != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        
        [HttpGet]
        [ActionName("Obtener-Meta-Indicador-Nombre-Indicador-Empresa")]
        public HttpResponseMessage ObtenerMetaIndicadorPorNombreIndicadorYEmpresa(string indicador, int id)
        {
            try
            {
                var logica = new LNMetasIndicadores();
                var result = logica.ObtenerMetaIndicadorPorNombreIndicadorYEmpresa(indicador, id);
                if (result != null)
                {
                    var response = Request.CreateResponse(HttpStatusCode.OK, result);
                    return response;
                }
                else
                {
                    var response = Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

    }
}
