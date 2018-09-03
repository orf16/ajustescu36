using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT5")]
    public class IncidentesAT5
    {
        [Key]
        public int PK_Incidentes_AT5 { get; set; }
        public int FK_incidentes_AT5 { get; set; }
        public string EventosSimilaresV { get; set; }
        public string NumeroPersonasV { get; set; }
        public string OtrosIncidentesV { get; set; }
        public string EventoSimilarV { get; set; }
        public string CondicionPrioritariaV { get; set; }
        public string TrabajadorInvolucradoV { get; set; }
        public string PanoramaRiesgoV { get; set; }
        public string DescripcionAccidenteV { get; set; }
        public string NitEmpresa { get; set; }
         
    }
}
