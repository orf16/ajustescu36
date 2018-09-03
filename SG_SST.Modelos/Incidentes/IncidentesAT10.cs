using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT10")]
    public class IncidentesAT10
    {
        [Key]
        public int PK_Incidentes_AT10 { get; set; }
        public int FK_incidentes_AT10 { get; set; }
        public string CausasInmediatasTipoC1X { get; set; }
        public string MedidasIntervencion1X { get; set; }
        public string TipoF1X { get; set; }
        public string RespImplementacion1X { get; set; }
        public string FechaImplementacion1X { get; set; }
        public string CausasInmediatasTipoC2X { get; set; }
        public string MedidasIntervencion2X { get; set; }
        public string TipoF2X { get; set; }
        public string RespImplementacion2X { get; set; }
        public string FechaImplementacion2X { get; set; }

        public string CausasInmediatasTipoC3X { get; set; }
        public string MedidasIntervencion3X { get; set; }
        public string TipoF3X { get; set; }
        public string RespImplementacion3X { get; set; }
        public string FechaImplementacion3X { get; set; }

        public string CausasBasicasTipoC1X { get; set; }
        public string BasicasInmediatas1X { get; set; }
        public string BasicasF1X { get; set; }
        public string BasicasRespImplementacion1X { get; set; }
        public string BasicasFechaImplementacion1X { get; set; }

        public string CausasBasicasTipoC2X { get; set; }
        public string BasicasInmediatas2X { get; set; }
        public string BasicasF2X { get; set; }
        public string BasicasRespImplementacion2X { get; set; }
        public string BasicasFechaImplementacion2X { get; set; }

        public string CausasBasicasTipoC3X { get; set; }
        public string BasicasInmediatas3X { get; set; }
        public string BasicasF3X { get; set; }
        public string BasicasRespImplementacion3X { get; set; }
        public string BasicasFechaImplementacion3X { get; set; }
        public bool boTipoF1X { get; set; }
        public bool boTipoM1X { get; set; }
        public bool boTipoT1X { get; set; }
        public bool boTipoF2X { get; set; }
        public bool boTipoM2X { get; set; }
        public bool boTipoT2X { get; set; }
        public bool boTipoF3X { get; set; }
        public bool boTipoM3X { get; set; }
        public bool boTipoT3X { get; set; }
        public bool boBasicasF1X { get; set; }
        public bool boBasicasM1X { get; set; }
        public bool boBasicasT1X { get; set; }
        public bool boBasicasF2X { get; set; }
        public bool boBasicasM2X { get; set; }
        public bool boBasicasT2X { get; set; }
        public bool boBasicasF3X { get; set; }
        public bool boBasicasM3X { get; set; }
        public bool boBasicasT3X { get; set; }
        public string BasicasT3X { get; set; }
        public string myFile10 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
