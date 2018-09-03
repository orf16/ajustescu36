using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL10")]
    public class IncidentesEL10
    {
        [Key]
        public int PK_Incidentes_EL10 { get; set; }
        public int FK_Incidentes_EL10 { get; set; }
        public string tempTipoIdentificacionX { get; set; }
        public string ResponsableVerficiacionX { get; set; }
        public string CargoX { get; set; }
        public string NumeroIdentificacionX { get; set; }
        public string MedidasIntervencionX { get; set; }
        public string ObsevacionesX { get; set; }
        public string FechaVerficacionX { get; set; }
        public string ObservacionesX { get; set; }
        public string myFile11 { get; set; }
        public string tempTipoIdentificacionXI { get; set; }
        public string ResponsableVerficiacionXI { get; set; }
        public string CargoXI { get; set; }
        public string NumeroIdentificacionXI { get; set; }
        public string MedidasIntervencionXI { get; set; }
        public string ObsevacionesARLXI { get; set; }
        public string FechaVerficacionXI { get; set; }
        public string myFile12 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
