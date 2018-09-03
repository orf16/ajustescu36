
using SG_SST.Models.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT13")]
    public class IncidentesAT13
    {

        [Key]
        public int PK_Incidentes_AT13 { get; set; }
        public int FK_incidentes_AT13 { get; set; }
        public string TipoIdentificacionXIII { get; set; }
        public string NombresXIII { get; set; }
        public string CargoXIII { get; set; }
        public string NumeroIdentificacionXIII { get; set; }
        public string MedidasIntervencionXIII { get; set; }
        public string FechaVerificacionXIII { get; set; }
        public string ObservacionesXIII { get; set; }
        public string myFile13 { get; set; }
        public string NitEmpresa { get; set; }

    }
}
