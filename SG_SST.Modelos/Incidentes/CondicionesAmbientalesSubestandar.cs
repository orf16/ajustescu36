using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Incidentes
{
    [Table("Tbl_Condiciones_Ambientales_Subestandar")]
    public class CondicionesAmbientalesSubestandar
    {
        [Key]
        public int PK_Condiciones_Ambientales_Subestandar { get; set; }
        public string Descripcion_CAS { get; set; }
    }
}
