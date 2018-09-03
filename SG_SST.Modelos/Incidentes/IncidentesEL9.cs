using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
     [Table("Tbl_IncidentesEL9")]
    public class IncidentesEL9
    {
        [Key]
        public int PK_Incidentes_EL9 { get; set; }
        public int FK_Incidentes_EL9 { get; set; }
        public string FechaRemisionIX { get; set; }
        public string NoFoliosIX { get; set; }
        public string tempTipoIdentificacionIX { get; set; }
        public string NombreApellidoIX { get; set; }
        public string CargoIX { get; set; }
        public string NumeroIdentificacionIX { get; set; }

        public string FechaRemisionARLIX { get; set; }
        public string FecRemisionTerritorialIX { get; set; }
        public string DisponibleRemisionARLIX { get; set; }
        public string ResponsablesRemisionARLIX { get; set; }
        public string CargoARLIX { get; set; }
        public string myFile10 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
