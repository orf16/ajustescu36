using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesAT11")]
    public class IncidentesAT11
    {
        [Key]
        public int PK_Incidentes_AT11 { get; set; }
        public int FK_incidentes_AT11 { get; set; }
        public string FechaRemisionXI { get; set; }
        public string NoFoliosXI { get; set; }
        public string TipoIdentificacionXI { get; set; }
        public string NumeroIdentificacionXI { get; set; }
        public string NombresXI { get; set; }
        public string CargoXI { get; set; }
        public string RecomendacionesARLXI { get; set; }
        public string RemisionInformeARLXI { get; set; }
        public string RemisionMinisterioTrabajoXI { get; set; }
        public string RecomendacionesCargoXI { get; set; }
        public string myFile11 { get; set; }
        public string NitEmpresa { get; set; }

    }
}
