using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
   public class EDCarguePlanEmergencia
    {
       public string path { get; set; }

       public string NitEmpresa { get; set; }

       public int idSede { get; set; }

       public string Message { get; set; }

       public string SiglaTipoDocumentoEmpresa { get; set; }

       public string rutaServicio { get; set; }
    }
}
