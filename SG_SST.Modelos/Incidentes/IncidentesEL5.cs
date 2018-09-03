using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL5")]
    public class IncidentesEL5
    {
        [Key]
        public int PK_Incidentes_EL5 { get; set; }
        public int FK_Incidentes_EL5 { get; set; }
        public string FechaOrigenELV { get; set; }
        public string OrigenLaboralV { get; set; }
        public string NoTrabajadoresV { get; set; }
        public string CargosSimilaresV { get; set; }
        public string NombresApellidosV1 { get; set; }
        public string NombresApellidosV2 { get; set; }
        public string NombresApellidosV3 { get; set; }
        public string NombresApellidosV4 { get; set; }
        public string AnioDiagnosticoV1 { get; set; }
        public string AnioDiagnosticoV2 { get; set; }
        public string AnioDiagnosticoV3 { get; set; }
        public string AnioDiagnosticoV4 { get; set; }
        public string NombresApellidosV5 { get; set; }
        public string NoTrabajadoresCargos { get; set; }
        public string CodigoCieCIEV { get; set; }
        public string DiagnosticosCIEV { get; set; }

        public string CodigoCie1 { get; set; }
        public string CodigoCie2 { get; set; }
        public string CodigoCie3 { get; set; }
        public string CodigoCie4 { get; set; }
        public string DiagnosticoIV1 { get; set; }
        public string DiagnosticoIV2 { get; set; }
        public string DiagnosticoIV3 { get; set; }
        public string DiagnosticoIV4 { get; set; }


        public string FechaOrigenELIV { get; set; }
        public string OrigenLaboralIV { get; set; }

        public string NitEmpresa { get; set; }
    }
}
