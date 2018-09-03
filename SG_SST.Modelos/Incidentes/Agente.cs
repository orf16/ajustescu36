using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Agente")]
    public class Agente
    {
        [Key]
        public int PK_Agente { get; set; }
        public string Descripcion_Agente { get; set; }
    }
}
