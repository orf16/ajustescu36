using SG_SST.EntidadesDominio.Planificacion;
using SG_SST.Interfaces.Planificacion;
using SG_SST.InterfazManager.Planificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Logica.Planificacion
{
    public class LNMetasIndicadores
    {
        private static IMetasIndicadores em = IMMetasIndicadores.MetasIndicadores();

        public List<EDIndicador> ObtenerIndicadoresPorTipo(string tipo)
        {
            return em.ObtenerIndicadoresPorTipo(tipo);
        }

        public EDIndicador ObtenerIndicadorPorId(int IdIndicador)
        {
            return em.ObtenerIndicadorPorId(IdIndicador);
        }

        public List<EDMetaIndicador> ObtenerMetasIndicadoresPorEmpresa(int id)
        {
            return em.ObtenerMetasIndicadoresPorEmpresa(id);
        }

        public EDMetaIndicador ObtenerMetaIndicadorPorId(int id)
        {
            return em.ObtenerMetaIndicadorPorId(id);
        }

        public EDMetaIndicador GuardarMetaIndicador(EDMetaIndicador metaInd)
        {
            return em.GuardarMetaIndicador(metaInd);
        }

        public EDMetaIndicador ModificarMetaIndicador(EDMetaIndicador metaInd)
        {
            return em.ModificarMetaIndicador(metaInd);
        }

        public List<EDMetaIndicador> EliminarMetaIndicador(int IdMetaInd, int IdEmpresa)
        {
            return em.EliminarMetaIndicador(IdMetaInd, IdEmpresa);
        }

        public EDMetaIndicador ObtenerMetaIndicadorPorNombreIndicadorYEmpresa(string indicador, int id)
        {
            return em.ObtenerMetaIndicadorPorNombreIndicadorYEmpresa(indicador, id);
        }
    }
}
