using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Actos_Subestandar")]
    public class ActosSubestandar
    {
        [Key]
        public int PK_Actos_Subestandar { get; set; }
        public string Descripcion_AS { get; set; }
    }
}
