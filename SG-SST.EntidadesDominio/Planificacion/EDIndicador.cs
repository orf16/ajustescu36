using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
    public class EDIndicador
    {
        public int PK_Id_Indicador { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Unidad { get; set; }

        public string Frecuencia { get; set; }
    }
}
