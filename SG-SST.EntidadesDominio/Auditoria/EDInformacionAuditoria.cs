
namespace SG_SST.EntidadesDominio.Auditoria
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EDInformacionAuditoria
    {
        public string NombreUsuario { get; set; }

        public string IdentificacionUsuario { get; set; }

        public string IpUsuario { get; set; }

        public string NombreEmpresa { get; set; }
        public string NitEmpresa { get; set; }
    }
}
