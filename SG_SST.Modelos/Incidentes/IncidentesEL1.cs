using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL1")]
    public class IncidentesEL1
    {
        [Key]
        public int PK_Incidentes_EL { get; set; }
        public string EnfLabCalificadaI { get; set; }
        public DateTime FechaInvestigacionI { get; set; }
        public string HoraInicioI { get; set; }
        public string HoraFinI { get; set; }
        public string DepartamentoI { get; set; }
        public string MunicipioI { get; set; }
        public string DireccionI { get; set; }
        public string NombresApellidosI { get; set; }
        public string ProfesionalI { get; set; }
        public string NoLicenciaI { get; set; }
        public string FotografiasI { get; set; }
        public string VideosI { get; set; }
        public string CintasAudioI { get; set; }
        public string IlustracionesI { get; set; }
        public string DiagramasI { get; set; }
        public string OtrosCualesI { get; set; }
        public string myFile1 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
