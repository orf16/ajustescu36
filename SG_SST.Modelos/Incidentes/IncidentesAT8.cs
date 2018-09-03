using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT8")]
    public class IncidentesAT8
    {
        [Key]
        public int PK_Incidentes_AT8 { get; set; }
        public int FK_incidentes_AT8 { get; set; }
        public string NitEmpresa { get; set; }
        public string myFile8 { get; set; }
    }
}
