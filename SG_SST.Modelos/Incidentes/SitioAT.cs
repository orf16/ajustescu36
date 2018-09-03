using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Sitio_AT")]
    public class SitioAT
    {
        [Key]
        public int PK_Sitio_AT { get; set; }
        public string Descripcion_Sitio_AT { get; set; }
    }
}
