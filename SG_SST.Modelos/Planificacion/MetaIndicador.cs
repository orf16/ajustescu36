using SG_SST.Models.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Planificacion
{
    [Table("Tbl_MetaIndicador")]
    public class MetaIndicador
    {
        [Key]
        public int PK_Id_MetaIndicador { get; set; }

        [ForeignKey("Tbl_Empresa")]
        public int FK_Empresa { get; set; }
        /// <summary>
        /// Obtiene y establece un objeto de tipo empresa
        /// </summary>
        [ForeignKey("Pk_Id_Empresa")]
        public virtual Empresa Tbl_Empresa { get; set; }

        [ForeignKey("Tbl_Indicador")]
        public int FK_Indicador { get; set; }
        /// <summary>
        /// Obtiene y establece un objeto de tipo indicador
        /// </summary>
        [ForeignKey("PK_Id_Indicador")]
        public virtual Indicador Tbl_Indicador { get; set; }

        public decimal ValorMeta { get; set; }

        public decimal ValorRojo { get; set; }

        public decimal ValorAmarillo { get; set; }

        public decimal ValorVerde { get; set; }



    }
}
