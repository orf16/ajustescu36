using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.EntidadesDominio.Planificacion
{
    public class EDDatosCarguePlanEmergencia
    {
        public int idSede { get; set; }
        public string nombreCompleto { get; set; }

        public string numeroDocumeto { get; set; }
        public string genero { get; set; }
        public string eps { get; set; }
        public string rh { get; set; }
    
        public string paremtescoContacto { get; set; }

        public string requiereManejo { get; set; }

        public string cual { get; set; }

        public string entidad { get; set; }

        public string direccion { get; set; }

        public string telefonoContacto { get; set; }

        public string nombreContacto{ get; set; }

        public string empresaParticipante { get; set; }

        public string recursoDisposicion { get; set; }

        public string compesacionEconomica { get; set; }

        public string reintegroRecurso { get; set; }

        public string nitEmpresa { get; set; }
    }
}
