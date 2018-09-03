using SG_SST.Models.Empresas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Usuarios
{
    [Table("Tbl_RecursosDenegadosPorRol")]
    public class RecursoDenegadoPorRol
    {
        [Key]
        public int Pk_Id_RecursoDenegadoPorRol { get; set; }

        [ForeignKey("RolSistema")]
        public int Fk_Id_RolSistema { get; set; }

        [ForeignKey("RecursoSistema")]
        public int Fk_Id_Recurso { get; set; }

        [ForeignKey("Empresa")]
        public int Fk_Id_Empresa { get; set; }
        public string DocumentoAsesorSST { get; set; }

        [ForeignKey("Pk_Id_RolSistema")]
        public virtual RolSistema RolSistema { get; set; }

        [ForeignKey("Pk_Id_RecursoSistema")]
        public virtual RecursoSistema RecursoSistema { get; set; }

        [ForeignKey("Pk_Id_Empresa")]
        public virtual Empresa Empresa { get; set; }
    }
}
