using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_IncidentesEL7")]
    public class IncidentesEL7
    {
        [Key]
        public int PK_Incidentes_EL7 { get; set; }
        public int FK_Incidentes_EL7 { get; set; }
        public string MedidasPreventivasVII1 { get; set; }
        public string ResponsableImplementacionVII1 { get; set; }
        public string FechaEjeMesVII1 { get; set; }
        public string FechaEjeDiaVII1 { get; set; }

        public string MedidasPreventivasVII2 { get; set; }
        public string ResponsableImplementacionVII2 { get; set; }
        public string FechaEjeMesVII2 { get; set; }
        public string FechaEjeDiaVII2 { get; set; }

        public string MedidasPreventivasVII3 { get; set; }
        public string ResponsableImplementacionVII3 { get; set; }
        public string FechaEjeMesVII3 { get; set; }
        public string FechaEjeDiaVII3 { get; set; }

        public string MedidasPreventivasVII4 { get; set; }
        public string ResponsableImplementacionVII4 { get; set; }
        public string FechaEjeMesVII4 { get; set; }
        public string FechaEjeDiaVII4 { get; set; }

        public string MedidasPreventivasVII5 { get; set; }
        public string ResponsableImplementacionVII5 { get; set; }
        public string FechaEjeMesVII5 { get; set; }
        public string FechaEjeDiaVII5 { get; set; }

        public string MedidasPreventivasVII6 { get; set; }
        public string ResponsableImplementacionVII6 { get; set; }
        public string FechaEjeMesVII6 { get; set; }
        public string FechaEjeDiaVII6 { get; set; }

        public string MedidasPreventivasVII7 { get; set; }
        public string ResponsableImplementacionVII7 { get; set; }
        public string FechaEjeMesVII7 { get; set; }
        public string FechaEjeDiaVII7 { get; set; }

        public string MedidasPreventivasVII8 { get; set; }
        public string ResponsableImplementacionVII8 { get; set; }
        public string FechaEjeMesVII8 { get; set; }
        public string FechaEjeDiaVII8 { get; set; }
        public string NitEmpresa { get; set; }
    }
}
