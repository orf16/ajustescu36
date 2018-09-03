using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT12")]
    public class IncidentesAT12
    {
        [Key]
        public int PK_Incidentes_AT12 { get; set; }
        public int FK_incidentes_AT12 { get; set; }
        public string TipoIdentificacionXII { get; set; }
        public string NumeroIdentificacionXII { get; set; }
        public string NombresXII { get; set; }
        public string CargoXII { get; set; }
        public string MedidasIntervencionXII { get; set; }
        public string ObservacionesXII { get; set; }
        public string FechaVerificacionXII { get; set; }
        public string myFile12 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
