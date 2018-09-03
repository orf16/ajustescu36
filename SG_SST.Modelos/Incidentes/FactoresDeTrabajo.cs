using
System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Factores_De_Trabajo")]
    public class FactoresDeTrabajo
    {
        [Key]
        public int PK_Factores_De_Trabajo { get; set; }
        public string Descripcion_FDT { get; set; }

    }
}
