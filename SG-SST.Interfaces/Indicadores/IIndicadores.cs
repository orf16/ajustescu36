using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Indicadores
{
    public interface IIndicadores
    {
        List<decimal> ObtenerResultadoEstandaresMinimos(string nitEmpresa);

        decimal? ObtenerResultadoFrecuenciaAusentismo(string nitEmpresa);

        decimal? ObtenerResultadoCumplimientoRequisitosLegales(string nitEmpresa);

        decimal? ObtenerResultadoCapacitacionEntrenamiento(string nitEmpresa);

        decimal? ObtenerResultadoCondicionActoInseguro(string nitEmpresa);

        int? ObtenerResultadoComiteCoppast(string nitEmpresa);

        int? ObtenerResultadoComiteConvivenciaLaboral(string nitEmpresa);

        decimal? ObtenerResultadoPlanTrabajoAnual(string nitEmpresa);

        decimal? ObtenerResultadoReporteSST(string nitEmpresa);

        decimal? ObtenerResultadoPerfilSocioDemografico(string nitEmpresa);

        decimal? ObtenerResultadoTasaAccidentalidad(string nitEmpresa);

    }
}
