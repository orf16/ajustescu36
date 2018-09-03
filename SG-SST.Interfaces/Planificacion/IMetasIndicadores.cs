using SG_SST.EntidadesDominio.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Interfaces.Planificacion
{
    public interface IMetasIndicadores
    {
        List<EDIndicador> ObtenerIndicadoresPorTipo(string tipo);

        EDIndicador ObtenerIndicadorPorId(int IdIndicador);

        List<EDMetaIndicador> ObtenerMetasIndicadoresPorEmpresa(int id);

        EDMetaIndicador ObtenerMetaIndicadorPorId(int id);

        EDMetaIndicador GuardarMetaIndicador(EDMetaIndicador metaInd);

        EDMetaIndicador ModificarMetaIndicador(EDMetaIndicador metaInd);

        List<EDMetaIndicador> EliminarMetaIndicador(int IdMetaInd, int IdEmpresa);

        EDMetaIndicador ObtenerMetaIndicadorPorNombreIndicadorYEmpresa(string indicador, int id);
    }
}
