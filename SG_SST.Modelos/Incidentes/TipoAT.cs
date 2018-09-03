using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Tipo_AT")]
    public class TipoAT
    {
        [Key]
        public int PK_Tipo_AT { get; set; }
        public string Descripcion_Tipo_AT { get; set; }
    }
}
