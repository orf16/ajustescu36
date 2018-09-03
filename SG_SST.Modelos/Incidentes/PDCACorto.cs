using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_PDCA_Corto")]
    public class PDCACorto
    {
        [Key]
        public int PK_PDCA_Corto { get; set; }
        public string Descripcion_PDCA_Corto { get; set; }
    }
}
