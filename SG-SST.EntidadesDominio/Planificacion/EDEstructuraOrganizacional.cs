using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
 public   class EDEstructuraOrganizacional
    {
        public int id_EstucturaOrg { get; set; }


        public int fk_id_sede { get; set; }

        public string Jefe_Estructura { get; set; }


        public string cargo_Empleado { get; set; }


        public int? Fk_Id_EstructuraOrg { get; set; }

    }
}
