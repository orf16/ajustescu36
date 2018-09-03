using SG_SST.Interfaces.Indicadores;
using SG_SST.InterfazManager.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Logica.Indicadores
{
    public class LNIndicadores
    {
        private static IIndicadores em = IMIndicadores.Indicadores();

        public List<decimal> ObtenerResultadoEstandaresMinimos(string nitEmpresa)
        {
            return em.ObtenerResultadoEstandaresMinimos(nitEmpresa);
        }

        public decimal? ObtenerResultadoFrecuenciaAusentismo(string nitEmpresa)
        {
            return em.ObtenerResultadoFrecuenciaAusentismo(nitEmpresa);
        }

        public decimal? ObtenerResultadoCumplimientoRequisitosLegales(string nitEmpresa)
        {
            return em.ObtenerResultadoCumplimientoRequisitosLegales(nitEmpresa);
        }

        public decimal? ObtenerResultadoCapacitacionEntrenamiento(string nitEmpresa)
        {
            return em.ObtenerResultadoCapacitacionEntrenamiento(nitEmpresa);
        }

        public decimal? ObtenerResultadoCondicionActoInseguro(string nitEmpresa)
        {
            return em.ObtenerResultadoCondicionActoInseguro(nitEmpresa);
        }

        public decimal? ObtenerResultadoComiteCoppast(string nitEmpresa)
        {
            return em.ObtenerResultadoComiteCoppast(nitEmpresa);
        }

        public decimal? ObtenerResultadoComiteConvivenciaLaboral(string nitEmpresa)
        {
            return em.ObtenerResultadoComiteConvivenciaLaboral(nitEmpresa);
        }

        public decimal? ObtenerResultadoPlanTrabajoAnual(string nitEmpresa)
        {
            return em.ObtenerResultadoPlanTrabajoAnual(nitEmpresa);
        }

        public decimal? ObtenerResultadoReporteSST(string nitEmpresa)
        {
            return em.ObtenerResultadoReporteSST(nitEmpresa);
        }

        public decimal? ObtenerResultadoPerfilSocioDemografico(string nitEmpresa)
        {
            return em.ObtenerResultadoPerfilSocioDemografico(nitEmpresa);
        }

        public decimal? ObtenerResultadoTasaAccidentalidad(string nitEmpresa)
        {
            return em.ObtenerResultadoTasaAccidentalidad(nitEmpresa);
        }
    }
}
