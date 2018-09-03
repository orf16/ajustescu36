using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SG_SST.Models.Incidentes
{
    public class ConsultasIncidentesModel
    {
        public int pk_id_incidente { get; set; }
        public DateTime fechainvestigacion { get; set; }

    }


    public class RetornoIncidentesModel
    {
        public int pk_id_incidente { get; set; }
        public string fechainvestigacion { get; set; }

    }
}