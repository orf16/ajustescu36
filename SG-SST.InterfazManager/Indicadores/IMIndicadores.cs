using SG_SST.Interfaces.Indicadores;
using SG_SST.Repositorio.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.InterfazManager.Indicadores
{
    public class IMIndicadores
    {
        public static IIndicadores Indicadores()
        {
            return new IndicadoresManager();
        }

    }
}
