using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_FactoresPersonales")]
    public class FactoresPersonales
    {
        [Key]
        public int PK_FactoresPersonales { get; set; }
        public string Descripcion_FP { get; set;  }

    }
}
