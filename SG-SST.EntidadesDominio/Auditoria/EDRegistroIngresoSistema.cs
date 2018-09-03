
namespace SG_SST.EntidadesDominio.Auditoria
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EDRegistroIngresoSistema
    {
        public int FK_Empresa { get; set; }

        public int FK_UsuarioSistema { get; set; }

        public DateTime FechaTransaccion { get; set; }
    }
}
