using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SST.Models.Usuarios
{
    [Table("Tbl_UsuarioEstados")]
    public class UsuarioEstados
    {
        [Key]
        public int Pk_Id_UsuarioEstados { get; set; }
        public string EstadoUsuario { get; set; }
    }
}
