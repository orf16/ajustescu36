using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL2")]
    public class IncidentesEL2
    {
        [Key]
        public int PK_Incidentes_EL2 { get; set; }
        public int FK_Incidentes_EL2 { get; set; }
        public string EmpleadorII { get; set; }
        public string CodActividadII { get; set; }
        public string ActividadPrincipalII { get; set; }
        public string RazonSocialII { get; set; }
        public string TipoIdentificacionII { get; set; }
        public string NumIdentificacionII { get; set; }
        public string DireccionPrincipalII { get; set; }
        public string TelefonoPpalII { get; set; }
        public string FaxII { get; set; }
        public string DeptoPpalII { get; set; }
        public string McpioPpalII { get; set; }
        public string EmailII { get; set; }
        public string ZonaPpalII { get; set; }
        public string CentroTrabajoPpalII { get; set; }
        public string CentroCostoTelefonoII { get; set; }
        public string CentroCostoFaxII { get; set; }
        public string CodActEconoPpalII { get; set; }
        public string ActEconoCentroTrabajoII { get; set; }
        public string DeptoEmpleadorII { get; set; }
        public string McpioEmpleadorII { get; set; }
        public string EmailEmpleadorII { get; set; }
        public string ZonaEmpleadorII { get; set; }
        public string DeptoCentroTrabajoII { get; set; }
        public string McpioCentroTrabajoII { get; set; }
        public string DireccionCentroTrabajoII { get; set; }
        public string NitEmpresa { get; set; }
    }
}
