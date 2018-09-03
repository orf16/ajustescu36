using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
    public class EDActividad
    {
        public int Id_Actividad { get; set; }
        public string Descripcion { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaFin { get; set; }
        public string FechaFinString { get; set; }


        public string Accion { get; set; }
        public string Id_Actividad_String { get; set; }
        public string Vigencia { get; set; }
    }
}
