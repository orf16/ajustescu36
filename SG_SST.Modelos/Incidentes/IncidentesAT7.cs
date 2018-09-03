using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT7")]
    public class IncidentesAT7
    {
        [Key]
        public int PK_Incidentes_AT7 { get; set; }
        public int FK_incidentes_AT7 { get; set; }
        public string CodTipoLesionVII { get; set; }
        public string TipoLesionVII { get; set; }
        public string CodigoParteCuerpoAfectadaVII { get; set; }
        public string CodMecaAccideneteVII { get; set; }
        public string MecanismoAccidenteVII { get; set; }
        public string CodAgenteAccideneteVII { get; set; }
        public string AgenteAccidenteVII { get; set; }
        public string CodFactoresPersonalesVII1 { get; set; }
        public string FactoresPersonalesVII1 { get; set; }
        public string CodFactoresPersonalesVII2 { get; set; }
        public string CodActFactoresPersonalesVII2 { get; set; }
        public string ActFactoresPersonalesVII2 { get; set; }
        public string CodActoSubestandarVII1 { get; set; }
        public string ActosSubestandarVII1 { get; set; }
        public string CodActoSubestandarVII2 { get; set; }
        public string ActosSubestandarVII2 { get; set; }
        public string CodFactoresTrabajoVII1 { get; set; }
        public string FactoresTrabajoVII1 { get; set; }
        public string CodFactoresTrabajoVII2 { get; set; }
        public string FactoresTrabajoVII2 { get; set; }
        public string CodCondAmbientalesVII1 { get; set; }
        public string CondAmbientalesVII1 { get; set; }
        public string CodCondAmbientalesVII2 { get; set; }
        public string CondAmbientalesVII2 { get; set; }
        public string textfield74 { get; set; }
        public string FactoresPersonalesVII2 { get; set; }

        public string NitEmpresa { get; set; }

    }
}
