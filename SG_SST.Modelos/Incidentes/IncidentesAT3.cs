using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT3")]
    public class IncidentesAT3
    {
        [Key]
        public int PK_Incidentes_AT3 { get; set; }
        public int FK_incidentes_AT3 { get; set; }
        public string boTipoVinculacionIII { get; set; }
        public string tempTipoIdentificacionIII { get; set; }
        public string NumeroIdentificacionIII { get; set; }
        public string PrimerApellidoIII { get; set; }
        public string SegundoApellidoIII { get; set; }
        public string PrimerNombreIII { get; set; }
        public string FechaNacimientoIII { get; set; }
        public string DepartamentoIII { get; set; }
        public string MunicipioIII { get; set; }

        public string SexoIII { get; set; }
        public string EPSIII { get; set; }
        public string AFPIII { get; set; }
        public string ARLIII { get; set; }
        public string TelefonoIII { get; set; }
        public string FaxIII { get; set; }
        public string EmailIII { get; set; }
        public string DireccionCentroTrabajoIII { get; set; }
        public string ZonaIII { get; set; }
        public string CargoIII { get; set; }
        public string OcupacionIII { get; set; }
        public string FechaIngresoIII { get; set; }
        public string TiempoOcupacionAIII { get; set; }
        public string TiempoOcupacionMIII { get; set; }
        public string AntiguedadAIII { get; set; }
        public string AntiguedadMIII { get; set; }
        public string boJornadaIII { get; set; }
        public string SalarioHonorariosIII { get; set; }
        public string FechaMuerteIII { get; set; }
        public string AtencionOportunaIII { get; set; }
        public string SegundoNombreIII { get; set; }
        public string CodigoOcupacionIII { get; set; }
        public string AtencionOportunaOtrosIII { get; set; }
        public string NitEmpresa { get; set; }
    }
}
