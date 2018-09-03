using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesATAnexos")]
    public class IncidentesATAnexos
    {
        [Key]
        public int PK_Incidentes_ATAnexos { get; set; }
        public int FK_incidentes_ATAnexos { get; set; }
        public string AnexoFechaIncidente { get; set; }
        public string AnexoFechaTestimonio { get; set; }
        public string AnexoTipoIdentificacion { get; set; }
        public string AnexoNumIdentificacion { get; set; }
        public string AnexoNombres { get; set; }
        public string AnexoCargo { get; set; }
        public string AnexoDondeSucedio { get; set; }
        public string AnexoPrevenir { get; set; }
        public string AnexoAdicionar { get; set; }
        public string AnexoFirma { get; set; }
        public string myFile14 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
