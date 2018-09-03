using SG_SST.EntidadesDominio.Ausentismo;
using SG_SST.EntidadesDominio.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Planificacion
{
    public interface IEvaluacionEstandMinimos
    {
        List<EDCiclo> ObtenerCiclos();
        bool CrearEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa);
        bool ValidarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa);
        EDCiclo ObtenerStandares(int idCiclo);
        EDCiclo ObtenerEstandarPorCicloG(int idCiclo, int idCriterioActual, int idEmpres);
        EDCiclo ObtenerEstandarPorCicloSiguiente(int ideval, string NIT);
        EDCiclo ObtenerEstandarPorCiclo(int idCiclo, string Nit, int IdEval);
        EDEvaluacionEstandarMinimo GuardarEvaluacionEstandar(EDEvaluacionEstandarMinimo EvaluacionEstandar);
        int ObtenerCantidaEstdPorEvaluas(int idCiclo, string Nit, int IdEval);
        int ObtenerCantidaEstdPorEvaluas(int idCiclo, int idEmpresa, int IdEval);
        int ObtenerCantidadCriteriosPorEstandar(int idClico);
        EDValoracionFinal ObtenerCalificacion(string Nit, int IdEval);
        List<EDCiclo> ObtenerDatosInformeExcel(string Nit, int IdEval);
        List<EDCiclo> ObtenerDatosInicialesInformeExcel();
        List<EDActividad> ObtenerActividades(string Nit, int IdEval);
        List<EDEvaluacionEmpresa> ListaEvaluaciones(int idEmpresa);
        EDEstandar ObtenerCantidaEstdPorEvaluasCons(int IdCriterio, int IdEval);
        EDEvaluacionEstandarMinimo EditarEvaluacionEstandar(EDEvaluacionEstandarMinimo EvaluacionEdicion);
        List<EDEstandar> ListaEstandarEditar(int idCiclo, string Nit, int IdEval);
        List<int> ListaCriteriosAnteriores(int IdEval, int Ciclo);
        List<EDEvaluacionEmpresa> EvaluacionCompleta(string Nit, int IdEval);
        List<EDEvaluacionEmpresa> Evaluacion(int Idempresa, int IdEval);
        bool EliminarEvaluacion(EDEvaluacionEmpresa EDEvaluacionEmpresa);
        EDCiclo ObtenerEstandarPorCiclo1(int idCiclo, string Nit, int IdEval);
        int VerificarCambiarEstado(int ideval);
        string CerrarEvaluacion(int IdEval, int idempresa);
        decimal ObtenerPorcentajeObtenidoAlmomento(int idCclo, string Nit, int Ideval);
        List<EDEvaluacionEmpresa> ObtenerCalificacionEstandresPorClicloComparar(string Nit, int fi, int ff);
        EDEmpresa Identidadempresa(string Nit);
        EDEvaluacionEmpresa ObtenerVigenciayFechaElab(string Nit, int IdEval);
        bool verificarcriterio(int idCriterio, int idEvaluacionEmpresa);
    }
}
