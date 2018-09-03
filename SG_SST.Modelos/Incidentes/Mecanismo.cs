using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Mecanismo")]
    public class Mecanismo
    {
        [Key]
        public int PK_Mecanismo { get; set; }
        public string Descripcion_Mecanismo { get; set; }
    }
}
