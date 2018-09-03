
using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Logica.Empresas;
using SG_SST.Logica.Planificacion;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SG_SST.Planeacion.Servicios.Controllers
{
    public class EvaluacionController : ApiController
    {
        #region Evaluacion Inicial


        /// <summary>
        /// guarda la informacion de la evaluacion inicial de una empresa
        /// </summary>
        /// <param name="Empresa"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("inicial")]
        public HttpResponseMessage GuardarEvaluacionInicial(EDEmpresaEvaluar Empresa)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionInicial logica = new LNEvaluacionInicial();
                EDEmpresaEvaluar empresa = logica.CrearEmpresaEvaluar(Empresa);
                if (empresa != null)
                {
                    response = Request.CreateResponse<EDEmpresaEvaluar>(HttpStatusCode.Created, empresa);
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
        [ActionName("aspectos-base")]
        public HttpResponseMessage ObtenerAspectosBase()
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionInicial logica = new LNEvaluacionInicial();
                var AspectosBase = logica.ObtenerAspectosBase();
                if (AspectosBase != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, AspectosBase);
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
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }

        #endregion

        #region Evaluacion Estandares Minimos

        /// <summary>
        /// Obtiene la lista de los ciclos a evaluar
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("estandares-minimos")]
        public HttpResponseMessage ObtenerCiclos(string NIT, string IdEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                int IdEvalInt = 0;
                if (int.TryParse(IdEval, out IdEvalInt))
                {
                }
                var Ciclos = logica.ObtenerCiclos(NIT, IdEvalInt);
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
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
        /// <summary>
        /// Obtiene la lista de los ciclos a evaluar
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("estandares-minimos")]
        public HttpResponseMessage ObtenerEstandarPorCiclo(int idCiclo, string NIT, string IdEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                int IdEvalInt = 0;
                if (int.TryParse(IdEval, out IdEvalInt))
                {
                }
                var Estandares = logica.ObtenerEstandaresPorCiclo(idCiclo, NIT, IdEvalInt);
                if (Estandares != null)
                {
                    response = Request.CreateResponse<EDCiclo>(HttpStatusCode.OK, Estandares);
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
        [ActionName("estandares-minimos")]
        public HttpResponseMessage GuardarEvaluacionEstandares(EDEvaluacionEstandarMinimo EvaluacionEstandar)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var result = logica.GuardarEvaluacionEstandar(EvaluacionEstandar);

                response = Request.CreateResponse<EDCiclo>(HttpStatusCode.Created, result);
                return response;

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        
        [HttpPost]
        [ActionName("crear-evaluacion")]
        public HttpResponseMessage CrearEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var Respuesta = logica.CrearEvaluacion(EDEvaluacionEmpresa);
                response = Request.CreateResponse(HttpStatusCode.OK, Respuesta);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
        [HttpPost]
        [ActionName("eliminar-evaluacion")]
        public HttpResponseMessage EliminarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var actividades = logica.EliminarEvaluacion(EDEvaluacionEmpresa);
                response = Request.CreateResponse(HttpStatusCode.OK, actividades);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpGet]
        [ActionName("obtener-evaluaciones")]
        public HttpResponseMessage ObtenerEvaluaaciones(int IdEmpresa)
        {
            try
            {
                var logica = new LNEvaluacionStandMinimos();
                var result = logica.ListaEvaluaciones(IdEmpresa);
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
        [ActionName("cerrar-evaluacion")]
        public HttpResponseMessage CerrarEvaluacion(int idEval, int idempresa)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var cerrado = logica.CerrarEvaluacion(idEval, idempresa);
                response = Request.CreateResponse(HttpStatusCode.OK, cerrado);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpGet]
        [ActionName("obtener-evaluaciones")]
        public HttpResponseMessage VerificarEstado(int Ideval)
        {
            try
            {
                var logica = new LNEvaluacionStandMinimos();
                var Respuesta = logica.VerificarCambiarEstado(Ideval);
                var response = Request.CreateResponse(HttpStatusCode.OK, Respuesta);
                return response;
            }
            catch (Exception ex)
            {
                var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpGet]
        [ActionName("estandares-minimos-consulta")]
        public HttpResponseMessage ObtenerCriterioConsulta(int idCiclo, string NIT, string IdEval, int idElemento, bool tipo)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                int IdEvalInt = 0;
                if (int.TryParse(IdEval, out IdEvalInt))
                {
                }
                EDCiclo EDCiclo = new EDCiclo();
                if (tipo)
                {
                    EDCiclo = logica.ObtenerEstandaresPorCicloConsulta1(idCiclo, NIT, IdEvalInt, idElemento);
                }
                else
                {
                    EDCiclo = logica.ObtenerEstandaresPorCicloConsulta(idCiclo, NIT, IdEvalInt, idElemento);
                }


                if (EDCiclo != null)
                {
                    response = Request.CreateResponse<EDCiclo>(HttpStatusCode.OK, EDCiclo);
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
        [ActionName("estandares-minimos-consulta")]
        public HttpResponseMessage EditarEvaluacionEstandares(EDEvaluacionEstandarMinimo EvaluacionEstandar)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var result = logica.EditarEvaluacionEstandar(EvaluacionEstandar);
                response = Request.CreateResponse<EDCiclo>(HttpStatusCode.Created, result);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }
        [HttpGet]
        [ActionName("estandares-minimos-consulta")]
        public HttpResponseMessage ObtenerCriterios(int idCiclo, string NIT, string IdEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                int IdEvalInt = 0;
                if (int.TryParse(IdEval, out IdEvalInt))
                {
                }
                var Estandares = logica.ListaEstandarEditar(idCiclo, NIT, IdEvalInt);
                if (Estandares != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Estandares);
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
        [ActionName("estandares-minimos-consulta")]
        public HttpResponseMessage ObtenerEvaluacion(string NIT, string IdEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                int IdEvalInt = 0;
                if (int.TryParse(IdEval, out IdEvalInt))
                {
                }
                var Estandares = logica.EvaluacionCompleta(NIT, IdEvalInt);
                if (Estandares != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Estandares);
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
        [ActionName("estandares-minimos-consulta")]
        public HttpResponseMessage ObtenerEvaluaciones(int Idempresa, int IdEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var Estandares = logica.Evaluacion(Idempresa, IdEval);
                if (Estandares != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Estandares);
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
        //cambio123
        [HttpGet]
        [ActionName("Obtener-Empresa-Evaluar")]
        public HttpResponseMessage ObtenerEmpresaEvaluar(string Nit, string Responsable)
        {
            try
            {
                var logica = new LNEmpresa();
                var result = logica.ObtenerDatosEmpresaEvaluar(Nit, Responsable);
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
        [ActionName("calificacion-estandares-minimos")]
        public HttpResponseMessage ObtenerCalificacionFinalEstandares(string NIT, string IdEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                int IdEvalInt = 0;
                if (int.TryParse(IdEval, out IdEvalInt))
                {
                }
                var calificacion = logica.ObtenerCalificacionFinal(NIT, IdEvalInt);
                if (calificacion != null)
                {
                    response = Request.CreateResponse<EDValoracionFinal>(HttpStatusCode.OK, calificacion);
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
        [ActionName("estandares-actividades")]
        public HttpResponseMessage ObtenerActividades(string NIT, int idEval)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var actividades = logica.ObtenerActividades(NIT, idEval);
                if (actividades != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, actividades);
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
        [ActionName("validar-evaluacion")]
        public HttpResponseMessage ValidarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var Respuesta = logica.ValidarEvaluacion(EDEvaluacionEmpresa);
                response = Request.CreateResponse(HttpStatusCode.OK, Respuesta);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
        [HttpPost]
        [ActionName("validar-criterio")]
        public HttpResponseMessage ValidarEvaluacionCriterio(EDEvaluacionEmpresa EDEvaluacionEmpresa)
        {
            HttpResponseMessage response = null;
            try
            {
                LNEvaluacionStandMinimos logica = new LNEvaluacionStandMinimos();
                var Respuesta = logica.verificarcriterio( EDEvaluacionEmpresa.Estado, EDEvaluacionEmpresa.Pk_Id_EvaluacionEmpresa);
                response = Request.CreateResponse(HttpStatusCode.OK, Respuesta);
                return response;
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                return response;
            }
        }
        #endregion
    }
}
