using SG_SST.Models.Empresas;
using SG_SST.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Auditoria
{
    [Table("Tbl_RegistroIngresoSistema")]
    public class RegistroIngresoSistema
    {
        [Key]
        public int PK_Id_RegistroIngresoSistema { get; set; }

        [ForeignKey("Tbl_Empresa")]
        public int FK_Empresa { get; set; }
        /// <summary>
        /// Obtiene y establece un objeto de tipo empresa
        /// </summary>
        [ForeignKey("Pk_Id_Empresa")]
        public virtual Empresa Tbl_Empresa { get; set; }

        [ForeignKey("Tbl_UsuarioSistema")]
        public int FK_UsuarioSistema { get; set; }
        /// <summary>
        /// Obtiene y establece un objeto de tipo empresa
        /// </summary>
        [ForeignKey("Pk_Id_UsuarioSistema")]
        public virtual UsuarioSistema Tbl_UsuarioSistema { get; set; }

        public DateTime FechaTransaccion { get; set; }
    }
}
