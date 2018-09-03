using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
    public class EDMetaIndicador
    {
        public int PK_Id_MetaIndicador { get; set; }

        public int FK_Empresa { get; set; }

        public int FK_Indicador { get; set; }

        public decimal ValorMeta { get; set; }

        public decimal ValorRojo { get; set; }

        public decimal ValorAmarillo { get; set; }

        public decimal ValorVerde { get; set; }

        public decimal ValorResultado { get; set; }

        public string ValorMetaString { get; set; }

        public string ValorRojoString { get; set; }

        public string ValorAmarilloString { get; set; }

        public string ValorVerdeString { get; set; }

        public EDIndicador Indicador { get; set; }

    }
}
