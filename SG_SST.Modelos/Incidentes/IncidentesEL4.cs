using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL4")]
    public class IncidentesEL4
    {
        [Key]
        public int PK_Incidentes_EL4 { get; set; }
        public int FK_Incidentes_EL4 { get; set; }
        public string CargoIV { get; set; }
        public string AntiguedadCargoAIV { get; set; }
        public string AntiguedadCargoMIV { get; set; }
        public string TiempoOcupacionAniosIV { get; set; }
        public string TiempoOcupacionMesesIV { get; set; }
        public string CodOcupacionIV { get; set; }
        public string OcupacionHabitualIV { get; set; }
        public string MurioTrabajadorIV { get; set; }
        public string FechaMuerteIV { get; set; }
        public string AreaActualIV { get; set; }
        public string NombreCargoIV { get; set; }
        public string AntiguedadCargoAnioIV { get; set; }
        public string AntiguedadCargoMesesIV { get; set; }
        public string DiurnoIV { get; set; }
        public string NocturnoIV { get; set; }
        public string MixtoIV { get; set; }
        public string TurnosIV { get; set; }
        public string CondicionesPuestoTrabajoIV { get; set; }
        public string FechaIngresoIV { get; set; }
        public string TareasCargo1IV { get; set; }
        public string DedicacionJL1IV { get; set; }
        public string DedicacionJL11IV { get; set; }
        public string DedicacionJL12IV { get; set; }
        public string RelacionMuyProbable1IV { get; set; }
        public string RelacionProbable1IV { get; set; }
        public string RelacionPocoProbable1IV { get; set; }
        public string DedicacionJL21IV { get; set; }
        public string DedicacionJL22IV { get; set; }
        public string DedicacionJL23IV { get; set; }
        public string RelacionMuyProbable2IV { get; set; }
        public string RelacionProbable2IV { get; set; }
        public string RelacionPocoProbable2IV { get; set; }

        public string TareasCargo3IV { get; set; }
        public string DedicacionJL31IV { get; set; }
        public string DedicacionJL32IV { get; set; }
        public string DedicacionJL33IV { get; set; }
        public string RelacionMuyProbable3IV { get; set; }
        public string RelacionProbable3IV { get; set; }
        public string RelacionPocoProbable3IV { get; set; }
        public string CodigoCie5 { get; set; }
        public string TareasCargo4IV { get; set; }
        public string DedicacionJL41IV { get; set; }
        public string DedicacionJL42IV { get; set; }
        public string DedicacionJL43IV { get; set; }
        public string RelacionMuyProbable4IV { get; set; }
        public string RelacionProbable4IV { get; set; }
        public string RelacionPocoProbable4IV { get; set; }
        public string TareasCargo2IV { get; set; }

        public string PreventivasIV { get; set; }
        public string ImplementadasIV { get; set; }
        public string DescripcionIV { get; set; }
        public string NoHabitualesIV { get; set; }

        public string CodigoCie1 { get; set; }
        public string CodigoCie2 { get; set; }
        public string CodigoCie3 { get; set; }
        public string CodigoCie4 { get; set; }
        public string DiagnosticoIV1 { get; set; }
        public string DiagnosticoIV2 { get; set; }
        public string DiagnosticoIV3 { get; set; }
        public string DiagnosticoIV4 { get; set; }
        public string FormacionInformacionIV { get; set; }
        public string ProteccionColectivaIV { get; set; }
        public string EPPIV { get; set; }
        public string DisenoPuestoTrabajoIV { get; set; }
        public string tempOrganizacionTrabajoIV { get; set; }
        public string ObservacionesIV { get; set; }
        public string DiurnoIV2 { get; set; }
        public string NocturnoIV2 { get; set; }
        public string MixtoIV2 { get; set; }
        public string TurnosIV2 { get; set; }
        public string FechaOrigenELIV { get; set; }

        
        public string NitEmpresa { get; set; }
    }
}
